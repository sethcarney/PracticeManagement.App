using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticeManagement.MAUI.ViewModels
{
    public class TimeViewModel
    {


        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }
        public ICommand DeleteCommand { get; private set; }
        public void ExecuteDelete(int id)
        {
            TimeService.Current.Delete(id);
        }
        public Time? Model { get; set; }
        public DateTime SelectedDate { get; set; }
        public string? UpdatedNarrative { get; set; }
        public string? UpdatedHours { get; set; }
        public bool createNew { get; set; }
        public List<Employee> Employees
        {
            get
            {
                return EmployeeService.Current.currentEmployees;
            }
        }
        SearchFilters FilterClosed { get; set; }
        public List<Project> Projects
        {
            get 
            {
                return ProjectService.Current.applyFilters(FilterClosed);
            }
        }
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
                SelectedEmployee = EmployeeService.Current.Get(Model.EmployeeId);
                SelectedProject = ProjectService.Current.Get(Model.ProjectId);
                createNew = false;
            }
            else
            {
                SelectedDate = DateTime.Today;
                UpdatedNarrative = null;
                UpdatedHours = "0.0";
                createNew = true;
            }
            DeleteCommand = new Command((c) => ExecuteDelete((c as TimeViewModel).Model.Id));
            FilterClosed = new SearchFilters();
            FilterClosed.Filters.Add(new Filter { Name = "Show Closed", Applied = false });
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
                Model.ProjectId = SelectedProject.Id;
                Model.EmployeeId = SelectedEmployee.Id;
            }
            else
            {
                Model = new Time(UpdatedNarrative, SelectedDate, holder, SelectedProject.Id, SelectedEmployee.Id);
                Add();
            }
            return true;
        }


    }
}
