using FlightApiService.Utils;
using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightApiService.Services
{
    public class FlightService
    {
        private readonly IMongoCollection<Flight> _flights;

        public FlightService(IFlightApiServiceSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var dataBase = client.GetDatabase(settings.DatabaseName);
            _flights = dataBase.GetCollection<Flight>(settings.FlightCollectionName);
        }

        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights() => await _flights.Find(client => true).ToListAsync();

        public async Task<Flight> GetFlight(string id) =>
            await _flights.Find(flight => flight.Id.Equals(id)).FirstOrDefaultAsync();

        public async void CreateFlight(Flight flight) => await _flights.InsertOneAsync(flight);

        public void UpdateFlight(string id, Flight flightParam) =>
            _flights.ReplaceOneAsync(flight => flight.Id.Equals(id), flightParam);

        public void DeleteFlight(string id) =>
            _flights.DeleteOneAsync(flight => flight.Id.Equals(id));
    }
}
