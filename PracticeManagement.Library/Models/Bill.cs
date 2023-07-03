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
        public DateOnly DueDate { get; set; }

        public int ProjectId { get; set; }
        public int Id { get; set; }
        public Bill(double amount, int DaysToPay, int projId)
        {
            TotalAmount = amount;
            DueDate = DateOnly.FromDateTime(DateTime.Now).AddDays(DaysToPay);
            ProjectId = projId;
        }

        public string printVal
        {
            get
            {
                return DueDate + "\t$" + System.String.Format("{0:0.00}", TotalAmount);
            }
        }
        public override string ToString()
        {
            return printVal ;
        }
    }
}
