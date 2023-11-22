using MySql.Data.MySqlClient;
using System.Data;

namespace WindowsFormsApp1
{
    internal class DatabaseLogic
    {
        private MySqlConnection con;

        public DatabaseLogic(string db_address, string uid, string pwd, string database = "default")
        {
            con = new MySqlConnection($"server={db_address};uid={uid};pwd={pwd};database={database}");
            Connect();
        }

        public bool Connect()
        {
            bool isOpen = IsConnectionOpen();
            if (!isOpen)
                con.Open();
            return isOpen;
        }

        public bool IsConnectionOpen() => con.State == ConnectionState.Open;

        public MySqlDataReader Execute(string request) => new MySqlCommand(request, con).ExecuteReader();

        public void Close() => con.Close();
    }

    class Example
    {
        DatabaseLogic logic;
        public void Main()
        {
            logic = new DatabaseLogic("localhost", "username", "password", "_test");
            MySqlDataReader response = logic.Execute("SELECT * FROM table");
            logic.Close();
        }
    }
}