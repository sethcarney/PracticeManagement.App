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
                int id = MsSqlContext.Current.insertClient(client);
            }

            return client;
        }

        public IEnumerable<Client> Search(SearchObj searchObj)
        {
            return MsSqlContext.Current.filterClients(searchObj);
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
