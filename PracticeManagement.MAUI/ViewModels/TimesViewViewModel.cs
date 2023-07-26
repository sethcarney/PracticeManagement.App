using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;

namespace PracticeManagement.MAUI.ViewModels
{
    public class TimesViewViewModel : INotifyPropertyChanged
    {
        public Time SelectedTime { get; set; }

        public List<Filter> Filters { get; set; }

        public ICommand SearchCommand { get; set; }
        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Times));
        }

        public TimesViewViewModel()
        {
           Filters = new List<Filter>();
            Filters.Add(new Filter { Name = "Today", Applied = false });
            Filters.Add(new Filter { Name = "Show Closed", Applied = false });
            SearchCommand = new Command(ExecuteSearchCommand);
        }
        public ObservableCollection<TimeViewModel> Times
        {
            get
            {
                /*
                List<Time> filtersApplied = TimeService.Current.applyFilters(PageFilters);
                if (string.IsNullOrEmpty(Query))
                    return new ObservableCollection<TimeViewModel>(filtersApplied.Select(t => new TimeViewModel(t)).ToList());
                return new ObservableCollection<TimeViewModel>(TimeService.Current.Search(filtersApplied, Query).Select(t => new TimeViewModel(t)).ToList());
            */
                return new ObservableCollection<TimeViewModel>();
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
