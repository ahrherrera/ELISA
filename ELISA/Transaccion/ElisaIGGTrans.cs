using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion
{
    class ElisaIGGTrans
    {
        public static void saveElisaIGG(elisaigg newRecord)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    context.elisaiggs.Add(newRecord);
                    context.SaveChanges();
                    //Task.Run(() => { MessageBox.Show("Ha sido agregado correctamente"); });
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
