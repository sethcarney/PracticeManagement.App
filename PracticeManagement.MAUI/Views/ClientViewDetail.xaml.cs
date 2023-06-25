namespace PracticeManagement.MAUI.Views;
using CommunityToolkit.Maui.Views;
using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;

public partial class ClientViewDetail : Popup
{
    public ClientViewDetail(Client? currentClient)
    {
        InitializeComponent();
        BindingContext = new ClientViewModel(currentClient);
    }


    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    private void Submit_Clicked(object sender, EventArgs e)
    {
        //Update with new values
        bool result = (BindingContext as ClientViewModel).Update();

        Close(result);

    }
}