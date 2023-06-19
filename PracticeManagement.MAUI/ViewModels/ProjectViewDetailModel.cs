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

        public Client ? SelectedClient { get; set; }

        public bool createNew { get; set; }

        public List <Client> Clients
        {
            get
            {
                    return new List<Client>(ClientService.Current.currentClients);
            }
        }

        
        public ProjectViewDetailModel(Project? currentProject) 
        {
            SelectedProject = currentProject;
            if (SelectedProject != null)
            {
                UpdatedShortName = SelectedProject.ShortName;
                UpdatedLongName = SelectedProject.LongName;
                SelectedClient = currentProject.Client;
                createNew = false;
            }
            else
            {
                UpdatedShortName = "";
                UpdatedLongName = "";
                createNew = true;
            
            }
        }

        public bool VerifyandUpdate()
        { 
            if(SelectedClient == null || String.IsNullOrEmpty(UpdatedLongName) || String.IsNullOrEmpty(UpdatedShortName))
               return false;
            


            if(SelectedProject != null)
            { 
               SelectedProject.ShortName = UpdatedShortName;
               SelectedProject.LongName = UpdatedLongName;
                if (!SelectedClient.Equals(SelectedProject.Client))
                {
                    SelectedProject.Client.Projects.Remove(SelectedProject);
                    SelectedProject.Client = SelectedClient;
                    SelectedClient.Projects.Add(SelectedProject);
                }
            }
            else
            {
                SelectedProject = new Project (UpdatedShortName, UpdatedLongName, SelectedClient);
                SelectedClient.Projects.Add(SelectedProject);
            }
            return true;
        }

        private void Client_Changed(object sender, EventArgs e)
        {
            //Return false to represent no change
            var test = new Object { };
        }


    }
}
