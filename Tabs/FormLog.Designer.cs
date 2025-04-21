namespace TanHungHa.Tabs
{
    partial class FormLog
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
            this.panel_control = new System.Windows.Forms.Panel();
            this.dp_endDate = new System.Windows.Forms.DateTimePicker();
            this.dp_startDate = new System.Windows.Forms.DateTimePicker();
            this.cl_DateSelector = new System.Windows.Forms.MonthCalendar();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel32 = new MaterialSkin.Controls.MaterialLabel();
            this.btnRefresh = new MaterialSkin.Controls.MaterialButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_view = new System.Windows.Forms.Panel();
            this.dg_Log = new System.Windows.Forms.DataGridView();
            this.cblSelLog = new System.Windows.Forms.CheckedListBox();
            this.panel_control.SuspendLayout();
            this.panel_view.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Log)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_control
            // 
            this.panel_control.Controls.Add(this.cblSelLog);
            this.panel_control.Controls.Add(this.dp_endDate);
            this.panel_control.Controls.Add(this.dp_startDate);
            this.panel_control.Controls.Add(this.cl_DateSelector);
            this.panel_control.Controls.Add(this.materialLabel2);
            this.panel_control.Controls.Add(this.materialLabel1);
            this.panel_control.Controls.Add(this.materialLabel32);
            this.panel_control.Controls.Add(this.btnRefresh);
            this.panel_control.Controls.Add(this.label3);
            this.panel_control.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_control.Location = new System.Drawing.Point(3, 0);
            this.panel_control.Name = "panel_control";
            this.panel_control.Size = new System.Drawing.Size(260, 518);
            this.panel_control.TabIndex = 1;
            // 
            // dp_endDate
            // 
            this.dp_endDate.Location = new System.Drawing.Point(48, 254);
            this.dp_endDate.Name = "dp_endDate";
            this.dp_endDate.Size = new System.Drawing.Size(200, 20);
            this.dp_endDate.TabIndex = 20;
            this.dp_endDate.ValueChanged += new System.EventHandler(this.dp_Date_ValueChanged);
            // 
            // dp_startDate
            // 
            this.dp_startDate.Location = new System.Drawing.Point(22, 228);
            this.dp_startDate.Name = "dp_startDate";
            this.dp_startDate.Size = new System.Drawing.Size(200, 20);
            this.dp_startDate.TabIndex = 20;
            this.dp_startDate.ValueChanged += new System.EventHandler(this.dp_Date_ValueChanged);
            // 
            // cl_DateSelector
            // 
            this.cl_DateSelector.Location = new System.Drawing.Point(21, 23);
            this.cl_DateSelector.Name = "cl_DateSelector";
            this.cl_DateSelector.TabIndex = 19;
            this.cl_DateSelector.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.cl_DateSelector_DateChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel2.HighEmphasis = true;
            this.materialLabel2.Location = new System.Drawing.Point(19, 295);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(68, 17);
            this.materialLabel2.TabIndex = 18;
            this.materialLabel2.Text = "Select Log";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel1.HighEmphasis = true;
            this.materialLabel1.Location = new System.Drawing.Point(19, 203);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(42, 17);
            this.materialLabel1.TabIndex = 18;
            this.materialLabel1.Text = "Range";
            // 
            // materialLabel32
            // 
            this.materialLabel32.AutoSize = true;
            this.materialLabel32.Depth = 0;
            this.materialLabel32.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel32.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel32.HighEmphasis = true;
            this.materialLabel32.Location = new System.Drawing.Point(19, 6);
            this.materialLabel32.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel32.Name = "materialLabel32";
            this.materialLabel32.Size = new System.Drawing.Size(74, 17);
            this.materialLabel32.TabIndex = 17;
            this.materialLabel32.Text = "Select Date";
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = false;
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRefresh.Depth = 0;
            this.btnRefresh.HighEmphasis = true;
            this.btnRefresh.Icon = null;
            this.btnRefresh.Location = new System.Drawing.Point(16, 448);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRefresh.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRefresh.Size = new System.Drawing.Size(227, 49);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnRefresh.UseAccentColor = false;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "~";
            // 
            // panel_view
            // 
            this.panel_view.Controls.Add(this.dg_Log);
            this.panel_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_view.Location = new System.Drawing.Point(263, 0);
            this.panel_view.Name = "panel_view";
            this.panel_view.Size = new System.Drawing.Size(668, 518);
            this.panel_view.TabIndex = 2;
            // 
            // dg_Log
            // 
            this.dg_Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Log.Location = new System.Drawing.Point(0, 0);
            this.dg_Log.Name = "dg_Log";
            this.dg_Log.Size = new System.Drawing.Size(668, 518);
            this.dg_Log.TabIndex = 21;
            // 
            // cblSelLog
            // 
            this.cblSelLog.FormattingEnabled = true;
            this.cblSelLog.Location = new System.Drawing.Point(16, 315);
            this.cblSelLog.Name = "cblSelLog";
            this.cblSelLog.Size = new System.Drawing.Size(227, 109);
            this.cblSelLog.TabIndex = 21;
            // 
            // FormLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 521);
            this.Controls.Add(this.panel_view);
            this.Controls.Add(this.panel_control);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "FormLog";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "FormLog";
            this.panel_control.ResumeLayout(false);
            this.panel_control.PerformLayout();
            this.panel_view.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Log)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_control;
        private MaterialSkin.Controls.MaterialButton btnRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_view;
        private System.Windows.Forms.DateTimePicker dp_endDate;
        private System.Windows.Forms.DateTimePicker dp_startDate;
        private System.Windows.Forms.MonthCalendar cl_DateSelector;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel32;
        private System.Windows.Forms.DataGridView dg_Log;
        private System.Windows.Forms.CheckedListBox cblSelLog;
    }
}