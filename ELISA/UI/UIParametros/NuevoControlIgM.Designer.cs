namespace ELISA.UI.UIParametros
{
    partial class NuevoControlIgM
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
            this.txtCodigoControl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_DOptica = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Volumen = new System.Windows.Forms.TextBox();
            this.time_FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.time_FechaFin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Observacion = new System.Windows.Forms.TextBox();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCodigoControl
            // 
            this.txtCodigoControl.Location = new System.Drawing.Point(137, 39);
            this.txtCodigoControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCodigoControl.Name = "txtCodigoControl";
            this.txtCodigoControl.Size = new System.Drawing.Size(122, 27);
            this.txtCodigoControl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código \r\nControl IgM :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "D Optica :";
            // 
            // txt_DOptica
            // 
            this.txt_DOptica.Location = new System.Drawing.Point(137, 85);
            this.txt_DOptica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_DOptica.Name = "txt_DOptica";
            this.txt_DOptica.Size = new System.Drawing.Size(122, 27);
            this.txt_DOptica.TabIndex = 2;
            this.txt_DOptica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DOptica_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Volumen :";
            // 
            // txt_Volumen
            // 
            this.txt_Volumen.Location = new System.Drawing.Point(137, 122);
            this.txt_Volumen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Volumen.Name = "txt_Volumen";
            this.txt_Volumen.Size = new System.Drawing.Size(122, 27);
            this.txt_Volumen.TabIndex = 4;
            this.txt_Volumen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Volumen_KeyPress);
            // 
            // time_FechaInicio
            // 
            this.time_FechaInicio.CustomFormat = "dd-MM-yyyy";
            this.time_FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_FechaInicio.Location = new System.Drawing.Point(138, 167);
            this.time_FechaInicio.Name = "time_FechaInicio";
            this.time_FechaInicio.Size = new System.Drawing.Size(120, 27);
            this.time_FechaInicio.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 40);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha de \r\nInicio :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 40);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha de \r\nFinalización :";
            // 
            // time_FechaFin
            // 
            this.time_FechaFin.CustomFormat = "dd-MM-yyyy";
            this.time_FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_FechaFin.Location = new System.Drawing.Point(137, 217);
            this.time_FechaFin.Name = "time_FechaFin";
            this.time_FechaFin.Size = new System.Drawing.Size(120, 27);
            this.time_FechaFin.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Observación :";
            // 
            // txt_Observacion
            // 
            this.txt_Observacion.Location = new System.Drawing.Point(135, 260);
            this.txt_Observacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Observacion.Multiline = true;
            this.txt_Observacion.Name = "txt_Observacion";
            this.txt_Observacion.Size = new System.Drawing.Size(156, 50);
            this.txt_Observacion.TabIndex = 10;
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Aceptar.Location = new System.Drawing.Point(44, 333);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(105, 39);
            this.btn_Aceptar.TabIndex = 12;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(155, 333);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(111, 39);
            this.btn_Cancelar.TabIndex = 13;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            // 
            // NuevoControlIgMCPA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 383);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Aceptar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Observacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.time_FechaFin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.time_FechaInicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Volumen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_DOptica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NuevoControlIgMCPA";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo Control IgM CPA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigoControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_DOptica;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Volumen;
        private System.Windows.Forms.DateTimePicker time_FechaInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker time_FechaFin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Observacion;
        private System.Windows.Forms.Button btn_Aceptar;
        private System.Windows.Forms.Button btn_Cancelar;
    }
}