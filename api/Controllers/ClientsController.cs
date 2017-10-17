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
        public async Task<IActionResult> Get()
        {
            return Ok(await clientRepository.QueryClients());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var theReturn = await clientRepository.GetClient(id);
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
        public async Task<IActionResult> Post([FromBody]ClientModel value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(value);
            }
            await clientRepository.CreateClient(value);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]ClientModel value)
        {
            await clientRepository.UpdateClient(id, value);
            return Ok();
        }
    }
}
