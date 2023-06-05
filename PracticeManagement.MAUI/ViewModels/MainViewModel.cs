using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;

namespace PracticeManagement.MAUI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Client SelectedClient { get; set; }
        public ObservableCollection<Client> Clients
        {
            get
            {
                if(string.IsNullOrEmpty(Query))
                    return new ObservableCollection<Client>(ClientService.Current.currentClients);
                return new ObservableCollection<Client>(ClientService.Current.Search(Query));
            }
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
