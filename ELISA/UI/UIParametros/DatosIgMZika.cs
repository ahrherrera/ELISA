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
using ELISA.Utils;

namespace ELISA.UI.UIParametros
{
    public partial class DatosIgMZika : Form
    {
        List<CheckBox> listaCheck = new List<CheckBox>();
        public DatosIgMZika()
        {
            InitializeComponent();
        }

        private void DatosIgM_Load(object sender, EventArgs e)
        {
            date_Fecha.Value = DateTime.Now;
            fillCombobox();
            addList();
            fillFields();
        }

        private void addList()
        {
            listaCheck.Add(chk_ControlNeg);
            listaCheck.Add(chk_GOAT);
            listaCheck.Add(chk_Coatting);
            listaCheck.Add(chk_Conjug);
            listaCheck.Add(chk_ControlNegRadio);
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
            listaCheck.Add(chk_LoteAntigeno);
            listaCheck.Add(chk_FactorP);
            listaCheck.Add(chk_FactorS);
        }

        private void fillCombobox()
        {
            EstudioTrans.LlenarEstudio(cmb_TipoEstudio);
            ProcH2OTrans.LlenarProcH2O(cmb_ProcH2O);
        }

        private void fillFields()
        {
            //Llena los campos desde la tabla datosprotocoloigm
            datosprotocoloigmzika data = DatosProtocoloIgMZika.TraerDatosprotocoloigmzika();
            txt_LoteIgM.Text = data.LoteIgM;
            txt_LoteAntigeno.Text = data.LoteAntigeno;
            if (data.fechafijIGM != null) date_Fijacion.Value = data.fechafijIGM.Value;
            if (data.VolUsadoIGM != null) txt_Volumen.Text = data.VolUsadoIGM.Value.ToString();
            cmb_TipoEstudio.SelectedIndex = cmb_TipoEstudio.FindString(data.TipoEstudio);
            cmb_ProcH2O.SelectedIndex = cmb_ProcH2O.FindString(data.ProcH2O);
            txt_Coatting.Text = data.Coatting;
            txt_PB.Text = data.PB;
            txt_Tipo.Text = data.TB;
            if (data.FB != null) date_Fecha.Value = data.FB.Value;
            txt_Temp.Text = data.TMPB.ToString();
            txt_Tiempo.Text = data.TIMEB;
            txt_Conjug.Text = data.Conjugado;
            txt_SHN.Text = data.SHN;
            txt_STOP.Text = data.STOP;
            txt_SUBST.Text = data.Substrato;
            if (data.TSubstrato != null) txt_TiempoSubs.Text = data.TSubstrato.Value.ToString();
            txt_FactorP.Text = Convert.ToString(data.Factor);
            txt_FactorS.Text = Convert.ToString(data.Factor2);
            txt_ControlPos.Text = data.ControlPos;
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
            foreach (CheckBox checkBox in listaCheck)
            {
                checkBox.Checked = stat;
            }
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
                datosprotocoloigmzika nuevo = new datosprotocoloigmzika();
                nuevo.LoteIgM = txt_LoteIgM.Text;
                nuevo.LoteAntigeno = txt_LoteAntigeno.Text;
                nuevo.VolUsadoIGM = float.Parse(txt_Volumen.Text);
                estudio selectedestudio = (estudio) cmb_TipoEstudio.SelectedValue;
                nuevo.TipoEstudio = selectedestudio.Estudio1;
                proch20 seelctedProch20 = (proch20) cmb_ProcH2O.SelectedValue;
                nuevo.ProcH2O = seelctedProch20.ProcH201;
                nuevo.TB = txt_Tipo.Text;
                nuevo.TMPB = byte.Parse(txt_Temp.Text);
                nuevo.TIMEB = txt_Tiempo.Text;
                nuevo.PB = txt_PB.Text;
                nuevo.Coatting = txt_Coatting.Text;
                nuevo.SHN = txt_SHN.Text;
                nuevo.STOP = txt_STOP.Text;
                nuevo.Substrato = txt_SUBST.Text;
                nuevo.TSubstrato = float.Parse(txt_TiempoSubs.Text);
                nuevo.Conjugado = txt_Conjug.Text;
                nuevo.FB = date_Fecha.Value;
                nuevo.fechafijIGM = date_Fijacion.Value;
                nuevo.ControlPos = txt_ControlPos.Text;
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
                nuevo.Factor = float.Parse(txt_FactorP.Text);
                nuevo.Factor2 = float.Parse(txt_FactorS.Text);

                DatosProtocoloIgMZika.updateprotocoloIgMZika(nuevo);
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
    }
}
