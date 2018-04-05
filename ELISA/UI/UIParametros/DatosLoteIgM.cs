using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELISA.UI.UIParametros
{
    public partial class DatosLoteIgM : Form
    {
        private TextBox txtLoteIgM;
        private Boolean cambiosPendientes = false;
        private int indexEditRow = -1;
        private string updateId = "";

        public DatosLoteIgM(TextBox txtLoteIgM)
        {
            InitializeComponent();
            this.txtLoteIgM = txtLoteIgM;
            FillTable();
        }

        private void FillTable()
        {
            
        }
    }
}
