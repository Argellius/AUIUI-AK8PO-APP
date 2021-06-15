namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{
    partial class Form_Seznam_Predmet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Seznam_Predmet));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.collumn_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Zkratka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Pocet_Tydnu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Hodin_Pr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Hodin_Cviceni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Hodin_Seminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Zpusob_Zakonceni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Jazyk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Velikost_Tridy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Skupina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ixp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.button_upravit = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.collumn_Id,
            this.Column_Zkratka,
            this.Column_Pocet_Tydnu,
            this.Column_Hodin_Pr,
            this.Column_Hodin_Cviceni,
            this.Column_Hodin_Seminar,
            this.Column_Zpusob_Zakonceni,
            this.Column_Jazyk,
            this.Column_Velikost_Tridy,
            this.Column_Skupina,
            this.Column_ixp});
            this.dataGridView1.Location = new System.Drawing.Point(12, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(818, 179);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // collumn_Id
            // 
            this.collumn_Id.HeaderText = "Id";
            this.collumn_Id.Name = "collumn_Id";
            this.collumn_Id.ReadOnly = true;
            this.collumn_Id.Visible = false;
            // 
            // Column_Zkratka
            // 
            this.Column_Zkratka.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Zkratka.HeaderText = "Zkratka";
            this.Column_Zkratka.Name = "Column_Zkratka";
            this.Column_Zkratka.ReadOnly = true;
            this.Column_Zkratka.Width = 69;
            // 
            // Column_Pocet_Tydnu
            // 
            this.Column_Pocet_Tydnu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column_Pocet_Tydnu.HeaderText = "Počet týdnů";
            this.Column_Pocet_Tydnu.Name = "Column_Pocet_Tydnu";
            this.Column_Pocet_Tydnu.ReadOnly = true;
            this.Column_Pocet_Tydnu.Width = 82;
            // 
            // Column_Hodin_Pr
            // 
            this.Column_Hodin_Pr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Hodin_Pr.HeaderText = "Hodin přenášek";
            this.Column_Hodin_Pr.Name = "Column_Hodin_Pr";
            this.Column_Hodin_Pr.ReadOnly = true;
            this.Column_Hodin_Pr.Width = 99;
            // 
            // Column_Hodin_Cviceni
            // 
            this.Column_Hodin_Cviceni.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Hodin_Cviceni.HeaderText = "Hodin cvičení";
            this.Column_Hodin_Cviceni.Name = "Column_Hodin_Cviceni";
            this.Column_Hodin_Cviceni.ReadOnly = true;
            this.Column_Hodin_Cviceni.Width = 91;
            // 
            // Column_Hodin_Seminar
            // 
            this.Column_Hodin_Seminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Hodin_Seminar.HeaderText = "Hodin semináře";
            this.Column_Hodin_Seminar.Name = "Column_Hodin_Seminar";
            this.Column_Hodin_Seminar.ReadOnly = true;
            this.Column_Hodin_Seminar.Width = 97;
            // 
            // Column_Zpusob_Zakonceni
            // 
            this.Column_Zpusob_Zakonceni.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Zpusob_Zakonceni.HeaderText = "Způsob zakončení";
            this.Column_Zpusob_Zakonceni.Name = "Column_Zpusob_Zakonceni";
            this.Column_Zpusob_Zakonceni.ReadOnly = true;
            this.Column_Zpusob_Zakonceni.Width = 112;
            // 
            // Column_Jazyk
            // 
            this.Column_Jazyk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Jazyk.HeaderText = "Jazyk";
            this.Column_Jazyk.Name = "Column_Jazyk";
            this.Column_Jazyk.ReadOnly = true;
            this.Column_Jazyk.Width = 59;
            // 
            // Column_Velikost_Tridy
            // 
            this.Column_Velikost_Tridy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Velikost_Tridy.HeaderText = "Velikost třídy";
            this.Column_Velikost_Tridy.Name = "Column_Velikost_Tridy";
            this.Column_Velikost_Tridy.ReadOnly = true;
            this.Column_Velikost_Tridy.Width = 87;
            // 
            // Column_Skupina
            // 
            this.Column_Skupina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Skupina.HeaderText = "Skupina";
            this.Column_Skupina.Name = "Column_Skupina";
            this.Column_Skupina.ReadOnly = true;
            this.Column_Skupina.Width = 71;
            // 
            // Column_ixp
            // 
            this.Column_ixp.HeaderText = "ixp";
            this.Column_ixp.Name = "Column_ixp";
            this.Column_ixp.ReadOnly = true;
            this.Column_ixp.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(836, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Přidat";
            this.button1.UseSelectable = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_upravit
            // 
            this.button_upravit.Location = new System.Drawing.Point(836, 71);
            this.button_upravit.Name = "button_upravit";
            this.button_upravit.Size = new System.Drawing.Size(75, 39);
            this.button_upravit.TabIndex = 2;
            this.button_upravit.Text = "Upravit";
            this.button_upravit.UseSelectable = true;
            this.button_upravit.Click += new System.EventHandler(this.button_zmenit_vel_tridy_Click);
            // 
            // Form_Seznam_Predmet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 228);
            this.Controls.Add(this.button_upravit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Seznam_Predmet";
            this.Text = "Form_Seznam_Predmet";
            this.Load += new System.EventHandler(this.Form_Seznam_Predmet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroButton button_upravit;
        private System.Windows.Forms.DataGridViewTextBoxColumn collumn_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Zkratka;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Pocet_Tydnu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Hodin_Pr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Hodin_Cviceni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Hodin_Seminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Zpusob_Zakonceni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Jazyk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Velikost_Tridy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Skupina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ixp;
    }
}