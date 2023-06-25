namespace PracticeManagement.MAUI.Views;
using CommunityToolkit.Maui.Views;
using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;


public partial class EmployeeViewDetail : Popup
{
	public EmployeeViewDetail(Employee? currentEmployee)
	{
		InitializeComponent();
		BindingContext = new EmployeeViewModel(currentEmployee);
	}


    private void Cancel_Clicked(object sender, EventArgs e)
    {
        //Return false to represent no change
        Close();
    }

    private void Submit_Clicked(object sender, EventArgs e)
    {
   
        Close((BindingContext as EmployeeViewModel).Update());
   
       
    }
}