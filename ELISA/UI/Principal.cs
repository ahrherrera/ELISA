using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELISA.UI
{
    public partial class Principal : Form
    {
        public static usuario user;
        public Principal(usuario logged)
        {
            InitializeComponent();
            user = logged;
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Mostrar Mensaje de confirmacion
            var dialogo = MessageBox.Show("¿Está seguro que desea Salir?",
                "Salir",
                MessageBoxButtons.YesNo);
            if (dialogo == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
    }
}
