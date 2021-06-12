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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Pridat_Skupiny = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Column_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Zkratka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Rocnik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Semestr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Pocet_Student = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Forma_Studia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Typ_Studia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Jazyk = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(573, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // button_Pridat_Skupiny
            // 
            this.button_Pridat_Skupiny.Location = new System.Drawing.Point(591, 12);
            this.button_Pridat_Skupiny.Name = "button_Pridat_Skupiny";
            this.button_Pridat_Skupiny.Size = new System.Drawing.Size(85, 23);
            this.button_Pridat_Skupiny.TabIndex = 1;
            this.button_Pridat_Skupiny.Text = "Přidat skupiny";
            this.button_Pridat_Skupiny.UseVisualStyleBackColor = true;
            this.button_Pridat_Skupiny.Click += new System.EventHandler(this.button_Pridat_Skupiny_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(591, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 62);
            this.button2.TabIndex = 3;
            this.button2.Text = "Změna počtu studentů u skupiny";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Column_Id
            // 
            this.Column_Id.HeaderText = "Id";
            this.Column_Id.Name = "Column_Id";
            this.Column_Id.Visible = false;
            // 
            // Column_Zkratka
            // 
            this.Column_Zkratka.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Zkratka.HeaderText = "Zkratka";
            this.Column_Zkratka.Name = "Column_Zkratka";
            this.Column_Zkratka.Width = 69;
            // 
            // Column_Rocnik
            // 
            this.Column_Rocnik.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Rocnik.HeaderText = "Ročník";
            this.Column_Rocnik.Name = "Column_Rocnik";
            this.Column_Rocnik.Width = 68;
            // 
            // Column_Semestr
            // 
            this.Column_Semestr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Semestr.HeaderText = "Semestr";
            this.Column_Semestr.Name = "Column_Semestr";
            this.Column_Semestr.Width = 70;
            // 
            // Column_Pocet_Student
            // 
            this.Column_Pocet_Student.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Pocet_Student.HeaderText = "Počet studentů";
            this.Column_Pocet_Student.Name = "Column_Pocet_Student";
            this.Column_Pocet_Student.Width = 96;
            // 
            // Column_Forma_Studia
            // 
            this.Column_Forma_Studia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Forma_Studia.HeaderText = "Forma studia";
            this.Column_Forma_Studia.Name = "Column_Forma_Studia";
            this.Column_Forma_Studia.Width = 85;
            // 
            // Column_Typ_Studia
            // 
            this.Column_Typ_Studia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Typ_Studia.HeaderText = "Typ studia";
            this.Column_Typ_Studia.Name = "Column_Typ_Studia";
            this.Column_Typ_Studia.Width = 75;
            // 
            // Column_Jazyk
            // 
            this.Column_Jazyk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Jazyk.HeaderText = "Jazyk";
            this.Column_Jazyk.Name = "Column_Jazyk";
            this.Column_Jazyk.Width = 59;
            // 
            // Form_Seznam_Skupin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 168);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_Pridat_Skupiny);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form_Seznam_Skupin";
            this.Text = "Form_Seznam_Skupin";
            this.Load += new System.EventHandler(this.Form_Seznam_Skupin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Pridat_Skupiny;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Zkratka;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Rocnik;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Semestr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Pocet_Student;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Forma_Studia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Typ_Studia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Jazyk;
    }
}