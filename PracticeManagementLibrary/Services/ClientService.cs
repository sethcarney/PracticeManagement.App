using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Read()
        {
            clients.ForEach(Console.WriteLine);
        }
    }
}
