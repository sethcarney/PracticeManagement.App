using PracticeManagement.API.Database;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Utilities;

namespace PracticeManagement.API.EC
{
    public class ClientEC
    {
        public Client AddOrUpdate(Client client)
        {
            if (client.Id > 0)
            {
                var clientToUpdate
                    = FakeDatabase.Clients
                    .FirstOrDefault(c => c.Id == client.Id);
                if(clientToUpdate != null) {
                    FakeDatabase.Clients.Remove(clientToUpdate);
                }
                FakeDatabase.Clients.Add(client);
            }
            else
            {
                client.Id = FakeDatabase.LastClientId + 1;
                FakeDatabase.Clients.Add(client);
            }

            return client;
        }

        public IEnumerable<Client> Search(SearchObj searchObj)
        {
            var context = FakeDatabase.Clients.Take(1000);
            if(!string.IsNullOrEmpty(searchObj.Query))
            {
                context = FakeDatabase.Clients.
                Where(c => c.Name.ToUpper()
                    .Contains(searchObj.Query.ToUpper())).Take(1000);
            }

            foreach (var filterItem in searchObj.Filters)
            {
                if (filterItem.Name == "Show Closed")
                   context = context.Where(c => c.isActive != filterItem.Applied).ToList();
            }
            return context;
        }


        public Client? Delete(int id)
        {
            var clientToDelete
                = FakeDatabase.Clients
                .FirstOrDefault(c => c.Id == id);
            if(clientToDelete != null)
            {
                FakeDatabase.Clients.Remove(clientToDelete);
                return clientToDelete;
            }
            return null;
        }
    }
}
