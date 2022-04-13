
using ModelsLib;
using System.Net.Http;
using System.Threading.Tasks;

namespace TicketApiService.Services
{
    public class FlightService
    {
        static readonly HttpClient _client = new();

        public async static Task<Flight> GetFlight(string id)
        {
            Flight flight;
            var response = await _client.GetAsync($"https://localhost:44391/api/Flights/{id}");
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadAsStringAsync();
            flight = ExtractFlightJsonData(responseBody);
            return flight;
        }

        public static Flight ExtractFlightJsonData(string jsonObject) => JsonConvert.DeserializeObject<Flight>(jsonObject) ?? null;
    }
}
