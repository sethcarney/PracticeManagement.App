
/* Unmerged change from project 'PracticeManagement.MAUI (net7.0-ios)'
Before:
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using System;
After:
using System;
*/

/* Unmerged change from project 'PracticeManagement.MAUI (net7.0-maccatalyst)'
Before:
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using System;
After:
using System;
*/

/* Unmerged change from project 'PracticeManagement.MAUI (net7.0-windows10.0.19041.0)'
Before:
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using System;
After:
using System;
*/
using System.Windows.Input;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
/* Unmerged change from project 'PracticeManagement.MAUI (net7.0-ios)'
Before:
using System.Windows.Input;
After:
using System.Windows.Input;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
*/

/* Unmerged change from project 'PracticeManagement.MAUI (net7.0-maccatalyst)'
Before:
using System.Windows.Input;
After:
using System.Windows.Input;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
*/

/* Unmerged change from project 'PracticeManagement.MAUI (net7.0-windows10.0.19041.0)'
Before:
using System.Windows.Input;
After:
using System.Windows.Input;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
*/


namespace PracticeManagement.MAUI.ViewModels
{
    public class TimeViewModel
    {
        public Time? Model { get; set; }
        public DateTime SelectedDate { get; set; }
        public string? UpdatedNarrative { get; set; }
        public string? UpdatedHours { get; set; }
        public Employee SelectedEmployee { get; set; }
        public Project SelectedProject { get; set; }
        public TimeViewModel(Time? currentTime)
        {
            Model = currentTime;
            if (Model != null)
            {
                SelectedDate = Model.Date;
                UpdatedNarrative = Model.Narrative;
                UpdatedHours = Model.Hours.ToString();
                SelectedEmployee = Model.Employee;
                SelectedProject = Model.Project;

            }
            else
            {
                SelectedDate = DateTime.Today;
                UpdatedNarrative = null;
                UpdatedHours = "0.0";
            }
            DeleteCommand = new Command((c) => ExecuteDelete((c as TimeViewModel).Model.Id));
            Filters = new List<Filter>();
            Filters.Add(new Filter { Name = "Show Closed", Applied = false });
        }
        public ICommand DeleteCommand { get; private set; }
        public void ExecuteDelete(int id)
        {
            TimeService.Current.Delete(id);
        }
        public void Add()
        {
            TimeService.Current.Add(Model);
        }
        public bool Update()
        {
            double holder;
            var RateGiven = double.TryParse(UpdatedHours, out holder);
            if (RateGiven == false || UpdatedNarrative == null || SelectedProject == null || SelectedEmployee == null)
                return false;
            if (Model != null)
            {
                Model.Date = SelectedDate;
                Model.Hours = holder;
                Model.Narrative = UpdatedNarrative;
                Model.Project = SelectedProject;
                Model.Employee = SelectedEmployee;
            }
            else
            {
                Model = new Time(UpdatedNarrative, SelectedDate, holder, SelectedProject, SelectedEmployee);
                Add();
            }
            return true;
        }
        public List<Employee> Employees
        {
            get
            {
                return EmployeeService.Current.currentEmployees;
            }
        }
        public List<Filter> Filters { get; set; }
        public List<Project> Projects
        {
            get
            {
                //Only return open projects for potential time entries
                //return ProjectService.Current.applyFilters(FilterClosed);
                return ProjectService.Current.currentProjects;
            }
        }
        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }
    }
}
