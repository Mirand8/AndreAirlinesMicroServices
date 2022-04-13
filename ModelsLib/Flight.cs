using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ModelsLib
{
    public class Flight : ILoggable
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public Airport Destination { get; set; }
        public Airport Origin { get; set; }
        public Aircraft Aircraft { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime BoardingTime { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime LandTime { get; set; }
        public string LoginUser { get; set; }
    }
}
