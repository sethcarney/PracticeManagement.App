using PracticeManagement.Library.Models;

namespace PracticeManagement.API.Database
{
    public class FakeDatabase
    {
        public static List<Client> Clients = new List<Client>
        {
             new Client { Id = 1, Name = "Client 1"},
              new Client { Id = 2, Name = "Client 2"}

        };
    }
}
