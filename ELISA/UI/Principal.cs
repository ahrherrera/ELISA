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
using ELISA.Utils;

namespace ELISA.UI
{
    public partial class Principal : Form
    {
        public static usuario user;
        public string SelectedProtocol;
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
                Environment.Exit(1);
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
            List<String> IgMList = new List<string>();
            IgMList.Add("IgM Dengue");
            IgMList.Add("IgM Zika");
            IgMList.Add("IgM Zika Bei");
            IgMList.Add("Chikungunya CDC/CNDR");
            IgMList.Add("Chikungunya CNDR");
            cmb_IgM.DataSource = IgMList;
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
            List<String> BOBList = new List<string>();
            BOBList.Add("Zika BOB");
            BOBList.Add("Zika BOB Cohorte Anual");
            BOBList.Add("Zika BOB Cohorte Anual Dup");
            BOBList.Add("Zika BOB Coh Anual/Sero 1 m");
            cmb_BOB.DataSource = BOBList;
            List<String> OneDList = new List<string>();
            OneDList.Add("ELISA 1D Cohorte Anual");
            OneDList.Add("ELISA 1D Cohorte Anual Dup");
            OneDList.Add("ELISA 1D Cohorte Anual Chik");
            OneDList.Add("ELISA 1D Seroprevalencia Chik");
            OneDList.Add("ELISA 1D Seroprevalencia Chik Dup");
            OneDList.Add("Zika 1D Cohorte Anual");
            OneDList.Add("Zika 1D Cohorte Anual Dup");
            cmb_1D.DataSource = OneDList;
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


            List<String> EquipoList = new List<string>();
            EquipoList.Add("MULTISKAN EX");
            EquipoList.Add("MULTISKAN FC");
            cmb_Equipo.ComboBox.DataSource = EquipoList;

            rb_Rotavirus.Checked = true;
            rb_IgM.Checked = true;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton send = (RadioButton) sender;

            if (send.Checked)
            {
                SelectedProtocol = send.Text;
                if (send.Text.Contains("IgM"))
                {
                    cmb_IgM.Enabled = true;
                    cmb_EI.Enabled = false;
                    cmb_BOB.Enabled = false;
                    cmb_IgG.Enabled = false;
                    cmb_1D.Enabled = false;
                    cmb_RM.Enabled = false;
                }else if (send.Text.Contains("EI"))
                {
                    cmb_IgM.Enabled = false;
                    cmb_EI.Enabled = true;
                    cmb_BOB.Enabled = false;
                    cmb_IgG.Enabled = false;
                    cmb_1D.Enabled = false;
                    cmb_RM.Enabled = false;
                }
                else if (send.Text.Contains("BOB"))
                {
                    cmb_IgM.Enabled = false;
                    cmb_EI.Enabled = false;
                    cmb_BOB.Enabled = true;
                    cmb_IgG.Enabled = false;
                    cmb_1D.Enabled = false;
                    cmb_RM.Enabled = false;
                }
                else if (send.Text.Contains("IgG"))
                {
                    cmb_IgM.Enabled = false;
                    cmb_EI.Enabled = false;
                    cmb_BOB.Enabled = false;
                    cmb_IgG.Enabled = true;
                    cmb_1D.Enabled = false;
                    cmb_RM.Enabled = false;
                }
                else if (send.Text.Contains("1D"))
                {
                    cmb_IgM.Enabled = false;
                    cmb_EI.Enabled = false;
                    cmb_BOB.Enabled = false;
                    cmb_IgG.Enabled = false;
                    cmb_1D.Enabled = true;
                    cmb_RM.Enabled = false;
                }
                else if (send.Text.Contains("RM"))
                {
                    cmb_IgM.Enabled = false;
                    cmb_EI.Enabled = false;
                    cmb_BOB.Enabled = false;
                    cmb_IgG.Enabled = false;
                    cmb_1D.Enabled = false;
                    cmb_RM.Enabled = true;
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
                }
            }
        }

        private void btnProtocolo_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btnProtocolo, new Point(0, btnProtocolo.Height));
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lbl_Time.Text = DateTime.Now.ToString("F",
                CultureInfo.CreateSpecificCulture("es-MX"));
        }

        private void cmb_IgM_EnabledChanged(object sender, EventArgs e)
        {
            if (cmb_IgM.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_IgM.SelectedItem.ToString();
            }
        }

        private void cmb_EI_EnabledChanged(object sender, EventArgs e)
        {
            if (cmb_EI.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_EI.SelectedItem.ToString();
            }
        }

        private void cmb_BOB_EnabledChanged(object sender, EventArgs e)
        {
            if (cmb_BOB.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_BOB.SelectedItem.ToString();
            }
        }

        private void cmb_IgG_EnabledChanged(object sender, EventArgs e)
        {
            if (cmb_IgG.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_IgG.SelectedItem.ToString();
            }
        }

        private void cmb_1D_EnabledChanged(object sender, EventArgs e)
        {
            if (cmb_1D.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_1D.SelectedItem.ToString();
            }
            
        }

        private void cmb_RM_EnabledChanged(object sender, EventArgs e)
        {
            if (cmb_RM.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_RM.SelectedItem.ToString();
            }
        }

        private void cmb_Protocolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_EI.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_EI.SelectedItem.ToString();
            }
            if (cmb_IgM.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_IgM.SelectedItem.ToString();
            }
            if (cmb_BOB.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_BOB.SelectedItem.ToString();
            }
            if (cmb_IgG.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_IgG.SelectedItem.ToString();
            }
            if (cmb_1D.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_1D.SelectedItem.ToString();
            }
            if (cmb_RM.Enabled)
            {
                groupProtocol.Text = "Protocolo " + cmb_RM.SelectedItem.ToString();
            }
        }
    }
}
