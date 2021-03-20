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
    public partial class Form_Pridat_Zam_Stitek : Form
    {
        Database_Tool dt;
        private int Id; // ID štítku
        Form_Stitky _owner;
        public Form_Pridat_Zam_Stitek(Form_Stitky owner)
        {
            InitializeComponent();
            this._owner = owner;
            dt = new Database_Tool();
        }

        private void Form_Pridat_Zam_Stitek_Load(object sender, EventArgs e)
        {
            
        }

        public void InitValue(int Id, string Nazev, string typ )
        {
            this.Id = Id;
            this.textBox1.Text = Nazev;
            this.textBox2.Text = typ;

            DataTable dataT_zamestnanci = dt.getZamestnanec();
            List<combobox_item> col_Zamestnanec = new List<combobox_item>();


            foreach (DataRow dr in dataT_zamestnanci.Rows)
            {
                col_Zamestnanec.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = string.Empty, nazev = dr.ItemArray[1].ToString().Trim() + " " +dr.ItemArray[2].ToString().Trim() });

            }


            //Zdroje comboboxů
            comboBox_Zamestnanec.DataSource = col_Zamestnanec;

            //Select default empty value
            comboBox_Zamestnanec.SelectedIndex = -1;


        }

        private void button_Pridat_Click(object sender, EventArgs e)
        {
            dt.setPracovniStitek(this.Id, (comboBox_Zamestnanec.SelectedItem as combobox_item).id);
            _owner.Form2_Load(null, null);
            this.Close();

        }
    }
}
