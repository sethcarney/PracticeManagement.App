namespace PracticeManagement.MAUI.Views;
using CommunityToolkit.Maui.Views;
using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;


public partial class ProjectViewDetail : Popup
{
	public ProjectViewDetail(Project? currentProject)
	{
		InitializeComponent();
		BindingContext = new ProjectViewModel(currentProject);
	}


    private void Cancel_Clicked(object sender, EventArgs e)
    {
        //Return false to represent no change
        Close(false);
    }



    private void Submit_Clicked(object sender, EventArgs e)
    {
        //Update with new values
        bool result = (BindingContext as ProjectViewModel).VerifyandUpdate();
        Close(result);        
    }


    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            Client current = (Client) picker.SelectedItem;
            (BindingContext as ProjectViewModel).Model.Client = current;
        }
    }
}