﻿using System.Net.Security;
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
        private bool? result;

        public ClientsView()
        {
            InitializeComponent();
            BindingContext = new ClientsViewViewModel();
        }

        
     

        private void Close_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var cli = (ClientViewModel)button.BindingContext;
            bool result = (BindingContext as ClientsViewViewModel).Close(cli.Model);
            if(result == false)
            {
                DisplayAlert("Alert", "Unable to close client. Ensure all projects connected to client have been closed", "OK");
            }
        }
        private void Delete_Clicked(object sender, EventArgs e)
        {
            (BindingContext as ClientsViewViewModel).RefreshClientList();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            ClientViewDetail popup = new ClientViewDetail(null);
             result = (bool?)await this.ShowPopupAsync(popup);
        
            popup.Closed += (o, e) => 
            {
                if (result == true)
                {
                    (BindingContext as ClientsViewViewModel).RefreshClientList();
                }
                else if (result == false)
                {
                    DisplayAlert("Alert", "Unable to add Client.", "OK");
                }
            };
        }

       

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var cli = (ClientViewModel) button.BindingContext;
            
            ClientViewDetail popup = new ClientViewDetail(cli.Model);
            popup.Size = new Size(600, 600);
            await this.ShowPopupAsync(popup);
            popup.Closed += (o, e) => { (BindingContext as ClientsViewViewModel).RefreshClientList(); };

        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//MainPage");
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