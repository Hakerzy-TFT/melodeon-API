using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MelodeonApi.Models
{
    public class Token
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { set; get; }

        public string Name { set; get; }
        public string AuthString { set; get; }
        public string Created { set; get; }
    }
}