using System;
using System.Windows.Forms;
using ELISA.Transaccion;
using ELISA.Utils;

namespace ELISA.UI.UIParametros.Controles
{
    public partial class SHN : Form
    {
        private TextBox parent;
        private Boolean cambiosPendientes = false;
        private int indexEditRow = -1;
        private string updateId = "";
        public SHN(TextBox txt)
        {
            InitializeComponent();
            switchParam();
            this.parent = txt;
        }

        private void switchParam()
        {
            SHNTrans.getSHN(dgv_Controles);
            dgv_Controles.Columns[0].ReadOnly = true;

            dgv_Controles.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_Controles.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_Controles.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_Controles.Columns[0].HeaderText = "Lote Asignado Ser";
            dgv_Controles.Columns[1].HeaderText = "Lote";
            dgv_Controles.Columns[2].HeaderText = "Distribuidora";
            dgv_Controles.Columns[3].HeaderText = "Cod Catalogo Ser";
            dgv_Controles.Columns[4].HeaderText = "Fecha de Inicio";
            dgv_Controles.Columns[5].HeaderText = "Fecha de Finalización";
            dgv_Controles.Columns[6].HeaderText = "Fecha de Expiración";
            dgv_Controles.Columns[7].HeaderText = "Volumen Total";
            dgv_Controles.Columns[8].HeaderText = "Volumen Pozo";
            dgv_Controles.Columns[9].HeaderText = "Concentración Inc";
            dgv_Controles.Columns[10].HeaderText = "Concentración Uso";
            dgv_Controles.Columns[11].HeaderText = "Observaciones";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String selected = dgv_Controles.CurrentRow.Cells[0].FormattedValue.ToString();
            parent.Text = selected;
            this.Close();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            //Mostrar ventana de agregar

            NuevoSHN nuevoShn = new NuevoSHN();
            DialogResult res = nuevoShn.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                switchParam();
                dgv_Controles.FirstDisplayedScrollingRowIndex = dgv_Controles.RowCount - 1;
            }

        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Controles.SelectedRows.Count > 0)
            {
                DialogResult res = MessageBox.Show("¿Está seguro de eliminar este elemento?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    String CodigoControl = dgv_Controles.CurrentRow.Cells[0].FormattedValue.ToString();


                    SHNTrans.removeSHN(CodigoControl);
                    switchParam();
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
            switchParam();
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
                shn data = (shn)gridrow.DataBoundItem;
                //MessageBox.Show(data.Cod_Asign_ContIgM + " ID: "+ updateId);
                SHNTrans.updateSHN(updateId, data);
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
