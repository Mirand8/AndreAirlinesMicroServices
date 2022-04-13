using BasePriceApiService.Utils;
using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasePriceApiService.Services
{
    public class BasePriceService
    {
        readonly IMongoCollection<BasePrice> _basePrices;

        public BasePriceService(IBasePriceApiServiceSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _basePrices = database.GetCollection<BasePrice>(settings.DatabaseName);
        }

        public async Task<ActionResult<IEnumerable<BasePrice>>> GetBasePrices() => await _basePrices.Find(basePrice => true).ToListAsync();

        public async Task<BasePrice> GetBasePrice(string id) =>
            await _basePrices.Find(basePrice => basePrice.Id.Equals(id)).FirstOrDefaultAsync();

        public async void CreateBasePrice(BasePrice basePrice) => await _basePrices.InsertOneAsync(basePrice);

        public void UpdateBasePrice(string id, BasePrice basePriceParam) =>
            _basePrices.ReplaceOneAsync(basePrice => basePrice.Id.Equals(id), basePriceParam);

        public void DeleteBasePrice(string id) =>
            _basePrices.DeleteOneAsync(basePrice => basePrice.Id.Equals(id));
    }
}
