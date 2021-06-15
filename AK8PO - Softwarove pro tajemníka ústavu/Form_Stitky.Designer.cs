namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{
    partial class Form_Stitky
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Stitky));
            this.dataGridView_Stitek = new System.Windows.Forms.DataGridView();
            this.Column_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Nazev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Zamestnanec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Typ_Stitek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Predmet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Pocet_Student = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Pocet_Hodin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Pocet_Tyden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Jazyk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Body = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Vygenerovat = new MetroFramework.Controls.MetroButton();
            this.button_Priradit = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Stitek)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Stitek
            // 
            this.dataGridView_Stitek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Stitek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Id,
            this.Column_Nazev,
            this.Column_Zamestnanec,
            this.Column_Typ_Stitek,
            this.Column_Predmet,
            this.Column_Pocet_Student,
            this.Column_Pocet_Hodin,
            this.Column_Pocet_Tyden,
            this.Column_Jazyk,
            this.Column_Body});
            this.dataGridView_Stitek.Location = new System.Drawing.Point(12, 28);
            this.dataGridView_Stitek.Name = "dataGridView_Stitek";
            this.dataGridView_Stitek.ReadOnly = true;
            this.dataGridView_Stitek.Size = new System.Drawing.Size(946, 231);
            this.dataGridView_Stitek.TabIndex = 0;
            // 
            // Column_Id
            // 
            this.Column_Id.HeaderText = "Id";
            this.Column_Id.Name = "Column_Id";
            this.Column_Id.ReadOnly = true;
            this.Column_Id.Visible = false;
            // 
            // Column_Nazev
            // 
            this.Column_Nazev.HeaderText = "Název";
            this.Column_Nazev.Name = "Column_Nazev";
            this.Column_Nazev.ReadOnly = true;
            // 
            // Column_Zamestnanec
            // 
            this.Column_Zamestnanec.HeaderText = "Zaměstnanec";
            this.Column_Zamestnanec.Name = "Column_Zamestnanec";
            this.Column_Zamestnanec.ReadOnly = true;
            // 
            // Column_Typ_Stitek
            // 
            this.Column_Typ_Stitek.HeaderText = "Typ";
            this.Column_Typ_Stitek.Name = "Column_Typ_Stitek";
            this.Column_Typ_Stitek.ReadOnly = true;
            // 
            // Column_Predmet
            // 
            this.Column_Predmet.HeaderText = "Předmět";
            this.Column_Predmet.Name = "Column_Predmet";
            this.Column_Predmet.ReadOnly = true;
            // 
            // Column_Pocet_Student
            // 
            this.Column_Pocet_Student.HeaderText = "Počet studentů";
            this.Column_Pocet_Student.Name = "Column_Pocet_Student";
            this.Column_Pocet_Student.ReadOnly = true;
            // 
            // Column_Pocet_Hodin
            // 
            this.Column_Pocet_Hodin.HeaderText = "Počet hodin";
            this.Column_Pocet_Hodin.Name = "Column_Pocet_Hodin";
            this.Column_Pocet_Hodin.ReadOnly = true;
            // 
            // Column_Pocet_Tyden
            // 
            this.Column_Pocet_Tyden.HeaderText = "Počet týdnů";
            this.Column_Pocet_Tyden.Name = "Column_Pocet_Tyden";
            this.Column_Pocet_Tyden.ReadOnly = true;
            // 
            // Column_Jazyk
            // 
            this.Column_Jazyk.HeaderText = "Jazyk";
            this.Column_Jazyk.Name = "Column_Jazyk";
            this.Column_Jazyk.ReadOnly = true;
            // 
            // Column_Body
            // 
            this.Column_Body.HeaderText = "Body";
            this.Column_Body.Name = "Column_Body";
            this.Column_Body.ReadOnly = true;
            // 
            // button_Vygenerovat
            // 
            this.button_Vygenerovat.Location = new System.Drawing.Point(964, 27);
            this.button_Vygenerovat.Name = "button_Vygenerovat";
            this.button_Vygenerovat.Size = new System.Drawing.Size(140, 23);
            this.button_Vygenerovat.TabIndex = 1;
            this.button_Vygenerovat.Text = "Vygenerovat štítky";
            this.button_Vygenerovat.UseSelectable = true;
            this.button_Vygenerovat.Click += new System.EventHandler(this.button_Vygenerovat_Click);
            // 
            // button_Priradit
            // 
            this.button_Priradit.Location = new System.Drawing.Point(964, 57);
            this.button_Priradit.Name = "button_Priradit";
            this.button_Priradit.Size = new System.Drawing.Size(139, 34);
            this.button_Priradit.TabIndex = 2;
            this.button_Priradit.Text = "Přiřadit štítek k\r\nzaměstnanci";
            this.button_Priradit.UseSelectable = true;
            this.button_Priradit.Click += new System.EventHandler(this.button_Priradit_Click);
            // 
            // Form_Stitky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 267);
            this.Controls.Add(this.button_Priradit);
            this.Controls.Add(this.button_Vygenerovat);
            this.Controls.Add(this.dataGridView_Stitek);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Stitky";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Stitek)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Stitek;
        private MetroFramework.Controls.MetroButton button_Vygenerovat;
        private MetroFramework.Controls.MetroButton button_Priradit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Nazev;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Zamestnanec;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Typ_Stitek;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Predmet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Pocet_Student;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Pocet_Hodin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Pocet_Tyden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Jazyk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Body;
    }
}