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
    public partial class DatosCoatting : Form
    {
        private TextBox txtCoat;
        private Boolean cambiosPendientes = false;
        int indexEditROw = -1;
        private string updateId = "";
        public DatosCoatting(TextBox txtCoat)
        {
            InitializeComponent();
            this.txtCoat = txtCoat;
            FillTable();
        }

        private void DatosCoatting_Load(object sender, EventArgs e)
        {
            btn_Save.Enabled = false;
            cambiosPendientes = false;
            btn_Select.Enabled = true;

        }

        private void FillTable()
        {
            ph96CoattingTrans.getph96Coatting(dgv_Coatting);
            dgv_Coatting.Columns[0].ReadOnly = true;
            dgv_Coatting.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_Coatting.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_Coatting.Columns[0].HeaderText = "Código Lote Coatting";
            dgv_Coatting.Columns[1].HeaderText = "Volumen";
            dgv_Coatting.Columns[2].HeaderText = "Na2CO3";
            dgv_Coatting.Columns[3].HeaderText = "NaHCO3";
            dgv_Coatting.Columns[4].HeaderText = "H2ODEST";
            dgv_Coatting.Columns[5].HeaderText = "pH";
            dgv_Coatting.Columns[6].HeaderText = "Fecha de Preparación";
            dgv_Coatting.Columns[7].HeaderText = "Fecha de Expiración";
            dgv_Coatting.Columns[8].HeaderText = "Observaciones";
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            String selected = dgv_Coatting.CurrentRow.Cells[0].FormattedValue.ToString();
            txtCoat.Text = selected;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Coatting.SelectedRows.Count > 0)
            {
                DialogResult res = MessageBox.Show("¿Está seguro de eliminar este control?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res ==DialogResult.Yes)
                {
                    String codigoControl = dgv_Coatting.CurrentRow.Cells[0].FormattedValue.ToString();
                    ph96CoattingTrans.removeph96Coatting(codigoControl);
                    FillTable();
                }
            }
        }

        private void dgv_Coatting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Coatting.SelectedRows.Count>0)
            {
                btn_Eliminar.Enabled = true;
            }
        }

        private void dgv_Coatting_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            updateId = dgv_Coatting.CurrentRow.Cells[0].FormattedValue.ToString();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (cambiosPendientes)
            {
                DataGridViewRow gridrow = dgv_Coatting.Rows[indexEditROw];
                ph_9_6__coatting_ data = (ph_9_6__coatting_) gridrow.DataBoundItem;
                ph96CoattingTrans.updateph96Coatting(updateId,data);
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            NuevoCoatting nuevocat = new NuevoCoatting();
            DialogResult res = nuevocat.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                FillTable();
                dgv_Coatting.FirstDisplayedScrollingRowIndex = dgv_Coatting.RowCount - 1;
            }
        }
    }
}
