using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PracticeManagement.Library.Models;

namespace PracticeManagement.Library.Services
{
    public class EmployeeService
    {
        private static EmployeeService? instance;
        private List<Employee> Employees;
        private static object _lock = new object();
        private static int _counter = 1;
        public static EmployeeService Current
        {
            get
            {
                //Thread safety, mission critical
                lock(_lock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeService();
                    }
                }
                return instance;
            }
        }

        private EmployeeService() 
        {
            Employees = new List<Employee>();
          
        }

        public List<Employee> currentEmployees
        {
            get { return Employees; }
        }

        public Employee? Get(int id)
        {
            return Employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee? Get(Employee employee)
        {
            return Employees.FirstOrDefault(e => e == employee);
        }

        public void Add(Employee? Employee)
        {   

            if(Employee != null)
            {
                Employee.Id = _counter++;
                Employees.Add(Employee);
            }
        }



        public void Delete(int id)
        {
            var toRemove = Get(id);
            if (toRemove != null)
            {
                Employees.Remove(toRemove);
            }
        }

        public void Delete(Employee s)
        {
            Delete(s.Id);
        }

        public List<Employee> Search (string query)
        {
            return Employees.Where(s => s.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ).ToList();
        }

        public void Read()
        {
            Employees.ForEach(Console.WriteLine);
        }
    }
}
