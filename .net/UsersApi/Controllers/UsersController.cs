using Microsoft.AspNetCore.Mvc;
using UsersApi.Services;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(UsersGateway gateway) : ControllerBase
    {
        private readonly UsersGateway _gateway = gateway;

        [HttpGet(Name = "GetUserByIdAsync")]
        public async Task<IActionResult> GetUserByIdAsync(long id)
        {
            var user = await _gateway.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(new User(user.Id, user.FirstName, user.LastName, user.Email));
        }
    }

    public record User(long Id, string FirstName, string LastName, string Email);
}
