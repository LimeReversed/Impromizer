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
            this.Settings = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnLoadFromBackup = new System.Windows.Forms.Button();
            this.btnSaveToBackup = new System.Windows.Forms.Button();
            this.btnResetDb = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbxUnoffendable = new System.Windows.Forms.CheckBox();
            this.cbxAdults = new System.Windows.Forms.CheckBox();
            this.cbxAdolescents = new System.Windows.Forms.CheckBox();
            this.cbxChildren = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
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
            this.tabControl1.Location = new System.Drawing.Point(15, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1412, 891);
            this.tabControl1.TabIndex = 0;
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
            this.Database.Location = new System.Drawing.Point(4, 38);
            this.Database.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Database.Name = "Database";
            this.Database.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Database.Size = new System.Drawing.Size(1404, 849);
            this.Database.TabIndex = 1;
            this.Database.Text = "Databas";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox4.Controls.Add(this.numWriteColumn);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnSaveToTxt);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(1175, 14);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(194, 154);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Kolumn till fil";
            // 
            // numWriteColumn
            // 
            this.numWriteColumn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numWriteColumn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWriteColumn.Location = new System.Drawing.Point(106, 37);
            this.numWriteColumn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numWriteColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWriteColumn.Name = "numWriteColumn";
            this.numWriteColumn.Size = new System.Drawing.Size(68, 37);
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
            this.label3.Location = new System.Drawing.Point(17, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 29);
            this.label3.TabIndex = 26;
            this.label3.Text = "Kolumn";
            // 
            // btnSaveToTxt
            // 
            this.btnSaveToTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSaveToTxt.Location = new System.Drawing.Point(22, 95);
            this.btnSaveToTxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveToTxt.Name = "btnSaveToTxt";
            this.btnSaveToTxt.Size = new System.Drawing.Size(152, 42);
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
            this.gbAddRow.Location = new System.Drawing.Point(28, 174);
            this.gbAddRow.Name = "gbAddRow";
            this.gbAddRow.Size = new System.Drawing.Size(1341, 215);
            this.gbAddRow.TabIndex = 7;
            this.gbAddRow.TabStop = false;
            this.gbAddRow.Text = "Lägg till rad";
            // 
            // cbCensur
            // 
            this.cbCensur.FormattingEnabled = true;
            this.cbCensur.Items.AddRange(new object[] {
            "Barn",
            "Ungdomar",
            "Vuxna",
            "Okränkbara"});
            this.cbCensur.Location = new System.Drawing.Point(832, 149);
            this.cbCensur.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCensur.Name = "cbCensur";
            this.cbCensur.Size = new System.Drawing.Size(193, 37);
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
            this.cbTermFor.Location = new System.Drawing.Point(60, 149);
            this.cbTermFor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTermFor.Name = "cbTermFor";
            this.cbTermFor.Size = new System.Drawing.Size(193, 37);
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
            this.cbGenus.Location = new System.Drawing.Point(320, 149);
            this.cbGenus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGenus.Name = "cbGenus";
            this.cbGenus.Size = new System.Drawing.Size(193, 37);
            this.cbGenus.TabIndex = 22;
            // 
            // cbRelation
            // 
            this.cbRelation.FormattingEnabled = true;
            this.cbRelation.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbRelation.Location = new System.Drawing.Point(578, 149);
            this.cbRelation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbRelation.Name = "cbRelation";
            this.cbRelation.Size = new System.Drawing.Size(193, 37);
            this.cbRelation.TabIndex = 21;
            // 
            // lblCensur
            // 
            this.lblCensur.AutoSize = true;
            this.lblCensur.Location = new System.Drawing.Point(828, 118);
            this.lblCensur.Name = "lblCensur";
            this.lblCensur.Size = new System.Drawing.Size(130, 29);
            this.lblCensur.TabIndex = 20;
            this.lblCensur.Text = "Lämpligt för";
            // 
            // lblRelation
            // 
            this.lblRelation.AutoSize = true;
            this.lblRelation.Location = new System.Drawing.Point(573, 118);
            this.lblRelation.Name = "lblRelation";
            this.lblRelation.Size = new System.Drawing.Size(95, 29);
            this.lblRelation.TabIndex = 18;
            this.lblRelation.Text = "Relation";
            // 
            // lblGenus
            // 
            this.lblGenus.AutoSize = true;
            this.lblGenus.Location = new System.Drawing.Point(315, 118);
            this.lblGenus.Name = "lblGenus";
            this.lblGenus.Size = new System.Drawing.Size(75, 29);
            this.lblGenus.TabIndex = 16;
            this.lblGenus.Text = "Genus";
            // 
            // lblTermFor
            // 
            this.lblTermFor.AutoSize = true;
            this.lblTermFor.Location = new System.Drawing.Point(54, 118);
            this.lblTermFor.Name = "lblTermFor";
            this.lblTermFor.Size = new System.Drawing.Size(115, 29);
            this.lblTermFor.TabIndex = 14;
            this.lblTermFor.Text = "Benämner";
            // 
            // lblColumn5
            // 
            this.lblColumn5.AutoSize = true;
            this.lblColumn5.Location = new System.Drawing.Point(1078, 38);
            this.lblColumn5.Name = "lblColumn5";
            this.lblColumn5.Size = new System.Drawing.Size(106, 29);
            this.lblColumn5.TabIndex = 12;
            this.lblColumn5.Text = "Kolumn 5";
            // 
            // tbxAddColumn5
            // 
            this.tbxAddColumn5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAddColumn5.Location = new System.Drawing.Point(1083, 69);
            this.tbxAddColumn5.Name = "tbxAddColumn5";
            this.tbxAddColumn5.Size = new System.Drawing.Size(194, 37);
            this.tbxAddColumn5.TabIndex = 4;
            // 
            // lblColumn4
            // 
            this.lblColumn4.AutoSize = true;
            this.lblColumn4.Location = new System.Drawing.Point(826, 38);
            this.lblColumn4.Name = "lblColumn4";
            this.lblColumn4.Size = new System.Drawing.Size(106, 29);
            this.lblColumn4.TabIndex = 10;
            this.lblColumn4.Text = "Kolumn 4";
            // 
            // tbxAddColumn4
            // 
            this.tbxAddColumn4.BackColor = System.Drawing.Color.White;
            this.tbxAddColumn4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAddColumn4.Location = new System.Drawing.Point(831, 69);
            this.tbxAddColumn4.Name = "tbxAddColumn4";
            this.tbxAddColumn4.Size = new System.Drawing.Size(194, 37);
            this.tbxAddColumn4.TabIndex = 3;
            // 
            // lblColumn3
            // 
            this.lblColumn3.AutoSize = true;
            this.lblColumn3.Location = new System.Drawing.Point(573, 38);
            this.lblColumn3.Name = "lblColumn3";
            this.lblColumn3.Size = new System.Drawing.Size(106, 29);
            this.lblColumn3.TabIndex = 8;
            this.lblColumn3.Text = "Kolumn 3";
            // 
            // tbxAddColumn3
            // 
            this.tbxAddColumn3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAddColumn3.Location = new System.Drawing.Point(578, 69);
            this.tbxAddColumn3.Name = "tbxAddColumn3";
            this.tbxAddColumn3.Size = new System.Drawing.Size(194, 37);
            this.tbxAddColumn3.TabIndex = 2;
            // 
            // lblColumn2
            // 
            this.lblColumn2.AutoSize = true;
            this.lblColumn2.Location = new System.Drawing.Point(315, 38);
            this.lblColumn2.Name = "lblColumn2";
            this.lblColumn2.Size = new System.Drawing.Size(106, 29);
            this.lblColumn2.TabIndex = 6;
            this.lblColumn2.Text = "Kolumn 2";
            // 
            // tbxAddColumn2
            // 
            this.tbxAddColumn2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAddColumn2.Location = new System.Drawing.Point(320, 69);
            this.tbxAddColumn2.Name = "tbxAddColumn2";
            this.tbxAddColumn2.Size = new System.Drawing.Size(194, 37);
            this.tbxAddColumn2.TabIndex = 1;
            // 
            // lblColumn1
            // 
            this.lblColumn1.AutoSize = true;
            this.lblColumn1.Location = new System.Drawing.Point(56, 38);
            this.lblColumn1.Name = "lblColumn1";
            this.lblColumn1.Size = new System.Drawing.Size(106, 29);
            this.lblColumn1.TabIndex = 4;
            this.lblColumn1.Text = "Kolumn 1";
            // 
            // btnAddRow
            // 
            this.btnAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRow.ForeColor = System.Drawing.Color.White;
            this.btnAddRow.Location = new System.Drawing.Point(1083, 125);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(195, 66);
            this.btnAddRow.TabIndex = 9;
            this.btnAddRow.Text = "Lägg till";
            this.btnAddRow.UseVisualStyleBackColor = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // tbxAddColumn1
            // 
            this.tbxAddColumn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAddColumn1.Location = new System.Drawing.Point(60, 69);
            this.tbxAddColumn1.Name = "tbxAddColumn1";
            this.tbxAddColumn1.Size = new System.Drawing.Size(196, 37);
            this.tbxAddColumn1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.numDeleteRow);
            this.groupBox3.Controls.Add(this.btnDeleteRow);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(962, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(184, 154);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ta bort rad";
            // 
            // numDeleteRow
            // 
            this.numDeleteRow.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDeleteRow.Location = new System.Drawing.Point(78, 38);
            this.numDeleteRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numDeleteRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDeleteRow.Name = "numDeleteRow";
            this.numDeleteRow.Size = new System.Drawing.Size(78, 37);
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
            this.btnDeleteRow.Location = new System.Drawing.Point(30, 95);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(126, 42);
            this.btnDeleteRow.TabIndex = 1;
            this.btnDeleteRow.Text = "Ta bort";
            this.btnDeleteRow.UseVisualStyleBackColor = false;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 29);
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
            this.groupBox2.Location = new System.Drawing.Point(414, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 154);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ändra i cell";
            // 
            // cbUpdateValue
            // 
            this.cbUpdateValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbUpdateValue.FormattingEnabled = true;
            this.cbUpdateValue.Location = new System.Drawing.Point(224, 35);
            this.cbUpdateValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbUpdateValue.Name = "cbUpdateValue";
            this.cbUpdateValue.Size = new System.Drawing.Size(249, 37);
            this.cbUpdateValue.TabIndex = 24;
            this.cbUpdateValue.SelectedIndexChanged += new System.EventHandler(this.cbUpdateValue_SelectedIndexChanged);
            this.cbUpdateValue.TextUpdate += new System.EventHandler(this.cbUpdateValue_TextUpdate);
            // 
            // numChangeColumn
            // 
            this.numChangeColumn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numChangeColumn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numChangeColumn.Location = new System.Drawing.Point(134, 95);
            this.numChangeColumn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numChangeColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChangeColumn.Name = "numChangeColumn";
            this.numChangeColumn.Size = new System.Drawing.Size(68, 37);
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
            this.label2.Location = new System.Drawing.Point(45, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kolumn";
            // 
            // numChangeRow
            // 
            this.numChangeRow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numChangeRow.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numChangeRow.Location = new System.Drawing.Point(134, 37);
            this.numChangeRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numChangeRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChangeRow.Name = "numChangeRow";
            this.numChangeRow.Size = new System.Drawing.Size(68, 37);
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
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rad";
            // 
            // btnChangeValue
            // 
            this.btnChangeValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnChangeValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChangeValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeValue.ForeColor = System.Drawing.Color.White;
            this.btnChangeValue.Location = new System.Drawing.Point(224, 95);
            this.btnChangeValue.Name = "btnChangeValue";
            this.btnChangeValue.Size = new System.Drawing.Size(249, 42);
            this.btnChangeValue.TabIndex = 3;
            this.btnChangeValue.Text = "Ändra";
            this.btnChangeValue.UseVisualStyleBackColor = false;
            this.btnChangeValue.Click += new System.EventHandler(this.btnChangeValue_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTabell);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 155);
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
            this.cbTabell.Location = new System.Drawing.Point(27, 68);
            this.cbTabell.Name = "cbTabell";
            this.cbTabell.Size = new System.Drawing.Size(306, 37);
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
            this.DbDisplay.Location = new System.Drawing.Point(-6, 402);
            this.DbDisplay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DbDisplay.MultiSelect = false;
            this.DbDisplay.Name = "DbDisplay";
            this.DbDisplay.ReadOnly = true;
            this.DbDisplay.RowHeadersWidth = 25;
            this.DbDisplay.Size = new System.Drawing.Size(1412, 445);
            this.DbDisplay.TabIndex = 0;
            this.DbDisplay.CurrentCellChanged += new System.EventHandler(this.DbDisplay_CurrentCellChanged);
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Settings.Controls.Add(this.groupBox6);
            this.Settings.Controls.Add(this.groupBox5);
            this.Settings.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings.Location = new System.Drawing.Point(4, 38);
            this.Settings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Settings.Size = new System.Drawing.Size(1404, 849);
            this.Settings.TabIndex = 0;
            this.Settings.Text = "Inställningar";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnLoadFromBackup);
            this.groupBox6.Controls.Add(this.btnSaveToBackup);
            this.groupBox6.Controls.Add(this.btnResetDb);
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(436, 57);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Size = new System.Drawing.Size(910, 228);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Spara/Ladda databas";
            // 
            // btnLoadFromBackup
            // 
            this.btnLoadFromBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoadFromBackup.Location = new System.Drawing.Point(626, 57);
            this.btnLoadFromBackup.Name = "btnLoadFromBackup";
            this.btnLoadFromBackup.Size = new System.Drawing.Size(224, 140);
            this.btnLoadFromBackup.TabIndex = 2;
            this.btnLoadFromBackup.Text = "Återställ från säkerhetskopia";
            this.btnLoadFromBackup.UseVisualStyleBackColor = false;
            this.btnLoadFromBackup.Click += new System.EventHandler(this.btnLoadFromBackup_Click);
            // 
            // btnSaveToBackup
            // 
            this.btnSaveToBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSaveToBackup.Location = new System.Drawing.Point(344, 57);
            this.btnSaveToBackup.Name = "btnSaveToBackup";
            this.btnSaveToBackup.Size = new System.Drawing.Size(224, 140);
            this.btnSaveToBackup.TabIndex = 1;
            this.btnSaveToBackup.Text = "Säkerhetkopiera databas";
            this.btnSaveToBackup.UseVisualStyleBackColor = false;
            this.btnSaveToBackup.Click += new System.EventHandler(this.btnSaveToBackup_Click);
            // 
            // btnResetDb
            // 
            this.btnResetDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnResetDb.Location = new System.Drawing.Point(58, 57);
            this.btnResetDb.Name = "btnResetDb";
            this.btnResetDb.Size = new System.Drawing.Size(224, 140);
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
            this.groupBox5.Location = new System.Drawing.Point(54, 57);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(320, 228);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Visa ord som passar...";
            // 
            // cbxUnoffendable
            // 
            this.cbxUnoffendable.AutoSize = true;
            this.cbxUnoffendable.Location = new System.Drawing.Point(51, 172);
            this.cbxUnoffendable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxUnoffendable.Name = "cbxUnoffendable";
            this.cbxUnoffendable.Size = new System.Drawing.Size(155, 33);
            this.cbxUnoffendable.TabIndex = 3;
            this.cbxUnoffendable.Text = "Okränkbara";
            this.cbxUnoffendable.UseVisualStyleBackColor = true;
            this.cbxUnoffendable.CheckedChanged += new System.EventHandler(this.cbxUnoffendable_CheckedChanged);
            // 
            // cbxAdults
            // 
            this.cbxAdults.AutoSize = true;
            this.cbxAdults.Location = new System.Drawing.Point(51, 131);
            this.cbxAdults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxAdults.Name = "cbxAdults";
            this.cbxAdults.Size = new System.Drawing.Size(100, 33);
            this.cbxAdults.TabIndex = 2;
            this.cbxAdults.Text = "Vuxna";
            this.cbxAdults.UseVisualStyleBackColor = true;
            this.cbxAdults.CheckedChanged += new System.EventHandler(this.cbxAdults_CheckedChanged);
            // 
            // cbxAdolescents
            // 
            this.cbxAdolescents.AutoSize = true;
            this.cbxAdolescents.Location = new System.Drawing.Point(51, 89);
            this.cbxAdolescents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxAdolescents.Name = "cbxAdolescents";
            this.cbxAdolescents.Size = new System.Drawing.Size(143, 33);
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
            this.cbxChildren.Location = new System.Drawing.Point(51, 48);
            this.cbxChildren.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxChildren.Name = "cbxChildren";
            this.cbxChildren.Size = new System.Drawing.Size(85, 33);
            this.cbxChildren.TabIndex = 0;
            this.cbxChildren.Text = "Barn";
            this.cbxChildren.UseVisualStyleBackColor = true;
            this.cbxChildren.CheckedChanged += new System.EventHandler(this.cbxChildren_CheckedChanged);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1443, 922);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1242, 942);
            this.Name = "Options";
            this.Text = "Options";
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
        private System.Windows.Forms.CheckBox cbxUnoffendable;
        private System.Windows.Forms.CheckBox cbxAdults;
        private System.Windows.Forms.CheckBox cbxAdolescents;
        private System.Windows.Forms.CheckBox cbxChildren;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbTermFor;
        private System.Windows.Forms.ComboBox cbGenus;
        private System.Windows.Forms.ComboBox cbRelation;
        private System.Windows.Forms.ComboBox cbUpdateValue;
        private System.Windows.Forms.Button btnLoadFromBackup;
        private System.Windows.Forms.Button btnSaveToBackup;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSaveToTxt;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.NumericUpDown numWriteColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}