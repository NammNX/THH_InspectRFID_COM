namespace TanHungHa.Tabs.ManualTab
{
    partial class ManThemeForm
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
            this.btnSaveTheme = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel52 = new MaterialSkin.Controls.MaterialLabel();
            this.materialListBoxFormStyle = new MaterialSkin.Controls.MaterialListBox();
            this.swDisplayIconWhenHidden = new MaterialSkin.Controls.MaterialSwitch();
            this.swBackgroundWithAccent = new MaterialSkin.Controls.MaterialSwitch();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.swHighlightWithAccent = new MaterialSkin.Controls.MaterialSwitch();
            this.btnChangeTheme = new MaterialSkin.Controls.MaterialButton();
            this.swAutoShow = new MaterialSkin.Controls.MaterialSwitch();
            this.swUserColors = new MaterialSkin.Controls.MaterialSwitch();
            this.btnChangeColor = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // btnSaveTheme
            // 
            this.btnSaveTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveTheme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSaveTheme.Depth = 0;
            this.btnSaveTheme.HighEmphasis = true;
            this.btnSaveTheme.Icon = null;
            this.btnSaveTheme.Location = new System.Drawing.Point(740, 355);
            this.btnSaveTheme.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveTheme.Name = "btnSaveTheme";
            this.btnSaveTheme.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSaveTheme.Size = new System.Drawing.Size(111, 36);
            this.btnSaveTheme.TabIndex = 63;
            this.btnSaveTheme.Text = "Save Theme";
            this.btnSaveTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnSaveTheme.UseAccentColor = false;
            this.btnSaveTheme.UseVisualStyleBackColor = true;
            this.btnSaveTheme.Click += new System.EventHandler(this.btnSaveTheme_Click);
            // 
            // materialLabel52
            // 
            this.materialLabel52.AutoSize = true;
            this.materialLabel52.Depth = 0;
            this.materialLabel52.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel52.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel52.Location = new System.Drawing.Point(655, 31);
            this.materialLabel52.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel52.Name = "materialLabel52";
            this.materialLabel52.Size = new System.Drawing.Size(113, 29);
            this.materialLabel52.TabIndex = 62;
            this.materialLabel52.Text = "Form style";
            // 
            // materialListBoxFormStyle
            // 
            this.materialListBoxFormStyle.BackColor = System.Drawing.Color.White;
            this.materialListBoxFormStyle.BorderColor = System.Drawing.Color.LightGray;
            this.materialListBoxFormStyle.Depth = 0;
            this.materialListBoxFormStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialListBoxFormStyle.Location = new System.Drawing.Point(648, 64);
            this.materialListBoxFormStyle.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialListBoxFormStyle.Name = "materialListBoxFormStyle";
            this.materialListBoxFormStyle.SelectedIndex = -1;
            this.materialListBoxFormStyle.SelectedItem = null;
            this.materialListBoxFormStyle.Size = new System.Drawing.Size(225, 258);
            this.materialListBoxFormStyle.TabIndex = 61;
            // 
            // swDisplayIconWhenHidden
            // 
            this.swDisplayIconWhenHidden.AutoSize = true;
            this.swDisplayIconWhenHidden.Checked = true;
            this.swDisplayIconWhenHidden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.swDisplayIconWhenHidden.Depth = 0;
            this.swDisplayIconWhenHidden.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.swDisplayIconWhenHidden.Location = new System.Drawing.Point(35, 346);
            this.swDisplayIconWhenHidden.Margin = new System.Windows.Forms.Padding(0);
            this.swDisplayIconWhenHidden.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swDisplayIconWhenHidden.MouseState = MaterialSkin.MouseState.HOVER;
            this.swDisplayIconWhenHidden.Name = "swDisplayIconWhenHidden";
            this.swDisplayIconWhenHidden.Ripple = true;
            this.swDisplayIconWhenHidden.Size = new System.Drawing.Size(309, 37);
            this.swDisplayIconWhenHidden.TabIndex = 60;
            this.swDisplayIconWhenHidden.Text = "Drawer - Display Icons when hidden";
            this.swDisplayIconWhenHidden.UseVisualStyleBackColor = true;
            this.swDisplayIconWhenHidden.Click += new System.EventHandler(this.sw_CheckedChanged);
            // 
            // swBackgroundWithAccent
            // 
            this.swBackgroundWithAccent.AutoSize = true;
            this.swBackgroundWithAccent.Depth = 0;
            this.swBackgroundWithAccent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.swBackgroundWithAccent.Location = new System.Drawing.Point(35, 309);
            this.swBackgroundWithAccent.Margin = new System.Windows.Forms.Padding(0);
            this.swBackgroundWithAccent.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swBackgroundWithAccent.MouseState = MaterialSkin.MouseState.HOVER;
            this.swBackgroundWithAccent.Name = "swBackgroundWithAccent";
            this.swBackgroundWithAccent.Ripple = true;
            this.swBackgroundWithAccent.Size = new System.Drawing.Size(291, 37);
            this.swBackgroundWithAccent.TabIndex = 59;
            this.swBackgroundWithAccent.Text = "Drawer - Background with Accent";
            this.swBackgroundWithAccent.UseVisualStyleBackColor = true;
            this.swBackgroundWithAccent.Click += new System.EventHandler(this.sw_CheckedChanged);
            // 
            // materialLabel9
            // 
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(32, 102);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(455, 60);
            this.materialLabel9.TabIndex = 53;
            this.materialLabel9.Text = "\r\nTo the left is the drawer, use it to see all the demos available\r\nTry clicking " +
    "stuff, you won\'t break it ;)\r\n";
            // 
            // swHighlightWithAccent
            // 
            this.swHighlightWithAccent.AutoSize = true;
            this.swHighlightWithAccent.Checked = true;
            this.swHighlightWithAccent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.swHighlightWithAccent.Depth = 0;
            this.swHighlightWithAccent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.swHighlightWithAccent.Location = new System.Drawing.Point(35, 273);
            this.swHighlightWithAccent.Margin = new System.Windows.Forms.Padding(0);
            this.swHighlightWithAccent.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swHighlightWithAccent.MouseState = MaterialSkin.MouseState.HOVER;
            this.swHighlightWithAccent.Name = "swHighlightWithAccent";
            this.swHighlightWithAccent.Ripple = true;
            this.swHighlightWithAccent.Size = new System.Drawing.Size(270, 37);
            this.swHighlightWithAccent.TabIndex = 58;
            this.swHighlightWithAccent.Text = "Drawer - Highlight with Accent";
            this.swHighlightWithAccent.UseVisualStyleBackColor = true;
            this.swHighlightWithAccent.Click += new System.EventHandler(this.sw_CheckedChanged);
            // 
            // btnChangeTheme
            // 
            this.btnChangeTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChangeTheme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnChangeTheme.Depth = 0;
            this.btnChangeTheme.HighEmphasis = true;
            this.btnChangeTheme.Icon = null;
            this.btnChangeTheme.Location = new System.Drawing.Point(193, 179);
            this.btnChangeTheme.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnChangeTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnChangeTheme.Name = "btnChangeTheme";
            this.btnChangeTheme.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnChangeTheme.Size = new System.Drawing.Size(133, 36);
            this.btnChangeTheme.TabIndex = 54;
            this.btnChangeTheme.Text = "Change Theme";
            this.btnChangeTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnChangeTheme.UseAccentColor = false;
            this.btnChangeTheme.UseVisualStyleBackColor = true;
            this.btnChangeTheme.Click += new System.EventHandler(this.btnChangeTheme_Click);
            // 
            // swAutoShow
            // 
            this.swAutoShow.AutoSize = true;
            this.swAutoShow.Depth = 0;
            this.swAutoShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.swAutoShow.Location = new System.Drawing.Point(35, 383);
            this.swAutoShow.Margin = new System.Windows.Forms.Padding(0);
            this.swAutoShow.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swAutoShow.MouseState = MaterialSkin.MouseState.HOVER;
            this.swAutoShow.Name = "swAutoShow";
            this.swAutoShow.Ripple = true;
            this.swAutoShow.Size = new System.Drawing.Size(195, 37);
            this.swAutoShow.TabIndex = 56;
            this.swAutoShow.Text = "Drawer - Auto show";
            this.swAutoShow.UseVisualStyleBackColor = true;
            this.swAutoShow.Click += new System.EventHandler(this.sw_CheckedChanged);
            // 
            // swUserColors
            // 
            this.swUserColors.AutoSize = true;
            this.swUserColors.Depth = 0;
            this.swUserColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.swUserColors.Location = new System.Drawing.Point(35, 236);
            this.swUserColors.Margin = new System.Windows.Forms.Padding(0);
            this.swUserColors.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swUserColors.MouseState = MaterialSkin.MouseState.HOVER;
            this.swUserColors.Name = "swUserColors";
            this.swUserColors.Ripple = true;
            this.swUserColors.Size = new System.Drawing.Size(193, 37);
            this.swUserColors.TabIndex = 57;
            this.swUserColors.Text = "Drawer - Use colors";
            this.swUserColors.UseVisualStyleBackColor = true;
            this.swUserColors.Click += new System.EventHandler(this.sw_CheckedChanged);
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChangeColor.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnChangeColor.Depth = 0;
            this.btnChangeColor.HighEmphasis = true;
            this.btnChangeColor.Icon = null;
            this.btnChangeColor.Location = new System.Drawing.Point(35, 179);
            this.btnChangeColor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnChangeColor.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnChangeColor.Size = new System.Drawing.Size(140, 36);
            this.btnChangeColor.TabIndex = 55;
            this.btnChangeColor.Text = "Change Colors";
            this.btnChangeColor.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnChangeColor.UseAccentColor = false;
            this.btnChangeColor.UseVisualStyleBackColor = true;
            this.btnChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.materialLabel1.HighEmphasis = true;
            this.materialLabel1.Location = new System.Drawing.Point(34, 31);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(310, 58);
            this.materialLabel1.TabIndex = 52;
            this.materialLabel1.Text = "Setting Theme";
            // 
            // ManThemeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 450);
            this.Controls.Add(this.btnSaveTheme);
            this.Controls.Add(this.materialLabel52);
            this.Controls.Add(this.materialListBoxFormStyle);
            this.Controls.Add(this.swDisplayIconWhenHidden);
            this.Controls.Add(this.swBackgroundWithAccent);
            this.Controls.Add(this.materialLabel9);
            this.Controls.Add(this.swHighlightWithAccent);
            this.Controls.Add(this.btnChangeTheme);
            this.Controls.Add(this.swAutoShow);
            this.Controls.Add(this.swUserColors);
            this.Controls.Add(this.btnChangeColor);
            this.Controls.Add(this.materialLabel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "ManThemeForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "ManThemeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnSaveTheme;
        private MaterialSkin.Controls.MaterialLabel materialLabel52;
        private MaterialSkin.Controls.MaterialListBox materialListBoxFormStyle;
        private MaterialSkin.Controls.MaterialSwitch swDisplayIconWhenHidden;
        private MaterialSkin.Controls.MaterialSwitch swBackgroundWithAccent;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialSwitch swHighlightWithAccent;
        private MaterialSkin.Controls.MaterialButton btnChangeTheme;
        private MaterialSkin.Controls.MaterialSwitch swAutoShow;
        private MaterialSkin.Controls.MaterialSwitch swUserColors;
        private MaterialSkin.Controls.MaterialButton btnChangeColor;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}