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
    public partial class NuevoGamma : Form
    {
        private Boolean fechaFinMod = false;
        private Boolean fechaInicioMod = false;

        public NuevoGamma()
        {
            InitializeComponent();
            time_FechaFin.Value = DateTime.Now;
            time_FechaInicio.Value = DateTime.Now;
            time_FechaInicio.ValueChanged += time_FechaInicio_ValueChanged;
            time_FechaFin.ValueChanged += time_FechaFinalizadoValueChanged;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (!txtCodigoLote.Text.Equals(""))
            {
                gammaglobulina nuevo = new gammaglobulina();
                nuevo.Lote_Asign_Gamma1 = txtCodigoLote.Text;
                nuevo.Concen_Gamma = Single.Parse(txt_concenGamma.Text);
                nuevo.PBS1X = txt_PSB1X.Text;
                nuevo.Volumen = Int32.Parse(txt_Volumen.Text);
                nuevo.NH4SO4 = txt_NH4SO4.Text;
                nuevo.Codigo_Mx = txt_codigoMX.Text;

                if (fechaFinMod)
                {
                    nuevo.Fecha_Terminacion = time_FechaFin.Value;
                }

                if (fechaInicioMod)
                {
                    nuevo.Fecha_Preparacion = time_FechaInicio.Value;
                }

                if (!txt_Observacion.Text.Equals(""))
                {
                    nuevo.Observaciones = txt_Observacion.Text;
                }
                GammaTrans.addGamma(nuevo);
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
