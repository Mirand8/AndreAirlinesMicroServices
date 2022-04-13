using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AircraftApiService.Services
{
    public class AircraftService
    {
        readonly IMongoCollection<Aircraft> _aircrafts;

        public AircraftService(IAircraftApiServiceSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var dataBase = client.GetDatabase(settings.DatabaseName);
            _aircrafts = dataBase.GetCollection<Aircraft>(settings.AircraftCollectionName);
        }

        public async Task<ActionResult<IEnumerable<Aircraft>>> GetAircrafts() => await _aircrafts.Find(aircraft => true).ToListAsync();

        public async Task<ActionResult<Aircraft>> GetAircraft(string id) =>
            await _aircrafts.Find(aircraft => aircraft.Id.Equals(id)).FirstOrDefaultAsync();

        public async void CreateAircraft(Aircraft aircraft) =>
            await _aircrafts.InsertOneAsync(aircraft);

        public async void UpdateAircraft(string id, Aircraft aircraftParam) =>
            await _aircrafts.ReplaceOneAsync(aircraft => aircraft.Id.Equals(id), aircraftParam);

        public async void DeleteAircraft(string id) =>
            await _aircrafts.DeleteOneAsync(aircraft => aircraft.Id.Equals(id));
    }
}
