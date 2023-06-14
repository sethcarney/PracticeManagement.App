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
            Project toEdit = (BindingContext as ProjectsViewViewModel).SelectedProject;
            if (toEdit != null)
            {
                await DisplayPopup(false);
            }
            else
                await DisplayAlert("Alert", "Please select a Project to edit", "Yes");


        }

        public async Task DisplayPopup(bool addProject)
        {
            Project currentProject = (BindingContext as ProjectsViewViewModel).SelectedProject;
            ProjectViewDetail popup;
            if (addProject == true)
                popup = new ProjectViewDetail(null);
            else
                popup = new ProjectViewDetail(currentProject);

            var result = await this.ShowPopupAsync(popup);

            if (result is Project)
            {
                Project newProject = result as Project;
                ProjectService.Current.Add(newProject);
            }
            else if(result is bool)
            {
                bool success = (bool)result;
                if (success == false)
                    return;

            }
            (BindingContext as ProjectsViewViewModel).Reset();

            
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//MainPage");
        }

    }
}