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
            this.dataGridView_Stitek = new System.Windows.Forms.DataGridView();
            this.Column_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Nazev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Typ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_zamestnanec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Vygenerovat = new System.Windows.Forms.Button();
            this.button_Priradit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Stitek)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Stitek
            // 
            this.dataGridView_Stitek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Stitek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Id,
            this.Column_Nazev,
            this.Column_Typ,
            this.Column_zamestnanec});
            this.dataGridView_Stitek.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_Stitek.Name = "dataGridView_Stitek";
            this.dataGridView_Stitek.Size = new System.Drawing.Size(346, 150);
            this.dataGridView_Stitek.TabIndex = 0;
            // 
            // Column_Id
            // 
            this.Column_Id.HeaderText = "Id";
            this.Column_Id.Name = "Column_Id";
            this.Column_Id.Visible = false;
            // 
            // Column_Nazev
            // 
            this.Column_Nazev.HeaderText = "Název";
            this.Column_Nazev.Name = "Column_Nazev";
            // 
            // Column_Typ
            // 
            this.Column_Typ.HeaderText = "Typ";
            this.Column_Typ.Name = "Column_Typ";
            // 
            // Column_zamestnanec
            // 
            this.Column_zamestnanec.HeaderText = "Zaměstnanec";
            this.Column_zamestnanec.Name = "Column_zamestnanec";
            // 
            // button_Vygenerovat
            // 
            this.button_Vygenerovat.Location = new System.Drawing.Point(364, 12);
            this.button_Vygenerovat.Name = "button_Vygenerovat";
            this.button_Vygenerovat.Size = new System.Drawing.Size(140, 23);
            this.button_Vygenerovat.TabIndex = 1;
            this.button_Vygenerovat.Text = "Vygenerovat štítky";
            this.button_Vygenerovat.UseVisualStyleBackColor = true;
            this.button_Vygenerovat.Click += new System.EventHandler(this.button_Vygenerovat_Click);
            // 
            // button_Priradit
            // 
            this.button_Priradit.Location = new System.Drawing.Point(365, 42);
            this.button_Priradit.Name = "button_Priradit";
            this.button_Priradit.Size = new System.Drawing.Size(139, 34);
            this.button_Priradit.TabIndex = 2;
            this.button_Priradit.Text = "Přiřadit štítek k zaměstnanci";
            this.button_Priradit.UseVisualStyleBackColor = true;
            this.button_Priradit.Click += new System.EventHandler(this.button_Priradit_Click);
            // 
            // Form_Stitky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 171);
            this.Controls.Add(this.button_Priradit);
            this.Controls.Add(this.button_Vygenerovat);
            this.Controls.Add(this.dataGridView_Stitek);
            this.Name = "Form_Stitky";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Stitek)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Stitek;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Nazev;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Typ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_zamestnanec;
        private System.Windows.Forms.Button button_Vygenerovat;
        private System.Windows.Forms.Button button_Priradit;
    }
}