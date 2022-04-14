using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using ModelsLib.DataValidations;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserApiService.Services;

namespace UserApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get() =>
            await _userService.GetUsers();

        [HttpGet("{login}", Name = "GetUser")]
        public async Task<ActionResult<User>> Get(string login)
        {
            var user = await _userService.GetUser(login);

            if (user == null) return NotFound("User not found!");

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            if (!user.Login.Equals("adm")) return Unauthorized("Unauthorized access!");
            if (user.LoginUser == null) return Unauthorized("Login user cannot be null");
            if (!PersonDataValidation.IsCpfValid(user.Cpf)) return BadRequest("Invalid CPF!");
            if (user.Adress.Cep == null) return BadRequest("Adress CEP cannot be null");

            var adress = await ViaCepService.GetViaCepAdress(user.Adress.Cep);
            if (adress == null) return BadRequest("CEP do not exists!");
            user.Adress = adress;

            _userService.CreateUser(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(string id, User user)
        {
            if (await _userService.GetUser(user.Login) == null) return NotFound("Login not found");
            if (!user.Function.Description.Equals("ADM")) return Unauthorized("Unauthorized access!");
            if (user.LoginUser == null) return BadRequest("Login user cannot be null");

            _userService.UpdateUser(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(string login)
        {
            if (await _userService.GetUser(login) == null) return NotFound("User not found");

            _userService.DeleteUser(login);
            return NoContent();
        }
    }
}
