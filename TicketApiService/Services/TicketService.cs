using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketApiService.Utils;

namespace TicketApiService.Services
{
    public class TicketService
    {
        readonly IMongoCollection<Ticket> _tickets;

        public TicketService(ITicketApiServiceSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var dataBase = client.GetDatabase(settings.DatabaseName);
            _tickets = dataBase.GetCollection<Ticket>(settings.TicketCollectionName);
        }

        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets() => await _tickets.Find(ticket => true).ToListAsync();

        public async Task<ActionResult<Ticket>> GetTicket(string id) =>
            await _tickets.Find(ticket => ticket.Id.Equals(id)).FirstOrDefaultAsync();

        public async void CreateTicket(Ticket ticket) =>
            await _tickets.InsertOneAsync(ticket);

        public async void UpdateTicket(string id, Ticket ticketParam) =>
            await _tickets.ReplaceOneAsync(ticket => ticket.Id.Equals(id), ticketParam);

        public async void DeleteTicket(string id) =>
            await _tickets.DeleteOneAsync(ticket => ticket.Id.Equals(id));
    }
}
