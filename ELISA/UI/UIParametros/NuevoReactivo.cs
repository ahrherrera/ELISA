using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Transaccion;

namespace ELISA.UI.UIParametros
{
    public partial class NuevoReactivo : Form
    {
        private string codKit;
        public NuevoReactivo(string codigoKit)
        {
            InitializeComponent();
            codKit = codigoKit;
        }

        private void txt_CodC1_TextChanged(object sender, EventArgs e)
        {
            txt_CodC2.Text = txt_CodC1.Text;
            txt_CodC3.Text = txt_CodC1.Text;
            txt_CodC4.Text = txt_CodC1.Text;
            txt_CodC5.Text = txt_CodC1.Text;
            txt_CodC6.Text = txt_CodC1.Text;
            txt_CodC7.Text = txt_CodC1.Text;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            reactivos_rotaviru bufer1 = new reactivos_rotaviru();
            bufer1.CodigoC = txt_CodC1.Text;
            bufer1.CodigoKit = codKit;
            bufer1.Componente = "Buffer de Lavado 25X";
            bufer1.Fecha_Expiracion = date_Exp1.Value;
            bufer1.Lote = txt_Lote1.Text;
            bufer1.Observaciones = txt_Obs1.Text;

            reactivos_rotaviru bufer2 = new reactivos_rotaviru();
            bufer2.CodigoC = txt_CodC2.Text;
            bufer2.CodigoKit = codKit;
            bufer2.Componente = "Conjugado";
            bufer2.Fecha_Expiracion = date_Exp2.Value;
            bufer2.Lote = txt_Lote2.Text;
            bufer2.Observaciones = txt_Obs2.Text;

            reactivos_rotaviru bufer3 = new reactivos_rotaviru();
            bufer3.CodigoC = txt_CodC3.Text;
            bufer3.CodigoKit = codKit;
            bufer3.Componente = "Control Positivo";
            bufer3.Fecha_Expiracion = date_Exp3.Value;
            bufer3.Lote = txt_Lote3.Text;
            bufer3.Observaciones = txt_Obs3.Text;

            reactivos_rotaviru bufer4 = new reactivos_rotaviru();
            bufer4.CodigoC = txt_CodC4.Text;
            bufer4.CodigoKit = codKit;
            bufer4.Componente = "Diluyente de Muestra";
            bufer4.Fecha_Expiracion = date_Exp4.Value;
            bufer4.Lote = txt_Lote4.Text;
            bufer4.Observaciones = txt_Obs4.Text;

            reactivos_rotaviru bufer5 = new reactivos_rotaviru();
            bufer5.CodigoC = txt_CodC5.Text;
            bufer5.CodigoKit = codKit;
            bufer5.Componente = "Placa";
            bufer5.Fecha_Expiracion = date_Exp5.Value;
            bufer5.Lote = txt_Lote5.Text;
            bufer5.Observaciones = txt_Obs5.Text;

            reactivos_rotaviru bufer6 = new reactivos_rotaviru();
            bufer6.CodigoC = txt_CodC6.Text;
            bufer6.CodigoKit = codKit;
            bufer6.Componente = "Solucion Stop";
            bufer6.Fecha_Expiracion = date_Exp6.Value;
            bufer6.Lote = txt_Lote6.Text;
            bufer6.Observaciones = txt_Obs6.Text;

            reactivos_rotaviru bufer7 = new reactivos_rotaviru();
            bufer7.CodigoC = txt_CodC7.Text;
            bufer7.CodigoKit = codKit;
            bufer7.Componente = "Substrato";
            bufer7.Fecha_Expiracion = date_Exp7.Value;
            bufer7.Lote = txt_Lote7.Text;
            bufer7.Observaciones = txt_Obs7.Text;

            KitELISATrans.nuevoComponente(bufer1);
            KitELISATrans.nuevoComponente(bufer2);
            KitELISATrans.nuevoComponente(bufer3);
            KitELISATrans.nuevoComponente(bufer4);
            KitELISATrans.nuevoComponente(bufer5);
            KitELISATrans.nuevoComponente(bufer6);
            KitELISATrans.nuevoComponente(bufer7);

            Task.Run(() => MessageBox.Show("Ha sido agregado correctamente"));
            this.Close();

        }
    }
}
