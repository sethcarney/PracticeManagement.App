﻿using System;
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

        public ClientViewDetailModel(Client currentClient) 
        {
            SelectedClient = currentClient;
            if (SelectedClient != null)
            {
                UpdatedName = SelectedClient.Name;
                UpdatedNotes = SelectedClient.Notes;
            }
        }

        public ClientViewDetailModel( )
        {
            
            UpdatedName = "";
            UpdatedNotes = "";
            
        }

        public void Update()
        { if(SelectedClient != null)
            { 
               SelectedClient.Name = UpdatedName;
               SelectedClient.Notes = UpdatedNotes;
            }
            else
            {
                var newestClient = new Client { Name = UpdatedName, Notes = UpdatedNotes };
                ClientService.Current.Add(newestClient);
            }
        }

  
    }
}