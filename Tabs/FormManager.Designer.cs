namespace TanHungHa.Tabs
{
    partial class FormManager
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
            this.materialTabControlManager = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageParameter = new System.Windows.Forms.TabPage();
            this.tabPageTheme = new System.Windows.Forms.TabPage();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPageModel = new System.Windows.Forms.TabPage();
            this.materialTabControlManager.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControlManager
            // 
            this.materialTabControlManager.Controls.Add(this.tabPageParameter);
            //this.materialTabControlManager.Controls.Add(this.tabPageModel);
            this.materialTabControlManager.Controls.Add(this.tabPageTheme);
            this.materialTabControlManager.Depth = 0;
            this.materialTabControlManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControlManager.Location = new System.Drawing.Point(0, 25);
            this.materialTabControlManager.Margin = new System.Windows.Forms.Padding(0);
            this.materialTabControlManager.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControlManager.Multiline = true;
            this.materialTabControlManager.Name = "materialTabControlManager";
            this.materialTabControlManager.SelectedIndex = 0;
            this.materialTabControlManager.Size = new System.Drawing.Size(928, 493);
            this.materialTabControlManager.TabIndex = 25;
            // 
            // tabPageParameter
            // 
            this.tabPageParameter.BackColor = System.Drawing.Color.White;
            this.tabPageParameter.Location = new System.Drawing.Point(4, 22);
            this.tabPageParameter.Name = "tabPageParameter";
            this.tabPageParameter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParameter.Size = new System.Drawing.Size(920, 467);
            this.tabPageParameter.TabIndex = 5;
            this.tabPageParameter.Text = "Parameter";
            // 
            // tabPageTheme
            // 
            this.tabPageTheme.BackColor = System.Drawing.Color.White;
            this.tabPageTheme.Location = new System.Drawing.Point(4, 22);
            this.tabPageTheme.Name = "tabPageTheme";
            this.tabPageTheme.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTheme.Size = new System.Drawing.Size(920, 467);
            this.tabPageTheme.TabIndex = 7;
            this.tabPageTheme.Text = "Theme";
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControlManager;
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
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.materialTabSelector1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.materialTabControlManager, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(928, 518);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // tabPageModel
            // 
            this.tabPageModel.Location = new System.Drawing.Point(4, 22);
            this.tabPageModel.Name = "tabPageModel";
            this.tabPageModel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageModel.Size = new System.Drawing.Size(920, 467);
            this.tabPageModel.TabIndex = 8;
            this.tabPageModel.Text = "Model";
            this.tabPageModel.UseVisualStyleBackColor = true;
            // 
            // FormManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 521);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "FormManager";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "FormManager";
            this.materialTabControlManager.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControlManager;
        private System.Windows.Forms.TabPage tabPageParameter;
        private System.Windows.Forms.TabPage tabPageTheme;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabPageModel;
    }
}