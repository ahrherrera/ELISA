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
    public partial class frmCPEI : Form
    {
        public string codEI;
        public int dil = 0;
        public int nDil;
        public int dire;

        public frmCPEI()
        {
            InitializeComponent();
            txt_codigo.Text = "CP";
            cmb_DisInicial.SelectedIndex = 0;
            cmb_Disol.SelectedIndex = 0;
            cmb_dir.SelectedIndex = 0;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {

            if (!txt_codigo.Text.Equals(""))
            {
                if (Int32.Parse(cmb_DisInicial.SelectedItem.ToString()) > 2 && Int32.Parse(cmb_Disol.SelectedItem.ToString()) > 4)
                {
                    MessageBox.Show("Verifique datos en el numero de disoluciones", "Compruebe sus datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    codEI = txt_codigo.Text;
                    dil = Int32.Parse(cmb_DisInicial.SelectedItem.ToString());
                    nDil = Int32.Parse(cmb_Disol.SelectedItem.ToString());
                    dire = Int32.Parse(cmb_dir.SelectedItem.ToString());
                }
            }
            else
            {
                MessageBox.Show("Ingrese el codigo de la muestra", "Verifique los datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            
        }
    }
}
