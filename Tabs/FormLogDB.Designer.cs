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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbNG = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbOK = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbOQC = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbIQC = new MaterialSkin.Controls.MaterialCheckbox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.mtDatePicker = new MaterialWinforms.Controls.MaterialDropDownDatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.materialDropDownDatePicker1 = new MaterialWinforms.Controls.MaterialDropDownDatePicker();
            this.btnRefresh = new MaterialSkin.Controls.MaterialButton();
            this.groupBoxChart = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbNG = new System.Windows.Forms.Label();
            this.lbOK = new System.Windows.Forms.Label();
            this.groupGridView = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBoxChart.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.groupGridView.SuspendLayout();
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
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRefresh, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.46566F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.27638F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18274F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(140, 597);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbNG);
            this.groupBox3.Controls.Add(this.cbOK);
            this.groupBox3.Controls.Add(this.cbOQC);
            this.groupBox3.Controls.Add(this.cbIQC);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 161);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(134, 324);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Log";
            // 
            // cbNG
            // 
            this.cbNG.AutoSize = true;
            this.cbNG.Depth = 0;
            this.cbNG.Location = new System.Drawing.Point(9, 124);
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
            // 
            // cbOK
            // 
            this.cbOK.AutoSize = true;
            this.cbOK.Depth = 0;
            this.cbOK.Location = new System.Drawing.Point(9, 68);
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
            // 
            // cbOQC
            // 
            this.cbOQC.AutoSize = true;
            this.cbOQC.Depth = 0;
            this.cbOQC.Location = new System.Drawing.Point(119, 16);
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
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 152);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Range";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.28125F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.71875F));
            this.tableLayoutPanel3.Controls.Add(this.mtDatePicker, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.materialDropDownDatePicker1, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(128, 133);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // mtDatePicker
            // 
            this.mtDatePicker.AnchorSize = new System.Drawing.Size(107, 62);
            this.mtDatePicker.BackColor = System.Drawing.SystemColors.Control;
            this.mtDatePicker.Date = new System.DateTime(2025, 4, 23, 0, 0, 0, 0);
            this.mtDatePicker.Depth = 0;
            this.mtDatePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtDatePicker.DockSide = MaterialWinforms.Controls.DropDownControl.eDockSide.Left;
            this.mtDatePicker.Location = new System.Drawing.Point(19, 2);
            this.mtDatePicker.Margin = new System.Windows.Forms.Padding(2);
            this.mtDatePicker.MouseState = MaterialWinforms.MouseState.HOVER;
            this.mtDatePicker.Name = "mtDatePicker";
            this.mtDatePicker.Size = new System.Drawing.Size(107, 62);
            this.mtDatePicker.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 67);
            this.label1.TabIndex = 9;
            this.label1.Text = "~";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialDropDownDatePicker1
            // 
            this.materialDropDownDatePicker1.AnchorSize = new System.Drawing.Size(107, 63);
            this.materialDropDownDatePicker1.BackColor = System.Drawing.SystemColors.Control;
            this.materialDropDownDatePicker1.Date = new System.DateTime(2025, 4, 23, 0, 0, 0, 0);
            this.materialDropDownDatePicker1.Depth = 0;
            this.materialDropDownDatePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialDropDownDatePicker1.DockSide = MaterialWinforms.Controls.DropDownControl.eDockSide.Left;
            this.materialDropDownDatePicker1.Location = new System.Drawing.Point(19, 68);
            this.materialDropDownDatePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.materialDropDownDatePicker1.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialDropDownDatePicker1.Name = "materialDropDownDatePicker1";
            this.materialDropDownDatePicker1.Size = new System.Drawing.Size(107, 63);
            this.materialDropDownDatePicker1.TabIndex = 10;
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
            this.btnRefresh.Location = new System.Drawing.Point(4, 494);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRefresh.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRefresh.Size = new System.Drawing.Size(132, 97);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnRefresh.UseAccentColor = false;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(3, 3);
            this.chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart.Series.Add(series2);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBoxChart.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.groupGridView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialWinforms.Controls.MaterialDropDownDatePicker mtDatePicker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private MaterialWinforms.Controls.MaterialDropDownDatePicker materialDropDownDatePicker1;
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
    }
}