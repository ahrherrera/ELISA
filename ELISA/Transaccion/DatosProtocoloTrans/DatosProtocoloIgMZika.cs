using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion.DatosProtocoloTrans
{
    class DatosProtocoloIgMZika
    {
        public static datosprotocoloigmzika TraerDatosprotocoloigmzika()
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    datosprotocoloigmzika dat;
                    var listaProtocolo = context.datosprotocoloigmzikas.ToList();
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

        public static void updateprotocoloIgMZika(datosprotocoloigmzika data)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    datosprotocoloigmzika datos =
                        context.datosprotocoloigmzikas.Single(x => x.idDatosProtocoloIgM == 1);
                    datos.LoteIgM = data.LoteIgM;
                    datos.LoteAntigeno = data.LoteAntigeno;
                    datos.VolUsadoIGM = data.VolUsadoIGM;
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
                    datos.fechafijIGM = data.fechafijIGM;
                    datos.ControlPos = data.ControlPos;
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
                    datos.Factor = data.Factor;
                    datos.Factor2 = data.Factor2;

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
                Log.logError("Error capturado: update IgMZika: " + ex.StackTrace);
            }
        }
    }
}
