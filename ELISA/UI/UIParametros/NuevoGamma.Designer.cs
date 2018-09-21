namespace ELISA.UI.UIParametros
{
    partial class NuevoGamma
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
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Volumen = new System.Windows.Forms.TextBox();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Observacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.time_FechaFin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.time_FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_PSB1X = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoLote = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_NH4SO4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_concenGamma = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_codigoMX = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 58);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Volumen :";
            // 
            // txt_Volumen
            // 
            this.txt_Volumen.Location = new System.Drawing.Point(110, 55);
            this.txt_Volumen.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Volumen.Name = "txt_Volumen";
            this.txt_Volumen.Size = new System.Drawing.Size(92, 20);
            this.txt_Volumen.TabIndex = 30;
            this.txt_Volumen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Volumen_KeyPress);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(124, 329);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(83, 32);
            this.btn_Cancelar.TabIndex = 29;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Aceptar.Location = new System.Drawing.Point(41, 329);
            this.btn_Aceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(79, 32);
            this.btn_Aceptar.TabIndex = 28;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 262);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Observación :";
            // 
            // txt_Observacion
            // 
            this.txt_Observacion.Location = new System.Drawing.Point(110, 260);
            this.txt_Observacion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Observacion.Multiline = true;
            this.txt_Observacion.Name = "txt_Observacion";
            this.txt_Observacion.Size = new System.Drawing.Size(118, 42);
            this.txt_Observacion.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 221);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 26);
            this.label5.TabIndex = 25;
            this.label5.Text = "Fecha de \r\nTerminación :";
            // 
            // time_FechaFin
            // 
            this.time_FechaFin.CustomFormat = "dd-MM-yyyy";
            this.time_FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_FechaFin.Location = new System.Drawing.Point(111, 225);
            this.time_FechaFin.Margin = new System.Windows.Forms.Padding(2);
            this.time_FechaFin.Name = "time_FechaFin";
            this.time_FechaFin.Size = new System.Drawing.Size(91, 20);
            this.time_FechaFin.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 180);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 26);
            this.label4.TabIndex = 23;
            this.label4.Text = "Fecha de \rPreparación :";
            // 
            // time_FechaInicio
            // 
            this.time_FechaInicio.CustomFormat = "dd-MM-yyyy";
            this.time_FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_FechaInicio.Location = new System.Drawing.Point(112, 184);
            this.time_FechaInicio.Margin = new System.Windows.Forms.Padding(2);
            this.time_FechaInicio.Name = "time_FechaInicio";
            this.time_FechaInicio.Size = new System.Drawing.Size(91, 20);
            this.time_FechaInicio.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "PBS1X :";
            // 
            // txt_PSB1X
            // 
            this.txt_PSB1X.Location = new System.Drawing.Point(110, 82);
            this.txt_PSB1X.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_PSB1X.Name = "txt_PSB1X";
            this.txt_PSB1X.Size = new System.Drawing.Size(92, 20);
            this.txt_PSB1X.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 26);
            this.label1.TabIndex = 17;
            this.label1.Text = "Código \rLote Asign :";
            // 
            // txtCodigoLote
            // 
            this.txtCodigoLote.Location = new System.Drawing.Point(110, 24);
            this.txtCodigoLote.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCodigoLote.Name = "txtCodigoLote";
            this.txtCodigoLote.Size = new System.Drawing.Size(92, 20);
            this.txtCodigoLote.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 110);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "NH4SO4 :";
            // 
            // txt_NH4SO4
            // 
            this.txt_NH4SO4.Location = new System.Drawing.Point(110, 108);
            this.txt_NH4SO4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_NH4SO4.Name = "txt_NH4SO4";
            this.txt_NH4SO4.Size = new System.Drawing.Size(92, 20);
            this.txt_NH4SO4.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 132);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 26);
            this.label9.TabIndex = 35;
            this.label9.Text = "Concen \r\nGamma :";
            // 
            // txt_concenGamma
            // 
            this.txt_concenGamma.Location = new System.Drawing.Point(110, 133);
            this.txt_concenGamma.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_concenGamma.Name = "txt_concenGamma";
            this.txt_concenGamma.Size = new System.Drawing.Size(92, 20);
            this.txt_concenGamma.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 161);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Codigo Mx :";
            // 
            // txt_codigoMX
            // 
            this.txt_codigoMX.Location = new System.Drawing.Point(110, 158);
            this.txt_codigoMX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_codigoMX.Name = "txt_codigoMX";
            this.txt_codigoMX.Size = new System.Drawing.Size(92, 20);
            this.txt_codigoMX.TabIndex = 36;
            this.txt_codigoMX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_PH_KeyPress);
            // 
            // NuevoGamma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 374);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_codigoMX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_concenGamma);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_NH4SO4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Volumen);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Aceptar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Observacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.time_FechaFin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.time_FechaInicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_PSB1X);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoLote);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NuevoGamma";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Gamma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Volumen;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Aceptar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Observacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker time_FechaFin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker time_FechaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_PSB1X;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoLote;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_NH4SO4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_concenGamma;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_codigoMX;
    }
}