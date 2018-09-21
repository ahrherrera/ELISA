using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion
{
    class SHNTrans
    {

        public static void updateSHN(string codigo, shn update)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    shn subs = context.shns.Single(x => x.Lote_Asign_Ser == codigo);
                    subs.Lote = update.Lote;
                    subs.Distribuidora = update.Distribuidora;
                    subs.Cod_Catalogo_Ser = update.Cod_Catalogo_Ser;
                    subs.Fecha_Inicia = update.Fecha_Inicia;
                    subs.Fecha_Termina = update.Fecha_Termina;
                    subs.Fecha_Expiracion = update.Fecha_Expiracion;
                    subs.Vol_total = update.Vol_total;
                    subs.Vol_Pozo = update.Vol_Pozo;
                    subs.Concentracion_Inc = update.Concentracion_Inc;
                    subs.Concentracion_Uso = update.Concentracion_Uso;
                    subs.Observaciones = update.Observaciones;

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
                Log.logError("Error capturado: Update Subs: " + ex.Message);
            }
        }

        public static void removeSHN(string codigo)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    shn subs = context.shns.Single(x => x.Lote_Asign_Ser == codigo);
                    context.shns.Remove(subs);
                    Task.Run(() =>
                    {
                        MessageBox.Show("Ha sido eliminado correctamente");
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Remove Subs: " + e.Message);
            }
        }

        public static void addSHN(shn nuevo)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    shn subs = new shn();
                    subs.Lote_Asign_Ser = nuevo.Lote_Asign_Ser;
                    subs.Lote = nuevo.Lote;
                    subs.Distribuidora = nuevo.Distribuidora;
                    subs.Cod_Catalogo_Ser = nuevo.Cod_Catalogo_Ser;
                    subs.Fecha_Inicia = nuevo.Fecha_Inicia;
                    subs.Fecha_Termina = nuevo.Fecha_Termina;
                    subs.Fecha_Expiracion = nuevo.Fecha_Expiracion;
                    subs.Vol_total = nuevo.Vol_total;
                    subs.Vol_Pozo = nuevo.Vol_Pozo;
                    subs.Concentracion_Inc = nuevo.Concentracion_Inc;
                    subs.Concentracion_Uso = nuevo.Concentracion_Uso;
                    subs.Observaciones = nuevo.Observaciones;
                    context.shns.Add(subs);
                    Task.Run(() =>
                    {
                        MessageBox.Show("Ha sido agregado correctamente");
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Agregar Subs: " + e.Message);
            }
        }

        public static void getSHN(DataGridView tabla)
        {
            tabla.DataSource = null;
            try
            {
                using (var context = new elisaEntities2())
                {
                    List<shn> substratos = null;
                    substratos = context.shns.ToList();
                    tabla.DataSource = substratos;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Obtener Substrato: " + e.Message);
            }
        }
    }
}
