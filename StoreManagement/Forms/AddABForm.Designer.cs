namespace StoreManagement
{
    partial class AddABForm
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
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblABName = new System.Windows.Forms.Label();
            this.tbxABName = new System.Windows.Forms.TextBox();
            this.lblDBName = new System.Windows.Forms.Label();
            this.tbxDBName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(183, 9);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "btnYes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(183, 42);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "btnNo";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(13, 71);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(47, 12);
            this.lblDesc.TabIndex = 3;
            this.lblDesc.Text = "lblDesc";
            // 
            // lblABName
            // 
            this.lblABName.AutoSize = true;
            this.lblABName.Location = new System.Drawing.Point(11, 14);
            this.lblABName.Name = "lblABName";
            this.lblABName.Size = new System.Drawing.Size(59, 12);
            this.lblABName.TabIndex = 0;
            this.lblABName.Text = "lblABName";
            // 
            // tbxABName
            // 
            this.tbxABName.Location = new System.Drawing.Point(77, 14);
            this.tbxABName.Name = "tbxABName";
            this.tbxABName.Size = new System.Drawing.Size(100, 21);
            this.tbxABName.TabIndex = 1;
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(13, 42);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(59, 12);
            this.lblDBName.TabIndex = 2;
            this.lblDBName.Text = "lblDBName";
            // 
            // tbxDBName
            // 
            this.tbxDBName.Location = new System.Drawing.Point(77, 42);
            this.tbxDBName.Name = "tbxDBName";
            this.tbxDBName.Size = new System.Drawing.Size(100, 21);
            this.tbxDBName.TabIndex = 3;
            // 
            // AddAB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 91);
            this.Controls.Add(this.tbxDBName);
            this.Controls.Add(this.lblDBName);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.tbxABName);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.lblABName);
            this.Controls.Add(this.btnYes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "创建账本";
            this.Load += new System.EventHandler(this.AddAB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblABName;
        private System.Windows.Forms.TextBox tbxABName;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.TextBox tbxDBName;
    }
}