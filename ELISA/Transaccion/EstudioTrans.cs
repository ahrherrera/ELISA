using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion
{
    class EstudioTrans
    {
        public static void LlenarEstudio(ComboBox cmb)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    var listaEstudio = context.estudios.ToList();
                    cmb.DataSource = listaEstudio;
                    cmb.DisplayMember = "Estudio1";
                    cmb.Invalidate();
                    Log.logInfo("Lista de estudio cargado correctamente");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.Message);
            }
        }
    }
}
