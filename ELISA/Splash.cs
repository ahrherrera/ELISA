using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.UI;

namespace ELISA
{
    public partial class Splash : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Shown(object sender, EventArgs e)
        {
            Utils.Log.logInfo("Splash Iniciado");
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Esconder el form hace que la aplicación no se cierre al esconderse el Splash
            this.Hide(); 
            //Muestra la ventana principal
            Utils.Log.logInfo("Splash Finalizado, Splash cerrado");
            new Login().Show();
            Utils.Log.logInfo("Arrancar la ventana de autenticación");
            timer.Stop();
        }
    }
}
