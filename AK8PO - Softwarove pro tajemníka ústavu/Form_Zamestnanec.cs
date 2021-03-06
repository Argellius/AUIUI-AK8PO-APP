using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AK8PO___Softwarove_pro_tajemníka_ústavu.Database_Tool;

namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{
    public partial class Form_Zamestnanec : MetroFramework.Forms.MetroForm
    {
        Database_Tool dt;
        int Id = -99;
        private Form_Seznam_Zamestnanec _parent;

        public Form_Zamestnanec()
        {
            InitializeComponent();
            dt = new Database_Tool();
        }

        public void Form_Zamestnanec_Load(object sender, EventArgs e)
        {
            //naplnění comboboxu pro jazyk
            DataTable dataT_jazyky = dt.getJazyk();
            List<combobox_item> col_jazyky = new List<combobox_item>();


            foreach (DataRow dr in dataT_jazyky.Rows)
            {
                col_jazyky.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = dr.ItemArray[1].ToString().Trim(), nazev = dr.ItemArray[2].ToString().Trim() });

            }


            //Zdroje comboboxů
            comboBox_Doktorant.DataSource = new List<combobox_item> { new combobox_item() { id = 0, nazev = "Ne" }, new combobox_item() { id = 1, nazev = "Ano" } };

            //Select default empty value
            comboBox_Doktorant.SelectedIndex = -1;
        }



        private void button_Pridat_Click(object sender, EventArgs e)
        {


            if (this.Id != -99)
            {
                if (dt.CheckExistZamestnanec(this.Id, textBox_Jmeno.Text, textBox_Prijmeni.Text))
                {
                    MessageBox.Show("Takový zaměstnanec již existuje");
                    return;
                }

                dt.setZamestnanec(
                    this.Id,
                    textBox_Jmeno.Text,
                    textBox_Prijmeni.Text,
                    textBox_Pracovni_Email.Text,
                    textBox_Soukromy_Email.Text,
                    (comboBox_Doktorant.SelectedItem as combobox_item).id == 0 ? Convert.ToByte(0) : Convert.ToByte(1),
                    Convert.ToDouble(textBox_Uvazek.Text));

                MessageBox.Show("Zaměstnanec upraven");
            }
            else
            {
                if (dt.CheckExistZamestnanec(textBox_Jmeno.Text, textBox_Prijmeni.Text))
                {
                    MessageBox.Show("Takový zaměstnanec již existuje");
                    return;
                }

                dt.setZamestnanec(
                    textBox_Jmeno.Text,
                    textBox_Prijmeni.Text,
                    textBox_Pracovni_Email.Text,
                    textBox_Soukromy_Email.Text,
                    (comboBox_Doktorant.SelectedItem as combobox_item).id == 0 ? Convert.ToByte(0) : Convert.ToByte(1),
                    Convert.ToDouble(textBox_Uvazek.Text));

                MessageBox.Show("Zaměstnanec přidán");
            }
            this._parent.Form_Seznam_Zamestnanec_Load(this, null);
            this.Close();

        }

        private void textBox_Jmeno_TextChanged(object sender, EventArgs e)
        {
            textBox_Cele_Jmeno.Text = textBox_Jmeno.Text + " " + textBox_Prijmeni.Text;
        }

        private void textBox_Prijmeni_TextChanged(object sender, EventArgs e)
        {
            textBox_Cele_Jmeno.Text = textBox_Jmeno.Text + " " + textBox_Prijmeni.Text;
        }

        private void textBox_Pracovni_Email_Leave(object sender, EventArgs e)
        {

            Regex mRegxExpression;
            if (textBox_Pracovni_Email.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(textBox_Pracovni_Email.Text.Trim()))
                {
                    MessageBox.Show("E-mail address format is not correct.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Pracovni_Email.Focus();
                }
            }

        }

        internal void Init(Form_Seznam_Zamestnanec form_Seznam_Zamestnanec)
        {
            this._parent = form_Seznam_Zamestnanec;
        }

        private void textBox_Soukromy_Email_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (textBox_Soukromy_Email.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(textBox_Soukromy_Email.Text.Trim()))
                {
                    MessageBox.Show("E-mail address format is not correct.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Soukromy_Email.Focus();
                }
            }
        }

        private void textBox_Uvazek_Leave(object sender, EventArgs e)
        {
            if (textBox_Uvazek.Text.Trim() != string.Empty)
            {
                if (textBox_Uvazek.Text.Contains("."))
                {
                    MessageBox.Show("U úvazku použijte desetinnou čárku, né tečku. A akci proveďte znovu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double uvazek = Convert.ToDouble(textBox_Uvazek.Text.Trim());

                if (!(uvazek > 0 && uvazek <= 1))
                {
                    MessageBox.Show("Úvazek musí být v rozsahu od 0 do 1", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Soukromy_Email.Focus();
                }
            }
        }

        internal void InitEdit(int id, Form_Seznam_Zamestnanec parent)
        {
            this._parent = parent;
            DataTable dt_zam = dt.getZamestnanec(id);
            this.Id = id;
            this.button_Pridat.Text = "Upravit";

            this.textBox_Jmeno.Text = dt_zam.Rows[0]["Jmeno"].ToString();
            this.textBox_Prijmeni.Text = dt_zam.Rows[0]["Prijmeni"].ToString();
            this.textBox_Pracovni_Email.Text = dt_zam.Rows[0]["Pracovni_Email"].ToString();
            this.textBox_Soukromy_Email.Text = dt_zam.Rows[0]["Soukromy_Email"].ToString();
            this.textBox_Uvazek.Text = dt_zam.Rows[0]["Uvazek"].ToString();

            for (int i = 0; i < comboBox_Doktorant.Items.Count; i++)
                if ((comboBox_Doktorant.Items[i] as combobox_item).id == Convert.ToInt32(Convert.ToBoolean(dt_zam.Rows[0]["Doktorand"].ToString())))
                {
                    comboBox_Doktorant.SelectedIndex = i;
                    comboBox_Doktorant.SelectedItem = comboBox_Doktorant.Items[i];
                }

            Uvazky uvazky = new Uvazky(true);
            double body = 0;
            DataTable dataTable = dt.getPracovniStitekNJZamestnanec(id);
            foreach (DataRow drSt in dataTable.Rows)
            {
                body += uvazky.getBody(
                    (TypStitek)(int)drSt.ItemArray[dataTable.Columns.IndexOf("Typ_Stitek")],
                    (TypJazyk)(int)drSt.ItemArray[dataTable.Columns.IndexOf("Jazyk")],
                    Convert.ToDouble(drSt.ItemArray[dataTable.Columns.IndexOf("Pocet_Hodin")]),
                    Convert.ToDouble(drSt.ItemArray[dataTable.Columns.IndexOf("Uvazek")])
                    );

            };

            this.textBox_Pracovni_Body.Text = body.ToString();

            double body_bez_AJ = 0;
            foreach (DataRow drSt in dataTable.Rows)
            {
                body_bez_AJ += uvazky.getBody(
                    (TypStitek)(int)drSt.ItemArray[dataTable.Columns.IndexOf("Typ_Stitek")],
                    (TypJazyk)(int)drSt.ItemArray[dataTable.Columns.IndexOf("Jazyk")],
                    Convert.ToDouble(drSt.ItemArray[dataTable.Columns.IndexOf("Pocet_Hodin")]),
                    Convert.ToDouble(drSt.ItemArray[dataTable.Columns.IndexOf("Uvazek")]),
                    true
                    );

            };

            this.textBox_Pracovni_Body_Bez_AJ.Text = body_bez_AJ.ToString();
        }
    }
}
