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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            Form_Seznam_Predmet settingsForm = new Form_Seznam_Predmet();

            // Show the settings form
            settingsForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            Form_Seznam_Skupin settingsForm = new Form_Seznam_Skupin();

            // Show the settings form
            settingsForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            Form_Seznam_Zamestnanec settingsForm = new Form_Seznam_Zamestnanec();

            // Show the settings form
            settingsForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            Form_Stitky settingsForm = new Form_Stitky();

            // Show the settings form
            settingsForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
