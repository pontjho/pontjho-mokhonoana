using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Absa.Assessment.Api.Client
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly ClientRepository clientRepository;

        public ClientsController(ClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new ClientModel[] {
                new ClientModel {},
                new ClientModel {}
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var theReturn = clientRepository.GetClient(id);
            if(theReturn == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(theReturn);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]ClientModel value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(value);
            }
            clientRepository.CreateClient(value);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]ClientModel value)
        {
            clientRepository.UpdateClient(id, value);
            return Ok();
        }
    }
}
