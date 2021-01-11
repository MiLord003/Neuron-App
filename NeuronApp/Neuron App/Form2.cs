using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neuron_App
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            int key = Convert.ToInt32(mastxtKey.Text);

            txtOut.Text = Encryption(txtIn.Text, key);
        }

        private string Encryption(string v1, int v2)
        {
            string temp = String.Empty;
            foreach (char c in v1)
            {
                temp = temp + Convert.ToString((char)(((int)(c) ^ v2)));
            }
            return temp;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtIn.Text = string.Empty;
            txtOut.Text = string.Empty;
        }

        private void mastxtKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.KeyChar));
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            mastxtKey.Mask = "000000000";
        }
    }
}