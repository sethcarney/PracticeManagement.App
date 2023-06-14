using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;

namespace PracticeManagement.MAUI.ViewModels
{
    public class EmployeeViewDetailModel
    {

        public Employee? SelectedEmployee { get; set; }
        public string? UpdatedName { get; set; }
        public double? UpdatedRate { get; set; }

        public bool createNew { get; set; }

        public EmployeeViewDetailModel(Employee? currentEmployee) 
        {
            SelectedEmployee = currentEmployee;
            if (SelectedEmployee != null)
            {
                UpdatedName = SelectedEmployee.Name;
                UpdatedRate = SelectedEmployee.Rate;
                createNew = false;
            }
            else
            {
                UpdatedName = "";
                UpdatedRate = 0.0;
                createNew = true;
            }
        }

        public void Update()
        { 
            if(SelectedEmployee != null)
            { 
               SelectedEmployee.Name = UpdatedName;
               SelectedEmployee.Rate = (double)UpdatedRate;
            }
            else
            {
                SelectedEmployee = new Employee (UpdatedName,(double)UpdatedRate);
            }
        }

  
    }
}
