using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion.DatosProtocoloTrans
{
    class DatosProtocoloIgG
    {

        public static datosprotocoloigg TraerDatosProtocoloIgG()
        {
            datosprotocoloigg dat;
            try
            {
                using (var context = new elisaEntities1())
                {
                    var listaProtocolo = context.datosprotocoloiggs.First();
                    dat = listaProtocolo;
                    return dat;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.Message);
                return null;
            }
        }

    }
}
