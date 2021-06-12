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
    public partial class Form_Seznam_Predmet : Form
    {
        Database_Tool dt;

        public Form_Seznam_Predmet()
        {
            InitializeComponent();
            dt = new Database_Tool();
        }

        public void Form_Seznam_Predmet_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataTable dbtable = dt.getPredmet();
            int i = 0;
            foreach (DataRow dr in dbtable.Rows)
            {

                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i++].Clone();
                row.Cells[0].Value = Convert.ToInt32(dr.ItemArray[0]);
                row.Cells[1].Value = dr.ItemArray[1];
                row.Cells[2].Value = dr.ItemArray[2];
                row.Cells[3].Value = dr.ItemArray[8];
                row.Cells[4].Value = dr.ItemArray[3];
                row.Cells[5].Value = dr.ItemArray[4];
                row.Cells[6].Value = dt.getZpusobZakonceni(Convert.ToInt32(dr.ItemArray[5])).Rows[0].ItemArray[1]; ;
                row.Cells[7].Value = dt.getJazyk(Convert.ToInt32(dr.ItemArray[6])).Rows[0].ItemArray[1]; ;
                row.Cells[8].Value = dr.ItemArray[7];
                row.Cells[9].Value = dt.getSkupina(dr.ItemArray[8].ToString()).Rows[0].ItemArray[1];
                //row.Cells[2].Value = dt.getNazevTypStitek(Convert.ToInt32(dr.ItemArray[3]));
                //if (dr.ItemArray[1].ToString() != string.Empty)
                //    row.Cells[3].Value = dt.getZamestnanecJmeno(Convert.ToInt32(dr.ItemArray[1]));
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            Form_Predmet1 settingsForm = new Form_Predmet1(this);

            // Show the settings form
            settingsForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button_zmenit_vel_tridy_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nejprve vyber řádek");
                return;
            }

            int index = this.dataGridView1.SelectedRows[0].Index;
            // Create a new instance of the Form2 class
            Form_Predmet1 Form = new Form_Predmet1(this);



            // Show the settings form
            Form.Show();

            Form.Init(
    (int)this.dataGridView1.SelectedRows[0].Cells[0].Value,
    this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
    this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
    this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
    this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString(),
    this.dataGridView1.SelectedRows[0].Cells[5].Value.ToString(),
    this.dataGridView1.SelectedRows[0].Cells[6].Value.ToString(),
    this.dataGridView1.SelectedRows[0].Cells[7].Value.ToString(),
    this.dataGridView1.SelectedRows[0].Cells[8].Value.ToString(),
    this.dataGridView1.SelectedRows[0].Cells[9].Value.ToString()
    );
        }
    }
}
