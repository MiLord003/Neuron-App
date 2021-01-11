using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Neuron_App
{
    public partial class Form3 : Form
    {
        private FilterInfoCollection videoDevices; // получим список устройств для видеозахвата
        private VideoCaptureDevice videoSource; // получим объект, связанный с веб-камерой, с которым мы будем взаимодействовать
        private ZXing.BarcodeReader reader;

        public Form3()
        {
            InitializeComponent();
        }
        delegate void SetStringDelegate(string parametr);

        void SetResult(string result)
        {
            if (!InvokeRequired) // если свойство = не правда
                tbText.Text = result; // нельзя делать
            else
                Invoke(new SetStringDelegate(SetResult), new object[] { result }); // если = правда, то можно делать
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice); // новая коллекция, в которой есть вся коллекция устройств

            reader = new ZXing.BarcodeReader(); // создание нового объекта (мы намерены распозновать только QR-код
            reader.Options.PossibleFormats = new List<ZXing.BarcodeFormat>(); // распознование по формату штрих-кодов
            reader.Options.PossibleFormats.Add(ZXing.BarcodeFormat.QR_CODE); // только QR-код


            if (videoDevices.Count > 0) // если есть такие устройства, то выполняется след. действие
            {
                foreach (FilterInfo device in videoDevices) // переборка всех устройств
                {
                    Camers.Items.Add(device.Name); // добавляем имя устройств
                }

                Camers.SelectedIndex = 0;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            videoSource = new VideoCaptureDevice(videoDevices[Camers.SelectedIndex].MonikerString); // обработчик щелка (выбранное устройство из списка) - путь к устройству (moni...)
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame); // событие обработика на получение нового кадра (будет работать при получении каждого кадра)
            videoSource.Start(); // начало съемки
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs) // как только камера дает кадр, то начинаем работать
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone(); // вклюение камеры
            webcam.Image = bitmap; // передача картинки

            ZXing.Result result = reader.Decode((Bitmap)eventArgs.Frame.Clone()); // объявление переменной - декодируем - принимает параметр (картинку)
            if (result != null) // если распознал QR-код
            {
                SetResult(result.Text);
            }
        }

        private void Form1_FormClossing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null)
            {
                videoSource.SignalToStop(); // заканчивает съемку
                videoSource.WaitForStop(); // конец дальше не выполняется
            }
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuQRcode frm = new MenuQRcode();
            frm.Show();
        }

        private void jToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
