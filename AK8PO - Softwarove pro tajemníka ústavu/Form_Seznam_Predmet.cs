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
    }
}
