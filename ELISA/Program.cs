using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Log.logInfo("Aplicación Iniciada");
            Application.Run(new Splash());
        }

        private static void OnProcessExit(object sender, EventArgs e)
        {
            Log.logInfo("Aplicación Terminada");
            Log.logInfo("=================SALTO DE LINEA=================");
            Log.logInfo("=================SALTO DE LINEA=================");
        }
    }
}
