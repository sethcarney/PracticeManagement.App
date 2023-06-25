using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.ApplicationModel.Communication;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;


namespace PracticeManagement.MAUI.ViewModels
{
    public class ProjectsViewViewModel : INotifyPropertyChanged
    {
        public Project SelectedProject { get; set; }

        public SearchFilters PageFilters { get; set; }

        public ICommand SearchCommand { get; set; }
        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Projects));
        }
        public ProjectsViewViewModel()
        {
            PageFilters = new SearchFilters();
            PageFilters.Filters.Add(new Filter { Name = "Show Closed", Applied = false });
            SearchCommand = new Command(ExecuteSearchCommand);

        }



        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                List<Project> filtersApplied = ProjectService.Current.applyFilters(PageFilters);
                if (string.IsNullOrEmpty(Query))
                    return new ObservableCollection<ProjectViewModel>(filtersApplied.Select(p => new ProjectViewModel(p)).ToList());
                return new ObservableCollection<ProjectViewModel>(ProjectService.Current.Search(filtersApplied,Query).Select(p => new ProjectViewModel(p)).ToList());
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
