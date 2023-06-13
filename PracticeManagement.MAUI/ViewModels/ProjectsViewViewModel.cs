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
    public class ProjectsViewViewModel : INotifyPropertyChanged
    {
        public Project SelectedProject { get; set; }


        public ObservableCollection<Project> Projects
        {
            get
            {
                if(string.IsNullOrEmpty(Query))
                    return new ObservableCollection<Project>(ProjectService.Current.currentProjects);
                return new ObservableCollection<Project>(ProjectService.Current.Search(Query));
            }
        }

        public Project? getCurrentClient() { return SelectedProject; }
        public void Delete()
        {
            if (SelectedProject == null)
            {
                return;
            }
            ProjectService.Current.Delete(SelectedProject);
            NotifyPropertyChanged("Projects");
        }

        public void Reset()
        {
            Query = "";
            NotifyPropertyChanged("Projects");
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
