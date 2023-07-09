using System.Net;
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

        private ClientService()
        {
            var response = new WebRequestHandler().Get("/Client/All").Result;
            clients = !string.IsNullOrEmpty(response) ? JsonConvert.DeserializeObject<List<Client>>(response) : new List<Client>();
        }

        public List<Client> currentClients
        {
            get 
            {
                return clients;
            }
        }

        public List<Client> applyFilters(SearchFilters filter)
        {
            List<Client> filtered = currentClients;
            foreach (var filterItem in filter.Filters)
            {
                if (filterItem.Name == "Show Closed")
                    filtered = filtered.Where(c => c.isActive != filterItem.Applied).ToList();
            }
            return filtered;
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

        public void Add(Client? client)
        {
            
            if (client != null)
            {
                client.Id = _counter++;
                clients.Add(client);
            }
            /*
             * var response = new WebRequestHandler().Post("/Client", c).Result;
            var UpdatedClient = Json.DeserializeObject<Client>(response);
            if(UpdatedClient != null)
            {
                var ExistingClient = clients.FirstOrDefault( c => c.Id == UpdatedClient.Id);
                if(ExistingClient == null)
                    clients.Add(UpdatedClient);
                else
                {
                    var index = clients.IndexOf(ExistingClient)
                    clients.RemoveAt(index);
                    clients.Insert(index,UpdatedClient);                
                }
            }
            */
        }

        public bool Close(Client client)
        {
            if (client.isActive == false)
            {
                client.isActive = true;
                return true;
            }

            foreach (var project in client.Projects)
            {
                if (project.isActive)
                    return false;
            }

            client.isActive = false; return true;
        }
        public void Delete(int id)
        {
            var toRemove = Get(id);
            if (toRemove != null)
            {
                clients.Remove(toRemove);
            }
        }

        public void Delete(Client s)
        {
            Delete(s.Id);
        }

        public List<Client> Search(List<Client> currentContext, string query)
        {
            return currentContext.Where(s => s.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

       
    }
}
