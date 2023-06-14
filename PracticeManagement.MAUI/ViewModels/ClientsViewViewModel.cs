using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel.Communication;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;

namespace PracticeManagement.MAUI.ViewModels
{
    public class ClientsViewViewModel : INotifyPropertyChanged
    {
        public Client SelectedClient { get; set; }

        public SearchFilters Filters { get; set; }

        public ClientsViewViewModel() 
        {
            Filters = new SearchFilters();
        }

        public void switchClosedFilter(Button button)
        {
            var firstColor = button.BackgroundColor;
            if(Filters.showClosed)
            {
                button.BackgroundColor = Colors.Gray;
                Filters.showClosed = false;

            }
            else
            {
                button.BackgroundColor = Colors.MediumSeaGreen;
                Filters.showClosed = true;
            }
            NotifyPropertyChanged("Clients");
        }

        public ObservableCollection<Client> Clients
        {
            get
            {
                List<Client> filtersApplied = ClientService.Current.applyFilters(Filters);
                if (string.IsNullOrEmpty(Query))
                    return new ObservableCollection<Client>(filtersApplied);
                return new ObservableCollection<Client>(ClientService.Current.Search(filtersApplied,Query));
            }
        }


        public bool Close()
        {
            if (SelectedClient == null)
                return false;
            
            bool result = ClientService.Current.Close(SelectedClient);
            if (result)
                NotifyPropertyChanged("Clients");
            return result;
        }
        public void Delete()
        {
            if (SelectedClient == null)
            {
                return;
            }
            ClientService.Current.Delete(SelectedClient);
            NotifyPropertyChanged("Clients");
        }

        public void Reset()
        {
            Query = "";
            NotifyPropertyChanged("Clients");
        }


        public string Query { get; set; }

        public void Search()
        {
            NotifyPropertyChanged("Clients");
        }

        public event PropertyChangedEventHandler PropertyChanged;


        //Decorator allow you to not need to specify the property name
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
