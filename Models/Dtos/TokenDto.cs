namespace MelodeonApi.Models.Dtos
{
    public class TokenDto
    {
        // [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        public string _id { set; get; }
        public string tokenAuth { set; get; }
        public string spotifyAuth { set; get; }
        // [BsonRepresentation(BsonType.ObjectId)]
        public string configuration { set; get; }
    }
}