using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MelodeonApi.Models
{
    public class ServiceStatus
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { set; get; }
        public bool webApp { set; get; }
        public bool api { set; get; }
        public bool db { set; get; }
    }
}