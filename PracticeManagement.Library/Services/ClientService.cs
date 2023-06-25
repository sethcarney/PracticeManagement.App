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
            clients = new List<Client>();
        }

        public List<Client> currentClients
        {
            get { return clients; }
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
            return clients.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Client? client)
        {

            if (client != null)
            {
                client.Id = _counter++;
                clients.Add(client);
            }
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

        public void Read()
        {
            clients.ForEach(Console.WriteLine);
        }
    }
}
