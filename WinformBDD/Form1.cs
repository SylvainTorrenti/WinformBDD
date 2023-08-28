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
            //appel de la m�thode InitializeBinding() qui cr�� les bind (association) entre les �l�ments
            InitializeBinding();

        }

        private void btRefresh_Click(object sender, EventArgs e)
        {

            Utilisateur current = bsUtilisateur.Current as Utilisateur;
            //efface la collection pour eviter de la r�p�ter 
            _utils.Clear();
            //cr�tion d'une variable qui r�cup�re les donn� r�cup�r� grace a la m�thode GetUtilisateurs()
            var u = _db.GetUtilisateurs();
            //ajout des utilisateurs r�cup�r� dans notre binding list
            foreach (Utilisateur utilisateur in u)
                _utils.Add(utilisateur);
            //permet de r�cuperer la position de la selection dans le DataGridView
            if (current is not null)
            {
                bsUtilisateur.Position = _utils.IndexOf(_utils.Where(u => u.Id == current.Id).FirstOrDefault());
            }
        }
        //methode pour initier les bind
        //!!!!!!!!!!!! Les bind ne doivent pas �tre modifier pendant l'application
        private void InitializeBinding()
        {
            _utils = new BindingList<Utilisateur>();
            bsUtilisateur.DataSource = _utils;
            dgvUtilisateur.DataSource = bsUtilisateur;
            tbxName.DataBindings.Add("text", bsUtilisateur, "Nom", false, DataSourceUpdateMode.Never);
            tbxFirstName.DataBindings.Add("text", bsUtilisateur, "Prenom", false, DataSourceUpdateMode.Never);
            dtpBirthday.DataBindings.Add("text", bsUtilisateur, "DtNaiss", false, DataSourceUpdateMode.Never);
            dgvUtilisateur.Columns["Id"].Visible = false;
            dgvUtilisateur.Columns["DtNaiss"].HeaderText = "Date de naissance";
            dgvUtilisateur.Columns["DtNaiss"].DefaultCellStyle.Format = "D";
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            Utilisateur current = bsUtilisateur.Current as Utilisateur;
            if (current is not null)
            {
                if (MessageBox.Show($"Accepter la suppression de l'utilisateur {current.Nom} ?", "Suprression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    _db.DeleteUser(current.Id);

                    btRefresh.PerformClick();
                }

            }

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Confirmer la creation de l'utilisateur \n nom : {tbxName.Text} \n prenom : {tbxFirstName.Text} \n date de naissance : {dtpBirthday.Text} ?", "Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                _db.AddUser(tbxName.Text, tbxFirstName.Text, dtpBirthday.Value);
                btRefresh.PerformClick();

            }
        }

        private void btModify_Click(object sender, EventArgs e)
        {
            Utilisateur current = bsUtilisateur.Current as Utilisateur;
            if (current is not null)
            {
                if (MessageBox.Show($"Confirmer la modification de l'utilisateur {current.Nom} ?", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    var nb = _db.UpdateUser(current.Id, tbxName.Text, tbxFirstName.Text, dtpBirthday.Value, current.Nom, current.Prenom, current.DtNaiss);
                    if (nb == 0)
                    {
                        MessageBox.Show("Les donn�es ont �t� modifi�es la mise � jour est impossible", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    btRefresh.PerformClick();
                }
            }
        }
    }
}