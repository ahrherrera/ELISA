using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Transaccion;

namespace ELISA.UI.UIParametros
{
    public partial class KitRotavirus : Form
    {
        string NuevoCodKit;
        private bool nuevo = false;
        private bool edit = false;
        private kit_elisa_rotaviru selectedKit = new kit_elisa_rotaviru();
        

        public KitRotavirus()
        {
            InitializeComponent();
            FillTable();
            normalStatus();
            dgv_masterKit.Rows[0].Selected = true;
            dgv_masterKit_CellClick(null,new DataGridViewCellEventArgs(0,0));

            for (int i = 0; i < KitELISATrans.TraerComponentes().Count; i++)
            {
                menu_Componentes.Items.Add(KitELISATrans.TraerComponentes()[i].Componente_Desc);
            }

            
        }

        private void FillTable()
        {
            KitELISATrans.LlenarCodigosKit(this.dgv_masterKit);
            
            //dgv_Componentes.Columns[0].DefaultCellStyle.BackColor = Color.DimGray;
            //dgv_Componentes.Columns[0].DefaultCellStyle.ForeColor = Color.Azure;
        }

        private void dgv_Componentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1 && e.ColumnIndex==0)
            {
                menu_Componentes.Show(MousePosition);
            }
        }

        public void editStatus()
        {
            btn_Save.Text = "Actualizar";
            btn_Save.Enabled = true;
            txt_Codigo.Enabled = false;
            btn_Cancelar.Enabled = true;
            btn_nuevo.Enabled = false;
            panel_Form.Enabled = true;
        }

        public void newStatus()
        {
            btn_Save.Text = "Guardar";
            txt_Codigo.Enabled = true;
            btn_Cancelar.Enabled = true;
            btn_nuevo.Enabled = false;
            panel_Form.Enabled = true;
        }

        public void normalStatus()
        {
            btn_Save.Enabled = false;
            btn_Save.Text = "Guardar";
            btn_nuevo.Text = "Nuevo";
            btn_nuevo.Enabled = true;
            btn_Cancelar.Enabled = false;
            panel_Form.Enabled = false;
        }

        public void clean()
        {
            txt_Lote.Text = "";
            txt_CasaComercial.Text = "";
            txt_Codigo.Text = "";
            txt_Metodo.Text = "";
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            newStatus();
            if (btn_nuevo.Text.Equals("Modificar"))
            {
                nuevo = false;
                edit = true;
                editStatus();
                txt_Codigo.Text = selectedKit.Codigo;
                txt_Lote.Text = selectedKit.Lote;
                txt_CasaComercial.Text = selectedKit.CasaComercial;
                txt_Metodo.Text = selectedKit.Metodo;
            }
            else
            {
                nuevo = true;
                edit = false;
                newStatus();
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!txt_Codigo.Text.Equals("") && !txt_Lote.Text.Equals("") && !txt_CasaComercial.Text.Equals("") && !txt_Metodo.Text.Equals(""))
            {
                if (nuevo)
                {
                    KitELISATrans.nuevoKit(txt_Codigo.Text, txt_Lote.Text, txt_CasaComercial.Text, txt_Metodo.Text);
                    new NuevoReactivo(txt_Codigo.Text).ShowDialog(this);
                    clean();
                    normalStatus();
                }
                else 
                if (edit)
                {
                    KitELISATrans.updateKit(selectedKit.Codigo, txt_Lote.Text, txt_CasaComercial.Text, txt_Metodo.Text);
                    clean();
                    normalStatus();
                }
            }
        }

        private void dgv_masterKit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex != -1 && dgv_masterKit.SelectedRows.Count>=1)
            {
                selectedKit.Codigo = dgv_masterKit.Rows[e.RowIndex].Cells[0].Value.ToString();
                selectedKit.Lote = dgv_masterKit.Rows[e.RowIndex].Cells[1].Value.ToString();
                selectedKit.CasaComercial = dgv_masterKit.Rows[e.RowIndex].Cells[2].Value.ToString();
                selectedKit.Metodo = dgv_masterKit.Rows[e.RowIndex].Cells[3].Value.ToString();

                KitELISATrans.LlenarTabla(dgv_Componentes, selectedKit.Codigo);
                dgv_Componentes.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
                btn_nuevo.Text = "Modificar";
            }
                
            
        }

        private void dgv_masterKit_MouseClick(object sender, MouseEventArgs e)
        {
            var ht = dgv_masterKit.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                btn_nuevo.Text = "Nuevo";
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            edit = false;
            nuevo = false;
            normalStatus();
            btn_nuevo.Text = "Nuevo";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
