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
        [HttpGet]
        public IEnumerable<ClientModel> Get()
        {
            return new ClientModel[] {
                new ClientModel {},
                new ClientModel {}
            };
        }

        [HttpGet("{id}")]
        public ClientModel Get(int id)
        {
            return new ClientModel {};
        }

        [HttpPost]
        public void Post([FromBody]ClientModel value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ClientModel value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
