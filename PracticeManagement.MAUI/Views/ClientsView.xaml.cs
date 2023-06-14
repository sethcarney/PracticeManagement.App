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
            bool choice = await DisplayAlert("Alert", "Are you sure you would like to close this client?", "Yes", "No");

            bool result = (BindingContext as ClientsViewViewModel).Close();
        }
        private async void Delete_Clicked(object sender, EventArgs e)
        {
            bool choice = await DisplayAlert("Alert", "Are you sure you would like to delete this client?", "Yes", "No");
            if(choice)
                (BindingContext as ClientsViewViewModel).Delete();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await DisplayPopup(true);
            
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            Client toEdit = (BindingContext as ClientsViewViewModel).SelectedClient;
            if (toEdit != null)
            {
                await DisplayPopup(false);
            }
            else
                await DisplayAlert("Alert", "Please select a client to edit", "Yes");


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
            (BindingContext as ClientsViewViewModel).Reset();

            
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//MainPage");
        }
    }
}