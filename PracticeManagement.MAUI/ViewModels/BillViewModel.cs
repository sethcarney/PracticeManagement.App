

using System.Windows.Input;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;



namespace PracticeManagement.MAUI.ViewModels
{
    public class BillViewModel
    {
        public Bill Model { get; set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        

        public BillViewModel(Bill Bill)
        {
            if (Bill == null)
            {
                Model = null;
            }
            else
                Model = Bill;


        }

 
         
    }
}
