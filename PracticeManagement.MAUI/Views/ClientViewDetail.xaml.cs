namespace PracticeManagement.MAUI.Views;
using CommunityToolkit.Maui.Views;
using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;

public partial class ClientViewDetail : Popup
{
	public ClientViewDetail(Client? currentClient)
	{
		InitializeComponent();
		BindingContext = new ClientViewModel (currentClient);
	}


    private    void Cancel_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PopModalAsync();
    }

    private   void Submit_Clicked(object sender, EventArgs e)
    {
        //Update with new values
        (BindingContext as ClientViewModel).Update();
        //await Navigation.PopModalAsync();
        Close(true);
        //Return new client if created
        /*
        if (success)
        {
            if ((BindingContext as ClientViewModel).createNew)
               // Close((BindingContext as ClientViewModel).Model);
            //Return true if successfully updated
            else
                //Close(true);
        }
        else
            //Close();
    */
    }
}