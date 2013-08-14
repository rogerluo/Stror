namespace StoreManagement
{
    partial class LoginGuideForm
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
            this.pnlAddr = new System.Windows.Forms.Panel();
            this.tbxDBPwd = new System.Windows.Forms.TextBox();
            this.lblDBPwd = new System.Windows.Forms.Label();
            this.tbxDBUser = new System.Windows.Forms.TextBox();
            this.lblDBUser = new System.Windows.Forms.Label();
            this.lblTestConnetc = new System.Windows.Forms.Label();
            this.btnTestConnect = new System.Windows.Forms.Button();
            this.tbxAddrPort = new System.Windows.Forms.TextBox();
            this.lblAddrPort = new System.Windows.Forms.Label();
            this.cmbDBList = new System.Windows.Forms.ComboBox();
            this.lblDBList = new System.Windows.Forms.Label();
            this.pbxLoad = new System.Windows.Forms.PictureBox();
            this.cmbAddrList = new System.Windows.Forms.ComboBox();
            this.lblAddrList = new System.Windows.Forms.Label();
            this.lblAddrDesc = new System.Windows.Forms.Label();
            this.pnlDB = new System.Windows.Forms.Panel();
            this.btnInvAB = new System.Windows.Forms.Button();
            this.btnAllAB = new System.Windows.Forms.Button();
            this.btnDelAB = new System.Windows.Forms.Button();
            this.btnAddAB = new System.Windows.Forms.Button();
            this.dgvABList = new System.Windows.Forms.DataGridView();
            this.lblABDesc = new System.Windows.Forms.Label();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnFin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlAuth = new System.Windows.Forms.Panel();
            this.tbxAuthPwd = new System.Windows.Forms.TextBox();
            this.lblAuthPwd = new System.Windows.Forms.Label();
            this.cmbAuthUser = new System.Windows.Forms.ComboBox();
            this.lblAuthUser = new System.Windows.Forms.Label();
            this.dtpLogDate = new System.Windows.Forms.DateTimePicker();
            this.lblLogDateDesc = new System.Windows.Forms.Label();
            this.pnlAddr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).BeginInit();
            this.pnlDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvABList)).BeginInit();
            this.pnlControl.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlAuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAddr
            // 
            this.pnlAddr.Controls.Add(this.tbxDBPwd);
            this.pnlAddr.Controls.Add(this.lblDBPwd);
            this.pnlAddr.Controls.Add(this.tbxDBUser);
            this.pnlAddr.Controls.Add(this.lblDBUser);
            this.pnlAddr.Controls.Add(this.lblTestConnetc);
            this.pnlAddr.Controls.Add(this.btnTestConnect);
            this.pnlAddr.Controls.Add(this.tbxAddrPort);
            this.pnlAddr.Controls.Add(this.lblAddrPort);
            this.pnlAddr.Controls.Add(this.cmbDBList);
            this.pnlAddr.Controls.Add(this.lblDBList);
            this.pnlAddr.Controls.Add(this.pbxLoad);
            this.pnlAddr.Controls.Add(this.cmbAddrList);
            this.pnlAddr.Controls.Add(this.lblAddrList);
            this.pnlAddr.Controls.Add(this.lblAddrDesc);
            this.pnlAddr.Location = new System.Drawing.Point(11, 11);
            this.pnlAddr.Name = "pnlAddr";
            this.pnlAddr.Size = new System.Drawing.Size(167, 91);
            this.pnlAddr.TabIndex = 0;
            // 
            // tbxDBPwd
            // 
            this.tbxDBPwd.Location = new System.Drawing.Point(87, 217);
            this.tbxDBPwd.Name = "tbxDBPwd";
            this.tbxDBPwd.Size = new System.Drawing.Size(55, 21);
            this.tbxDBPwd.TabIndex = 13;
            this.tbxDBPwd.UseSystemPasswordChar = true;
            this.tbxDBPwd.TextChanged += new System.EventHandler(this.tbxDBPwd_TextChanged);
            this.tbxDBPwd.Validating += new System.ComponentModel.CancelEventHandler(this.tbxDBPwd_Validating);
            // 
            // lblDBPwd
            // 
            this.lblDBPwd.AutoSize = true;
            this.lblDBPwd.Location = new System.Drawing.Point(23, 227);
            this.lblDBPwd.Name = "lblDBPwd";
            this.lblDBPwd.Size = new System.Drawing.Size(53, 12);
            this.lblDBPwd.TabIndex = 12;
            this.lblDBPwd.Text = "lblDBPwd";
            // 
            // tbxDBUser
            // 
            this.tbxDBUser.Location = new System.Drawing.Point(87, 189);
            this.tbxDBUser.Name = "tbxDBUser";
            this.tbxDBUser.Size = new System.Drawing.Size(55, 21);
            this.tbxDBUser.TabIndex = 11;
            this.tbxDBUser.TextChanged += new System.EventHandler(this.tbxDBUser_TextChanged);
            this.tbxDBUser.Validating += new System.ComponentModel.CancelEventHandler(this.tbxDBUser_Validating);
            // 
            // lblDBUser
            // 
            this.lblDBUser.AutoSize = true;
            this.lblDBUser.Location = new System.Drawing.Point(21, 189);
            this.lblDBUser.Name = "lblDBUser";
            this.lblDBUser.Size = new System.Drawing.Size(59, 12);
            this.lblDBUser.TabIndex = 10;
            this.lblDBUser.Text = "lblDBUser";
            // 
            // lblTestConnetc
            // 
            this.lblTestConnetc.AutoSize = true;
            this.lblTestConnetc.Location = new System.Drawing.Point(21, 173);
            this.lblTestConnetc.Name = "lblTestConnetc";
            this.lblTestConnetc.Size = new System.Drawing.Size(89, 12);
            this.lblTestConnetc.TabIndex = 9;
            this.lblTestConnetc.Text = "lblTestConnetc";
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.Location = new System.Drawing.Point(67, 141);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(75, 23);
            this.btnTestConnect.TabIndex = 8;
            this.btnTestConnect.Text = "btnTestConnect";
            this.btnTestConnect.UseVisualStyleBackColor = true;
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
            // 
            // tbxAddrPort
            // 
            this.tbxAddrPort.Location = new System.Drawing.Point(99, 115);
            this.tbxAddrPort.Name = "tbxAddrPort";
            this.tbxAddrPort.Size = new System.Drawing.Size(43, 21);
            this.tbxAddrPort.TabIndex = 7;
            this.tbxAddrPort.TextChanged += new System.EventHandler(this.tbxAddrPort_TextChanged);
            this.tbxAddrPort.Validating += new System.ComponentModel.CancelEventHandler(this.tbxAddrPort_Validating);
            // 
            // lblAddrPort
            // 
            this.lblAddrPort.AutoSize = true;
            this.lblAddrPort.Location = new System.Drawing.Point(21, 115);
            this.lblAddrPort.Name = "lblAddrPort";
            this.lblAddrPort.Size = new System.Drawing.Size(71, 12);
            this.lblAddrPort.TabIndex = 6;
            this.lblAddrPort.Text = "lblAddrPort";
            // 
            // cmbDBList
            // 
            this.cmbDBList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDBList.FormattingEnabled = true;
            this.cmbDBList.Location = new System.Drawing.Point(21, 88);
            this.cmbDBList.Name = "cmbDBList";
            this.cmbDBList.Size = new System.Drawing.Size(121, 20);
            this.cmbDBList.TabIndex = 5;
            this.cmbDBList.SelectedIndexChanged += new System.EventHandler(this.cmbDBList_SelectedIndexChanged);
            // 
            // lblDBList
            // 
            this.lblDBList.AutoSize = true;
            this.lblDBList.Location = new System.Drawing.Point(21, 72);
            this.lblDBList.Name = "lblDBList";
            this.lblDBList.Size = new System.Drawing.Size(59, 12);
            this.lblDBList.TabIndex = 4;
            this.lblDBList.Text = "lblDBList";
            // 
            // pbxLoad
            // 
            this.pbxLoad.ErrorImage = null;
            this.pbxLoad.Image = global::StoreManagement.Properties.Resources.throbber;
            this.pbxLoad.InitialImage = null;
            this.pbxLoad.Location = new System.Drawing.Point(21, 141);
            this.pbxLoad.Name = "pbxLoad";
            this.pbxLoad.Size = new System.Drawing.Size(25, 25);
            this.pbxLoad.TabIndex = 3;
            this.pbxLoad.TabStop = false;
            // 
            // cmbAddrList
            // 
            this.cmbAddrList.FormattingEnabled = true;
            this.cmbAddrList.Location = new System.Drawing.Point(21, 46);
            this.cmbAddrList.Name = "cmbAddrList";
            this.cmbAddrList.Size = new System.Drawing.Size(121, 20);
            this.cmbAddrList.TabIndex = 2;
            this.cmbAddrList.Leave += new System.EventHandler(this.cmbAddrList_Leave);
            // 
            // lblAddrList
            // 
            this.lblAddrList.AutoSize = true;
            this.lblAddrList.Location = new System.Drawing.Point(21, 31);
            this.lblAddrList.Name = "lblAddrList";
            this.lblAddrList.Size = new System.Drawing.Size(71, 12);
            this.lblAddrList.TabIndex = 1;
            this.lblAddrList.Text = "lblAddrList";
            // 
            // lblAddrDesc
            // 
            this.lblAddrDesc.AutoSize = true;
            this.lblAddrDesc.Location = new System.Drawing.Point(19, 15);
            this.lblAddrDesc.Name = "lblAddrDesc";
            this.lblAddrDesc.Size = new System.Drawing.Size(71, 12);
            this.lblAddrDesc.TabIndex = 0;
            this.lblAddrDesc.Text = "lblAddrDesc";
            // 
            // pnlDB
            // 
            this.pnlDB.Controls.Add(this.btnInvAB);
            this.pnlDB.Controls.Add(this.btnAllAB);
            this.pnlDB.Controls.Add(this.btnDelAB);
            this.pnlDB.Controls.Add(this.btnAddAB);
            this.pnlDB.Controls.Add(this.dgvABList);
            this.pnlDB.Controls.Add(this.lblABDesc);
            this.pnlDB.Location = new System.Drawing.Point(184, 11);
            this.pnlDB.Name = "pnlDB";
            this.pnlDB.Size = new System.Drawing.Size(206, 123);
            this.pnlDB.TabIndex = 1;
            // 
            // btnInvAB
            // 
            this.btnInvAB.Location = new System.Drawing.Point(152, 99);
            this.btnInvAB.Name = "btnInvAB";
            this.btnInvAB.Size = new System.Drawing.Size(51, 23);
            this.btnInvAB.TabIndex = 5;
            this.btnInvAB.Text = "btnInvAB";
            this.btnInvAB.UseVisualStyleBackColor = true;
            // 
            // btnAllAB
            // 
            this.btnAllAB.Location = new System.Drawing.Point(152, 72);
            this.btnAllAB.Name = "btnAllAB";
            this.btnAllAB.Size = new System.Drawing.Size(51, 23);
            this.btnAllAB.TabIndex = 4;
            this.btnAllAB.Text = "btnAllAB";
            this.btnAllAB.UseVisualStyleBackColor = true;
            // 
            // btnDelAB
            // 
            this.btnDelAB.Location = new System.Drawing.Point(152, 46);
            this.btnDelAB.Name = "btnDelAB";
            this.btnDelAB.Size = new System.Drawing.Size(51, 23);
            this.btnDelAB.TabIndex = 3;
            this.btnDelAB.Text = "btnDelAB";
            this.btnDelAB.UseVisualStyleBackColor = true;
            this.btnDelAB.Click += new System.EventHandler(this.btnDelAB_Click);
            // 
            // btnAddAB
            // 
            this.btnAddAB.Location = new System.Drawing.Point(152, 19);
            this.btnAddAB.Name = "btnAddAB";
            this.btnAddAB.Size = new System.Drawing.Size(51, 23);
            this.btnAddAB.TabIndex = 2;
            this.btnAddAB.Text = "btnAddAB";
            this.btnAddAB.UseVisualStyleBackColor = true;
            this.btnAddAB.Click += new System.EventHandler(this.btnAddAB_Click);
            // 
            // dgvABList
            // 
            this.dgvABList.AllowUserToAddRows = false;
            this.dgvABList.AllowUserToDeleteRows = false;
            this.dgvABList.AllowUserToResizeColumns = false;
            this.dgvABList.AllowUserToResizeRows = false;
            this.dgvABList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvABList.Location = new System.Drawing.Point(3, 15);
            this.dgvABList.MultiSelect = false;
            this.dgvABList.Name = "dgvABList";
            this.dgvABList.ReadOnly = true;
            this.dgvABList.RowHeadersVisible = false;
            this.dgvABList.RowTemplate.Height = 23;
            this.dgvABList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvABList.Size = new System.Drawing.Size(142, 77);
            this.dgvABList.TabIndex = 1;
            this.dgvABList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvABList_CellContentClick);
            // 
            // lblABDesc
            // 
            this.lblABDesc.Location = new System.Drawing.Point(21, 4);
            this.lblABDesc.Name = "lblABDesc";
            this.lblABDesc.Size = new System.Drawing.Size(78, 23);
            this.lblABDesc.TabIndex = 0;
            this.lblABDesc.Text = "lblABDesc";
            // 
            // pnlControl
            // 
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Controls.Add(this.btnFin);
            this.pnlControl.Controls.Add(this.btnCancel);
            this.pnlControl.Controls.Add(this.btnPrev);
            this.pnlControl.Controls.Add(this.btnNext);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 260);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(420, 35);
            this.pnlControl.TabIndex = 2;
            // 
            // btnFin
            // 
            this.btnFin.Location = new System.Drawing.Point(12, 8);
            this.btnFin.Name = "btnFin";
            this.btnFin.Size = new System.Drawing.Size(75, 23);
            this.btnFin.TabIndex = 3;
            this.btnFin.Text = "完成";
            this.btnFin.UseVisualStyleBackColor = true;
            this.btnFin.Click += new System.EventHandler(this.btnFin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(298, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(103, 8);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "上一步";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(208, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "下一步";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.pnlAuth);
            this.pnlMain.Controls.Add(this.pnlAddr);
            this.pnlMain.Controls.Add(this.pnlDB);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(420, 260);
            this.pnlMain.TabIndex = 3;
            // 
            // pnlAuth
            // 
            this.pnlAuth.Controls.Add(this.tbxAuthPwd);
            this.pnlAuth.Controls.Add(this.lblAuthPwd);
            this.pnlAuth.Controls.Add(this.cmbAuthUser);
            this.pnlAuth.Controls.Add(this.lblAuthUser);
            this.pnlAuth.Controls.Add(this.dtpLogDate);
            this.pnlAuth.Controls.Add(this.lblLogDateDesc);
            this.pnlAuth.Location = new System.Drawing.Point(187, 170);
            this.pnlAuth.Name = "pnlAuth";
            this.pnlAuth.Size = new System.Drawing.Size(167, 84);
            this.pnlAuth.TabIndex = 2;
            // 
            // tbxAuthPwd
            // 
            this.tbxAuthPwd.Location = new System.Drawing.Point(21, 99);
            this.tbxAuthPwd.Name = "tbxAuthPwd";
            this.tbxAuthPwd.Size = new System.Drawing.Size(100, 21);
            this.tbxAuthPwd.TabIndex = 5;
            this.tbxAuthPwd.UseSystemPasswordChar = true;
            // 
            // lblAuthPwd
            // 
            this.lblAuthPwd.AutoSize = true;
            this.lblAuthPwd.Location = new System.Drawing.Point(23, 82);
            this.lblAuthPwd.Name = "lblAuthPwd";
            this.lblAuthPwd.Size = new System.Drawing.Size(65, 12);
            this.lblAuthPwd.TabIndex = 4;
            this.lblAuthPwd.Text = "lblAuthPwd";
            // 
            // cmbAuthUser
            // 
            this.cmbAuthUser.FormattingEnabled = true;
            this.cmbAuthUser.Location = new System.Drawing.Point(23, 55);
            this.cmbAuthUser.Name = "cmbAuthUser";
            this.cmbAuthUser.Size = new System.Drawing.Size(121, 20);
            this.cmbAuthUser.TabIndex = 3;
            // 
            // lblAuthUser
            // 
            this.lblAuthUser.AutoSize = true;
            this.lblAuthUser.Location = new System.Drawing.Point(23, 43);
            this.lblAuthUser.Name = "lblAuthUser";
            this.lblAuthUser.Size = new System.Drawing.Size(71, 12);
            this.lblAuthUser.TabIndex = 2;
            this.lblAuthUser.Text = "lblAuthUser";
            // 
            // dtpLogDate
            // 
            this.dtpLogDate.Location = new System.Drawing.Point(21, 15);
            this.dtpLogDate.Name = "dtpLogDate";
            this.dtpLogDate.Size = new System.Drawing.Size(121, 21);
            this.dtpLogDate.TabIndex = 1;
            // 
            // lblLogDateDesc
            // 
            this.lblLogDateDesc.AutoSize = true;
            this.lblLogDateDesc.Location = new System.Drawing.Point(19, 6);
            this.lblLogDateDesc.Name = "lblLogDateDesc";
            this.lblLogDateDesc.Size = new System.Drawing.Size(89, 12);
            this.lblLogDateDesc.TabIndex = 0;
            this.lblLogDateDesc.Text = "lblLogDateDesc";
            // 
            // LoginGuideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 295);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginGuideForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "登录向导";
            this.Load += new System.EventHandler(this.LoginGuide_Load);
            this.pnlAddr.ResumeLayout(false);
            this.pnlAddr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).EndInit();
            this.pnlDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvABList)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlAuth.ResumeLayout(false);
            this.pnlAuth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAddr;
        private System.Windows.Forms.Label lblAddrDesc;
        private System.Windows.Forms.Panel pnlDB;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblABDesc;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblAddrList;
        private System.Windows.Forms.ComboBox cmbAddrList;
        private System.Windows.Forms.PictureBox pbxLoad;
        private System.Windows.Forms.Button btnTestConnect;
        private System.Windows.Forms.TextBox tbxAddrPort;
        private System.Windows.Forms.Label lblAddrPort;
        private System.Windows.Forms.ComboBox cmbDBList;
        private System.Windows.Forms.Label lblDBList;
        private System.Windows.Forms.Label lblTestConnetc;
        private System.Windows.Forms.TextBox tbxDBPwd;
        private System.Windows.Forms.Label lblDBPwd;
        private System.Windows.Forms.TextBox tbxDBUser;
        private System.Windows.Forms.Label lblDBUser;
        private System.Windows.Forms.Button btnFin;
        private System.Windows.Forms.DataGridView dgvABList;
        private System.Windows.Forms.Button btnAddAB;
        private System.Windows.Forms.Button btnDelAB;
        private System.Windows.Forms.Button btnAllAB;
        private System.Windows.Forms.Button btnInvAB;
        private System.Windows.Forms.Panel pnlAuth;
        private System.Windows.Forms.TextBox tbxAuthPwd;
        private System.Windows.Forms.Label lblAuthPwd;
        private System.Windows.Forms.ComboBox cmbAuthUser;
        private System.Windows.Forms.Label lblAuthUser;
        private System.Windows.Forms.DateTimePicker dtpLogDate;
        private System.Windows.Forms.Label lblLogDateDesc;
    }
}