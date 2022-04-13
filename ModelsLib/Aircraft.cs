
using MongoDB.Bson.Serialization.Attributes;

namespace ModelsLib
{
    public class Aircraft
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}