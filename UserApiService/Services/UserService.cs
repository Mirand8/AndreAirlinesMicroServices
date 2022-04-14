using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserApiService.Utils;

namespace UserApiService.Services
{
    public class UserService
    {
        readonly IMongoCollection<User> _users;

        public UserService(IUserApiServiceSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public async Task<ActionResult<IEnumerable<User>>> GetUsers() =>
            await _users.Find(user => true).ToListAsync();

        public async Task<ActionResult<User>> GetUser(string login) =>
            await _users.Find(user => user.Login.Equals(login)).FirstOrDefaultAsync();

        public async void CreateUser(User user) =>
            await _users.InsertOneAsync(user);

        public async void UpdateUser(string login, User user) =>
            await _users.ReplaceOneAsync(user => user.Login.Equals(login), user);

        public async void DeleteUser(string login) =>
            await _users.DeleteOneAsync(user => user.Login.Equals(login));
    }
}
