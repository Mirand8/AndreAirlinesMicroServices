using ModelsLib;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlightApiService.Services
{
    public class AircraftService
    {
        static readonly HttpClient _client = new();

        public async static Task<Aircraft> GetAircraft(string id)
        {
            Aircraft aircraft;
            var response = await _client.GetAsync($"https://localhost:44337/api/Aircrafts/{id}");
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadAsStringAsync();
            aircraft = ExtractAircraftJsonData(responseBody);
            return aircraft;
        }

        public static Aircraft ExtractAircraftJsonData(string jsonObject) => JsonConvert.DeserializeObject<Aircraft>(jsonObject) ?? null;
    }
}
