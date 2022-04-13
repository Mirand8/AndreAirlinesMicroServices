using PassengerApiService.Utils;
using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using ModelsLib.DataValidations;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PassengerApiService.Services
{
    public class PassengerService
    {
        private readonly IMongoCollection<Passenger> _passengers;

        public PassengerService(IPassengerApiServiceSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var dataBase = client.GetDatabase(settings.DatabaseName);
            _passengers = dataBase.GetCollection<Passenger>(settings.PassengerCollectionName);
        }

        public async Task<ActionResult<IEnumerable<Passenger>>> GetPassengers() => await _passengers.Find(passenger => true).ToListAsync();

        public async Task<Passenger> GetPassenger(string cpf) =>
            await _passengers.Find(passenger => passenger.Cpf == cpf).FirstOrDefaultAsync();

        public async void CreatePassenger(Passenger passenger) => await _passengers.InsertOneAsync(passenger);

        public void UpdatePassenger(string cpf, Passenger passengerParam) =>
            _passengers.ReplaceOneAsync(passenger => passenger.PassportCode.Equals(cpf), passengerParam);

        public void DeletePassenger(string cpf) =>
            _passengers.DeleteOneAsync(passenger => passenger.PassportCode.Equals(cpf));
    }
}
