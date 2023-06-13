using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        Time (int id, int projectId, int employeeId, string narrative, DateTime date)
        {
            Id = id;
            ProjectId = projectId;
            EmployeeId = employeeId;
            Narrative = narrative;
            Date = date;
        }

    }
}
