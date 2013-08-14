namespace StoreManagement
{
    partial class PicCompressForm
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
            this.pnlCtrl = new System.Windows.Forms.Panel();
            this.tbxHeight = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.tbxWidth = new System.Windows.Forms.TextBox();
            this.cbxRestrain = new System.Windows.Forms.CheckBox();
            this.btnAfterComp = new System.Windows.Forms.Button();
            this.btnBeforeComp = new System.Windows.Forms.Button();
            this.lblAfterComp = new System.Windows.Forms.Label();
            this.lblBeforeComp = new System.Windows.Forms.Label();
            this.btnComp = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblCompRadio = new System.Windows.Forms.Label();
            this.tbrCompRadio = new System.Windows.Forms.TrackBar();
            this.pnlPic = new System.Windows.Forms.Panel();
            this.pbxPic = new System.Windows.Forms.PictureBox();
            this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.pnlCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrCompRadio)).BeginInit();
            this.pnlPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPic)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCtrl
            // 
            this.pnlCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCtrl.Controls.Add(this.tbxHeight);
            this.pnlCtrl.Controls.Add(this.lblHeight);
            this.pnlCtrl.Controls.Add(this.lblWidth);
            this.pnlCtrl.Controls.Add(this.tbxWidth);
            this.pnlCtrl.Controls.Add(this.cbxRestrain);
            this.pnlCtrl.Controls.Add(this.btnAfterComp);
            this.pnlCtrl.Controls.Add(this.btnBeforeComp);
            this.pnlCtrl.Controls.Add(this.lblAfterComp);
            this.pnlCtrl.Controls.Add(this.lblBeforeComp);
            this.pnlCtrl.Controls.Add(this.btnComp);
            this.pnlCtrl.Controls.Add(this.btnOpen);
            this.pnlCtrl.Controls.Add(this.lblCompRadio);
            this.pnlCtrl.Controls.Add(this.tbrCompRadio);
            this.pnlCtrl.Location = new System.Drawing.Point(32, 12);
            this.pnlCtrl.Name = "pnlCtrl";
            this.pnlCtrl.Size = new System.Drawing.Size(184, 302);
            this.pnlCtrl.TabIndex = 0;
            // 
            // tbxHeight
            // 
            this.tbxHeight.Location = new System.Drawing.Point(84, 231);
            this.tbxHeight.Name = "tbxHeight";
            this.tbxHeight.Size = new System.Drawing.Size(57, 21);
            this.tbxHeight.TabIndex = 24;
            this.tbxHeight.Validating += new System.ComponentModel.CancelEventHandler(this.tbxHeight_Validating);
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(19, 231);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(59, 12);
            this.lblHeight.TabIndex = 23;
            this.lblHeight.Text = "lblHeight";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(19, 215);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(53, 12);
            this.lblWidth.TabIndex = 22;
            this.lblWidth.Text = "lblWidth";
            // 
            // tbxWidth
            // 
            this.tbxWidth.Location = new System.Drawing.Point(69, 212);
            this.tbxWidth.Name = "tbxWidth";
            this.tbxWidth.Size = new System.Drawing.Size(58, 21);
            this.tbxWidth.TabIndex = 21;
            this.tbxWidth.TextChanged += new System.EventHandler(this.tbxWidth_TextChanged);
            // 
            // cbxRestrain
            // 
            this.cbxRestrain.AutoSize = true;
            this.cbxRestrain.Location = new System.Drawing.Point(19, 269);
            this.cbxRestrain.Name = "cbxRestrain";
            this.cbxRestrain.Size = new System.Drawing.Size(78, 16);
            this.cbxRestrain.TabIndex = 20;
            this.cbxRestrain.Text = "checkBox1";
            this.cbxRestrain.UseVisualStyleBackColor = true;
            this.cbxRestrain.CheckedChanged += new System.EventHandler(this.cbxRestrain_CheckedChanged);
            // 
            // btnAfterComp
            // 
            this.btnAfterComp.Location = new System.Drawing.Point(101, 186);
            this.btnAfterComp.Name = "btnAfterComp";
            this.btnAfterComp.Size = new System.Drawing.Size(75, 23);
            this.btnAfterComp.TabIndex = 19;
            this.btnAfterComp.Text = "btnAfterComp";
            this.btnAfterComp.UseVisualStyleBackColor = true;
            this.btnAfterComp.Click += new System.EventHandler(this.btnAfterComp_Click);
            // 
            // btnBeforeComp
            // 
            this.btnBeforeComp.Location = new System.Drawing.Point(19, 186);
            this.btnBeforeComp.Name = "btnBeforeComp";
            this.btnBeforeComp.Size = new System.Drawing.Size(75, 23);
            this.btnBeforeComp.TabIndex = 18;
            this.btnBeforeComp.Text = "btnBeforeComp";
            this.btnBeforeComp.UseVisualStyleBackColor = true;
            this.btnBeforeComp.Click += new System.EventHandler(this.btnBeforeComp_Click);
            // 
            // lblAfterComp
            // 
            this.lblAfterComp.Location = new System.Drawing.Point(19, 158);
            this.lblAfterComp.Name = "lblAfterComp";
            this.lblAfterComp.Size = new System.Drawing.Size(100, 23);
            this.lblAfterComp.TabIndex = 16;
            this.lblAfterComp.Text = "lblAfterComp";
            // 
            // lblBeforeComp
            // 
            this.lblBeforeComp.Location = new System.Drawing.Point(19, 132);
            this.lblBeforeComp.Name = "lblBeforeComp";
            this.lblBeforeComp.Size = new System.Drawing.Size(100, 23);
            this.lblBeforeComp.TabIndex = 14;
            this.lblBeforeComp.Text = "lblBeforeComp";
            // 
            // btnComp
            // 
            this.btnComp.Location = new System.Drawing.Point(101, 4);
            this.btnComp.Name = "btnComp";
            this.btnComp.Size = new System.Drawing.Size(75, 23);
            this.btnComp.TabIndex = 13;
            this.btnComp.Text = "btnComp";
            this.btnComp.UseVisualStyleBackColor = true;
            this.btnComp.Click += new System.EventHandler(this.btnComp_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(19, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 12;
            this.btnOpen.Text = "btnOpen";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblCompRadio
            // 
            this.lblCompRadio.Location = new System.Drawing.Point(27, 56);
            this.lblCompRadio.Name = "lblCompRadio";
            this.lblCompRadio.Size = new System.Drawing.Size(100, 23);
            this.lblCompRadio.TabIndex = 11;
            this.lblCompRadio.Text = "lblCompRadio";
            // 
            // tbrCompRadio
            // 
            this.tbrCompRadio.BackColor = System.Drawing.SystemColors.Control;
            this.tbrCompRadio.LargeChange = 10;
            this.tbrCompRadio.Location = new System.Drawing.Point(19, 80);
            this.tbrCompRadio.Maximum = 100;
            this.tbrCompRadio.Minimum = 1;
            this.tbrCompRadio.Name = "tbrCompRadio";
            this.tbrCompRadio.Size = new System.Drawing.Size(143, 45);
            this.tbrCompRadio.TabIndex = 10;
            this.tbrCompRadio.TickFrequency = 10;
            this.tbrCompRadio.Value = 50;
            this.tbrCompRadio.Scroll += new System.EventHandler(this.tbrCompRadio_Scroll);
            // 
            // pnlPic
            // 
            this.pnlPic.AutoScroll = true;
            this.pnlPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPic.Controls.Add(this.pbxPic);
            this.pnlPic.Location = new System.Drawing.Point(238, 12);
            this.pnlPic.Name = "pnlPic";
            this.pnlPic.Size = new System.Drawing.Size(337, 257);
            this.pnlPic.TabIndex = 1;
            this.pnlPic.Resize += new System.EventHandler(this.pnlPic_Resize);
            // 
            // pbxPic
            // 
            this.pbxPic.Location = new System.Drawing.Point(116, 56);
            this.pbxPic.Name = "pbxPic";
            this.pbxPic.Size = new System.Drawing.Size(100, 50);
            this.pbxPic.TabIndex = 0;
            this.pbxPic.TabStop = false;
            this.pbxPic.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pbxPic_LoadCompleted);
            this.pbxPic.LoadProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.pbxPic_LoadProgressChanged);
            // 
            // ofdOpen
            // 
            this.ofdOpen.FileName = "ofdOpen";
            // 
            // stsStatus
            // 
            this.stsStatus.Location = new System.Drawing.Point(0, 347);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(587, 22);
            this.stsStatus.TabIndex = 2;
            this.stsStatus.Text = "stsStatus";
            // 
            // PicCompressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 369);
            this.Controls.Add(this.pnlPic);
            this.Controls.Add(this.pnlCtrl);
            this.Controls.Add(this.stsStatus);
            this.Name = "PicCompressForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图片压缩";
            this.pnlCtrl.ResumeLayout(false);
            this.pnlCtrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrCompRadio)).EndInit();
            this.pnlPic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCtrl;
        private System.Windows.Forms.Panel pnlPic;
        private System.Windows.Forms.Label lblCompRadio;
        private System.Windows.Forms.TrackBar tbrCompRadio;
        private System.Windows.Forms.Button btnComp;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnAfterComp;
        private System.Windows.Forms.Button btnBeforeComp;
        private System.Windows.Forms.Label lblAfterComp;
        private System.Windows.Forms.Label lblBeforeComp;
        private System.Windows.Forms.PictureBox pbxPic;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.CheckBox cbxRestrain;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox tbxWidth;
        private System.Windows.Forms.TextBox tbxHeight;


    }
}