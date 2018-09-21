using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Transaccion;

namespace ELISA.UI.UIParametros
{
    public partial class NuevoPB : Form
    {
        public NuevoPB()
        {
            InitializeComponent();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (!txtCodigoLote.Text.Equals(""))
            {
                pbs1x nuevo = new pbs1x();
                nuevo.Lote_Asign_20X = txtCodigoLote.Text;
                nuevo.H2ODEST = txt_h2odest.Text;
                nuevo.Lote_Asign_1X = txt_CodLote1X.Text;
                nuevo.Volumen = Int32.Parse(txt_Volumen.Text);
                nuevo.Numero = Int32.Parse(txt_Numero.Text);

                if (!txt_Observacion.Text.Equals(""))
                {
                    nuevo.Observaciones = txt_Observacion.Text;
                }
                PBTrans.addPB(nuevo);
            }
            else
            {
                Task.Run(() => MessageBox.Show("Ingrese los campos requeridos"));
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_PH_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            //    (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void txt_Volumen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
