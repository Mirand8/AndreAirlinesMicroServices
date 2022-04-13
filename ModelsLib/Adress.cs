using Newtonsoft.Json;

namespace ModelsLib
{
    public class Adress
    {
        [JsonProperty("cep")]
        public string Cep { get; set; }
        public string Country { get; set; }
        [JsonProperty("logradouro")]
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        [JsonProperty("complemento")]
        public string Complement { get; set; }
        [JsonProperty("bairro")]
        public string District { get; set; }
        [JsonProperty("localidade")]
        public string City { get; set; }
        [JsonProperty("uf")]
        public string UF { get; set; }
    }
}