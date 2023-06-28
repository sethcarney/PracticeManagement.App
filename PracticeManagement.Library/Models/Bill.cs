using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Models
{
    public class Bill
    {
        double TotalAmount { get; set; }
        DateOnly DueDate { get; set; }

        public Bill(double amount, int DaysToPay)
        {
            TotalAmount = amount;
            DueDate = DateOnly.FromDateTime(DateTime.Now).AddDays(DaysToPay);
        }
    }
}
