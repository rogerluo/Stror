namespace StoreManagement.Forms
{
    partial class GoodsInfoForm
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.tclMain = new System.Windows.Forms.TabControl();
            this.tpgBasic = new System.Windows.Forms.TabPage();
            this.gpbPicture = new System.Windows.Forms.GroupBox();
            this.pnlPicBottom = new System.Windows.Forms.Panel();
            this.btnPicNext = new System.Windows.Forms.Button();
            this.btnPicPrev = new System.Windows.Forms.Button();
            this.btnPicRemove = new System.Windows.Forms.Button();
            this.btnPicImport = new System.Windows.Forms.Button();
            this.pbxPicture = new System.Windows.Forms.PictureBox();
            this.gpbBasciInfo = new System.Windows.Forms.GroupBox();
            this.tbxGoodsPrice3 = new System.Windows.Forms.TextBox();
            this.lblGoodsPrice3 = new System.Windows.Forms.Label();
            this.tbxGoodsPrice2 = new System.Windows.Forms.TextBox();
            this.lblGoodsPrice2 = new System.Windows.Forms.Label();
            this.tbxGoodsPrice1 = new System.Windows.Forms.TextBox();
            this.lblGoodsPrice1 = new System.Windows.Forms.Label();
            this.cmbStuff = new System.Windows.Forms.ComboBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.cmbSeason = new System.Windows.Forms.ComboBox();
            this.dptExpired = new System.Windows.Forms.DateTimePicker();
            this.tbxBarCode = new System.Windows.Forms.TextBox();
            this.cmbBarCodeFormat = new System.Windows.Forms.ComboBox();
            this.tbxGoodsUnit = new System.Windows.Forms.TextBox();
            this.tbxGoodsAbbrName = new System.Windows.Forms.TextBox();
            this.tbxGoodsFullName = new System.Windows.Forms.TextBox();
            this.tbxGoodsId = new System.Windows.Forms.TextBox();
            this.lblStuff = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblSeason = new System.Windows.Forms.Label();
            this.lblExpired = new System.Windows.Forms.Label();
            this.lblBarCode = new System.Windows.Forms.Label();
            this.lblBarCodeFormat = new System.Windows.Forms.Label();
            this.lblGoodsUnit = new System.Windows.Forms.Label();
            this.lblGoodsAbbrName = new System.Windows.Forms.Label();
            this.lblGoodsFullName = new System.Windows.Forms.Label();
            this.lblGoodsId = new System.Windows.Forms.Label();
            this.tabPicture = new System.Windows.Forms.TabPage();
            this.pnlPictureMain = new System.Windows.Forms.Panel();
            this.dgvPicture = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thumbnail = new System.Windows.Forms.DataGridViewImageColumn();
            this.Color = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tpgColor = new System.Windows.Forms.TabPage();
            this.btnColorAllDel = new System.Windows.Forms.Button();
            this.btnColorAllAdd = new System.Windows.Forms.Button();
            this.btnColorDel = new System.Windows.Forms.Button();
            this.btnColorAdd = new System.Windows.Forms.Button();
            this.gpbOptionColor = new System.Windows.Forms.GroupBox();
            this.dgvOptionColor = new System.Windows.Forms.DataGridView();
            this.gpbSelectedColor = new System.Windows.Forms.GroupBox();
            this.dgvSelectedColor = new System.Windows.Forms.DataGridView();
            this.btnAddNewColor = new System.Windows.Forms.Button();
            this.tpgSzie = new System.Windows.Forms.TabPage();
            this.gpbOptionSize = new System.Windows.Forms.GroupBox();
            this.btnSizeAllDel = new System.Windows.Forms.Button();
            this.btnSizeAllAdd = new System.Windows.Forms.Button();
            this.btnSizeDel = new System.Windows.Forms.Button();
            this.btnSizeAdd = new System.Windows.Forms.Button();
            this.gpbSizeSelected = new System.Windows.Forms.GroupBox();
            this.btnAddNewSize = new System.Windows.Forms.Button();
            this.lbxSelectedSize = new System.Windows.Forms.ListBox();
            this.lbxOtherSize = new System.Windows.Forms.ListBox();
            this.pnlMain.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.tclMain.SuspendLayout();
            this.tpgBasic.SuspendLayout();
            this.gpbPicture.SuspendLayout();
            this.pnlPicBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPicture)).BeginInit();
            this.gpbBasciInfo.SuspendLayout();
            this.tabPicture.SuspendLayout();
            this.pnlPictureMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPicture)).BeginInit();
            this.tpgColor.SuspendLayout();
            this.gpbOptionColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOptionColor)).BeginInit();
            this.gpbSelectedColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedColor)).BeginInit();
            this.tpgSzie.SuspendLayout();
            this.gpbOptionSize.SuspendLayout();
            this.gpbSizeSelected.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Controls.Add(this.tclMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(646, 348);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnNext);
            this.pnlBottom.Controls.Add(this.btnPrev);
            this.pnlBottom.Location = new System.Drawing.Point(12, 309);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(355, 75);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(262, 26);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(180, 26);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(98, 26);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(16, 27);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "上一页";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // tclMain
            // 
            this.tclMain.Controls.Add(this.tpgBasic);
            this.tclMain.Controls.Add(this.tabPicture);
            this.tclMain.Controls.Add(this.tpgColor);
            this.tclMain.Controls.Add(this.tpgSzie);
            this.tclMain.Location = new System.Drawing.Point(12, 12);
            this.tclMain.Name = "tclMain";
            this.tclMain.SelectedIndex = 0;
            this.tclMain.Size = new System.Drawing.Size(622, 303);
            this.tclMain.TabIndex = 0;
            this.tclMain.SelectedIndexChanged += new System.EventHandler(this.tclMain_SelectedIndexChanged);
            // 
            // tpgBasic
            // 
            this.tpgBasic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpgBasic.Controls.Add(this.gpbPicture);
            this.tpgBasic.Controls.Add(this.gpbBasciInfo);
            this.tpgBasic.Location = new System.Drawing.Point(4, 22);
            this.tpgBasic.Name = "tpgBasic";
            this.tpgBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tpgBasic.Size = new System.Drawing.Size(614, 277);
            this.tpgBasic.TabIndex = 0;
            this.tpgBasic.Text = "基本信息";
            this.tpgBasic.UseVisualStyleBackColor = true;
            // 
            // gpbPicture
            // 
            this.gpbPicture.Controls.Add(this.pnlPicBottom);
            this.gpbPicture.Controls.Add(this.pbxPicture);
            this.gpbPicture.Location = new System.Drawing.Point(361, 16);
            this.gpbPicture.Name = "gpbPicture";
            this.gpbPicture.Size = new System.Drawing.Size(231, 253);
            this.gpbPicture.TabIndex = 0;
            this.gpbPicture.TabStop = false;
            this.gpbPicture.Text = "图片";
            // 
            // pnlPicBottom
            // 
            this.pnlPicBottom.Controls.Add(this.btnPicNext);
            this.pnlPicBottom.Controls.Add(this.btnPicPrev);
            this.pnlPicBottom.Controls.Add(this.btnPicRemove);
            this.pnlPicBottom.Controls.Add(this.btnPicImport);
            this.pnlPicBottom.Location = new System.Drawing.Point(22, 175);
            this.pnlPicBottom.Name = "pnlPicBottom";
            this.pnlPicBottom.Size = new System.Drawing.Size(181, 66);
            this.pnlPicBottom.TabIndex = 0;
            // 
            // btnPicNext
            // 
            this.btnPicNext.Location = new System.Drawing.Point(31, 39);
            this.btnPicNext.Name = "btnPicNext";
            this.btnPicNext.Size = new System.Drawing.Size(75, 23);
            this.btnPicNext.TabIndex = 3;
            this.btnPicNext.UseVisualStyleBackColor = true;
            // 
            // btnPicPrev
            // 
            this.btnPicPrev.Location = new System.Drawing.Point(14, 9);
            this.btnPicPrev.Name = "btnPicPrev";
            this.btnPicPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPicPrev.TabIndex = 2;
            this.btnPicPrev.UseVisualStyleBackColor = true;
            // 
            // btnPicRemove
            // 
            this.btnPicRemove.Location = new System.Drawing.Point(122, 9);
            this.btnPicRemove.Name = "btnPicRemove";
            this.btnPicRemove.Size = new System.Drawing.Size(50, 23);
            this.btnPicRemove.TabIndex = 1;
            this.btnPicRemove.UseVisualStyleBackColor = true;
            // 
            // btnPicImport
            // 
            this.btnPicImport.Location = new System.Drawing.Point(66, 5);
            this.btnPicImport.Name = "btnPicImport";
            this.btnPicImport.Size = new System.Drawing.Size(50, 23);
            this.btnPicImport.TabIndex = 0;
            this.btnPicImport.UseVisualStyleBackColor = true;
            // 
            // pbxPicture
            // 
            this.pbxPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxPicture.Location = new System.Drawing.Point(22, 16);
            this.pbxPicture.Name = "pbxPicture";
            this.pbxPicture.Size = new System.Drawing.Size(100, 50);
            this.pbxPicture.TabIndex = 1;
            this.pbxPicture.TabStop = false;
            // 
            // gpbBasciInfo
            // 
            this.gpbBasciInfo.Controls.Add(this.tbxGoodsPrice3);
            this.gpbBasciInfo.Controls.Add(this.lblGoodsPrice3);
            this.gpbBasciInfo.Controls.Add(this.tbxGoodsPrice2);
            this.gpbBasciInfo.Controls.Add(this.lblGoodsPrice2);
            this.gpbBasciInfo.Controls.Add(this.tbxGoodsPrice1);
            this.gpbBasciInfo.Controls.Add(this.lblGoodsPrice1);
            this.gpbBasciInfo.Controls.Add(this.cmbStuff);
            this.gpbBasciInfo.Controls.Add(this.cmbBrand);
            this.gpbBasciInfo.Controls.Add(this.cmbSeason);
            this.gpbBasciInfo.Controls.Add(this.dptExpired);
            this.gpbBasciInfo.Controls.Add(this.tbxBarCode);
            this.gpbBasciInfo.Controls.Add(this.cmbBarCodeFormat);
            this.gpbBasciInfo.Controls.Add(this.tbxGoodsUnit);
            this.gpbBasciInfo.Controls.Add(this.tbxGoodsAbbrName);
            this.gpbBasciInfo.Controls.Add(this.tbxGoodsFullName);
            this.gpbBasciInfo.Controls.Add(this.tbxGoodsId);
            this.gpbBasciInfo.Controls.Add(this.lblStuff);
            this.gpbBasciInfo.Controls.Add(this.lblBrand);
            this.gpbBasciInfo.Controls.Add(this.lblSeason);
            this.gpbBasciInfo.Controls.Add(this.lblExpired);
            this.gpbBasciInfo.Controls.Add(this.lblBarCode);
            this.gpbBasciInfo.Controls.Add(this.lblBarCodeFormat);
            this.gpbBasciInfo.Controls.Add(this.lblGoodsUnit);
            this.gpbBasciInfo.Controls.Add(this.lblGoodsAbbrName);
            this.gpbBasciInfo.Controls.Add(this.lblGoodsFullName);
            this.gpbBasciInfo.Controls.Add(this.lblGoodsId);
            this.gpbBasciInfo.Location = new System.Drawing.Point(24, 16);
            this.gpbBasciInfo.Name = "gpbBasciInfo";
            this.gpbBasciInfo.Size = new System.Drawing.Size(326, 238);
            this.gpbBasciInfo.TabIndex = 0;
            this.gpbBasciInfo.TabStop = false;
            this.gpbBasciInfo.Text = "主要信息";
            // 
            // tbxGoodsPrice3
            // 
            this.tbxGoodsPrice3.Location = new System.Drawing.Point(196, 81);
            this.tbxGoodsPrice3.Name = "tbxGoodsPrice3";
            this.tbxGoodsPrice3.Size = new System.Drawing.Size(100, 21);
            this.tbxGoodsPrice3.TabIndex = 25;
            // 
            // lblGoodsPrice3
            // 
            this.lblGoodsPrice3.AutoSize = true;
            this.lblGoodsPrice3.Location = new System.Drawing.Point(194, 69);
            this.lblGoodsPrice3.Name = "lblGoodsPrice3";
            this.lblGoodsPrice3.Size = new System.Drawing.Size(41, 12);
            this.lblGoodsPrice3.TabIndex = 24;
            this.lblGoodsPrice3.Text = "label1";
            // 
            // tbxGoodsPrice2
            // 
            this.tbxGoodsPrice2.Location = new System.Drawing.Point(196, 45);
            this.tbxGoodsPrice2.Name = "tbxGoodsPrice2";
            this.tbxGoodsPrice2.Size = new System.Drawing.Size(100, 21);
            this.tbxGoodsPrice2.TabIndex = 23;
            // 
            // lblGoodsPrice2
            // 
            this.lblGoodsPrice2.AutoSize = true;
            this.lblGoodsPrice2.Location = new System.Drawing.Point(194, 26);
            this.lblGoodsPrice2.Name = "lblGoodsPrice2";
            this.lblGoodsPrice2.Size = new System.Drawing.Size(41, 12);
            this.lblGoodsPrice2.TabIndex = 22;
            this.lblGoodsPrice2.Text = "label1";
            // 
            // tbxGoodsPrice1
            // 
            this.tbxGoodsPrice1.Location = new System.Drawing.Point(196, 181);
            this.tbxGoodsPrice1.Name = "tbxGoodsPrice1";
            this.tbxGoodsPrice1.Size = new System.Drawing.Size(100, 21);
            this.tbxGoodsPrice1.TabIndex = 21;
            // 
            // lblGoodsPrice1
            // 
            this.lblGoodsPrice1.AutoSize = true;
            this.lblGoodsPrice1.Location = new System.Drawing.Point(23, 207);
            this.lblGoodsPrice1.Name = "lblGoodsPrice1";
            this.lblGoodsPrice1.Size = new System.Drawing.Size(41, 12);
            this.lblGoodsPrice1.TabIndex = 20;
            this.lblGoodsPrice1.Text = "label1";
            // 
            // cmbStuff
            // 
            this.cmbStuff.FormattingEnabled = true;
            this.cmbStuff.Location = new System.Drawing.Point(68, 207);
            this.cmbStuff.Name = "cmbStuff";
            this.cmbStuff.Size = new System.Drawing.Size(121, 20);
            this.cmbStuff.TabIndex = 19;
            // 
            // cmbBrand
            // 
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(68, 180);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(121, 20);
            this.cmbBrand.TabIndex = 18;
            // 
            // cmbSeason
            // 
            this.cmbSeason.FormattingEnabled = true;
            this.cmbSeason.Location = new System.Drawing.Point(70, 160);
            this.cmbSeason.Name = "cmbSeason";
            this.cmbSeason.Size = new System.Drawing.Size(121, 20);
            this.cmbSeason.TabIndex = 17;
            // 
            // dptExpired
            // 
            this.dptExpired.Location = new System.Drawing.Point(68, 141);
            this.dptExpired.Name = "dptExpired";
            this.dptExpired.Size = new System.Drawing.Size(200, 21);
            this.dptExpired.TabIndex = 16;
            // 
            // tbxBarCode
            // 
            this.tbxBarCode.Location = new System.Drawing.Point(68, 123);
            this.tbxBarCode.Name = "tbxBarCode";
            this.tbxBarCode.Size = new System.Drawing.Size(100, 21);
            this.tbxBarCode.TabIndex = 15;
            // 
            // cmbBarCodeFormat
            // 
            this.cmbBarCodeFormat.FormattingEnabled = true;
            this.cmbBarCodeFormat.Location = new System.Drawing.Point(68, 96);
            this.cmbBarCodeFormat.Name = "cmbBarCodeFormat";
            this.cmbBarCodeFormat.Size = new System.Drawing.Size(121, 20);
            this.cmbBarCodeFormat.TabIndex = 14;
            this.cmbBarCodeFormat.SelectedIndexChanged += new System.EventHandler(this.cmbBarCodeFormat_SelectedIndexChanged);
            // 
            // tbxGoodsUnit
            // 
            this.tbxGoodsUnit.Location = new System.Drawing.Point(68, 72);
            this.tbxGoodsUnit.MaxLength = 2;
            this.tbxGoodsUnit.Name = "tbxGoodsUnit";
            this.tbxGoodsUnit.Size = new System.Drawing.Size(100, 21);
            this.tbxGoodsUnit.TabIndex = 13;
            // 
            // tbxGoodsAbbrName
            // 
            this.tbxGoodsAbbrName.Location = new System.Drawing.Point(68, 51);
            this.tbxGoodsAbbrName.MaxLength = 10;
            this.tbxGoodsAbbrName.Name = "tbxGoodsAbbrName";
            this.tbxGoodsAbbrName.Size = new System.Drawing.Size(100, 21);
            this.tbxGoodsAbbrName.TabIndex = 12;
            // 
            // tbxGoodsFullName
            // 
            this.tbxGoodsFullName.Location = new System.Drawing.Point(68, 26);
            this.tbxGoodsFullName.MaxLength = 25;
            this.tbxGoodsFullName.Name = "tbxGoodsFullName";
            this.tbxGoodsFullName.Size = new System.Drawing.Size(100, 21);
            this.tbxGoodsFullName.TabIndex = 11;
            // 
            // tbxGoodsId
            // 
            this.tbxGoodsId.Location = new System.Drawing.Point(68, 8);
            this.tbxGoodsId.Name = "tbxGoodsId";
            this.tbxGoodsId.Size = new System.Drawing.Size(100, 21);
            this.tbxGoodsId.TabIndex = 10;
            this.tbxGoodsId.Validating += new System.ComponentModel.CancelEventHandler(this.tbxGoodsId_Validating);
            // 
            // lblStuff
            // 
            this.lblStuff.AutoSize = true;
            this.lblStuff.Location = new System.Drawing.Point(21, 175);
            this.lblStuff.Name = "lblStuff";
            this.lblStuff.Size = new System.Drawing.Size(41, 12);
            this.lblStuff.TabIndex = 9;
            this.lblStuff.Text = "label1";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(21, 163);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(41, 12);
            this.lblBrand.TabIndex = 8;
            this.lblBrand.Text = "label1";
            // 
            // lblSeason
            // 
            this.lblSeason.AutoSize = true;
            this.lblSeason.Location = new System.Drawing.Point(23, 151);
            this.lblSeason.Name = "lblSeason";
            this.lblSeason.Size = new System.Drawing.Size(41, 12);
            this.lblSeason.TabIndex = 7;
            this.lblSeason.Text = "label1";
            // 
            // lblExpired
            // 
            this.lblExpired.AutoSize = true;
            this.lblExpired.Location = new System.Drawing.Point(21, 139);
            this.lblExpired.Name = "lblExpired";
            this.lblExpired.Size = new System.Drawing.Size(41, 12);
            this.lblExpired.TabIndex = 6;
            this.lblExpired.Text = "label1";
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.Location = new System.Drawing.Point(21, 127);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(41, 12);
            this.lblBarCode.TabIndex = 5;
            this.lblBarCode.Text = "label1";
            // 
            // lblBarCodeFormat
            // 
            this.lblBarCodeFormat.AutoSize = true;
            this.lblBarCodeFormat.Location = new System.Drawing.Point(21, 105);
            this.lblBarCodeFormat.Name = "lblBarCodeFormat";
            this.lblBarCodeFormat.Size = new System.Drawing.Size(41, 12);
            this.lblBarCodeFormat.TabIndex = 4;
            this.lblBarCodeFormat.Text = "label1";
            // 
            // lblGoodsUnit
            // 
            this.lblGoodsUnit.AutoSize = true;
            this.lblGoodsUnit.Location = new System.Drawing.Point(21, 81);
            this.lblGoodsUnit.Name = "lblGoodsUnit";
            this.lblGoodsUnit.Size = new System.Drawing.Size(41, 12);
            this.lblGoodsUnit.TabIndex = 3;
            this.lblGoodsUnit.Text = "label1";
            // 
            // lblGoodsAbbrName
            // 
            this.lblGoodsAbbrName.AutoSize = true;
            this.lblGoodsAbbrName.Location = new System.Drawing.Point(21, 54);
            this.lblGoodsAbbrName.Name = "lblGoodsAbbrName";
            this.lblGoodsAbbrName.Size = new System.Drawing.Size(41, 12);
            this.lblGoodsAbbrName.TabIndex = 2;
            this.lblGoodsAbbrName.Text = "label1";
            // 
            // lblGoodsFullName
            // 
            this.lblGoodsFullName.AutoSize = true;
            this.lblGoodsFullName.Location = new System.Drawing.Point(21, 29);
            this.lblGoodsFullName.Name = "lblGoodsFullName";
            this.lblGoodsFullName.Size = new System.Drawing.Size(41, 12);
            this.lblGoodsFullName.TabIndex = 1;
            this.lblGoodsFullName.Text = "label1";
            // 
            // lblGoodsId
            // 
            this.lblGoodsId.AutoSize = true;
            this.lblGoodsId.Location = new System.Drawing.Point(21, 17);
            this.lblGoodsId.Name = "lblGoodsId";
            this.lblGoodsId.Size = new System.Drawing.Size(41, 12);
            this.lblGoodsId.TabIndex = 0;
            this.lblGoodsId.Text = "label1";
            // 
            // tabPicture
            // 
            this.tabPicture.Controls.Add(this.pnlPictureMain);
            this.tabPicture.Location = new System.Drawing.Point(4, 22);
            this.tabPicture.Name = "tabPicture";
            this.tabPicture.Size = new System.Drawing.Size(614, 277);
            this.tabPicture.TabIndex = 4;
            this.tabPicture.Text = "图片管理";
            this.tabPicture.UseVisualStyleBackColor = true;
            // 
            // pnlPictureMain
            // 
            this.pnlPictureMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPictureMain.Controls.Add(this.dgvPicture);
            this.pnlPictureMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPictureMain.Location = new System.Drawing.Point(0, 0);
            this.pnlPictureMain.Name = "pnlPictureMain";
            this.pnlPictureMain.Size = new System.Drawing.Size(614, 277);
            this.pnlPictureMain.TabIndex = 0;
            // 
            // dgvPicture
            // 
            this.dgvPicture.AllowUserToResizeRows = false;
            this.dgvPicture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPicture.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Thumbnail,
            this.Color});
            this.dgvPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPicture.Location = new System.Drawing.Point(0, 0);
            this.dgvPicture.Name = "dgvPicture";
            this.dgvPicture.RowHeadersVisible = false;
            this.dgvPicture.RowTemplate.Height = 23;
            this.dgvPicture.Size = new System.Drawing.Size(612, 275);
            this.dgvPicture.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "编号";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Thumbnail
            // 
            this.Thumbnail.HeaderText = "缩略图";
            this.Thumbnail.Name = "Thumbnail";
            // 
            // Color
            // 
            this.Color.HeaderText = "颜色";
            this.Color.Name = "Color";
            // 
            // tpgColor
            // 
            this.tpgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpgColor.Controls.Add(this.btnColorAllDel);
            this.tpgColor.Controls.Add(this.btnColorAllAdd);
            this.tpgColor.Controls.Add(this.btnColorDel);
            this.tpgColor.Controls.Add(this.btnColorAdd);
            this.tpgColor.Controls.Add(this.gpbOptionColor);
            this.tpgColor.Controls.Add(this.gpbSelectedColor);
            this.tpgColor.Controls.Add(this.btnAddNewColor);
            this.tpgColor.Location = new System.Drawing.Point(4, 22);
            this.tpgColor.Name = "tpgColor";
            this.tpgColor.Size = new System.Drawing.Size(614, 277);
            this.tpgColor.TabIndex = 2;
            this.tpgColor.Text = "颜色设置";
            this.tpgColor.UseVisualStyleBackColor = true;
            // 
            // btnColorAllDel
            // 
            this.btnColorAllDel.Location = new System.Drawing.Point(377, 177);
            this.btnColorAllDel.Name = "btnColorAllDel";
            this.btnColorAllDel.Size = new System.Drawing.Size(75, 23);
            this.btnColorAllDel.TabIndex = 8;
            this.btnColorAllDel.Text = ">>";
            this.btnColorAllDel.UseVisualStyleBackColor = true;
            // 
            // btnColorAllAdd
            // 
            this.btnColorAllAdd.Location = new System.Drawing.Point(377, 148);
            this.btnColorAllAdd.Name = "btnColorAllAdd";
            this.btnColorAllAdd.Size = new System.Drawing.Size(75, 23);
            this.btnColorAllAdd.TabIndex = 7;
            this.btnColorAllAdd.Text = "<<";
            this.btnColorAllAdd.UseVisualStyleBackColor = true;
            // 
            // btnColorDel
            // 
            this.btnColorDel.Location = new System.Drawing.Point(377, 119);
            this.btnColorDel.Name = "btnColorDel";
            this.btnColorDel.Size = new System.Drawing.Size(75, 23);
            this.btnColorDel.TabIndex = 6;
            this.btnColorDel.Text = "->";
            this.btnColorDel.UseVisualStyleBackColor = true;
            // 
            // btnColorAdd
            // 
            this.btnColorAdd.Location = new System.Drawing.Point(377, 90);
            this.btnColorAdd.Name = "btnColorAdd";
            this.btnColorAdd.Size = new System.Drawing.Size(75, 23);
            this.btnColorAdd.TabIndex = 5;
            this.btnColorAdd.Text = "<-";
            this.btnColorAdd.UseVisualStyleBackColor = true;
            // 
            // gpbOptionColor
            // 
            this.gpbOptionColor.Controls.Add(this.dgvOptionColor);
            this.gpbOptionColor.Location = new System.Drawing.Point(458, 36);
            this.gpbOptionColor.Name = "gpbOptionColor";
            this.gpbOptionColor.Size = new System.Drawing.Size(140, 236);
            this.gpbOptionColor.TabIndex = 4;
            this.gpbOptionColor.TabStop = false;
            this.gpbOptionColor.Text = "可选颜色";
            // 
            // dgvOptionColor
            // 
            this.dgvOptionColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOptionColor.Location = new System.Drawing.Point(8, 20);
            this.dgvOptionColor.Name = "dgvOptionColor";
            this.dgvOptionColor.RowTemplate.Height = 23;
            this.dgvOptionColor.Size = new System.Drawing.Size(120, 210);
            this.dgvOptionColor.TabIndex = 0;
            // 
            // gpbSelectedColor
            // 
            this.gpbSelectedColor.Controls.Add(this.dgvSelectedColor);
            this.gpbSelectedColor.Location = new System.Drawing.Point(3, 36);
            this.gpbSelectedColor.Name = "gpbSelectedColor";
            this.gpbSelectedColor.Size = new System.Drawing.Size(368, 232);
            this.gpbSelectedColor.TabIndex = 3;
            this.gpbSelectedColor.TabStop = false;
            this.gpbSelectedColor.Text = "已选颜色";
            // 
            // dgvSelectedColor
            // 
            this.dgvSelectedColor.AllowUserToAddRows = false;
            this.dgvSelectedColor.AllowUserToDeleteRows = false;
            this.dgvSelectedColor.AllowUserToResizeColumns = false;
            this.dgvSelectedColor.AllowUserToResizeRows = false;
            this.dgvSelectedColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedColor.Location = new System.Drawing.Point(6, 20);
            this.dgvSelectedColor.Name = "dgvSelectedColor";
            this.dgvSelectedColor.ReadOnly = true;
            this.dgvSelectedColor.RowHeadersVisible = false;
            this.dgvSelectedColor.RowTemplate.Height = 23;
            this.dgvSelectedColor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedColor.Size = new System.Drawing.Size(350, 210);
            this.dgvSelectedColor.TabIndex = 0;
            // 
            // btnAddNewColor
            // 
            this.btnAddNewColor.Location = new System.Drawing.Point(525, 7);
            this.btnAddNewColor.Name = "btnAddNewColor";
            this.btnAddNewColor.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewColor.TabIndex = 2;
            this.btnAddNewColor.Text = "添加新颜色";
            this.btnAddNewColor.UseVisualStyleBackColor = true;
            // 
            // tpgSzie
            // 
            this.tpgSzie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpgSzie.Controls.Add(this.gpbOptionSize);
            this.tpgSzie.Controls.Add(this.btnSizeAllDel);
            this.tpgSzie.Controls.Add(this.btnSizeAllAdd);
            this.tpgSzie.Controls.Add(this.btnSizeDel);
            this.tpgSzie.Controls.Add(this.btnSizeAdd);
            this.tpgSzie.Controls.Add(this.gpbSizeSelected);
            this.tpgSzie.Controls.Add(this.btnAddNewSize);
            this.tpgSzie.Location = new System.Drawing.Point(4, 22);
            this.tpgSzie.Name = "tpgSzie";
            this.tpgSzie.Size = new System.Drawing.Size(614, 277);
            this.tpgSzie.TabIndex = 3;
            this.tpgSzie.Text = "尺码设置";
            this.tpgSzie.UseVisualStyleBackColor = true;
            // 
            // gpbOptionSize
            // 
            this.gpbOptionSize.Controls.Add(this.lbxOtherSize);
            this.gpbOptionSize.Location = new System.Drawing.Point(257, 36);
            this.gpbOptionSize.Name = "gpbOptionSize";
            this.gpbOptionSize.Size = new System.Drawing.Size(135, 237);
            this.gpbOptionSize.TabIndex = 6;
            this.gpbOptionSize.TabStop = false;
            this.gpbOptionSize.Text = "可选尺寸";
            // 
            // btnSizeAllDel
            // 
            this.btnSizeAllDel.Location = new System.Drawing.Point(175, 173);
            this.btnSizeAllDel.Name = "btnSizeAllDel";
            this.btnSizeAllDel.Size = new System.Drawing.Size(75, 23);
            this.btnSizeAllDel.TabIndex = 5;
            this.btnSizeAllDel.Text = ">>";
            this.btnSizeAllDel.UseVisualStyleBackColor = true;
            this.btnSizeAllDel.Click += new System.EventHandler(this.btnSizeAllDel_Click);
            // 
            // btnSizeAllAdd
            // 
            this.btnSizeAllAdd.Location = new System.Drawing.Point(175, 144);
            this.btnSizeAllAdd.Name = "btnSizeAllAdd";
            this.btnSizeAllAdd.Size = new System.Drawing.Size(75, 23);
            this.btnSizeAllAdd.TabIndex = 4;
            this.btnSizeAllAdd.Text = "<<";
            this.btnSizeAllAdd.UseVisualStyleBackColor = true;
            this.btnSizeAllAdd.Click += new System.EventHandler(this.btnSizeAllAdd_Click);
            // 
            // btnSizeDel
            // 
            this.btnSizeDel.Location = new System.Drawing.Point(175, 115);
            this.btnSizeDel.Name = "btnSizeDel";
            this.btnSizeDel.Size = new System.Drawing.Size(75, 23);
            this.btnSizeDel.TabIndex = 3;
            this.btnSizeDel.Text = "->";
            this.btnSizeDel.UseVisualStyleBackColor = true;
            this.btnSizeDel.Click += new System.EventHandler(this.btnSizeDel_Click);
            // 
            // btnSizeAdd
            // 
            this.btnSizeAdd.Location = new System.Drawing.Point(175, 86);
            this.btnSizeAdd.Name = "btnSizeAdd";
            this.btnSizeAdd.Size = new System.Drawing.Size(75, 23);
            this.btnSizeAdd.TabIndex = 2;
            this.btnSizeAdd.Text = "<-";
            this.btnSizeAdd.UseVisualStyleBackColor = true;
            // 
            // gpbSizeSelected
            // 
            this.gpbSizeSelected.Controls.Add(this.lbxSelectedSize);
            this.gpbSizeSelected.Location = new System.Drawing.Point(3, 36);
            this.gpbSizeSelected.Name = "gpbSizeSelected";
            this.gpbSizeSelected.Size = new System.Drawing.Size(148, 237);
            this.gpbSizeSelected.TabIndex = 1;
            this.gpbSizeSelected.TabStop = false;
            this.gpbSizeSelected.Text = "已选尺寸";
            // 
            // btnAddNewSize
            // 
            this.btnAddNewSize.Location = new System.Drawing.Point(316, 4);
            this.btnAddNewSize.Name = "btnAddNewSize";
            this.btnAddNewSize.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewSize.TabIndex = 0;
            this.btnAddNewSize.Text = "添加新尺寸";
            this.btnAddNewSize.UseVisualStyleBackColor = true;
            // 
            // lbxSelectedSize
            // 
            this.lbxSelectedSize.FormattingEnabled = true;
            this.lbxSelectedSize.ItemHeight = 12;
            this.lbxSelectedSize.Location = new System.Drawing.Point(8, 20);
            this.lbxSelectedSize.Name = "lbxSelectedSize";
            this.lbxSelectedSize.Size = new System.Drawing.Size(120, 208);
            this.lbxSelectedSize.TabIndex = 0;
            // 
            // lbxOtherSize
            // 
            this.lbxOtherSize.FormattingEnabled = true;
            this.lbxOtherSize.ItemHeight = 12;
            this.lbxOtherSize.Location = new System.Drawing.Point(6, 20);
            this.lbxOtherSize.Name = "lbxOtherSize";
            this.lbxOtherSize.Size = new System.Drawing.Size(123, 208);
            this.lbxOtherSize.TabIndex = 0;
            // 
            // GoodsInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 348);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoodsInfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "商品信息";
            this.pnlMain.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.tclMain.ResumeLayout(false);
            this.tpgBasic.ResumeLayout(false);
            this.gpbPicture.ResumeLayout(false);
            this.pnlPicBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPicture)).EndInit();
            this.gpbBasciInfo.ResumeLayout(false);
            this.gpbBasciInfo.PerformLayout();
            this.tabPicture.ResumeLayout(false);
            this.pnlPictureMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPicture)).EndInit();
            this.tpgColor.ResumeLayout(false);
            this.gpbOptionColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOptionColor)).EndInit();
            this.gpbSelectedColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedColor)).EndInit();
            this.tpgSzie.ResumeLayout(false);
            this.gpbOptionSize.ResumeLayout(false);
            this.gpbSizeSelected.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.TabControl tclMain;
        private System.Windows.Forms.TabPage tpgBasic;
        private System.Windows.Forms.GroupBox gpbPicture;
        private System.Windows.Forms.Panel pnlPicBottom;
        private System.Windows.Forms.Button btnPicNext;
        private System.Windows.Forms.Button btnPicPrev;
        private System.Windows.Forms.Button btnPicRemove;
        private System.Windows.Forms.Button btnPicImport;
        private System.Windows.Forms.PictureBox pbxPicture;
        private System.Windows.Forms.GroupBox gpbBasciInfo;
        private System.Windows.Forms.ComboBox cmbStuff;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.ComboBox cmbSeason;
        private System.Windows.Forms.DateTimePicker dptExpired;
        private System.Windows.Forms.TextBox tbxBarCode;
        private System.Windows.Forms.ComboBox cmbBarCodeFormat;
        private System.Windows.Forms.TextBox tbxGoodsUnit;
        private System.Windows.Forms.TextBox tbxGoodsAbbrName;
        private System.Windows.Forms.TextBox tbxGoodsFullName;
        private System.Windows.Forms.TextBox tbxGoodsId;
        private System.Windows.Forms.Label lblStuff;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblSeason;
        private System.Windows.Forms.Label lblExpired;
        private System.Windows.Forms.Label lblBarCode;
        private System.Windows.Forms.Label lblBarCodeFormat;
        private System.Windows.Forms.Label lblGoodsUnit;
        private System.Windows.Forms.Label lblGoodsAbbrName;
        private System.Windows.Forms.Label lblGoodsFullName;
        private System.Windows.Forms.Label lblGoodsId;
        private System.Windows.Forms.TabPage tpgColor;
        private System.Windows.Forms.TabPage tpgSzie;
        private System.Windows.Forms.Button btnColorAllDel;
        private System.Windows.Forms.Button btnColorAllAdd;
        private System.Windows.Forms.Button btnColorDel;
        private System.Windows.Forms.Button btnColorAdd;
        private System.Windows.Forms.GroupBox gpbOptionColor;
        private System.Windows.Forms.DataGridView dgvOptionColor;
        private System.Windows.Forms.GroupBox gpbSelectedColor;
        private System.Windows.Forms.DataGridView dgvSelectedColor;
        private System.Windows.Forms.Button btnAddNewColor;
        private System.Windows.Forms.Button btnSizeAllDel;
        private System.Windows.Forms.Button btnSizeAllAdd;
        private System.Windows.Forms.Button btnSizeDel;
        private System.Windows.Forms.Button btnSizeAdd;
        private System.Windows.Forms.GroupBox gpbSizeSelected;
        private System.Windows.Forms.Button btnAddNewSize;
        private System.Windows.Forms.GroupBox gpbOptionSize;
        private System.Windows.Forms.TextBox tbxGoodsPrice3;
        private System.Windows.Forms.Label lblGoodsPrice3;
        private System.Windows.Forms.TextBox tbxGoodsPrice2;
        private System.Windows.Forms.Label lblGoodsPrice2;
        private System.Windows.Forms.TextBox tbxGoodsPrice1;
        private System.Windows.Forms.Label lblGoodsPrice1;
        private System.Windows.Forms.TabPage tabPicture;
        private System.Windows.Forms.Panel pnlPictureMain;
        private System.Windows.Forms.DataGridView dgvPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewImageColumn Thumbnail;
        private System.Windows.Forms.DataGridViewComboBoxColumn Color;
        private System.Windows.Forms.ListBox lbxOtherSize;
        private System.Windows.Forms.ListBox lbxSelectedSize;
    }
}