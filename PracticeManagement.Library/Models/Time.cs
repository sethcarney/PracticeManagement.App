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

        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }

        public Time ( string narrative, DateTime date, double hrs, int ProjectID, int EmployeeID)
        {
           
            Narrative = narrative;
            Date = date;
            Hours = hrs;
            ProjectId = ProjectID;
            EmployeeId = EmployeeID;

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
            return $" {Date.ToShortDateString()}  {EmployeeService.Current.Get(EmployeeId).Name}  {prettyHours} \n {ProjectService.Current.Get(ProjectId)} \t  {Narrative}  ";
        }

    }
}
