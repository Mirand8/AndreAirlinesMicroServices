using ModelsLib;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BasePriceApiService.Services
{
    public class AirportService
    {
        static readonly HttpClient _client = new();

        public async static Task<Airport> GetAirport(int id)
        {
            Airport airport;
            var response = await _client.GetAsync($"https://localhost:44307/api/Airports/{id}");
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadAsStringAsync();
            airport = ExtractAirportJsonData(responseBody);
            return airport;
        }

        public static Airport ExtractAirportJsonData(string jsonObject) => JsonConvert.DeserializeObject<Airport>(jsonObject) ?? null;
    }
}
