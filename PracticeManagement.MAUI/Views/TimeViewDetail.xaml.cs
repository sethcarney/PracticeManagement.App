namespace PracticeManagement.MAUI.Views;
using CommunityToolkit.Maui.Views;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.ViewModels;


public partial class TimeViewDetail : Popup
{
	public TimeViewDetail(Time? currentTime)
	{
		InitializeComponent();
		BindingContext = new TimeViewDetailModel(currentTime);
	}

   

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        //Return false to represent no change
        Close(false);
    }

    private void Submit_Clicked(object sender, EventArgs e)
    {
        //Update with new values
        bool success = (BindingContext as TimeViewDetailModel).Update();
        //Return new client if created
        if (success)
        {
            if ((BindingContext as TimeViewDetailModel).createNew)
                Close((BindingContext as TimeViewDetailModel).SelectedTime);
            //Return true if successfully updated
            else
                Close(true);
        }
        else
        { Close(); }
    }
}