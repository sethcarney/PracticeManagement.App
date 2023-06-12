﻿using System.Net.Security;
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

        private void Add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ClientViewDetail());
            (BindingContext as ClientsViewViewModel).Reset();
        }
        private async void Edit_Clicked(object sender, EventArgs e)
        {
            Client toEdit = (BindingContext as ClientsViewViewModel).SelectedClient;
            if (toEdit != null)
            {
                await Navigation.PushModalAsync(new ClientViewDetail(toEdit));
                (BindingContext as ClientsViewViewModel).Reset();

            }
            else
                await DisplayAlert("Alert", "Please select a client to edit", "Yes");
           
            
        }
    }
}