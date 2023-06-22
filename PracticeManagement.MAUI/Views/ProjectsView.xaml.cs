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
            

            await DisplayPopup(false);
        }

        public async Task DisplayPopup(bool addProject)
        {
            ProjectViewDetail popup;
            if (addProject == true)
                popup = new ProjectViewDetail(null);
            else
                popup = new ProjectViewDetail((BindingContext as ProjectsViewViewModel).SelectedProject);

            var result = await this.ShowPopupAsync(popup);
         
                if (result is Project)
                {
                    Project newProject = result as Project;
                    ProjectService.Current.Add(newProject);
                }
                else if (result is bool)
                {
                    bool success = (bool)result;
                    if (success == false)
                        return;

                }
                else
                {
                    await DisplayAlert("Alert", "Unable to edit/create project. Ensure a client has been selected and all fields are populated.", "OK");
                    return;
                }
                
                (BindingContext as ProjectsViewViewModel).Reset();



                    

            
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//MainPage");
        }

        private async void Close_Clicked(object sender, EventArgs e)
        {
           
            bool choice = await DisplayAlert("Confirm", "Are you sure you would like to close this project?", "Yes", "No");
            bool result = (BindingContext as ProjectsViewViewModel).Close();
            if (result)
            {
                await DisplayAlert("Success", "Project closed successfully", "OK");
            }
            else
            {
                await DisplayAlert("Alert", "Unable to close project. Project was already closed.", "OK");
            }

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