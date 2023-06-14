using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Models
{
    public class Employee
    {

        public string Name { get; set; }
        public double Rate { get; set; }
        public int Id { get; set; }    
        public Employee(string name, double rate ) 
        {
            this.Name = name;   
            this.Rate = rate;
        }
    }
}
