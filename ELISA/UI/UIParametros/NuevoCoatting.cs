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
    public partial class NuevoCoatting : Form
    {
        private Boolean fechaFinMod = false;
        private Boolean fechaInicioMod = false;

        public NuevoCoatting()
        {
            InitializeComponent();
            time_FechaFin.Value = DateTime.Now;
            time_FechaInicio.Value = DateTime.Now;
            time_FechaInicio.ValueChanged += time_FechaInicio_ValueChanged;
            time_FechaFin.ValueChanged += time_FechaFinalizadoValueChanged;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (!txtCodigoControl.Text.Equals(""))
            {
                ph_9_6__coatting_ nuevo = new ph_9_6__coatting_();
                nuevo.Lote_Asign_Coatting = txtCodigoControl.Text;
                nuevo.H2ODEST = H2ODest.Text;
                nuevo.Na2CO3 = txt_Na2CO3.Text;
                nuevo.Volumen = Int32.Parse(txt_Volumen.Text);
                nuevo.NaHCO3 = txt_NaHCO3.Text;
                if (fechaFinMod)
                {
                    nuevo.Fecha_Expiracion = time_FechaFin.Value;
                }

                if (fechaInicioMod)
                {
                    nuevo.Fecha_Preparacion = time_FechaInicio.Value;
                }

                if (!txt_Observacion.Text.Equals(""))
                {
                    nuevo.Oservaciones = txt_Observacion.Text;
                }
                ph96CoattingTrans.addph96Coatting(nuevo);
            }
            else
            {
                Task.Run(() => MessageBox.Show("Ingrese los campos requeridos"));
            }
        }

        private void time_FechaInicio_ValueChanged(object sender, EventArgs e)
        {
            fechaInicioMod = true;
        }
        private void time_FechaFinalizadoValueChanged(object sender, EventArgs e)
        {
            fechaFinMod = true;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_PH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
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
