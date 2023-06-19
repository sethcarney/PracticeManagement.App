using System.Net.Security;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.ApplicationModel.Communication;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views
{
    public partial class TimesView : ContentPage
    {
  
        public TimesView()
        {
            InitializeComponent();
            BindingContext = new TimesViewViewModel();
        }

        
     
        private void Search_Clicked(object sender, EventArgs e)
        {
           (BindingContext as TimesViewViewModel).Search();
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            bool choice = await DisplayAlert("Alert", "Are you sure you would like to delete this Time?", "Yes", "No");
            if(choice)
                (BindingContext as TimesViewViewModel).Delete();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await DisplayPopup(true);
            
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            Time toEdit = (BindingContext as TimesViewViewModel).SelectedTime;
            if (toEdit != null)
            {
                await DisplayPopup(false);
            }
            else
                await DisplayAlert("Alert", "Please select a Time to edit", "Yes");


        }

        public async Task DisplayPopup(bool addTime)
        {
            Time currentTime = (BindingContext as TimesViewViewModel).SelectedTime;
            TimeViewDetail popup;
            if (addTime == true)
                popup = new TimeViewDetail(null);
            else
                popup = new TimeViewDetail(currentTime);

            // Set the desired width and height of the popup window
            popup.Size = new Size(400,600);
       

            var result = await this.ShowPopupAsync(popup);

            if (result is Time)
            {
                Time newTime = result as Time;
                TimeService.Current.Add(newTime);
            }
            else if(result is bool)
            {
                bool success = (bool)result;
                if (success == false)
                    return;

            }
            else
            {
                await DisplayAlert("Alert", "Unable to add/edit timesheet properly. Please ensure all values have been specified.", "OK");
                return;
            }
            (BindingContext as TimesViewViewModel).Reset();

            
        }


        private void ClientMenu_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Clients");
        }
        private void ProjectMenu_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Projects");
        }

        private void EmployeesMenu_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Employees");
        }

        

    }
}