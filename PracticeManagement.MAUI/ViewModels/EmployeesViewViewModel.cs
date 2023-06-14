using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel.Communication;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;

namespace PracticeManagement.MAUI.ViewModels
{
    public class EmployeesViewViewModel : INotifyPropertyChanged
    {
        public Employee SelectedEmployee { get; set; }


        public ObservableCollection<Employee> Employees
        {
            get
            {
                if(string.IsNullOrEmpty(Query))
                    return new ObservableCollection<Employee>(EmployeeService.Current.currentEmployees);
                return new ObservableCollection<Employee>(EmployeeService.Current.Search(Query));
            }
        }

        public Employee? getCurrentClient() { return SelectedEmployee; }
        public void Delete()
        {
            if (SelectedEmployee == null)
            {
                return;
            }
            EmployeeService.Current.Delete(SelectedEmployee);
            NotifyPropertyChanged("Employees");
        }

        public void Reset()
        {
            Query = "";
            NotifyPropertyChanged("Employees");
        }


        public string Query { get; set; }

        public void Search()
        {
            NotifyPropertyChanged("Employees");
        }

        public event PropertyChangedEventHandler PropertyChanged;


        //Decorator allow you to not need to specify the property name
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
