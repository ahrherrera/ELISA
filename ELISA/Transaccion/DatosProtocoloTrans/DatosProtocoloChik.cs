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

        public static void updateProtocoloChik(datosprotocolochik data)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    datosprotocolochik datos = context.datosprotocolochiks.Single(x => x.idDatosProtocoloChik == 1);
                    datos.LoteIgM = data.LoteIgM;
                    datos.GGLOB = data.GGLOB;
                    datos.VolUsado = data.VolUsado;
                    datos.FVC = data.FVC;
                    datos.ProcH2O = data.ProcH2O;
                    datos.TB = data.TB;
                    datos.TMPB = data.TMPB;
                    datos.TIMEB = data.TIMEB;
                    datos.PB = data.PB;
                    datos.Coatting = data.Coatting;
                    datos.LoteAntigenoViral = data.LoteAntigenoViral;
                    datos.SHN = data.SHN;
                    datos.STOP = data.STOP;
                    datos.Substrato = data.Substrato;
                    datos.TSubstrato = data.TSubstrato;
                    datos.Conjugado = data.Conjugado;
                    datos.FB = data.FB;
                    datos.fechafijGG = data.fechafijGG;
                    datos.ControlPos = data.ControlPos;
                    datos.ControlNeg = data.ControlNeg;
                    datos.LimCNI = data.LimCNI;
                    datos.LimCPI = data.LimCPI;
                    datos.LimCPS = data.LimCPS;
                    datos.LimCNS = data.LimCNS;
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
                Log.logError("Error capturado: Update ProtocoloChik: " + ex.StackTrace);

            }
        }


        public static void saveElisaChik(chikungunya newRec)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    context.chikungunyas.Add(newRec);
                    context.SaveChanges();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido una excepcion.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Guardando Chik: " + ex.Message);
            }
        }
    }
}

