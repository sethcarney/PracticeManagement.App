using PracticeManagement.Library.Models;

namespace PracticeManagement.API.Database
{
    public class FakeDatabase
    {
        public static List<Client> Clients = new List<Client>
        {
             new Client (1, "Client 1", "notes"),
              new Client (2, "Client 2", "notes")

        };

        public static int LastClientId =>
             Clients.Any() ? Clients.Select(c => c.Id).Max() : 0; 
        
    }
}
