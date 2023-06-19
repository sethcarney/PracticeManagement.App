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
        public string? UpdatedRate { get; set; }

        public bool createNew { get; set; }

        public EmployeeViewDetailModel(Employee? currentEmployee) 
        {
            SelectedEmployee = currentEmployee;
            if (SelectedEmployee != null)
            {
                UpdatedName = SelectedEmployee.Name;
                UpdatedRate = SelectedEmployee.Rate.ToString();
                createNew = false;
            }
            else
            {
                UpdatedName = "";
                UpdatedRate = "0.00";
                createNew = true;
            }
        }

        public bool Update()
        {
            double holder;
            var RateGiven = double.TryParse(UpdatedRate, out holder);
            Math.Round(holder, 2, MidpointRounding.AwayFromZero);
            if (RateGiven == false || String.IsNullOrEmpty(UpdatedName))
                return false;

            if(SelectedEmployee != null)
            { 
               SelectedEmployee.Name = UpdatedName;
               SelectedEmployee.Rate = holder;
            }
            else
            {
                SelectedEmployee = new Employee (UpdatedName,holder);
            }
            return true;
        }

  
    }
}
