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
            //Creation de la connection avec le chemin mis en Setting
            _dbconnection = new(Settings.Default.dbConnect);
        }
        //Methode pour récuperer tout les champs de la table utilisateur de la BDD
        public IEnumerable<Utilisateur> GetUtilisateurs()
        {
            //récupération des données de la table utilisateur
            //test le bon fonctionnement de la requête
            try
            {
                _dbconnection.Open();
                var q = "SELECT * from utilisateurs";
                return _dbconnection.Query<Utilisateur>(q);
            }
            //ferme la connection même si la requête precedente echoue
            finally
            {
                _dbconnection.Close();
            }
        }
    }
}
