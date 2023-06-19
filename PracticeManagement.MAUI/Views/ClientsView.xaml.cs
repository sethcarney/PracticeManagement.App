using System.Net.Security;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.ApplicationModel.Communication;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views
{
    public partial class ClientsView : ContentPage
    {
  
        public ClientsView()
        {
            InitializeComponent();
            BindingContext = new ClientsViewViewModel();
        }

        
     
        private void Search_Clicked(object sender, EventArgs e)
        {
           (BindingContext as ClientsViewViewModel).Search();
        }

        private async void Close_Clicked(object sender, EventArgs e)
        {
            if(verifyClientSelected() == false)
            {
                return;
            }
            bool choice = await DisplayAlert("Confirm", "Are you sure you would like to close this client?", "Yes", "No");
            bool result = (BindingContext as ClientsViewViewModel).Close();
            if (result)
            {
                await DisplayAlert("Success", "Client closed successfully", "OK");
            }
            else
            {
                await DisplayAlert("Alert", "Unable to close client. Please ensure that there are no active projects linked to that client.", "OK");
            }
        }
        private async void Delete_Clicked(object sender, EventArgs e)
        {
            if (verifyClientSelected() == false)
            {
                return;
            }
            bool choice = await DisplayAlert("Confirm", "Are you sure you would like to delete this client?", "Yes", "No");
            if (choice)
                (BindingContext as ClientsViewViewModel).Delete();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await DisplayPopup(true);
            
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            if(verifyClientSelected() == false)
            {
                return;
            }

            await DisplayPopup(false);
        }

        public async Task DisplayPopup(bool addClient)
        {
            Client currentClient = (BindingContext as ClientsViewViewModel).SelectedClient;
            ClientViewDetail popup;
            if (addClient == true)
                popup = new ClientViewDetail(null);
            else
                popup = new ClientViewDetail(currentClient);

            var result = await this.ShowPopupAsync(popup);

            if (result is Client)
            {
                Client newClient = result as Client;
                ClientService.Current.Add(newClient);
            }
            else if(result is bool)
            {
                bool success = (bool)result;
                if (success == false)
                    return;

            }
            else
            {
                await DisplayAlert("Alert","Unable to Add/Edit Client. Ensure all fields have been populated correctly","OK");
                return;
            }
            (BindingContext as ClientsViewViewModel).Reset();

            
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//MainPage");
        }

        private void ClosedFilter_Clicked(object sender, EventArgs e)
        {
            (BindingContext as ClientsViewViewModel).switchClosedFilter((Button)sender); 
        }

        private bool verifyClientSelected()
        {
            if ((BindingContext as ClientsViewViewModel).SelectedClient == null)
            {
                DisplayAlert("Alert", "Please select a client in order to perform this operation", "OK");
                return false;
            }

            return true;
        }

        
        private void ProjectMenu_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Projects");
        }

        private void EmployeesMenu_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Employees");
        }

        private void HoursMenu_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Hours");
        }
    }
}