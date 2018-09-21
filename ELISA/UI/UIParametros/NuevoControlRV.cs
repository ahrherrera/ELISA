using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Transaccion;
using ELISA.Utils;

namespace ELISA.UI.UIParametros
{
    public partial class NuevoControlRV : Form
    {
        private Boolean fechaFinMod = false;
        private Boolean fechaInicioMod = false;
        private MainUtils.Controles control;

        public NuevoControlRV(Utils.MainUtils.Controles control)
        {
            InitializeComponent();
            this.control = control;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (!txtCodigoControl.Text.Equals(""))
            {
                controles_rotaviru nuevo = new controles_rotaviru();
                nuevo.CodControl = txtCodigoControl.Text;
                
                switch (control)
                {
                    case MainUtils.Controles.ControlesRV_CP:
                    {
                        nuevo.TipoControl = "Pos";
                            break;
                    }
                    case MainUtils.Controles.ControlesRV_CN:
                    {
                        nuevo.TipoControl = "Neg";
                            break;
                    }
                }
                ControlesTrans.addControlesRV(nuevo);

            }
            else
            {
                Task.Run(() => MessageBox.Show("Ingrese los campos requeridos"));
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
