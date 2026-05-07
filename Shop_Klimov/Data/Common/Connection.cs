using MySql.Data.MySqlClient;

namespace Shop_Klimov.Data.Common
{
    public class Connection
    {
        readonly static string ConnectionData = "server=localhost;port=3307;database=Shop;uid=root;pwd=;";

        public static MySqlConnection MySqlOpen()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionData);
            mySqlConnection.Open();

            return mySqlConnection;
        }

        public static void MySqlClose(MySqlConnection connection)
        {
            connection.Close();
        }

        public static MySqlDataReader MySqlQuery(string Query, MySqlConnection Connection)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(Query, Connection);
            return mySqlCommand.ExecuteReader();
        }
    }
}
