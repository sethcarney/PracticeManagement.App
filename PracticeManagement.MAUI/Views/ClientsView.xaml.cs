using System.Net.Security;
using System.Net.Sockets;
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
        private void Delete_Clicked(object sender, EventArgs e)
        {
            (BindingContext as ClientsViewViewModel).RefreshClientList();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
      
            ClientViewDetail popup = new ClientViewDetail(null);
            //await Navigation.PushModalAsync(popup);
            await this.ShowPopupAsync(popup);
            popup.Closed += (o, e) => { (BindingContext as ClientsViewViewModel).RefreshClientList(); };
           

        }

       

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var cli = (ClientViewModel) button.BindingContext;
            
            ClientViewDetail popup = new ClientViewDetail(cli.Model);
            await this.ShowPopupAsync(popup);
            popup.Closed += (o, e) => { (BindingContext as ClientsViewViewModel).RefreshClientList(); };

        }

        public async Task DisplayPopup(bool addClient)
        {
            Client currentClient = (BindingContext as ClientsViewViewModel).SelectedClient;
            ClientViewDetail popup;
            if (addClient == true)
                popup = new ClientViewDetail(null);
            else
                popup = new ClientViewDetail(currentClient);

          //   await Navigation.PushModalAsync(popup);
            
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//MainPage");
        }

        private void ClosedFilter_Clicked(object sender, EventArgs e)
        {
            (BindingContext as ClientsViewViewModel).switchClosedFilter((Button)sender); 
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