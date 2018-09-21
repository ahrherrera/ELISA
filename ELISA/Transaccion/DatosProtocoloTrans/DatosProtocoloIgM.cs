using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion.DatosProtocoloTrans
{
    class DatosProtocoloIgM
    {

        public static datosprotocoloigm TraerDatosProtocoloIgM()
        {

            try
            {
                using (var context = new elisaEntities2())
                {
                    datosprotocoloigm dat;
                    //var listaProtocolo = (from u in context.datosprotocoloigms select u).FirstOrDefault();
                    //dat = listaProtocolo;
                    var listaProtocolo = context.datosprotocoloigms.ToList();
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

        public static void updateProtocoloIgM(datosprotocoloigm data)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    datosprotocoloigm datos = context.datosprotocoloigms.Single(x => x.idDatosProtocoloIgM == 1);
                    datos.LoteIgM = data.LoteIgM;
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
                    datos.ControlPosA = data.ControlPosA;
                    datos.ControlPosB = data.ControlPosB;
                    datos.ControlNeg = data.ControlNeg;
                    datos.ControlNegLI = data.ControlNegLI;
                    datos.ControlNegLS = data.ControlNegLS;
                    datos.ControlNegRadLI = data.ControlNegRadLI;
                    datos.ControlRadPos = data.ControlRadPos;
                    datos.ControlPosRadLI = data.ControlPosRadLI;
                    datos.ControlPosRadLS = data.ControlPosRadLS;
                    datos.ControlRadNeg = data.ControlRadNeg;
                    datos.ControlNegRadLS = data.ControlNegRadLS;
                    datos.ControlNegRadLI = data.ControlNegRadLI;
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
                Log.logError("Error capturado: Guardando Protocolo IgM: " + ex.StackTrace);

            }
        }

    }
}
