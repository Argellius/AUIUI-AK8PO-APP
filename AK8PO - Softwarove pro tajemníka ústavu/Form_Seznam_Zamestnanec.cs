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
    public partial class Form_Seznam_Zamestnanec : MetroFramework.Forms.MetroForm
    {
        Database_Tool DB_Data;
        public Form_Seznam_Zamestnanec()
        {
            InitializeComponent();
            DB_Data = new Database_Tool();
        }

        public void Form_Seznam_Zamestnanec_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataTable dbtable = DB_Data.getZamestnanec();
            int i = 0;
            Uvazky uvazky = new Uvazky(true);
            foreach (DataRow dr in dbtable.Rows)
            {

                double body = 0;
                DataTable dataTable = DB_Data.getPracovniStitekNJZamestnanec(Convert.ToInt32(dr.ItemArray[0]));
                foreach (DataRow drSt in dataTable.Rows)
                {
                    body += uvazky.getBody(
                        (TypStitek)(int)drSt.ItemArray[dataTable.Columns.IndexOf("Typ_Stitek")],
                        (TypJazyk)(int)drSt.ItemArray[dataTable.Columns.IndexOf("Jazyk")],
                        Convert.ToDouble(drSt.ItemArray[dataTable.Columns.IndexOf("Pocet_Hodin")]),
                        Convert.ToDouble(drSt.ItemArray[dataTable.Columns.IndexOf("Uvazek")])
                        );

                }

                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i++].Clone();
                row.Cells[0].Value = Convert.ToInt32(dr.ItemArray[0]);
                row.Cells[1].Value = dr.ItemArray[1].ToString() + " " + dr.ItemArray[2].ToString();
                row.Cells[2].Value = dr.ItemArray[3];
                row.Cells[3].Value = dr.ItemArray[4];
                row.Cells[4].Value = (bool)dr.ItemArray[5] ? "Ano" : "Ne";
                row.Cells[5].Value = dr.ItemArray[6];


                row.Cells[6].Value = body;
                //row.Cells[2].Value = dt.getNazevTypStitek(Convert.ToInt32(dr.ItemArray[3]));
                //if (dr.ItemArray[1].ToString() != string.Empty)
                //    row.Cells[3].Value = dt.getZamestnanecJmeno(Convert.ToInt32(dr.ItemArray[1]));
                dataGridView1.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Create a new instance of the Form2 class
            Form_Zamestnanec settingsForm = new Form_Zamestnanec();
            settingsForm.Init(this);
            // Show the settings form
            settingsForm.Show();
        }

        private void button_Export_CSV_Click(object sender, EventArgs e)
        {
            string lblFilePath = string.Empty;

            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select a folder";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    lblFilePath = dlg.SelectedPath;
                }
                else
                    return;
            }

            var sb = new StringBuilder();

            var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value == null)
                    break;
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }

            System.IO.File.WriteAllText(lblFilePath + "\\exportZamestnance.csv", sb.ToString(), Encoding.UTF8);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.DB_Data.setPracovniStitekToNullByZamestnanec((int)this.dataGridView1.SelectedRows[0].Cells[0].Value);
            this.DB_Data.DeleteZamestnanec((int)this.dataGridView1.SelectedRows[0].Cells[0].Value);

            this.Form_Seznam_Zamestnanec_Load(this, null);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nejprve vyber řádek");
                return;
            }

            // Create a new instance of the Form2 class
            Form_Zamestnanec settingsForm = new Form_Zamestnanec();

            // Show the settings form
            settingsForm.Show();

            settingsForm.InitEdit(
                (int)this.dataGridView1.SelectedRows[0].Cells[0].Value,
                this
                );
            
            
            

        }
    }
}
