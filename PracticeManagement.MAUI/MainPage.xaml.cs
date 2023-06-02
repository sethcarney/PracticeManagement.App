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

        
     
        private void Button_Clicked(object sender, EventArgs e)
        {
            //(BindingContext as MainViewModel).Test1 = "Clicked";
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Delete();
        }
    }
}