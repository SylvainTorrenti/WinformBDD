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
            //cr�� un current qui correspond � l'utilisateur selectionner gr�ce au BindingSource
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
        private void btDelete_Click(object sender, EventArgs e)
        {
            //cr�� un current qui correspond � l'utilisateur selectionner gr�ce au BindingSource
            Utilisateur current = bsUtilisateur.Current as Utilisateur;
            //Verifie que le current n'est pas null
            if (current is not null)
            {
                //Affiche une MessageBox qui demande la confirmation de l'action. Dans ce message il est indiqu� le nom de l'utilisateur concern� par la suppression. 
                //Si l'utilisateur confirme la demande alors la m�thode est effectu�e
                if (MessageBox.Show($"Accepter la suppression de l'utilisateur {current.Nom} ?", "Suprression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //Appel la m�thode cr�� dans db avec comme param�tre l'id r�cup�r� gr�ce au current.
                    _db.DeleteUser(current.Id);
                    //Simule un click sur le bouton refresh pour que l'utilisateur voit le r�sultat directement
                    btRefresh.PerformClick();
                }

            }

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (dtpBirthday.Checked == false)
            {
                if (_utils.Where(util => util.Nom == tbxName.Text && util.Prenom == tbxFirstName.Text && util.DtNaiss == null).Count() >= 1)
                {
                    MessageBox.Show("L'utilisateur que vous voulez cr�� existe d�j�", "Erreur de creation", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                if (MessageBox.Show($"Confirmer la creation de l'utilisateur \n nom : {tbxName.Text} \n prenom : {tbxFirstName.Text} \n sans date de naissance ?", "Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    var idDateNull = _db.AddUser(tbxName.Text, tbxFirstName.Text, null);
                    btRefresh.PerformClick();
                    return;
                }
            }
            if (_utils.Where(util => util.Nom == tbxName.Text && util.Prenom == tbxFirstName.Text && util.DtNaiss == dtpBirthday.Value).Count() >= 1)
            {
                MessageBox.Show("L'utilisateur que vous voulez cr�� existe d�j�", "Erreur de creation", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            //Affiche une MessageBox demandant la confirmation de la cr�ation de l'utilisateur.
            //Dans ce MessageBox les information fournit pour la cr�ation sont pr�sente pour que l'utilisateur voit precisement ce qu'il va cr��
            //Si l'utilisateur confirme la requ�te est affectu�e
            if (MessageBox.Show($"Confirmer la creation de l'utilisateur \n nom : {tbxName.Text} \n prenom : {tbxFirstName.Text} \n date de naissance : {dtpBirthday.Text} ?", "Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {


                //Appel la m�thode cr�� dans db avec comme param�tre les valeurs renseigner dans les champs par l'utilisateur
                var id = _db.AddUser(tbxName.Text, tbxFirstName.Text, dtpBirthday.Value);
                //Simule un click sur le bouton refresh pour que l'utilisateur voit le r�sultat directement
                btRefresh.PerformClick();
                //Positionement sur l'utilisateur cr��
                bsUtilisateur.Position = _utils.IndexOf(_utils.Where(u => u.Id == id).FirstOrDefault());

            }
        }


        private void btModify_Click(object sender, EventArgs e)
        {
            //cr�� un current qui correspond � l'utilisateur selectionner gr�ce au BindingSource
            Utilisateur current = bsUtilisateur.Current as Utilisateur;
            //Verifie que le current n'est pas null
            if (current is not null)
            {
                //Affiche une MessageBox demandant la confirmation de l'update de l'utilisateur.
                //Dans ce MessageBox les information fournit pour l'update sont pr�sente pour que l'utilisateur voit precisement ce qu'il va mettre � jour
                //Si l'utilisateur confirme la requ�te est affectu�e
                if (MessageBox.Show($"Confirmer la modification de l'utilisateur {current.Nom} ?", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //Appel la m�thode cr�� dans db avec comme param�tre les valeurs renseigner dans les champs par l'utilisateur
                    var nb = _db.UpdateUser(current.Id, tbxName.Text, tbxFirstName.Text, dtpBirthday.Value, current.Nom, current.Prenom);
                    //Si la m�thode �choue. Donc si elle renvoie "0" un message apparait pour que l'uitlisateur sache que l'operation � echou�e
                    if (nb == 0)
                    {
                        MessageBox.Show("Les donn�es ont �t� modifi�es la mise � jour est impossible", "Echec des Modifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //Si la m�thode � reussi. Donc si elle renvoie "1" (!!!!!!! Dans ce cas elle renvoie "1" car notre mise a jour ne concerne qu'UNE ligne si on effectue des mise a jour sur 5 ligne le resultat retourn� sera 5)
                    if (nb == 1)
                    {
                        if (dtpBirthday.Checked == true)
                        {
                            //Un message apparait avec l'ancien Nom de l'utilisateur que nous r�cuperons avec current.Nom et toutes les nouvelles informations r�cup�r� via les different champs. Le current n'a pas encore changer car nous n'avons pas encore rafraichi les donn�es.
                            MessageBox.Show($"Les modifications de l'utilisateur {current.Nom} ont �taient effectu�es. \n Maintenant elles sont : \n Nom : {tbxName.Text} \n Prenom : {tbxFirstName.Text} \n Date de naissance : {dtpBirthday.Text}", "Modifications effectu�es");
                        }
                        else
                        {
                            _db.UpdateUser(current.Id, tbxName.Text, tbxFirstName.Text, null, current.Nom, current.Prenom);
                            MessageBox.Show($"Les modifications de l'utilisateur {current.Nom} ont �taient effectu�es. \n Maintenant elles sont : \n Nom : {tbxName.Text} \n Prenom : {tbxFirstName.Text} \n Date de naissance : Sans date", "Modifications effectu�es");
                        }
                        //Simule un click sur le bouton refresh pour que l'utilisateur voit le r�sultat directement
                        btRefresh.PerformClick();
                    }
                }
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
            dgvUtilisateur.Columns["IdDept"].HeaderText = "D�partement";
        }

    }
}