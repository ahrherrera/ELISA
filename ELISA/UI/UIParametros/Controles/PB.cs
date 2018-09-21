using System;
using System.Windows.Forms;
using ELISA.Transaccion;
using ELISA.Utils;

namespace ELISA.UI.UIParametros.Controles
{
    public partial class PB : Form
    {
        private Boolean cambiosPendientes = false;
        private int indexEditRow = -1;
        private string updateId = "";
        private TextBox txt_PB;
        public PB(TextBox txt_PB)
        {
            InitializeComponent();
            fillTable();
            this.txt_PB = txt_PB;
        }

        private void fillTable()
        {
            PBTrans.getPB(dgv_Controles);
            dgv_Controles.Columns[0].ReadOnly = true;
            dgv_Controles.Columns[0].HeaderText = "Lote Asignado 20X";
            dgv_Controles.Columns[1].HeaderText = "Numero";
            dgv_Controles.Columns[2].HeaderText = "Lote Asignado 1X";
            dgv_Controles.Columns[3].HeaderText = "Volumen";
            dgv_Controles.Columns[4].HeaderText = "H2O Dest";
            dgv_Controles.Columns[5].HeaderText = "Observaciones";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String selected = dgv_Controles.CurrentRow.Cells[0].FormattedValue.ToString();
            txt_PB.Text = selected;
            this.Close();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            //Mostrar ventana de agregar
            
            NuevoPB nuevoPB = new NuevoPB();
            DialogResult res = nuevoPB.ShowDialog(this);
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


                    PBTrans.removePB(CodigoControl);
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
                pbs1x data = (pbs1x)gridrow.DataBoundItem;
                //MessageBox.Show(data.Cod_Asign_ContIgM + " ID: "+ updateId);
                PBTrans.updatePB(updateId, data);
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
