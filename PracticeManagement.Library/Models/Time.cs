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

        public Time ( string narrative, DateTime date)
        {
           
            Narrative = narrative;
            Date = date;
        }

    }
}
