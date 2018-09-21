namespace ELISA.UI.UIParametros
{
    partial class NuevoPB
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
            this.label3 = new System.Windows.Forms.Label();
            this.txt_CodLote1X = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoLote = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Numero = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_h2odest = new System.Windows.Forms.TextBox();
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
            this.btn_Cancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Cancelar.Location = new System.Drawing.Point(124, 219);
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
            this.btn_Aceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Aceptar.Location = new System.Drawing.Point(41, 219);
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
            this.label6.Location = new System.Drawing.Point(26, 160);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Observación :";
            // 
            // txt_Observacion
            // 
            this.txt_Observacion.Location = new System.Drawing.Point(110, 160);
            this.txt_Observacion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Observacion.Multiline = true;
            this.txt_Observacion.Name = "txt_Observacion";
            this.txt_Observacion.Size = new System.Drawing.Size(118, 42);
            this.txt_Observacion.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 26);
            this.label3.TabIndex = 21;
            this.label3.Text = "Codigo Lote\r\nAsign 1X :";
            // 
            // txt_CodLote1X
            // 
            this.txt_CodLote1X.Location = new System.Drawing.Point(110, 82);
            this.txt_CodLote1X.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_CodLote1X.Name = "txt_CodLote1X";
            this.txt_CodLote1X.Size = new System.Drawing.Size(92, 20);
            this.txt_CodLote1X.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 26);
            this.label1.TabIndex = 17;
            this.label1.Text = "Código Lote \r\nAsign 20X :";
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
            this.label8.Location = new System.Drawing.Point(32, 111);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Numero :";
            // 
            // txt_Numero
            // 
            this.txt_Numero.Location = new System.Drawing.Point(110, 108);
            this.txt_Numero.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Numero.Name = "txt_Numero";
            this.txt_Numero.Size = new System.Drawing.Size(92, 20);
            this.txt_Numero.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 132);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "H2O Dest :";
            // 
            // txt_h2odest
            // 
            this.txt_h2odest.Location = new System.Drawing.Point(110, 133);
            this.txt_h2odest.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_h2odest.Name = "txt_h2odest";
            this.txt_h2odest.Size = new System.Drawing.Size(92, 20);
            this.txt_h2odest.TabIndex = 34;
            // 
            // NuevoPB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 264);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_h2odest);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_Numero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Volumen);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Aceptar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Observacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_CodLote1X);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoLote);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NuevoPB";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PB";
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_CodLote1X;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoLote;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Numero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_h2odest;
    }
}