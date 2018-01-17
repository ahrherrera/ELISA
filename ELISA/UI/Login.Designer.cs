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
            this.lbl_userName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_showPassword = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbUsuario = new MetroFramework.Controls.MetroComboBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_Error = new System.Windows.Forms.Label();
            this.masterPanel = new System.Windows.Forms.Panel();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.masterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_userName
            // 
            this.lbl_userName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_userName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_userName.Location = new System.Drawing.Point(20, 44);
            this.lbl_userName.Name = "lbl_userName";
            this.lbl_userName.Size = new System.Drawing.Size(118, 54);
            this.lbl_userName.TabIndex = 2;
            this.lbl_userName.Text = "Nombre de Usuario :";
            this.lbl_userName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contraseña :";
            // 
            // btn_showPassword
            // 
            this.btn_showPassword.BackgroundImage = global::ELISA.Properties.Resources.if_icon_22_eye_315220;
            this.btn_showPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_showPassword.Location = new System.Drawing.Point(449, 110);
            this.btn_showPassword.Name = "btn_showPassword";
            this.btn_showPassword.Size = new System.Drawing.Size(40, 40);
            this.btn_showPassword.TabIndex = 4;
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
            this.groupBox1.Location = new System.Drawing.Point(10, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 194);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inicie Sesión";
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.ItemHeight = 24;
            this.cmbUsuario.Location = new System.Drawing.Point(145, 58);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(298, 30);
            this.cmbUsuario.Style = MetroFramework.MetroColorStyle.Blue;
            this.cmbUsuario.TabIndex = 5;
            this.cmbUsuario.UseSelectable = true;
            // 
            // btn_Login
            // 
            this.btn_Login.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.Location = new System.Drawing.Point(414, 241);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(114, 32);
            this.btn_Login.TabIndex = 2;
            this.btn_Login.Text = "Iniciar Sesión";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(302, 241);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(106, 32);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "Cancelar";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_Error
            // 
            this.lbl_Error.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Error.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error.Location = new System.Drawing.Point(15, 234);
            this.lbl_Error.Name = "lbl_Error";
            this.lbl_Error.Size = new System.Drawing.Size(263, 47);
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
            this.masterPanel.Name = "masterPanel";
            this.masterPanel.Size = new System.Drawing.Size(552, 300);
            this.masterPanel.TabIndex = 5;
            this.masterPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.masterPanel_Paint);
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(145, 116);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(298, 30);
            this.txt_Password.TabIndex = 7;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 300);
            this.Controls.Add(this.masterPanel);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autenticación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Shown += new System.EventHandler(this.Login_Shown);
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