using System;
using System.Linq;
using System.Collections.Generic;

namespace Absa.Assessment.Api.Client
{
    public interface ClientRepository
    {
        ClientModel GetClient(Guid id);
        void CreateClient(ClientModel model);
        void UpdateClient(Guid id, ClientModel model);
        IEnumerable<ClientModel> QueryClients();
        void RemoveClient(Guid id);
    }
}