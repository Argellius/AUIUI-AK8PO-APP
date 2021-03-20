using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{

    public partial class Form_Predmet1 : Form
    {
        Database_Tool dt;
        public Form_Predmet1()
        {
            InitializeComponent();
            dt = new Database_Tool();

        }

        private void Form_Predmet_Load(object sender, EventArgs e)
        {
            //naplnění comboboxu pro jazyk
            DataTable dataT_jazyky = dt.getJazyk();
            DataTable dataT_způsob_zakonceni = dt.getZpusobZakonceni();
            DataTable dataT_skupiny = dt.getSkupina();
            List<combobox_item> col_jazyky = new List<combobox_item>();
            List<combobox_item> col_způsob_zakonceni = new List<combobox_item>();
            List<combobox_item> col_skupiny = new List<combobox_item>();


            foreach (DataRow dr in dataT_jazyky.Rows)
            {
                col_jazyky.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = dr.ItemArray[1].ToString().Trim(), nazev = dr.ItemArray[2].ToString().Trim() });

            }

            foreach (DataRow dr in dataT_způsob_zakonceni.Rows)
            {
                col_způsob_zakonceni.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = dr.ItemArray[1].ToString().Trim(), nazev = dr.ItemArray[2].ToString().Trim() });

            }

            foreach (DataRow dr in dataT_skupiny.Rows)
            {
                col_skupiny.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), nazev = dr.ItemArray[1].ToString().Trim(), zkratka = null });

            }

            //Zdroje comboboxů
            comboBox_Jazyk.DataSource = col_jazyky;
            comboBox_Zpusob_Zakonceni.DataSource = col_způsob_zakonceni;
            comboBox_Seznam_Skupin.DataSource = col_skupiny;

            //Select default empty value
            comboBox_Jazyk.SelectedIndex = -1;
            comboBox_Zpusob_Zakonceni.SelectedIndex = -1;
            comboBox_Seznam_Skupin.SelectedIndex = -1;

        }

        private void button_Pridat_Click(object sender, EventArgs e)
        {
            dt.setPredmet(textBox_Zkratka.Text.ToString(), Convert.ToInt32(textBox_Pocet_Tyden.Text), Convert.ToInt32(textBox_Pocet_Hodin_Prednasek.Text),
                Convert.ToInt32(textBox_Pocet_Hodin_Seminar.Text), Convert.ToInt32(textBox_Pocet_Hodin_Cviceni.Text),
                (comboBox_Zpusob_Zakonceni.SelectedItem as combobox_item).id, (comboBox_Jazyk.SelectedItem as combobox_item).id,
                Convert.ToInt32(textBox_Velikost_Trida.Text), (comboBox_Seznam_Skupin.SelectedItem as combobox_item).id);
        }
    }
}
