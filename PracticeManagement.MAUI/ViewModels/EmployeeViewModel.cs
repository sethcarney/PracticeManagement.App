using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticeManagement.MAUI.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Model { get; set; }
        public string? UpdatedName { get; set; }
        public string? UpdatedRate { get; set; }

  


        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public ICommand DeleteCommand { get; private set; }
        public void ExecuteDelete(int id)
        {
            EmployeeService.Current.Delete(id);
        }

    
        public EmployeeViewModel(Employee currentEmployee) {

            
            if (currentEmployee != null)
            {
                Model = currentEmployee;
                UpdatedName = Model.Name;
                UpdatedRate = Model.Rate.ToString();
         
            }
            else
            {
                UpdatedName = "";
                UpdatedRate = "0.00";
               
            }


            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as EmployeeViewModel).Model.Id));

            
        

        }

       
        public void Add()
        {
            EmployeeService.Current.Add(Model);
        }


        
    
 

      



        public bool Update()
        {
            double holder;
            var RateGiven = double.TryParse(UpdatedRate, out holder);
            Math.Round(holder, 2, MidpointRounding.AwayFromZero);
            if (RateGiven == false || String.IsNullOrEmpty(UpdatedName))
                return false;

            if (Model != null)
            {
                Model.Name = UpdatedName;
                Model.Rate = holder;
            }
            else
            {
                Model = new Employee(UpdatedName, holder);
                Add();
            }
            return true;
        }





    }
}
