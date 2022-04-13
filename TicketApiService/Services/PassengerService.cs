using ModelsLib;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace TicketApiService.Services
{
    public class PassengerService
    {
        static readonly HttpClient _client = new();

        public async static Task<Passenger> GetPassenger(string cpf)
        {
            var response = await _client.GetAsync($"https://localhost:44365/api/Passenger/{cpf}");
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadAsStringAsync();
            return ExtractPassengerJsonData(responseBody);
        }

        public static Passenger ExtractPassengerJsonData(string jsonObject) => JsonConvert.DeserializeObject<Passenger>(jsonObject) ?? null;
    }
}
