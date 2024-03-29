﻿namespace Headline_Randomizer
{
    partial class Settings
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Database = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numWriteColumn = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveToTxt = new System.Windows.Forms.Button();
            this.gbAddRow = new System.Windows.Forms.GroupBox();
            this.cbCensur = new System.Windows.Forms.ComboBox();
            this.cbTermFor = new System.Windows.Forms.ComboBox();
            this.cbGenus = new System.Windows.Forms.ComboBox();
            this.cbRelation = new System.Windows.Forms.ComboBox();
            this.lblCensur = new System.Windows.Forms.Label();
            this.lblRelation = new System.Windows.Forms.Label();
            this.lblGenus = new System.Windows.Forms.Label();
            this.lblTermFor = new System.Windows.Forms.Label();
            this.lblColumn5 = new System.Windows.Forms.Label();
            this.tbxAddColumn5 = new System.Windows.Forms.TextBox();
            this.lblColumn4 = new System.Windows.Forms.Label();
            this.tbxAddColumn4 = new System.Windows.Forms.TextBox();
            this.lblColumn3 = new System.Windows.Forms.Label();
            this.tbxAddColumn3 = new System.Windows.Forms.TextBox();
            this.lblColumn2 = new System.Windows.Forms.Label();
            this.tbxAddColumn2 = new System.Windows.Forms.TextBox();
            this.lblColumn1 = new System.Windows.Forms.Label();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.tbxAddColumn1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numDeleteRow = new System.Windows.Forms.NumericUpDown();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbUpdateValue = new System.Windows.Forms.ComboBox();
            this.numChangeColumn = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numChangeRow = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeValue = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTabell = new System.Windows.Forms.ComboBox();
            this.DbDisplay = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblKlar = new System.Windows.Forms.Label();
            this.pBarDatabase = new System.Windows.Forms.ProgressBar();
            this.btnLoadFromBackup = new System.Windows.Forms.Button();
            this.btnSaveToBackup = new System.Windows.Forms.Button();
            this.btnResetDb = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbxUnoffendable = new System.Windows.Forms.CheckBox();
            this.cbxAdults = new System.Windows.Forms.CheckBox();
            this.cbxAdolescents = new System.Windows.Forms.CheckBox();
            this.cbxChildren = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.Database.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWriteColumn)).BeginInit();
            this.gbAddRow.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDeleteRow)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeRow)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DbDisplay)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Database);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(11, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(874, 579);
            this.tabControl1.TabIndex = 1;
            // 
            // Database
            // 
            this.Database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Database.Controls.Add(this.groupBox4);
            this.Database.Controls.Add(this.gbAddRow);
            this.Database.Controls.Add(this.groupBox3);
            this.Database.Controls.Add(this.groupBox2);
            this.Database.Controls.Add(this.groupBox1);
            this.Database.Controls.Add(this.DbDisplay);
            this.Database.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Database.Location = new System.Drawing.Point(4, 28);
            this.Database.Name = "Database";
            this.Database.Padding = new System.Windows.Forms.Padding(3);
            this.Database.Size = new System.Drawing.Size(866, 547);
            this.Database.TabIndex = 1;
            this.Database.Text = "Databas";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.numWriteColumn);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnSaveToTxt);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(717, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(129, 101);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Exportera";
            // 
            // numWriteColumn
            // 
            this.numWriteColumn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numWriteColumn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWriteColumn.Location = new System.Drawing.Point(71, 24);
            this.numWriteColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWriteColumn.Name = "numWriteColumn";
            this.numWriteColumn.Size = new System.Drawing.Size(45, 27);
            this.numWriteColumn.TabIndex = 25;
            this.numWriteColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numWriteColumn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Kolumn";
            // 
            // btnSaveToTxt
            // 
            this.btnSaveToTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSaveToTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveToTxt.Location = new System.Drawing.Point(15, 62);
            this.btnSaveToTxt.Name = "btnSaveToTxt";
            this.btnSaveToTxt.Size = new System.Drawing.Size(101, 27);
            this.btnSaveToTxt.TabIndex = 0;
            this.btnSaveToTxt.Text = "Välj mapp";
            this.btnSaveToTxt.UseVisualStyleBackColor = false;
            this.btnSaveToTxt.Click += new System.EventHandler(this.BtnSaveToTxt_Click);
            // 
            // gbAddRow
            // 
            this.gbAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAddRow.Controls.Add(this.cbCensur);
            this.gbAddRow.Controls.Add(this.cbTermFor);
            this.gbAddRow.Controls.Add(this.cbGenus);
            this.gbAddRow.Controls.Add(this.cbRelation);
            this.gbAddRow.Controls.Add(this.lblCensur);
            this.gbAddRow.Controls.Add(this.lblRelation);
            this.gbAddRow.Controls.Add(this.lblGenus);
            this.gbAddRow.Controls.Add(this.lblTermFor);
            this.gbAddRow.Controls.Add(this.lblColumn5);
            this.gbAddRow.Controls.Add(this.tbxAddColumn5);
            this.gbAddRow.Controls.Add(this.lblColumn4);
            this.gbAddRow.Controls.Add(this.tbxAddColumn4);
            this.gbAddRow.Controls.Add(this.lblColumn3);
            this.gbAddRow.Controls.Add(this.tbxAddColumn3);
            this.gbAddRow.Controls.Add(this.lblColumn2);
            this.gbAddRow.Controls.Add(this.tbxAddColumn2);
            this.gbAddRow.Controls.Add(this.lblColumn1);
            this.gbAddRow.Controls.Add(this.btnAddRow);
            this.gbAddRow.Controls.Add(this.tbxAddColumn1);
            this.gbAddRow.ForeColor = System.Drawing.Color.White;
            this.gbAddRow.Location = new System.Drawing.Point(19, 113);
            this.gbAddRow.Margin = new System.Windows.Forms.Padding(2);
            this.gbAddRow.Name = "gbAddRow";
            this.gbAddRow.Padding = new System.Windows.Forms.Padding(2);
            this.gbAddRow.Size = new System.Drawing.Size(827, 140);
            this.gbAddRow.TabIndex = 7;
            this.gbAddRow.TabStop = false;
            this.gbAddRow.Text = "Lägg till rad";
            // 
            // cbCensur
            // 
            this.cbCensur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCensur.FormattingEnabled = true;
            this.cbCensur.Items.AddRange(new object[] {
            "Barn",
            "Ungdomar",
            "Vuxna",
            "Okränkbara"});
            this.cbCensur.Location = new System.Drawing.Point(515, 97);
            this.cbCensur.Name = "cbCensur";
            this.cbCensur.Size = new System.Drawing.Size(130, 27);
            this.cbCensur.TabIndex = 8;
            // 
            // cbTermFor
            // 
            this.cbTermFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTermFor.FormattingEnabled = true;
            this.cbTermFor.Items.AddRange(new object[] {
            "Någon",
            "Något",
            "Plats",
            "Någon & Plats",
            "Någon & Något"});
            this.cbTermFor.Location = new System.Drawing.Point(30, 97);
            this.cbTermFor.Name = "cbTermFor";
            this.cbTermFor.Size = new System.Drawing.Size(130, 27);
            this.cbTermFor.TabIndex = 23;
            // 
            // cbGenus
            // 
            this.cbGenus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenus.FormattingEnabled = true;
            this.cbGenus.Items.AddRange(new object[] {
            "N-genus",
            "T-genus",
            "N-undantag",
            "T-undantag"});
            this.cbGenus.Location = new System.Drawing.Point(192, 97);
            this.cbGenus.Name = "cbGenus";
            this.cbGenus.Size = new System.Drawing.Size(130, 27);
            this.cbGenus.TabIndex = 22;
            // 
            // cbRelation
            // 
            this.cbRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRelation.FormattingEnabled = true;
            this.cbRelation.Items.AddRange(new object[] {
            "Någon (Strikt)",
            "Någon",
            "Relation (Strikt)",
            "Relation",
            "Någon & Något",
            "Relation & Något",
            "Relation (Strikt)",
            "Något",
            "Något (Strikt)"});
            this.cbRelation.Location = new System.Drawing.Point(354, 97);
            this.cbRelation.Name = "cbRelation";
            this.cbRelation.Size = new System.Drawing.Size(130, 27);
            this.cbRelation.TabIndex = 21;
            // 
            // lblCensur
            // 
            this.lblCensur.AutoSize = true;
            this.lblCensur.Location = new System.Drawing.Point(512, 77);
            this.lblCensur.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCensur.Name = "lblCensur";
            this.lblCensur.Size = new System.Drawing.Size(87, 19);
            this.lblCensur.TabIndex = 20;
            this.lblCensur.Text = "Lämpligt för";
            // 
            // lblRelation
            // 
            this.lblRelation.AutoSize = true;
            this.lblRelation.Location = new System.Drawing.Point(351, 77);
            this.lblRelation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRelation.Name = "lblRelation";
            this.lblRelation.Size = new System.Drawing.Size(52, 19);
            this.lblRelation.TabIndex = 18;
            this.lblRelation.Text = "Passar";
            // 
            // lblGenus
            // 
            this.lblGenus.AutoSize = true;
            this.lblGenus.Location = new System.Drawing.Point(189, 77);
            this.lblGenus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGenus.Name = "lblGenus";
            this.lblGenus.Size = new System.Drawing.Size(50, 19);
            this.lblGenus.TabIndex = 16;
            this.lblGenus.Text = "Genus";
            // 
            // lblTermFor
            // 
            this.lblTermFor.AutoSize = true;
            this.lblTermFor.Location = new System.Drawing.Point(26, 77);
            this.lblTermFor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTermFor.Name = "lblTermFor";
            this.lblTermFor.Size = new System.Drawing.Size(75, 19);
            this.lblTermFor.TabIndex = 14;
            this.lblTermFor.Text = "Benämner";
            // 
            // lblColumn5
            // 
            this.lblColumn5.AutoSize = true;
            this.lblColumn5.Location = new System.Drawing.Point(668, 25);
            this.lblColumn5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColumn5.Name = "lblColumn5";
            this.lblColumn5.Size = new System.Drawing.Size(69, 19);
            this.lblColumn5.TabIndex = 12;
            this.lblColumn5.Text = "Kolumn 5";
            // 
            // tbxAddColumn5
            // 
            this.tbxAddColumn5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAddColumn5.Location = new System.Drawing.Point(671, 45);
            this.tbxAddColumn5.Margin = new System.Windows.Forms.Padding(2);
            this.tbxAddColumn5.Name = "tbxAddColumn5";
            this.tbxAddColumn5.Size = new System.Drawing.Size(130, 27);
            this.tbxAddColumn5.TabIndex = 4;
            // 
            // lblColumn4
            // 
            this.lblColumn4.AutoSize = true;
            this.lblColumn4.Location = new System.Drawing.Point(511, 25);
            this.lblColumn4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColumn4.Name = "lblColumn4";
            this.lblColumn4.Size = new System.Drawing.Size(69, 19);
            this.lblColumn4.TabIndex = 10;
            this.lblColumn4.Text = "Kolumn 4";
            // 
            // tbxAddColumn4
            // 
            this.tbxAddColumn4.BackColor = System.Drawing.Color.White;
            this.tbxAddColumn4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAddColumn4.Location = new System.Drawing.Point(514, 45);
            this.tbxAddColumn4.Margin = new System.Windows.Forms.Padding(2);
            this.tbxAddColumn4.Name = "tbxAddColumn4";
            this.tbxAddColumn4.Size = new System.Drawing.Size(130, 27);
            this.tbxAddColumn4.TabIndex = 3;
            // 
            // lblColumn3
            // 
            this.lblColumn3.AutoSize = true;
            this.lblColumn3.Location = new System.Drawing.Point(351, 25);
            this.lblColumn3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColumn3.Name = "lblColumn3";
            this.lblColumn3.Size = new System.Drawing.Size(69, 19);
            this.lblColumn3.TabIndex = 8;
            this.lblColumn3.Text = "Kolumn 3";
            // 
            // tbxAddColumn3
            // 
            this.tbxAddColumn3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAddColumn3.Location = new System.Drawing.Point(354, 45);
            this.tbxAddColumn3.Margin = new System.Windows.Forms.Padding(2);
            this.tbxAddColumn3.Name = "tbxAddColumn3";
            this.tbxAddColumn3.Size = new System.Drawing.Size(130, 27);
            this.tbxAddColumn3.TabIndex = 2;
            // 
            // lblColumn2
            // 
            this.lblColumn2.AutoSize = true;
            this.lblColumn2.Location = new System.Drawing.Point(189, 25);
            this.lblColumn2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColumn2.Name = "lblColumn2";
            this.lblColumn2.Size = new System.Drawing.Size(69, 19);
            this.lblColumn2.TabIndex = 6;
            this.lblColumn2.Text = "Kolumn 2";
            // 
            // tbxAddColumn2
            // 
            this.tbxAddColumn2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAddColumn2.Location = new System.Drawing.Point(192, 45);
            this.tbxAddColumn2.Margin = new System.Windows.Forms.Padding(2);
            this.tbxAddColumn2.Name = "tbxAddColumn2";
            this.tbxAddColumn2.Size = new System.Drawing.Size(130, 27);
            this.tbxAddColumn2.TabIndex = 1;
            // 
            // lblColumn1
            // 
            this.lblColumn1.AutoSize = true;
            this.lblColumn1.Location = new System.Drawing.Point(27, 25);
            this.lblColumn1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColumn1.Name = "lblColumn1";
            this.lblColumn1.Size = new System.Drawing.Size(69, 19);
            this.lblColumn1.TabIndex = 4;
            this.lblColumn1.Text = "Kolumn 1";
            // 
            // btnAddRow
            // 
            this.btnAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRow.ForeColor = System.Drawing.Color.White;
            this.btnAddRow.Location = new System.Drawing.Point(671, 88);
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(129, 43);
            this.btnAddRow.TabIndex = 9;
            this.btnAddRow.Text = "Lägg till";
            this.btnAddRow.UseVisualStyleBackColor = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // tbxAddColumn1
            // 
            this.tbxAddColumn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAddColumn1.Location = new System.Drawing.Point(30, 45);
            this.tbxAddColumn1.Margin = new System.Windows.Forms.Padding(2);
            this.tbxAddColumn1.Name = "tbxAddColumn1";
            this.tbxAddColumn1.Size = new System.Drawing.Size(131, 27);
            this.tbxAddColumn1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.numDeleteRow);
            this.groupBox3.Controls.Add(this.btnDeleteRow);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(583, 8);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(123, 101);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ta bort rad";
            // 
            // numDeleteRow
            // 
            this.numDeleteRow.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDeleteRow.Location = new System.Drawing.Point(52, 25);
            this.numDeleteRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDeleteRow.Name = "numDeleteRow";
            this.numDeleteRow.Size = new System.Drawing.Size(52, 27);
            this.numDeleteRow.TabIndex = 0;
            this.numDeleteRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numDeleteRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDeleteRow.ValueChanged += new System.EventHandler(this.NumDeleteRow_ValueChanged);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRow.ForeColor = System.Drawing.Color.White;
            this.btnDeleteRow.Location = new System.Drawing.Point(20, 62);
            this.btnDeleteRow.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(84, 27);
            this.btnDeleteRow.TabIndex = 1;
            this.btnDeleteRow.Text = "Ta bort";
            this.btnDeleteRow.UseVisualStyleBackColor = false;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Rad";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.cbUpdateValue);
            this.groupBox2.Controls.Add(this.numChangeColumn);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numChangeRow);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnChangeValue);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(268, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(304, 101);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ändra i cell";
            // 
            // cbUpdateValue
            // 
            this.cbUpdateValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbUpdateValue.FormattingEnabled = true;
            this.cbUpdateValue.Location = new System.Drawing.Point(127, 23);
            this.cbUpdateValue.Name = "cbUpdateValue";
            this.cbUpdateValue.Size = new System.Drawing.Size(167, 27);
            this.cbUpdateValue.TabIndex = 24;
            this.cbUpdateValue.SelectedIndexChanged += new System.EventHandler(this.cbUpdateValue_SelectedIndexChanged);
            this.cbUpdateValue.TextUpdate += new System.EventHandler(this.cbUpdateValue_TextUpdate);
            // 
            // numChangeColumn
            // 
            this.numChangeColumn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numChangeColumn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numChangeColumn.Location = new System.Drawing.Point(67, 62);
            this.numChangeColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChangeColumn.Name = "numChangeColumn";
            this.numChangeColumn.Size = new System.Drawing.Size(45, 27);
            this.numChangeColumn.TabIndex = 1;
            this.numChangeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numChangeColumn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChangeColumn.ValueChanged += new System.EventHandler(this.numChangeColumn_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kolumn";
            // 
            // numChangeRow
            // 
            this.numChangeRow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numChangeRow.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numChangeRow.Location = new System.Drawing.Point(67, 24);
            this.numChangeRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChangeRow.Name = "numChangeRow";
            this.numChangeRow.Size = new System.Drawing.Size(45, 27);
            this.numChangeRow.TabIndex = 0;
            this.numChangeRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numChangeRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChangeRow.ValueChanged += new System.EventHandler(this.NumChangeRow_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rad";
            // 
            // btnChangeValue
            // 
            this.btnChangeValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnChangeValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChangeValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeValue.ForeColor = System.Drawing.Color.White;
            this.btnChangeValue.Location = new System.Drawing.Point(127, 62);
            this.btnChangeValue.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangeValue.Name = "btnChangeValue";
            this.btnChangeValue.Size = new System.Drawing.Size(166, 27);
            this.btnChangeValue.TabIndex = 3;
            this.btnChangeValue.Text = "Ändra";
            this.btnChangeValue.UseVisualStyleBackColor = false;
            this.btnChangeValue.Click += new System.EventHandler(this.btnChangeValue_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTabell);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(19, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(239, 101);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Välj tabell";
            // 
            // cbTabell
            // 
            this.cbTabell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTabell.FormattingEnabled = true;
            this.cbTabell.Items.AddRange(new object[] {
            "Adjektiv",
            "Substantiv",
            "Verb",
            "Skämtnamn",
            "Nobelpriser",
            "Sparade resultat"});
            this.cbTabell.Location = new System.Drawing.Point(18, 44);
            this.cbTabell.Margin = new System.Windows.Forms.Padding(2);
            this.cbTabell.Name = "cbTabell";
            this.cbTabell.Size = new System.Drawing.Size(205, 27);
            this.cbTabell.TabIndex = 1;
            this.cbTabell.SelectedIndexChanged += new System.EventHandler(this.CbTabell_SelectedIndexChanged);
            this.cbTabell.SelectionChangeCommitted += new System.EventHandler(this.cbTabell_SelectionChangeCommitted);
            // 
            // DbDisplay
            // 
            this.DbDisplay.AllowUserToAddRows = false;
            this.DbDisplay.AllowUserToDeleteRows = false;
            this.DbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DbDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DbDisplay.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DbDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DbDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DbDisplay.Location = new System.Drawing.Point(-4, 261);
            this.DbDisplay.MultiSelect = false;
            this.DbDisplay.Name = "DbDisplay";
            this.DbDisplay.ReadOnly = true;
            this.DbDisplay.RowHeadersWidth = 25;
            this.DbDisplay.Size = new System.Drawing.Size(874, 289);
            this.DbDisplay.TabIndex = 0;
            this.DbDisplay.CurrentCellChanged += new System.EventHandler(this.DbDisplay_CurrentCellChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(866, 547);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inställningar";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.lblKlar);
            this.groupBox6.Controls.Add(this.pBarDatabase);
            this.groupBox6.Controls.Add(this.btnLoadFromBackup);
            this.groupBox6.Controls.Add(this.btnSaveToBackup);
            this.groupBox6.Controls.Add(this.btnResetDb);
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(283, 37);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(552, 204);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Spara/Ladda databas";
            // 
            // lblKlar
            // 
            this.lblKlar.AutoSize = true;
            this.lblKlar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
            this.lblKlar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKlar.ForeColor = System.Drawing.Color.White;
            this.lblKlar.Location = new System.Drawing.Point(257, 156);
            this.lblKlar.Name = "lblKlar";
            this.lblKlar.Size = new System.Drawing.Size(42, 19);
            this.lblKlar.TabIndex = 4;
            this.lblKlar.Text = "Klart";
            this.lblKlar.Visible = false;
            // 
            // pBarDatabase
            // 
            this.pBarDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBarDatabase.Location = new System.Drawing.Point(26, 151);
            this.pBarDatabase.Name = "pBarDatabase";
            this.pBarDatabase.Size = new System.Drawing.Size(500, 30);
            this.pBarDatabase.Step = 13;
            this.pBarDatabase.TabIndex = 3;
            // 
            // btnLoadFromBackup
            // 
            this.btnLoadFromBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFromBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoadFromBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadFromBackup.Location = new System.Drawing.Point(377, 37);
            this.btnLoadFromBackup.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadFromBackup.Name = "btnLoadFromBackup";
            this.btnLoadFromBackup.Size = new System.Drawing.Size(149, 91);
            this.btnLoadFromBackup.TabIndex = 2;
            this.btnLoadFromBackup.Text = "Återställ från säkerhetskopia";
            this.btnLoadFromBackup.UseVisualStyleBackColor = false;
            this.btnLoadFromBackup.Click += new System.EventHandler(this.btnLoadFromBackup_Click);
            // 
            // btnSaveToBackup
            // 
            this.btnSaveToBackup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSaveToBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSaveToBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveToBackup.Location = new System.Drawing.Point(203, 37);
            this.btnSaveToBackup.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveToBackup.Name = "btnSaveToBackup";
            this.btnSaveToBackup.Size = new System.Drawing.Size(149, 91);
            this.btnSaveToBackup.TabIndex = 1;
            this.btnSaveToBackup.Text = "Säkerhetkopiera databas";
            this.btnSaveToBackup.UseVisualStyleBackColor = false;
            this.btnSaveToBackup.Click += new System.EventHandler(this.btnSaveToBackup_Click);
            // 
            // btnResetDb
            // 
            this.btnResetDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnResetDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetDb.Location = new System.Drawing.Point(26, 37);
            this.btnResetDb.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetDb.Name = "btnResetDb";
            this.btnResetDb.Size = new System.Drawing.Size(149, 91);
            this.btnResetDb.TabIndex = 0;
            this.btnResetDb.Text = "Återställ från fabriksinställningar";
            this.btnResetDb.UseVisualStyleBackColor = false;
            this.btnResetDb.Click += new System.EventHandler(this.btnResetDb_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbxUnoffendable);
            this.groupBox5.Controls.Add(this.cbxAdults);
            this.groupBox5.Controls.Add(this.cbxAdolescents);
            this.groupBox5.Controls.Add(this.cbxChildren);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(36, 37);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(213, 204);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Visa ord som passar...";
            // 
            // cbxUnoffendable
            // 
            this.cbxUnoffendable.AutoSize = true;
            this.cbxUnoffendable.Location = new System.Drawing.Point(34, 145);
            this.cbxUnoffendable.Name = "cbxUnoffendable";
            this.cbxUnoffendable.Size = new System.Drawing.Size(103, 23);
            this.cbxUnoffendable.TabIndex = 3;
            this.cbxUnoffendable.Text = "Okränkbara";
            this.cbxUnoffendable.UseVisualStyleBackColor = true;
            this.cbxUnoffendable.CheckedChanged += new System.EventHandler(this.cbxUnoffendable_CheckedChanged);
            // 
            // cbxAdults
            // 
            this.cbxAdults.AutoSize = true;
            this.cbxAdults.Location = new System.Drawing.Point(34, 112);
            this.cbxAdults.Name = "cbxAdults";
            this.cbxAdults.Size = new System.Drawing.Size(68, 23);
            this.cbxAdults.TabIndex = 2;
            this.cbxAdults.Text = "Vuxna";
            this.cbxAdults.UseVisualStyleBackColor = true;
            this.cbxAdults.CheckedChanged += new System.EventHandler(this.cbxAdults_CheckedChanged);
            // 
            // cbxAdolescents
            // 
            this.cbxAdolescents.AutoSize = true;
            this.cbxAdolescents.Location = new System.Drawing.Point(34, 79);
            this.cbxAdolescents.Name = "cbxAdolescents";
            this.cbxAdolescents.Size = new System.Drawing.Size(95, 23);
            this.cbxAdolescents.TabIndex = 1;
            this.cbxAdolescents.Text = "Ungdomar";
            this.cbxAdolescents.UseVisualStyleBackColor = true;
            this.cbxAdolescents.CheckedChanged += new System.EventHandler(this.cbxAdolescents_CheckedChanged);
            // 
            // cbxChildren
            // 
            this.cbxChildren.AutoSize = true;
            this.cbxChildren.Checked = true;
            this.cbxChildren.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxChildren.Enabled = false;
            this.cbxChildren.Location = new System.Drawing.Point(34, 47);
            this.cbxChildren.Name = "cbxChildren";
            this.cbxChildren.Size = new System.Drawing.Size(58, 23);
            this.cbxChildren.TabIndex = 0;
            this.cbxChildren.Text = "Barn";
            this.cbxChildren.UseVisualStyleBackColor = true;
            this.cbxChildren.CheckedChanged += new System.EventHandler(this.cbxChildren_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(895, 599);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(890, 638);
            this.Name = "Settings";
            this.Text = "Settings";
            this.TopMost = true;
            this.SizeChanged += new System.EventHandler(this.Options_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.Database.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWriteColumn)).EndInit();
            this.gbAddRow.ResumeLayout(false);
            this.gbAddRow.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDeleteRow)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeRow)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DbDisplay)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Database;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numWriteColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveToTxt;
        private System.Windows.Forms.GroupBox gbAddRow;
        private System.Windows.Forms.ComboBox cbCensur;
        private System.Windows.Forms.ComboBox cbTermFor;
        private System.Windows.Forms.ComboBox cbGenus;
        private System.Windows.Forms.ComboBox cbRelation;
        private System.Windows.Forms.Label lblCensur;
        private System.Windows.Forms.Label lblRelation;
        private System.Windows.Forms.Label lblGenus;
        private System.Windows.Forms.Label lblTermFor;
        private System.Windows.Forms.Label lblColumn5;
        private System.Windows.Forms.TextBox tbxAddColumn5;
        private System.Windows.Forms.Label lblColumn4;
        private System.Windows.Forms.TextBox tbxAddColumn4;
        private System.Windows.Forms.Label lblColumn3;
        private System.Windows.Forms.TextBox tbxAddColumn3;
        private System.Windows.Forms.Label lblColumn2;
        private System.Windows.Forms.TextBox tbxAddColumn2;
        private System.Windows.Forms.Label lblColumn1;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.TextBox tbxAddColumn1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numDeleteRow;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbUpdateValue;
        private System.Windows.Forms.NumericUpDown numChangeColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numChangeRow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbTabell;
        private System.Windows.Forms.DataGridView DbDisplay;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnLoadFromBackup;
        private System.Windows.Forms.Button btnSaveToBackup;
        private System.Windows.Forms.Button btnResetDb;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbxUnoffendable;
        private System.Windows.Forms.CheckBox cbxAdults;
        private System.Windows.Forms.CheckBox cbxAdolescents;
        private System.Windows.Forms.CheckBox cbxChildren;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ProgressBar pBarDatabase;
        private System.Windows.Forms.Label lblKlar;
    }
}