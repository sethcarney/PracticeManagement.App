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

        public string printVal
        {
            get
            {
                return Name + "\t$" + String.Format("{0:0.00}", Rate) + "/hr";
            }
        }
        public override string ToString()
        {
            return printVal;
        }
    }
}
