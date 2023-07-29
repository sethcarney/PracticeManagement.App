using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using PracticeManagement.API.Database;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Utilities;

namespace PracticeManagement.API.EC
{
    public class ClientEC
    {
        public Client AddOrUpdate(Client client)
        {
            /*if (client.Id > 0)
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
            */
            if (client.Id <= 0)
            {
                using (var context = new EfContextFactory().CreateDbContext(new string[0]))
                {

                    context.Clients.Add(client);
                    context.SaveChanges();
                }
            }

            return client;
        }

        public IEnumerable<Client> Search(SearchObj searchObj)
        {
            var results = new List<Client>();
            using (var context = new EfContextFactory().CreateDbContext(new string[0]))
            {
                foreach (var filterItem in searchObj.Filters)
                {
                    if (filterItem.Name == "Show Closed")
                        results = (List<Client>)context.Clients.Where(indexer => indexer.isActive != filterItem.Applied).ToList();
                }

            }
            return results;
        }
        //var groups = context.Products.GroupBy(p => p.CategoryId);


        public bool Delete(int id)
        {
           var result = MsSqlContext.Current.deleteClient(id);
           return Convert.ToBoolean(result);
        }
    }
}
