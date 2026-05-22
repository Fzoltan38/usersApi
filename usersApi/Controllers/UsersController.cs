using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace usersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public User GetName([FromBody]User user)
        {
            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return newUser;
        }

        [HttpGet("url")]
        public object GetNameUrl(string first, string last)
        {
            return new { firstName = first, lastName = last };
        }

        [HttpGet("szamol")]
        public object Szamol(int x, int y)
        {
            return new { eredmeny = x + y };
        }
    }

    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
