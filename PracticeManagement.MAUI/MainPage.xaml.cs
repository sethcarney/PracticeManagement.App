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
    }
}