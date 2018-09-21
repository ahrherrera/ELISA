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
    public partial class DatosChikCNDR : Form
    {
        List<CheckBox> listaCheck = new List<CheckBox>();
        public DatosChikCNDR()
        {
            InitializeComponent();
        }

        private void DatosIgM_Load(object sender, EventArgs e)
        {
            date_Fecha.Value = DateTime.Now;
            fillCombobox();
            fillFields();
            addList();
        }

        private void addList()
        {
            listaCheck.Add(chk_ControlNeg);
            listaCheck.Add(chk_ANT);
            listaCheck.Add(chk_AntiGlobulina);
            listaCheck.Add(chk_Coatting);
            listaCheck.Add(chk_Conjug);
            listaCheck.Add(chk_ControlNeg);
            listaCheck.Add(chk_ControlPos);
            listaCheck.Add(chk_ControlNeg);
            listaCheck.Add(chk_ControlPos);
            listaCheck.Add(chk_Fecha);
            listaCheck.Add(chk_Fijacion);
            listaCheck.Add(chk_Volumen);
            listaCheck.Add(chk_FVC);
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
            ProcH2OTrans.LlenarProcH2O(cmb_ProcH2O);
        }

        private void fillFields()
        {
            //Llena los campos desde la tabla datosprotocoloigm
            datosprotocolochik data = DatosProtocoloChik.TraerDatosprotocoloChik();
            txt_LoteIgM.Text = data.LoteIgM;
            txt_LoteAsignado.Text = data.GGLOB;
            if (data.fechafijGG != null) date_Fijacion.Value = data.fechafijGG.Value;
            if (data.VolUsado != null) txt_Volumen.Text = data.VolUsado.Value.ToString();
            txt_fvc.Text = data.FVC.ToString();
            cmb_ProcH2O.SelectedIndex = cmb_ProcH2O.FindString(data.ProcH2O);
            txt_Coatting.Text = data.Coatting;
            txt_PB.Text = data.PB;
            txt_Tipo.Text = data.TB;
            if (data.FB != null) date_Fecha.Value = data.FB.Value;
            txt_Temp.Text = data.TMPB.ToString();
            txt_Tiempo.Text = data.TIMEB;
            txt_ANT.Text = data.LoteAntigenoViral;
            txt_Conjug.Text = data.Conjugado;
            txt_SHN.Text = data.SHN;
            txt_STOP.Text = data.STOP;
            txt_SUBST.Text = data.Substrato;
            if (data.TSubstrato != null) txt_TiempoSubs.Text = data.TSubstrato.Value.ToString();
            txt_ControlPos.Text = data.ControlPos;
            txt_ControlNeg.Text = data.ControlNeg;
            txt_LimCPI.Text = data.LimCPI.ToString();
            txt_LimCPS.Text = data.LimCPS.ToString();
            txt_LimCNI.Text = data.LimCNI.ToString();
            txt_LimCNS.Text = data.LimCNS.ToString();


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
            chk_ControlNeg.Checked = stat;
            chk_ControlPos.Checked = stat;
            chk_ControlNeg.Checked = stat;
            chk_ControlPos.Checked = stat;
            chk_Fecha.Checked = stat;
            chk_Fijacion.Checked = stat;
            chk_Volumen.Checked = stat;
            chk_FVC.Checked = stat;
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
                datosprotocolochik nuevo = new datosprotocolochik();
                nuevo.LoteIgM = txt_LoteIgM.Text;
                nuevo.GGLOB = txt_LoteAsignado.Text;
                nuevo.VolUsado = float.Parse(txt_Volumen.Text);
                proch20 seelctedProch20 = (proch20) cmb_ProcH2O.SelectedValue;
                nuevo.ProcH2O = seelctedProch20.ProcH201;
                nuevo.TB = txt_Tipo.Text;
                nuevo.FVC = float.Parse(txt_fvc.Text);
                nuevo.TMPB = byte.Parse(txt_Temp.Text);
                nuevo.TIMEB = txt_Tiempo.Text;
                nuevo.PB = txt_PB.Text;
                nuevo.Coatting = txt_Coatting.Text;
                nuevo.LoteAntigenoViral = txt_ANT.Text;
                nuevo.SHN = txt_SHN.Text;
                nuevo.STOP = txt_STOP.Text;
                nuevo.Substrato = txt_SUBST.Text;
                nuevo.TSubstrato = float.Parse(txt_TiempoSubs.Text);
                nuevo.Conjugado = txt_Conjug.Text;
                nuevo.FB = date_Fecha.Value;
                nuevo.fechafijGG = date_Fijacion.Value;
                nuevo.ControlPos = txt_ControlPos.Text;
                nuevo.ControlNeg = txt_ControlNeg.Text;
                nuevo.LimCNI = float.Parse(txt_LimCNI.Text);
                nuevo.LimCPI = float.Parse(txt_LimCPI.Text);
                nuevo.LimCPS = float.Parse(txt_LimCPS.Text);
                nuevo.LimCNS = float.Parse(txt_LimCNS.Text);

                
                if (allchecked)
                {
                    Principal.invalid = false;
                    DatosProtocoloChik.updateProtocoloChik(nuevo);
                }
                else
                {
                    MessageBox.Show("Debe revisar y marcar todas las casillas", "No ha marcado algunas casillas",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Principal.invalid = true;
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Error en el formato de texto", "Error detectado");
                Log.logError("Error capturado: Preparando update ProtocoloChik: " + fex.StackTrace);
            }
        }
    }
}
