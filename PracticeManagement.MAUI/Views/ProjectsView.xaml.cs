using System.Net.Security;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.ApplicationModel.Communication;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views
{
    public partial class ProjectsView : ContentPage
    {
  
        public ProjectsView()
        {
            InitializeComponent();
            BindingContext = new ProjectsViewViewModel();
        }

        
     
        private void Search_Clicked(object sender, EventArgs e)
        {
           (BindingContext as ProjectsViewViewModel).Search();
        }

        private  void Delete_Clicked(object sender, EventArgs e)
        {
            (BindingContext as ProjectsViewViewModel).RefreshProjectList();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            ProjectViewDetail popup = new ProjectViewDetail(null);
            bool result = (bool) await this.ShowPopupAsync(popup);
            popup.Closed += (o, e) => {
                if (result)
                    (BindingContext as ProjectsViewViewModel).RefreshProjectList();
                else
                    DisplayAlert("Alert", "Alert unable to add Project", "OK");
            };
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var cli = (ProjectViewModel)button.BindingContext;
            ProjectViewDetail popup = new ProjectViewDetail(cli.Model);
            bool result = (bool) await this.ShowPopupAsync(popup);
            popup.Closed += (o, e) =>
            {
                if (result)
                    (BindingContext as ProjectsViewViewModel).RefreshProjectList();
                else
                    DisplayAlert("Alert", "Unable to modify project", "OK");
            };
        }


        private void Back_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//MainPage");
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            (BindingContext as ProjectsViewViewModel).RefreshProjectList();
        }

   

        private void ClosedFilter_Clicked(object sender, EventArgs e)
        {
            (BindingContext as ProjectsViewViewModel).switchClosedFilter((Button)sender);
        }

        private void ClientMenu_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Clients");
        }
       

        private void EmployeesMenu_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Employees");
        }

        private void HoursMenu_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Hours");
        }

    }
}