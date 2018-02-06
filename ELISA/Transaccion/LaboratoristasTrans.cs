using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;
using MetroFramework.Drawing;

namespace ELISA.Transaccion
{
    class LaboratoristasTrans
    {

        public static void LlenarLaboratoristas(ComboBox cmb)
        {
            try
            {
                using (var context = new elisaEntities1())
                {
                    var listaLaboratoristas = context.laboratoristas.ToList();
                    cmb.DataSource = listaLaboratoristas;
                    cmb.DisplayMember = "Descrip";
                    cmb.ValueMember = "Cod";
                    cmb.Invalidate();
                    ELISA.Utils.Log.logInfo("Lista de laboratorista cargado correctamente");
                    cmb.SelectedItem = null;
                    cmb.SelectedText = "";
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
