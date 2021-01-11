using System;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Speech.Recognition;

namespace Neuron_App
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        static Label l;
        static NumericUpDown NUD;

        static bool Shutdown = false;

        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "выключить компьютер" && e.Result.Confidence > (float)NUD.Value)  // степень распознавания
            {
                l.Text = "Выключение ПК";
                if (Shutdown)
                {
                    System.Diagnostics.Process.Start("shutdown", "/s /t 0");
                }
            }

            if (e.Result.Text == "перезагрузить компьютер" && e.Result.Confidence > (float)NUD.Value)  // степень распознавания
            {
                l.Text = "Перезагрузка ПК";
                if (Shutdown)
                {
                    System.Diagnostics.Process.Start("shutdown", "/r /t 0");
                }
            }

            if (e.Result.Text == "открой блокнот" && e.Result.Confidence > (float)NUD.Value)
            {
                l.Text = "Открываю блокнот";
                if (Shutdown)
                {
                    Process.Start("notepad.exe");
                }
            }

            if (e.Result.Text == "открой пеинт" && e.Result.Confidence > (float)NUD.Value)
            {
                l.Text = "Открываю Paint";
                if (Shutdown)
                {
                    Process.Start("mspaint.exe");
                }
            }

            if (e.Result.Text == "открой ютуб" && e.Result.Confidence > (float)NUD.Value)
            {
                l.Text = "Открываю YouTube";
                if (Shutdown)
                {
                    Process.Start("https://www.youtube.com/");
                }
            }

            if (e.Result.Text == "открой яндекс" && e.Result.Confidence > (float)NUD.Value)
            {
                l.Text = "Открываю Yandex";
                if (Shutdown)
                {
                    Process.Start(@"C:\Users\ARTEM\AppData\Local\Yandex\YandexBrowser\Application\browser.exe");
                }
            }

            if (e.Result.Text == "открой телеграм" && e.Result.Confidence > (float)NUD.Value)
            {
                l.Text = "Открываю Telegram";
                if (Shutdown)
                {
                    Process.Start("https://web.telegram.org");
                }
            }

            if (e.Result.Text == "открой скайп" && e.Result.Confidence > (float)NUD.Value)
            {
                l.Text = "Открываю Skype";
                if (Shutdown)
                {
                    Process.Start("https://web.skype.com");
                }
            }

            if (e.Result.Text == "открой вижел студио" && e.Result.Confidence > (float)NUD.Value)
            {
                l.Text = "Открываю Visual Studio 2019";
                if (Shutdown)
                {
                    Process.Start("devenv.exe");
                }
            }

            if (e.Result.Text == "открой дискорд" && e.Result.Confidence > (float)NUD.Value)
            {
                l.Text = "Открываю Discord";
                if (Shutdown)
                {
                    Process.Start("https://discord.com");
                }
            }

            if (e.Result.Text == "открой ватсап" && e.Result.Confidence > (float)NUD.Value)
            {
                l.Text = "Открываю WhatsApp";
                if (Shutdown)
                {
                    Process.Start("https://web.whatsapp.com");
                }
            }

            if (e.Result.Text == "открой зум" && e.Result.Confidence > (float)NUD.Value)
            {
                l.Text = "Открываю Zoom";
                if (Shutdown)
                {
                    Process.Start(@"C:\Users\ARTEM\AppData\Roaming\Zoom\bin\Zoom.exe");
                }
            }

            if (e.Result.Text == "открой паскаль" && e.Result.Confidence > (float)NUD.Value)
            {
                l.Text = "Открываю Pascal";
                if (Shutdown)
                {
                    Process.Start(@"C:\Program Files (x86)\PascalABC.NET\PascalABCNET.exe");
                }
            }

            if (e.Result.Text == "открой диспетчер задач" && e.Result.Confidence > (float)NUD.Value)
            {
                l.Text = "Открываю Диспетчер задач";
                if (Shutdown)
                {
                    Process.Start("taskmgr.exe");
                }
            }

            if (e.Result.Text == "открой редактор сайтов" && e.Result.Confidence > (float)NUD.Value)
            {
                l.Text = "Открываю Notepad++";
                if (Shutdown)
                {
                    Process.Start("notepad++.exe");
                }
            }
        }

        private void Form4_Shown(object sender, EventArgs e)
        {
            l = label1;
            NUD = nudThresold;

            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-Ru"); // информация об языке
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci); // движок для распознования речи 
            sre.SetInputToDefaultAudioDevice(); // место, откуда нужно распознавать речь (микрофон)

            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized); // текст, который распознается прогой (обработчик)

            Choices word = new Choices();
            word.Add(new string[] { "выключить компьютер", "открой скайп", "открой ватсап", "открой дискорд", "открой редактор сайтов", "открой диспетчер задач", "открой зум", "открой паскаль", "открой вижел студио", "перезагрузить компьютер", "открой телеграм", "открой блокнот", "открой пеинт", "открой ютуб", "открой яндекс" });

            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(word);

            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);

            sre.RecognizeAsync(RecognizeMode.Multiple);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Shutdown = true;
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void командыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
        }
    }
}