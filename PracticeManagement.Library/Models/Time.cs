using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeManagement.Library.Services;

namespace PracticeManagement.Library.Models
{
    public class Time
    {

        public DateTime Date { get; set; }
        public string Narrative { get; set; }
        public int Id { get; set; }  
        
        public double Hours { get; set; }

        public Project Project { get; set; }

        public Employee Employee { get; set; }

        public Time ( string narrative, DateTime date, double hrs, int ProjectID, int EmployeeID)
        {
           
            Narrative = narrative;
            Date = date;
            Hours = hrs;
            Project = ProjectService.Current.Get(ProjectID);
            Employee = EmployeeService.Current.Get(EmployeeID);

        }

        public string prettyHours
        {
            get
            {
                return String.Format("{0:0.0}", Hours) + "hrs";
            }
        }
        public override string ToString()
        {
            return $" {Date.ToShortDateString()}  {Employee.Name}  {prettyHours} \n {Project.ToString()} \t  {Narrative}  ";
        }

    }
}
