namespace TanHungHa.PopUp
{
    partial class FormSpeedWarning
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnWarning = new MaterialSkin.Controls.MaterialButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.OrangeRed;
            this.groupBox1.Controls.Add(this.btnWarning);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cảnh báo";
            // 
            // btnWarning
            // 
            this.btnWarning.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnWarning.BackColor = System.Drawing.Color.Red;
            this.btnWarning.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnWarning.Depth = 0;
            this.btnWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnWarning.HighEmphasis = true;
            this.btnWarning.Icon = null;
            this.btnWarning.Location = new System.Drawing.Point(3, 25);
            this.btnWarning.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnWarning.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnWarning.Name = "btnWarning";
            this.btnWarning.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnWarning.Size = new System.Drawing.Size(345, 139);
            this.btnWarning.TabIndex = 0;
            this.btnWarning.Text = "materialButton1";
            this.btnWarning.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnWarning.UseAccentColor = false;
            this.btnWarning.UseVisualStyleBackColor = false;
            // 
            // FormSpeedWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 170);
            this.Controls.Add(this.groupBox1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "FormSpeedWarning";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSpeedWarning";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialButton btnWarning;
    }
}