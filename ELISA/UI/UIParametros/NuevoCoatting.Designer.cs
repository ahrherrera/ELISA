namespace ELISA.UI.UIParametros
{
    partial class NuevoCoatting
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
            this.txt_Na2CO3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoControl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_NaHCO3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.H2ODest = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_PH = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 31;
            this.label7.Text = "Volumen :";
            // 
            // txt_Volumen
            // 
            this.txt_Volumen.Location = new System.Drawing.Point(146, 68);
            this.txt_Volumen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Volumen.Name = "txt_Volumen";
            this.txt_Volumen.Size = new System.Drawing.Size(122, 22);
            this.txt_Volumen.TabIndex = 30;
            this.txt_Volumen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Volumen_KeyPress);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(166, 405);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(111, 40);
            this.btn_Cancelar.TabIndex = 29;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Aceptar.Location = new System.Drawing.Point(55, 405);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(105, 40);
            this.btn_Aceptar.TabIndex = 28;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Observación :";
            // 
            // txt_Observacion
            // 
            this.txt_Observacion.Location = new System.Drawing.Point(146, 320);
            this.txt_Observacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Observacion.Multiline = true;
            this.txt_Observacion.Name = "txt_Observacion";
            this.txt_Observacion.Size = new System.Drawing.Size(156, 51);
            this.txt_Observacion.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 34);
            this.label5.TabIndex = 25;
            this.label5.Text = "Fecha de \r\nExpiración :";
            // 
            // time_FechaFin
            // 
            this.time_FechaFin.CustomFormat = "dd-MM-yyyy";
            this.time_FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_FechaFin.Location = new System.Drawing.Point(148, 277);
            this.time_FechaFin.Name = "time_FechaFin";
            this.time_FechaFin.Size = new System.Drawing.Size(120, 22);
            this.time_FechaFin.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 34);
            this.label4.TabIndex = 23;
            this.label4.Text = "Fecha de \rPreparación :";
            // 
            // time_FechaInicio
            // 
            this.time_FechaInicio.CustomFormat = "dd-MM-yyyy";
            this.time_FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_FechaInicio.Location = new System.Drawing.Point(149, 227);
            this.time_FechaInicio.Name = "time_FechaInicio";
            this.time_FechaInicio.Size = new System.Drawing.Size(120, 22);
            this.time_FechaInicio.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Na2CO3 :";
            // 
            // txt_Na2CO3
            // 
            this.txt_Na2CO3.Location = new System.Drawing.Point(146, 101);
            this.txt_Na2CO3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Na2CO3.Name = "txt_Na2CO3";
            this.txt_Na2CO3.Size = new System.Drawing.Size(122, 22);
            this.txt_Na2CO3.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 34);
            this.label1.TabIndex = 17;
            this.label1.Text = "Código \rLote Coatting :";
            // 
            // txtCodigoControl
            // 
            this.txtCodigoControl.Location = new System.Drawing.Point(146, 30);
            this.txtCodigoControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCodigoControl.Name = "txtCodigoControl";
            this.txtCodigoControl.Size = new System.Drawing.Size(122, 22);
            this.txtCodigoControl.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 33;
            this.label8.Text = "NaHCO3 :";
            // 
            // txt_NaHCO3
            // 
            this.txt_NaHCO3.Location = new System.Drawing.Point(146, 133);
            this.txt_NaHCO3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_NaHCO3.Name = "txt_NaHCO3";
            this.txt_NaHCO3.Size = new System.Drawing.Size(122, 22);
            this.txt_NaHCO3.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 17);
            this.label9.TabIndex = 35;
            this.label9.Text = "H2ODEST :";
            // 
            // H2ODest
            // 
            this.H2ODest.Location = new System.Drawing.Point(146, 164);
            this.H2ODest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.H2ODest.Name = "H2ODest";
            this.H2ODest.Size = new System.Drawing.Size(122, 22);
            this.H2ODest.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 17);
            this.label10.TabIndex = 37;
            this.label10.Text = "pH :";
            // 
            // txt_PH
            // 
            this.txt_PH.Location = new System.Drawing.Point(146, 194);
            this.txt_PH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_PH.Name = "txt_PH";
            this.txt_PH.Size = new System.Drawing.Size(122, 22);
            this.txt_PH.TabIndex = 36;
            this.txt_PH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_PH_KeyPress);
            // 
            // NuevoCoatting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 460);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_PH);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.H2ODest);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_NaHCO3);
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
            this.Controls.Add(this.txt_Na2CO3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoControl);
            this.Name = "NuevoCoatting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Nuevo Lote Coatting";
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
        private System.Windows.Forms.TextBox txt_Na2CO3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoControl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_NaHCO3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox H2ODest;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_PH;
    }
}