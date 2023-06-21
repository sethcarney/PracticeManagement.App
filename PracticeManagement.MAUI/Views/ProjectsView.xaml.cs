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

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            if (verifyProjectSelected() == false)
                return;

            bool choice = await DisplayAlert("Alert", "Are you sure you would like to delete this Project?", "Yes", "No");
            if(choice)
                (BindingContext as ProjectsViewViewModel).Delete();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await DisplayPopup(true);
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            if (verifyProjectSelected() == false)
                return;

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

        private bool verifyProjectSelected()
        {
            if ((BindingContext as ProjectsViewViewModel).SelectedProject == null)
            {
                DisplayAlert("Alert", "Please select a project in order to perform this operation", "OK");
                return false;
            }

            return true;
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