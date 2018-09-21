using System;
using System.Windows.Forms;
using ELISA.Transaccion;
using ELISA.Utils;

namespace ELISA.UI.UIParametros.Controles
{
    public partial class Gamma : Form
    {
        private Boolean cambiosPendientes = false;
        private int indexEditRow = -1;
        private string updateId = "";
        private TextBox txtGamma;
        public Gamma(TextBox txtGamma)
        {
            InitializeComponent();
            fillTable();
            this.txtGamma = txtGamma;
        }

        private void fillTable()
        {
            GammaTrans.getGammas(dgv_Controles);
            dgv_Controles.Columns[0].ReadOnly = true;
            dgv_Controles.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_Controles.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_Controles.Columns[0].HeaderText = "Lote Asignado Gamma";
            dgv_Controles.Columns[1].HeaderText = "Codigo MX";
            dgv_Controles.Columns[2].HeaderText = "PBS1X";
            dgv_Controles.Columns[3].HeaderText = "NH4SO4";
            dgv_Controles.Columns[4].HeaderText = "Volumen";
            dgv_Controles.Columns[5].HeaderText = "Concen Gamma";
            dgv_Controles.Columns[6].HeaderText = "Fecha de Preparación";
            dgv_Controles.Columns[7].HeaderText = "Fecha de Terminación";
            dgv_Controles.Columns[8].HeaderText = "Observaciones";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String selected = dgv_Controles.CurrentRow.Cells[0].FormattedValue.ToString();
            txtGamma.Text = selected;
            this.Close();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            //Mostrar ventana de agregar
            
            NuevoGamma nuevoGamma = new NuevoGamma();
            DialogResult res = nuevoGamma.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                fillTable();
                dgv_Controles.FirstDisplayedScrollingRowIndex = dgv_Controles.RowCount - 1;
            }

        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Controles.SelectedRows.Count > 0)
            {
                DialogResult res = MessageBox.Show("¿Está seguro eliminar este elemento?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    String CodigoControl = dgv_Controles.CurrentRow.Cells[0].FormattedValue.ToString();


                    GammaTrans.removeGamma(CodigoControl);
                    fillTable();
                }
            }
        }

        private void dgv_Controles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Controles.SelectedRows.Count>0)
            {
                btn_Eliminar.Enabled = true;
            }
        }

        private void Controles_Load(object sender, EventArgs e)
        {
            btn_Eliminar.Enabled = false;
            btn_Save.Enabled = false;
            btn_Select.Enabled = false;
            
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            fillTable();
        }

        private void dgv_Controles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            indexEditRow = e.RowIndex;
            btn_Save.Enabled = true;
            cambiosPendientes = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (cambiosPendientes)
            {
                DataGridViewRow gridrow = dgv_Controles.Rows[indexEditRow];
                gammaglobulina data = (gammaglobulina)gridrow.DataBoundItem;
                //MessageBox.Show(data.Cod_Asign_ContIgM + " ID: "+ updateId);
                GammaTrans.updateGamma(updateId, data);
            }
        }

        private void dgv_Controles_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            updateId = dgv_Controles.CurrentRow.Cells[0].FormattedValue.ToString();
        }

        private void dgv_Controles_SelectionChanged(object sender, EventArgs e)
        {
            btn_Save.Enabled = false;
            cambiosPendientes = false;
            btn_Select.Enabled = true;
        }
    }
}
