using System;
using System.Windows.Forms;
using ELISA.Transaccion;
using ELISA.Utils;

namespace ELISA.UI.UIParametros.Controles
{
    public partial class ControlesEI : Form
    {
        private DatosEI parent;
        private DatosEIChikMono parentChik;
        private DatosEIChikHiper parentChikHiper;
        private Boolean cambiosPendientes = false;
        private MainUtils.Controles param;
        private int indexEditRow = -1;
        private string updateId = "";
        public ControlesEI(MainUtils.Controles param, DatosEI parent)
        {
            InitializeComponent();
            switchParam(param);
            this.parent = parent;
            this.param = param;
        }

        public ControlesEI(MainUtils.Controles param, DatosEIChikMono parent)
        {
            InitializeComponent();
            switchParam(param);
            this.parentChik = parent;
            this.param = param;
        }

        public ControlesEI(MainUtils.Controles param, DatosEIChikHiper parent)
        {
            InitializeComponent();
            switchParam(param);
            this.parentChikHiper = parent;
            this.param = param;
        }

        private void switchParam(MainUtils.Controles param)
        {
            switch (param)
            {
                case MainUtils.Controles.ControlesEI_CPlus:
                {
                    ControlesTrans.getControles("EI", "C+", dgv_Controles);
                        break;
                }
                case MainUtils.Controles.ControlesEI_CMin:
                {
                    ControlesTrans.getControles("EI", "C-", dgv_Controles);
                        break;
                }
            }
            dgv_Controles.Columns[0].ReadOnly = true;
            dgv_Controles.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_Controles.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_Controles.Columns[0].HeaderText = "Código Control EI";
            dgv_Controles.Columns[1].HeaderText = "Tipo";
            dgv_Controles.Columns[2].HeaderText = "MxC";
            dgv_Controles.Columns[3].HeaderText = "D Optica";
            dgv_Controles.Columns[4].HeaderText = "Volumen";
            dgv_Controles.Columns[5].HeaderText = "Fecha de Inicio";
            dgv_Controles.Columns[6].HeaderText = "Fecha de Finalización";
            dgv_Controles.Columns[7].HeaderText = "Observaciones";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String selected = dgv_Controles.CurrentRow.Cells[0].FormattedValue.ToString();
            switch (param)
            {
                case MainUtils.Controles.ControlesEI_CMin:
                {
                    if (parentChik!=null)
                    {
                        parentChik.txt_ControlNeg.Text = selected;
                    }
                    else if(parent!=null)
                    {
                        parent.txt_ControlNeg.Text = selected;
                    }else if (parentChikHiper != null)
                    {
                        parentChikHiper.txt_ControlNeg.Text = selected;
                    }
                    
                        break;
                }
                case MainUtils.Controles.ControlesEI_CPlus:
                {
                    if (parentChik != null)
                    {
                        parentChik.txt_ControlPos.Text = selected;
                    }
                    else if(parent!=null)
                    {
                        parent.txt_ControlPos.Text = selected;
                    }else if(parentChikHiper!=null)
                    {
                        parentChikHiper.txt_ControlPos.Text = selected;
                    }
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
                case MainUtils.Controles.ControlesEI_CPlus:
                {
                    NuevoControlEI controlCPA = new NuevoControlEI(MainUtils.Controles.ControlesEI_CPlus);
                    DialogResult res = controlCPA.ShowDialog(this);
                    if (res == DialogResult.OK)
                    {
                        switchParam(param);
                        dgv_Controles.FirstDisplayedScrollingRowIndex = dgv_Controles.RowCount - 1;
                    }
                    break;
                }
                case MainUtils.Controles.ControlesEI_CMin:
                {
                    NuevoControlEI controlCPA = new NuevoControlEI(MainUtils.Controles.ControlesEI_CMin);
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


                    ControlesTrans.removeControl("EI", CodigoControl);
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
                controles_ei data = (controles_ei)gridrow.DataBoundItem;
                //MessageBox.Show(data.Cod_Asign_ContIgM + " ID: "+ updateId);
                ControlesTrans.updateControlEI(updateId, data);
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
