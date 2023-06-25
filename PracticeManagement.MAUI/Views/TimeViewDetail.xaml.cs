namespace PracticeManagement.MAUI.Views;
using CommunityToolkit.Maui.Views;
using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;


public partial class TimeViewDetail : Popup
{
    public TimeViewDetail(Time? currentTime)
    {
        InitializeComponent();
        BindingContext = new TimeViewModel(currentTime);
    }
    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    private void Submit_Clicked(object sender, EventArgs e)
    {
        Close((BindingContext as TimeViewModel).Update());
    }
}