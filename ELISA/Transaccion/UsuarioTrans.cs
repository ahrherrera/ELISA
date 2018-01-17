using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.UI;
using ELISA.Utils;
using MetroFramework.Controls;

namespace ELISA.Transaccion
{
    class UsuarioTrans
    {


        public static void LlenarUsuarios(MetroComboBox cmb, Login parent)
        {
            try
            {
                using (var context = new elisaEntities1())
                {
                    var listaUsuarios = context.usuarios.ToList();
                    cmb.DataSource = listaUsuarios;
                    cmb.DisplayMember = "nombreUsuario";
                    cmb.Invalidate();
                    cmb.MaxDropDownItems = 10;
                    ELISA.Utils.Log.logInfo("Los usuarios han sido cargado correctamente. Numero de Usuarios: " +
                                            listaUsuarios.Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: "+ ex.Message);
                parent.Enabled = false;
            }

        }

        public static bool Login(string user , TextBox pass)
        {
            try { 
            Utils.Log.logInfo("Inicio de la consulta a la Base de Datos");
            string password = pass.Text;
            using (var context = new elisaEntities1())
            {
                var query = context.Database.SqlQuery<string>(
                    "select CAST(aes_decrypt(pass, '"+password+"') AS CHAR(50)) from Usuario" +
                    " where nombreUsuario = '"+user+"'").ToList();
                //Primer chequeo
                if (query[0] != null)
                {
                    //Segundo chequeo
                    if (query[0].Equals(password))
                    {
                        Utils.Log.logInfo("Usuario y contraseña son correctos");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Utils.Log.logInfo("Error al iniciar sesión con el usuario: " + user);
                    return false;
                }

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.Message);
                return false;
            }
        }
        
    }
}
