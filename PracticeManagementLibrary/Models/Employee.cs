using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Models
{
    public class Employee
    {

        string Name { get; set; }
        double Rate { get; set; }
        int Id { get; set; }    
        public Employee(int id,string name, double rate ) 
        {
            this.Id = id;
            this.Name = name;   
            this.Rate = rate;
        }
    }
}
