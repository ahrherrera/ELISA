using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion
{
    class ElisaChikTrans
    {

        public static void saveElisaChikCNDR(chikungunya newRecord)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    context.chikungunyas.Add(newRecord);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido una excepcion.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Guardando ELISA IgG: " + ex.StackTrace);
            }
        }
    }
}
