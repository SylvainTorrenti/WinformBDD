using ConnectinBDD;
using ConnectinBDD.Properties;
using Dapper;
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
        public IEnumerable<Utilisateur> GetUtilisateurs()
        {
            try
            {
                _dbconnection.Open();
                var q = "SELECT * from utilisateurs";
                return _dbconnection.Query<Utilisateur>(q);
            }
            finally
            {
                _dbconnection.Close();
            }


        }
    }
}
