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
    public partial class Form_Seznam_Skupin : Form
    {
        Database_Tool dt;
        DataTable tableSkupiny;
        public Form_Seznam_Skupin()
        {
            InitializeComponent();
            dt = new Database_Tool();
        }

        private void button_Pridat_Skupiny_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            Form_Skupina settingsForm = new Form_Skupina();

            // Show the settings form
            settingsForm.Show();

        }

        public void Form_Seznam_Skupin_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            tableSkupiny = dt.getSkupina();
            int i = 0;
            foreach (DataRow dr in tableSkupiny.Rows)
            {

                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i++].Clone();
                row.Cells[0].Value = Convert.ToInt32(dr.ItemArray[0]);
                row.Cells[1].Value = dr.ItemArray[1];
                row.Cells[2].Value = dr.ItemArray[2];
                row.Cells[3].Value = dt.getSemestr(Convert.ToInt32(dr.ItemArray[3])).Rows[0].ItemArray[1];
                row.Cells[4].Value = dr.ItemArray[4];
                row.Cells[5].Value = dt.getFormaStudia(Convert.ToInt32(dr.ItemArray[5])).Rows[0].ItemArray[1];
                row.Cells[6].Value = dt.getTypStudia(Convert.ToInt32(dr.ItemArray[6])).Rows[0].ItemArray[1]; ;
                row.Cells[7].Value = dt.getJazyk(Convert.ToInt32(dr.ItemArray[7])).Rows[0].ItemArray[1];
                //row.Cells[2].Value = dt.getNazevTypStitek(Convert.ToInt32(dr.ItemArray[3]));
                //if (dr.ItemArray[1].ToString() != string.Empty)
                //    row.Cells[3].Value = dt.getZamestnanecJmeno(Convert.ToInt32(dr.ItemArray[1]));
                dataGridView1.Rows.Add(row);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nejprve vyber řádek");
                return;
            }

            Form_PocetStudentuSkupina form = new Form_PocetStudentuSkupina();
            form.Init(Convert.ToInt32(tableSkupiny.Rows[0].ItemArray[this.dataGridView1.SelectedRows[0].Index]), this);
            form.Show();
        }
    }
}
