namespace ELISA.UI
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lbl_userName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_showPassword = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.cmbUsuario = new MetroFramework.Controls.MetroComboBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_Error = new System.Windows.Forms.Label();
            this.masterPanel = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.masterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_userName
            // 
            this.lbl_userName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_userName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_userName.Location = new System.Drawing.Point(15, 36);
            this.lbl_userName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_userName.Name = "lbl_userName";
            this.lbl_userName.Size = new System.Drawing.Size(88, 44);
            this.lbl_userName.TabIndex = 2;
            this.lbl_userName.Text = "Nombre de Usuario :";
            this.lbl_userName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contraseña :";
            // 
            // btn_showPassword
            // 
            this.btn_showPassword.BackgroundImage = global::ELISA.Properties.Resources.if_icon_22_eye_315220;
            this.btn_showPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_showPassword.Location = new System.Drawing.Point(337, 89);
            this.btn_showPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_showPassword.Name = "btn_showPassword";
            this.btn_showPassword.Size = new System.Drawing.Size(30, 32);
            this.btn_showPassword.TabIndex = 6;
            this.btn_showPassword.UseVisualStyleBackColor = true;
            this.btn_showPassword.Click += new System.EventHandler(this.btn_showPassword_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Password);
            this.groupBox1.Controls.Add(this.cmbUsuario);
            this.groupBox1.Controls.Add(this.lbl_userName);
            this.groupBox1.Controls.Add(this.btn_showPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(382, 158);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inicie Sesión";
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(109, 94);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(224, 26);
            this.txt_Password.TabIndex = 2;
            this.txt_Password.UseSystemPasswordChar = true;
            this.txt_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Password_KeyPress);
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.ItemHeight = 23;
            this.cmbUsuario.Location = new System.Drawing.Point(109, 47);
            this.cmbUsuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(224, 29);
            this.cmbUsuario.Style = MetroFramework.MetroColorStyle.Blue;
            this.cmbUsuario.TabIndex = 1;
            this.cmbUsuario.UseSelectable = true;
            // 
            // btn_Login
            // 
            this.btn_Login.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.Location = new System.Drawing.Point(310, 196);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(86, 28);
            this.btn_Login.TabIndex = 3;
            this.btn_Login.Text = "Iniciar Sesión";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(226, 196);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(80, 28);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Cancelar";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_Error
            // 
            this.lbl_Error.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Error.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error.Location = new System.Drawing.Point(11, 190);
            this.lbl_Error.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Error.Name = "lbl_Error";
            this.lbl_Error.Size = new System.Drawing.Size(197, 38);
            this.lbl_Error.TabIndex = 8;
            this.lbl_Error.Text = "El usuario y la contraseña no son correctos";
            this.lbl_Error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Error.Visible = false;
            // 
            // masterPanel
            // 
            this.masterPanel.BackColor = System.Drawing.Color.White;
            this.masterPanel.Controls.Add(this.groupBox1);
            this.masterPanel.Controls.Add(this.lbl_Error);
            this.masterPanel.Controls.Add(this.btn_Login);
            this.masterPanel.Controls.Add(this.btn_Cancel);
            this.masterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterPanel.Location = new System.Drawing.Point(0, 0);
            this.masterPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.masterPanel.Name = "masterPanel";
            this.masterPanel.Size = new System.Drawing.Size(414, 244);
            this.masterPanel.TabIndex = 5;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 244);
            this.Controls.Add(this.masterPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autenticación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.masterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_userName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_showPassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_Error;
        private System.Windows.Forms.Panel masterPanel;
        private MetroFramework.Controls.MetroComboBox cmbUsuario;
        private System.Windows.Forms.TextBox txt_Password;
    }
}