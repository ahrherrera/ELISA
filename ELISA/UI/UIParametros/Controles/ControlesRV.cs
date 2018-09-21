using System;
using System.Windows.Forms;
using ELISA.Transaccion;
using ELISA.Utils;

namespace ELISA.UI.UIParametros.Controles
{
    public partial class ControlesRV : Form
    {
        private TextBox parent;
        private Boolean cambiosPendientes = false;
        private MainUtils.Controles param;
        private int indexEditRow = -1;
        private string updateId = "";
        public ControlesRV(MainUtils.Controles param, TextBox parent)
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
                case MainUtils.Controles.ControlesRV_CP:
                {
                    //Select * from [Controles Rotavirus]Where TipoControl = 'Pos'
                        ControlesTrans.getControles("RV", "Pos", dgv_Controles);
                        break;
                }
                case MainUtils.Controles.ControlesRV_CN:
                {
                        //Select * from [Controles Rotavirus] Where TipoControl = 'Neg'
                        ControlesTrans.getControles("RV", "Neg", dgv_Controles);
                        break;
                }
            }
            dgv_Controles.Columns[0].ReadOnly = true;
            
            dgv_Controles.Columns[0].HeaderText = "Código Control";
            dgv_Controles.Columns[1].HeaderText = "Tipo";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String selected = dgv_Controles.CurrentRow.Cells[0].FormattedValue.ToString();
            switch (param)
            {
                case MainUtils.Controles.ControlesRV_CP:
                {
                    parent.Text = selected;
                        break;
                }
                case MainUtils.Controles.ControlesRV_CN:
                {
                    parent.Text = selected;
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
                case MainUtils.Controles.ControlesRV_CP:
                {
                    NuevoControlRV controlCPA = new NuevoControlRV(MainUtils.Controles.ControlesRV_CP);
                    DialogResult res = controlCPA.ShowDialog(this);
                    if (res == DialogResult.OK)
                    {
                        switchParam(param);
                        dgv_Controles.FirstDisplayedScrollingRowIndex = dgv_Controles.RowCount - 1;
                    }
                    break;
                }
                case MainUtils.Controles.ControlesRV_CN:
                {
                    NuevoControlRV controlCPA = new NuevoControlRV(MainUtils.Controles.ControlesRV_CN);
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


                    ControlesTrans.removeControl("RV", CodigoControl);
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
            btn_Select.Enabled = false;
            
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            switchParam(param);
        }

        private void dgv_Controles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            indexEditRow = e.RowIndex;
            cambiosPendientes = true;

        }

        private void dgv_Controles_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            updateId = dgv_Controles.CurrentRow.Cells[0].FormattedValue.ToString();
        }

        private void dgv_Controles_SelectionChanged(object sender, EventArgs e)
        {
            cambiosPendientes = false;
            btn_Select.Enabled = true;
        }
    }
}
