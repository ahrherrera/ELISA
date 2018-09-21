namespace ELISA.UI.UIParametros
{
    partial class frmCPEI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_dir = new System.Windows.Forms.ComboBox();
            this.cmb_Disol = new System.Windows.Forms.ComboBox();
            this.cmb_DisInicial = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_dir);
            this.groupBox1.Controls.Add(this.cmb_Disol);
            this.groupBox1.Controls.Add(this.cmb_DisInicial);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_codigo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(276, 187);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // cmb_dir
            // 
            this.cmb_dir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_dir.FormattingEnabled = true;
            this.cmb_dir.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical"});
            this.cmb_dir.Location = new System.Drawing.Point(87, 148);
            this.cmb_dir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_dir.Name = "cmb_dir";
            this.cmb_dir.Size = new System.Drawing.Size(82, 23);
            this.cmb_dir.TabIndex = 7;
            // 
            // cmb_Disol
            // 
            this.cmb_Disol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Disol.FormattingEnabled = true;
            this.cmb_Disol.Items.AddRange(new object[] {
            "4",
            "5"});
            this.cmb_Disol.Location = new System.Drawing.Point(107, 106);
            this.cmb_Disol.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_Disol.Name = "cmb_Disol";
            this.cmb_Disol.Size = new System.Drawing.Size(82, 23);
            this.cmb_Disol.TabIndex = 6;
            // 
            // cmb_DisInicial
            // 
            this.cmb_DisInicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DisInicial.FormattingEnabled = true;
            this.cmb_DisInicial.Items.AddRange(new object[] {
            "1/10",
            "1/20",
            "1/100",
            "1/200"});
            this.cmb_DisInicial.Location = new System.Drawing.Point(128, 67);
            this.cmb_DisInicial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_DisInicial.Name = "cmb_DisInicial";
            this.cmb_DisInicial.Size = new System.Drawing.Size(82, 23);
            this.cmb_DisInicial.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dirección :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Disoluciones :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Disolución Inicial :";
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(77, 25);
            this.txt_codigo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(104, 23);
            this.txt_codigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código :";
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btn_Cancelar.Location = new System.Drawing.Point(162, 211);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(128, 37);
            this.btn_Cancelar.TabIndex = 5;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Aceptar.Location = new System.Drawing.Point(14, 211);
            this.btn_Aceptar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(132, 37);
            this.btn_Aceptar.TabIndex = 4;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // frmCPEI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 267);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Aceptar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCPEI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCPEI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_dir;
        private System.Windows.Forms.ComboBox cmb_Disol;
        private System.Windows.Forms.ComboBox cmb_DisInicial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Aceptar;
    }
}