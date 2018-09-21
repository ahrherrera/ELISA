using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion
{
    class PBTrans
    {

        public static void updatePB(String codigo, pbs1x update)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    pbs1x pb = context.pbs1x.Single(x => x.Lote_Asign_20X == codigo);
                    pb.H2ODEST = update.H2ODEST;
                    pb.Lote_Asign_1X = update.Lote_Asign_1X;
                    pb.Numero = update.Numero;
                    pb.Observaciones = update.Observaciones;
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
                Log.logError("Error capturado: Update PB: " + ex.Message);
            }
        }

        public static void removePB(string codigo)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    pbs1x pb = context.pbs1x.Single(x => x.Lote_Asign_20X == codigo);
                    context.pbs1x.Remove(pb);
                    Task.Run(() =>
                    {
                        MessageBox.Show("Ha sido eliminado correctamente");
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Remove PB: " + e.Message);
            }
        }

        public static void addPB(pbs1x nuevo)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    pbs1x pb = new pbs1x();
                    pb.H2ODEST = nuevo.H2ODEST;
                    pb.Lote_Asign_1X = nuevo.Lote_Asign_1X;
                    pb.Lote_Asign_20X = nuevo.Lote_Asign_20X;
                    pb.Numero = nuevo.Numero;
                    pb.Volumen = nuevo.Volumen;
                    pb.Observaciones = nuevo.Observaciones;
                    context.pbs1x.Add(pb);
                    Task.Run(() =>
                    {
                        MessageBox.Show("Ha sido agregado correctamente");
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Agregar PB: " + e.Message);
            }
        }

        public static void getPB(DataGridView tabla)
        {
            tabla.DataSource = null;
            try
            {
                using (var context = new elisaEntities2())
                {
                    List<pbs1x> pbs1Xes = null;
                    pbs1Xes = context.pbs1x.ToList();
                    tabla.DataSource = pbs1Xes;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Obtener PB: " + e.Message);
            }
        }
    }
}
