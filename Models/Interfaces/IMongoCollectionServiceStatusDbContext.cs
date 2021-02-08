using MongoDB.Driver;

namespace MelodeonApi.Models.Interfaces
{
    public interface IMongoCollectionServiceStatusDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name); 
    }
}