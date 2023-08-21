using ConnectinBDD.Properties;
using MySql.Data.MySqlClient;

namespace WinformBDD
{
    internal class db
    {
        private readonly MySqlConnection _dbconnection;

        public db() 
        {
            _dbconnection = new(Settings.Default.dbConnect);
        }

        public void Connect()
        {
            _dbconnection?.Open();
        }
        public void Disconnect()
        {
            _dbconnection?.Close();
        }
    }
}
