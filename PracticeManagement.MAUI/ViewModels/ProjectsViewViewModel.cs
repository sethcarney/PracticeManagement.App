using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;


namespace PracticeManagement.MAUI.ViewModels
{
    public class ProjectsViewViewModel : INotifyPropertyChanged
    {
        public Project SelectedProject { get; set; }

        public List<Filter> Filters { get; set; }

        public ICommand SearchCommand { get; set; }
        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Projects));
        }
        public ProjectsViewViewModel()
        {
            Filters = new List<Filter>();
            Filters.Add(new Filter { Name = "Show Closed", Applied = false });
            SearchCommand = new Command(ExecuteSearchCommand);

        }



        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
               /* List<Project> filtersApplied = ProjectService.Current.applyFilters(PageFilters);
                if (string.IsNullOrEmpty(Query))
                    return new ObservableCollection<ProjectViewModel>(filtersApplied.Select(p => new ProjectViewModel(p)).ToList());
                return new ObservableCollection<ProjectViewModel>(ProjectService.Current.Search(filtersApplied, Query).Select(p => new ProjectViewModel(p)).ToList());
            */
               return new ObservableCollection<ProjectViewModel>();
                }
        }




        public void Reset()
        {
            Query = "";
            NotifyPropertyChanged("Projects");
        }

        public void RefreshProjectList()
        {
            NotifyPropertyChanged(nameof(Projects));
        }
        public string Query { get; set; }

        public void Search()
        {
            NotifyPropertyChanged("Projects");
        }

        public event PropertyChangedEventHandler PropertyChanged;


        //Decorator allow you to not need to specify the property name
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
