using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.Library.Utilities;

namespace PracticeManagement.MAUI.ViewModels
{
    public class ClientsViewViewModel : INotifyPropertyChanged
    {
        public Client SelectedClient { get; set; }

       

        public SearchObj searchObj { get; set; }
        public ICommand LocalSearchCommand { get; private set; }

        public ICommand RefreshCommand { get; private set; }

        public ICommand ResetSearchCommand { get; private set; }
        public ClientsViewViewModel()
        {

            List<Filter> Filters = new List<Filter>();
            Filters.Add(new Filter { Name = "Show Closed", Applied = false });
            Filters.Add(new Filter { Name = "Show Open", Applied = false });
            Filters.Add(new Filter { Name = "Has Projects", Applied = false });
            searchObj = new SearchObj("", Filters);
            RefreshCommand = new Command(ExecuteRefreshOrSearchCommand);
            LocalSearchCommand = new Command(ExecuteLocalSearchCommand);
            ResetSearchCommand = new Command(ExecuteResetSearchObj);
        }

        public void ExecuteRefreshOrSearchCommand()
        {
            if(searchObj.hasContent())
                ClientService.Current.Search(searchObj);
            else
                ClientService.Current.RefreshData();
            NotifyPropertyChanged(nameof(Clients));
        }
        
        //This gets called when typing in the search bar
        public void ExecuteLocalSearchCommand()
        {
            if (searchObj.Query != String.Empty)
            {
                ClientService.Current.LocalSearch(searchObj.Query);
                NotifyPropertyChanged(nameof(Clients));
            }

        }

        public void ExecuteResetSearchObj()
        {
            searchObj.Reset();
            ExecuteRefreshOrSearchCommand();
        }


        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                return new ObservableCollection<ClientViewModel>(ClientService.Current.currentClients.Select(c => new ClientViewModel(c)).ToList());
            }
        }


        public bool Close(Client current)
        {
            bool result = ClientService.Current.Close(current);
            if (result)
                NotifyPropertyChanged("Clients");
            return result;
        }
        public void RefreshClientList()
        {
            NotifyPropertyChanged(nameof(Clients));
        }

        public event PropertyChangedEventHandler PropertyChanged;


        //Decorator allow you to not need to specify the property name
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
