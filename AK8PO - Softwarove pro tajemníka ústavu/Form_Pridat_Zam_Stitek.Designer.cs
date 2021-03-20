namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{
    partial class Form_Pridat_Zam_Stitek
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
            this.button_Pridat = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox_Zamestnanec = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button_Pridat
            // 
            this.button_Pridat.Location = new System.Drawing.Point(13, 135);
            this.button_Pridat.Name = "button_Pridat";
            this.button_Pridat.Size = new System.Drawing.Size(100, 23);
            this.button_Pridat.TabIndex = 0;
            this.button_Pridat.Text = "Přidat";
            this.button_Pridat.UseVisualStyleBackColor = true;
            this.button_Pridat.Click += new System.EventHandler(this.button_Pridat_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(13, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(13, 58);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox_Zamestnanec.FormattingEnabled = true;
            this.comboBox_Zamestnanec.Location = new System.Drawing.Point(13, 96);
            this.comboBox_Zamestnanec.Name = "comboBox1";
            this.comboBox_Zamestnanec.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Zamestnanec.TabIndex = 3;
            // 
            // Form_Pridat_Zam_Stitek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(139, 199);
            this.Controls.Add(this.comboBox_Zamestnanec);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_Pridat);
            this.Name = "Form_Pridat_Zam_Stitek";
            this.Text = "Form_Pridat_Zam_Stitek";
            this.Load += new System.EventHandler(this.Form_Pridat_Zam_Stitek_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Pridat;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox_Zamestnanec;
    }
}