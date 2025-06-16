namespace TanHungHa.PopUp
{
    partial class FormListTIDEmpty
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
            this.listBoxTidEmpty = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxTidEmpty
            // 
            this.listBoxTidEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTidEmpty.FormattingEnabled = true;
            this.listBoxTidEmpty.Location = new System.Drawing.Point(3, 64);
            this.listBoxTidEmpty.Name = "listBoxTidEmpty";
            this.listBoxTidEmpty.Size = new System.Drawing.Size(559, 268);
            this.listBoxTidEmpty.TabIndex = 0;
            // 
            // FormListTIDEmpty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 335);
            this.Controls.Add(this.listBoxTidEmpty);
            this.Name = "FormListTIDEmpty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách TID trống";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTidEmpty;
    }
}