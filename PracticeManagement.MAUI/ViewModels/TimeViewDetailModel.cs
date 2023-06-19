using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;

namespace PracticeManagement.MAUI.ViewModels
{
    public class TimeViewDetailModel
    {

        public Time? SelectedTime { get; set; }
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

        public List<Project> Projects
        {
            get { return ProjectService.Current.currentProjects;}
        }

        public Employee SelectedEmployee { get; set; }
     
        public Project SelectedProject { get; set; }


        public TimeViewDetailModel(Time? currentTime) 
        {
            SelectedTime = currentTime;
            if (SelectedTime != null)
            {
                SelectedDate = SelectedTime.Date;
                UpdatedNarrative = SelectedTime.Narrative;
                UpdatedHours = SelectedTime.Hours.ToString();
                SelectedEmployee = EmployeeService.Current.Get(SelectedTime.EmployeeId);
                SelectedProject = ProjectService.Current.Get(SelectedTime.ProjectId);
                createNew = false;
            }
            else
            {
                SelectedDate = DateTime.Today;
                UpdatedNarrative = null;
                UpdatedHours = "0.0";
                createNew = true;
            }
        }

        public bool Update()
        {
            double holder;
            var RateGiven = double.TryParse(UpdatedHours, out holder);
            if (RateGiven == false || UpdatedNarrative == null || SelectedProject == null || SelectedEmployee == null )
                return false;
            if (SelectedTime != null)
            { 
               SelectedTime.Date = SelectedDate;
                SelectedTime.Hours = holder;
               SelectedTime.Narrative = UpdatedNarrative;
                SelectedTime.ProjectId = SelectedProject.Id;
                SelectedTime.EmployeeId = SelectedEmployee.Id;
            }
            else
            {
                SelectedTime = new Time(UpdatedNarrative,SelectedDate,holder,SelectedProject.Id,SelectedEmployee.Id);
            }
            return true;
        }

  
    }
}
