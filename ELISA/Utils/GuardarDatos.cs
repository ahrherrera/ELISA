using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Transaccion.DatosProtocoloTrans;
using ELISA.UI.UIParametros;

namespace ELISA.Utils
{
    class GuardarDatos
    {
        public static void GuardarIgM(String [,] protocolo)
        {
            //Inicializar la ventana de DatosIgM para que el laboratorista pueda
            //confirmar los datos del protocolo antes de comenzar a Guardar.
            DatosIgM datos = new DatosIgM();
            datosprotocoloigm protocoloigm = DatosProtocoloIgM.TraerDatosProtocoloIgM();
            if (datos.ShowDialog() == DialogResult.OK)
            {
                //Los datos han sido verificados
            }
            else
            {
                MessageBox.Show("Debe verificar los datos del protocolo IgM.", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
