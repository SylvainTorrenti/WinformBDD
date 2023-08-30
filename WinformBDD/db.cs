using ConnectinBDD;
using ConnectinBDD.Properties;
using Dapper;
using Microsoft.VisualBasic;
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
        /// <summary>
        /// Methode pour ajouter un utilisateur
        /// </summary>
        /// <param name="nom">Recuperé grace au champ tbxName.Text</param>
        /// <param name="prenom">Recuperé grace au champ tbxFirstName.Text</param>
        /// <param name="dtNaiss">Recuperé grace au champ dtpBirthday.Text (attention dtpBirthday.Value est different bien verifier de ce que nous voulons récupérer</param>
        /// <returns></returns>
        public int AddUser(string nom, string prenom, DateTime? dtNaiss)
        {
            try
            {
                //Ouverture de la connection
                _dbconnection.Open();
                //Requête permetant la création de l'utilisateur 
                //Les nom de variable avec "@" sont renseigner via l'application et evite ainsi l'injection SQL
                var sql = "INSERT INTO utilisateurs (Nom, Prenom , DtNaiss, IdDept) VALUES (@Nom, @Prenom,@DtNaiss,10); SELECT LAST_INSERT_ID() ";      
                //Effectue la commande "Execute" qui retourne le nombre de ligne modifier dans la BDD. 
                //Passage des paramétre qui iront automatiquement remplace les variables avec "@"
                var result = _dbconnection.Query<int>(sql, new { nom, prenom, dtNaiss });
                return result.Single();
            }
            finally
            {
                //Fermeture de la connection même si la requête SQL echoue
                _dbconnection.Close();
            }
        }
        /// <summary>
        /// Suppression d'un utilisateur
        /// </summary>
        /// <param name="Id">Récupéré grâce au "current" et permet ainsi de cibler la suppression</param>
        /// <returns></returns>
        public int DeleteUser(int Id)
        {
            try
            {
                //Ouverture de la connection
                _dbconnection.Open();
                //Requête permetant la suppression de l'utilisateur 
                //Le nom de variable avec "@" est renseigné via l'application et evite ainsi l'injection SQL
                var sql = "DELETE FROM db09.utilisateurs WHERE Id = @Id;";
                //Effectue la commande "Execute" qui retourne le nombre de ligne modifier dans la BDD. 
                //Passage du paramétre qui va automatiquement remplacer la variable avec "@"
                return _dbconnection.Execute(sql, new {Id});
            }
            finally
            {
                //Fermeture de la connection même si la requête SQL echoue
                _dbconnection.Close();
            }
        }
        /// <summary>
        /// Update d'un utilisateur
        /// </summary>
        /// <param name="id">Récupéré grâce au "current" (il ne change pas durant l'update)</param>
        /// <param name="nom">Recuperé grace au champ tbxName.Text</param>
        /// <param name="prenom">Recuperé grace au champ tbxFirstName.Text</param>
        /// <param name="dtNaiss">Recuperé grace au champ dtpBirthday.Text (attention dtpBirthday.Value est different bien verifier de ce que nous voulons récupérer</param>
        /// <param name="currentNom">Récupéré grâce au "current.Nom"</param>
        /// <param name="currentPrenom">Récupéré grâce au "current.Prenom"</param>
        /// <param name="currentDtNaiss">Récupéré grâce au "current.DtNaiss"</param>
        /// <returns></returns>
        public int UpdateUser(int id, string nom, string prenom, DateTime? dtNaiss, string currentNom, string currentPrenom, DateTime? currentDtNaiss)
        {
            try
            {
                //Ouverture de la connection
                _dbconnection.Open();
                //Requête permetant la création de l'utilisateur 
                //Les nom de variable avec "@" sont renseigner via l'application et evite ainsi l'injection SQL
                var sql = "UPDATE db09.utilisateurs SET Nom = @Nom, Prenom=@Prenom, DtNaiss=@DtNaiss WHERE Id = @Id AND Nom = @currentNom AND Prenom=@currentPrenom AND DtNaiss=@currentDtNaiss;";
                //Effectue la commande "Execute" qui retourne le nombre de ligne modifier dans la BDD. 
                //Passage des paramétre qui iront automatiquement remplace les variables avec "@"
                return _dbconnection.Execute(sql, new { id, nom, prenom, dtNaiss, currentNom, currentPrenom, currentDtNaiss});
            }
            finally
            {
                //Fermeture de la connection même si la requête SQL echoue
                _dbconnection.Close();
            }
        }

    }
}
