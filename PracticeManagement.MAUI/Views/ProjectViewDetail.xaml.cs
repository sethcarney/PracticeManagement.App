namespace PracticeManagement.MAUI.Views;
using CommunityToolkit.Maui.Views;
using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;


public partial class ProjectViewDetail : Popup
{
	public ProjectViewDetail(Project? currentProject)
	{
		InitializeComponent();
		BindingContext = new ProjectViewDetailModel(currentProject);
	}


    private void Cancel_Clicked(object sender, EventArgs e)
    {
        //Return false to represent no change
        Close(false);
    }

    private void Submit_Clicked(object sender, EventArgs e)
    {
        //Update with new values
        (BindingContext as ProjectViewDetailModel).Update();
        //Return new client if created
        if((BindingContext as ProjectViewDetailModel).createNew)
            Close((BindingContext as ProjectViewDetailModel).SelectedProject);
        //Return true if successfully updated
        else
            Close(true);
    }
}