using System.Net.Security;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.ApplicationModel.Communication;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views
{
    public partial class EmployeesView : ContentPage
    {
  
        public EmployeesView()
        {
            InitializeComponent();
            BindingContext = new EmployeesViewViewModel();
        }

        
     
        private void Search_Clicked(object sender, EventArgs e)
        {
           (BindingContext as EmployeesViewViewModel).Search();
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            bool choice = await DisplayAlert("Alert", "Are you sure you would like to delete this Employee?", "Yes", "No");
            if(choice)
                (BindingContext as EmployeesViewViewModel).Delete();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await DisplayPopup(true);
            
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            Employee toEdit = (BindingContext as EmployeesViewViewModel).SelectedEmployee;
            if (toEdit != null)
            {
                await DisplayPopup(false);
            }
            else
                await DisplayAlert("Alert", "Please select a Employee to edit", "Yes");


        }

        public async Task DisplayPopup(bool addEmployee)
        {
            Employee currentEmployee = (BindingContext as EmployeesViewViewModel).SelectedEmployee;
            EmployeeViewDetail popup;
            if (addEmployee == true)
                popup = new EmployeeViewDetail(null);
            else
                popup = new EmployeeViewDetail(currentEmployee);

            var result = await this.ShowPopupAsync(popup);

            if (result is Employee)
            {
                Employee newEmployee = result as Employee;
                EmployeeService.Current.Add(newEmployee);
            }
            else if(result is bool)
            {
                bool success = (bool)result;
                if (success == false)
                    return;

            }
            (BindingContext as EmployeesViewViewModel).Reset();

            
        }
     
    }
}