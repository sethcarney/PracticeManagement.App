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
        public ICommand SearchCommand { get; private set; }

        public ICommand RefreshCommand { get; private set; }
        public ClientsViewViewModel()
        {

            List<Filter> Filters = new List<Filter>();
            Filters.Add(new Filter { Name = "Show Closed", Applied = false });
            searchObj = new SearchObj("", Filters);
            SearchCommand = new Command(ExecuteSearchCommand);
            RefreshCommand = new Command(ExecuteRefreshCommand);
        }

        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Clients));
        }

        public void ExecuteRefreshCommand()
        {
            ClientService.Current.RefreshData();
            NotifyPropertyChanged(nameof(Clients));
        }


        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {

                if (searchObj.hasContent() == true)
                    ClientService.Current.Search(searchObj);

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
