using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Absa.Assessment.Api.Client
{
    public interface ClientRepository
    {
        Task<ClientModel> GetClient(Guid id);
        Task CreateClient(ClientModel model);
        Task UpdateClient(Guid id, ClientModel model);
        Task<IEnumerable<ClientModel>> QueryClients();
    }
}