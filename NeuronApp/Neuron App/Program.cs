using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neuron_App
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form7 first = new Form7();
            DateTime end = DateTime.Now + TimeSpan.FromSeconds(3);
            first.Show();
            while(end > DateTime.Now)
            {
                Application.DoEvents();
            }

            first.Close();
            first.Dispose();
            Application.Run(new Form1());
        }
    }
}
