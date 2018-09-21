namespace ELISA.UI.UIParametros
{
    partial class KitRotavirus
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_Form = new System.Windows.Forms.GroupBox();
            this.txt_Metodo = new System.Windows.Forms.TextBox();
            this.txt_CasaComercial = new System.Windows.Forms.TextBox();
            this.txt_Lote = new System.Windows.Forms.TextBox();
            this.txt_Codigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_Componentes = new System.Windows.Forms.DataGridView();
            this.menu_Componentes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_masterKit = new System.Windows.Forms.DataGridView();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_Form.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Componentes)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_masterKit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Form
            // 
            this.panel_Form.Controls.Add(this.txt_Metodo);
            this.panel_Form.Controls.Add(this.txt_CasaComercial);
            this.panel_Form.Controls.Add(this.txt_Lote);
            this.panel_Form.Controls.Add(this.txt_Codigo);
            this.panel_Form.Controls.Add(this.label4);
            this.panel_Form.Controls.Add(this.label3);
            this.panel_Form.Controls.Add(this.label2);
            this.panel_Form.Controls.Add(this.label1);
            this.panel_Form.Enabled = false;
            this.panel_Form.Location = new System.Drawing.Point(332, 51);
            this.panel_Form.Name = "panel_Form";
            this.panel_Form.Size = new System.Drawing.Size(238, 183);
            this.panel_Form.TabIndex = 0;
            this.panel_Form.TabStop = false;
            this.panel_Form.Text = "Datos del Kit";
            // 
            // txt_Metodo
            // 
            this.txt_Metodo.Location = new System.Drawing.Point(113, 145);
            this.txt_Metodo.Name = "txt_Metodo";
            this.txt_Metodo.Size = new System.Drawing.Size(116, 23);
            this.txt_Metodo.TabIndex = 7;
            // 
            // txt_CasaComercial
            // 
            this.txt_CasaComercial.Location = new System.Drawing.Point(113, 107);
            this.txt_CasaComercial.Name = "txt_CasaComercial";
            this.txt_CasaComercial.Size = new System.Drawing.Size(116, 23);
            this.txt_CasaComercial.TabIndex = 6;
            // 
            // txt_Lote
            // 
            this.txt_Lote.Location = new System.Drawing.Point(113, 66);
            this.txt_Lote.Name = "txt_Lote";
            this.txt_Lote.Size = new System.Drawing.Size(116, 23);
            this.txt_Lote.TabIndex = 5;
            // 
            // txt_Codigo
            // 
            this.txt_Codigo.Location = new System.Drawing.Point(113, 28);
            this.txt_Codigo.Name = "txt_Codigo";
            this.txt_Codigo.Size = new System.Drawing.Size(116, 23);
            this.txt_Codigo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Método :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Casa Comercial :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lote :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_Componentes);
            this.groupBox2.Location = new System.Drawing.Point(7, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 245);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Componentes del Kit";
            // 
            // dgv_Componentes
            // 
            this.dgv_Componentes.AllowUserToAddRows = false;
            this.dgv_Componentes.AllowUserToDeleteRows = false;
            this.dgv_Componentes.AllowUserToResizeRows = false;
            this.dgv_Componentes.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Componentes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Componentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Componentes.Location = new System.Drawing.Point(8, 24);
            this.dgv_Componentes.Margin = new System.Windows.Forms.Padding(5);
            this.dgv_Componentes.MultiSelect = false;
            this.dgv_Componentes.Name = "dgv_Componentes";
            this.dgv_Componentes.ReadOnly = true;
            this.dgv_Componentes.RowHeadersVisible = false;
            this.dgv_Componentes.ShowCellErrors = false;
            this.dgv_Componentes.ShowRowErrors = false;
            this.dgv_Componentes.Size = new System.Drawing.Size(547, 213);
            this.dgv_Componentes.TabIndex = 0;
            this.dgv_Componentes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Componentes_CellClick);
            // 
            // menu_Componentes
            // 
            this.menu_Componentes.Name = "menu_Componentes";
            this.menu_Componentes.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_masterKit);
            this.groupBox3.Location = new System.Drawing.Point(12, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(314, 216);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lista Kit ELISA Rotavitus";
            // 
            // dgv_masterKit
            // 
            this.dgv_masterKit.AllowUserToAddRows = false;
            this.dgv_masterKit.AllowUserToDeleteRows = false;
            this.dgv_masterKit.AllowUserToOrderColumns = true;
            this.dgv_masterKit.AllowUserToResizeRows = false;
            this.dgv_masterKit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_masterKit.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_masterKit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_masterKit.Location = new System.Drawing.Point(8, 22);
            this.dgv_masterKit.MultiSelect = false;
            this.dgv_masterKit.Name = "dgv_masterKit";
            this.dgv_masterKit.RowHeadersVisible = false;
            this.dgv_masterKit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_masterKit.Size = new System.Drawing.Size(300, 188);
            this.dgv_masterKit.TabIndex = 0;
            this.dgv_masterKit.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_masterKit_CellClick);
            this.dgv_masterKit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_masterKit_MouseClick);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(418, 13);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(76, 30);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Guardar";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.Location = new System.Drawing.Point(342, 13);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(70, 30);
            this.btn_nuevo.TabIndex = 5;
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Enabled = false;
            this.btn_Cancelar.Location = new System.Drawing.Point(500, 13);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(70, 30);
            this.btn_Cancelar.TabIndex = 6;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(427, 490);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 33);
            this.button1.TabIndex = 7;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // KitRotavirus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 535);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_nuevo);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel_Form);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KitRotavirus";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kit ELISA Rotavirus";
            this.panel_Form.ResumeLayout(false);
            this.panel_Form.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Componentes)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_masterKit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox panel_Form;
        private System.Windows.Forms.TextBox txt_Metodo;
        private System.Windows.Forms.TextBox txt_CasaComercial;
        private System.Windows.Forms.TextBox txt_Lote;
        private System.Windows.Forms.TextBox txt_Codigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_Componentes;
        private System.Windows.Forms.ContextMenuStrip menu_Componentes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_masterKit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button button1;
    }
}