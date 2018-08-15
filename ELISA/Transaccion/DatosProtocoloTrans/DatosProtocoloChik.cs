using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion.DatosProtocoloTrans
{
    class DatosProtocoloChik
    {
        public static datosprotocolochik TraerDatosprotocoloChik()
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    datosprotocolochik dat;
                    var listaProtocolo = context.datosprotocolochiks.ToList();
                    dat = listaProtocolo[0];
                    return dat;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.StackTrace);
                return null;

            }
        }
    }
}
