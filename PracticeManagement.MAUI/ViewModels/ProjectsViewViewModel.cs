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

        public SearchFilters Filters { get; set; }

        public ProjectsViewViewModel()
        {
            Filters = new SearchFilters();

        }

        public bool Close()
        {
            if (SelectedProject == null)
                return false;

            bool result = ProjectService.Current.Close(SelectedProject);
            if (result)
                NotifyPropertyChanged("Projects");
            return result;
        }
        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                List<Project> filtersApplied = ProjectService.Current.applyFilters(Filters);
                if(string.IsNullOrEmpty(Query))
                    return new ObservableCollection<ProjectViewModel>(filtersApplied.Select(p => new ProjectViewModel(p)).ToList());
                return new ObservableCollection<ProjectViewModel>(ProjectService.Current.Search(filtersApplied,Query).Select(p => new ProjectViewModel(p)).ToList());
            }
        }

        public void switchClosedFilter(Button button)
        {
            var firstColor = button.BackgroundColor;
            if (Filters.showClosed)
            {
                button.BackgroundColor = Colors.Gray;
                Filters.showClosed = false;

            }
            else
            {
                button.BackgroundColor = Colors.MediumSeaGreen;
                Filters.showClosed = true;
            }
            NotifyPropertyChanged("Projects");
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
