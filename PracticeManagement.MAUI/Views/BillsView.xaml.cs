using CommunityToolkit.Maui.Views;
using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views
{
    [QueryProperty(nameof(ProjectId), "projectId")]
    [QueryProperty(nameof(ClientId), "clientId")]
    public partial class BillsView : ContentPage
    {
        public BillsView()
        {
            InitializeComponent();
           
        }
        public int ProjectId { get; set; }
        public int ClientId { get; set; }

        private void OnArriving(object sender, NavigatedToEventArgs e)
        {
            BindingContext = new BillsViewViewModel(ProjectId,ClientId);
            
        }

        private async void GenerateBills_Clicked(object sender, EventArgs e)
        {
           bool result = (BindingContext as BillsViewViewModel).GenerateBills();
            if (result)
                await DisplayAlert("Success", "Bills Generated", "OK");
            else
                await DisplayAlert("Error", "No Unbilled Hours", "OK");
        }
    }
}