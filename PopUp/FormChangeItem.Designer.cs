namespace TanHungHa.PopUp
{
    partial class FormChangeItem
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
            this.btnReplace = new MaterialSkin.Controls.MaterialButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReplace = new MaterialSkin.Controls.MaterialTextBox2();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFind = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnFind = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.Controls.Add(this.btnReplace, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFind, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(519, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnReplace
            // 
            this.btnReplace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReplace.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnReplace.Depth = 0;
            this.btnReplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReplace.Enabled = false;
            this.btnReplace.HighEmphasis = true;
            this.btnReplace.Icon = null;
            this.btnReplace.Location = new System.Drawing.Point(399, 81);
            this.btnReplace.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReplace.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnReplace.Size = new System.Drawing.Size(116, 63);
            this.btnReplace.TabIndex = 3;
            this.btnReplace.Text = "Thay thế";
            this.btnReplace.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnReplace.UseAccentColor = false;
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReplace);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 69);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhập TID thay thế";
            // 
            // txtReplace
            // 
            this.txtReplace.AnimateReadOnly = false;
            this.txtReplace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtReplace.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtReplace.Depth = 0;
            this.txtReplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtReplace.HideSelection = true;
            this.txtReplace.Hint = "Nhập ...";
            this.txtReplace.LeadingIcon = null;
            this.txtReplace.Location = new System.Drawing.Point(3, 16);
            this.txtReplace.MaxLength = 32767;
            this.txtReplace.MouseState = MaterialSkin.MouseState.OUT;
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.PasswordChar = '\0';
            this.txtReplace.PrefixSuffixText = null;
            this.txtReplace.ReadOnly = false;
            this.txtReplace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtReplace.SelectedText = "";
            this.txtReplace.SelectionLength = 0;
            this.txtReplace.SelectionStart = 0;
            this.txtReplace.ShortcutsEnabled = true;
            this.txtReplace.Size = new System.Drawing.Size(383, 48);
            this.txtReplace.TabIndex = 1;
            this.txtReplace.TabStop = false;
            this.txtReplace.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtReplace.TrailingIcon = null;
            this.txtReplace.UseSystemPasswordChar = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFind);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập TID hoặc Mã của tem đã bóc ra";
            // 
            // txtFind
            // 
            this.txtFind.AnimateReadOnly = false;
            this.txtFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtFind.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtFind.Depth = 0;
            this.txtFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFind.HideSelection = true;
            this.txtFind.Hint = "Nhập ...";
            this.txtFind.LeadingIcon = null;
            this.txtFind.Location = new System.Drawing.Point(3, 16);
            this.txtFind.MaxLength = 32767;
            this.txtFind.MouseState = MaterialSkin.MouseState.OUT;
            this.txtFind.Name = "txtFind";
            this.txtFind.PasswordChar = '\0';
            this.txtFind.PrefixSuffixText = null;
            this.txtFind.ReadOnly = false;
            this.txtFind.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFind.SelectedText = "";
            this.txtFind.SelectionLength = 0;
            this.txtFind.SelectionStart = 0;
            this.txtFind.ShortcutsEnabled = true;
            this.txtFind.Size = new System.Drawing.Size(383, 48);
            this.txtFind.TabIndex = 0;
            this.txtFind.TabStop = false;
            this.txtFind.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFind.TrailingIcon = null;
            this.txtFind.UseSystemPasswordChar = false;
            // 
            // btnFind
            // 
            this.btnFind.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFind.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnFind.Depth = 0;
            this.btnFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFind.HighEmphasis = true;
            this.btnFind.Icon = null;
            this.btnFind.Location = new System.Drawing.Point(399, 6);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFind.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFind.Name = "btnFind";
            this.btnFind.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnFind.Size = new System.Drawing.Size(116, 63);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnFind.UseAccentColor = false;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // FormChangeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 217);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormChangeItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "THAY TEM";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialTextBox2 txtFind;
        private MaterialSkin.Controls.MaterialTextBox2 txtReplace;
        private MaterialSkin.Controls.MaterialButton btnReplace;
        private MaterialSkin.Controls.MaterialButton btnFind;
    }
}