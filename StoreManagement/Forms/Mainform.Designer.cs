namespace StoreManagement
{
    partial class Mainform
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
            this.components = new System.ComponentModel.Container();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.tsmBasicInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGoodsMgr = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGoodsInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmGoodsColorGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGoodsSizeGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBrand = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSeason = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStuff = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmBarcode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTradeUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStorage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRetail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSysChangeUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSysChangeAB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSysChangePwd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSysDBBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSysDBRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSendReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSysExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tclMain = new System.Windows.Forms.TabControl();
            this.tpgNav = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gpbStore = new System.Windows.Forms.GroupBox();
            this.btnGoodsInfo = new System.Windows.Forms.Button();
            this.btnStoreDetail = new System.Windows.Forms.Button();
            this.gpbSale = new System.Windows.Forms.GroupBox();
            this.btnNewSaleOrder = new System.Windows.Forms.Button();
            this.gpbPurchase = new System.Windows.Forms.GroupBox();
            this.btnNewPurchaseOrder = new System.Windows.Forms.Button();
            this.imgListTapThumb = new System.Windows.Forms.ImageList(this.components);
            this.tsmTool = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPicCompress = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tclMain.SuspendLayout();
            this.tpgNav.SuspendLayout();
            this.gpbStore.SuspendLayout();
            this.gpbSale.SuspendLayout();
            this.gpbPurchase.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrStatus
            // 
            this.tmrStatus.Interval = 1000;
            this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
            // 
            // stsStatus
            // 
            this.stsStatus.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.stsStatus.Location = new System.Drawing.Point(0, 433);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(700, 22);
            this.stsStatus.TabIndex = 0;
            this.stsStatus.Text = "stsStatus";
            // 
            // mnsMain
            // 
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmBasicInfo,
            this.tsmSystem,
            this.tsmTool});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(700, 25);
            this.mnsMain.TabIndex = 3;
            this.mnsMain.Text = "Menu";
            // 
            // tsmBasicInfo
            // 
            this.tsmBasicInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGoodsMgr,
            this.tsmTradeUnit,
            this.tsmEmployee,
            this.tsmSection,
            this.tsmStorage,
            this.tsmRetail});
            this.tsmBasicInfo.Name = "tsmBasicInfo";
            this.tsmBasicInfo.Size = new System.Drawing.Size(68, 21);
            this.tsmBasicInfo.Text = "账本信息";
            // 
            // tsmGoodsMgr
            // 
            this.tsmGoodsMgr.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGoodsInfo,
            this.toolStripSeparator3,
            this.tsmGoodsColorGroup,
            this.tsmGoodsSizeGroup,
            this.tsmBrand,
            this.tsmSeason,
            this.tsmStuff,
            this.toolStripSeparator4,
            this.tsmBarcode});
            this.tsmGoodsMgr.Name = "tsmGoodsMgr";
            this.tsmGoodsMgr.Size = new System.Drawing.Size(152, 22);
            this.tsmGoodsMgr.Text = "商品管理";
            // 
            // tsmGoodsInfo
            // 
            this.tsmGoodsInfo.Name = "tsmGoodsInfo";
            this.tsmGoodsInfo.Size = new System.Drawing.Size(148, 22);
            this.tsmGoodsInfo.Text = "商品信息";
            this.tsmGoodsInfo.Click += new System.EventHandler(this.tsmGoodsInfo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // tsmGoodsColorGroup
            // 
            this.tsmGoodsColorGroup.Name = "tsmGoodsColorGroup";
            this.tsmGoodsColorGroup.Size = new System.Drawing.Size(148, 22);
            this.tsmGoodsColorGroup.Text = "商品颜色设置";
            // 
            // tsmGoodsSizeGroup
            // 
            this.tsmGoodsSizeGroup.Name = "tsmGoodsSizeGroup";
            this.tsmGoodsSizeGroup.Size = new System.Drawing.Size(148, 22);
            this.tsmGoodsSizeGroup.Text = "商品尺码设置";
            // 
            // tsmBrand
            // 
            this.tsmBrand.Name = "tsmBrand";
            this.tsmBrand.Size = new System.Drawing.Size(148, 22);
            this.tsmBrand.Text = "品牌";
            // 
            // tsmSeason
            // 
            this.tsmSeason.Name = "tsmSeason";
            this.tsmSeason.Size = new System.Drawing.Size(148, 22);
            this.tsmSeason.Text = "季节";
            // 
            // tsmStuff
            // 
            this.tsmStuff.Name = "tsmStuff";
            this.tsmStuff.Size = new System.Drawing.Size(148, 22);
            this.tsmStuff.Text = "材料";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // tsmBarcode
            // 
            this.tsmBarcode.Name = "tsmBarcode";
            this.tsmBarcode.Size = new System.Drawing.Size(148, 22);
            this.tsmBarcode.Text = "条形码设置";
            // 
            // tsmTradeUnit
            // 
            this.tsmTradeUnit.Name = "tsmTradeUnit";
            this.tsmTradeUnit.Size = new System.Drawing.Size(152, 22);
            this.tsmTradeUnit.Text = "交易单位";
            // 
            // tsmEmployee
            // 
            this.tsmEmployee.Name = "tsmEmployee";
            this.tsmEmployee.Size = new System.Drawing.Size(152, 22);
            this.tsmEmployee.Text = "雇员管理";
            // 
            // tsmSection
            // 
            this.tsmSection.Name = "tsmSection";
            this.tsmSection.Size = new System.Drawing.Size(152, 22);
            this.tsmSection.Text = "部门管理";
            // 
            // tsmStorage
            // 
            this.tsmStorage.Name = "tsmStorage";
            this.tsmStorage.Size = new System.Drawing.Size(152, 22);
            this.tsmStorage.Text = "仓库管理";
            // 
            // tsmRetail
            // 
            this.tsmRetail.Name = "tsmRetail";
            this.tsmRetail.Size = new System.Drawing.Size(152, 22);
            this.tsmRetail.Text = "门店管理";
            // 
            // tsmSystem
            // 
            this.tsmSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSysChangeUser,
            this.tsmSysChangeAB,
            this.tsmSysChangePwd,
            this.toolStripSeparator1,
            this.tsmSysDBBackup,
            this.tsmSysDBRestore,
            this.toolStripSeparator2,
            this.tsmSendReport,
            this.tsmSysExit});
            this.tsmSystem.Name = "tsmSystem";
            this.tsmSystem.Size = new System.Drawing.Size(68, 21);
            this.tsmSystem.Text = "系统管理";
            // 
            // tsmSysChangeUser
            // 
            this.tsmSysChangeUser.Name = "tsmSysChangeUser";
            this.tsmSysChangeUser.Size = new System.Drawing.Size(163, 22);
            this.tsmSysChangeUser.Text = "切换用户";
            this.tsmSysChangeUser.Click += new System.EventHandler(this.tsmSysChangeUser_Click);
            // 
            // tsmSysChangeAB
            // 
            this.tsmSysChangeAB.Name = "tsmSysChangeAB";
            this.tsmSysChangeAB.Size = new System.Drawing.Size(163, 22);
            this.tsmSysChangeAB.Text = "切换账本";
            this.tsmSysChangeAB.Click += new System.EventHandler(this.tsmSysChangeAB_Click);
            // 
            // tsmSysChangePwd
            // 
            this.tsmSysChangePwd.Name = "tsmSysChangePwd";
            this.tsmSysChangePwd.Size = new System.Drawing.Size(163, 22);
            this.tsmSysChangePwd.Text = "修改密码";
            this.tsmSysChangePwd.Click += new System.EventHandler(this.tsmSysChangePwd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // tsmSysDBBackup
            // 
            this.tsmSysDBBackup.Name = "tsmSysDBBackup";
            this.tsmSysDBBackup.Size = new System.Drawing.Size(163, 22);
            this.tsmSysDBBackup.Text = "备份数据库";
            // 
            // tsmSysDBRestore
            // 
            this.tsmSysDBRestore.Name = "tsmSysDBRestore";
            this.tsmSysDBRestore.Size = new System.Drawing.Size(163, 22);
            this.tsmSysDBRestore.Text = "还原数据库";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // tsmSendReport
            // 
            this.tsmSendReport.Name = "tsmSendReport";
            this.tsmSendReport.Size = new System.Drawing.Size(163, 22);
            this.tsmSendReport.Text = "发送使用报告";
            this.tsmSendReport.Click += new System.EventHandler(this.tsmSendReport_Click);
            // 
            // tsmSysExit
            // 
            this.tsmSysExit.Name = "tsmSysExit";
            this.tsmSysExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.tsmSysExit.Size = new System.Drawing.Size(163, 22);
            this.tsmSysExit.Text = "退出系统";
            this.tsmSysExit.Click += new System.EventHandler(this.tsmSysExit_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMain.Controls.Add(this.tclMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(700, 408);
            this.pnlMain.TabIndex = 4;
            // 
            // tclMain
            // 
            this.tclMain.AllowDrop = true;
            this.tclMain.Controls.Add(this.tpgNav);
            this.tclMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tclMain.ImageList = this.imgListTapThumb;
            this.tclMain.Location = new System.Drawing.Point(0, 0);
            this.tclMain.Margin = new System.Windows.Forms.Padding(10);
            this.tclMain.Multiline = true;
            this.tclMain.Name = "tclMain";
            this.tclMain.SelectedIndex = 0;
            this.tclMain.Size = new System.Drawing.Size(696, 404);
            this.tclMain.TabIndex = 0;
            this.tclMain.SelectedIndexChanged += new System.EventHandler(this.tclMain_SelectedIndexChanged);
            // 
            // tpgNav
            // 
            this.tpgNav.Controls.Add(this.groupBox1);
            this.tpgNav.Controls.Add(this.gpbStore);
            this.tpgNav.Controls.Add(this.gpbSale);
            this.tpgNav.Controls.Add(this.gpbPurchase);
            this.tpgNav.Location = new System.Drawing.Point(4, 23);
            this.tpgNav.Name = "tpgNav";
            this.tpgNav.Padding = new System.Windows.Forms.Padding(3);
            this.tpgNav.Size = new System.Drawing.Size(688, 377);
            this.tpgNav.TabIndex = 0;
            this.tpgNav.Text = "导航图";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(334, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "盈亏模块";
            // 
            // gpbStore
            // 
            this.gpbStore.Controls.Add(this.btnGoodsInfo);
            this.gpbStore.Controls.Add(this.btnStoreDetail);
            this.gpbStore.Location = new System.Drawing.Point(83, 158);
            this.gpbStore.Name = "gpbStore";
            this.gpbStore.Size = new System.Drawing.Size(200, 100);
            this.gpbStore.TabIndex = 2;
            this.gpbStore.TabStop = false;
            this.gpbStore.Text = "库存模块";
            // 
            // btnGoodsInfo
            // 
            this.btnGoodsInfo.Location = new System.Drawing.Point(59, 50);
            this.btnGoodsInfo.Name = "btnGoodsInfo";
            this.btnGoodsInfo.Size = new System.Drawing.Size(75, 23);
            this.btnGoodsInfo.TabIndex = 0;
            this.btnGoodsInfo.Text = "商品信息";
            this.btnGoodsInfo.UseVisualStyleBackColor = true;
            this.btnGoodsInfo.Click += new System.EventHandler(this.btnGoodsInfo_Click);
            // 
            // btnStoreDetail
            // 
            this.btnStoreDetail.Location = new System.Drawing.Point(59, 21);
            this.btnStoreDetail.Name = "btnStoreDetail";
            this.btnStoreDetail.Size = new System.Drawing.Size(75, 23);
            this.btnStoreDetail.TabIndex = 0;
            this.btnStoreDetail.Text = "库存状况";
            this.btnStoreDetail.UseVisualStyleBackColor = true;
            // 
            // gpbSale
            // 
            this.gpbSale.BackColor = System.Drawing.SystemColors.Control;
            this.gpbSale.Controls.Add(this.btnNewSaleOrder);
            this.gpbSale.Location = new System.Drawing.Point(334, 24);
            this.gpbSale.Name = "gpbSale";
            this.gpbSale.Size = new System.Drawing.Size(200, 100);
            this.gpbSale.TabIndex = 1;
            this.gpbSale.TabStop = false;
            this.gpbSale.Text = "销售模块";
            // 
            // btnNewSaleOrder
            // 
            this.btnNewSaleOrder.Location = new System.Drawing.Point(59, 19);
            this.btnNewSaleOrder.Name = "btnNewSaleOrder";
            this.btnNewSaleOrder.Size = new System.Drawing.Size(75, 23);
            this.btnNewSaleOrder.TabIndex = 0;
            this.btnNewSaleOrder.Text = "创建销售单";
            this.btnNewSaleOrder.UseVisualStyleBackColor = true;
            // 
            // gpbPurchase
            // 
            this.gpbPurchase.Controls.Add(this.btnNewPurchaseOrder);
            this.gpbPurchase.Location = new System.Drawing.Point(83, 24);
            this.gpbPurchase.Name = "gpbPurchase";
            this.gpbPurchase.Size = new System.Drawing.Size(200, 100);
            this.gpbPurchase.TabIndex = 0;
            this.gpbPurchase.TabStop = false;
            this.gpbPurchase.Text = "进货模块";
            // 
            // btnNewPurchaseOrder
            // 
            this.btnNewPurchaseOrder.Location = new System.Drawing.Point(59, 20);
            this.btnNewPurchaseOrder.Name = "btnNewPurchaseOrder";
            this.btnNewPurchaseOrder.Size = new System.Drawing.Size(75, 23);
            this.btnNewPurchaseOrder.TabIndex = 0;
            this.btnNewPurchaseOrder.Text = "创建进货单";
            this.btnNewPurchaseOrder.UseVisualStyleBackColor = true;
            // 
            // imgListTapThumb
            // 
            this.imgListTapThumb.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgListTapThumb.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListTapThumb.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tsmTool
            // 
            this.tsmTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPicCompress});
            this.tsmTool.Name = "tsmTool";
            this.tsmTool.Size = new System.Drawing.Size(68, 21);
            this.tsmTool.Text = "应用工具";
            // 
            // tsmPicCompress
            // 
            this.tsmPicCompress.Name = "tsmPicCompress";
            this.tsmPicCompress.Size = new System.Drawing.Size(152, 22);
            this.tsmPicCompress.Text = "图片压缩";
            this.tsmPicCompress.Click += new System.EventHandler(this.tsmPicCompress_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 455);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.stsStatus);
            this.Controls.Add(this.mnsMain);
            this.MainMenuStrip = this.mnsMain;
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "包租公";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.Shown += new System.EventHandler(this.Mainform_Shown);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.tclMain.ResumeLayout(false);
            this.tpgNav.ResumeLayout(false);
            this.gpbStore.ResumeLayout(false);
            this.gpbSale.ResumeLayout(false);
            this.gpbPurchase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrStatus;
        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmSystem;
        private System.Windows.Forms.ToolStripMenuItem tsmSysChangeUser;
        private System.Windows.Forms.ToolStripMenuItem tsmSysChangeAB;
        private System.Windows.Forms.ToolStripMenuItem tsmSysChangePwd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmSysDBBackup;
        private System.Windows.Forms.ToolStripMenuItem tsmSysDBRestore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmSysExit;
        private System.Windows.Forms.ToolStripMenuItem tsmBasicInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmGoodsMgr;
        private System.Windows.Forms.ToolStripMenuItem tsmGoodsInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmGoodsColorGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmGoodsSizeGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmBrand;
        private System.Windows.Forms.ToolStripMenuItem tsmSeason;
        private System.Windows.Forms.ToolStripMenuItem tsmStuff;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmBarcode;
        private System.Windows.Forms.ToolStripMenuItem tsmTradeUnit;
        private System.Windows.Forms.ToolStripMenuItem tsmEmployee;
        private System.Windows.Forms.ToolStripMenuItem tsmSection;
        private System.Windows.Forms.ToolStripMenuItem tsmStorage;
        private System.Windows.Forms.ToolStripMenuItem tsmRetail;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TabControl tclMain;
        private System.Windows.Forms.TabPage tpgNav;
        private System.Windows.Forms.ImageList imgListTapThumb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gpbStore;
        private System.Windows.Forms.Button btnGoodsInfo;
        private System.Windows.Forms.Button btnStoreDetail;
        private System.Windows.Forms.GroupBox gpbSale;
        private System.Windows.Forms.Button btnNewSaleOrder;
        private System.Windows.Forms.GroupBox gpbPurchase;
        private System.Windows.Forms.Button btnNewPurchaseOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmSendReport;
        private System.Windows.Forms.ToolStripMenuItem tsmTool;
        private System.Windows.Forms.ToolStripMenuItem tsmPicCompress;
    }
}

