using CommunityToolkit.Maui.Views;
using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views
{
    [QueryProperty(nameof(ProjectId), "projectId")]
    public partial class BillsView : ContentPage
    {


       
        
            
            
         

          
        
        public BillsView()
        {
            InitializeComponent();
           
        }
        public int ProjectId { get; set; }

        private void OnArriving(object sender, NavigatedToEventArgs e)
        {
            BindingContext = new BillsViewViewModel(ProjectId);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            (BindingContext as BillsViewViewModel).GenerateBills();
        }
    }
}