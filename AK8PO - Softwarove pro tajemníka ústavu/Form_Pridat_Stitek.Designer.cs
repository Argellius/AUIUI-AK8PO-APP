
namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{
    partial class Form_Pridat_Stitek
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Pridat_Stitek));
            this.button_Pridat = new MetroFramework.Controls.MetroButton();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_Pocet_Studentu = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox__Název = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Pocet_Hodin = new System.Windows.Forms.TextBox();
            this.textBox_Pocet_Tyden = new System.Windows.Forms.TextBox();
            this.comboBox_Zamestnanec = new System.Windows.Forms.ComboBox();
            this.comboBox_Typ_Stitek = new System.Windows.Forms.ComboBox();
            this.comboBox_Predmet = new System.Windows.Forms.ComboBox();
            this.comboBox_Jazyk = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button_Pridat
            // 
            this.button_Pridat.Location = new System.Drawing.Point(174, 258);
            this.button_Pridat.Name = "button_Pridat";
            this.button_Pridat.Size = new System.Drawing.Size(100, 23);
            this.button_Pridat.TabIndex = 59;
            this.button_Pridat.Text = "Přidat";
            this.button_Pridat.UseSelectable = true;
            this.button_Pridat.Click += new System.EventHandler(this.button_Pridat_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 224);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 54;
            this.label11.Text = "Jazyk";
            // 
            // textBox_Pocet_Studentu
            // 
            this.textBox_Pocet_Studentu.Location = new System.Drawing.Point(174, 137);
            this.textBox_Pocet_Studentu.Name = "textBox_Pocet_Studentu";
            this.textBox_Pocet_Studentu.Size = new System.Drawing.Size(100, 20);
            this.textBox_Pocet_Studentu.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "Počet hodin";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Předmět";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Typ štítku";
            // 
            // textBox__Název
            // 
            this.textBox__Název.Location = new System.Drawing.Point(174, 26);
            this.textBox__Název.Name = "textBox__Název";
            this.textBox__Název.Size = new System.Drawing.Size(100, 20);
            this.textBox__Název.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Počet týdnů";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Zaměstnanec";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Název";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Počet studentů";
            // 
            // textBox_Pocet_Hodin
            // 
            this.textBox_Pocet_Hodin.Location = new System.Drawing.Point(174, 164);
            this.textBox_Pocet_Hodin.Name = "textBox_Pocet_Hodin";
            this.textBox_Pocet_Hodin.Size = new System.Drawing.Size(100, 20);
            this.textBox_Pocet_Hodin.TabIndex = 6;
            this.textBox_Pocet_Hodin.Leave += new System.EventHandler(this.textBox_Pocet_Hodin_Leave);
            // 
            // textBox_Pocet_Tyden
            // 
            this.textBox_Pocet_Tyden.Location = new System.Drawing.Point(174, 191);
            this.textBox_Pocet_Tyden.Name = "textBox_Pocet_Tyden";
            this.textBox_Pocet_Tyden.Size = new System.Drawing.Size(100, 20);
            this.textBox_Pocet_Tyden.TabIndex = 7;
            this.textBox_Pocet_Tyden.Leave += new System.EventHandler(this.textBox_Pocet_Tyden_Leave);
            // 
            // comboBox_Zamestnanec
            // 
            this.comboBox_Zamestnanec.FormattingEnabled = true;
            this.comboBox_Zamestnanec.Location = new System.Drawing.Point(174, 54);
            this.comboBox_Zamestnanec.Name = "comboBox_Zamestnanec";
            this.comboBox_Zamestnanec.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Zamestnanec.TabIndex = 2;
            // 
            // comboBox_Typ_Stitek
            // 
            this.comboBox_Typ_Stitek.FormattingEnabled = true;
            this.comboBox_Typ_Stitek.Location = new System.Drawing.Point(174, 85);
            this.comboBox_Typ_Stitek.Name = "comboBox_Typ_Stitek";
            this.comboBox_Typ_Stitek.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Typ_Stitek.TabIndex = 3;
            // 
            // comboBox_Predmet
            // 
            this.comboBox_Predmet.FormattingEnabled = true;
            this.comboBox_Predmet.Location = new System.Drawing.Point(174, 110);
            this.comboBox_Predmet.Name = "comboBox_Predmet";
            this.comboBox_Predmet.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Predmet.TabIndex = 4;
            // 
            // comboBox_Jazyk
            // 
            this.comboBox_Jazyk.FormattingEnabled = true;
            this.comboBox_Jazyk.Location = new System.Drawing.Point(174, 221);
            this.comboBox_Jazyk.Name = "comboBox_Jazyk";
            this.comboBox_Jazyk.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Jazyk.TabIndex = 8;
            // 
            // Form_Pridat_Stitek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 306);
            this.Controls.Add(this.comboBox_Jazyk);
            this.Controls.Add(this.comboBox_Predmet);
            this.Controls.Add(this.comboBox_Typ_Stitek);
            this.Controls.Add(this.comboBox_Zamestnanec);
            this.Controls.Add(this.textBox_Pocet_Tyden);
            this.Controls.Add(this.textBox_Pocet_Hodin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_Pridat);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_Pocet_Studentu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox__Název);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Pridat_Stitek";
            this.Load += new System.EventHandler(this.Form_Pridat_Stitek_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton button_Pridat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_Pocet_Studentu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox__Název;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Pocet_Hodin;
        private System.Windows.Forms.TextBox textBox_Pocet_Tyden;
        private System.Windows.Forms.ComboBox comboBox_Zamestnanec;
        private System.Windows.Forms.ComboBox comboBox_Typ_Stitek;
        private System.Windows.Forms.ComboBox comboBox_Predmet;
        private System.Windows.Forms.ComboBox comboBox_Jazyk;
    }
}