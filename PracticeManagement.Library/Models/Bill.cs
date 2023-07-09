using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace PracticeManagement.Library.Models
{
    public class Bill
    {
        public double TotalAmount { get; set; }
        public double TotalHours { get; set; }
        public DateOnly DueDate { get; set; }

        public int ProjectId { get; set; }
        public int Id { get; set; }

        public List<Time> Times { get; set; }
        public Bill(double amount, double hours,  List<Time> times, int DaysToPay, int projId)
        {
            TotalAmount = amount;
            TotalHours = hours;
            Times= times;
            DueDate = DateOnly.FromDateTime(DateTime.Now).AddDays(DaysToPay);
            ProjectId = projId;
            Id = 0;
        }

        public string printVal
        {
            get
            {
                string header = "Due Date: "+ DueDate + "\t" + "Total Hours Worked: " + System.String.Format("{0:0.00}",TotalHours) + "\t Amount Due: $" + System.String.Format("{0:0.00}", TotalAmount);
                string body = "";
                Times.ForEach(t => { body += t.ToString() + "\n"; });
                return header + "\n" + body;
            }
        }
        public override string ToString()
        {
            return printVal ;
        }
    }
}
