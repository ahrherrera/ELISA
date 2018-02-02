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
using ELISA.Utils;

namespace ELISA.UI
{
    public partial class Principal : Form
    {
        public static usuario user;
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

            List<String> EquipoList = new List<string>();
            EquipoList.Add("MULTISKAN EX");
            EquipoList.Add("MULTISKAN FC");
            cmb_Equipo.ComboBox.DataSource = EquipoList;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton send = (RadioButton) sender;

            if (send.Checked)
            {
                //MessageBox.Show("Text: " + send.Text);
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
                }
            }
            

        }
    }
}
