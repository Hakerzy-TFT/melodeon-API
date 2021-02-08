using MongoDB.Driver;

namespace MelodeonApi.Models.Interfaces
{
    public interface IMongoCollectionDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name); 
    }
}