using MelodeonApi.Models;
using MelodeonApi.Models.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MelodeonApi.BusinessLogic
{
    public class ServiceStatusDbContext : IMongoCollectionDbContext, IMongoCollectionServiceStatusDbContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }

        public ServiceStatusDbContext(IOptions<MongoSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.Connection);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}