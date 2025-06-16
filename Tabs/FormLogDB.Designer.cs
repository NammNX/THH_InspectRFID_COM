namespace TanHungHa.Tabs
{
    partial class FormLogDB
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxChart = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbNG = new System.Windows.Forms.Label();
            this.lbOK = new System.Windows.Forms.Label();
            this.groupGridView = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxFindRollByDate = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cbbListRoll = new MaterialSkin.Controls.MaterialComboBox();
            this.btnScanRoll = new MaterialSkin.Controls.MaterialButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbNG = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbOK = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbOQC = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbIQC = new MaterialSkin.Controls.MaterialCheckbox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mtDatePicker1 = new MaterialWinforms.Controls.MaterialDropDownDatePicker();
            this.cbHex2AciiEPC = new System.Windows.Forms.CheckBox();
            this.btnExportExcel = new MaterialSkin.Controls.MaterialButton();
            this.btnRefresh = new MaterialSkin.Controls.MaterialButton();
            this.groupBoxFindNameByName = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnScanRollByName = new MaterialSkin.Controls.MaterialButton();
            this.cbbFindRollByName = new MaterialSkin.Controls.MaterialComboBox();
            this.txtFindRollByName = new MaterialSkin.Controls.MaterialTextBox2();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBoxChart.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.groupGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxFindRollByDate.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxFindNameByName.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(979, 603);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel4.Controls.Add(this.groupBoxChart, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupGridView, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(149, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(827, 597);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // groupBoxChart
            // 
            this.groupBoxChart.BackColor = System.Drawing.Color.Silver;
            this.groupBoxChart.Controls.Add(this.tableLayoutPanel6);
            this.groupBoxChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxChart.ForeColor = System.Drawing.Color.Black;
            this.groupBoxChart.Location = new System.Drawing.Point(663, 3);
            this.groupBoxChart.Name = "groupBoxChart";
            this.groupBoxChart.Size = new System.Drawing.Size(161, 591);
            this.groupBoxChart.TabIndex = 1;
            this.groupBoxChart.TabStop = false;
            this.groupBoxChart.Text = "Chart";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.chart, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.49484F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.50516F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(155, 570);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(3, 3);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(149, 430);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.lbTotal, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.lbNG, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.lbOK, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 439);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(149, 128);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTotal.Location = new System.Drawing.Point(3, 84);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(143, 44);
            this.lbTotal.TabIndex = 2;
            this.lbTotal.Text = "Total";
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNG
            // 
            this.lbNG.AutoSize = true;
            this.lbNG.BackColor = System.Drawing.Color.Red;
            this.lbNG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNG.Location = new System.Drawing.Point(3, 42);
            this.lbNG.Name = "lbNG";
            this.lbNG.Size = new System.Drawing.Size(143, 42);
            this.lbNG.TabIndex = 1;
            this.lbNG.Text = "NG";
            this.lbNG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbOK
            // 
            this.lbOK.AutoSize = true;
            this.lbOK.BackColor = System.Drawing.Color.Lime;
            this.lbOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbOK.Location = new System.Drawing.Point(3, 0);
            this.lbOK.Name = "lbOK";
            this.lbOK.Size = new System.Drawing.Size(143, 42);
            this.lbOK.TabIndex = 0;
            this.lbOK.Text = "OK";
            this.lbOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupGridView
            // 
            this.groupGridView.Controls.Add(this.dataGridView1);
            this.groupGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupGridView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupGridView.Location = new System.Drawing.Point(3, 3);
            this.groupGridView.Name = "groupGridView";
            this.groupGridView.Size = new System.Drawing.Size(654, 591);
            this.groupGridView.TabIndex = 4;
            this.groupGridView.TabStop = false;
            this.groupGridView.Text = "IQC-OQC";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(648, 572);
            this.dataGridView1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBoxFindRollByDate, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbHex2AciiEPC, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.btnExportExcel, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnRefresh, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxFindNameByName, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(140, 597);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBoxFindRollByDate
            // 
            this.groupBoxFindRollByDate.BackColor = System.Drawing.Color.Silver;
            this.groupBoxFindRollByDate.Controls.Add(this.tableLayoutPanel3);
            this.groupBoxFindRollByDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFindRollByDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFindRollByDate.Location = new System.Drawing.Point(3, 181);
            this.groupBoxFindRollByDate.Name = "groupBoxFindRollByDate";
            this.groupBoxFindRollByDate.Size = new System.Drawing.Size(134, 113);
            this.groupBoxFindRollByDate.TabIndex = 1;
            this.groupBoxFindRollByDate.TabStop = false;
            this.groupBoxFindRollByDate.Text = "Tìm cuộn trong ngày";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.cbbListRoll, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnScanRoll, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(128, 88);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // cbbListRoll
            // 
            this.cbbListRoll.AutoResize = false;
            this.cbbListRoll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbbListRoll.Depth = 0;
            this.cbbListRoll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbListRoll.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbListRoll.DropDownHeight = 174;
            this.cbbListRoll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbListRoll.DropDownWidth = 121;
            this.cbbListRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbbListRoll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbbListRoll.FormattingEnabled = true;
            this.cbbListRoll.IntegralHeight = false;
            this.cbbListRoll.ItemHeight = 43;
            this.cbbListRoll.Location = new System.Drawing.Point(3, 47);
            this.cbbListRoll.MaxDropDownItems = 4;
            this.cbbListRoll.MouseState = MaterialSkin.MouseState.OUT;
            this.cbbListRoll.Name = "cbbListRoll";
            this.cbbListRoll.Size = new System.Drawing.Size(122, 49);
            this.cbbListRoll.StartIndex = 0;
            this.cbbListRoll.TabIndex = 4;
            // 
            // btnScanRoll
            // 
            this.btnScanRoll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnScanRoll.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnScanRoll.Depth = 0;
            this.btnScanRoll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnScanRoll.HighEmphasis = true;
            this.btnScanRoll.Icon = null;
            this.btnScanRoll.Location = new System.Drawing.Point(4, 6);
            this.btnScanRoll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnScanRoll.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnScanRoll.Name = "btnScanRoll";
            this.btnScanRoll.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnScanRoll.Size = new System.Drawing.Size(120, 32);
            this.btnScanRoll.TabIndex = 5;
            this.btnScanRoll.Text = "Scan";
            this.btnScanRoll.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnScanRoll.UseAccentColor = false;
            this.btnScanRoll.UseVisualStyleBackColor = true;
            this.btnScanRoll.Click += new System.EventHandler(this.btnScanRoll_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbNG);
            this.groupBox3.Controls.Add(this.cbOK);
            this.groupBox3.Controls.Add(this.cbOQC);
            this.groupBox3.Controls.Add(this.cbIQC);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(134, 113);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Log";
            // 
            // cbNG
            // 
            this.cbNG.AutoSize = true;
            this.cbNG.Depth = 0;
            this.cbNG.Location = new System.Drawing.Point(8, 90);
            this.cbNG.Margin = new System.Windows.Forms.Padding(0);
            this.cbNG.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbNG.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbNG.Name = "cbNG";
            this.cbNG.ReadOnly = false;
            this.cbNG.Ripple = true;
            this.cbNG.Size = new System.Drawing.Size(57, 37);
            this.cbNG.TabIndex = 3;
            this.cbNG.Text = "NG";
            this.cbNG.UseVisualStyleBackColor = true;
            this.cbNG.CheckedChanged += new System.EventHandler(this.cbNG_CheckedChanged);
            // 
            // cbOK
            // 
            this.cbOK.AutoSize = true;
            this.cbOK.Depth = 0;
            this.cbOK.Location = new System.Drawing.Point(9, 53);
            this.cbOK.Margin = new System.Windows.Forms.Padding(0);
            this.cbOK.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbOK.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbOK.Name = "cbOK";
            this.cbOK.ReadOnly = false;
            this.cbOK.Ripple = true;
            this.cbOK.Size = new System.Drawing.Size(56, 37);
            this.cbOK.TabIndex = 2;
            this.cbOK.Text = "OK";
            this.cbOK.UseVisualStyleBackColor = true;
            this.cbOK.CheckedChanged += new System.EventHandler(this.cbOK_CheckedChanged);
            // 
            // cbOQC
            // 
            this.cbOQC.AutoSize = true;
            this.cbOQC.Depth = 0;
            this.cbOQC.Location = new System.Drawing.Point(89, 16);
            this.cbOQC.Margin = new System.Windows.Forms.Padding(0);
            this.cbOQC.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbOQC.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbOQC.Name = "cbOQC";
            this.cbOQC.ReadOnly = false;
            this.cbOQC.Ripple = true;
            this.cbOQC.Size = new System.Drawing.Size(67, 37);
            this.cbOQC.TabIndex = 1;
            this.cbOQC.Text = "OQC";
            this.cbOQC.UseVisualStyleBackColor = true;
            this.cbOQC.CheckedChanged += new System.EventHandler(this.cbOQC_CheckedChanged);
            this.cbOQC.CheckStateChanged += new System.EventHandler(this.cbOQC_CheckStateChanged);
            // 
            // cbIQC
            // 
            this.cbIQC.AutoSize = true;
            this.cbIQC.Checked = true;
            this.cbIQC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIQC.Depth = 0;
            this.cbIQC.Location = new System.Drawing.Point(9, 16);
            this.cbIQC.Margin = new System.Windows.Forms.Padding(0);
            this.cbIQC.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbIQC.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbIQC.Name = "cbIQC";
            this.cbIQC.ReadOnly = false;
            this.cbIQC.Ripple = true;
            this.cbIQC.Size = new System.Drawing.Size(60, 37);
            this.cbIQC.TabIndex = 0;
            this.cbIQC.Text = "IQC";
            this.cbIQC.UseVisualStyleBackColor = true;
            this.cbIQC.CheckedChanged += new System.EventHandler(this.cbIQC_CheckedChanged);
            this.cbIQC.CheckStateChanged += new System.EventHandler(this.cbIQC_CheckStateChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mtDatePicker1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 53);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Date";
            // 
            // mtDatePicker1
            // 
            this.mtDatePicker1.AnchorSize = new System.Drawing.Size(128, 34);
            this.mtDatePicker1.BackColor = System.Drawing.SystemColors.Control;
            this.mtDatePicker1.Date = new System.DateTime(2025, 4, 23, 0, 0, 0, 0);
            this.mtDatePicker1.Depth = 0;
            this.mtDatePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtDatePicker1.DockSide = MaterialWinforms.Controls.DropDownControl.eDockSide.Left;
            this.mtDatePicker1.Location = new System.Drawing.Point(3, 16);
            this.mtDatePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.mtDatePicker1.MouseState = MaterialWinforms.MouseState.HOVER;
            this.mtDatePicker1.Name = "mtDatePicker1";
            this.mtDatePicker1.Size = new System.Drawing.Size(128, 34);
            this.mtDatePicker1.TabIndex = 8;
            // 
            // cbHex2AciiEPC
            // 
            this.cbHex2AciiEPC.AutoSize = true;
            this.cbHex2AciiEPC.BackColor = System.Drawing.Color.Cyan;
            this.cbHex2AciiEPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbHex2AciiEPC.Location = new System.Drawing.Point(3, 573);
            this.cbHex2AciiEPC.Name = "cbHex2AciiEPC";
            this.cbHex2AciiEPC.Size = new System.Drawing.Size(134, 21);
            this.cbHex2AciiEPC.TabIndex = 5;
            this.cbHex2AciiEPC.Text = "Hex to Ascii EPC";
            this.cbHex2AciiEPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbHex2AciiEPC.UseVisualStyleBackColor = false;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExportExcel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExportExcel.Depth = 0;
            this.btnExportExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportExcel.HighEmphasis = true;
            this.btnExportExcel.Icon = null;
            this.btnExportExcel.Location = new System.Drawing.Point(4, 529);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExportExcel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnExportExcel.Size = new System.Drawing.Size(132, 35);
            this.btnExportExcel.TabIndex = 4;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExportExcel.UseAccentColor = false;
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRefresh.Depth = 0;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.HighEmphasis = true;
            this.btnRefresh.Icon = null;
            this.btnRefresh.Location = new System.Drawing.Point(4, 482);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRefresh.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRefresh.Size = new System.Drawing.Size(132, 35);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnRefresh.UseAccentColor = false;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBoxFindNameByName
            // 
            this.groupBoxFindNameByName.BackColor = System.Drawing.Color.Silver;
            this.groupBoxFindNameByName.Controls.Add(this.tableLayoutPanel5);
            this.groupBoxFindNameByName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFindNameByName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFindNameByName.Location = new System.Drawing.Point(3, 300);
            this.groupBoxFindNameByName.Name = "groupBoxFindNameByName";
            this.groupBoxFindNameByName.Size = new System.Drawing.Size(134, 173);
            this.groupBoxFindNameByName.TabIndex = 6;
            this.groupBoxFindNameByName.TabStop = false;
            this.groupBoxFindNameByName.Text = "Tìm cuộn theo tên";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.btnScanRollByName, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.cbbFindRollByName, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.txtFindRollByName, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(128, 148);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // btnScanRollByName
            // 
            this.btnScanRollByName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnScanRollByName.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnScanRollByName.Depth = 0;
            this.btnScanRollByName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnScanRollByName.HighEmphasis = true;
            this.btnScanRollByName.Icon = null;
            this.btnScanRollByName.Location = new System.Drawing.Point(4, 6);
            this.btnScanRollByName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnScanRollByName.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnScanRollByName.Name = "btnScanRollByName";
            this.btnScanRollByName.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnScanRollByName.Size = new System.Drawing.Size(120, 37);
            this.btnScanRollByName.TabIndex = 2;
            this.btnScanRollByName.Text = "Scan";
            this.btnScanRollByName.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnScanRollByName.UseAccentColor = false;
            this.btnScanRollByName.UseVisualStyleBackColor = true;
            this.btnScanRollByName.Click += new System.EventHandler(this.btnScanRollByName_Click);
            // 
            // cbbFindRollByName
            // 
            this.cbbFindRollByName.AutoResize = false;
            this.cbbFindRollByName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbbFindRollByName.Depth = 0;
            this.cbbFindRollByName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbFindRollByName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbFindRollByName.DropDownHeight = 174;
            this.cbbFindRollByName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFindRollByName.DropDownWidth = 121;
            this.cbbFindRollByName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbbFindRollByName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbbFindRollByName.FormattingEnabled = true;
            this.cbbFindRollByName.IntegralHeight = false;
            this.cbbFindRollByName.ItemHeight = 43;
            this.cbbFindRollByName.Location = new System.Drawing.Point(3, 101);
            this.cbbFindRollByName.MaxDropDownItems = 4;
            this.cbbFindRollByName.MouseState = MaterialSkin.MouseState.OUT;
            this.cbbFindRollByName.Name = "cbbFindRollByName";
            this.cbbFindRollByName.Size = new System.Drawing.Size(122, 49);
            this.cbbFindRollByName.StartIndex = 0;
            this.cbbFindRollByName.TabIndex = 1;
            // 
            // txtFindRollByName
            // 
            this.txtFindRollByName.AnimateReadOnly = false;
            this.txtFindRollByName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtFindRollByName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtFindRollByName.Depth = 0;
            this.txtFindRollByName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFindRollByName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFindRollByName.HideSelection = true;
            this.txtFindRollByName.Hint = "Nhập tên cuộn";
            this.txtFindRollByName.LeadingIcon = null;
            this.txtFindRollByName.Location = new System.Drawing.Point(3, 52);
            this.txtFindRollByName.MaxLength = 32767;
            this.txtFindRollByName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtFindRollByName.Name = "txtFindRollByName";
            this.txtFindRollByName.PasswordChar = '\0';
            this.txtFindRollByName.PrefixSuffixText = null;
            this.txtFindRollByName.ReadOnly = false;
            this.txtFindRollByName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFindRollByName.SelectedText = "";
            this.txtFindRollByName.SelectionLength = 0;
            this.txtFindRollByName.SelectionStart = 0;
            this.txtFindRollByName.ShortcutsEnabled = true;
            this.txtFindRollByName.Size = new System.Drawing.Size(122, 48);
            this.txtFindRollByName.TabIndex = 3;
            this.txtFindRollByName.TabStop = false;
            this.txtFindRollByName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFindRollByName.TrailingIcon = global::TanHungHa.Properties.Resources.outline_cleaning_services_black_18dp;
            this.txtFindRollByName.UseSystemPasswordChar = false;
            this.txtFindRollByName.TrailingIconClick += new System.EventHandler(this.txtFindRollByName_TrailingIconClick);
            // 
            // FormLogDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 606);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "FormLogDB";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "FormLogDB";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBoxChart.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.groupGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBoxFindRollByDate.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBoxFindNameByName.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        public MaterialWinforms.Controls.MaterialDropDownDatePicker mtDatePicker1;
        private MaterialSkin.Controls.MaterialCheckbox cbNG;
        private MaterialSkin.Controls.MaterialCheckbox cbOK;
        private MaterialSkin.Controls.MaterialCheckbox cbOQC;
        private MaterialSkin.Controls.MaterialCheckbox cbIQC;
        private MaterialSkin.Controls.MaterialButton btnRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        public System.Windows.Forms.GroupBox groupBoxChart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbNG;
        private System.Windows.Forms.Label lbOK;
        private System.Windows.Forms.GroupBox groupGridView;
        private MaterialSkin.Controls.MaterialButton btnExportExcel;
        private System.Windows.Forms.CheckBox cbHex2AciiEPC;
        private MaterialSkin.Controls.MaterialComboBox cbbListRoll;
        private MaterialSkin.Controls.MaterialButton btnScanRoll;
        private MaterialSkin.Controls.MaterialComboBox cbbFindRollByName;
        private System.Windows.Forms.GroupBox groupBoxFindRollByDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBoxFindNameByName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private MaterialSkin.Controls.MaterialButton btnScanRollByName;
        private MaterialSkin.Controls.MaterialTextBox2 txtFindRollByName;
    }
}