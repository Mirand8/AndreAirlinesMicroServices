using LogApiService.Utils;
using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogApiService.Services
{
    public class LogService
    {
        readonly IMongoCollection<Log> _logs;

        public LogService(ILogApiServiceSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _logs = database.GetCollection<Log>(settings.LogCollectionName);
        }

        public async Task<ActionResult<IEnumerable<Log>>> GetLogs() => await _logs.Find(log => true).ToListAsync();

        public async Task<Log> GetLog(string id) =>
            await _logs.Find(log => log.Id.Equals(id)).FirstOrDefaultAsync();

        public async void CreateLog(Log log) => await _logs.InsertOneAsync(log);

        public void UpdateLog(string id, Log logParam) =>
            _logs.ReplaceOneAsync(log => log.Id.Equals(id), logParam);

        public void DeleteLog(string id) =>
            _logs.DeleteOneAsync(log => log.Id.Equals(id));
    }
}
