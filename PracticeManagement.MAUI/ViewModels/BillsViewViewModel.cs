using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;

namespace PracticeManagement.MAUI.ViewModels
{
    public class BillsViewViewModel : INotifyPropertyChanged
    {

        private string titleString = "Billing page for: ";
        public String DisplayBillingContext { get {
                return titleString; }}
        public Project CurrentProject { get; set; }

        private List<Project> _projects = new List<Project>();
        public BillsViewViewModel(int projectID, int clientId)
        {
            if (projectID != 0)
            {
                Project current = ProjectService.Current.Get(projectID);
                titleString += $"{current.ShortName} - {current.LongName} \n {current.Client.Name}"; 
                _projects.Add(ProjectService.Current.Get(projectID));

            }
            else if(clientId != 0)
            { 
                Client current = ClientService.Current.Get(clientId);
                _projects = current.Projects;
                titleString += current.Name;
            }
            else
            {
                _projects = ProjectService.Current.currentProjects;
                titleString += "All Projects";
            }
        }

        public bool GenerateBills ()
        {
            bool result = false;
            _projects.ForEach(p => 
            {  
                if(result == false)
                    result = GenerateBill(p); 
            });
            if(result)
                NotifyPropertyChanged(nameof(Bills));
            return result;
        }

        public bool GenerateBill (Project project)
        {
            var Times = TimeService.Current.currentTimes.Where(t => t.Project == project).ToList();
            var TimesUnbilled = Times.Where(t => t.Billed == false).ToList();
            if(TimesUnbilled.Count == 0)
            {
                return false;
            }
            double TotalDue = 0;
            double TotalHours = 0;
            Times.ForEach(t => { 
                TotalDue += (t.Hours*t.Employee.Rate);
                TotalHours += t.Hours;
            });
            BillService.Current.Add(new Bill(TotalDue,TotalHours, TimesUnbilled, 7, project.Id));
            TimesUnbilled.ForEach(t => { t.Billed = true; });
            return true;
        }
    


        public ObservableCollection<BillViewModel> Bills
        {
            get
            {

                if (  _projects == ProjectService.Current.currentProjects)
                    return new ObservableCollection<BillViewModel>(BillService.Current.currentBills.Select(b => new BillViewModel(b)).ToList());
                else
                {
                    List<Bill> currentSelection = new List<Bill>();
                    _projects.ForEach(
                        p =>
                        {
                            currentSelection.AddRange(BillService.Current.GetByProjId(p.Id));
                        });
                    return new ObservableCollection<BillViewModel>(currentSelection.Select(b => new BillViewModel(b)).ToList());
                }                
            }
        }


   

        public void Reset()
        {
            NotifyPropertyChanged("Bills");
        }



        public event PropertyChangedEventHandler PropertyChanged;


        //Decorator allow you to not need to specify the property name
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
