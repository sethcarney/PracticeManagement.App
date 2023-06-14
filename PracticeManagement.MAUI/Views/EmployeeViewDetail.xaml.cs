namespace PracticeManagement.MAUI.Views;
using CommunityToolkit.Maui.Views;
using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;


public partial class EmployeeViewDetail : Popup
{
	public EmployeeViewDetail(Employee? currentEmployee)
	{
		InitializeComponent();
		BindingContext = new EmployeeViewDetailModel(currentEmployee);
	}


    private void Cancel_Clicked(object sender, EventArgs e)
    {
        //Return false to represent no change
        Close(false);
    }

    private void Submit_Clicked(object sender, EventArgs e)
    {
        //Update with new values
        (BindingContext as EmployeeViewDetailModel).Update();
        //Return new client if created
        if((BindingContext as EmployeeViewDetailModel).createNew)
            Close((BindingContext as EmployeeViewDetailModel).SelectedEmployee);
        //Return true if successfully updated
        else
            Close(true);
    }
}