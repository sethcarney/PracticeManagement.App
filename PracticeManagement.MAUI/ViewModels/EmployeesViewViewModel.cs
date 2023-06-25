using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;

namespace PracticeManagement.MAUI.ViewModels
{
    public class EmployeesViewViewModel : INotifyPropertyChanged
    {
        public Employee SelectedEmployee { get; set; }

        public ICommand SearchCommand { get; private set; }

        public EmployeesViewViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand);
        }

        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Employees));
        }
        public ObservableCollection<EmployeeViewModel> Employees
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                    return new ObservableCollection<EmployeeViewModel>(EmployeeService.Current.currentEmployees.Select(e => new EmployeeViewModel(e)).ToList());
                return new ObservableCollection<EmployeeViewModel>(EmployeeService.Current.Search(Query).Select(e => new EmployeeViewModel(e)).ToList());
            }
        }




        public void Reset()
        {
            Query = "";
            NotifyPropertyChanged(nameof(Employees));
        }


        public string Query { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;


        //Decorator allow you to not need to specify the property name
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
