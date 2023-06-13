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
    public class ProjectViewDetailModel
    {

        public Project? SelectedProject { get; set; }
        public string? UpdatedShortName { get; set; }
        public string? UpdatedLongName { get; set; }

        public bool createNew { get; set; }

        public ProjectViewDetailModel(Project? currentProject) 
        {
            SelectedProject = currentProject;
            if (SelectedProject != null)
            {
                UpdatedShortName = SelectedProject.ShortName;
                UpdatedLongName = SelectedProject.LongName;
                createNew = false;
            }
            else
            {
                UpdatedShortName = "";
                UpdatedLongName = "";
                createNew = true;
            }
        }

        public void Update()
        { 
            if(SelectedProject != null)
            { 
               SelectedProject.ShortName = UpdatedShortName;
               SelectedProject.LongName = UpdatedLongName;
            }
            else
            {
                SelectedProject = new Project { ShortName = UpdatedShortName, LongName = UpdatedLongName };
            }
        }

  
    }
}
