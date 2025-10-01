namespace TanHungHa.Tabs.ManualTab
{
    partial class VisionForm
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnModel = new MaterialSkin.Controls.MaterialButton();
            this.btnSaveJob = new MaterialSkin.Controls.MaterialButton();
            this.btnLoadJob = new MaterialSkin.Controls.MaterialButton();
            this.panelVM = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelVM, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 447);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnModel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSaveJob, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnLoadJob, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(73, 441);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnModel
            // 
            this.btnModel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnModel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnModel.Depth = 0;
            this.btnModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnModel.HighEmphasis = true;
            this.btnModel.Icon = null;
            this.btnModel.Location = new System.Drawing.Point(4, 6);
            this.btnModel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnModel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnModel.Name = "btnModel";
            this.btnModel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnModel.Size = new System.Drawing.Size(65, 98);
            this.btnModel.TabIndex = 2;
            this.btnModel.Text = "Model";
            this.btnModel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnModel.UseAccentColor = true;
            this.btnModel.UseVisualStyleBackColor = true;
            // 
            // btnSaveJob
            // 
            this.btnSaveJob.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveJob.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSaveJob.Depth = 0;
            this.btnSaveJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveJob.HighEmphasis = true;
            this.btnSaveJob.Icon = null;
            this.btnSaveJob.Location = new System.Drawing.Point(4, 226);
            this.btnSaveJob.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveJob.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveJob.Name = "btnSaveJob";
            this.btnSaveJob.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSaveJob.Size = new System.Drawing.Size(65, 98);
            this.btnSaveJob.TabIndex = 1;
            this.btnSaveJob.Text = "Save";
            this.btnSaveJob.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSaveJob.UseAccentColor = false;
            this.btnSaveJob.UseVisualStyleBackColor = true;
            this.btnSaveJob.Click += new System.EventHandler(this.btnSaveJob_Click);
            // 
            // btnLoadJob
            // 
            this.btnLoadJob.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoadJob.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLoadJob.Depth = 0;
            this.btnLoadJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadJob.HighEmphasis = true;
            this.btnLoadJob.Icon = null;
            this.btnLoadJob.Location = new System.Drawing.Point(4, 116);
            this.btnLoadJob.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLoadJob.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLoadJob.Name = "btnLoadJob";
            this.btnLoadJob.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLoadJob.Size = new System.Drawing.Size(65, 98);
            this.btnLoadJob.TabIndex = 0;
            this.btnLoadJob.Text = "Load Job";
            this.btnLoadJob.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLoadJob.UseAccentColor = false;
            this.btnLoadJob.UseVisualStyleBackColor = true;
            this.btnLoadJob.Click += new System.EventHandler(this.btnLoadJob_Click);
            // 
            // panelVM
            // 
            this.panelVM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVM.Location = new System.Drawing.Point(82, 3);
            this.panelVM.Name = "panelVM";
            this.panelVM.Size = new System.Drawing.Size(709, 441);
            this.panelVM.TabIndex = 1;
            // 
            // VisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "VisionForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "Vision";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialButton btnLoadJob;
        private MaterialSkin.Controls.MaterialButton btnSaveJob;
        private System.Windows.Forms.Panel panelVM;
        private MaterialSkin.Controls.MaterialButton btnModel;
    }
}