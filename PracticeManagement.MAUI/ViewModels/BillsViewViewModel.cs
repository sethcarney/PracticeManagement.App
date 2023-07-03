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
     
        public Project CurrentProject { get; set; }
        public BillsViewViewModel(int projectID)
        {
            if (projectID != 0)
            {
                CurrentProject = ProjectService.Current.Get(projectID);

            }
          
        }

        public void GenerateBills ()
        {
            if(CurrentProject == null)
                return;
            else
            {
                var Times = TimeService.Current.currentTimes.Where(t => t.Project == CurrentProject).ToList();
                double HrsWorked = 0;
                Times.ForEach(t => { HrsWorked += t.Hours; });
                BillService.Current.Add( new Bill(HrsWorked, 7, CurrentProject.Id));
            }

            NotifyPropertyChanged(nameof(Bills));
        }

    


        public ObservableCollection<BillViewModel> Bills
        {
            get
            {
                if (CurrentProject == null)
                    return new ObservableCollection<BillViewModel>(BillService.Current.currentBills.Select(b => new BillViewModel(b)).ToList());
                else
                    return new ObservableCollection<BillViewModel>(BillService.Current.currentBills.Where(b => b.ProjectId == CurrentProject.Id).ToList().Select(b => new BillViewModel(b)).ToList());


                
                
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
