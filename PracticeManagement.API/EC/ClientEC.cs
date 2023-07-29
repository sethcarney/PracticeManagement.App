using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticeManagement.API.Database;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Utilities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PracticeManagement.API.EC
{
    public class ClientEC
    {
        public Client AddOrUpdate(Client client)
        {
            
            if (client.Id <= 0)
            {
                using (var context = new EfContextFactory().CreateDbContext(new string[0]))
                {

                    context.Clients.Add(client);
                    context.SaveChanges();
                }
            }
            else
            {   
                using (var context = new EfContextFactory().CreateDbContext(new string[0]))
                {
                    context.Clients.Update(client);
                    context.SaveChanges();
                }
            }

            return client;
        }

        public IEnumerable<Client> Search(SearchObj searchObj)
        {
            var results = new List<Client>();
            String query = searchObj.Query;
            using (var context = new EfContextFactory().CreateDbContext(new string[0]))
            {
                foreach (var filterItem in searchObj.Filters)
                {
                    String name = filterItem.Name;
                    
                    if (filterItem.Applied)
                    {
                        //Check to see if cascading filters are applied
                        if (results.Count == 0)
                        {
                            if (name == "Show Closed" )
                                results = (List<Client>)context.Clients.Where(indexer => indexer.isActive == false).ToList();
                            if (name == "Show Open" )
                                results = (List<Client>)context.Clients.Where(indexer => indexer.isActive == true).ToList();
                            if (name == "Has Projects")
                                results = (List<Client>)context.Clients.Where(indexer => indexer.Projects.Count > 0).ToList();
                        }
                        //Query from already filtered results
                        else
                        {
                            if (name == "Show Closed")
                                results = (List<Client>)results.Where(indexer => indexer.isActive == false).ToList();
                            if (name == "Show Open")
                                results = (List<Client>)results.Where(indexer => indexer.isActive == true).ToList();
                            if (name == "Has Projects")
                                results = (List<Client>)results.Where(indexer => indexer.Projects.Count > 0).ToList();
                        }
                    }
                }

                if( query != String.Empty)
                {
                    if (results.Count == 0)
                    {
                        results = (List<Client>)context.Clients.Where(c => EF.Functions.Like(c.Name, query) || EF.Functions.Like(c.Notes, query)).ToList();
                        //c.Name.Contains(query, StringComparison.OrdinalIgnoreCase) || c.Notes.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
                    }
                    else
                    {
                        results = (List<Client>)results.Where(c => c.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 || c.Notes.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);
                    }

                }
                



            }
            return results;
        }
        //var groups = context.Products.GroupBy(p => p.CategoryId);

        public IEnumerable<Client> Get()
        {
            var results = new List<Client>();
            using (var context = new EfContextFactory().CreateDbContext(new string[0]))
            {
                results = context.Clients.ToList();
            }
            return results;
        }

        public Client Get(int id)
        {
            var result = new Client();
            using (var context = new EfContextFactory().CreateDbContext(new string[0]))
            {
                result = context.Clients.Find(id);
            }
            return result;
        }

        public bool Delete(int id)
        {
            var Client = new Client { Id= id };
            using (var context = new EfContextFactory().CreateDbContext(new string[0]))
            { 
                 
                    context.Clients.Remove(Client);
                    context.SaveChanges();
            
            }
            return true;
        }
    }
}
