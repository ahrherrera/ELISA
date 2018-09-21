using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion.DatosProtocoloTrans
{
    class DatosProtocoloEIChikMono
    {
        public static datosprotocolochikmono TraerDatosProtocoloChikMono()
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    datosprotocolochikmono dat;
                    var listaProtocolo = context.datosprotocolochikmonoes.ToList();
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

        public static void updateProtocoloChikMono(datosprotocolochikmono data)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    datosprotocolochikmono datos =
                        context.datosprotocolochikmonoes.Single(x => x.idDatosProtocoloChikMono == 1);
                    datos.LoteEI = data.LoteEI;
                    datos.GGLOB = data.GGLOB;
                    datos.VolUsado = data.VolUsado;
                    datos.TipoEstudio = data.TipoEstudio;
                    datos.ProcH2O = data.ProcH2O;
                    datos.TB = data.TB;
                    datos.TMPB = data.TMPB;
                    datos.TIMEB = data.TIMEB;
                    datos.PB = data.PB;
                    datos.Coatting = data.Coatting;
                    datos.LoteAntigeno = data.LoteAntigeno;
                    datos.SHN = data.SHN;
                    datos.STOP = data.STOP;
                    datos.Substrato = data.Substrato;
                    datos.TSubstrato = data.TSubstrato;
                    datos.Conjugado = data.Conjugado;
                    datos.FB = data.FB;
                    datos.fechafijGG = data.fechafijGG;
                    datos.ControlPos = data.ControlPos;
                    datos.ControlNeg = data.ControlNeg;
                    datos.ControlNegLI = data.ControlNegLI;
                    datos.ControlNegLS = data.ControlNegLS;
                    context.SaveChanges();
                    Task.Run(() =>
                    {
                        MessageBox.Show("Ha sido actualizado correctamente");
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + e.StackTrace);
            }
        }

    }
}
