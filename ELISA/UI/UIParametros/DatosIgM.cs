using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Transaccion.DatosProtocoloTrans;

namespace ELISA.UI.UIParametros
{
    public partial class DatosIgM : Form
    {
        public DatosIgM()
        {
            InitializeComponent();
        }

        private void DatosIgM_Load(object sender, EventArgs e)
        {
            date_Fecha.Value = DateTime.Now;
        }

        private async Task fillFields()
        {
            datosprotocoloigg data = DatosProtocoloIgG.TraerDatosProtocoloIgG();
            txt_LoteIgG.Text = data.LoteIgG;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
