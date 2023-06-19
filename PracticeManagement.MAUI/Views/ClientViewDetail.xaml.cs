namespace PracticeManagement.MAUI.Views;
using CommunityToolkit.Maui.Views;
using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;


public partial class ClientViewDetail : Popup
{
	public ClientViewDetail(Client? currentClient)
	{
		InitializeComponent();
		BindingContext = new ClientViewDetailModel(currentClient);
	}


    private void Cancel_Clicked(object sender, EventArgs e)
    {
        //Return false to represent no change
        Close(false);
    }

    private void Submit_Clicked(object sender, EventArgs e)
    {
        //Update with new values
        bool success = (BindingContext as ClientViewDetailModel).Update();
        //Return new client if created
        if (success)
        {
            if ((BindingContext as ClientViewDetailModel).createNew)
                Close((BindingContext as ClientViewDetailModel).SelectedClient);
            //Return true if successfully updated
            else
                Close(true);
        }
        else
            Close();
    }
}