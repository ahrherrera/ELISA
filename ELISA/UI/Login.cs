﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Transaccion;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ELISA.UI
{
    public partial class Login : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
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
            System.Environment.Exit(1);
        }

        private void btn_showPassword_Click(object sender, EventArgs e)
        {
            //Muestra durante 1 segundo el campo de contraseña
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            this.txt_Password.UseSystemPasswordChar = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.txt_Password.UseSystemPasswordChar = true;
            timer.Stop();
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            //Realiza una tarea asincrona que manda a traer los nombres de usuarios
            //y los llena en el combobox
            fillCombo();
            Utils.Log.logInfo("Ventana de autenticación Mostrada");
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
                    this.Hide();
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
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void masterPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
