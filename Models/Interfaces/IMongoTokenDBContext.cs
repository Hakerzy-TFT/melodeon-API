using MongoDB.Driver;

namespace MelodeonApi.Models.Interfaces
{
    public interface IMongoTokenDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name); 
    }
}