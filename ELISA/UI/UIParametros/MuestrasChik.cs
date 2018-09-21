using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELISA.UI.UIParametros
{
    public partial class MuestrasChik : Form
    {
        public string codChik;
        public int numChik = 0;
        public MuestrasChik()
        {
            InitializeComponent();
            cmb_Cantidad.SelectedIndex = 0;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (!txt_codigo.Text.Equals(""))
            {
            string codTemp = txt_codigo.Text.Substring(0, 7);
            if (codTemp == "NICCNDR")
            {
                codChik = txt_codigo.Text.Substring(7, txt_codigo.Text.Length - 7);
            }
            else
            {
                codChik = txt_codigo.Text;
            }

            numChik = Int32.Parse(cmb_Cantidad.SelectedItem.ToString());
            
            }
            else
            {
                MessageBox.Show("Ingrese el codigo de la muestra", "Verifique los datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
