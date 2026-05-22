using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace usersApi.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserSqlController : ControllerBase
    {
       
        [HttpPost]
        public object AddNewUser()
        {
            return new { message = "Hello"};
        }
    }
}
