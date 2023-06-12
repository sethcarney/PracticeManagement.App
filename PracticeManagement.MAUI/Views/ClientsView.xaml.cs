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

        public async Task DisplayPopup(bool addClient)
        {
            Client currentClient = (BindingContext as ClientsViewViewModel).SelectedClient;
            Sample popup;
            if (addClient == true)
                popup = new Sample(null);
            else
                popup = new Sample(currentClient);

            var result = await this.ShowPopupAsync(popup);

            Client newClient = result as Client;

            if (addClient)
            {
                ClientService.Current.Add(newClient);

             
            }
            (BindingContext as ClientsViewViewModel).Reset();

            
        }
        private async void Edit_Clicked(object sender, EventArgs e)
        {
            Client toEdit = (BindingContext as ClientsViewViewModel).SelectedClient;
            if (toEdit != null)
            {
               

            }
            else
                await DisplayAlert("Alert", "Please select a client to edit", "Yes");
           
            
        }
    }
}