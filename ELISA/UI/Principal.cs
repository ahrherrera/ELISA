using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Transaccion;
using ELISA.Transaccion.DatosProtocoloTrans;
using ELISA.UI.UIParametros;
using ELISA.Utils;

namespace ELISA.UI
{
    public partial class Principal : Form
    {
        public static usuario user;
        CheckBox cb = new CheckBox();
        public static Boolean ControlP = true;
        ErrorProvider ErrorProviderPlaca = new ErrorProvider();
        ErrorProvider ErrorProviderLab = new ErrorProvider();

        //Variables
        private int selectedTest = -1;
        public static Boolean invalid;
        public Principal(usuario logged)
        {
            InitializeComponent();
            user = logged;
            cmb_Equipo.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Mostrar Mensaje de confirmacion
            var dialogo = MessageBox.Show("¿Está seguro que desea Salir?",
                "Salir",
                MessageBoxButtons.YesNo);
            if (dialogo == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Log.logInfo("Ventana principal Cargada correctamente");
            fillCombobox();
            fillComboLab();
            addCheckbox();
            alignHeaders();
            timerClock.Enabled = true;
            
        }

        private void alignHeaders()
        {
            dgv_Protocolo.Rows.Add(8);
            int rowNumber = 0;
            foreach (DataGridViewRow row in dgv_Protocolo.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = MainUtils.abc()[rowNumber];
                rowNumber = rowNumber + 1;
            }
            dgv_Protocolo.AutoResizeRowHeadersWidth(
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void addCheckbox()
        {
            CheckBox cb = new CheckBox();
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
            if (cmb_EI.Enabled) 
            {
                groupProtocol.Text = "Protocolo " + cmb_EI.SelectedItem.ToString();
                groupValidar.Text = "Validación " + cmb_EI.SelectedItem.ToString();
                string selectedItem = cmb_EI.SelectedItem.ToString();

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
                    //fmeResultsIgM
                    SelectTest(MainUtils.Test.IgMDengue);
                    SetOpcionesOptIgm();
                }else if (selectedItem.Equals("IgM Zika"))
                {
                    SelectTest(MainUtils.Test.IgMZika);
                    SetOpcionesIgMZika();
                }else if (selectedItem.Equals("IgM Zika Bei"))
                {
                    SelectTest(MainUtils.Test.IgMZikaBei);
                    SetOpcionesIgMZikaBei();
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

        private void SetOpcionesOptIgm()
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
                //MessageBox.Show("CMb1Text = " + cmb_Lab1.Text + "  CmbIndex= " +cmb_Lab1.SelectedIndex);
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
            //Pasa los datos contenidos en la tabla a un arreglo multidimensional
            String [,] protocolo = new String[dgv_Protocolo.RowCount,dgv_Protocolo.ColumnCount];
            foreach (DataGridViewRow i in dgv_Protocolo.Rows)
            {
                if (i.IsNewRow)
                {
                    foreach (DataGridViewCell j in i.Cells)
                    {
                        protocolo[j.RowIndex, j.ColumnIndex] = (string) j.Value;
                    }
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
                        //GuardarIgM
                        break;
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
    }
}
