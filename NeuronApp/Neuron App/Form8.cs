using QRCoder;
using System;
using System.Windows.Forms;

namespace Neuron_App
{
    public partial class GenerateQR : Form
    {
        public GenerateQR()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(txtQRCode.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            pictureBox1.Image = code.GetGraphic(5);
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuQRcode frm = new MenuQRcode();
            frm.Show();
        }

        private void назадВМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) //проверка наличия изображения
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить картинку как...";

                sfd.OverwritePrompt = true; // проверка есть ли файл с таким именем 
                sfd.CheckPathExists = true; // показывает диалоговое окно с несуществующим путе загрузки
                sfd.Filter = "Image Files(*.JPG)|*.jpg|Image Files(*.PNG)|*.png|Image Files(*.BMP)|*.BMP|All files(*.*)|*.*"; // расширение картинки
                sfd.ShowHelp = true; // отображать ли справку в диалогово окне

                if (sfd.ShowDialog() == DialogResult.OK) // если возвращаемое значение = ОК, то сохраняем файл
                {
                    try
                    {
                        pictureBox1.Image.Save(sfd.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
