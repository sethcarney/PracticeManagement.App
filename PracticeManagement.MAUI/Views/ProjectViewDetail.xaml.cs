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
        Close();
    }

    private void ClosedFilter_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectsViewViewModel).switchClosedFilter((Button)sender);
    }

    private void Submit_Clicked(object sender, EventArgs e)
    {
        //Update with new values
        bool result = (BindingContext as ProjectViewDetailModel).VerifyandUpdate();

        if (result)
        {
            //Return new client if created
            if ((BindingContext as ProjectViewDetailModel).createNew)
                Close((BindingContext as ProjectViewDetailModel).SelectedProject);
            //Return true if successfully updated
            else
                Close(true);

        }

        Close(false);
        
    }


    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            Client current = (Client) picker.SelectedItem;
            (BindingContext as ProjectViewDetailModel).SelectedProject.Client = current;
        }
    }
}