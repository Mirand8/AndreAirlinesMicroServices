using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLib
{
    public class BasePrice : ILoggable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Airport Destination { get; set; }
        public Airport Origin { get; set; }
        public double Price { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime InclusionDate { get; set; }
        public string LoginUser { get; set; }

        public double CalculatePrice(double promotionPercentage)
        {
            Price = ((promotionPercentage/100) * Price) - Price;
            return Price;
        }
    }
}
