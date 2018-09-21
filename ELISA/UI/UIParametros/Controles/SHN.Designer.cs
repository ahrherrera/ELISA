namespace ELISA.UI.UIParametros.Controles
{
    partial class SHN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Controles = new System.Windows.Forms.DataGridView();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Controles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Controles
            // 
            this.dgv_Controles.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Controles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Controles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Controles.Location = new System.Drawing.Point(9, 10);
            this.dgv_Controles.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Controles.Name = "dgv_Controles";
            this.dgv_Controles.RowHeadersVisible = false;
            this.dgv_Controles.RowTemplate.Height = 24;
            this.dgv_Controles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Controles.Size = new System.Drawing.Size(656, 205);
            this.dgv_Controles.TabIndex = 0;
            this.dgv_Controles.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_Controles_CellBeginEdit);
            this.dgv_Controles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Controles_CellClick);
            this.dgv_Controles.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Controles_CellEndEdit);
            this.dgv_Controles.SelectionChanged += new System.EventHandler(this.dgv_Controles_SelectionChanged);
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Agregar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Agregar.Location = new System.Drawing.Point(669, 10);
            this.btn_Agregar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(78, 33);
            this.btn_Agregar.TabIndex = 1;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Eliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Eliminar.Location = new System.Drawing.Point(669, 86);
            this.btn_Eliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(78, 33);
            this.btn_Eliminar.TabIndex = 3;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Refresh.BackgroundImage = global::ELISA.Properties.Resources.refresh_icon;
            this.btn_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Refresh.Location = new System.Drawing.Point(669, 188);
            this.btn_Refresh.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(26, 26);
            this.btn_Refresh.TabIndex = 4;
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Select.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Select.Location = new System.Drawing.Point(669, 150);
            this.btn_Select.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(78, 34);
            this.btn_Select.TabIndex = 5;
            this.btn_Select.Text = "Seleccionar";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Save.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Save.Location = new System.Drawing.Point(669, 48);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(78, 33);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "Guardar";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // SHN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 223);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.dgv_Controles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "SHN";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SHN";
            this.Load += new System.EventHandler(this.Controles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Controles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Controles;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Button btn_Save;
    }
}