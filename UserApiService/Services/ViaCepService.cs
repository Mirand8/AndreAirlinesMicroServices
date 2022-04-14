using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace UserApiService.Services
{
    public class ViaCepService
    {
        static readonly HttpClient _client = new();

        public async static Task<Adress> GetViaCepAdress(string cep)
        {
            Adress adress;
            var response = await _client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadAsStringAsync();
            adress = ExtractAdressJsonData(responseBody);
            adress.Country = "Brasil";
            return adress;
        }

        public static Adress ExtractAdressJsonData(string jsonObject) => JsonConvert.DeserializeObject<Adress>(jsonObject) ?? null;
    }
}
