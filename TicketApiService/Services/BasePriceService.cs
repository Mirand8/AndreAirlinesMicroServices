using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TicketApiService.Services
{
    public class BasePriceService
    {
        static readonly HttpClient _client = new();

        public async static Task<BasePrice> GetBasePrice(string id)
        {
            var response = await _client.GetAsync($"https://localhost:44335/api/BasePrices/{id}");
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadAsStringAsync();
            return ExtractBasePriceJsonData(responseBody);
        }

        public async static Task<ActionResult<bool>> CreateBasePrice(BasePrice newBasePrice)
        {
            var basePriceJsonObject = JsonConvert.SerializeObject(newBasePrice);
            var data = new StringContent(basePriceJsonObject, Encoding.UTF8, "application/json");

            var url = "https://localhost:44397/api/BasePrices/";

            var response = await _client.PostAsync(url, data);

            return response.IsSuccessStatusCode;
        }

        public static BasePrice ExtractBasePriceJsonData(string jsonObject) => JsonConvert.DeserializeObject<BasePrice>(jsonObject) ?? null;
    }
}
