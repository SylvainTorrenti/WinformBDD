namespace WinformBDD
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            tlpMain = new TableLayoutPanel();
            dgvUtilisateur = new DataGridView();
            flpRefresh = new FlowLayoutPanel();
            btRefresh = new Button();
            btDelete = new Button();
            btAdd = new Button();
            btModify = new Button();
            tlpChampText = new TableLayoutPanel();
            lbName = new Label();
            lbFirstname = new Label();
            lbBirthday = new Label();
            tbxName = new TextBox();
            tbxFirstName = new TextBox();
            dtpBirthday = new DateTimePicker();
            bsUtilisateur = new BindingSource(components);
            tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUtilisateur).BeginInit();
            flpRefresh.SuspendLayout();
            tlpChampText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bsUtilisateur).BeginInit();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMain.Controls.Add(dgvUtilisateur, 0, 0);
            tlpMain.Controls.Add(flpRefresh, 0, 2);
            tlpMain.Controls.Add(tlpChampText, 0, 1);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tlpMain.Size = new Size(593, 391);
            tlpMain.TabIndex = 0;
            // 
            // dgvUtilisateur
            // 
            dgvUtilisateur.AllowUserToAddRows = false;
            dgvUtilisateur.AllowUserToDeleteRows = false;
            dgvUtilisateur.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUtilisateur.BackgroundColor = SystemColors.Control;
            dgvUtilisateur.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUtilisateur.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUtilisateur.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUtilisateur.Dock = DockStyle.Fill;
            dgvUtilisateur.EnableHeadersVisualStyles = false;
            dgvUtilisateur.GridColor = SystemColors.Control;
            dgvUtilisateur.Location = new Point(3, 3);
            dgvUtilisateur.MultiSelect = false;
            dgvUtilisateur.Name = "dgvUtilisateur";
            dgvUtilisateur.ReadOnly = true;
            dgvUtilisateur.RowHeadersVisible = false;
            dgvUtilisateur.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvUtilisateur.RowTemplate.Height = 25;
            dgvUtilisateur.RowTemplate.Resizable = DataGridViewTriState.False;
            dgvUtilisateur.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUtilisateur.Size = new Size(587, 228);
            dgvUtilisateur.TabIndex = 2;
            // 
            // flpRefresh
            // 
            flpRefresh.Controls.Add(btRefresh);
            flpRefresh.Controls.Add(btDelete);
            flpRefresh.Controls.Add(btAdd);
            flpRefresh.Controls.Add(btModify);
            flpRefresh.Dock = DockStyle.Fill;
            flpRefresh.Location = new Point(3, 332);
            flpRefresh.Name = "flpRefresh";
            flpRefresh.Size = new Size(587, 56);
            flpRefresh.TabIndex = 3;
            // 
            // btRefresh
            // 
            btRefresh.Image = ConnectinBDD.Properties.Resources.refresh_arrow_1546;
            btRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            btRefresh.Location = new Point(3, 3);
            btRefresh.Name = "btRefresh";
            btRefresh.Size = new Size(101, 44);
            btRefresh.TabIndex = 0;
            btRefresh.Text = "Actualiser";
            btRefresh.TextAlign = ContentAlignment.MiddleRight;
            btRefresh.UseVisualStyleBackColor = true;
            btRefresh.Click += btRefresh_Click;
            // 
            // btDelete
            // 
            btDelete.Image = ConnectinBDD.Properties.Resources.filesystems_garbage_full_670;
            btDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btDelete.Location = new Point(110, 3);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(101, 44);
            btDelete.TabIndex = 1;
            btDelete.Text = "Supprimer";
            btDelete.TextAlign = ContentAlignment.MiddleRight;
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Click += btDelete_Click;
            // 
            // btAdd
            // 
            btAdd.Image = ConnectinBDD.Properties.Resources.addition_sign_icon_icons_com_73100;
            btAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btAdd.Location = new Point(217, 3);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(101, 44);
            btAdd.TabIndex = 2;
            btAdd.Text = "Ajouter";
            btAdd.TextAlign = ContentAlignment.MiddleRight;
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // btModify
            // 
            btModify.Image = ConnectinBDD.Properties.Resources.pen_edit_modify_icon_149416;
            btModify.ImageAlign = ContentAlignment.MiddleLeft;
            btModify.Location = new Point(324, 3);
            btModify.Name = "btModify";
            btModify.Size = new Size(101, 44);
            btModify.TabIndex = 3;
            btModify.Text = "Modifier";
            btModify.TextAlign = ContentAlignment.MiddleRight;
            btModify.UseVisualStyleBackColor = true;
            btModify.Click += btModify_Click;
            // 
            // tlpChampText
            // 
            tlpChampText.ColumnCount = 2;
            tlpChampText.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.25043F));
            tlpChampText.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.74957F));
            tlpChampText.Controls.Add(lbName, 0, 0);
            tlpChampText.Controls.Add(lbFirstname, 0, 1);
            tlpChampText.Controls.Add(lbBirthday, 0, 2);
            tlpChampText.Controls.Add(tbxName, 1, 0);
            tlpChampText.Controls.Add(tbxFirstName, 1, 1);
            tlpChampText.Controls.Add(dtpBirthday, 1, 2);
            tlpChampText.Dock = DockStyle.Fill;
            tlpChampText.Location = new Point(3, 237);
            tlpChampText.Name = "tlpChampText";
            tlpChampText.RowCount = 3;
            tlpChampText.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpChampText.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpChampText.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpChampText.Size = new Size(587, 89);
            tlpChampText.TabIndex = 4;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(3, 5);
            lbName.Margin = new Padding(3, 5, 3, 0);
            lbName.Name = "lbName";
            lbName.Size = new Size(34, 15);
            lbName.TabIndex = 0;
            lbName.Text = "Nom";
            // 
            // lbFirstname
            // 
            lbFirstname.AutoSize = true;
            lbFirstname.Location = new Point(3, 35);
            lbFirstname.Margin = new Padding(3, 5, 3, 0);
            lbFirstname.Name = "lbFirstname";
            lbFirstname.Size = new Size(49, 15);
            lbFirstname.TabIndex = 1;
            lbFirstname.Text = "Prénom";
            // 
            // lbBirthday
            // 
            lbBirthday.AutoSize = true;
            lbBirthday.Location = new Point(3, 65);
            lbBirthday.Margin = new Padding(3, 5, 3, 0);
            lbBirthday.Name = "lbBirthday";
            lbBirthday.Size = new Size(101, 15);
            lbBirthday.TabIndex = 2;
            lbBirthday.Text = "Date de naissance";
            // 
            // tbxName
            // 
            tbxName.Dock = DockStyle.Fill;
            tbxName.Location = new Point(116, 3);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(468, 23);
            tbxName.TabIndex = 3;
            // 
            // tbxFirstName
            // 
            tbxFirstName.Dock = DockStyle.Fill;
            tbxFirstName.Location = new Point(116, 33);
            tbxFirstName.Name = "tbxFirstName";
            tbxFirstName.Size = new Size(468, 23);
            tbxFirstName.TabIndex = 4;
            // 
            // dtpBirthday
            // 
            dtpBirthday.Dock = DockStyle.Fill;
            dtpBirthday.Location = new Point(116, 63);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(468, 23);
            dtpBirthday.TabIndex = 5;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 391);
            Controls.Add(tlpMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(609, 430);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Utilisateur";
            tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUtilisateur).EndInit();
            flpRefresh.ResumeLayout(false);
            tlpChampText.ResumeLayout(false);
            tlpChampText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bsUtilisateur).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private DataGridView dgvUtilisateur;
        private BindingSource bsUtilisateur;
        private FlowLayoutPanel flpRefresh;
        private Button btRefresh;
        private TableLayoutPanel tlpChampText;
        private Label lbName;
        private Label lbFirstname;
        private Label lbBirthday;
        private TextBox tbxName;
        private TextBox tbxFirstName;
        private DateTimePicker dtpBirthday;
        private Button btDelete;
        private Button btAdd;
        private Button btModify;
    }
}