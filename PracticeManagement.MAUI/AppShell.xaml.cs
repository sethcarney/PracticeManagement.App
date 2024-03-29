﻿namespace PracticeManagement.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private void HoursMenu_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Hours");
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

        private void HomeMenu_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//MainPage");
        }

        private void BillingMenu_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Bills?projectId=0&clientId=0");
        }
    }
}