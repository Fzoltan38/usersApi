using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using usersApi.Models;

namespace usersApi.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserSqlController : ControllerBase
    {
        Connect conn = new Connect();

        [HttpPost]
        public ActionResult AddNewUser([FromBody]Users users)
        {
            try
            {
                var user = new Users
                {
                    UserName = users.UserName,
                    Email = users.Email,
                    Password = users.Password
                };

                conn.MySqlConnection.Open();

                string sql = $"INSERT INTO `users`(`username`, `email`, `password`, `createdtime`) VALUES (@username,@email,@password,@createdtime)";

                MySqlCommand cmd = new MySqlCommand(sql, conn.MySqlConnection);

                cmd.Parameters.AddWithValue("@username", user.UserName);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@createdtime", user.CreatedTime);

                cmd.ExecuteNonQuery();

                conn.MySqlConnection.Close();

                return StatusCode(201, new { message = "Sikeres felvétel!" });


               
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
          
        }
       
        [HttpGet]
        public ActionResult GetAllUser()
        {

            List<Users> users = new List<Users>();
            try
            {
                conn.MySqlConnection.Open();

                string sql = "SELECT * FROM users";

                MySqlCommand cmd = new MySqlCommand(sql, conn.MySqlConnection);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var user = new Users
                    {
                        Id = dr.GetInt32(0),
                        UserName = dr.GetString("username"),
                        Email = dr.GetString("email"),
                        Password = dr.GetString("password")
                       
                    };

                    users.Add(user);
                }
                conn.MySqlConnection.Close();

                return StatusCode(200, new { message = "Sikeres lekésrdezés.", result = users });

               
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                conn.MySqlConnection.Open();

                string sql = "DELETE FROM users WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conn.MySqlConnection);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                conn.MySqlConnection.Close();

                return StatusCode(200, new { message = "Sikeres törlés."});
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }
    }
}
