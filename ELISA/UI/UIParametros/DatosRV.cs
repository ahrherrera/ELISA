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
using ELISA.Transaccion.DatosProtocoloTrans;
using ELISA.UI.UIParametros.Controles;
using ELISA.Utils;

namespace ELISA.UI.UIParametros
{
    public partial class DatosRV : Form
    {
        List<CheckBox> listaCheck = new List<CheckBox>();
        private datosprotocolorotaviru data;
        public DatosRV()
        {
            InitializeComponent();
        }

        private void DatosIgM_Load(object sender, EventArgs e)
        {
            fillCombobox();
            fillFields();
            addList();
        }

        private void addList()
        {
            listaCheck.Add(chk_ControlNeg);
            listaCheck.Add(chk_Codigo);
            listaCheck.Add(chk_ControlPos);
            listaCheck.Add(chk_ProcH2O);
            listaCheck.Add(chk_TiempoSubs);
        }

        private void fillCombobox()
        {
            KitELISATrans.LlenarComboboxKit(cmb_Codigo);
            ProcH2OTrans.LlenarProcH2O(cmb_ProcH2O);
        }

        private void fillFields()
        {
            //Llena los campos desde la tabla datosprotocoloigm
            data = DatosProtocoloRotavirus.TraerDatosprotocoloRotavirus();
            cmb_Codigo.SelectedIndex = cmb_Codigo.FindString(data.Codigo);
            cmb_ProcH2O.SelectedIndex = cmb_ProcH2O.FindString(data.ProcH2O);
            txt_TiempoSubs.Text = data.TIMES.ToString();
            txt_ControlNeg.Text = data.ControlNeg;
            txt_ControlPos.Text = data.ControlPos;
            txt_ControlNegLI.Text = data.ControlNegLI.ToString();
            txt_ControlNegLS.Text = data.ControlNegLS.ToString();
            txt_ControlPosLI.Text = data.ControlPosLI.ToString();
            txt_ControlPosLS.Text = data.ControlPosLS.ToString();


            if (Principal.ControlP)
            {
                Check(false);
            }
            else
            {
                Check(true);
            }
        }

        private void Check(bool stat)
        {
            chk_Codigo.Checked = stat;
            chk_ControlNeg.Checked = stat;
            chk_ControlPos.Checked = stat;
            chk_TiempoSubs.Checked = stat;
            chk_ProcH2O.Checked = stat;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            bool allchecked = true;
            //Guardar los parametros en la tabla ProtocoloIgM
            foreach (CheckBox checkBox in listaCheck)
            {
                if (!checkBox.Checked)
                {
                    allchecked = false;
                }
            }

            try
            {
                //Guardar los datos del protocolo
                datosprotocolorotaviru nuevo = new datosprotocolorotaviru();
                
                kit_elisa_rotaviru selectedKit = (kit_elisa_rotaviru) cmb_Codigo.SelectedValue;
                proch20 seelctedProch20 = (proch20) cmb_ProcH2O.SelectedValue;
                nuevo.ProcH2O = seelctedProch20.ProcH201;
                nuevo.Codigo = selectedKit.Codigo;
                nuevo.ControlNeg = txt_ControlNeg.Text;
                nuevo.ControlNegLI = float.Parse(txt_ControlNegLI.Text);
                nuevo.ControlNegLS = float.Parse(txt_ControlNegLS.Text);
                nuevo.ControlPos = txt_ControlPos.Text;
                nuevo.ControlPosLI = float.Parse(txt_ControlPosLI.Text);
                nuevo.ControlPosLS = float.Parse(txt_ControlPosLS.Text);

                DatosProtocoloRotavirus.updateProtocoloRV(nuevo);
                if (allchecked)
                {
                    Principal.invalid = false;
                }
                else
                {
                    Principal.invalid = true;
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Error en el formato de texto", "Error detectado");
                Log.logError("Error capturado: Trace: " + fex.StackTrace);
            }
        }

        private void txt_ControlPosRadio_Click(object sender, EventArgs e)
        {
            DialogResult res = new ControlesRV(MainUtils.Controles.ControlesRV_CP, this.txt_ControlPos).ShowDialog(this);
        }

        private void txt_ControlNegRadio_Click(object sender, EventArgs e)
        {
            DialogResult res = new ControlesRV(MainUtils.Controles.ControlesRV_CN, this.txt_ControlNeg).ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (new KitRotavirus().ShowDialog(this) == DialogResult.OK)
            {
                KitELISATrans.LlenarComboboxKit(cmb_Codigo);
                cmb_Codigo.SelectedIndex = cmb_Codigo.FindString(data.Codigo);
            }

            
        }
    }
}
