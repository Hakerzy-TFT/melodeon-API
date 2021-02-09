using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MelodeonApi.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Token
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string TokenAuth { get; set; }
        public string SpotifyAuth { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Configuration { get; set; }
    }

}