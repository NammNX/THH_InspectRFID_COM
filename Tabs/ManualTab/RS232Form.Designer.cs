namespace TanHungHa.Tabs.ManualTab
{
    partial class RS232Form
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDataSend = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDataReceiver = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.btnClearData = new MaterialSkin.Controls.MaterialButton();
            this.btnSendDataCom = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxRTS = new System.Windows.Forms.CheckBox();
            this.checkBoxDTR = new System.Windows.Forms.CheckBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.btnConnectComport = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.cbbStopbit = new MaterialSkin.Controls.MaterialComboBox();
            this.cbbHandshake = new MaterialSkin.Controls.MaterialComboBox();
            this.cbbParity = new MaterialSkin.Controls.MaterialComboBox();
            this.cbbDataSize = new MaterialSkin.Controls.MaterialComboBox();
            this.cbbBaud = new MaterialSkin.Controls.MaterialComboBox();
            this.cbbComPort = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.btnScanCom = new MaterialSkin.Controls.MaterialButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDataSend);
            this.groupBox2.Controls.Add(this.txtDataReceiver);
            this.groupBox2.Controls.Add(this.materialLabel10);
            this.groupBox2.Controls.Add(this.btnClearData);
            this.groupBox2.Controls.Add(this.btnSendDataCom);
            this.groupBox2.Controls.Add(this.materialLabel9);
            this.groupBox2.Location = new System.Drawing.Point(9, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 322);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // txtDataSend
            // 
            this.txtDataSend.AnimateReadOnly = false;
            this.txtDataSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDataSend.Depth = 0;
            this.txtDataSend.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDataSend.Hint = "Data to send";
            this.txtDataSend.LeadingIcon = global::TanHungHa.Properties.Resources.outline_send_black_24dp;
            this.txtDataSend.Location = new System.Drawing.Point(9, 274);
            this.txtDataSend.MaxLength = 50;
            this.txtDataSend.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDataSend.Multiline = false;
            this.txtDataSend.Name = "txtDataSend";
            this.txtDataSend.Size = new System.Drawing.Size(567, 50);
            this.txtDataSend.TabIndex = 7;
            this.txtDataSend.Text = "";
            this.txtDataSend.TrailingIcon = global::TanHungHa.Properties.Resources.outline_close_black_24dp;
            // 
            // txtDataReceiver
            // 
            this.txtDataReceiver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtDataReceiver.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDataReceiver.Depth = 0;
            this.txtDataReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.txtDataReceiver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtDataReceiver.Location = new System.Drawing.Point(7, 64);
            this.txtDataReceiver.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDataReceiver.Name = "txtDataReceiver";
            this.txtDataReceiver.Size = new System.Drawing.Size(633, 169);
            this.txtDataReceiver.TabIndex = 6;
            this.txtDataReceiver.Text = "";
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel10.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel10.HighEmphasis = true;
            this.materialLabel10.Location = new System.Drawing.Point(6, 240);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(46, 24);
            this.materialLabel10.TabIndex = 5;
            this.materialLabel10.Text = "Send";
            // 
            // btnClearData
            // 
            this.btnClearData.AutoSize = false;
            this.btnClearData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearData.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClearData.Depth = 0;
            this.btnClearData.HighEmphasis = true;
            this.btnClearData.Icon = global::TanHungHa.Properties.Resources.outline_cleaning_services_black_24dp;
            this.btnClearData.Location = new System.Drawing.Point(587, 19);
            this.btnClearData.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClearData.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClearData.Size = new System.Drawing.Size(45, 36);
            this.btnClearData.TabIndex = 9;
            this.btnClearData.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClearData.UseAccentColor = false;
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnSerialClick);
            // 
            // btnSendDataCom
            // 
            this.btnSendDataCom.AutoSize = false;
            this.btnSendDataCom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSendDataCom.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSendDataCom.Depth = 0;
            this.btnSendDataCom.HighEmphasis = true;
            this.btnSendDataCom.Icon = global::TanHungHa.Properties.Resources.outline_send_black_24dp;
            this.btnSendDataCom.Location = new System.Drawing.Point(587, 274);
            this.btnSendDataCom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSendDataCom.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSendDataCom.Name = "btnSendDataCom";
            this.btnSendDataCom.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSendDataCom.Size = new System.Drawing.Size(45, 36);
            this.btnSendDataCom.TabIndex = 9;
            this.btnSendDataCom.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSendDataCom.UseAccentColor = false;
            this.btnSendDataCom.UseVisualStyleBackColor = true;
            this.btnSendDataCom.Click += new System.EventHandler(this.btnSerialClick);
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel9.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel9.HighEmphasis = true;
            this.materialLabel9.Location = new System.Drawing.Point(6, 25);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(123, 24);
            this.materialLabel9.TabIndex = 5;
            this.materialLabel9.Text = "Receiver data";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxRTS);
            this.groupBox1.Controls.Add(this.checkBoxDTR);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.materialLabel8);
            this.groupBox1.Controls.Add(this.materialLabel7);
            this.groupBox1.Controls.Add(this.materialLabel6);
            this.groupBox1.Controls.Add(this.materialLabel5);
            this.groupBox1.Controls.Add(this.btnConnectComport);
            this.groupBox1.Controls.Add(this.materialLabel3);
            this.groupBox1.Controls.Add(this.cbbStopbit);
            this.groupBox1.Controls.Add(this.cbbHandshake);
            this.groupBox1.Controls.Add(this.cbbParity);
            this.groupBox1.Controls.Add(this.cbbDataSize);
            this.groupBox1.Controls.Add(this.cbbBaud);
            this.groupBox1.Controls.Add(this.cbbComPort);
            this.groupBox1.Location = new System.Drawing.Point(661, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 404);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // checkBoxRTS
            // 
            this.checkBoxRTS.AutoSize = true;
            this.checkBoxRTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRTS.Location = new System.Drawing.Point(156, 320);
            this.checkBoxRTS.Name = "checkBoxRTS";
            this.checkBoxRTS.Size = new System.Drawing.Size(54, 20);
            this.checkBoxRTS.TabIndex = 10;
            this.checkBoxRTS.Text = "RTS";
            this.checkBoxRTS.UseVisualStyleBackColor = true;
            // 
            // checkBoxDTR
            // 
            this.checkBoxDTR.AutoSize = true;
            this.checkBoxDTR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.checkBoxDTR.Location = new System.Drawing.Point(34, 320);
            this.checkBoxDTR.Name = "checkBoxDTR";
            this.checkBoxDTR.Size = new System.Drawing.Size(55, 20);
            this.checkBoxDTR.TabIndex = 10;
            this.checkBoxDTR.Text = "DTR";
            this.checkBoxDTR.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel1.HighEmphasis = true;
            this.materialLabel1.Location = new System.Drawing.Point(6, 281);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(30, 17);
            this.materialLabel1.TabIndex = 5;
            this.materialLabel1.Text = "Stop";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel8.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel8.HighEmphasis = true;
            this.materialLabel8.Location = new System.Drawing.Point(6, 230);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(73, 17);
            this.materialLabel8.TabIndex = 5;
            this.materialLabel8.Text = "Handshake";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel7.HighEmphasis = true;
            this.materialLabel7.Location = new System.Drawing.Point(6, 181);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(39, 17);
            this.materialLabel7.TabIndex = 5;
            this.materialLabel7.Text = "Parity";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel6.HighEmphasis = true;
            this.materialLabel6.Location = new System.Drawing.Point(6, 133);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(60, 17);
            this.materialLabel6.TabIndex = 5;
            this.materialLabel6.Text = "Data size";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel5.HighEmphasis = true;
            this.materialLabel5.Location = new System.Drawing.Point(6, 82);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(34, 17);
            this.materialLabel5.TabIndex = 5;
            this.materialLabel5.Text = "Baud";
            // 
            // btnConnectComport
            // 
            this.btnConnectComport.AutoSize = false;
            this.btnConnectComport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConnectComport.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConnectComport.Depth = 0;
            this.btnConnectComport.HighEmphasis = true;
            this.btnConnectComport.Icon = global::TanHungHa.Properties.Resources.outline_sensors_black_24dp;
            this.btnConnectComport.Location = new System.Drawing.Point(55, 359);
            this.btnConnectComport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConnectComport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConnectComport.Name = "btnConnectComport";
            this.btnConnectComport.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConnectComport.Size = new System.Drawing.Size(126, 36);
            this.btnConnectComport.TabIndex = 9;
            this.btnConnectComport.Text = "Connect";
            this.btnConnectComport.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConnectComport.UseAccentColor = false;
            this.btnConnectComport.UseVisualStyleBackColor = true;
            this.btnConnectComport.Click += new System.EventHandler(this.btnSerialClick);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel3.HighEmphasis = true;
            this.materialLabel3.Location = new System.Drawing.Point(6, 34);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(62, 17);
            this.materialLabel3.TabIndex = 5;
            this.materialLabel3.Text = "COM Port";
            // 
            // cbbStopbit
            // 
            this.cbbStopbit.AutoResize = false;
            this.cbbStopbit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbbStopbit.Depth = 0;
            this.cbbStopbit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbStopbit.DropDownHeight = 118;
            this.cbbStopbit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStopbit.DropDownWidth = 121;
            this.cbbStopbit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbbStopbit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbbStopbit.FormattingEnabled = true;
            this.cbbStopbit.Hint = "1";
            this.cbbStopbit.IntegralHeight = false;
            this.cbbStopbit.ItemHeight = 29;
            this.cbbStopbit.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbbStopbit.Location = new System.Drawing.Point(89, 263);
            this.cbbStopbit.MaxDropDownItems = 4;
            this.cbbStopbit.MouseState = MaterialSkin.MouseState.OUT;
            this.cbbStopbit.Name = "cbbStopbit";
            this.cbbStopbit.Size = new System.Drawing.Size(131, 35);
            this.cbbStopbit.StartIndex = 0;
            this.cbbStopbit.TabIndex = 8;
            this.cbbStopbit.UseTallSize = false;
            // 
            // cbbHandshake
            // 
            this.cbbHandshake.AutoResize = false;
            this.cbbHandshake.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbbHandshake.Depth = 0;
            this.cbbHandshake.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbHandshake.DropDownHeight = 118;
            this.cbbHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHandshake.DropDownWidth = 121;
            this.cbbHandshake.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbbHandshake.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbbHandshake.FormattingEnabled = true;
            this.cbbHandshake.Hint = "OFF";
            this.cbbHandshake.IntegralHeight = false;
            this.cbbHandshake.ItemHeight = 29;
            this.cbbHandshake.Location = new System.Drawing.Point(89, 212);
            this.cbbHandshake.MaxDropDownItems = 4;
            this.cbbHandshake.MouseState = MaterialSkin.MouseState.OUT;
            this.cbbHandshake.Name = "cbbHandshake";
            this.cbbHandshake.Size = new System.Drawing.Size(131, 35);
            this.cbbHandshake.StartIndex = 0;
            this.cbbHandshake.TabIndex = 8;
            this.cbbHandshake.UseTallSize = false;
            // 
            // cbbParity
            // 
            this.cbbParity.AutoResize = false;
            this.cbbParity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbbParity.Depth = 0;
            this.cbbParity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbParity.DropDownHeight = 118;
            this.cbbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbParity.DropDownWidth = 121;
            this.cbbParity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbbParity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbbParity.FormattingEnabled = true;
            this.cbbParity.Hint = "none";
            this.cbbParity.IntegralHeight = false;
            this.cbbParity.ItemHeight = 29;
            this.cbbParity.Location = new System.Drawing.Point(89, 163);
            this.cbbParity.MaxDropDownItems = 4;
            this.cbbParity.MouseState = MaterialSkin.MouseState.OUT;
            this.cbbParity.Name = "cbbParity";
            this.cbbParity.Size = new System.Drawing.Size(131, 35);
            this.cbbParity.StartIndex = 0;
            this.cbbParity.TabIndex = 8;
            this.cbbParity.UseTallSize = false;
            // 
            // cbbDataSize
            // 
            this.cbbDataSize.AutoResize = false;
            this.cbbDataSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbbDataSize.Depth = 0;
            this.cbbDataSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbDataSize.DropDownHeight = 118;
            this.cbbDataSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDataSize.DropDownWidth = 121;
            this.cbbDataSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbbDataSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbbDataSize.FormattingEnabled = true;
            this.cbbDataSize.Hint = "8";
            this.cbbDataSize.IntegralHeight = false;
            this.cbbDataSize.ItemHeight = 29;
            this.cbbDataSize.Location = new System.Drawing.Point(89, 115);
            this.cbbDataSize.MaxDropDownItems = 4;
            this.cbbDataSize.MouseState = MaterialSkin.MouseState.OUT;
            this.cbbDataSize.Name = "cbbDataSize";
            this.cbbDataSize.Size = new System.Drawing.Size(131, 35);
            this.cbbDataSize.StartIndex = 0;
            this.cbbDataSize.TabIndex = 8;
            this.cbbDataSize.UseTallSize = false;
            // 
            // cbbBaud
            // 
            this.cbbBaud.AutoResize = false;
            this.cbbBaud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbbBaud.Depth = 0;
            this.cbbBaud.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbBaud.DropDownHeight = 118;
            this.cbbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBaud.DropDownWidth = 121;
            this.cbbBaud.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbbBaud.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbbBaud.FormattingEnabled = true;
            this.cbbBaud.Hint = "19200";
            this.cbbBaud.IntegralHeight = false;
            this.cbbBaud.ItemHeight = 29;
            this.cbbBaud.Location = new System.Drawing.Point(89, 64);
            this.cbbBaud.MaxDropDownItems = 4;
            this.cbbBaud.MouseState = MaterialSkin.MouseState.OUT;
            this.cbbBaud.Name = "cbbBaud";
            this.cbbBaud.Size = new System.Drawing.Size(131, 35);
            this.cbbBaud.StartIndex = 0;
            this.cbbBaud.TabIndex = 8;
            this.cbbBaud.UseTallSize = false;
            // 
            // cbbComPort
            // 
            this.cbbComPort.AutoResize = false;
            this.cbbComPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbbComPort.Depth = 0;
            this.cbbComPort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbComPort.DropDownHeight = 118;
            this.cbbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbComPort.DropDownWidth = 121;
            this.cbbComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbbComPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbbComPort.FormattingEnabled = true;
            this.cbbComPort.Hint = "COM1";
            this.cbbComPort.IntegralHeight = false;
            this.cbbComPort.ItemHeight = 29;
            this.cbbComPort.Location = new System.Drawing.Point(89, 16);
            this.cbbComPort.MaxDropDownItems = 4;
            this.cbbComPort.MouseState = MaterialSkin.MouseState.OUT;
            this.cbbComPort.Name = "cbbComPort";
            this.cbbComPort.Size = new System.Drawing.Size(131, 35);
            this.cbbComPort.StartIndex = 0;
            this.cbbComPort.TabIndex = 8;
            this.cbbComPort.UseTallSize = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.materialLabel2.HighEmphasis = true;
            this.materialLabel2.Location = new System.Drawing.Point(9, 31);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(155, 41);
            this.materialLabel2.TabIndex = 12;
            this.materialLabel2.Text = "Serial port";
            // 
            // btnScanCom
            // 
            this.btnScanCom.AutoSize = false;
            this.btnScanCom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnScanCom.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnScanCom.Depth = 0;
            this.btnScanCom.HighEmphasis = true;
            this.btnScanCom.Icon = null;
            this.btnScanCom.Location = new System.Drawing.Point(661, 30);
            this.btnScanCom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnScanCom.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnScanCom.Name = "btnScanCom";
            this.btnScanCom.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnScanCom.Size = new System.Drawing.Size(126, 36);
            this.btnScanCom.TabIndex = 16;
            this.btnScanCom.Text = "SCAN COM";
            this.btnScanCom.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnScanCom.UseAccentColor = false;
            this.btnScanCom.UseVisualStyleBackColor = true;
            this.btnScanCom.Click += new System.EventHandler(this.btnSerialClick);
            // 
            // RS232Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1171, 485);
            this.Controls.Add(this.btnScanCom);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.materialLabel2);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "RS232Form";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "RS232Form";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialTextBox txtDataSend;
        private MaterialSkin.Controls.MaterialMultiLineTextBox txtDataReceiver;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialButton btnClearData;
        private MaterialSkin.Controls.MaterialButton btnSendDataCom;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialButton btnConnectComport;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialComboBox cbbHandshake;
        private MaterialSkin.Controls.MaterialComboBox cbbParity;
        private MaterialSkin.Controls.MaterialComboBox cbbDataSize;
        private MaterialSkin.Controls.MaterialComboBox cbbBaud;
        private MaterialSkin.Controls.MaterialComboBox cbbComPort;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.CheckBox checkBoxRTS;
        private System.Windows.Forms.CheckBox checkBoxDTR;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialComboBox cbbStopbit;
        private MaterialSkin.Controls.MaterialButton btnScanCom;
    }
}