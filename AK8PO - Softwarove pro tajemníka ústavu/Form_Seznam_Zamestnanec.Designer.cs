namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{
    partial class Form_Seznam_Zamestnanec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Seznam_Zamestnanec));
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.collumn_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Cele_Jmeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Pracovni_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Soukromy_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Doktorand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Ubazek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Body = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Export_CSV = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(663, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "Přidat zaměstnance";
            this.button1.UseSelectable = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.collumn_Id,
            this.Column_Cele_Jmeno,
            this.Column_Pracovni_Email,
            this.Column_Soukromy_Email,
            this.Column_Doktorand,
            this.Column_Ubazek,
            this.Column_Body});
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(645, 246);
            this.dataGridView1.TabIndex = 2;
            // 
            // collumn_Id
            // 
            this.collumn_Id.HeaderText = "Id";
            this.collumn_Id.Name = "collumn_Id";
            this.collumn_Id.ReadOnly = true;
            this.collumn_Id.Visible = false;
            // 
            // Column_Cele_Jmeno
            // 
            this.Column_Cele_Jmeno.HeaderText = "Celé jméno";
            this.Column_Cele_Jmeno.Name = "Column_Cele_Jmeno";
            this.Column_Cele_Jmeno.ReadOnly = true;
            // 
            // Column_Pracovni_Email
            // 
            this.Column_Pracovni_Email.HeaderText = "Pracovní email";
            this.Column_Pracovni_Email.Name = "Column_Pracovni_Email";
            this.Column_Pracovni_Email.ReadOnly = true;
            // 
            // Column_Soukromy_Email
            // 
            this.Column_Soukromy_Email.HeaderText = "Soukromý email";
            this.Column_Soukromy_Email.Name = "Column_Soukromy_Email";
            this.Column_Soukromy_Email.ReadOnly = true;
            // 
            // Column_Doktorand
            // 
            this.Column_Doktorand.HeaderText = "Doktorand";
            this.Column_Doktorand.Name = "Column_Doktorand";
            this.Column_Doktorand.ReadOnly = true;
            // 
            // Column_Ubazek
            // 
            this.Column_Ubazek.HeaderText = "Úvazek";
            this.Column_Ubazek.Name = "Column_Ubazek";
            this.Column_Ubazek.ReadOnly = true;
            // 
            // Column_Body
            // 
            this.Column_Body.HeaderText = "Body";
            this.Column_Body.Name = "Column_Body";
            this.Column_Body.ReadOnly = true;
            // 
            // button_Export_CSV
            // 
            this.button_Export_CSV.Location = new System.Drawing.Point(663, 72);
            this.button_Export_CSV.Name = "button_Export_CSV";
            this.button_Export_CSV.Size = new System.Drawing.Size(110, 39);
            this.button_Export_CSV.TabIndex = 4;
            this.button_Export_CSV.Text = "Export CSV";
            this.button_Export_CSV.UseSelectable = true;
            this.button_Export_CSV.Click += new System.EventHandler(this.button_Export_CSV_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(663, 117);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(110, 39);
            this.metroButton1.TabIndex = 5;
            this.metroButton1.Text = "Smazat";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // Form_Seznam_Zamestnanec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 296);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.button_Export_CSV);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Seznam_Zamestnanec";
            this.Load += new System.EventHandler(this.Form_Seznam_Zamestnanec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn collumn_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Cele_Jmeno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Pracovni_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Soukromy_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Doktorand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Ubazek;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Body;
        private MetroFramework.Controls.MetroButton button_Export_CSV;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}