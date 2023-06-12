using System.Net.Security;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views
{
    public partial class ClientViewDetail : ContentPage
    {
  
        public ClientViewDetail(Client currentClient)
        {
            InitializeComponent();
            BindingContext = new ClientViewDetailModel(currentClient);
        }

        public ClientViewDetail()
        {
            InitializeComponent();
            BindingContext = new ClientViewDetailModel();
        }

        private async void Submit_Clicked(object sender, EventArgs e)
        {
            (BindingContext as ClientViewDetailModel).Update();
            await Navigation.PopModalAsync();
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}