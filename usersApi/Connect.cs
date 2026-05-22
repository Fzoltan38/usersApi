using MySqlConnector;

namespace usersApi
{
    public class Connect
    {
        public string Server;
        public string DataBase;
        public string UserName;
        public string Password;
        public string ConnectionString;

        public MySqlConnection MySqlConnection;
       
        public Connect()
        {
            Server = "localhost";
            DataBase = "webshop";
            UserName = "root";
            Password = "";

            ConnectionString = $"SERVER={Server};DATABASE={DataBase};UID={UserName};PASSWORD={Password}";

            MySqlConnection = new MySqlConnection(ConnectionString);

        }

    }
}
