using CommunityToolkit.Maui.Views;
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
        private void Close_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var cli = (ClientViewModel)button.BindingContext;
            bool result = (BindingContext as ClientsViewViewModel).Close(cli.Model);
            if (result == false)
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
            await this.ShowPopupAsync(popup);

            popup.Closed += (o, e) =>
            {
                if(e.WasDismissedByTappingOutsideOfPopup)
                    return;

                bool result = (bool)e.Result;

                if (result == true)
                {
                    (BindingContext as ClientsViewViewModel).RefreshClientList();
                }
                else if (result == false)
                {
                    DisplayAlert("Alert", "Unable to add Client.", "OK");
                }
                else
                {
                    DisplayAlert("Alert", "Undefined behavior.", "OK");
                }
            };
        }
        private async void Edit_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var cli = (ClientViewModel)button.BindingContext;
            ClientViewDetail popup = new ClientViewDetail(cli.Model);
            popup.Size = new Size(600, 600);
            await this.ShowPopupAsync(popup);
            popup.Closed += (o, e) => { (BindingContext as ClientsViewViewModel).RefreshClientList(); };
        }
    }
}