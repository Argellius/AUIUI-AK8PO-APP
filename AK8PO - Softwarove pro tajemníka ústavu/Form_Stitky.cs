﻿using System;
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
    public partial class Form_Stitky : Form
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
                row.Cells[2].Value = dt.getNazevTypStitek(Convert.ToInt32(dr.ItemArray[3]));
                if (dr.ItemArray[1].ToString() != string.Empty)
                row.Cells[3].Value = dt.getZamestnanecJmeno(Convert.ToInt32(dr.ItemArray[1]));
                dataGridView_Stitek.Rows.Add(row);
            }



        }

        private void button_Vygenerovat_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data = dt.getPredmetNJSkupina();

            foreach (DataRow dr in data.Rows)
            {
                if (!dt.getPracovniStitek(Convert.ToInt32(dr.ItemArray[0]), 1))
                //Vytvoří přednášku
                dt.setPracovniStitek(String.Empty, Convert.ToInt32(dr.ItemArray[0]), 1 /*Přednáška*/, Convert.ToInt32(dr.ItemArray[14]), 0, 0, Convert.ToInt32(dr.ItemArray[6]), dr.ItemArray[1] + " " + dr.ItemArray[11]);

                double number = Convert.ToDouble(dr.ItemArray[14]) / Convert.ToDouble(dr.ItemArray[7]); //Počet studentů / velikost třídy
                number = Math.Ceiling(number);

                int poc_studentu = Convert.ToInt32(dr.ItemArray[14]) / Convert.ToInt32(number); // Počet studentů / number
                int num = Convert.ToInt32(dr.ItemArray[14]) / poc_studentu;

                if (dt.getCountPracovniStitek(Convert.ToInt32(dr.ItemArray[0]), 2) != num)
                for (int i =0; i < num; i++)
                dt.setPracovniStitek(String.Empty, Convert.ToInt32(dr.ItemArray[0]), 2 /*Cviceni*/, poc_studentu, 0, 0, Convert.ToInt32(dr.ItemArray[6]), dr.ItemArray[1] + " " + dr.ItemArray[11]);
            
            }

            this.Form2_Load(null, null);

            MessageBox.Show("Provedeno generování štítků");
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
            settingsForm.InitValue(Convert.ToInt32(selectedRow.Cells[0].Value), Convert.ToString(selectedRow.Cells[1].Value), Convert.ToString(selectedRow.Cells[2].Value));
            // Show the settings form
            settingsForm.Show(this);
        }
    }
}
