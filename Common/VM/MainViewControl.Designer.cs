namespace TanHungHa.Common.VM
{
    partial class MainViewControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vmMainViewConfigControl1 = new VMControls.Winform.Release.VmMainViewConfigControl();
            this.SuspendLayout();
            // 
            // vmMainViewConfigControl1
            // 
            this.vmMainViewConfigControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmMainViewConfigControl1.Location = new System.Drawing.Point(0, 0);
            this.vmMainViewConfigControl1.Margin = new System.Windows.Forms.Padding(2);
            this.vmMainViewConfigControl1.Name = "vmMainViewConfigControl1";
            this.vmMainViewConfigControl1.Size = new System.Drawing.Size(382, 347);
            this.vmMainViewConfigControl1.TabIndex = 0;
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            // 
            // MainViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vmMainViewConfigControl1);
            this.Name = "MainViewControl";
            this.Size = new System.Drawing.Size(382, 347);
            this.ResumeLayout(false);

        }

        #endregion

        private VMControls.Winform.Release.VmMainViewConfigControl vmMainViewConfigControl1;
    }
}
