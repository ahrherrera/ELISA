using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Transaccion;
using ELISA.Transaccion.DatosProtocoloTrans;
using ELISA.UI.Dialogs;
using ELISA.UI.UIParametros;
using ELISA.Utils;

namespace ELISA.UI
{
    public partial class Principal : Form
    {
        public static usuario user;
        public CheckBox cb = new CheckBox();
        public static Boolean ControlP = true;
        ErrorProvider ErrorProviderPlaca = new ErrorProvider();
        ErrorProvider ErrorProviderLab = new ErrorProvider();
        private Boolean restart = false;

        //Variables
        public int selectedTest = -1;
        public static Boolean invalid;

        public Single cpA;
        public Single cpB;
        public Single cn;
        public Single cpR;
        public Single cnR;
        public Single MxCP, MxCN, MxCNS, med3men, MxCNEI;

        public String [,] Unidades = new string[8,12];
        public String [,] Absorbancia = new string[8,12];
        public String [,] Resultados = new string[8,12];
        public String [,] Resultados1 = new string[8,12];

        public Principal(usuario logged)
        {
            InitializeComponent();
            user = logged;
            cmb_Equipo.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            InitialButtons();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Mostrar Mensaje de confirmacion
            if (!restart)
            {
                var dialogo = MessageBox.Show("¿Está seguro que desea Salir?",
                    "Salir",
                    MessageBoxButtons.YesNo);
                if (dialogo == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
            
        }

        public void InitialButtons()
        {
            btn_Leer.Enabled = false;
            btn_Save.Enabled = false;
            btn_Print.Enabled = false;
            btn_LoadProtocolo.Enabled = false;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Log.logInfo("Ventana principal Cargada correctamente");
            fillCombobox();
            fillComboLab();
            addCheckbox();
            setHeaders();
            timerClock.Enabled = true;
            btn_Print.Enabled = false;
        }

        private void setHeaders()
        {
            dgv_Protocolo.Rows.Add(8);
            int rowNumber = 0;
            foreach (DataGridViewRow row in dgv_Protocolo.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = MainUtils.rowHeaderNames()[rowNumber];
                rowNumber = rowNumber + 1;
            }
            dgv_Protocolo.AutoResizeRowHeadersWidth(
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);


        }

        private void addCheckbox()
        {
            cb.Text = "IgM";
            cb.Checked = true;
            cb.BackColor = Color.Transparent;
            ToolStripControlHost host = new ToolStripControlHost(cb);
            toolStrip1.Items.Insert(11, host);
        }

        private void fillComboLab()
        {
            cmb_Lab1.ComboBox.BeginInvoke(
                (Action) (() => { LaboratoristasTrans.LlenarLaboratoristas(cmb_Lab1.ComboBox); }
                ));
            cmb_Lab2.ComboBox.BeginInvoke((Action) (() =>
            {
                LaboratoristasTrans.LlenarLaboratoristas(cmb_Lab2.ComboBox);
            }));
        }

        private async Task fillCombobox()
        {
            //Llenar lista de test IgM
            List<String> IgMList = new List<string>();
            IgMList.Add("IgM Dengue");
            IgMList.Add("IgM Zika");
            IgMList.Add("IgM Zika Bei");
            IgMList.Add("Chikungunya CDC/CNDR");
            IgMList.Add("Chikungunya CNDR");
            cmb_IgM.DataSource = IgMList;
            //Llenar lista de test IgG
            List<String> IgGList = new List<string>();
            IgGList.Add("Saliva CIET");
            IgGList.Add("Saliva CIET Repeticiones");
            cmb_IgG.DataSource = IgGList;
            List<String> EIList = new List<string>();
            EIList.Add("ELISA INH Monoclonal Chik");
            EIList.Add("ELISA INH Hiperinmune Chik");
            EIList.Add("ELISA INH Ensayos");
            EIList.Add("ELISA INH R and M");
            EIList.Add("ELISA INH Zika");
            cmb_EI.DataSource = EIList;
            //Llenar lista de test BOB
            List<String> BOBList = new List<string>();
            BOBList.Add("Zika BOB");
            BOBList.Add("Zika BOB Cohorte Anual");
            BOBList.Add("Zika BOB Cohorte Anual Dup");
            BOBList.Add("Zika BOB Coh Anual/Sero 1 m");
            cmb_BOB.DataSource = BOBList;
            //Llenar lista de test 1D
            List<String> OneDList = new List<string>();
            OneDList.Add("ELISA 1D Cohorte Anual");
            OneDList.Add("ELISA 1D Cohorte Anual Dup");
            OneDList.Add("ELISA 1D Cohorte Anual Chik");
            OneDList.Add("ELISA 1D Cohorte Anual Chik Dup");
            OneDList.Add("ELISA 1D Seroprevalencia Chik");
            OneDList.Add("ELISA 1D Seroprevalencia Chik Dup");
            OneDList.Add("Zika 1D Cohorte Anual");
            OneDList.Add("Zika 1D Cohorte Anual Dup");
            cmb_1D.DataSource = OneDList;
            //Llenar lista de test RM
            List<String> RMList = new List<string>();
            RMList.Add("R and M Cohorte Anual");
            RMList.Add("R and M Cohorte Anual Dup");
            RMList.Add("ELISA RM Cohorte Anual Chik");
            RMList.Add("ELISA RM Cohorte Anual Chik Dup");
            RMList.Add("ELISA RM Seroprevalencia Chik");
            RMList.Add("ELISA RM Seroprevalencia Chik Dup");
            RMList.Add("ZIKA RM Cohorte Anual");
            RMList.Add("ZIKA RM Cohorte Anual Dup");
            cmb_RM.DataSource = RMList;

            cmb_IgM.SelectedIndexChanged += cmb_Protocolo_SelectedIndexChanged;
            cmb_EI.SelectedIndexChanged += cmb_Protocolo_SelectedIndexChanged;
            cmb_BOB.SelectedIndexChanged += cmb_Protocolo_SelectedIndexChanged;
            cmb_IgG.SelectedIndexChanged += cmb_Protocolo_SelectedIndexChanged;
            cmb_1D.SelectedIndexChanged += cmb_Protocolo_SelectedIndexChanged;
            cmb_RM.SelectedIndexChanged += cmb_Protocolo_SelectedIndexChanged;

            //Llena la lista de Equipos
            List<String> EquipoList = new List<string>();
            EquipoList.Add("MULTISKAN EX"); //0
            EquipoList.Add("MULTISKAN FC"); //1
            cmb_Equipo.ComboBox.DataSource = EquipoList;

            rb_Rotavirus.Checked = true;
            rb_IgM.Checked = true;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton send = (RadioButton) sender;

            if (send.Checked)
            {
                if (send.Text.Contains("IgM"))
                {
                    cmb_IgM.Enabled = true;
                    cmb_EI.Enabled = false;
                    cmb_BOB.Enabled = false;
                    cmb_IgG.Enabled = false;
                    cmb_1D.Enabled = false;
                    cmb_RM.Enabled = false;
                    cmb_Protocolo_SelectedIndexChanged(null, EventArgs.Empty);
                }
                else if (send.Text.Contains("EI"))
                {
                    cmb_IgM.Enabled = false;
                    cmb_EI.Enabled = true;
                    cmb_BOB.Enabled = false;
                    cmb_IgG.Enabled = false;
                    cmb_1D.Enabled = false;
                    cmb_RM.Enabled = false;
                    cmb_Protocolo_SelectedIndexChanged(null, EventArgs.Empty);
                }
                else if (send.Text.Contains("BOB"))
                {
                    cmb_IgM.Enabled = false;
                    cmb_EI.Enabled = false;
                    cmb_BOB.Enabled = true;
                    cmb_IgG.Enabled = false;
                    cmb_1D.Enabled = false;
                    cmb_RM.Enabled = false;
                    cmb_Protocolo_SelectedIndexChanged(null, EventArgs.Empty);
                }
                else if (send.Text.Contains("IgG"))
                {
                    cmb_IgM.Enabled = false;
                    cmb_EI.Enabled = false;
                    cmb_BOB.Enabled = false;
                    cmb_IgG.Enabled = true;
                    cmb_1D.Enabled = false;
                    cmb_RM.Enabled = false;
                    cmb_Protocolo_SelectedIndexChanged(null, EventArgs.Empty);
                }
                else if (send.Text.Contains("1D"))
                {
                    cmb_IgM.Enabled = false;
                    cmb_EI.Enabled = false;
                    cmb_BOB.Enabled = false;
                    cmb_IgG.Enabled = false;
                    cmb_1D.Enabled = true;
                    cmb_RM.Enabled = false;
                    cmb_Protocolo_SelectedIndexChanged(null, EventArgs.Empty);
                }
                else if (send.Text.Contains("RM"))
                {
                    cmb_IgM.Enabled = false;
                    cmb_EI.Enabled = false;
                    cmb_BOB.Enabled = false;
                    cmb_IgG.Enabled = false;
                    cmb_1D.Enabled = false;
                    cmb_RM.Enabled = true;
                    cmb_Protocolo_SelectedIndexChanged(null, EventArgs.Empty);
                }
                else //Rotavirus
                {
                    cmb_IgM.Enabled = false;
                    cmb_EI.Enabled = false;
                    cmb_BOB.Enabled = false;
                    cmb_IgG.Enabled = false;
                    cmb_1D.Enabled = false;
                    cmb_RM.Enabled = false;
                    groupProtocol.Text = "Protocolo Rotavirus";
                    SetOpcionesRv();
                    cmb_Protocolo_SelectedIndexChanged(null, EventArgs.Empty);
                    SelectTest(MainUtils.Test.Rotavirus);
                }
            }
        }

        private void SelectTest(MainUtils.Test prueba)
        {
            selectedTest = (int) prueba;
        }

        private void btnProtocolo_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btnProtocolo, new Point(0, btnProtocolo.Height));
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lbl_Time.Text = "  " +DateTime.Now.ToString("F",
                CultureInfo.CreateSpecificCulture("es-MX"));
        }

        private void cmb_IgM_EnabledChanged(object sender, EventArgs e)
        {
            if (cmb_IgM.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_IgM.SelectedItem.ToString();
                cmb_Protocolo_SelectedIndexChanged(null, EventArgs.Empty);
            }
        }

        private void cmb_EI_EnabledChanged(object sender, EventArgs e)
        {
            if (cmb_EI.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_EI.SelectedItem.ToString();
                groupValidar.Text = "Validación " + cmb_EI.SelectedItem.ToString();
                cmb_Protocolo_SelectedIndexChanged(null, EventArgs.Empty);
            }
        }

        private void cmb_BOB_EnabledChanged(object sender, EventArgs e)
        {
            if (cmb_BOB.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_BOB.SelectedItem.ToString();
                groupValidar.Text = "Validación " + cmb_BOB.SelectedItem.ToString();
                cmb_Protocolo_SelectedIndexChanged(null, EventArgs.Empty);
            }
        }

        private void cmb_IgG_EnabledChanged(object sender, EventArgs e)
        {
            if (cmb_IgG.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_IgG.SelectedItem.ToString();
                groupValidar.Text = "Validación " + cmb_IgG.SelectedItem.ToString();
                cmb_Protocolo_SelectedIndexChanged(null, EventArgs.Empty);
            }
        }

        private void cmb_1D_EnabledChanged(object sender, EventArgs e)
        {
            if (cmb_1D.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_1D.SelectedItem.ToString();
                groupValidar.Text = "Validación " + cmb_1D.SelectedItem.ToString();
                cmb_Protocolo_SelectedIndexChanged(null, EventArgs.Empty);
            }
            
        }

        private void cmb_RM_EnabledChanged(object sender, EventArgs e)
        {
            if (cmb_RM.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_RM.SelectedItem.ToString();
                groupValidar.Text = "Validación " + cmb_RM.SelectedItem.ToString();
                cmb_Protocolo_SelectedIndexChanged(null, EventArgs.Empty);
            }
        }

        private void cmb_Protocolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_val1.Visible = true;
            txt_val2.Visible = true;
            txt_val3.Visible = true;
            txt_val4.Visible = true;
            txt_val5.Visible = true;
            txt_val6.Visible = true;
            txt_val7.Visible = true;
            lbl_val1.Text = "";
            lbl_val2.Text = "";
            lbl_val3.Text = "";
            lbl_val4.Text = "";
            lbl_val5.Text = "";
            lbl_val6.Text = "";
            lbl_val7.Text = "";
            //TODO Aca colocar lo label de Resultados
            if (cmb_EI.Enabled) 
            {
                groupProtocol.Text = "Protocolo " + cmb_EI.SelectedItem.ToString();
                groupValidar.Text = "Validación " + cmb_EI.SelectedItem.ToString();
                string selectedItem = cmb_EI.SelectedItem.ToString();

                lbl_val1.Text = "Valor de Corte: ";
                lbl_val2.Text = "Media de los controles positivos: ";
                lbl_val3.Text = "Media de los controles negativos: ";
                txt_val4.Visible = false;
                txt_val5.Visible = false;
                txt_val6.Visible = false;
                txt_val7.Visible = false;

                if (selectedItem.Equals("ELISA INH Monoclonal Chik"))
                {
                    SetOpcionesRm();
                    SelectTest(MainUtils.Test.ELISAINHMonoChik);
                }else if (selectedItem.Equals("ELISA INH Hiperinmune Chik"))
                {
                    SelectTest(MainUtils.Test.ELISAINHHiperChik);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("ELISA INH Ensayos"))
                {
                    SelectTest(MainUtils.Test.ELISAINHEnsa);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("ELISA INH R and M"))
                {
                    SelectTest(MainUtils.Test.ELISAINHRM);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("ELISA INH Zika"))
                {
                    SelectTest(MainUtils.Test.ELISAINHZika);
                    SetOpcionesRm();
                }

            }
            if (cmb_IgM.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_IgM.SelectedItem.ToString();
                groupValidar.Text = "Validación " + cmb_IgM.SelectedItem.ToString();
                string selectedItem = cmb_IgM.SelectedItem.ToString();
                if (selectedItem.Equals("IgM Dengue"))
                {
                    lbl_val1.Text = "VC :";
                    lbl_val2.Text = "Media CPR :";
                    lbl_val3.Text = "Media CNR :";
                    lbl_val4.Text = "CPA :";
                    lbl_val5.Text = "CPB :";
                    lbl_val6.Text = "Media CN :";
                    lbl_val7.Text = "Validación :";
                    SelectTest(MainUtils.Test.IgMDengue);
                    SetOpcionesOptIgM();
                    btn_LoadProtocolo.Enabled = false;
                }else if (selectedItem.Equals("IgM Zika"))
                {
                    SelectTest(MainUtils.Test.IgMZika);
                    lbl_val1.Text = "VC Factor 1:";
                    lbl_val2.Text = "VC Factor 2:";
                    lbl_val3.Text = "Media CPR:";
                    lbl_val4.Text = "Media CNR:";
                    lbl_val5.Text = "Media CP :";
                    lbl_val6.Text = "Media CN :";
                    lbl_val7.Text = "Validación :";
                    SetOpcionesIgMZika();
                    btn_LoadProtocolo.Enabled = false;
                }else if (selectedItem.Equals("IgM Zika Bei"))
                {
                    SelectTest(MainUtils.Test.IgMZikaBei);
                    lbl_val1.Text = "Suero Control Negativo Humano DDO < 0.2";
                    lbl_val2.Text = "Suero Control Positivo IgM Humano anti-Zika DDO > 0.8";
                    txt_val3.Visible = false;
                    txt_val4.Visible = false;
                    txt_val5.Visible = false;
                    txt_val6.Visible = false;
                    txt_val7.Visible = false;
                    SetOpcionesIgMZikaBei();
                    btn_LoadProtocolo.Enabled = false;
                }else if (selectedItem.Equals("Chikungunya CDC/CNDR"))
                {
                    SelectTest(MainUtils.Test.ChinkungunyaCDCCNDR);
                    SetOpcionesChikCndr();
                }else if (selectedItem.Equals("Chikungunya CNDR"))
                {
                    SelectTest(MainUtils.Test.ChinkungunyaCNDR);
                    SetOpcionesChik();
                }
            }
            if (cmb_BOB.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_BOB.SelectedItem.ToString();
                groupValidar.Text = "Validación " + cmb_BOB.SelectedItem.ToString();
                string selectedItem = cmb_BOB.SelectedItem.ToString();

                if (selectedItem.Equals("Zika BOB"))
                {
                    SelectTest(MainUtils.Test.ZikaBOB);
                    SetOpcionesZikaBob();
                }else if (selectedItem.Equals("Zika BOB Cohorte Anual"))
                {
                    SelectTest(MainUtils.Test.ZikaBOBCohAnual);
                    SetOpcionesZikaBob();
                }else if (selectedItem.Equals("Zika BOB Cohorte Anual Dup"))
                {
                    SelectTest(MainUtils.Test.ZikaBOBCohAnualDup);
                    SetOpcionesZikaBob();
                }else if (selectedItem.Equals("Zika BOB Coh Anual/Sero 1 m"))
                {
                    SelectTest(MainUtils.Test.ZikaBOBCohAnualSero);
                    SetOpcionesZikaBob();
                }
            }
            if (cmb_IgG.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_IgG.SelectedItem.ToString();
                groupValidar.Text = "Validación " + cmb_IgG.SelectedItem.ToString();
                string selectedItem = cmb_IgG.SelectedItem.ToString();
                if (selectedItem.Equals("Saliva CIET"))
                {
                    SelectTest(MainUtils.Test.SalivaCIET);
                    lbl_val1.Text = "Media de los C- de Saliva: ";
                    lbl_val2.Text = "Media de los Controles Positivos: ";
                    lbl_val3.Text = "Media de los Controles Negativos: ";
                    lbl_val4.Text = "Media de las 3 DO mas bajas: ";
                    lbl_val5.Text = "";
                    lbl_val6.Text = "";
                    lbl_val7.Text = "";
                    txt_val5.Visible = false;
                    txt_val6.Visible = false;
                    txt_val7.Visible = false;
                    SetOpcionesOptIgG();
                }else if (selectedItem.Equals("Saliva CIET Repeticiones"))
                {
                    SelectTest(MainUtils.Test.SalivaCIETRep);
                    SetOpcionesOptIgG();
                }
            }
            if (cmb_1D.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_1D.SelectedItem.ToString();
                groupValidar.Text = "Validación " + cmb_1D.SelectedItem.ToString();
                string selectedItem = cmb_1D.SelectedItem.ToString();

                if (selectedItem.Equals("ELISA 1D Cohorte Anual"))
                {
                    SelectTest(MainUtils.Test.ELISA1DCohAnual);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("ELISA 1D Cohorte Anual Dup"))
                {
                    SelectTest(MainUtils.Test.ELISA1DCohAnualDup);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("ELISA 1D Cohorte Anual Chik"))
                {
                    SelectTest(MainUtils.Test.ELISA1DCohAnualChik);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("ELISA 1D Cohorte Anual Chik Dup"))
                {
                    SelectTest(MainUtils.Test.ELISA1DCohAnualChikDup);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("ELISA 1D Seroprevalencia Chik"))
                {
                    SelectTest(MainUtils.Test.ELISA1DSeroChik);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("ELISA 1D Seroprevalencia Chik Dup"))
                {
                    SelectTest(MainUtils.Test.ELISA1DSeroChikDup);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("Zika 1D Cohorte Anual"))
                {
                    SelectTest(MainUtils.Test.Zika1DCohAnual);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("Zika 1D Cohorte Anual Dup"))
                {
                    SelectTest(MainUtils.Test.Zika1DCohAnualDup);
                    SetOpcionesRm();
                }

            }
            if (cmb_RM.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_RM.SelectedItem.ToString();
                groupValidar.Text = "Validación " + cmb_RM.SelectedItem.ToString();
                string selectedItem = cmb_RM.SelectedItem.ToString();

                if (selectedItem.Equals("R and M Cohorte Anual"))
                {
                    SelectTest(MainUtils.Test.RMCohAnual);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("R and M Cohorte Anual Dup"))
                {
                    SelectTest(MainUtils.Test.RMCohAnualDup);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("ELISA RM Cohorte Anual Chik"))
                {
                    SelectTest(MainUtils.Test.ELISARMCohAnualChik);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("ELISA RM Cohorte Anual Chik Dup"))
                {
                    SelectTest(MainUtils.Test.ELISARMCohAnualChikDup);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("ELISA RM Seroprevalencia Chik"))
                {
                    SelectTest(MainUtils.Test.ELISARMSeroChik);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("ELISA RM Seroprevalncia Chik Dup"))
                {
                    SelectTest(MainUtils.Test.ELISARMSeroChikDup);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("ZIKA RM Cohorte Anual"))
                {
                    SelectTest(MainUtils.Test.ZIKARMCohAnual);
                    SetOpcionesRm();
                }else if (selectedItem.Equals("ZIKA RM Cohorte Anual Dup"))
                {
                    SelectTest(MainUtils.Test.ZIKARMCohAnualDup);
                    SetOpcionesRm();
                }
            }
        }

        private void SetOpcionesZikaBob()
        {
            rb_Opt7.Visible = false;
            rb_Opt6.Visible = false;
            rb_Opt5.Visible = false;
            rb_Opt4.Visible = true;
            rb_Opt3.Visible = true;
            rb_opt2.Visible = true;
            rb_Opt1.Visible = true;
            rb_Opt4.Text = "Muestra";
            rb_Opt4.Checked = true;
            rb_Opt3.Text = "Control Máximo";
            rb_opt2.Text = "Control Mínimo";
            rb_Opt1.Text = "Sin Muestra";
        }

        private void SetOpcionesIgMZikaBei()
        {
            rb_Opt7.Visible = false;
            rb_Opt6.Visible = false;
            rb_Opt5.Visible = false;
            rb_Opt4.Visible = true;
            rb_Opt3.Visible = true;
            rb_opt2.Visible = true;
            rb_Opt1.Visible = true;
            rb_Opt4.Text = "Muestra";
            rb_Opt4.Checked = true;
            rb_Opt3.Text = "Control Positivo";
            rb_opt2.Text = "Control Negativo";
            rb_Opt1.Text = "Quitar";
        }

        private void SetOpcionesIgMZika()
        {
            rb_Opt7.Visible = false;
            rb_Opt6.Visible = true;
            rb_Opt5.Visible = true;
            rb_Opt4.Visible = true;
            rb_Opt3.Visible = true;
            rb_opt2.Visible = true;
            rb_Opt1.Visible = true;
            rb_Opt6.Text = "Editar";
            rb_Opt6.Checked = true;
            rb_Opt5.Text = "Control Positivo";
            rb_Opt4.Text = "Control Negativo";
            rb_Opt3.Text = "C+ Radio";
            rb_opt2.Text = "C- Radio";
            rb_Opt1.Text = "S/ Muestra";
        }

        private void SetOpcionesOptIgM()
        {
            rb_Opt7.Visible = true;
            rb_Opt6.Visible = true;
            rb_Opt5.Visible = true;
            rb_Opt4.Visible = true;
            rb_Opt3.Visible = true;
            rb_opt2.Visible = true;
            rb_Opt1.Visible = true;
            rb_Opt7.Text = "Editar";
            rb_Opt7.Checked = true;
            rb_Opt6.Text = "Control + Alto";
            rb_Opt5.Text = "Control + Bajo";
            rb_Opt4.Text = "Control Negativo";
            rb_Opt3.Text = "C+ Radio";
            rb_opt2.Text = "C- Radio";
            rb_Opt1.Text = "S/Muestra";
        }

        private void SetOpcionesChik()
        {
            rb_Opt7.Visible = false;
            rb_Opt6.Visible = false;
            rb_Opt5.Visible = true;
            rb_Opt4.Visible = true;
            rb_Opt3.Visible = true;
            rb_opt2.Visible = true;
            rb_Opt1.Visible = true;
            rb_Opt5.Text = "Editar";
            rb_Opt5.Checked = true;
            rb_Opt4.Text = "Muestra";
            rb_Opt3.Text = "Control Positivo";
            rb_opt2.Text = "Control Negativo";
            rb_Opt1.Text = "S/Muestra";
        }

        private void SetOpcionesChikCndr()
        {
            rb_Opt7.Visible = false;
            rb_Opt6.Visible = false;
            rb_Opt5.Visible = false;
            rb_Opt4.Visible = true;
            rb_Opt3.Visible = true;
            rb_opt2.Visible = true;
            rb_Opt1.Visible = true;
            rb_Opt4.Text = "Editar";
            rb_Opt4.Checked = true;
            rb_Opt3.Text = "Control Positivo";
            rb_opt2.Text = "Control Negativo";
            rb_Opt1.Text = "S/Muestra";
        }

        private void SetOpcionesRv()
        {
            rb_Opt7.Visible = false;
            rb_Opt6.Visible = false;
            rb_Opt5.Visible = true;
            rb_Opt4.Visible = true;
            rb_Opt3.Visible = true;
            rb_opt2.Visible = true;
            rb_Opt1.Visible = true;
            rb_Opt5.Text = "Editar";
            rb_Opt5.Checked = true;
            rb_Opt4.Text = "Control Muestra";
            rb_Opt3.Text = "Control Positivo";
            rb_opt2.Text = "Control Negativo";
            rb_Opt1.Text = "S/Muestra";
        }

        private void SetOpcionesRm()
        {
            rb_Opt7.Visible = false;
            rb_Opt6.Visible = false;
            rb_Opt5.Visible = true;
            rb_Opt4.Visible = true;
            rb_Opt3.Visible = true;
            rb_opt2.Visible = true;
            rb_Opt1.Visible = true;
            rb_Opt5.Text = "Editar";
            rb_Opt5.Checked = true;
            rb_Opt4.Text = "Muestra";
            rb_Opt3.Text = "Control Positivo";
            rb_opt2.Text = "Control Negativo";
            rb_Opt1.Text = "S/Muestra";
        }

        private void SetOpcionesOptIgG()
        {
            rb_Opt7.Visible = false;
            rb_Opt6.Visible = false;
            rb_Opt5.Visible = true;
            rb_Opt4.Visible = true;
            rb_Opt3.Visible = true;
            rb_opt2.Visible = true;
            rb_Opt1.Visible = true;
            rb_Opt5.Text = "Editar";
            rb_Opt4.Checked = true;
            rb_Opt4.Text = "Control Suero Positivo";
            rb_Opt3.Text = "Control Suero Negativo";
            rb_opt2.Text = "Control Negativo Saliva";
            rb_Opt1.Text = "S/Muestra";
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal_FormClosing(null, new FormClosingEventArgs(CloseReason.UserClosing, true));
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Placa.Text.Equals(""))
            {
                Task.Run(() =>
                {
                    MessageBox.Show("Ingrese el número de la placa", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                });
               
                ErrorProviderPlaca.SetError(txt_Placa.TextBox, "Debe escribir el número de placa");
            }else if (!cmb_Lab1.Text.Equals(""))
            {
                //verificar la validez del laboratorista
                if (cmb_Lab1.SelectedIndex!=-1)
                {
                    Guardar();
                }
                else
                {
                    Task.Run(() => { MessageBox.Show("Seleccione un laboratorista válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); });
                    
                    ErrorProviderLab.SetError(cmb_Lab1.ComboBox, "Seleccione o escriba el número de Laboratorista");
                }

            }
            else
            {
                Task.Run(() =>
                {
                    MessageBox.Show("Seleccione un laboratorista", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                });
                ErrorProviderLab.SetError(cmb_Lab1.ComboBox, "Seleccione o escriba el número de Laboratorista");
            }
        }

        private void Guardar()
        {
            //TODO Guardar datos
            //Pasa los datos contenidos en la tabla a un arreglo multidimensional
            String [,] protocolo = new String[dgv_Protocolo.RowCount,dgv_Protocolo.ColumnCount];
            String[,] lectura = new String[dgv_Lectura.RowCount, dgv_Lectura.ColumnCount];
            for (int k = 0; k < 8; k++)
            {
                for (int i = 0; i < 12; i++)
                {
                    protocolo[k, i] = dgv_Protocolo.Rows[k].Cells[i].Value.ToString();
                    lectura[k, i] = dgv_Lectura.Rows[k].Cells[i].Value.ToString();
                }
            }
            switch (selectedTest)
            {
                case 5:
                    {
                        //GuardarIgG
                        
                        break;
                    }
                case 6:
                    {
                        //GuardarIgG
                        break;
                    }
                case 0:
                    {
                        ControlP = false;
                        //GuardarIgM Dengue
                        if (new DatosIgM().ShowDialog(this) == DialogResult.OK)
                        {
                            Single lectData;
                            String und;
                            String res;
                            datosprotocoloigm datos = DatosProtocoloIgM.TraerDatosProtocoloIgM();
                            int cont = 1;
                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 12; j++)
                                {
                                    elisaigm newIgM = new elisaigm();
                                    newIgM.Cod_Pozo = protocolo[i,j];
                                    newIgM.posicion = Convert.ToByte(cont++);
                                    if (lectura[i,j].EndsWith(Convert.ToString((char)8203)))
                                    {
                                        lectData = Single.Parse(lectura[i, j].Remove(lectura[i, j].Length - 1));
                                    }
                                    else
                                    {
                                        lectData = Single.Parse(lectura[i, j]);
                                    }

                                    newIgM.Lectura = lectData;
                                    if (cb.Checked && !invalid)
                                    {
                                        und = (((lectData - cnR) / (cpR - cnR)) * 100).ToString("0.00");
                                        Single par = (((lectData - cnR) / (cpR - cnR)) * 100);
                                    }
                                    else
                                        und = "NA";

                                    if (invalid)
                                        und = "INV";
                                    newIgM.Unidades = und;
                                    Unidades[i, j] = und;
                                    Absorbancia[i, j] = Convert.ToString(lectData);

                                    if (lectData >= float.Parse(txt_val1.Text) && !invalid)
                                    {
                                        res = "P";
                                    }
                                    else
                                    {
                                        res = "N";
                                    }

                                    if (invalid)
                                    {
                                        res = "INV";
                                    }
                                    newIgM.VC = Single.Parse(Single.Parse(txt_val1.Text).ToString("0.000"));
                                    newIgM.Resultado = res;
                                    Resultados[i, j] = res;
                                    newIgM.Placa = txt_Placa.TextBox.Text;
                                    if (invalid)
                                    {
                                        newIgM.Valido = false;
                                    }
                                    else
                                    {
                                        if (lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                                        {
                                            newIgM.Valido = false;
                                        }
                                        else
                                            newIgM.Valido = true;

                                    }

                                    newIgM.Fecha = DateTime.Now;
                                    newIgM.ControlPosA = datos.ControlPosA;
                                    newIgM.ControlPosB = datos.ControlPosB;
                                    newIgM.ControlNeg = datos.ControlNeg;
                                    newIgM.ControlRadPos = datos.ControlRadPos;
                                    newIgM.ControlRadNeg = datos.ControlRadNeg;
                                    newIgM.LoteIgM = datos.LoteIgM;
                                    newIgM.LoteAntigeno = datos.LoteAntigeno;
                                    newIgM.GGLOB = datos.GGLOB;
                                    newIgM.fechafijGG = datos.fechafijGG;
                                    newIgM.VolUsado = datos.VolUsado;
                                    newIgM.ProcH2O = datos.ProcH2O;
                                    newIgM.TipoEstudio = datos.TipoEstudio;
                                    newIgM.Coatting = datos.Coatting;
                                    newIgM.PB = datos.PB;
                                    newIgM.TB = datos.TB;
                                    newIgM.FB = datos.FB;
                                    newIgM.TMPB = datos.TMPB;
                                    newIgM.TIMEB = datos.TIMEB;
                                    newIgM.Substrato = datos.Substrato;
                                    newIgM.TSubstrato = datos.TSubstrato;
                                    newIgM.Conjugado = datos.Conjugado;
                                    newIgM.SHN = datos.SHN;
                                    newIgM.STOP = datos.STOP;
                                    newIgM.Lab1 = cmb_Lab1.ComboBox.Text;
                                    newIgM.Lab2 = cmb_Lab2.ComboBox.Text;
                                    newIgM.User = Convert.ToString(user.idUsuario);
                                    ElisaIGMTrans.saveElisaIGM(newIgM);
                                    btn_Print.Enabled = true;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Verifique los datos del protocolo en el menu principal",
                                "Verifique sus datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }
                case 10:
                    {
                        ControlP = false;
                        //GuardarEI2
                        break;
                    }
                case 7:
                    {
                        ControlP = false;
                        //GuardarEI2
                        break;
                    }
                case 8:
                    {
                        ControlP = false;
                        //GuardarEI2
                        break;
                    }
                case 9:
                    {
                        ControlP = false;
                        //GuardarEI2
                        break;
                    }
                case 26:
                    {
                        ControlP = false;
                        //GuardarEI2
                        break;
                    }
                case 27:
                    {
                        ControlP = false;
                        //GuardarEI2
                        break;
                    }
                case 28:
                    {
                        ControlP = false;
                        //GuardarEI2
                        break;
                    }
                case 29:
                    {
                        ControlP = false;
                        //GuardarEI2
                        break;
                    }
                case 11:
                    {
                        ControlP = false;
                        //GuardarEI2
                        break;
                    }
                case 30:
                    {
                        ControlP = false;
                        //GuardarEI2
                        break;
                    }
                case 31:
                    {
                        ControlP = false;
                        //GuardarEI2
                        break;
                    }
                case 16:
                    {
                        ControlP = false;
                        //GuardarEI1D
                        break;
                    }
                case 17:
                    {
                        ControlP = false;
                        //GuardarEI1D
                        break;
                    }
                case 18:
                    {
                        ControlP = false;
                        //GuardarEI1D
                        break;
                    }
                case 19:
                    {
                        ControlP = false;
                        //GuardarEI1D
                        break;
                    }
                case 20:
                    {
                        ControlP = false;
                        //GuardarEI1D
                        break;
                    }
                case 21:
                    {
                        ControlP = false;
                        //GuardarEI1D
                        break;
                    }
                case 22:
                    {
                        ControlP = false;
                        //GuardarEI1D
                        break;
                    }
                case 23:
                    {
                        ControlP = false;
                        //GuardarEI1D
                        break;
                    }
                case 24:
                    {
                        ControlP = false;
                        //GuardarEIPDVI
                        break;
                    }
                case 25:
                    {
                        ControlP = false;
                        //GuardarEIPPDVIDup
                        break;
                    }
                case 32:
                    {
                        ControlP = false;
                        //GuardarRV
                        break;
                    }
                case 3:
                    {
                        //GuardarChik
                        break;
                    }
                case 4:
                    {
                        //GuardarChikCNDR
                        break;
                    }
                case 1:
                    {
                        ControlP = false;
                        if (new DatosIgMZika().ShowDialog(this) == DialogResult.OK)
                        {
                            Single lectData;
                            String und, res, res1;
                            datosprotocoloigmzika datos = DatosProtocoloIgMZika.TraerDatosprotocoloigmzika();
                            int cont = 1;
                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 12; j++)
                                {
                                    zikaigm newIgM = new zikaigm();
                                    newIgM.Cod_Pozo = protocolo[i, j];
                                    newIgM.posicion = Convert.ToByte(cont++);
                                    if (lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                                    {
                                        lectData = Single.Parse(lectura[i, j].Remove(lectura[i, j].Length - 1));
                                    }
                                    else
                                    {
                                        lectData = Single.Parse(lectura[i, j]);
                                    }
                                    newIgM.Lectura = lectData;
                                    if (cb.Checked && !invalid)
                                    {
                                        und = (((lectData - cnR) / (cpR - cnR)) * 100).ToString("0.00");
                                    }
                                    else
                                    {
                                        und = "NA";
                                    }

                                    if (invalid)
                                        und = "INV";

                                    newIgM.Unidades = und;
                                    Unidades[i, j] = und;
                                    Absorbancia[i, j] = Convert.ToString(lectData);
                                    

                                    if (lectData >= float.Parse(txt_val1.Text) && !invalid)
                                    {
                                        res = "P";
                                    }
                                    else
                                    {
                                        res = "N";
                                    }

                                    if (invalid)
                                    {
                                        res = "INV";

                                    }

                                    newIgM.VC = Single.Parse(Single.Parse(txt_val1.Text).ToString("0.000"));
                                    newIgM.Resultado = res;
                                    Resultados[i, j] = res;

                                    if (lectData >= float.Parse(txt_val2.Text) && !invalid)
                                    {
                                        res1 = "P";
                                    }
                                    else
                                    {
                                        res1 = "N";
                                    }

                                    if (invalid)
                                    {
                                        res1 = "INV";
                                    }

                                    newIgM.VC2 = Single.Parse(Single.Parse(txt_val2.Text).ToString("0.000"));
                                    newIgM.Resultado2 = res1;
                                    Resultados1[i, j] = res1;
                                    newIgM.Placa = txt_Placa.TextBox.Text;
                                    if (invalid)
                                    {
                                        newIgM.Valido = false;
                                    }
                                    else
                                    {
                                        if (lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                                        {
                                            newIgM.Valido = false;
                                        }
                                        else
                                            newIgM.Valido = true;
                                    }

                                    newIgM.Fecha = DateTime.Now;
                                    newIgM.ControlPos = datos.ControlPos;
                                    newIgM.ControlNeg = datos.ControlNeg;
                                    newIgM.ControlRadPos = datos.ControlRadPos;
                                    newIgM.ControlRadNeg = datos.ControlRadNeg;
                                    newIgM.LoteIgM = datos.LoteIgM;
                                    newIgM.LoteAntigeno = datos.LoteAntigeno;
                                    newIgM.fechafijIGM = datos.fechafijIGM;
                                    newIgM.VolUsadoIGM = datos.VolUsadoIGM;
                                    newIgM.ProcH2O = datos.ProcH2O;
                                    newIgM.TipoEstudio = datos.TipoEstudio;
                                    newIgM.Coatting = datos.Coatting;
                                    newIgM.PB = datos.PB;
                                    newIgM.TB = datos.TB;
                                    newIgM.FB = datos.FB;
                                    newIgM.TMPB = datos.TMPB;
                                    newIgM.TIMEB = datos.TIMEB;
                                    newIgM.Substrato = datos.Substrato;
                                    newIgM.TSubstrato = datos.TSubstrato;
                                    newIgM.Conjugado = datos.Conjugado;
                                    newIgM.SHN = datos.SHN;
                                    newIgM.STOP = datos.STOP;
                                    newIgM.Factor = datos.Factor;
                                    newIgM.Factor2 = datos.Factor2;
                                    newIgM.Lab2 = cmb_Lab2.ComboBox.Text;
                                    newIgM.User = Convert.ToString(user.idUsuario);
                                    ElisaIGMTrans.saveElisaImGZika(newIgM);
                                    btn_Print.Enabled = true;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Verifique los datos del protocolo en el menu principal",
                                "Verifique sus datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;

                        //GuardarIgMZika
                        break;
                    }
                case 2:
                    {
                        ControlP = false;
                        //GuardarIgMZikaBei
                        break;
                    }
                case 12:
                    {
                        ControlP = false;
                        //GuardarZikaBob
                        break;
                    }
                case 13:
                    {
                        ControlP = false;
                        //GuardarZikaBob
                        break;
                    }
                case 14:
                    {
                        ControlP = false;
                        //GuardarZikaBob
                        break;
                    }
                case 15:
                    {
                        ControlP = false;
                        //GuardarZikaBob
                        break;
                    }
            }
        }

        private void txt_Placa_TextChanged(object sender, EventArgs e)
        {
            ErrorProviderPlaca.Clear();
        }

        private void cmb_Lab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProviderLab.Clear();
        }

        private void txt_Placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void guardarPlacaInválidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invalid = true;
            btn_Save_Click(null, EventArgs.Empty);
        }

        private void protocoloIgMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosIgM protoIgM = new DatosIgM();
            DialogResult result = protoIgM.ShowDialog(this);


        }

        private void btn_LoadProtocolo_Click(object sender, EventArgs e)
        {

        }

        private void protocoloEIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosEI protoEI = new DatosEI();
            DialogResult result = protoEI.ShowDialog(this);
        }

        private void btn_Leer_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;  
            if (txt_Placa.TextBox.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el número de la placa", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                btn_Leer.Enabled = false;
                dgv_Lectura.Rows.Clear();
                string contenido = MainUtils.CopyAndExtract(txt_Placa.TextBox.Text, selectedTest);
                if (contenido != null)
                {
                    string first = contenido.Substring(contenido.IndexOf("[DATA01]"),
                        (contenido.LastIndexOf("[DATA02]")) - contenido.IndexOf("[DATA01]"));
                    string second = contenido.Substring(contenido.IndexOf("[DATA02]"),
                        contenido.Length - contenido.IndexOf("[DATA02]"));

                    string[] splitfirst = first.Split('\t');
                    string[] splitsecond = second.Split('\t');

                    Single[] resultado = new float[96];

                    int i = 0;
                    for (int j = 1; j <= 192; j+= 2)
                    {
                        if (selectedTest == (Int32)MainUtils.Test.IgMZikaBei || selectedTest == (Int32)MainUtils.Test.ZikaBOB || selectedTest == (Int32)MainUtils.Test.ZikaBOBCohAnual || selectedTest == (Int32)MainUtils.Test.ZikaBOBCohAnualDup)
                        {
                            Single temp = Single.Parse(splitfirst[j]);
                            resultado[i] =Single.Parse(temp.ToString("#.000"));
                        }
                        else
                        {
                            Single temp1 = Single.Parse(Single.Parse(splitfirst[j]).ToString("#.000"));
                            Single temp2 = Single.Parse(Single.Parse(splitsecond[j]).ToString("#.000"));
                            Single res = temp1 - temp2;
                            resultado[i] = Single.Parse(res.ToString("#.000"));
                        }

                        i++;
                    }

                    string [,] tabla = new string[8,12];
                    int m = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        for (int k = 0; k < 12; k++)
                        {
                            tabla[j, k] = resultado[m] + "";
                            m++;
                        }
                        
                    }

                    for (int r = 0; r < 8; r++)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(this.dgv_Lectura);

                        for (int c = 0; c < 12; c++)
                        {
                            row.Cells[c].Value = tabla[r, c];
                        }

                        this.dgv_Lectura.Rows.Add(row);
                    }

                    int rowNumber = 0;
                    foreach (DataGridViewRow row in dgv_Lectura.Rows)
                    {
                        if (row.IsNewRow) continue;
                        row.HeaderCell.Value = MainUtils.rowHeadersRead()[rowNumber];
                        rowNumber = rowNumber + 1;
                    }
                    dgv_Lectura.AutoResizeRowHeadersWidth(
                        DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

                }
            }
            //Definir una ruta en el sistema para definir donde buscar el archivo.


        }

        private void btn_Calcular_Click(object sender, EventArgs e)
        {
            //TODO Realiza la accion del boton de calcular.
            switch (selectedTest)
            {
                case 0:
                {
                    new Calculos().CalcularIgM(this);
                }
                    break;
                case 1:
                {
                    new Calculos().CalcularIgmZika(this);
                }
                    break;
                case 5:
                {
                        new Calculos().CalcularIgG(this);
                }break;
                case 6:
                {
                        new Calculos().CalcularIgG(this);
                }
                    break;
            }
            
        }

        private bool validar, invalidar, editar;
        private bool loadedProtocol = false;

        private void tsOpen_Click(object sender, EventArgs e)
        {
            FD_OpenProtocolo.Filter = "Hoja de Calculo de Excel|*xls";
            FD_OpenProtocolo.FileName = "";
            FD_OpenProtocolo.InitialDirectory = MainUtils.BASE_DIR + "Protocolos";
            if (DialogResult.OK == FD_OpenProtocolo.ShowDialog())
            {
                string selectedPath = FD_OpenProtocolo.FileName;
                MainUtils.CargarProtocolo(selectedPath, dgv_Protocolo, txt_Placa.TextBox, this);
                tableLayoutPanel1.Enabled = true;
                btn_Leer.Enabled = true;
                loadedProtocol = true;
            }
        }

        private void dgv_Lectura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string value;
            if (dgv_Lectura.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                value = dgv_Lectura.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (validar)
                {
                    if (value[value.Length - 1].Equals((char)8203))
                    {
                        dgv_Lectura.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value.Remove(value.Length - 1);
                        dgv_Lectura.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                        dgv_Lectura.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                        dgv_Lectura.ClearSelection();
                    }
                }
                else if (invalidar)
                {
                    if (!value[value.Length - 1].Equals((char)8203))
                    {
                        dgv_Lectura.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value + (char)8203;
                        dgv_Lectura.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                        dgv_Lectura.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.White;
                        dgv_Lectura.ClearSelection();
                    }
                }
                else if (editar)
                {
                    dgv_Lectura.BeginEdit(true);
                }
            }

            
        }

        private void dgv_Protocolo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex>0 && e.RowIndex>0 && loadedProtocol)
            {
                dgv_Protocolo.ReadOnly = true;
                string value;
                value = dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string[,] protocolo = new string[8, 12];
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        protocolo[i, j] = dgv_Protocolo.Rows[i].Cells[j].Value.ToString();
                    }
                }
                //TODO Accion de los controles 
                switch ((MainUtils.Test)selectedTest)
                {
                    case MainUtils.Test.IgMDengue:
                        {
                            if (rb_Opt6.Checked)
                            {
                                if (MessageBox.Show("¿Desea convertir a Control Positivo Alto (CPA) esta celda?",
                                        "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                                    DialogResult.Yes)
                                {
                                    protocolo[e.RowIndex, e.ColumnIndex] = "";
                                    dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = MainUtils.contar(protocolo, "CA+");
                                }
                            }
                            else if (rb_Opt5.Checked)
                            {
                                if (MessageBox.Show("¿Desea convertir a Control Positivo Bajo (CPB) esta celda?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    protocolo[e.RowIndex, e.ColumnIndex] = "";
                                    dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = MainUtils.contar(protocolo, "CB+");
                                }
                            }
                            else if (rb_Opt4.Checked)
                            {
                                if (MessageBox.Show("¿Desea convertir a Control Negativo (C-) esta celda?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    protocolo[e.RowIndex, e.ColumnIndex] = "";
                                    dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = MainUtils.contar(protocolo, "C-");
                                }
                            }
                            else if (rb_Opt3.Checked)
                            {
                                if (MessageBox.Show("¿Desea convertir a Control Radio Positivo (CR+) esta celda?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    protocolo[e.RowIndex, e.ColumnIndex] = "";
                                    dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = MainUtils.contar(protocolo, "CR+");
                                }
                            }
                            else if (rb_opt2.Checked)
                            {
                                if (MessageBox.Show("¿Desea convertir a Control Radio Negativo (CR-) esta celda?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    protocolo[e.RowIndex, e.ColumnIndex] = "";
                                    dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = MainUtils.contar(protocolo, "CR-");
                                }
                            }
                            else if (rb_Opt1.Checked)
                            {
                                protocolo[e.RowIndex, e.ColumnIndex] = "";
                                dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = MainUtils.contar(protocolo, "SINM");
                            }
                        }
                        break;

                    case MainUtils.Test.IgMZika:
                    {
                        if (rb_Opt5.Checked)
                        {
                            if (MessageBox.Show("¿Desea convertir a Control Positivo (C+) esta celda?",
                                "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                protocolo[e.RowIndex, e.ColumnIndex] = "";
                                dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = MainUtils.contar(protocolo, "C+");
                            }
                        }else if (rb_Opt4.Checked)
                        {
                            if (MessageBox.Show("¿Desea convertir a Control Negativo (C-) esta celda?",
                                    "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                                DialogResult.Yes)
                            {
                                protocolo[e.RowIndex, e.ColumnIndex] = "";
                                dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                                    dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                                        MainUtils.contar(protocolo, "C-");
                            }
                        }else if (rb_Opt3.Checked)
                        {
                            if (MessageBox.Show("¿Desea convertir a Control Radio Positivo (CR+) esta celda?",
                                    "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                                DialogResult.Yes)
                            {
                                protocolo[e.RowIndex, e.ColumnIndex] = "";
                                dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                                    dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                                        MainUtils.contar(protocolo, "CR+");
                            }
                        }else if (rb_opt2.Checked)
                        {
                            if (MessageBox.Show("¿Desea convertir a Control Radio Negativo (CR-) esta celda?",
                                    "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                                DialogResult.Yes)
                            {
                                protocolo[e.RowIndex, e.ColumnIndex] = "";
                                dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                                    dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                                        MainUtils.contar(protocolo, "CR-");
                            }
                        }
                        else if (rb_Opt1.Checked)
                        {
                            protocolo[e.RowIndex, e.ColumnIndex] = "";
                            dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = MainUtils.contar(protocolo, "SINM");

                        }
                        }
                        break;
                    case MainUtils.Test.IgMZikaBei:
                    {
                            //Queda Pendiente
                    }break;
                    case MainUtils.Test.SalivaCIET:
                    {
                        if (rb_Opt4.Checked)
                        {
                            if (MessageBox.Show("¿Desea convertir a Control Positivo (C+) esta celda?",
                                    "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                protocolo[e.RowIndex, e.ColumnIndex] = "";
                                dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = MainUtils.contar(protocolo, "C+");
                            }
                        }else if (rb_Opt3.Checked)
                        {
                            if (MessageBox.Show("¿Desea convertir a Control Negativo (C-) esta celda?",
                                    "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                                DialogResult.Yes)
                            {
                                protocolo[e.RowIndex, e.ColumnIndex] = "";
                                dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                                    dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                                        MainUtils.contar(protocolo, "C-");
                            }
                        }else if (rb_opt2.Checked)
                        {
                            if (MessageBox.Show("¿Desea convertir a Control Negativo Saliva (S-) esta celda?",
                                    "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                                DialogResult.Yes)
                            {
                                protocolo[e.RowIndex, e.ColumnIndex] = "";
                                dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                                    dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                                        MainUtils.contar(protocolo, "S-");
                            }
                        }else if (rb_Opt1.Checked)
                        {
                            protocolo[e.RowIndex, e.ColumnIndex] = "";
                            dgv_Protocolo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = MainUtils.contar(protocolo, "SINM");
                        }
                    }
                        break;
                }
            }
            
        }

        private void rb_OptCheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            
            Thread frmLoad = new Thread(new ThreadStart(showLoadingScreen));
            frmLoad.Start();
            //Inicializar hoja de Excel
            MainUtils.InitializeExcelWorkSheet(this, groupProtocol.Text);
            closeLoadingScreen();
            this.Enabled = true;
        }

        LoadingScreen load = new LoadingScreen("Creando archivo de Excel");

        private void btn_Reiniciar_Click(object sender, EventArgs e)
        {
            Principal p = new Principal(user);
            p.Location = this.Location;
            this.Hide();
            p.Show();
            restart = true;
            this.Close();
            
        }

        public void showLoadingScreen()
        {
            load.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(load);
        }

        public void closeLoadingScreen()
        {
            if (load.label1.InvokeRequired)
            {
                load.Invoke((MethodInvoker)delegate ()
                {
                    closeLoadingScreen();
                });
            }
            else
            {
                load.Close();
            }
        }

        private void protocoloIgMZikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosIgMZika protoIgM = new DatosIgMZika();
            DialogResult result = protoIgM.ShowDialog(this);
        }

        public void toggleCombobox(string test)
        {
            RadioButton [] radioButtons = new RadioButton[7];
            radioButtons[0] = rb_IgM;
            radioButtons[1] = rb_IgG;
            radioButtons[2] = rb_EI;
            radioButtons[3] = rb_BOB;
            radioButtons[4] = rb_1D;
            radioButtons[5] = rb_RM;
            radioButtons[6] = rb_Rotavirus;
            ComboBox [] comboboxes = new ComboBox[6];
            comboboxes[0] = cmb_IgM;
            comboboxes[1] = cmb_IgG;
            comboboxes[2] = cmb_EI;
            comboboxes[3] = cmb_BOB;
            comboboxes[4] = cmb_1D;
            comboboxes[5] = cmb_RM;

            if (test.Equals("Rotavirus"))
            {
                rb_Rotavirus.Checked = true;
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    if (comboboxes[i].FindStringExact(test) != -1)
                    {
                        radioButtons[i].Checked = true;
                        comboboxes[i].SelectedIndex = comboboxes[i].FindStringExact(test);
                    }
                }
            }

        }

        private void rb_CheckedButtonChanged(object sender, EventArgs e)
        {
            validar = false;
            invalidar = false;
            editar = false;
            dgv_Lectura.ReadOnly = true;
            if (rb_Validar.Checked)
            {
                validar = true;
            }else if (rb_Invalidar.Checked)
            {
                invalidar = true;
            }
        }
    }
}
