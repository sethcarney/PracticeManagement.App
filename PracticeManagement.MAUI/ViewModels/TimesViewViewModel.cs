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
    public class TimesViewViewModel : INotifyPropertyChanged
    {
        public Time SelectedTime { get; set; }


        public ObservableCollection<TimeViewModel> Times
        {
            get
            {
                if(string.IsNullOrEmpty(Query))
                    return new ObservableCollection<TimeViewModel>(TimeService.Current.currentTimes.Select(t => new TimeViewModel(t)).ToList());
                return new ObservableCollection<TimeViewModel>(TimeService.Current.Search(Query).Select(t => new TimeViewModel(t)).ToList());
            }
        }

     
        public void Reset()
        {
            Query = "";
            NotifyPropertyChanged("Times");
        }


        public string Query { get; set; }

        public void RefreshTimes()
        {
            NotifyPropertyChanged(nameof(Times));
        }

        public event PropertyChangedEventHandler PropertyChanged;


        //Decorator allow you to not need to specify the property name
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
