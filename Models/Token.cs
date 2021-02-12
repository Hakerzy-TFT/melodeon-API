using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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
        public string tokenAuth { set; get; }
        public string spotifyAuth { set; get; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string configuration { set; get; }
    }
}