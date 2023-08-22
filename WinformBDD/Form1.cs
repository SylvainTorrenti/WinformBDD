using ConnectinBDD;
using System.ComponentModel;

namespace WinformBDD
{
    public partial class frmMain : Form
    {
        //creation d'un objet db pour utiliser la class db
        db _db = new db();
        //creation d'une collection d'utilisateur qui permet le binding
        BindingList<Utilisateur> _utils = new();
        public frmMain()
        {
            InitializeComponent();
            //appel de la méthode InitializeBinding() qui créé les bind (association) entre les éléments
            InitializeBinding();

        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            
            Utilisateur current = bsUtilisateur.Current as Utilisateur;
            //efface la collection pour eviter de la répéter 
            _utils.Clear();
            //crétion d'une variable qui récupére les donné récupéré grace a la méthode GetUtilisateurs()
            var u = _db.GetUtilisateurs();
            //ajout des utilisateurs récupéré dans notre binding list
            foreach (Utilisateur utilisateur in u)
                _utils.Add(utilisateur);
            //permet de récuperer la position de la selection dans le DataGridView
            if (current is not null)
            {
                bsUtilisateur.Position = _utils.IndexOf(_utils.Where(u => u.Id == current.Id).FirstOrDefault());
            }
        }
        //methode pour initier les bind
        //!!!!!!!!!!!! Les bind ne doivent pas être modifier pendant l'application
        private void InitializeBinding()
        {
            _utils = new BindingList<Utilisateur>();
            bsUtilisateur.DataSource = _utils;
            dgvUtilisateur.DataSource = bsUtilisateur;
        }
    }
}