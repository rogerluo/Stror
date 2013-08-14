using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using StoreManagement.Properties;

namespace StoreManagement.Forms
{
    public partial class GoodsViewer : Panel
    {
        private Panel pnlTop = null;
        private Panel pnlMain = null;
        private Panel pnlBottom = null;

        private Label lblTitle = null;
        private Label lblPath = null;
        private TreeView trvFolder = null;
        private ContextMenuStrip cmsFolderMenu = null;
        private ListView lvwGoods = null;
        private ContextMenuStrip cmsGoodsMenu = null;

        private Button btnNewGoodsInfo = null;
        private Button btnModGoodsInfo = null;
        private Button btnDelGoodsInfo = null;
        private Button btnNewGoodsFolder = null;
        private Button btnModGoodsFolder = null;
        private Button btnDelGoodsFolder = null;

        public GoodsViewer()
        {
            InitializeComponent();

            this.SuspendLayout();

            InitializeSelfComponets();

            InitializeMainLayout();

            InitializeTopLayout();

            InitializeBottomLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public GoodsViewer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.SuspendLayout();

            InitializeSelfComponets();

            InitializeTopLayout();

            InitializeMainLayout();

            InitializeBottomLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitializeSelfComponets()
        {
            pnlMain = new Panel();
            lblPath = new Label();
            trvFolder = new TreeView();
            lvwGoods = new ListView();
            cmsFolderMenu = new ContextMenuStrip();
            cmsGoodsMenu = new ContextMenuStrip();

            //this.pnlMain.Controls.Add(cmsFolderMenu);
            this.pnlMain.Controls.Add(trvFolder);
            this.pnlMain.Controls.Add(lvwGoods);
            this.pnlMain.Controls.Add(lblPath);
            this.Controls.Add(pnlMain);

            pnlTop = new Panel();
            
            lblTitle = new Label();
            lblTitle.Text = Settings.Default.GoodsViewerTitle;
            pnlTop.Controls.Add(lblTitle);
            this.Controls.Add(pnlTop);

            pnlBottom = new Panel();
            btnNewGoodsInfo = new Button();
            btnModGoodsInfo = new Button();
            btnDelGoodsInfo = new Button();
            btnNewGoodsFolder = new Button();
            btnModGoodsFolder = new Button();
            btnDelGoodsFolder = new Button();
            this.pnlBottom.Controls.Add(btnNewGoodsInfo);
            this.pnlBottom.Controls.Add(btnModGoodsInfo);
            this.pnlBottom.Controls.Add(btnDelGoodsInfo);
            this.pnlBottom.Controls.Add(btnNewGoodsFolder);
            this.pnlBottom.Controls.Add(btnModGoodsFolder);
            this.pnlBottom.Controls.Add(btnDelGoodsFolder);
            this.Controls.Add(pnlBottom);
        }

        private void InitializeTopLayout()
        {
            this.pnlTop.SuspendLayout();

            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTop.Height = 30;

            this.lblTitle.Top = 5;
            this.lblTitle.Left = 5;

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
        }

        private void InitializeMainLayout()
        {
            this.pnlMain.SuspendLayout();

            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.cmsFolderMenu.Visible = false;
            ToolStripMenuItem addFolder = new ToolStripMenuItem("添加子类", null, addFolder_OnClick);
            ToolStripMenuItem delFolder = new ToolStripMenuItem("删除分类", null, delFolder_OnClick);
            ToolStripSeparator tss1 = new ToolStripSeparator();
            ToolStripMenuItem refreshFolder = new ToolStripMenuItem("刷新", null, refreshFolder_OnClick);
            ToolStripMenuItem propertyFolder = new ToolStripMenuItem("属性", null, propertyFolder_OnClick);
            this.cmsFolderMenu.Items.AddRange(new ToolStripItem[] {addFolder, delFolder, tss1, refreshFolder, propertyFolder});

            //this.trvFolder.Top = this.lblPath.Bottom;
            //this.trvFolder.Left = this.lblPath.Left;
            this.trvFolder.Dock = DockStyle.Left;
            this.trvFolder.Width = 250;
            //this.trvFolder.ContextMenuStrip = this.cmsFolderMenu;
            RefreshAllFolderList();

            this.lvwGoods.Top = this.trvFolder.Top;
            this.lvwGoods.Left = this.trvFolder.Right;
            this.lvwGoods.Dock = DockStyle.Fill;
            this.lvwGoods.Enabled = true;
            this.lvwGoods.MouseClick += new MouseEventHandler(lvwGoods_MouseClick);

            this.cmsGoodsMenu.Visible = false;
            ToolStripMenuItem addGoods = new ToolStripMenuItem("添加商品", null, addGoods_OnClick);
            ToolStripMenuItem delGoods = new ToolStripMenuItem("删除商品", null, delGoods_OnClick);
            ToolStripMenuItem uptGoods = new ToolStripMenuItem("修改商品", null, ModifyGoods_OnClick);
            ToolStripMenuItem refreshGoods = new ToolStripMenuItem("刷新", null, RefreshGoods_OnClick);
            this.cmsGoodsMenu.Items.AddRange(new ToolStripItem[]{addGoods, delGoods, uptGoods, refreshGoods});
            //this.lvwGoods.ContextMenuStrip = cmsGoodsMenu;

            this.lblPath.Text = "//";
            this.lblPath.Dock = DockStyle.Top;
            this.lblPath.Height = 30;
            this.lblPath.BackColor = System.Drawing.SystemColors.ControlDark;

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
        }

        void lvwGoods_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (this.lvwGoods.SelectedIndices.Count == 0)
                {
                    this.cmsGoodsMenu.Items["addGoods"].Enabled = false;
                    this.cmsGoodsMenu.Show(this.lvwGoods, e.X, e.Y);
                }
            }
        }

        private void InitializeBottomLayout()
        {
            this.pnlBottom.SuspendLayout();

            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Height = 50;

            this.btnNewGoodsInfo.Text = "创建商品信息";
            this.btnNewGoodsInfo.Width = 100;
            this.btnNewGoodsInfo.Top = this.pnlBottom.Top + 10;
            this.btnNewGoodsInfo.Left = this.pnlBottom.Left + 10;
            this.btnNewGoodsInfo.Click += new EventHandler(btnNewGoodsInfo_Click);

            this.btnModGoodsInfo.Text = "修改商品信息";
            this.btnModGoodsInfo.Width = 100;
            this.btnModGoodsInfo.Top = this.btnNewGoodsInfo.Top;
            this.btnModGoodsInfo.Left = this.btnNewGoodsInfo.Right;
            this.btnModGoodsInfo.Enabled = false;

            this.btnDelGoodsInfo.Text = "删除商品信息";
            this.btnDelGoodsInfo.Width = 100;
            this.btnDelGoodsInfo.Top = this.btnModGoodsInfo.Top;
            this.btnDelGoodsInfo.Left = this.btnModGoodsInfo.Right;
            this.btnDelGoodsInfo.Enabled = false;

            this.btnNewGoodsFolder.Text = "创建商品分类";
            this.btnNewGoodsFolder.Width = 100;
            this.btnNewGoodsFolder.Top = this.btnDelGoodsInfo.Top;
            this.btnNewGoodsFolder.Left = this.btnDelGoodsInfo.Right;

            this.btnModGoodsFolder.Text = "修改商品分类";
            this.btnModGoodsFolder.Width = 100;
            this.btnModGoodsFolder.Top = this.btnNewGoodsFolder.Top;
            this.btnModGoodsFolder.Left = this.btnNewGoodsFolder.Right;
            this.btnModGoodsFolder.Enabled = false;

            this.btnDelGoodsFolder.Text = "删除商品分类";
            this.btnDelGoodsFolder.Width = 100;
            this.btnDelGoodsFolder.Top = this.btnModGoodsFolder.Top;
            this.btnDelGoodsFolder.Left = this.btnModGoodsFolder.Right;
            this.btnDelGoodsFolder.Enabled = false;

            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
        }

        void btnNewGoodsInfo_Click(object sender, EventArgs e)
        {
            GoodsInfoForm frm = new GoodsInfoForm();
            frm.ShowDialog(this);
        }

        private void RefreshAllFolderList()
        {
            Dictionary<int, Folder> folders = LoginUser.CurrentUser.FolderList;
            folders.Clear();
            if (false == Utility.DBProvider.GetAllGoodsFolder(Utility.DBProvider.DBName, folders))
            {
                MessageBox.Show(Utility.LastErrorMessage);
            }
            else
            {
                Folder.RebuildFolderRelationship(folders);
            }

            this.trvFolder.Nodes.Clear();
            int root = 1;
            if (folders.ContainsKey(root) == false)
            {
                MessageBox.Show("没有根分类");
                return;
            }

            this.trvFolder.Nodes.Add(root.ToString(), folders[root].Name);
            this.trvFolder.Nodes[root.ToString()].Tag = root;
            this.trvFolder.NodeMouseClick += new TreeNodeMouseClickEventHandler(trvFolder_NodeMouseClick);
            RecursiveRebuildFolder(root, trvFolder.Nodes[root.ToString()]);
        }

        private void trvFolder_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point pos = new Point(e.Node.Bounds.X + e.Node.Bounds.Width, e.Node.Bounds.Y + e.Node.Bounds.Height / 2);
                this.cmsFolderMenu.Show(this.trvFolder, pos);
                this.trvFolder.SelectedNode = e.Node;
            }
        }

        private void addFolder_OnClick(object sender, System.EventArgs e)
        {
            if (this.trvFolder.SelectedNode == null)
            {
                MessageBox.Show("请选中商品分类");
                return;
            }
            using (FolderSettingForm frm = new FolderSettingForm(null))
            {
                if (DialogResult.OK == frm.ShowDialog(this))
                {
                    int id = 0;
                    int parentId = (int)this.trvFolder.SelectedNode.Tag;
                    if (false == Utility.DBProvider.AddFolder(Utility.DBProvider.DBName, parentId, frm.FolderName, out id))
                    {
                        MessageBox.Show(Utility.LastErrorMessage);
                    }
                    else
                    {
                        MessageBox.Show(Settings.Default.FolderSettingAddSuccess);
                        Folder folder = new Folder{Name = frm.FolderName, Childs = new HashSet<int>(), ID = id, ParentID = parentId};
                        LoginUser.CurrentUser.FolderList.Add(id, folder);
                        LoginUser.CurrentUser.FolderList[parentId].Childs.Add(id);

                        this.trvFolder.SelectedNode.Nodes.Add(id.ToString(), frm.FolderName);
                        this.trvFolder.SelectedNode.Nodes[id.ToString()].Tag = id;
                    }
                }
                frm.Dispose();
            }
        }

        private void delFolder_OnClick(object sender, System.EventArgs e)
        {
            if (this.trvFolder.SelectedNode == null)
            {
                MessageBox.Show("请选中商品分类");
                return;
            }
            int id = (int)trvFolder.SelectedNode.Tag;
            if (DialogResult.OK == MessageBox.Show("确定删除商品分类?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                if (false == Utility.DBProvider.DeleteFolder(Utility.DBProvider.DBName, id))
                    MessageBox.Show(Utility.LastErrorMessage);
                else
                {
                    int parentId = LoginUser.CurrentUser.FolderList[id].ParentID;
                    LoginUser.CurrentUser.FolderList.Remove(id);
                    LoginUser.CurrentUser.FolderList[parentId].Childs.Remove(id);
                    this.trvFolder.SelectedNode.Remove();
                    MessageBox.Show("删除商品分类成功");
                }
            }
        }

        private void refreshFolder_OnClick(object sender, System.EventArgs e)
        {
            if (this.trvFolder.SelectedNode == null)
            {
                MessageBox.Show("请选中商品分类");
                return;
            }
            int id = (int)trvFolder.SelectedNode.Tag;
            RefreshAllFolderList();
            RecursiveExpandParentNode(id).Expand();
            
        }

        private void propertyFolder_OnClick(object sender, System.EventArgs e)
        {
            if (this.trvFolder.SelectedNode == null)
            {
                MessageBox.Show("请选中商品分类");
                return;
            }
            using (FolderSettingForm frm = new FolderSettingForm(trvFolder.SelectedNode.Text))
            {
                if (DialogResult.OK == frm.ShowDialog(this))
                {
                    int id = (int)this.trvFolder.SelectedNode.Tag;
                    if (false == Utility.DBProvider.ModifyFolder(Utility.DBProvider.DBName, id, frm.FolderName))
                    {
                        MessageBox.Show(Utility.LastErrorMessage);
                    }
                    else
                    {
                        MessageBox.Show(Settings.Default.FolderSettingModifySuccess);
                        LoginUser.CurrentUser.FolderList[id].Name = frm.FolderName;
                        this.trvFolder.SelectedNode.Text = frm.FolderName;
                    }
                }
                frm.Dispose();
            }
        }
        
        private void RecursiveRebuildFolder(int ParentID,  TreeNode ParentNode)
        {
            foreach (int childID in LoginUser.CurrentUser.FolderList[ParentID].Childs)
            {
                ParentNode.Nodes.Add(childID.ToString(), LoginUser.CurrentUser.FolderList[childID].Name);
                ParentNode.Nodes[childID.ToString()].Tag = childID;
                if (LoginUser.CurrentUser.FolderList[childID].Childs.Count > 0)
                { 
                    RecursiveRebuildFolder(childID, ParentNode.Nodes[childID.ToString()]);
                }
            }
        }

        private void addGoods_OnClick(object sender, System.EventArgs e)
        { 
        
        }

        private void delGoods_OnClick(object sender, System.EventArgs e)
        { 
        
        }

        private void ModifyGoods_OnClick(object sender, System.EventArgs e)
        { 
            
        }

        private void RefreshGoods_OnClick(object sender, System.EventArgs e)
        { 
            
        }

        private TreeNode RecursiveExpandParentNode(int id)
        {
            int parentId = LoginUser.CurrentUser.FolderList[id].ParentID;
            if (parentId == 0)
            {
                return trvFolder.Nodes[id.ToString()];
            }
            else
            {
                TreeNode parentNode = RecursiveExpandParentNode(parentId);
                parentNode.Expand();
                if (parentNode.Nodes.ContainsKey(id.ToString()) == true)
                    return parentNode.Nodes[id.ToString()];
                else
                    return null;
            }
        }
    }
}
