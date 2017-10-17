using System;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Absa.Assessment.Api.Client
{
    public class MongoClientRepository : ClientRepository
    {
        private IMongoCollection<ClientModel> collection;

        public MongoClientRepository(IMongoCollection<ClientModel> collection)
        {
            this.collection = collection;
        }

        public async Task<ClientModel> GetClient(Guid id)
        {
            return await collection.Find(f => f.Id == id)
                .SingleAsync();
        }

        public async Task CreateClient(ClientModel model)
        {
            await collection.InsertOneAsync(model);
        }

        public async Task UpdateClient(Guid id, ClientModel model)
        {
            var query = Builders<ClientModel>.Filter.Where(f => f.Id == id);
            await collection.FindOneAndReplaceAsync(query, model);
        }

        public async Task<IEnumerable<ClientModel>> QueryClients()
        {
            return await collection.Find(r => true).ToListAsync();
        }
    }
}