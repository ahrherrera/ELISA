using System;
using System.Windows.Forms;
using ELISA.Transaccion;

namespace ELISA.UI
{
    public partial class Login : Form
    {
        private Timer timer = new Timer();
        public Login()
        {
            InitializeComponent();
        }

        public void fillCombo()
        {
            cmbUsuario.BeginInvoke(
                (Action)(() =>
                {
                    UsuarioTrans.LlenarUsuarios(cmbUsuario, this);
                }));
            
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cierra el hilo de ejecución principal del programa
            try
            {
                System.Environment.Exit(1);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {

            }
        }

        private void btn_showPassword_Click(object sender, EventArgs e)
        {
            //Muestra durante 1 segundo el campo de contraseña
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            timer.Start();
            this.txt_Password.UseSystemPasswordChar = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.txt_Password.UseSystemPasswordChar = true;
            timer.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void IniciarSesion()
        {
            if (cmbUsuario.SelectedIndex!=-1)
            {
                Utils.Log.logInfo("Usuario seleccionado, consultar los datos");
                usuario user = (usuario)cmbUsuario.SelectedValue;
                var result = UsuarioTrans.Login(user.nombreUsuario, txt_Password);

                if (result)
                {
                    lbl_Error.Visible = false;
                    //Mostrar ventana principal
                    new Principal(user).Show();
                    Hide();
                }
                else
                {
                    lbl_Error.Visible = true;
                }
            }
        }

        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                IniciarSesion();
                e.Handled = true;
                

            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
        

        private void Login_Load(object sender, EventArgs e)
        {
            // Realiza una tarea asincrona que manda a traer los nombres de usuarios
            //y los llena en el combobox
            txt_Password.Select();
            fillCombo();
            Utils.Log.logInfo("Ventana de autenticación Mostrada");
        }
    }
}
