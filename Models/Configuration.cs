using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MelodeonApi.Models
{
    public class Configuration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { set; get; }
        public string lastLogin { set; get; }
    }
}