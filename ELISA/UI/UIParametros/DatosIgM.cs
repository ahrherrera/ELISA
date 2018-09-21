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
    public partial class DatosIgM : Form
    {
        List<CheckBox> listaCheck = new List<CheckBox>();
        public DatosIgM()
        {
            InitializeComponent();
        }

        private void DatosIgM_Load(object sender, EventArgs e)
        {
            date_Fecha.Value = DateTime.Now;
            fillCombobox();
            fillFields();
            //Eventos
            this.txt_ControlPosBajo.Click += new System.EventHandler(this.txt_ControlPosBajo_Click);
            this.txt_ControlPosAlto.Click += new System.EventHandler(this.txt_ControlPosAlto_Click);
            addList();
        }

        private void addList()
        {
            listaCheck.Add(chk_ControlNeg);
            listaCheck.Add(chk_ANT);
            listaCheck.Add(chk_AntiGlobulina);
            listaCheck.Add(chk_Coatting);
            listaCheck.Add(chk_Conjug);
            listaCheck.Add(chk_ControlNegRadio);
            listaCheck.Add(chk_ControlPosAlto);
            listaCheck.Add(chk_ControlPosBajo);
            listaCheck.Add(chk_ControlPosRadio);
            listaCheck.Add(chk_Fecha);
            listaCheck.Add(chk_Fijacion);
            listaCheck.Add(chk_Volumen);
            listaCheck.Add(chk_TipoEstudio);
            listaCheck.Add(chk_Tipo);
            listaCheck.Add(chk_TiempoSubs);
            listaCheck.Add(chk_Temp);
            listaCheck.Add(chk_Tiempo);
            listaCheck.Add(chk_Stop);
            listaCheck.Add(chk_SUBST);
            listaCheck.Add(chk_SHN);
            listaCheck.Add(chk_ProcH2O);
            listaCheck.Add(chk_PB);
            listaCheck.Add(chk_LoteAsignado);
        }

        private void fillCombobox()
        {
            EstudioTrans.LlenarEstudio(cmb_TipoEstudio);
            ProcH2OTrans.LlenarProcH2O(cmb_ProcH2O);
        }

        private void fillFields()
        {
            //Llena los campos desde la tabla datosprotocoloigm
            datosprotocoloigm data = DatosProtocoloIgM.TraerDatosProtocoloIgM();
            txt_LoteIgM.Text = data.LoteIgM;
            txt_LoteAsignado.Text = data.GGLOB;
            if (data.fechafijGG != null) date_Fijacion.Value = data.fechafijGG.Value;
            if (data.VolUsado != null) txt_Volumen.Text = data.VolUsado.Value.ToString();
            cmb_TipoEstudio.SelectedIndex = cmb_TipoEstudio.FindString(data.TipoEstudio);
            cmb_ProcH2O.SelectedIndex = cmb_ProcH2O.FindString(data.ProcH2O);
            txt_Coatting.Text = data.Coatting;
            txt_PB.Text = data.PB;
            txt_Tipo.Text = data.TB;
            if (data.FB != null) date_Fecha.Value = data.FB.Value;
            txt_Temp.Text = data.TMPB.ToString();
            txt_Tiempo.Text = data.TIMEB;
            txt_ANT.Text = data.LoteAntigeno;
            txt_Conjug.Text = data.Conjugado;
            txt_SHN.Text = data.SHN;
            txt_STOP.Text = data.STOP;
            txt_SUBST.Text = data.Substrato;
            if (data.TSubstrato != null) txt_TiempoSubs.Text = data.TSubstrato.Value.ToString();
            txt_ControlPosAlto.Text = data.ControlPosA;
            txt_ControlPosBajo.Text = data.ControlPosB;
            txt_ControlNeg.Text = data.ControlNeg;
            txt_ControlNegLI.Text = data.ControlNegLI.ToString();
            txt_ControlNegLS.Text = data.ControlNegLS.ToString();
            txt_ControlPosRadio.Text = data.ControlRadPos;
            txt_ControlPosRadioLI.Text = data.ControlPosRadLI.ToString();
            txt_ControlPosRadioLS.Text = data.ControlPosRadLS.ToString();
            txt_ControlNegRadio.Text = data.ControlRadNeg;
            txt_ControlNegRadioLI.Text = data.ControlNegRadLI.ToString();
            txt_ControlNegRadioLS.Text = data.ControlNegRadLS.ToString();


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
            chk_ControlNeg.Checked = stat;
            chk_ANT.Checked = stat;
            chk_AntiGlobulina.Checked = stat;
            chk_Coatting.Checked = stat;
            chk_Conjug.Checked = stat;
            chk_ControlNegRadio.Checked = stat;
            chk_ControlPosAlto.Checked = stat;
            chk_ControlPosBajo.Checked = stat;
            chk_ControlPosRadio.Checked = stat;
            chk_Fecha.Checked = stat;
            chk_Fijacion.Checked = stat;
            chk_Volumen.Checked = stat;
            chk_TipoEstudio.Checked = stat;
            chk_Tipo.Checked = stat;
            chk_TiempoSubs.Checked = stat;
            chk_Temp.Checked = stat;
            chk_Tiempo.Checked = stat;
            chk_Stop.Checked = stat;
            chk_SUBST.Checked = stat;
            chk_SHN.Checked = stat;
            chk_ProcH2O.Checked = stat;
            chk_PB.Checked = stat;
            chk_LoteAsignado.Checked = stat;
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
                datosprotocoloigm nuevo = new datosprotocoloigm();
                nuevo.LoteIgM = txt_LoteIgM.Text;
                nuevo.GGLOB = txt_LoteAsignado.Text;
                nuevo.VolUsado = float.Parse(txt_Volumen.Text);
                estudio selectedestudio = (estudio) cmb_TipoEstudio.SelectedValue;
                nuevo.TipoEstudio = selectedestudio.Estudio1;
                proch20 seelctedProch20 = (proch20) cmb_ProcH2O.SelectedValue;
                nuevo.ProcH2O = seelctedProch20.ProcH201;
                nuevo.TB = txt_Tipo.Text;
                nuevo.TMPB = byte.Parse(txt_Temp.Text);
                nuevo.TIMEB = txt_Tiempo.Text;
                nuevo.PB = txt_PB.Text;
                nuevo.Coatting = txt_Coatting.Text;
                nuevo.LoteAntigeno = txt_ANT.Text;
                nuevo.SHN = txt_SHN.Text;
                nuevo.STOP = txt_STOP.Text;
                nuevo.Substrato = txt_SUBST.Text;
                nuevo.TSubstrato = float.Parse(txt_TiempoSubs.Text);
                nuevo.Conjugado = txt_Conjug.Text;
                nuevo.FB = date_Fecha.Value;
                nuevo.fechafijGG = date_Fijacion.Value;
                nuevo.ControlPosA = txt_ControlPosAlto.Text;
                nuevo.ControlPosB = txt_ControlPosBajo.Text;
                nuevo.ControlNeg = txt_ControlNeg.Text;
                nuevo.ControlNegLI = float.Parse(txt_ControlNegLI.Text);
                nuevo.ControlNegLS = float.Parse(txt_ControlNegLS.Text);
                nuevo.ControlNegRadLI = float.Parse(txt_ControlNegRadioLI.Text);
                nuevo.ControlRadPos = txt_ControlPosRadio.Text;
                nuevo.ControlPosRadLI = float.Parse(txt_ControlPosRadioLI.Text);
                nuevo.ControlPosRadLS = float.Parse(txt_ControlPosRadioLS.Text);
                nuevo.ControlRadNeg = txt_ControlNegRadio.Text;
                nuevo.ControlNegRadLS = float.Parse(txt_ControlNegRadioLS.Text);
                nuevo.ControlNegRadLI = float.Parse(txt_ControlNegRadioLI.Text);

                DatosProtocoloIgM.updateProtocoloIgM(nuevo);
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

        private void txt_ControlPosAlto_Click(object sender, EventArgs e)
        {
            DialogResult res = new ControlesIgM(MainUtils.Controles.ControlesIgM_CPA, this).ShowDialog(this);
        }

        private void txt_ControlPosBajo_Click(object sender, EventArgs e)
        {
            DialogResult res = new ControlesIgM(MainUtils.Controles.ControlesIgM_CPB, this).ShowDialog(this);
        }

        private void txt_ControlNeg_Click(object sender, EventArgs e)
        {
            DialogResult res = new ControlesIgM(MainUtils.Controles.ControlesIgM_C, this).ShowDialog(this);
        }

        private void txt_ControlPosRadio_Click(object sender, EventArgs e)
        {
            DialogResult res = new ControlesIgM(MainUtils.Controles.ControlesIgM_CRP, this).ShowDialog(this);
        }

        private void txt_ControlNegRadio_Click(object sender, EventArgs e)
        {
            DialogResult res = new ControlesIgM(MainUtils.Controles.ControlesIgM_CRN, this).ShowDialog(this);
        }

        private void txt_Coatting_Click(object sender, EventArgs e)
        {
            DialogResult res = new DatosCoatting(this.txt_Coatting).ShowDialog(this);
        }
    }
}
