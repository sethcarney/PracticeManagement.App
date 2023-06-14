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
    public class ClientViewDetailModel
    {

        public Client? SelectedClient { get; set; }
        public string? UpdatedName { get; set; }
        public string? UpdatedNotes { get; set; }

        public List<Project> linkedProjects { get; set; }
        public bool createNew { get; set; }

        
        public ClientViewDetailModel(Client currentClient) 
        {
            SelectedClient = currentClient;
            if (SelectedClient != null)
            {
                UpdatedName = SelectedClient.Name;
                UpdatedNotes = SelectedClient.Notes;
                linkedProjects = SelectedClient.Projects;
                createNew = false;
            }
            else
            {
                UpdatedName = "";
                UpdatedNotes = "";
                createNew = true;
            }
        }

        public void Update()
        { 
            if(SelectedClient != null)
            { 
               SelectedClient.Name = UpdatedName;
               SelectedClient.Notes = UpdatedNotes;
            }
            else
            {
                
                SelectedClient = new Client (UpdatedName,UpdatedNotes);
            }
        }

  
    }
}
