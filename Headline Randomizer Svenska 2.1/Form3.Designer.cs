namespace Headline_Randomizer
{
    partial class Options
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
            this.Settings = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnResetDb = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbxOffensive = new System.Windows.Forms.CheckBox();
            this.cbxSex = new System.Windows.Forms.CheckBox();
            this.cbxViolence = new System.Windows.Forms.CheckBox();
            this.cbxRegular = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.Database.SuspendLayout();
            this.gbAddRow.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDeleteRow)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeRow)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DbDisplay)).BeginInit();
            this.Settings.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.Settings);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(10, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 579);
            this.tabControl1.TabIndex = 0;
            // 
            // Database
            // 
            this.Database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Database.Controls.Add(this.gbAddRow);
            this.Database.Controls.Add(this.groupBox3);
            this.Database.Controls.Add(this.groupBox2);
            this.Database.Controls.Add(this.groupBox1);
            this.Database.Controls.Add(this.DbDisplay);
            this.Database.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Database.Location = new System.Drawing.Point(4, 28);
            this.Database.Name = "Database";
            this.Database.Padding = new System.Windows.Forms.Padding(3);
            this.Database.Size = new System.Drawing.Size(792, 547);
            this.Database.TabIndex = 1;
            this.Database.Text = "Databas";
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
            this.gbAddRow.Size = new System.Drawing.Size(753, 140);
            this.gbAddRow.TabIndex = 7;
            this.gbAddRow.TabStop = false;
            this.gbAddRow.Text = "Lägg till rad";
            // 
            // cbCensur
            // 
            this.cbCensur.FormattingEnabled = true;
            this.cbCensur.Items.AddRange(new object[] {
            "0 (Censurera ej)",
            "1 (Sex/droger)"});
            this.cbCensur.Location = new System.Drawing.Point(451, 97);
            this.cbCensur.Name = "cbCensur";
            this.cbCensur.Size = new System.Drawing.Size(130, 27);
            this.cbCensur.TabIndex = 8;
            // 
            // cbTermFor
            // 
            this.cbTermFor.FormattingEnabled = true;
            this.cbTermFor.Items.AddRange(new object[] {
            "Någon",
            "Något",
            "Plats",
            "Någon & Plats",
            "Någon & Något"});
            this.cbTermFor.Location = new System.Drawing.Point(21, 97);
            this.cbTermFor.Name = "cbTermFor";
            this.cbTermFor.Size = new System.Drawing.Size(130, 27);
            this.cbTermFor.TabIndex = 23;
            // 
            // cbGenus
            // 
            this.cbGenus.FormattingEnabled = true;
            this.cbGenus.Items.AddRange(new object[] {
            "N-genus",
            "T-genus",
            "N-undantag",
            "T-undantag"});
            this.cbGenus.Location = new System.Drawing.Point(164, 97);
            this.cbGenus.Name = "cbGenus";
            this.cbGenus.Size = new System.Drawing.Size(130, 27);
            this.cbGenus.TabIndex = 22;
            // 
            // cbRelation
            // 
            this.cbRelation.FormattingEnabled = true;
            this.cbRelation.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbRelation.Location = new System.Drawing.Point(307, 97);
            this.cbRelation.Name = "cbRelation";
            this.cbRelation.Size = new System.Drawing.Size(130, 27);
            this.cbRelation.TabIndex = 21;
            // 
            // lblCensur
            // 
            this.lblCensur.AutoSize = true;
            this.lblCensur.Location = new System.Drawing.Point(448, 77);
            this.lblCensur.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCensur.Name = "lblCensur";
            this.lblCensur.Size = new System.Drawing.Size(107, 19);
            this.lblCensur.TabIndex = 20;
            this.lblCensur.Text = "Censurkategori";
            // 
            // lblRelation
            // 
            this.lblRelation.AutoSize = true;
            this.lblRelation.Location = new System.Drawing.Point(304, 77);
            this.lblRelation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRelation.Name = "lblRelation";
            this.lblRelation.Size = new System.Drawing.Size(106, 19);
            this.lblRelation.TabIndex = 18;
            this.lblRelation.Text = "Passar relation";
            // 
            // lblGenus
            // 
            this.lblGenus.AutoSize = true;
            this.lblGenus.Location = new System.Drawing.Point(161, 77);
            this.lblGenus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGenus.Name = "lblGenus";
            this.lblGenus.Size = new System.Drawing.Size(50, 19);
            this.lblGenus.TabIndex = 16;
            this.lblGenus.Text = "Genus";
            // 
            // lblTermFor
            // 
            this.lblTermFor.AutoSize = true;
            this.lblTermFor.Location = new System.Drawing.Point(17, 77);
            this.lblTermFor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTermFor.Name = "lblTermFor";
            this.lblTermFor.Size = new System.Drawing.Size(75, 19);
            this.lblTermFor.TabIndex = 14;
            this.lblTermFor.Text = "Benämner";
            // 
            // lblColumn5
            // 
            this.lblColumn5.AutoSize = true;
            this.lblColumn5.Location = new System.Drawing.Point(591, 25);
            this.lblColumn5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColumn5.Name = "lblColumn5";
            this.lblColumn5.Size = new System.Drawing.Size(69, 19);
            this.lblColumn5.TabIndex = 12;
            this.lblColumn5.Text = "Kolumn 5";
            // 
            // tbxAddColumn5
            // 
            this.tbxAddColumn5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAddColumn5.Location = new System.Drawing.Point(594, 45);
            this.tbxAddColumn5.Margin = new System.Windows.Forms.Padding(2);
            this.tbxAddColumn5.Name = "tbxAddColumn5";
            this.tbxAddColumn5.Size = new System.Drawing.Size(130, 27);
            this.tbxAddColumn5.TabIndex = 4;
            // 
            // lblColumn4
            // 
            this.lblColumn4.AutoSize = true;
            this.lblColumn4.Location = new System.Drawing.Point(448, 25);
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
            this.tbxAddColumn4.Location = new System.Drawing.Point(451, 45);
            this.tbxAddColumn4.Margin = new System.Windows.Forms.Padding(2);
            this.tbxAddColumn4.Name = "tbxAddColumn4";
            this.tbxAddColumn4.Size = new System.Drawing.Size(130, 27);
            this.tbxAddColumn4.TabIndex = 3;
            // 
            // lblColumn3
            // 
            this.lblColumn3.AutoSize = true;
            this.lblColumn3.Location = new System.Drawing.Point(304, 25);
            this.lblColumn3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColumn3.Name = "lblColumn3";
            this.lblColumn3.Size = new System.Drawing.Size(69, 19);
            this.lblColumn3.TabIndex = 8;
            this.lblColumn3.Text = "Kolumn 3";
            // 
            // tbxAddColumn3
            // 
            this.tbxAddColumn3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAddColumn3.Location = new System.Drawing.Point(307, 45);
            this.tbxAddColumn3.Margin = new System.Windows.Forms.Padding(2);
            this.tbxAddColumn3.Name = "tbxAddColumn3";
            this.tbxAddColumn3.Size = new System.Drawing.Size(130, 27);
            this.tbxAddColumn3.TabIndex = 2;
            // 
            // lblColumn2
            // 
            this.lblColumn2.AutoSize = true;
            this.lblColumn2.Location = new System.Drawing.Point(161, 25);
            this.lblColumn2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColumn2.Name = "lblColumn2";
            this.lblColumn2.Size = new System.Drawing.Size(69, 19);
            this.lblColumn2.TabIndex = 6;
            this.lblColumn2.Text = "Kolumn 2";
            // 
            // tbxAddColumn2
            // 
            this.tbxAddColumn2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAddColumn2.Location = new System.Drawing.Point(164, 45);
            this.tbxAddColumn2.Margin = new System.Windows.Forms.Padding(2);
            this.tbxAddColumn2.Name = "tbxAddColumn2";
            this.tbxAddColumn2.Size = new System.Drawing.Size(130, 27);
            this.tbxAddColumn2.TabIndex = 1;
            // 
            // lblColumn1
            // 
            this.lblColumn1.AutoSize = true;
            this.lblColumn1.Location = new System.Drawing.Point(17, 25);
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
            this.btnAddRow.Location = new System.Drawing.Point(594, 81);
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(130, 43);
            this.btnAddRow.TabIndex = 9;
            this.btnAddRow.Text = "Lägg till";
            this.btnAddRow.UseVisualStyleBackColor = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // tbxAddColumn1
            // 
            this.tbxAddColumn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAddColumn1.Location = new System.Drawing.Point(20, 45);
            this.tbxAddColumn1.Margin = new System.Windows.Forms.Padding(2);
            this.tbxAddColumn1.Name = "tbxAddColumn1";
            this.tbxAddColumn1.Size = new System.Drawing.Size(130, 27);
            this.tbxAddColumn1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.numDeleteRow);
            this.groupBox3.Controls.Add(this.btnDeleteRow);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(649, 9);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(123, 100);
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
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbUpdateValue);
            this.groupBox2.Controls.Add(this.numChangeColumn);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numChangeRow);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnChangeValue);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(285, 9);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(340, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ändra i cell";
            // 
            // cbUpdateValue
            // 
            this.cbUpdateValue.FormattingEnabled = true;
            this.cbUpdateValue.Location = new System.Drawing.Point(125, 23);
            this.cbUpdateValue.Name = "cbUpdateValue";
            this.cbUpdateValue.Size = new System.Drawing.Size(205, 27);
            this.cbUpdateValue.TabIndex = 24;
            this.cbUpdateValue.SelectedIndexChanged += new System.EventHandler(this.cbUpdateValue_SelectedIndexChanged);
            this.cbUpdateValue.TextUpdate += new System.EventHandler(this.cbUpdateValue_TextUpdate);
            // 
            // numChangeColumn
            // 
            this.numChangeColumn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numChangeColumn.Location = new System.Drawing.Point(65, 62);
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
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kolumn";
            // 
            // numChangeRow
            // 
            this.numChangeRow.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numChangeRow.Location = new System.Drawing.Point(65, 24);
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rad";
            // 
            // btnChangeValue
            // 
            this.btnChangeValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChangeValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeValue.ForeColor = System.Drawing.Color.White;
            this.btnChangeValue.Location = new System.Drawing.Point(125, 62);
            this.btnChangeValue.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangeValue.Name = "btnChangeValue";
            this.btnChangeValue.Size = new System.Drawing.Size(205, 27);
            this.btnChangeValue.TabIndex = 3;
            this.btnChangeValue.Text = "Ändra + Nästa rad";
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
            "Sparade resultat",
            "Förskrivna uppdrag",
            "Plats",
            "Relation",
            "Status"});
            this.cbTabell.Location = new System.Drawing.Point(18, 44);
            this.cbTabell.Margin = new System.Windows.Forms.Padding(2);
            this.cbTabell.Name = "cbTabell";
            this.cbTabell.Size = new System.Drawing.Size(205, 27);
            this.cbTabell.TabIndex = 1;
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
            this.DbDisplay.Size = new System.Drawing.Size(800, 289);
            this.DbDisplay.TabIndex = 0;
            this.DbDisplay.CurrentCellChanged += new System.EventHandler(this.DbDisplay_CurrentCellChanged);
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Settings.Controls.Add(this.btnCancel);
            this.Settings.Controls.Add(this.btnOk);
            this.Settings.Controls.Add(this.groupBox6);
            this.Settings.Controls.Add(this.groupBox5);
            this.Settings.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings.Location = new System.Drawing.Point(4, 28);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(3);
            this.Settings.Size = new System.Drawing.Size(792, 547);
            this.Settings.TabIndex = 0;
            this.Settings.Text = "Inställningar";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(703, 508);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Avbryt";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(622, 508);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 27);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnResetDb);
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(291, 37);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 148);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Återställ databas";
            // 
            // btnResetDb
            // 
            this.btnResetDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnResetDb.Location = new System.Drawing.Point(26, 37);
            this.btnResetDb.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetDb.Name = "btnResetDb";
            this.btnResetDb.Size = new System.Drawing.Size(149, 91);
            this.btnResetDb.TabIndex = 0;
            this.btnResetDb.Text = "Återställ";
            this.btnResetDb.UseVisualStyleBackColor = false;
            this.btnResetDb.Click += new System.EventHandler(this.btnResetDb_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbxOffensive);
            this.groupBox5.Controls.Add(this.cbxSex);
            this.groupBox5.Controls.Add(this.cbxViolence);
            this.groupBox5.Controls.Add(this.cbxRegular);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(36, 37);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(213, 148);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Boring censurage for pussies";
            // 
            // cbxOffensive
            // 
            this.cbxOffensive.AutoSize = true;
            this.cbxOffensive.Location = new System.Drawing.Point(34, 112);
            this.cbxOffensive.Name = "cbxOffensive";
            this.cbxOffensive.Size = new System.Drawing.Size(132, 23);
            this.cbxOffensive.TabIndex = 3;
            this.cbxOffensive.Text = "Tillåt kränkande";
            this.cbxOffensive.UseVisualStyleBackColor = true;
            // 
            // cbxSex
            // 
            this.cbxSex.AutoSize = true;
            this.cbxSex.Location = new System.Drawing.Point(34, 85);
            this.cbxSex.Name = "cbxSex";
            this.cbxSex.Size = new System.Drawing.Size(87, 23);
            this.cbxSex.TabIndex = 2;
            this.cbxSex.Text = "Tillåt sex";
            this.cbxSex.UseVisualStyleBackColor = true;
            // 
            // cbxViolence
            // 
            this.cbxViolence.AutoSize = true;
            this.cbxViolence.Location = new System.Drawing.Point(34, 58);
            this.cbxViolence.Name = "cbxViolence";
            this.cbxViolence.Size = new System.Drawing.Size(92, 23);
            this.cbxViolence.TabIndex = 1;
            this.cbxViolence.Text = "Tillåt våld";
            this.cbxViolence.UseVisualStyleBackColor = true;
            // 
            // cbxRegular
            // 
            this.cbxRegular.AutoSize = true;
            this.cbxRegular.Checked = true;
            this.cbxRegular.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxRegular.Enabled = false;
            this.cbxRegular.Location = new System.Drawing.Point(34, 31);
            this.cbxRegular.Name = "cbxRegular";
            this.cbxRegular.Size = new System.Drawing.Size(112, 23);
            this.cbxRegular.TabIndex = 0;
            this.cbxRegular.Text = "Tillåt vanliga";
            this.cbxRegular.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(821, 599);
            this.Controls.Add(this.tabControl1);
            this.Name = "Options";
            this.Text = "Options";
            this.SizeChanged += new System.EventHandler(this.Options_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.Database.ResumeLayout(false);
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
            this.Settings.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Settings;
        private System.Windows.Forms.TabPage Database;
        private System.Windows.Forms.DataGridView DbDisplay;
        private System.Windows.Forms.ComboBox cbTabell;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChangeValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbAddRow;
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
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numChangeRow;
        private System.Windows.Forms.NumericUpDown numDeleteRow;
        private System.Windows.Forms.NumericUpDown numChangeColumn;
        private System.Windows.Forms.Label lblCensur;
        private System.Windows.Forms.ComboBox cbCensur;
        private System.Windows.Forms.Button btnResetDb;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbxOffensive;
        private System.Windows.Forms.CheckBox cbxSex;
        private System.Windows.Forms.CheckBox cbxViolence;
        private System.Windows.Forms.CheckBox cbxRegular;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cbTermFor;
        private System.Windows.Forms.ComboBox cbGenus;
        private System.Windows.Forms.ComboBox cbRelation;
        private System.Windows.Forms.ComboBox cbUpdateValue;
    }
}