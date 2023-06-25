using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;

namespace PracticeManagement.MAUI.ViewModels
{
    public class ClientsViewViewModel : INotifyPropertyChanged
    {
        public Client SelectedClient { get; set; }

        public SearchFilters PageFilters { get; set; }

        public ICommand SearchCommand { get; private set; }

        public ClientsViewViewModel()
        {

            PageFilters = new SearchFilters();
            PageFilters.Filters.Add(new Filter { Name = "Show Closed", Applied = false });
            SearchCommand = new Command(ExecuteSearchCommand);
        }

        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Clients));
        }



        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                List<Client> filtersApplied = ClientService.Current.applyFilters(PageFilters);
                if (string.IsNullOrEmpty(Query))
                    return new ObservableCollection<ClientViewModel>(filtersApplied.Select(c => new ClientViewModel(c)).ToList());
                return new ObservableCollection<ClientViewModel>(ClientService.Current.Search(filtersApplied, Query).Select(c => new ClientViewModel(c)).ToList());
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

        public void Reset()
        {
            Query = "";
            NotifyPropertyChanged("Clients");
        }


        public string Query { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        //Decorator allow you to not need to specify the property name
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
