using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AK8PO___Softwarove_pro_tajemníka_ústavu.Database_Tool;

namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{
    public partial class Form_Stitky : MetroFramework.Forms.MetroForm
    {
        Database_Tool dt;
        public Form_Stitky()
        {
            InitializeComponent();
            dt = new Database_Tool();
        }

        public void Form2_Load(object sender, EventArgs e)
        {
            dataGridView_Stitek.Rows.Clear();
            DataTable dbtable = dt.getPracovniStitek();
            int i = 0;
            foreach (DataRow dr in dbtable.Rows)
            {

                DataGridViewRow row = (DataGridViewRow)dataGridView_Stitek.Rows[i++].Clone();
                row.Cells[0].Value = Convert.ToInt32(dr.ItemArray[0]);
                row.Cells[1].Value = dr.ItemArray[8];
                row.Cells[3].Value = dt.getNazevTypStitek(Convert.ToInt32(dr.ItemArray[3]));
                row.Cells[4].Value = dt.getPredmet(Convert.ToInt32(dr.ItemArray[2])).Rows[0].ItemArray[1];
                row.Cells[5].Value = dr.ItemArray[4];
                row.Cells[6].Value = dr.ItemArray[5];
                row.Cells[7].Value = dr.ItemArray[6];
                row.Cells[8].Value = dt.getJazyk(Convert.ToInt32(dr.ItemArray[7])).Rows[0].ItemArray[1];
                row.Cells[9].Value = this.GetBodyZaStitek(Convert.ToInt32(dr.ItemArray[3]),
                    Convert.ToInt32(dr.ItemArray[7]),
                    Convert.ToDouble(dr.ItemArray[5]));
              
                if (dr.ItemArray[1].ToString() != string.Empty)
                    row.Cells[2].Value = dt.getZamestnanecJmeno(Convert.ToInt32(dr.ItemArray[1]));
                dataGridView_Stitek.Rows.Add(row);
            }



        }

        private double GetBodyZaStitek(int typ_stitku, int jazyk, double hodina)
        {
            TypStitek typ = (TypStitek)typ_stitku;
            Uvazky uvazky = new Uvazky(true);

            return uvazky.getBody(typ, (TypJazyk)jazyk, hodina);
        }
             
        private void button_Priradit_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;
            if (dataGridView_Stitek.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView_Stitek.SelectedCells[0].RowIndex;
                selectedRow = dataGridView_Stitek.Rows[selectedrowindex];
            }
            else
                return;

            // Create a new instance of the Form2 class
            Form_Pridat_Zam_Stitek settingsForm = new Form_Pridat_Zam_Stitek(this);
            settingsForm.InitValue(Convert.ToInt32(selectedRow.Cells[0].Value), Convert.ToString(selectedRow.Cells[1].Value), Convert.ToString(selectedRow.Cells[3].Value), Convert.ToString(selectedRow.Cells[2].Value));            // Show the settings form
            settingsForm.Show(this);
        }

        private void metroButton_rucne_stitek_Click(object sender, EventArgs e)
        {
            Form_Pridat_Stitek settingsForm = new Form_Pridat_Stitek();
            settingsForm.Init(this);
            settingsForm.Show(this);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = new DataGridViewRow();
            if (dataGridView_Stitek.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView_Stitek.SelectedCells[0].RowIndex;
                selectedRow = dataGridView_Stitek.Rows[selectedrowindex];
                this.dt.DeletePracovniStitek(Convert.ToInt32(selectedRow.Cells[0].Value);
            }
            else
                MessageBox.Show("Vyber řádek");

            
            
        }
    }
}
