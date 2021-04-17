using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{

    public partial class Form_Predmet1 : Form
    {
        Database_Tool dt;
        Form_Seznam_Predmet _parent;
        public Form_Predmet1(Form_Seznam_Predmet parent)
        {
            _parent = parent;
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
            try
            {
                dt.setPredmet(textBox_Zkratka.Text.ToString(), Convert.ToInt32(textBox_Pocet_Tyden.Text), Convert.ToInt32(textBox_Pocet_Hodin_Prednasek.Text),
                    Convert.ToInt32(textBox_Pocet_Hodin_Seminar.Text), Convert.ToInt32(textBox_Pocet_Hodin_Cviceni.Text),
                    (comboBox_Zpusob_Zakonceni.SelectedItem as combobox_item).id, (comboBox_Jazyk.SelectedItem as combobox_item).id,
                    Convert.ToInt32(textBox_Velikost_Trida.Text), (comboBox_Seznam_Skupin.SelectedItem as combobox_item).id);
                MessageBox.Show("Předmět přidán");
                Thread.Sleep(100);

                this._vygenerovaniStitku();
                MessageBox.Show("Štítky automaticky vygenerovány");
                Thread.Sleep(100);
            }
            catch (Exception)
            {

            }
            this.Close();
            this._parent.Form_Seznam_Predmet_Load(this, null);
        }

        private void _vygenerovaniStitku()
        {

            DataTable dataSkupina = dt.getSkupina((comboBox_Seznam_Skupin.SelectedItem as combobox_item).id.ToString());

            DataTable data = new DataTable();
            data = dt.getPredmetNJSkupina();
            //getPredmetNJSkupina
            // 0. Id, 1. Zkratka, 2. Pocet týdnů, 3. Počet hodin přednášek, 4. Počet hodin seminářů
            //5. Způsob ukončení, 6. jazyk, 7. Velikost třídy, 8. Skupina
            //9. Počet hodin cvičení 
            //14. počet studentů


            //Vytvoří přednášku
            dt.setPracovniStitek(String.Empty, Convert.ToInt32(dr.ItemArray[0]), 1 /*Přednáška*/,
                Convert.ToInt32(dataSkupina.Rows[0].ItemArray[4]), 0, 0, (comboBox_Jazyk.SelectedItem as combobox_item).id,
                dr.ItemArray[1] + " " + dr.ItemArray[11]);

            double pocet_stitku = Convert.ToDouble(Convert.ToInt32(dataSkupina.Rows[0].ItemArray[4])) / Convert.ToDouble(textBox_Velikost_Trida.Text); //Počet studentů / velikost třídy
            pocet_stitku = Math.Ceiling(pocet_stitku);

            int pocet_studentu_stitek = (int)Math.Ceiling(Convert.ToDouble(Convert.ToInt32(dataSkupina.Rows[0].ItemArray[4])) / pocet_stitku);
            List<int> pocet_student_list = new List<int>();
            do
            {
                pocet_student_list.Add(pocet_studentu_stitek);

            } while (pocet_student_list.Take(pocet_student_list.Count()).Sum() + pocet_studentu_stitek < Convert.ToInt32(Convert.ToInt32(dataSkupina.Rows[0].ItemArray[4])));

            int pocet_studentu_posledni_prvek = Convert.ToInt32(Convert.ToInt32(dataSkupina.Rows[0].ItemArray[4])) - pocet_student_list.Take(pocet_student_list.Count()).Sum();
            if (pocet_studentu_posledni_prvek != 0)
                pocet_student_list.Add(pocet_studentu_posledni_prvek);

            foreach (int studenti in pocet_student_list)
                dt.setPracovniStitek(string.Empty, Convert.ToInt16(dr.ItemArray[0]), 2 /*Cvičení*/, studenti, Convert.ToInt16(dr.ItemArray[9]),
                    Convert.ToInt16(dr.ItemArray[2]), Convert.ToInt16(dr.ItemArray[6]), dr.ItemArray[1] + " " + dr.ItemArray[11]);

        



    }
}
}
