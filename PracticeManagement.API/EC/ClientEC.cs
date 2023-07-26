﻿using PracticeManagement.API.Database;
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
            return FakeDatabase.Clients.
                Where(c => c.Name.ToUpper()
                    .Contains(searchObj.Query.ToUpper())).Take(1000);
        }
    }
}
