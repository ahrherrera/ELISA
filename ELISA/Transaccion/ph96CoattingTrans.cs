using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion
{
    class ph96CoattingTrans
    {
        public static void updateph96Coatting(String codLote, ph_9_6__coatting_ update)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    ph_9_6__coatting_ coat = context.ph_9_6__coatting_.Single(x => x.Lote_Asign_Coatting == codLote);
                    coat.Fecha_Expiracion = update.Fecha_Expiracion;
                    coat.Fecha_Preparacion = update.Fecha_Preparacion;
                    coat.H2ODEST = update.H2ODEST;
                    coat.Na2CO3 = update.Na2CO3;
                    coat.NaHCO3 = update.NaHCO3;
                    coat.pH = update.pH;
                    coat.Volumen = update.Volumen;
                    coat.Oservaciones = update.Oservaciones;
                    context.SaveChanges();

                    Task.Run(() => MessageBox.Show("Ha sido actualizado correctamente"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.Message);
            }
        }

        public static void getph96Coatting(DataGridView tabla)
        {
            tabla.DataSource = null;
            try
            {
                using (var context = new elisaEntities2())
                {
                    var lista = context.ph_9_6__coatting_.ToList();
                    tabla.DataSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.Message);
            }
        }

        public static void removeph96Coatting(String codLote)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    ph_9_6__coatting_ coat = context.ph_9_6__coatting_.Single(x => x.Lote_Asign_Coatting == codLote);
                    context.ph_9_6__coatting_.Remove(coat);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.Message);
            }
        }

        public static void addph96Coatting(ph_9_6__coatting_ coat)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    context.ph_9_6__coatting_.Add(coat);
                    context.SaveChanges();
                    Task.Run(() => { MessageBox.Show("Ha sido agregado correctamente"); });
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
