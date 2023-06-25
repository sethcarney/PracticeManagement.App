using System.Net.Security;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.ApplicationModel.Communication;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views
{
    public partial class TimesView : ContentPage
    {

        bool? result;
        public TimesView()
        {
            InitializeComponent();
            BindingContext = new TimesViewViewModel();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            TimeViewDetail popup = new TimeViewDetail(null);
            result = (bool?)await this.ShowPopupAsync(popup);
            popup.Closed += (o, e) => {
                if (result == true)
                    (BindingContext as TimesViewViewModel).RefreshTimes();
                else if (result == false)
                    DisplayAlert("Alert", "Alert unable to add time entry", "OK");
            };

        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var cli = (TimeViewModel)button.BindingContext;
            TimeViewDetail popup = new TimeViewDetail(cli.Model);
            result = (bool?)await this.ShowPopupAsync(popup);
            popup.Closed += (o, e) =>
            {
                if (result == true)
                    (BindingContext as TimesViewViewModel).RefreshTimes();
                else if (result == false)
                    DisplayAlert("Alert", "Unable to modify time entry", "OK");

            };

        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            (BindingContext as EmployeesViewViewModel).Reset();
        }
       

        

    }
}