namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{
    partial class Form_Seznam_Skupin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Seznam_Skupin));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Zkratka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Rocnik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Semestr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Pocet_Student = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Forma_Studia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Typ_Studia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Jazyk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Pridat_Skupiny = new MetroFramework.Controls.MetroButton();
            this.button2 = new MetroFramework.Controls.MetroButton();
            this.metroButton_Smazat = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Id,
            this.Column_Zkratka,
            this.Column_Rocnik,
            this.Column_Semestr,
            this.Column_Pocet_Student,
            this.Column_Forma_Studia,
            this.Column_Typ_Studia,
            this.Column_Jazyk});
            this.dataGridView1.Location = new System.Drawing.Point(12, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(573, 239);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column_Id
            // 
            this.Column_Id.HeaderText = "Id";
            this.Column_Id.Name = "Column_Id";
            this.Column_Id.ReadOnly = true;
            this.Column_Id.Visible = false;
            // 
            // Column_Zkratka
            // 
            this.Column_Zkratka.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Zkratka.HeaderText = "Zkratka";
            this.Column_Zkratka.Name = "Column_Zkratka";
            this.Column_Zkratka.ReadOnly = true;
            this.Column_Zkratka.Width = 69;
            // 
            // Column_Rocnik
            // 
            this.Column_Rocnik.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Rocnik.HeaderText = "Ročník";
            this.Column_Rocnik.Name = "Column_Rocnik";
            this.Column_Rocnik.ReadOnly = true;
            this.Column_Rocnik.Width = 68;
            // 
            // Column_Semestr
            // 
            this.Column_Semestr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Semestr.HeaderText = "Semestr";
            this.Column_Semestr.Name = "Column_Semestr";
            this.Column_Semestr.ReadOnly = true;
            this.Column_Semestr.Width = 70;
            // 
            // Column_Pocet_Student
            // 
            this.Column_Pocet_Student.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Pocet_Student.HeaderText = "Počet studentů";
            this.Column_Pocet_Student.Name = "Column_Pocet_Student";
            this.Column_Pocet_Student.ReadOnly = true;
            this.Column_Pocet_Student.Width = 96;
            // 
            // Column_Forma_Studia
            // 
            this.Column_Forma_Studia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Forma_Studia.HeaderText = "Forma studia";
            this.Column_Forma_Studia.Name = "Column_Forma_Studia";
            this.Column_Forma_Studia.ReadOnly = true;
            this.Column_Forma_Studia.Width = 85;
            // 
            // Column_Typ_Studia
            // 
            this.Column_Typ_Studia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Typ_Studia.HeaderText = "Typ studia";
            this.Column_Typ_Studia.Name = "Column_Typ_Studia";
            this.Column_Typ_Studia.ReadOnly = true;
            this.Column_Typ_Studia.Width = 75;
            // 
            // Column_Jazyk
            // 
            this.Column_Jazyk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Jazyk.HeaderText = "Jazyk";
            this.Column_Jazyk.Name = "Column_Jazyk";
            this.Column_Jazyk.ReadOnly = true;
            this.Column_Jazyk.Width = 59;
            // 
            // button_Pridat_Skupiny
            // 
            this.button_Pridat_Skupiny.Location = new System.Drawing.Point(591, 34);
            this.button_Pridat_Skupiny.Name = "button_Pridat_Skupiny";
            this.button_Pridat_Skupiny.Size = new System.Drawing.Size(85, 23);
            this.button_Pridat_Skupiny.TabIndex = 1;
            this.button_Pridat_Skupiny.Text = "Přidat";
            this.button_Pridat_Skupiny.UseSelectable = true;
            this.button_Pridat_Skupiny.Click += new System.EventHandler(this.button_Pridat_Skupiny_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(591, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 72);
            this.button2.TabIndex = 3;
            this.button2.Text = "Změna počtu \r\nstudentů u \r\nskupiny";
            this.button2.UseSelectable = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // metroButton_Smazat
            // 
            this.metroButton_Smazat.Location = new System.Drawing.Point(591, 141);
            this.metroButton_Smazat.Name = "metroButton_Smazat";
            this.metroButton_Smazat.Size = new System.Drawing.Size(85, 23);
            this.metroButton_Smazat.TabIndex = 4;
            this.metroButton_Smazat.Text = "Smazat";
            this.metroButton_Smazat.UseSelectable = true;
            this.metroButton_Smazat.Click += new System.EventHandler(this.metroButton_Smazat_Click);
            // 
            // Form_Seznam_Skupin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 303);
            this.Controls.Add(this.metroButton_Smazat);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_Pridat_Skupiny);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Seznam_Skupin";
            this.Load += new System.EventHandler(this.Form_Seznam_Skupin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private MetroFramework.Controls.MetroButton button_Pridat_Skupiny;
        private MetroFramework.Controls.MetroButton button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Zkratka;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Rocnik;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Semestr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Pocet_Student;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Forma_Studia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Typ_Studia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Jazyk;
        private MetroFramework.Controls.MetroButton metroButton_Smazat;
    }
}