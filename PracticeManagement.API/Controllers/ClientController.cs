﻿using Microsoft.AspNetCore.Mvc;
using PracticeManagement.API.Database;
using PracticeManagement.API.EC;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Utilities;


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
                return new ClientEC().Get();
            }

            [HttpGet("{id}")]
            public Client GetId(int id)
            {
                return new ClientEC().Get(id);
            }

            [HttpDelete("{id}")]
            public bool Delete(int id)
            {
               return new ClientEC().Delete(id);
            }

            [HttpPost]
            public Client AddOrUpdate([FromBody] Client client)
            {
                return new ClientEC().AddOrUpdate(client);
            }

            

            [HttpPost]
            [Route("Search")]
            public IEnumerable<Client> Search([FromBody] SearchObj searchInfo)
            {
                return new ClientEC().Search(searchInfo);
            }


    }



}
