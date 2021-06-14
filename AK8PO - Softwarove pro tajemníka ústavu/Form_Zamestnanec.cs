using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{
    public partial class Form_Zamestnanec : MetroFramework.Forms.MetroForm
    {
        Database_Tool dt;

        public Form_Zamestnanec()
        {
            InitializeComponent();
            dt = new Database_Tool();
        }

        private void Form_Zamestnanec_Load(object sender, EventArgs e)
        {
            //naplnění comboboxu pro jazyk
            DataTable dataT_jazyky = dt.getJazyk();
            List<combobox_item> col_jazyky = new List<combobox_item>();


            foreach (DataRow dr in dataT_jazyky.Rows)
            {
                col_jazyky.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = dr.ItemArray[1].ToString().Trim(), nazev = dr.ItemArray[2].ToString().Trim() });

            }


            //Zdroje comboboxů
            comboBox_Jazyk.DataSource = col_jazyky;
            comboBox_Doktorant.DataSource = new List<combobox_item> { new combobox_item() { id = 0, nazev = "Ne" }, new combobox_item() { id = 1, nazev = "Ano" } };

            //Select default empty value
            comboBox_Jazyk.SelectedIndex = -1;
            comboBox_Doktorant.SelectedIndex = -1;
        }

        private void button_Pridat_Click(object sender, EventArgs e)
        {
            dt.setZamestnanec(
                textBox_Jmeno.Text, 
                textBox_Prijmeni.Text, 
                textBox_Pracovni_Email.Text, 
                textBox_Soukromy_Email.Text,
                (comboBox_Doktorant.SelectedItem as combobox_item).id == 0 ? Convert.ToByte(0) : Convert.ToByte(1), 
                Convert.ToDouble(textBox_Uvazek.Text));
        }
    }
}
