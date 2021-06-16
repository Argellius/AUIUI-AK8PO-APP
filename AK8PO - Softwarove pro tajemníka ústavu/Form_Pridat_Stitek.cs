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
    public partial class Form_Pridat_Stitek : MetroFramework.Forms.MetroForm
    {

        private Database_Tool DB_Data;
        public Form_Pridat_Stitek()
        {
            InitializeComponent();
            DB_Data = new Database_Tool();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form_Pridat_Stitek_Load(object sender, EventArgs e)
        {
            DataTable dataT_Zamestnanci = DB_Data.getZamestnanec();
            DataTable dataT_Jazyky = DB_Data.getJazyk();
            DataTable dataT_Typ_Stitek = DB_Data.getTypStitek();
            DataTable dataT_Predmet = DB_Data.getPredmet();
            List<combobox_item> col_Zamestnanec = new List<combobox_item>();
            List<combobox_item> col_Jazyky = new List<combobox_item>();
            List<combobox_item> col_Typ_Stitek = new List<combobox_item>();
            List<combobox_item> col_Predmet = new List<combobox_item>();


            foreach (DataRow dr in dataT_Zamestnanci.Rows)
                col_Zamestnanec.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = string.Empty, nazev = dr.ItemArray[1].ToString().Trim() + " " + dr.ItemArray[2].ToString().Trim() });

            foreach (DataRow dr in dataT_Jazyky.Rows)
                col_Jazyky.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = dr.ItemArray[1].ToString(), nazev = dr.ItemArray[2].ToString() });

            foreach (DataRow dr in dataT_Typ_Stitek.Rows)
                col_Typ_Stitek.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = dr.ItemArray[1].ToString(), nazev = dr.ItemArray[2].ToString() });

            foreach (DataRow dr in dataT_Predmet.Rows)
                col_Predmet.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = dr.ItemArray[1].ToString(), nazev = dr.ItemArray[2].ToString() });



            //Zdroje comboboxů
            comboBox_Zamestnanec.DataSource = col_Zamestnanec;
            comboBox_Jazyk.DataSource = col_Jazyky;
            comboBox_Typ_Stitek.DataSource = col_Typ_Stitek;
            comboBox_Predmet.DataSource = col_Predmet;

            //Select default empty value            
            comboBox_Zamestnanec.SelectedIndex = -1;
            comboBox_Jazyk.SelectedIndex = -1;
            comboBox_Typ_Stitek.SelectedIndex = -1;
            comboBox_Predmet.SelectedIndex = -1;
        }
    }
}
