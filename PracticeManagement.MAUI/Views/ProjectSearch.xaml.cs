using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

public partial class ProjectSearch : ContentView
{
	public ProjectSearch()
	{
		InitializeComponent();
        BindingContext = new ProjectSearchViewModel();
    }

    

    private void Search_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectSearchViewModel).Search();
    }


    private void ClosedFilter_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectSearchViewModel).switchClosedFilter((Button)sender);
    }
}