namespace TanHungHa.Tabs
{
    partial class FormManual
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControlManual = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageSerial = new System.Windows.Forms.TabPage();
            this.tabPageEthernet = new System.Windows.Forms.TabPage();
            this.tabTeachRobot = new System.Windows.Forms.TabPage();
            this.tabPageVM = new System.Windows.Forms.TabPage();
            this.tabVisionPro = new System.Windows.Forms.TabPage();
            this.tabMotion = new System.Windows.Forms.TabPage();
            this.tabRobot = new System.Windows.Forms.TabPage();
            this.tabPageLightController = new System.Windows.Forms.TabPage();
            this.tabPageCamera = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.materialTabControlManual.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.materialTabSelector1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.materialTabControlManual, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(928, 518);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControlManual;
            this.materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Proper;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabSelector1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 0);
            this.materialTabSelector1.Margin = new System.Windows.Forms.Padding(0);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(928, 25);
            this.materialTabSelector1.TabIndex = 26;
            this.materialTabSelector1.Text = "``";
            // 
            // materialTabControlManual
            // 
            this.materialTabControlManual.Controls.Add(this.tabPageSerial);
            this.materialTabControlManual.Depth = 0;
            this.materialTabControlManual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControlManual.Location = new System.Drawing.Point(0, 25);
            this.materialTabControlManual.Margin = new System.Windows.Forms.Padding(0);
            this.materialTabControlManual.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControlManual.Multiline = true;
            this.materialTabControlManual.Name = "materialTabControlManual";
            this.materialTabControlManual.SelectedIndex = 0;
            this.materialTabControlManual.Size = new System.Drawing.Size(928, 493);
            this.materialTabControlManual.TabIndex = 25;
            this.materialTabControlManual.Selected += new System.Windows.Forms.TabControlEventHandler(this.materialTabControlManual_Selected);
            // 
            // tabPageSerial
            // 
            this.tabPageSerial.BackColor = System.Drawing.Color.White;
            this.tabPageSerial.Location = new System.Drawing.Point(4, 22);
            this.tabPageSerial.Name = "tabPageSerial";
            this.tabPageSerial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSerial.Size = new System.Drawing.Size(920, 467);
            this.tabPageSerial.TabIndex = 1;
            this.tabPageSerial.Text = "Serial";
            // 
            // tabPageEthernet
            // 
            this.tabPageEthernet.Location = new System.Drawing.Point(4, 22);
            this.tabPageEthernet.Name = "tabPageEthernet";
            this.tabPageEthernet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEthernet.Size = new System.Drawing.Size(920, 467);
            this.tabPageEthernet.TabIndex = 2;
            this.tabPageEthernet.Text = "Ethernet";
            this.tabPageEthernet.UseVisualStyleBackColor = true;
            // 
            // tabTeachRobot
            // 
            this.tabTeachRobot.Location = new System.Drawing.Point(4, 22);
            this.tabTeachRobot.Name = "tabTeachRobot";
            this.tabTeachRobot.Padding = new System.Windows.Forms.Padding(3);
            this.tabTeachRobot.Size = new System.Drawing.Size(920, 467);
            this.tabTeachRobot.TabIndex = 8;
            this.tabTeachRobot.Text = "Teach Robot";
            this.tabTeachRobot.UseVisualStyleBackColor = true;
            // 
            // tabPageVM
            // 
            this.tabPageVM.BackColor = System.Drawing.Color.White;
            this.tabPageVM.Location = new System.Drawing.Point(4, 22);
            this.tabPageVM.Name = "tabPageVM";
            this.tabPageVM.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVM.Size = new System.Drawing.Size(920, 467);
            this.tabPageVM.TabIndex = 2;
            this.tabPageVM.Text = "VisionMaster";
            // 
            // tabVisionPro
            // 
            this.tabVisionPro.Location = new System.Drawing.Point(4, 22);
            this.tabVisionPro.Name = "tabVisionPro";
            this.tabVisionPro.Padding = new System.Windows.Forms.Padding(3);
            this.tabVisionPro.Size = new System.Drawing.Size(920, 467);
            this.tabVisionPro.TabIndex = 5;
            this.tabVisionPro.Text = "Vision Pro";
            this.tabVisionPro.UseVisualStyleBackColor = true;
            // 
            // tabMotion
            // 
            this.tabMotion.Location = new System.Drawing.Point(4, 22);
            this.tabMotion.Name = "tabMotion";
            this.tabMotion.Padding = new System.Windows.Forms.Padding(3);
            this.tabMotion.Size = new System.Drawing.Size(920, 467);
            this.tabMotion.TabIndex = 7;
            this.tabMotion.Text = "Ezi Motion";
            this.tabMotion.UseVisualStyleBackColor = true;
            // 
            // tabRobot
            // 
            this.tabRobot.Location = new System.Drawing.Point(4, 22);
            this.tabRobot.Name = "tabRobot";
            this.tabRobot.Padding = new System.Windows.Forms.Padding(3);
            this.tabRobot.Size = new System.Drawing.Size(920, 467);
            this.tabRobot.TabIndex = 6;
            this.tabRobot.Text = "Robot";
            this.tabRobot.UseVisualStyleBackColor = true;
            // 
            // tabPageLightController
            // 
            this.tabPageLightController.Location = new System.Drawing.Point(4, 22);
            this.tabPageLightController.Name = "tabPageLightController";
            this.tabPageLightController.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLightController.Size = new System.Drawing.Size(920, 467);
            this.tabPageLightController.TabIndex = 4;
            this.tabPageLightController.Text = "Light";
            this.tabPageLightController.UseVisualStyleBackColor = true;
            // 
            // tabPageCamera
            // 
            this.tabPageCamera.BackColor = System.Drawing.Color.White;
            this.tabPageCamera.Location = new System.Drawing.Point(4, 22);
            this.tabPageCamera.Name = "tabPageCamera";
            this.tabPageCamera.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCamera.Size = new System.Drawing.Size(920, 467);
            this.tabPageCamera.TabIndex = 0;
            this.tabPageCamera.Text = "Camera";
            // 
            // FormManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 521);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "FormManual";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "FormManual";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.materialTabControlManual.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private System.Windows.Forms.TabPage tabPageEthernet;
        private MaterialSkin.Controls.MaterialTabControl materialTabControlManual;
        private System.Windows.Forms.TabPage tabPageCamera;
        private System.Windows.Forms.TabPage tabPageSerial;
        private System.Windows.Forms.TabPage tabPageLightController;
        private System.Windows.Forms.TabPage tabRobot;
        private System.Windows.Forms.TabPage tabMotion;
        private System.Windows.Forms.TabPage tabVisionPro;
        private System.Windows.Forms.TabPage tabPageVM;
        private System.Windows.Forms.TabPage tabTeachRobot;
        //private System.Windows.Forms.TabPage tabPage1;
    }
}