using ConnectinBDD;
using ConnectinBDD.Properties;
using Dapper;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Xml.Linq;

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
        public int AddUser(string nom, string prenom, DateTime dtNaiss)
        {
            try
            {

                _dbconnection.Open();
                var sql = "INSERT INTO utilisateurs (Nom, Prenom , DtNaiss) VALUES (@Nom, @Prenom,@DtNaiss)";                
                return _dbconnection.Execute(sql, new { nom, prenom, dtNaiss });
            }
            finally
            {
                _dbconnection.Close();
            }
        }
        public int DeleteUser(int Id)
        {
            try
            {

                _dbconnection.Open();
                var sql = "DELETE FROM db09.utilisateurs " + "WHERE Id = @Id;";
                return _dbconnection.Execute(sql, new {Id});
            }
            finally
            {
                _dbconnection.Close();
            }
        }
    }
}
