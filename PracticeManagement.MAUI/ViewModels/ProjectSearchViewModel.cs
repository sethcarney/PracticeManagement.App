﻿using System;
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
    public class ProjectSearchViewModel : INotifyPropertyChanged
    {
        public Project SelectedProject { get; set; }

        public SearchFilters Filters { get; set; }

        public ProjectSearchViewModel()
        {
            Filters = new SearchFilters();
        }

       
        public ObservableCollection<Project> Projects
        {
            get
            {
                List<Project> filtersApplied = ProjectService.Current.applyFilters(Filters);
                if(string.IsNullOrEmpty(Query))
                    return new ObservableCollection<Project>(filtersApplied);
                return new ObservableCollection<Project>(ProjectService.Current.Search(filtersApplied,Query));
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
