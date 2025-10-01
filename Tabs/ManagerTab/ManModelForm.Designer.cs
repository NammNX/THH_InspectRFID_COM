namespace TanHungHa.Tabs.ManagerTab
{
    partial class ManModelForm
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
            this.panelView = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lvModels = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tablelayoutpanelModelnameJOB = new System.Windows.Forms.TableLayoutPanel();
            this.txtPathJob = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.txtModelName = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnActive = new MaterialSkin.Controls.MaterialButton();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnDel = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpdate = new MaterialSkin.Controls.MaterialButton();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.btnCheck = new MaterialSkin.Controls.MaterialButton();
            this.swStatus = new MaterialSkin.Controls.MaterialSwitch();
            this.panelView.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tablelayoutpanelModelnameJOB.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelView
            // 
            this.panelView.Controls.Add(this.tableLayoutPanel2);
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(3, 41);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(794, 406);
            this.panelView.TabIndex = 20;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.lvModels, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tablelayoutpanelModelnameJOB, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 406F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 406);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lvModels
            // 
            this.lvModels.AutoSizeTable = false;
            this.lvModels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lvModels.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvModels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader3});
            this.lvModels.Depth = 0;
            this.lvModels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvModels.FullRowSelect = true;
            this.lvModels.HideSelection = false;
            this.lvModels.Location = new System.Drawing.Point(479, 3);
            this.lvModels.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvModels.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lvModels.MouseState = MaterialSkin.MouseState.OUT;
            this.lvModels.Name = "lvModels";
            this.lvModels.OwnerDraw = true;
            this.lvModels.Size = new System.Drawing.Size(312, 400);
            this.lvModels.TabIndex = 95;
            this.lvModels.UseCompatibleStateImageBehavior = false;
            this.lvModels.View = System.Windows.Forms.View.Details;
            this.lvModels.SelectedIndexChanged += new System.EventHandler(this.lvModels_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Active";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Model";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Job Path";
            this.columnHeader3.Width = 1200;
            // 
            // tablelayoutpanelModelnameJOB
            // 
            this.tablelayoutpanelModelnameJOB.ColumnCount = 2;
            this.tablelayoutpanelModelnameJOB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.34043F));
            this.tablelayoutpanelModelnameJOB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.65958F));
            this.tablelayoutpanelModelnameJOB.Controls.Add(this.txtPathJob, 1, 1);
            this.tablelayoutpanelModelnameJOB.Controls.Add(this.materialButton1, 0, 0);
            this.tablelayoutpanelModelnameJOB.Controls.Add(this.materialButton2, 0, 1);
            this.tablelayoutpanelModelnameJOB.Controls.Add(this.txtModelName, 1, 0);
            this.tablelayoutpanelModelnameJOB.Dock = System.Windows.Forms.DockStyle.Top;
            this.tablelayoutpanelModelnameJOB.Location = new System.Drawing.Point(3, 3);
            this.tablelayoutpanelModelnameJOB.Name = "tablelayoutpanelModelnameJOB";
            this.tablelayoutpanelModelnameJOB.RowCount = 2;
            this.tablelayoutpanelModelnameJOB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablelayoutpanelModelnameJOB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablelayoutpanelModelnameJOB.Size = new System.Drawing.Size(470, 100);
            this.tablelayoutpanelModelnameJOB.TabIndex = 96;
            // 
            // txtPathJob
            // 
            this.txtPathJob.AllowPromptAsInput = true;
            this.txtPathJob.AnimateReadOnly = false;
            this.txtPathJob.AsciiOnly = false;
            this.txtPathJob.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPathJob.BeepOnError = false;
            this.txtPathJob.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtPathJob.Depth = 0;
            this.txtPathJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPathJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPathJob.HidePromptOnLeave = false;
            this.txtPathJob.HideSelection = true;
            this.txtPathJob.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtPathJob.LeadingIcon = global::TanHungHa.Properties.Resources.outline_folder_open_black_18dp;
            this.txtPathJob.Location = new System.Drawing.Point(108, 53);
            this.txtPathJob.Mask = "";
            this.txtPathJob.MaxLength = 32767;
            this.txtPathJob.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPathJob.Name = "txtPathJob";
            this.txtPathJob.PasswordChar = '\0';
            this.txtPathJob.PrefixSuffixText = null;
            this.txtPathJob.PromptChar = '_';
            this.txtPathJob.ReadOnly = true;
            this.txtPathJob.RejectInputOnFirstFailure = false;
            this.txtPathJob.ResetOnPrompt = true;
            this.txtPathJob.ResetOnSpace = true;
            this.txtPathJob.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPathJob.SelectedText = "";
            this.txtPathJob.SelectionLength = 0;
            this.txtPathJob.SelectionStart = 0;
            this.txtPathJob.ShortcutsEnabled = true;
            this.txtPathJob.Size = new System.Drawing.Size(359, 48);
            this.txtPathJob.SkipLiterals = true;
            this.txtPathJob.TabIndex = 3;
            this.txtPathJob.TabStop = false;
            this.txtPathJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPathJob.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtPathJob.TrailingIcon = null;
            this.txtPathJob.UseSystemPasswordChar = false;
            this.txtPathJob.ValidatingType = null;
            this.txtPathJob.LeadingIconClick += new System.EventHandler(this.txtPathJob_LeadingIconClick);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(4, 6);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(97, 38);
            this.materialButton1.TabIndex = 0;
            this.materialButton1.Text = "Model Name";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(4, 56);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(97, 38);
            this.materialButton2.TabIndex = 1;
            this.materialButton2.Text = "Vision Job";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            // 
            // txtModelName
            // 
            this.txtModelName.AllowPromptAsInput = true;
            this.txtModelName.AnimateReadOnly = false;
            this.txtModelName.AsciiOnly = false;
            this.txtModelName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtModelName.BeepOnError = false;
            this.txtModelName.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtModelName.Depth = 0;
            this.txtModelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtModelName.HidePromptOnLeave = false;
            this.txtModelName.HideSelection = true;
            this.txtModelName.Hint = "Nhập tên model";
            this.txtModelName.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtModelName.LeadingIcon = null;
            this.txtModelName.Location = new System.Drawing.Point(108, 3);
            this.txtModelName.Mask = "";
            this.txtModelName.MaxLength = 32767;
            this.txtModelName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.PasswordChar = '\0';
            this.txtModelName.PrefixSuffixText = null;
            this.txtModelName.PromptChar = '_';
            this.txtModelName.ReadOnly = false;
            this.txtModelName.RejectInputOnFirstFailure = false;
            this.txtModelName.ResetOnPrompt = true;
            this.txtModelName.ResetOnSpace = true;
            this.txtModelName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtModelName.SelectedText = "";
            this.txtModelName.SelectionLength = 0;
            this.txtModelName.SelectionStart = 0;
            this.txtModelName.ShortcutsEnabled = true;
            this.txtModelName.Size = new System.Drawing.Size(359, 48);
            this.txtModelName.SkipLiterals = true;
            this.txtModelName.TabIndex = 2;
            this.txtModelName.TabStop = false;
            this.txtModelName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtModelName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtModelName.TrailingIcon = null;
            this.txtModelName.UseSystemPasswordChar = false;
            this.txtModelName.ValidatingType = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 41);
            this.panel1.TabIndex = 19;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 41);
            this.tableLayoutPanel1.TabIndex = 65;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.btnActive, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnDel, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(479, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(312, 35);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // btnActive
            // 
            this.btnActive.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActive.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnActive.Depth = 0;
            this.btnActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnActive.HighEmphasis = true;
            this.btnActive.Icon = null;
            this.btnActive.Location = new System.Drawing.Point(212, 6);
            this.btnActive.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnActive.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnActive.Name = "btnActive";
            this.btnActive.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnActive.Size = new System.Drawing.Size(96, 23);
            this.btnActive.TabIndex = 2;
            this.btnActive.Text = "Active";
            this.btnActive.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnActive.UseAccentColor = true;
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(108, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(96, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnSave.UseAccentColor = true;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDel.Depth = 0;
            this.btnDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDel.HighEmphasis = true;
            this.btnDel.Icon = null;
            this.btnDel.Location = new System.Drawing.Point(4, 6);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDel.Name = "btnDel";
            this.btnDel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDel.Size = new System.Drawing.Size(96, 23);
            this.btnDel.TabIndex = 0;
            this.btnDel.Text = "Del";
            this.btnDel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnDel.UseAccentColor = true;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Controls.Add(this.btnUpdate, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnAdd, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.materialLabel2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnCheck, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.swStatus, 4, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(470, 35);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnUpdate.Depth = 0;
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.HighEmphasis = true;
            this.btnUpdate.Icon = null;
            this.btnUpdate.Location = new System.Drawing.Point(286, 6);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnUpdate.Size = new System.Drawing.Size(86, 23);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnUpdate.UseAccentColor = false;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdd.Depth = 0;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.HighEmphasis = true;
            this.btnAdd.Icon = null;
            this.btnAdd.Location = new System.Drawing.Point(192, 6);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAdd.Size = new System.Drawing.Size(86, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add";
            this.btnAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAdd.UseAccentColor = false;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.materialLabel2.HighEmphasis = true;
            this.materialLabel2.Location = new System.Drawing.Point(3, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(88, 35);
            this.materialLabel2.TabIndex = 14;
            this.materialLabel2.Text = "Model";
            // 
            // btnCheck
            // 
            this.btnCheck.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCheck.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCheck.Depth = 0;
            this.btnCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheck.HighEmphasis = true;
            this.btnCheck.Icon = null;
            this.btnCheck.Location = new System.Drawing.Point(98, 6);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCheck.Size = new System.Drawing.Size(86, 23);
            this.btnCheck.TabIndex = 15;
            this.btnCheck.Text = "Check";
            this.btnCheck.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCheck.UseAccentColor = false;
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // swStatus
            // 
            this.swStatus.AutoSize = true;
            this.swStatus.Depth = 0;
            this.swStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.swStatus.Location = new System.Drawing.Point(376, 0);
            this.swStatus.Margin = new System.Windows.Forms.Padding(0);
            this.swStatus.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.swStatus.Name = "swStatus";
            this.swStatus.ReadOnly = true;
            this.swStatus.Ripple = true;
            this.swStatus.Size = new System.Drawing.Size(94, 35);
            this.swStatus.TabIndex = 18;
            this.swStatus.Text = "Status";
            this.swStatus.UseVisualStyleBackColor = true;
            // 
            // ManModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "ManModelForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "ManModel";
            this.Load += new System.EventHandler(this.ManModelForm_Load);
            this.panelView.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tablelayoutpanelModelnameJOB.ResumeLayout(false);
            this.tablelayoutpanelModelnameJOB.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialListView lvModels;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tablelayoutpanelModelnameJOB;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtModelName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnDel;
        private MaterialSkin.Controls.MaterialButton btnActive;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialButton btnCheck;
        private MaterialSkin.Controls.MaterialButton btnUpdate;
        private MaterialSkin.Controls.MaterialButton btnAdd;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtPathJob;
        private MaterialSkin.Controls.MaterialSwitch swStatus;
    }
}