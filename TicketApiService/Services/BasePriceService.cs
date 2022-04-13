using ModelsLib;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace TicketApiService.Services
{
    public class BasePriceService
    {
        static readonly HttpClient _client = new();

        public async static Task<BasePrice> GetBasePrice(string id)
        {
            var response = await _client.GetAsync($"https://localhost:44397/api/BasePrices/{id}");
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadAsStringAsync();
            return ExtractBasePriceJsonData(responseBody);
        }

        public static BasePrice ExtractBasePriceJsonData(string jsonObject) => JsonConvert.DeserializeObject<BasePrice>(jsonObject) ?? null;
    }
}
