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
    class KitELISATrans
    {
        public static void LlenarCodigosKit(DataGridView table)
        {
            table.DataSource = null;
            try
            {
                using (var context = new elisaEntities2())
                {
                    var lista = context.kit_elisa_rotavirus.OrderBy(x=> x.Codigo).Select(x=> new
                    {
                        x.Codigo,
                        x.Lote,
                        x.CasaComercial,
                        x.Metodo
                    }).ToList();
                    table.DataSource = lista;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.Message);
            }
        }

        public static void LlenarComboboxKit(ComboBox cmb)
        {
            cmb.DataSource = null;
            try
            {
                using (var context = new elisaEntities2())
                {
                    var listaCodigos = context.kit_elisa_rotavirus.ToList();
                    cmb.DataSource = listaCodigos;
                    cmb.DisplayMember = "Codigo";
                    cmb.Invalidate();
                    Log.logInfo("Lista de cod Kit cargado correctamente");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.Message);
            }
        }

        public static void LlenarTabla(DataGridView tabla, string codigoKit)
        {
            tabla.DataSource = null;
            try
            {
                using (var context = new elisaEntities2())
                {

                    var result = context.reactivos_rotavirus.Where(x=> x.CodigoKit == codigoKit).OrderBy(x=> x.CodigoKit).Select(x=> new
                    {
                        x.CodigoKit,
                        x.Componente,
                        x.CodigoC,
                        x.Lote,
                        x.Fecha_Expiracion,
                        x.Observaciones
                    }).ToList();
                    tabla.DataSource = result;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Obtener PB: " + ex.Message);
            }
        }

        public static List<componentesrotaviru> TraerComponentes()
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    List<componentesrotaviru> lista = null;
                    lista = context.componentesrotavirus.ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Obtener Comp RV: " + ex.Message);
                return null;
            }
        }

        public static void updateKit(string codigo, string lote, string cc, string metodo)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    kit_elisa_rotaviru kit = context.kit_elisa_rotavirus.Single(x => x.Codigo == codigo);
                    kit.Lote = lote;
                    kit.CasaComercial = cc;
                    kit.Metodo = metodo;
                    context.SaveChanges();
                    Task.Run(() => MessageBox.Show("Ha sido actualizado correctamente"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Actualizar Kit: " + ex.Message);
            }
        }

        public static void nuevoKit(string codigo, string lote, string cc, string metodo)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    kit_elisa_rotaviru kit = new kit_elisa_rotaviru();
                    kit.Codigo = codigo;
                    kit.Lote = lote;
                    kit.CasaComercial = cc;
                    kit.Metodo = metodo;
                    context.kit_elisa_rotavirus.Add(kit);
                    context.SaveChanges();
                    Task.Run(() => MessageBox.Show("Ha sido agregado correctamente"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Nuevo Kit: " + ex.Message);
            }
        }

        public static void nuevoComponente(reactivos_rotaviru data)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    data.kit_elisa_rotavirus = context.kit_elisa_rotavirus.Single(x => x.Codigo == data.CodigoKit);
                    context.reactivos_rotavirus.Add(data);
                    context.SaveChanges();
                    //Task.Run(() => MessageBox.Show("Ha sido agregado correctamente"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Nuevo Componente: " + ex.Message);
            }
        }
    }
}
