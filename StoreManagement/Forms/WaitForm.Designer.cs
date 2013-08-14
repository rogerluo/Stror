namespace StoreManagement
{
    partial class WaitForm
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
            this.pbxThrobber = new System.Windows.Forms.PictureBox();
            this.lblDesc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxThrobber)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxThrobber
            // 
            this.pbxThrobber.Image = global::StoreManagement.Properties.Resources.throbber;
            this.pbxThrobber.Location = new System.Drawing.Point(24, 14);
            this.pbxThrobber.Name = "pbxThrobber";
            this.pbxThrobber.Size = new System.Drawing.Size(25, 25);
            this.pbxThrobber.TabIndex = 0;
            this.pbxThrobber.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(67, 20);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(47, 12);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "lblDesc";
            // 
            // WaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 59);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.pbxThrobber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WaitForm";
            this.Shown += new System.EventHandler(this.WaitForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxThrobber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxThrobber;
        private System.Windows.Forms.Label lblDesc;
    }
}