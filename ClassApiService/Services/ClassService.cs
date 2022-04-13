using ClassApiService.Utils;
using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassApiService.Services
{
    public class ClassService
    {
        readonly IMongoCollection<Class> _classes;

        public ClassService(IClassApiServiceSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _classes = database.GetCollection<Class>(settings.ClassCollectionName);
        }

        public async Task<ActionResult<IEnumerable<Class>>> GetClasses() => await _classes.Find(c => true).ToListAsync();

        public async Task<Class> GetClass(string id) =>
            await _classes.Find(c => c.Id.Equals(id)).FirstOrDefaultAsync();

        public async void CreateClass(Class @class) => await _classes.InsertOneAsync(@class);

        public void UpdateClass(string id, Class classParam) =>
            _classes.ReplaceOneAsync(c => c.Id.Equals(id), classParam);

        public void DeleteClass(string id) =>
            _classes.DeleteOneAsync(c => c.Id.Equals(id));
    }
}
