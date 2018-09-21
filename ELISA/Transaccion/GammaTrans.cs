using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion
{
    class GammaTrans
    {
        public static void updateGamma(String codigo, gammaglobulina update)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    gammaglobulina gamma = context.gammaglobulinas.Single(x => x.Lote_Asign_Gamma1 == codigo);
                    gamma.Codigo_Mx = update.Codigo_Mx;
                    gamma.Concen_Gamma = update.Concen_Gamma;
                    gamma.Fecha_Preparacion = update.Fecha_Preparacion;
                    gamma.Fecha_Terminacion = update.Fecha_Terminacion;
                    gamma.NH4SO4 = update.NH4SO4;
                    gamma.Observaciones = update.Observaciones;
                    gamma.PBS1X = update.PBS1X;
                    gamma.Volumen = update.Volumen;
                    context.SaveChanges();
                    Task.Run(() =>
                    {
                        MessageBox.Show("Ha sido actualizado correctamente");
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void getGammas(DataGridView tabla)
        {
            tabla.DataSource = null;
            try
            {
                using (var context = new elisaEntities2())
                {
                    List<gammaglobulina> lista = null;
                    lista = context.gammaglobulinas.OrderBy(x => x.Lote_Asign_Gamma1).ToList();
                    tabla.DataSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trayendo Lista Gamma: " + ex.Message);
            }
        }

        public static void removeGamma(String codigo)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    gammaglobulina gamma = context.gammaglobulinas.Single(x => x.Lote_Asign_Gamma1 == codigo);
                    context.gammaglobulinas.Remove(gamma);
                    context.SaveChanges();
                    Task.Run(() =>
                    {
                        MessageBox.Show("Ha sido eliminado correctamente");
                    });
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Eliminando Gamma: " + ex.Message);
            }
        }

        public static void addGamma(gammaglobulina nuevo)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    context.gammaglobulinas.Add(nuevo);
                    context.SaveChanges();
                    Task.Run(() =>
                    {
                        MessageBox.Show("Ha sido agregado correctamente");
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Agregando Gamma: " + ex.Message);
            }
        }

    }
}
