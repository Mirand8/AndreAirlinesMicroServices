using Newtonsoft.Json;

namespace ModelsLib
{
    public class Airport : ILoggable
    {
        public readonly static string SQLInsertString = "INSERT INTO Airport (City, Country, Code, Continent) VALUES (@City, @Country, @Code, @Continent)";
        public readonly static string SQLGetAllString = "SELECT Id, City, Country, Code, Continent FROM Airport";

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("continent")]
        public string Continent { get; set; }
        public string LoginUser { get; set; }
    }
}