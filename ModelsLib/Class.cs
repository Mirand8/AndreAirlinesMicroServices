using MongoDB.Bson.Serialization.Attributes;

namespace ModelsLib
{
    public class Class
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
    }
}