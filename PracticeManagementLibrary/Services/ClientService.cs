using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PracticeManagement.Library.Models;

namespace PracticeManagement.Library.Services
{
    public class ClientService
    {
        private static ClientService? instance;
        private List<Client> clients;
        private static object _lock = new object();
        private static int _counter = 1;
        public static ClientService Current
        {
            get
            {
                //Thread safety, mission critical
                lock(_lock)
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
            clients = new List<Client>();
            /*
             * clients.Add(new Client
                        {
                            Id = 1,
                            Name = "BOB",
                            Notes = "Is cool"
                        });
            clients.Add(new Client
            {
                Id = 1,
                Name = "Susan",
                Notes = "Is even cooler"
            });
            */
        }

        public List<Client> currentClients
        {
            get { return clients; }
        }

        public List<Client> applyFilters (SearchFilters filter)
        {
            List<Client> closedFilter = clients.Where(s => s.isActive != filter.showClosed).ToList();
            return closedFilter;
        }

        public Client? Get(int id)
        {
            return clients.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Client? client)
        {   

            if(client != null)
            {
                client.Id = _counter++;
                clients.Add(client);
            }
        }

        public bool Close(Client client)
        {
            foreach (var project in client.Projects)
            {
                if (project.IsActive)
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

        public List<Client> Search (List<Client> currentContext,string query)
        {
            return currentContext.Where(s => s.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public void Read()
        {
            clients.ForEach(Console.WriteLine);
        }
    }
}
