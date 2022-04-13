using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLib
{
    public class Ticket : ILoggable
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public Flight Flight { get; set; }
        public Passenger Passenger { get; set; }
        public double Price { get; set; }
        public Class Class { get; set; }
        public BasePrice BasePrice { get; set; }
        public double PromotionPercentage { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime RegisterDate { get; set; }
        public string LoginUser { get; set; }
    }
}
