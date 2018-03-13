using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Transaccion;
using ELISA.Utils;

namespace ELISA.UI.UIParametros
{
    public partial class NuevoControlEI : Form
    {
        private Boolean fechaFinMod = false;
        private Boolean fechaInicioMod = false;
        private MainUtils.Controles control;

        public NuevoControlEI(Utils.MainUtils.Controles control)
        {
            InitializeComponent();
            time_FechaFin.Value = DateTime.Now;
            time_FechaInicio.Value = DateTime.Now;
            this.control = control;
            time_FechaInicio.ValueChanged += time_FechaInicio_ValueChanged;
            time_FechaFin.ValueChanged += time_FechaFinalizadoValueChanged;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (!txtCodigoControl.Text.Equals("") || !txt_DOptica.Text.Equals("") || !txt_Volumen.Text.Equals(""))
            {
                controles_ei nuevo = new controles_ei();
                nuevo.Codigo_Asig_ContEI = txtCodigoControl.Text;
                nuevo.MxC = txt_MxC.Text;
                nuevo.D_Optica = float.Parse(txt_DOptica.Text);
                nuevo.Volumen = Int32.Parse(txt_Volumen.Text);
                if (fechaFinMod)
                {
                    nuevo.Fecha_Finalizacion = time_FechaFin.Value;
                }

                if (fechaInicioMod)
                {
                    nuevo.Fecha_Inicio = time_FechaInicio.Value;
                }

                if (!txt_Observacion.Text.Equals(""))
                {
                    nuevo.Oservaciones = txt_Observacion.Text;
                }
                
                switch (control)
                {
                    case MainUtils.Controles.ControlesEI_CMin:
                    {
                        nuevo.Tipo = "C-";
                            break;
                    }
                    case MainUtils.Controles.ControlesEI_CPlus:
                    {
                        nuevo.Tipo = "C+";
                            break;
                    }
                }
                ControlesTrans.addControlesEI(nuevo);

            }
            else
            {
                Task.Run(() => MessageBox.Show("Ingrese los campos requeridos"));
            }
        }

        private void txt_Volumen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

        private void txt_DOptica_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
