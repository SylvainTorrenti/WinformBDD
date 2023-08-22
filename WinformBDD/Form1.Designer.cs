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
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvUtilisateur = new DataGridView();
            btRefresh = new Button();
            bsUtilisateur = new BindingSource(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUtilisateur).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsUtilisateur).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(dgvUtilisateur, 0, 0);
            tableLayoutPanel1.Controls.Add(btRefresh, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 98F));
            tableLayoutPanel1.Size = new Size(595, 392);
            tableLayoutPanel1.TabIndex = 0;
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
            dgvUtilisateur.RowTemplate.Height = 25;
            dgvUtilisateur.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUtilisateur.Size = new Size(589, 288);
            dgvUtilisateur.TabIndex = 2;
            // 
            // btRefresh
            // 
            btRefresh.Anchor = AnchorStyles.None;
            btRefresh.Image = ConnectinBDD.Properties.Resources.refresh_arrow_1546;
            btRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            btRefresh.Location = new Point(218, 318);
            btRefresh.Name = "btRefresh";
            btRefresh.Size = new Size(159, 49);
            btRefresh.TabIndex = 1;
            btRefresh.Text = "Actualiser";
            btRefresh.UseVisualStyleBackColor = true;
            btRefresh.Click += button1_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 392);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(600, 430);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Utilisateur";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUtilisateur).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsUtilisateur).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvUtilisateur;
        private Button btRefresh;
        private BindingSource bsUtilisateur;
    }
}