using System;
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
            clients.Add(new Client
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
        }

        public List<Client> currentClients
        {
            get { return clients; }
        }

        public Client? Get(int id)
        {
            return clients.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Client? client)
        {
            if(client != null)
            {
                clients.Add(client);
            }
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

        public List<Client> Search (string query)
        {
            return clients.Where(s => s.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public void Read()
        {
            clients.ForEach(Console.WriteLine);
        }
    }
}
