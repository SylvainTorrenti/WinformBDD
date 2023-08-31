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
        private void frmMain_Load(object sender, EventArgs e)
        {
            //Simule le click pour afficher les données à l'ouverture de l'application
            btRefresh.PerformClick();
        }
        private void btRefresh_Click(object sender, EventArgs e)
        {
            //créé un current qui correspond à l'utilisateur selectionner grâce au BindingSource
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
        private void btDelete_Click(object sender, EventArgs e)
        {
            //créé un current qui correspond à l'utilisateur selectionner grâce au BindingSource
            Utilisateur current = bsUtilisateur.Current as Utilisateur;
            //Verifie que le current n'est pas null
            if (current is not null)
            {
                //Affiche une MessageBox qui demande la confirmation de l'action. Dans ce message il est indiqué le nom de l'utilisateur concerné par la suppression. 
                //Si l'utilisateur confirme la demande alors la méthode est effectuée
                if (MessageBox.Show($"Accepter la suppression de l'utilisateur {current.Nom} ?", "Suprression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //Appel la méthode créé dans db avec comme paramétre l'id récupéré grâce au current.
                    _db.DeleteUser(current.Id);
                    //Simule un click sur le bouton refresh pour que l'utilisateur voit le résultat directement
                    btRefresh.PerformClick();
                }

            }

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            // Verifie si le DTP est check
            if (dtpBirthday.Checked == false)
            {
                // Verifie si un utilisateur identique n'existe pas deja
                if (_utils.Where(util => util.Nom == tbxName.Text && util.Prenom == tbxFirstName.Text && util.DtNaiss == null).Count() >= 1)
                {
                    MessageBox.Show("L'utilisateur que vous voulez créé existe déjà", "Erreur de creation", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                if (MessageBox.Show($"Confirmer la creation de l'utilisateur \n nom : {tbxName.Text} \n prenom : {tbxFirstName.Text} \n sans date de naissance ?", "Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // Creation de l'utilisateur avec un date NULL
                    var idDateNull = _db.AddUser(tbxName.Text, tbxFirstName.Text, null);
                    btRefresh.PerformClick();
                    return;
                }
            }
            // Verifie si un utilisateur identique n'existe pas deja
            if (_utils.Where(util => util.Nom == tbxName.Text && util.Prenom == tbxFirstName.Text && util.DtNaiss == dtpBirthday.Value).Count() >= 1)
            {
                MessageBox.Show("L'utilisateur que vous voulez créé existe déjà", "Erreur de creation", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            //Affiche une MessageBox demandant la confirmation de la création de l'utilisateur.
            //Dans ce MessageBox les information fournit pour la création sont présente pour que l'utilisateur voit precisement ce qu'il va créé
            //Si l'utilisateur confirme la requête est affectuée
            if (MessageBox.Show($"Confirmer la creation de l'utilisateur \n nom : {tbxName.Text} \n prenom : {tbxFirstName.Text} \n date de naissance : {dtpBirthday.Text} ?", "Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {


                //Appel la méthode créé dans db avec comme paramétre les valeurs renseigner dans les champs par l'utilisateur
                var id = _db.AddUser(tbxName.Text, tbxFirstName.Text, dtpBirthday.Value);
                //Simule un click sur le bouton refresh pour que l'utilisateur voit le résultat directement
                btRefresh.PerformClick();
                //Positionement sur l'utilisateur créé
                bsUtilisateur.Position = _utils.IndexOf(_utils.Where(u => u.Id == id).FirstOrDefault());

            }
        }


        private void btModify_Click(object sender, EventArgs e)
        {
            //créé un current qui correspond à l'utilisateur selectionner grâce au BindingSource
            Utilisateur current = bsUtilisateur.Current as Utilisateur;
            //Verifie que le current n'est pas null
            if (current is not null)
            {
                //Affiche une MessageBox demandant la confirmation de l'update de l'utilisateur.
                //Dans ce MessageBox les information fournit pour l'update sont présente pour que l'utilisateur voit precisement ce qu'il va mettre à jour
                //Si l'utilisateur confirme la requête est affectuée
                if (MessageBox.Show($"Confirmer la modification de l'utilisateur {current.Nom} ?", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (dtpBirthday.Checked == true)
                    {
                        if (current.DtNaiss == null)
                        {
                            var nb2 = _db.UpdateUserWithoutDate(current.Id, tbxName.Text, tbxFirstName.Text, dtpBirthday.Value, current.Nom, current.Prenom, current.DtNaiss);
                            if (nb2 == 1)
                            {
                                //Verifie si le DTP est check
                                if (dtpBirthday.Checked == true)
                                {
                                    //Un message apparait avec l'ancien Nom de l'utilisateur que nous récuperons avec current.Nom et toutes les nouvelles informations récupéré via les different champs. Le current n'a pas encore changer car nous n'avons pas encore rafraichi les données.
                                    MessageBox.Show($"Les modifications de l'utilisateur {current.Nom} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxName.Text} \n Prenom : {tbxFirstName.Text} \n Date de naissance : {dtpBirthday.Text}", "Modifications effectuées");
                                }
                                else
                                {
                                    //Update l'utilisateur avec la date NULL
                                    _db.UpdateUser(current.Id, tbxName.Text, tbxFirstName.Text, null, current.Nom, current.Prenom, current.DtNaiss);
                                    MessageBox.Show($"Les modifications de l'utilisateur {current.Nom} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxName.Text} \n Prenom : {tbxFirstName.Text} \n Date de naissance : Sans date", "Modifications effectuées");
                                }
                                //Simule un click sur le bouton refresh pour que l'utilisateur voit le résultat directement
                                btRefresh.PerformClick();
                            }
                        }
                        var nb = _db.UpdateUser(current.Id, tbxName.Text, tbxFirstName.Text, dtpBirthday.Value, current.Nom, current.Prenom, current.DtNaiss);
                        if (nb == 1)
                        {
                            //Verifie si le DTP est check
                            if (dtpBirthday.Checked == true)
                            {
                                //Un message apparait avec l'ancien Nom de l'utilisateur que nous récuperons avec current.Nom et toutes les nouvelles informations récupéré via les different champs. Le current n'a pas encore changer car nous n'avons pas encore rafraichi les données.
                                MessageBox.Show($"Les modifications de l'utilisateur {current.Nom} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxName.Text} \n Prenom : {tbxFirstName.Text} \n Date de naissance : {dtpBirthday.Text}", "Modifications effectuées");
                            }
                            else
                            {
                                //Update l'utilisateur avec la date NULL
                                _db.UpdateUser(current.Id, tbxName.Text, tbxFirstName.Text, null, current.Nom, current.Prenom, current.DtNaiss);
                                MessageBox.Show($"Les modifications de l'utilisateur {current.Nom} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxName.Text} \n Prenom : {tbxFirstName.Text} \n Date de naissance : Sans date", "Modifications effectuées");
                            }
                            //Simule un click sur le bouton refresh pour que l'utilisateur voit le résultat directement
                            btRefresh.PerformClick();
                        }
                    }
                    if (dtpBirthday.Checked == false)
                    {
                        var nb = _db.UpdateUserWithoutDate(current.Id, tbxName.Text, tbxFirstName.Text, null, current.Nom, current.Prenom, current.DtNaiss);
                        if (nb == 1)
                        {
                            MessageBox.Show($"Les modifications de l'utilisateur {current.Nom} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxName.Text} \n Prenom : {tbxFirstName.Text} \n Date de naissance : Sans date", "Modifications effectuées");
                        }
                        //    //Simule un click sur le bouton refresh pour que l'utilisateur voit le résultat directement
                        btRefresh.PerformClick();
                        //}
                    }


                }
            }
        }
        //methode pour initier les bind
        //!!!!!!!!!!!! Les bind ne doivent pas être modifier pendant l'application
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
            dgvUtilisateur.Columns["IdDept"].HeaderText = "Département";
        }


    }
}