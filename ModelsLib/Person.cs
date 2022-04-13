using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ModelsLib
{
    public abstract class Person : ILoggable
    {
        [BsonId]
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime BirthDate { get; set; }

        public string Email { get; set; }
        public Adress Adress { get; set; }
        public string LoginUser { get; set; }
    }
}