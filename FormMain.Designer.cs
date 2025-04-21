namespace TanHungHa
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageAuto = new System.Windows.Forms.TabPage();
            this.panelAuto = new System.Windows.Forms.Panel();
            this.tabPageManual = new System.Windows.Forms.TabPage();
            this.panelManual = new System.Windows.Forms.Panel();
            this.tabPageManager = new System.Windows.Forms.TabPage();
            this.panelManager = new System.Windows.Forms.Panel();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.panelLog = new System.Windows.Forms.Panel();
            this.tabPageExit = new System.Windows.Forms.TabPage();
            this.menuIconList = new System.Windows.Forms.ImageList(this.components);
            this.tabPageTeaching = new System.Windows.Forms.TabPage();
            this.panelTeaching = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sttIQC = new System.Windows.Forms.ToolStripStatusLabel();
            this.sttOQC = new System.Windows.Forms.ToolStripStatusLabel();
            this.sttRAM = new System.Windows.Forms.ToolStripStatusLabel();
            this.materialTabControl1.SuspendLayout();
            this.tabPageAuto.SuspendLayout();
            this.panelAuto.SuspendLayout();
            this.tabPageManual.SuspendLayout();
            this.tabPageManager.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.tabPageTeaching.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPageAuto);
            this.materialTabControl1.Controls.Add(this.tabPageManual);
            this.materialTabControl1.Controls.Add(this.tabPageManager);
            this.materialTabControl1.Controls.Add(this.tabPageInfo);
            this.materialTabControl1.Controls.Add(this.tabPageLog);
            this.materialTabControl1.Controls.Add(this.tabPageExit);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.menuIconList;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1274, 653);
            this.materialTabControl1.TabIndex = 0;
            this.materialTabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.materialTabControl1_Selected);
            // 
            // tabPageAuto
            // 
            this.tabPageAuto.Controls.Add(this.panelAuto);
            this.tabPageAuto.ImageKey = "auto_white_24dp.png";
            this.tabPageAuto.Location = new System.Drawing.Point(4, 31);
            this.tabPageAuto.Name = "tabPageAuto";
            this.tabPageAuto.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuto.Size = new System.Drawing.Size(1266, 618);
            this.tabPageAuto.TabIndex = 0;
            this.tabPageAuto.Text = "Auto";
            this.tabPageAuto.UseVisualStyleBackColor = true;
            // 
            // panelAuto
            // 
            this.panelAuto.Controls.Add(this.statusStrip1);
            this.panelAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAuto.Location = new System.Drawing.Point(3, 3);
            this.panelAuto.Name = "panelAuto";
            this.panelAuto.Size = new System.Drawing.Size(1260, 612);
            this.panelAuto.TabIndex = 0;
            // 
            // tabPageManual
            // 
            this.tabPageManual.Controls.Add(this.panelManual);
            this.tabPageManual.ImageKey = "manual_white_24dp.png";
            this.tabPageManual.Location = new System.Drawing.Point(4, 31);
            this.tabPageManual.Name = "tabPageManual";
            this.tabPageManual.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageManual.Size = new System.Drawing.Size(1266, 618);
            this.tabPageManual.TabIndex = 1;
            this.tabPageManual.Text = "Manual";
            this.tabPageManual.UseVisualStyleBackColor = true;
            // 
            // panelManual
            // 
            this.panelManual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelManual.Location = new System.Drawing.Point(3, 3);
            this.panelManual.Name = "panelManual";
            this.panelManual.Size = new System.Drawing.Size(1260, 612);
            this.panelManual.TabIndex = 1;
            // 
            // tabPageManager
            // 
            this.tabPageManager.Controls.Add(this.panelManager);
            this.tabPageManager.ImageKey = "manage_accounts_white_24dp.png";
            this.tabPageManager.Location = new System.Drawing.Point(4, 31);
            this.tabPageManager.Name = "tabPageManager";
            this.tabPageManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageManager.Size = new System.Drawing.Size(1266, 618);
            this.tabPageManager.TabIndex = 3;
            this.tabPageManager.Text = "Manager";
            this.tabPageManager.UseVisualStyleBackColor = true;
            // 
            // panelManager
            // 
            this.panelManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelManager.Location = new System.Drawing.Point(3, 3);
            this.panelManager.Name = "panelManager";
            this.panelManager.Size = new System.Drawing.Size(1260, 612);
            this.panelManager.TabIndex = 1;
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.panelInfo);
            this.tabPageInfo.ImageKey = "info_white_24dp.png";
            this.tabPageInfo.Location = new System.Drawing.Point(4, 31);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(1266, 618);
            this.tabPageInfo.TabIndex = 5;
            this.tabPageInfo.Text = "Info";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // panelInfo
            // 
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfo.Location = new System.Drawing.Point(3, 3);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(1260, 612);
            this.panelInfo.TabIndex = 1;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.panelLog);
            this.tabPageLog.ImageKey = "log_white_24dp.png";
            this.tabPageLog.Location = new System.Drawing.Point(4, 31);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(1266, 618);
            this.tabPageLog.TabIndex = 4;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // panelLog
            // 
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLog.Location = new System.Drawing.Point(3, 3);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(1260, 612);
            this.panelLog.TabIndex = 1;
            // 
            // tabPageExit
            // 
            this.tabPageExit.ImageKey = "logout_white_24dp.png";
            this.tabPageExit.Location = new System.Drawing.Point(4, 31);
            this.tabPageExit.Name = "tabPageExit";
            this.tabPageExit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExit.Size = new System.Drawing.Size(1266, 618);
            this.tabPageExit.TabIndex = 6;
            this.tabPageExit.Text = "Exit";
            this.tabPageExit.UseVisualStyleBackColor = true;
            // 
            // menuIconList
            // 
            this.menuIconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("menuIconList.ImageStream")));
            this.menuIconList.TransparentColor = System.Drawing.Color.Transparent;
            this.menuIconList.Images.SetKeyName(0, "round_assessment_white_24dp.png");
            this.menuIconList.Images.SetKeyName(1, "round_backup_white_24dp.png");
            this.menuIconList.Images.SetKeyName(2, "round_bluetooth_white_24dp.png");
            this.menuIconList.Images.SetKeyName(3, "round_bookmark_white_24dp.png");
            this.menuIconList.Images.SetKeyName(4, "round_build_white_24dp.png");
            this.menuIconList.Images.SetKeyName(5, "round_gps_fixed_white_24dp.png");
            this.menuIconList.Images.SetKeyName(6, "round_http_white_24dp.png");
            this.menuIconList.Images.SetKeyName(7, "round_report_problem_white_24dp.png");
            this.menuIconList.Images.SetKeyName(8, "round_swap_vert_white_24dp.png");
            this.menuIconList.Images.SetKeyName(9, "round_phone_black_24dp.png");
            this.menuIconList.Images.SetKeyName(10, "round_push_pin_black_24dp.png");
            this.menuIconList.Images.SetKeyName(11, "round_mail_outline_black_24dp.png");
            this.menuIconList.Images.SetKeyName(12, "round_person_black_24dp.png");
            this.menuIconList.Images.SetKeyName(13, "round_add_a_photo_black_24dp.png");
            this.menuIconList.Images.SetKeyName(14, "round_alternate_email_black_24dp.png");
            this.menuIconList.Images.SetKeyName(15, "round_cancel_black_24dp.png");
            this.menuIconList.Images.SetKeyName(16, "round_error_black_24dp.png");
            this.menuIconList.Images.SetKeyName(17, "round_event_black_24dp.png");
            this.menuIconList.Images.SetKeyName(18, "auto_white_24dp.png");
            this.menuIconList.Images.SetKeyName(19, "info_white_24dp.png");
            this.menuIconList.Images.SetKeyName(20, "log_white_24dp.png");
            this.menuIconList.Images.SetKeyName(21, "logout_white_24dp.png");
            this.menuIconList.Images.SetKeyName(22, "manage_accounts_white_24dp.png");
            this.menuIconList.Images.SetKeyName(23, "manual_white_24dp.png");
            this.menuIconList.Images.SetKeyName(24, "teach_white_24dp.png");
            // 
            // tabPageTeaching
            // 
            this.tabPageTeaching.Controls.Add(this.panelTeaching);
            this.tabPageTeaching.ImageKey = "teach_white_24dp.png";
            this.tabPageTeaching.Location = new System.Drawing.Point(4, 31);
            this.tabPageTeaching.Name = "tabPageTeaching";
            this.tabPageTeaching.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTeaching.Size = new System.Drawing.Size(1266, 618);
            this.tabPageTeaching.TabIndex = 2;
            this.tabPageTeaching.Text = "Teaching";
            this.tabPageTeaching.UseVisualStyleBackColor = true;
            // 
            // panelTeaching
            // 
            this.panelTeaching.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTeaching.Location = new System.Drawing.Point(3, 3);
            this.panelTeaching.Name = "panelTeaching";
            this.panelTeaching.Size = new System.Drawing.Size(1260, 612);
            this.panelTeaching.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1266, 618);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sttIQC,
            this.sttOQC,
            this.sttRAM});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1260, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sttIQC
            // 
            this.sttIQC.Name = "sttIQC";
            this.sttIQC.Size = new System.Drawing.Size(27, 17);
            this.sttIQC.Text = "IQC";
            // 
            // sttOQC
            // 
            this.sttOQC.Name = "sttOQC";
            this.sttOQC.Size = new System.Drawing.Size(33, 17);
            this.sttOQC.Text = "OQC";
            // 
            // sttRAM
            // 
            this.sttRAM.Name = "sttRAM";
            this.sttRAM.Size = new System.Drawing.Size(33, 17);
            this.sttRAM.Text = "RAM";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPageAuto.ResumeLayout(false);
            this.panelAuto.ResumeLayout(false);
            this.panelAuto.PerformLayout();
            this.tabPageManual.ResumeLayout(false);
            this.tabPageManager.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageLog.ResumeLayout(false);
            this.tabPageTeaching.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPageAuto;
        private System.Windows.Forms.TabPage tabPageManual;
        private System.Windows.Forms.TabPage tabPageTeaching;
        private System.Windows.Forms.TabPage tabPageManager;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.ImageList menuIconList;
        public System.Windows.Forms.Panel panelManual;
        public System.Windows.Forms.Panel panelTeaching;
        public System.Windows.Forms.Panel panelManager;
        public System.Windows.Forms.Panel panelLog;
        public System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel panelAuto;
        private System.Windows.Forms.TabPage tabPageExit;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel sttIQC;
        public System.Windows.Forms.ToolStripStatusLabel sttOQC;
        public System.Windows.Forms.ToolStripStatusLabel sttRAM;
    }
}

