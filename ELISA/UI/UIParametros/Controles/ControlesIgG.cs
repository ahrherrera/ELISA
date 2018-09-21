using System;
using System.Windows.Forms;
using ELISA.Transaccion;
using ELISA.Utils;

namespace ELISA.UI.UIParametros.Controles
{
    public partial class ControlesIgG : Form
    {
        private DatosIgG parent;
        private Boolean cambiosPendientes = false;
        private MainUtils.Controles param;
        private int indexEditRow = -1;
        private string updateId = "";
        public ControlesIgG(MainUtils.Controles param, DatosIgG parent)
        {
            InitializeComponent();
            switchParam(param);
            this.parent = parent;
            this.param = param;
        }

        private void switchParam(MainUtils.Controles param)
        {
            switch (param)
            {
                case MainUtils.Controles.ControlesIgG_CP:
                {
                    // Select * from Controles_IgG Where Tipo_Control = 'C+'
                        ControlesTrans.getControles("IgG", "C+", dgv_Controles);
                        break;
                }
                case MainUtils.Controles.ControlesIgG_CN:
                {
                        //Select * from Controles_IgG Where Tipo_Control = 'C-'
                        ControlesTrans.getControles("IgG", "C-", dgv_Controles);
                        break;
                }
                case MainUtils.Controles.ControlesIgG_CNS:
                {
                        //Select * from Controles_IgG Where Tipo_Control = 'S-'
                        ControlesTrans.getControles("IgG", "S-", dgv_Controles);
                        break;
                }
            }
            dgv_Controles.Columns[0].ReadOnly = true;

            dgv_Controles.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_Controles.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_Controles.Columns[0].HeaderText = "Código Asign ContIgG";
            dgv_Controles.Columns[1].HeaderText = "Tipo Control";
            dgv_Controles.Columns[2].HeaderText = "D Optica";
            dgv_Controles.Columns[3].HeaderText = "Volumen";
            dgv_Controles.Columns[4].HeaderText = "Fecha de Inicio";
            dgv_Controles.Columns[5].HeaderText = "Fecha de Finalización";
            dgv_Controles.Columns[6].HeaderText = "Observaciones";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String selected = dgv_Controles.CurrentRow.Cells[0].FormattedValue.ToString();
            switch (param)
            {
                case MainUtils.Controles.ControlesIgG_CP:
                {
                    parent.txt_ControlPos.Text = selected;
                    break;
                }
                case MainUtils.Controles.ControlesIgG_CN:
                {
                    parent.txt_ControlNeg.Text = selected;
                    break;
                }
                case MainUtils.Controles.ControlesIgG_CNS:
                {
                    parent.txt_ControlNegSal.Text = selected;
                    break;
                }
            }
            this.Close();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            //Mostrar ventana de agregar
            switch (param)
            {
                case MainUtils.Controles.ControlesIgG_CP:
                {
                    NuevoControlIgG controlCPA = new NuevoControlIgG(MainUtils.Controles.ControlesIgG_CP);
                    DialogResult res = controlCPA.ShowDialog(this);
                    if (res == DialogResult.OK)
                    {
                        switchParam(param);
                        dgv_Controles.FirstDisplayedScrollingRowIndex = dgv_Controles.RowCount - 1;
                    }
                    break;
                }
                case MainUtils.Controles.ControlesIgG_CN:
                {
                    NuevoControlIgG controlCPA = new NuevoControlIgG(MainUtils.Controles.ControlesIgG_CN);
                    DialogResult res = controlCPA.ShowDialog(this);
                    if (res == DialogResult.OK)
                    {
                        switchParam(param);
                        dgv_Controles.FirstDisplayedScrollingRowIndex = dgv_Controles.RowCount - 1;
                    }
                        break;
                }
                case MainUtils.Controles.ControlesIgG_CNS:
                {
                    NuevoControlIgG controlCPA = new NuevoControlIgG(MainUtils.Controles.ControlesIgG_CNS);
                    DialogResult res = controlCPA.ShowDialog(this);
                    if (res == DialogResult.OK)
                    {
                        switchParam(param);
                        dgv_Controles.FirstDisplayedScrollingRowIndex = dgv_Controles.RowCount - 1;
                    }
                        break;
                }
            }

        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Controles.SelectedRows.Count > 0)
            {
                DialogResult res = MessageBox.Show("¿Está seguro de eliminar este control?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    String CodigoControl = dgv_Controles.CurrentRow.Cells[0].FormattedValue.ToString();


                    ControlesTrans.removeControl("IgG", CodigoControl);
                    switchParam(param);
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
            switchParam(param);
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
                controles_igg data = (controles_igg)gridrow.DataBoundItem;
                //MessageBox.Show(data.Cod_Asign_ContIgM + " ID: "+ updateId);
                ControlesTrans.updateControlIgG(updateId, data);
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
