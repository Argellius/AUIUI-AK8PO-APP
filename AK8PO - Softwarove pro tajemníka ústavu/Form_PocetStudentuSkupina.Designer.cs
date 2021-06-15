
namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{
    partial class Form_PocetStudentuSkupina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PocetStudentuSkupina));
            this.button_potvrdit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_nazev = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_potvrdit
            // 
            this.button_potvrdit.Location = new System.Drawing.Point(15, 90);
            this.button_potvrdit.Name = "button_potvrdit";
            this.button_potvrdit.Size = new System.Drawing.Size(231, 23);
            this.button_potvrdit.TabIndex = 0;
            this.button_potvrdit.Text = "Potvrdit";
            this.button_potvrdit.UseVisualStyleBackColor = true;
            this.button_potvrdit.Click += new System.EventHandler(this.button_potvrdit_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(118, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label_nazev
            // 
            this.label_nazev.AutoSize = true;
            this.label_nazev.Location = new System.Drawing.Point(12, 26);
            this.label_nazev.Name = "label_nazev";
            this.label_nazev.Size = new System.Drawing.Size(83, 13);
            this.label_nazev.TabIndex = 2;
            this.label_nazev.Text = "Zkratka skupiny";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Počet studentů";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(128, 20);
            this.textBox2.TabIndex = 4;
            // 
            // Form_PocetStudentuSkupina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 135);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_nazev);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_potvrdit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_PocetStudentuSkupina";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_potvrdit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_nazev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
    }
}