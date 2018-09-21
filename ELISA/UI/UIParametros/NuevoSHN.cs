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
    public partial class NuevoSHN : Form
    {
        private Boolean fechaFinMod = false;
        private Boolean fechaInicioMod = false;
        private Boolean fechaExpMod = false;
        public NuevoSHN()
        {
            InitializeComponent();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (!txtCodigoLoteSer.Text.Equals(""))
            {
                shn subs = new shn();
                subs.Lote_Asign_Ser = txtCodigoLoteSer.Text;
                subs.Lote = txt_Lote.Text;
                subs.Distribuidora = txt_Dist.Text;
                subs.Cod_Catalogo_Ser = txt_CodCatalogo.Text;
                if (fechaFinMod)
                {
                    subs.Fecha_Inicia = time_FechaFin.Value;
                }

                if (fechaInicioMod)
                {
                    subs.Fecha_Termina = time_FechaInicio.Value;
                }

                if (fechaExpMod)
                {
                    subs.Fecha_Expiracion = time_FechaExp.Value;
                }

                subs.Vol_total = float.Parse(txt_volTotal.Text);
                subs.Vol_Pozo = float.Parse(txt_volPozo.Text);
                subs.Concentracion_Inc = Int32.Parse(txt_ConInc.Text);
                subs.Concentracion_Uso = Int32.Parse(txt_ConUso.Text);

                if (!txt_Observacion.Text.Equals(""))
                {
                    subs.Observaciones = txt_Observacion.Text;
                }
                SHNTrans.addSHN(subs);
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

        private void time_FechaExp_ValueChanged(object sender, EventArgs e)
        {
            fechaExpMod = true;
        }
    }
}
