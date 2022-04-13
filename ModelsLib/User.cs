using MongoDB.Bson.Serialization.Attributes;

namespace ModelsLib
{
    public class User : Person
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Sector { get; set; }
        public Function Function { get; set; }
    }
}