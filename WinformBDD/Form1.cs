using ConnectinBDD;
using System.ComponentModel;

namespace WinformBDD
{
    public partial class frmMain : Form
    {
        db _db = new db();
        BindingList<Utilisateur> _utils = new();
        public frmMain()
        {
            InitializeComponent();
            InitializeBinding();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utilisateur current = bsUtilisateur.Current as Utilisateur;

            _utils.Clear();
            var u = _db.GetUtilisateurs();
            foreach (Utilisateur utilisateur in u)
                _utils.Add(utilisateur);

            if (current is not null)
            {
                bsUtilisateur.Position = _utils.IndexOf(_utils.Where(u => u.Id == current.Id).FirstOrDefault());
            }
        }
        private void InitializeBinding()
        {
            _utils = new BindingList<Utilisateur>();
            bsUtilisateur.DataSource = _utils;
            dgvUtilisateur.DataSource = bsUtilisateur;
        }
    }
}