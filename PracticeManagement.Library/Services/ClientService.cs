﻿using System.Net;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Utilities;

namespace PracticeManagement.Library.Services
{
    public class ClientService
    {
        private static ClientService? instance;
        private static object _lock = new object();
        private static int _counter = 1;

        private List<Client> clients = new List<Client>();
        public static ClientService Current
        {
            get
            {
                //Thread safety, mission critical
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ClientService();
                    }
                }
                return instance;
            }
        }


        public void RefreshData()
        {
            var response = new WebRequestHandler().Get("/Client").Result;
            clients = !string.IsNullOrEmpty(response) ? JsonConvert.DeserializeObject<List<Client>>(response) : new List<Client>();
        }

        private ClientService()
        {
            RefreshData();
        }

        public List<Client> currentClients
        {
            get 
            {
                return clients;
            }
        }

       
        public Client? Get(int id)
        {
          /*  var response = new WebRequestHandler().
                .Get($"/Client/GetClients/{id}").Results;
            var client = JsonConvert.DeserializeObject<Client>(response);
            return client ?? new Client();
            */

            return currentClients.FirstOrDefault(e => e.Id == id);
        }

        public void AddOrUpdate(Client c)
        {

            var response
                = new WebRequestHandler().Post("/Client", c).Result;
            //MISSING CODE
            var myUpdatedClient = JsonConvert.DeserializeObject<Client>(response);
            if (myUpdatedClient != null)
            {
                var existingClient = clients.FirstOrDefault(c => c.Id == myUpdatedClient.Id);
                if (existingClient == null)
                {
                    clients.Add(myUpdatedClient);
                }
                else
                {
                    var index = clients.IndexOf(existingClient);
                    clients.RemoveAt(index);
                    clients.Insert(index, myUpdatedClient);
                }
            }
            return;
        }

        public bool Close(Client client)
        {
            if (client.isActive == false)
            {
                client.isActive = true;
                AddOrUpdate(client);
                return true;
            }

            foreach (var project in client.Projects)
            {
                if (project.isActive)
                    return false;
            }

            client.isActive = false;
            AddOrUpdate(client);
            return true;
        }
        public void Delete(int id)
        {
            clients.Remove(clients.FirstOrDefault(c => c.Id == id));
            
            //Remove from server
            var response = new WebRequestHandler().Delete($"/Client/{id}").Result;
            
            //clients.Remove(clients.FirstOrDefault(c => c.Id == id));

        }

        public void Delete(Client s)
        {
            Delete(s.Id);  
        }

        public void Search(SearchObj s)
        {
            var response = new WebRequestHandler().Post("/Client/Search", s).Result;
            clients = JsonConvert.DeserializeObject<List<Client>>(response) ?? new List<Client>();

        }

        public void LocalSearch(string query)
        {
            var result = clients.Where(c => c.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 || c.Notes.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (result.Count > 0)
                clients = result;
            else if(clients.Count == 0)
                RefreshData();
        }
    }
}
