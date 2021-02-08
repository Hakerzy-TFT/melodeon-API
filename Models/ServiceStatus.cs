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
        public bool WebService { set; get; }
        public bool Api { set; get; }
        public bool Database { set; get; }
    }
}