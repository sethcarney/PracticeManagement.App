namespace PracticeManagement.MAUI.Views;
using CommunityToolkit.Maui.Views;
using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;


public partial class Sample : Popup
{
	public Sample(Client? currentClient)
	{
		InitializeComponent();
		BindingContext = new ClientViewDetailModel(currentClient);

	}


  
  

    void OnYesButtonClicked(object? sender, EventArgs e) => Close(true);

    void OnNoButtonClicked(object? sender, EventArgs e) => Close(false);

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Close(false);

    }

    private void Submit_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewDetailModel).Update();
        Close((BindingContext as ClientViewDetailModel).SelectedClient);
    }
}