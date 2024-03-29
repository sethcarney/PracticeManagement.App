﻿using CommunityToolkit.Maui.Views;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views
{
    public partial class EmployeesView : ContentPage
    {

        bool? result;
        public EmployeesView()
        {
            InitializeComponent();
            BindingContext = new EmployeesViewViewModel();
        }
        private async void Add_Clicked(object sender, EventArgs e)
        {
            EmployeeViewDetail popup = new EmployeeViewDetail(null);
            result = (bool?)await this.ShowPopupAsync(popup);
            popup.Closed += (o, e) =>
            {
                if (result == true)
                    (BindingContext as EmployeesViewViewModel).Reset();
                else if (result == false)
                    DisplayAlert("Alert", "Alert unable to add Employee", "OK");
            };

        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var cli = (EmployeeViewModel)button.BindingContext;
            EmployeeViewDetail popup = new EmployeeViewDetail(cli.Model);
            result = (bool?)await this.ShowPopupAsync(popup);
            popup.Closed += (o, e) =>
            {
                if (result == true)
                    (BindingContext as EmployeesViewViewModel).Reset();
                else if (result == false)
                    DisplayAlert("Alert", "Unable to modify project", "OK");

            };
        }
        private void Delete_Clicked(object sender, EventArgs e)
        {
            (BindingContext as EmployeesViewViewModel).Reset();
        }
    }
}