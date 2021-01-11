using MessagingToolkit.QRCode.Codec.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Neuron_App
{
    public partial class SkanQRimage : Form
    {
        public SkanQRimage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files(*.JPG)|*.jpg|Image Files(*.PNG)|*.png|Image Files(*.BMP)|*.BMP|All files(*.*)|*.*"; // расширение картинки

            if (ofd.ShowDialog() == DialogResult.OK) // если возвращаемое значение = ОК, то загружаем файл
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MessagingToolkit.QRCode.Codec.QRCodeDecoder decoder = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
                textBox1.Text = decoder.Decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap));
            }
            catch
            {
                MessageBox.Show("Вы не загрузили файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuQRcode frm = new MenuQRcode();
            frm.Show();
        }

        private void вМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
