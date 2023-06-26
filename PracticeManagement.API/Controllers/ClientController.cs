using Microsoft.AspNetCore.Mvc;
using PracticeManagement.API.Database;
using PracticeManagement.Library.Models;


namespace PracticeManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
  

        public class ClientController : ControllerBase
        {


            private readonly ILogger<ClientController> _logger;

            public ClientController(ILogger<ClientController> logger)
            {
                _logger = logger;
            }

            [HttpGet]
            public IEnumerable<Client> Get()
            {
                return FakeDatabase.Clients;
            }

        }

   

}
