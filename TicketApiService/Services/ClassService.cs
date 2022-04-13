using ModelsLib;
using System.Net.Http;
using System.Threading.Tasks;

namespace TicketApiService.Services
{
    public class ClassService
    {
        static readonly HttpClient _client = new();

        public async static Task<Class> GetClass(string id)
        {
            var response = await _client.GetAsync($"https://localhost:44397/api/Classes/{id}");
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadAsStringAsync();
            return ExtractClassJsonData(responseBody);
        }

        public static Class ExtractClassJsonData(string jsonObject) => JsonConvert.DeserializeObject<Class>(jsonObject) ?? null;
    }
}
