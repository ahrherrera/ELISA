using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion.DatosProtocoloTrans
{
    class DatosProtocoloRotavirus
    {

        public static datosprotocolorotaviru TraerDatosprotocoloRotavirus()
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    datosprotocolorotaviru dat;
                    var listaProtocolo = context.datosprotocolorotavirus.ToList();
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

        public static void updateProtocoloRV(datosprotocolorotaviru data)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    datosprotocolorotaviru datos = context.datosprotocolorotavirus.Single(x => x.idDatosProtocoloRV == 1);
                    datos.Codigo = data.Codigo;
                    datos.ProcH2O = data.ProcH2O;
                    datos.TIMES = data.TIMES;
                    datos.ControlPos = data.ControlPos;
                    datos.ControlNeg = data.ControlNeg;
                    datos.ControlNegLI = data.ControlNegLI;
                    datos.ControlNegLS = data.ControlNegLS;
                    data.ControlPosLI = data.ControlPosLI;
                    data.ControlPosLS = data.ControlNegLS;
                    context.SaveChanges();

                    Task.Run(() =>
                    {
                        MessageBox.Show("Ha sido actualizado correctamente");
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: update RV: " + ex.StackTrace);
            }
        }


    }
}
