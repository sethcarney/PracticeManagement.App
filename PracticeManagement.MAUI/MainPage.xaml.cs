using System.Net.Security;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI
{
    public partial class MainPage : ContentPage
    {
  
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
           
        }

        private void ClientView_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Clients");

        }

        private void ProjectView_Clicked(Object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Projects");
        }

        private void Employee_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Employees");
        }

        private void Time_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Hours");
        }
    }
}