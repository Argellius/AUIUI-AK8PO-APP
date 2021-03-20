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
    public partial class Form_Skupina : Form
    {
        Database_Tool dt;
        public Form_Skupina()
        {
            InitializeComponent();
            dt = new Database_Tool();
        }

        private void Form_Skupina_Load(object sender, EventArgs e)
        {
            DataTable dataT_jazyky = dt.getJazyk();
            DataTable dataT_semestr = dt.getSemestr();
            DataTable dataT_forma_studia = dt.getFormaStudia();
            DataTable dataT_typ_studia = dt.getTypStudia();
            List<combobox_item> col_jazyky = new List<combobox_item>();
            List<combobox_item> col_semestr = new List<combobox_item>();
            List<combobox_item> col_forma_studia = new List<combobox_item>();
            List<combobox_item> col_typ_studia = new List<combobox_item>();

            foreach (DataRow dr in dataT_jazyky.Rows)
            {
                col_jazyky.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = dr.ItemArray[1].ToString().Trim(), nazev = dr.ItemArray[2].ToString().Trim() });

            }

            foreach (DataRow dr in dataT_semestr.Rows)
            {
                col_semestr.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = dr.ItemArray[1].ToString().Trim(), nazev = dr.ItemArray[2].ToString().Trim() });

            }

            foreach (DataRow dr in dataT_forma_studia.Rows)
            {
                col_forma_studia.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = dr.ItemArray[1].ToString().Trim(), nazev = dr.ItemArray[2].ToString().Trim() });

            }

            foreach (DataRow dr in dataT_typ_studia.Rows)
            {
                col_typ_studia.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = dr.ItemArray[1].ToString().Trim(), nazev = dr.ItemArray[2].ToString().Trim() });

            }
            //Zdroje comboboxů
            comboBox_Jazyk.DataSource = col_jazyky;
            comboBox_Semestr.DataSource = col_semestr;
            comboBox_Forma_Studia.DataSource = col_forma_studia;
            comboBox_Typ_Studia.DataSource = col_typ_studia;

            //Select default empty value
            comboBox_Jazyk.SelectedIndex = -1;
            comboBox_Semestr.SelectedIndex = -1;
            comboBox_Forma_Studia.SelectedIndex = -1;
            comboBox_Typ_Studia.SelectedIndex = -1;
        }

        private void button_Pridat_Click(object sender, EventArgs e)
        {
            dt.setSkupina(
                textBox_Zkratka.Text, 
                Convert.ToInt32(textBox_Rocnik.Text), 
                (comboBox_Semestr.SelectedItem as combobox_item).id, 
                Convert.ToInt32(textBox_Pocet_Student.Text),
                (comboBox_Forma_Studia.SelectedItem as combobox_item).id, 
                (comboBox_Typ_Studia.SelectedItem as combobox_item).id, 
                (comboBox_Jazyk.SelectedItem as combobox_item).id
                );
        }
    }
}

