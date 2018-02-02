namespace ELISA.UI
{
    partial class Principal
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
            this.cmb_RM = new System.Windows.Forms.ComboBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.cmb_1D = new System.Windows.Forms.ComboBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.rb_Rotavirus = new System.Windows.Forms.RadioButton();
            this.cmb_IgG = new System.Windows.Forms.ComboBox();
            this.rb_IgG = new System.Windows.Forms.RadioButton();
            this.cmb_BOB = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.cmb_EI = new System.Windows.Forms.ComboBox();
            this.cmb_IgM = new System.Windows.Forms.ComboBox();
            this.rb_EI = new System.Windows.Forms.RadioButton();
            this.rb_IgM = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmb_Equipo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.holaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txt_Placa = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.cmb_Lab1 = new System.Windows.Forms.ToolStripComboBox();
            this.cmb_Lab2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.materialTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmb_RM);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.cmb_1D);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.rb_Rotavirus);
            this.groupBox1.Controls.Add(this.cmb_IgG);
            this.groupBox1.Controls.Add(this.rb_IgG);
            this.groupBox1.Controls.Add(this.cmb_BOB);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.cmb_EI);
            this.groupBox1.Controls.Add(this.cmb_IgM);
            this.groupBox1.Controls.Add(this.rb_EI);
            this.groupBox1.Controls.Add(this.rb_IgM);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1221, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el tipo de Test";
            // 
            // cmb_RM
            // 
            this.cmb_RM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_RM.DropDownWidth = 200;
            this.cmb_RM.FormattingEnabled = true;
            this.cmb_RM.Location = new System.Drawing.Point(580, 93);
            this.cmb_RM.Name = "cmb_RM";
            this.cmb_RM.Size = new System.Drawing.Size(241, 28);
            this.cmb_RM.TabIndex = 12;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.radioButton4.Location = new System.Drawing.Point(518, 93);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(59, 23);
            this.radioButton4.TabIndex = 11;
            this.radioButton4.Text = "RM :";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // cmb_1D
            // 
            this.cmb_1D.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_1D.DropDownWidth = 200;
            this.cmb_1D.FormattingEnabled = true;
            this.cmb_1D.Location = new System.Drawing.Point(245, 93);
            this.cmb_1D.Name = "cmb_1D";
            this.cmb_1D.Size = new System.Drawing.Size(221, 28);
            this.cmb_1D.TabIndex = 10;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.radioButton3.Location = new System.Drawing.Point(183, 93);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(49, 23);
            this.radioButton3.TabIndex = 9;
            this.radioButton3.Text = "1D:";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_Rotavirus
            // 
            this.rb_Rotavirus.AutoSize = true;
            this.rb_Rotavirus.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.rb_Rotavirus.Location = new System.Drawing.Point(854, 93);
            this.rb_Rotavirus.Name = "rb_Rotavirus";
            this.rb_Rotavirus.Size = new System.Drawing.Size(89, 23);
            this.rb_Rotavirus.TabIndex = 8;
            this.rb_Rotavirus.Text = "Rotavirus";
            this.rb_Rotavirus.UseVisualStyleBackColor = true;
            this.rb_Rotavirus.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // cmb_IgG
            // 
            this.cmb_IgG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_IgG.DropDownWidth = 200;
            this.cmb_IgG.FormattingEnabled = true;
            this.cmb_IgG.Location = new System.Drawing.Point(985, 39);
            this.cmb_IgG.Name = "cmb_IgG";
            this.cmb_IgG.Size = new System.Drawing.Size(213, 28);
            this.cmb_IgG.TabIndex = 7;
            // 
            // rb_IgG
            // 
            this.rb_IgG.AutoSize = true;
            this.rb_IgG.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.rb_IgG.Location = new System.Drawing.Point(923, 39);
            this.rb_IgG.Name = "rb_IgG";
            this.rb_IgG.Size = new System.Drawing.Size(59, 23);
            this.rb_IgG.TabIndex = 6;
            this.rb_IgG.Text = "IgG :";
            this.rb_IgG.UseVisualStyleBackColor = true;
            this.rb_IgG.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // cmb_BOB
            // 
            this.cmb_BOB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_BOB.DropDownWidth = 200;
            this.cmb_BOB.FormattingEnabled = true;
            this.cmb_BOB.Location = new System.Drawing.Point(704, 39);
            this.cmb_BOB.Name = "cmb_BOB";
            this.cmb_BOB.Size = new System.Drawing.Size(199, 28);
            this.cmb_BOB.TabIndex = 5;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(636, 39);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(64, 23);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "BOB :";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // cmb_EI
            // 
            this.cmb_EI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EI.DropDownWidth = 200;
            this.cmb_EI.FormattingEnabled = true;
            this.cmb_EI.Location = new System.Drawing.Point(398, 39);
            this.cmb_EI.Name = "cmb_EI";
            this.cmb_EI.Size = new System.Drawing.Size(220, 28);
            this.cmb_EI.TabIndex = 3;
            // 
            // cmb_IgM
            // 
            this.cmb_IgM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_IgM.DropDownWidth = 200;
            this.cmb_IgM.FormattingEnabled = true;
            this.cmb_IgM.Location = new System.Drawing.Point(85, 39);
            this.cmb_IgM.Name = "cmb_IgM";
            this.cmb_IgM.Size = new System.Drawing.Size(239, 28);
            this.cmb_IgM.TabIndex = 2;
            // 
            // rb_EI
            // 
            this.rb_EI.AutoSize = true;
            this.rb_EI.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_EI.Location = new System.Drawing.Point(349, 39);
            this.rb_EI.Name = "rb_EI";
            this.rb_EI.Size = new System.Drawing.Size(48, 23);
            this.rb_EI.TabIndex = 1;
            this.rb_EI.Text = "EI :";
            this.rb_EI.UseVisualStyleBackColor = true;
            this.rb_EI.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_IgM
            // 
            this.rb_IgM.AutoSize = true;
            this.rb_IgM.Checked = true;
            this.rb_IgM.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_IgM.Location = new System.Drawing.Point(23, 39);
            this.rb_IgM.Name = "rb_IgM";
            this.rb_IgM.Size = new System.Drawing.Size(62, 23);
            this.rb_IgM.TabIndex = 0;
            this.rb_IgM.TabStop = true;
            this.rb_IgM.Text = "IgM :";
            this.rb_IgM.UseVisualStyleBackColor = true;
            this.rb_IgM.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cmb_Equipo,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.txt_Placa,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.cmb_Lab1,
            this.toolStripLabel4,
            this.cmb_Lab2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1284, 30);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(154, 25);
            this.toolStripLabel1.Text = "Seleccione el Equipo :";
            // 
            // cmb_Equipo
            // 
            this.cmb_Equipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Equipo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_Equipo.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.cmb_Equipo.Name = "cmb_Equipo";
            this.cmb_Equipo.Size = new System.Drawing.Size(140, 28);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.holaToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 24);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // holaToolStripMenuItem
            // 
            this.holaToolStripMenuItem.Name = "holaToolStripMenuItem";
            this.holaToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.holaToolStripMenuItem.Text = "Hola";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.toolStripLabel2.Size = new System.Drawing.Size(55, 25);
            this.toolStripLabel2.Text = "Placa :";
            // 
            // txt_Placa
            // 
            this.txt_Placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Placa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Placa.Name = "txt_Placa";
            this.txt_Placa.Size = new System.Drawing.Size(120, 30);
            this.txt_Placa.Tag = "";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(116, 25);
            this.toolStripLabel3.Text = "Laboratorista 1 :";
            // 
            // cmb_Lab1
            // 
            this.cmb_Lab1.AutoSize = false;
            this.cmb_Lab1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Lab1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_Lab1.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.cmb_Lab1.Name = "cmb_Lab1";
            this.cmb_Lab1.Size = new System.Drawing.Size(170, 28);
            // 
            // cmb_Lab2
            // 
            this.cmb_Lab2.AutoSize = false;
            this.cmb_Lab2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Lab2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_Lab2.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.cmb_Lab2.Name = "cmb_Lab2";
            this.cmb_Lab2.Size = new System.Drawing.Size(170, 28);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(116, 25);
            this.toolStripLabel4.Text = "Laboratorista 2 :";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialTabControl1.Location = new System.Drawing.Point(32, 241);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1221, 455);
            this.materialTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.materialTabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1213, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(762, 310);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 836);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Centro Nacional de Diagnóstico y Referencia | Departamento de Virología | ELISA S" +
    "oftware";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.materialTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_Rotavirus;
        private System.Windows.Forms.ComboBox cmb_IgG;
        private System.Windows.Forms.RadioButton rb_IgG;
        private System.Windows.Forms.ComboBox cmb_BOB;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox cmb_EI;
        private System.Windows.Forms.ComboBox cmb_IgM;
        private System.Windows.Forms.RadioButton rb_EI;
        private System.Windows.Forms.RadioButton rb_IgM;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ComboBox cmb_RM;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.ComboBox cmb_1D;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ToolStripComboBox cmb_Equipo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem holaToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txt_Placa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox cmb_Lab1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox cmb_Lab2;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}