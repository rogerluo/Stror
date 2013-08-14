using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using StoreManagement.Forms;
using StoreManagement.Properties;

namespace StoreManagement
{
    public partial class Mainform : Form
    {
        private bool m_bInitialized = false;
        private LoginUser m_User = null;

        public Mainform()
        {
            InitializeComponent();

            Utility.RunningPath = System.Environment.CurrentDirectory;
            // Init self controller
            SuspendLayout();
            InitStatus();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            
        }

        private void Mainform_Shown(object sender, EventArgs e)
        {
            //// show loginguide dialog
            //Form loginguide = new LoginGuideForm();
            //if (DialogResult.Yes != loginguide.ShowDialog(this) ||
            //    LoginUser.CurrentUser.Available == false)
            //{
            //    Application.Exit();
            //    return;
            //}

            //MessageBox.Show("初始化模块完成");

            TestInitialize(); 

            InitImageListTapThumb();

            tclMain.TabPages["tpgNav"].ImageIndex = 0;
            
            RefreshStatus();
            tmrStatus.Start();
        }

        

        private void TestInitialize()
        {
            Utility.DBProvider = DBFactory.InitProvider(DBType.MSSQL, new IPEndPoint(IPAddress.Parse(Settings.Default.ServerIP), 1433), "sa", "intel@123", null);
            Utility.DBProvider.ABName = "AA";
            Utility.DBProvider.DBName = "AA";
            LoginUser.CurrentUser.UserID = 1;
            LoginUser.CurrentUser.UserName = "管理员";
            LoginUser.CurrentUser.UserPwd = "000000";
            
        }

        /// <summary> 
        /// 初始化任务栏
        /// </summary>
        private void InitStatus() 
        {
            this.stsStatus.SuspendLayout();
            // Timer
            ToolStripStatusLabel tsslblTimer = new ToolStripStatusLabel();
            tsslblTimer.Name = "tsslblTimer";
            tsslblTimer.Text = Utility.GetLongSysDateTimeString();

            ToolStripSeparator tssp1 = new ToolStripSeparator();

            ToolStripStatusLabel tsslblUser = new ToolStripStatusLabel();
            tsslblUser.Name = "tsslblUser";
            tsslblUser.Text = "登录人员：";

            ToolStripSeparator tssp2 = new ToolStripSeparator();

            ToolStripStatusLabel tsslblABName = new ToolStripStatusLabel();
            tsslblABName.Name = "tsslblABName";
            tsslblABName.Text = "当前账本：";

            ToolStripSeparator tssp3 = new ToolStripSeparator();

            ToolStripStatusLabel tsslblIP = new ToolStripStatusLabel();
            tsslblIP.Name = "tsslblIP";
            tsslblIP.Text = "IP：";

            this.stsStatus.Items.AddRange(new ToolStripItem[] { tsslblTimer, tssp1, tsslblUser, tssp2, tsslblABName, tssp3, tsslblIP});

            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
        }

        /// <summary>
        /// 重置任务栏信息
        /// </summary>
        private void RefreshStatus()
        {
            this.stsStatus.SuspendLayout();

            this.stsStatus.Items["tsslblUser"].Text = string.Format("登陆人员: {0}", LoginUser.CurrentUser.UserName);
            this.stsStatus.Items["tsslblABName"].Text = string.Format("当前账本: {0}", Utility.DBProvider.ABName);
           //this.stsStatus.Items["tsslblIP"].Text = string.Format("IP：{0}", Utility.InternetIP);

            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
        }
        

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            stsStatus.Items["tsslblTimer"].Text = Utility.GetLongSysDateTimeString();
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmSysExit_Click(object sender, EventArgs e)
        {
            // todo 检查是否存在没有保存的账单
            Application.Exit();
        }

        /// <summary>
        /// 切换用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmSysChangeUser_Click(object sender, EventArgs e)
        {
            SysChangeUserForm frm = new SysChangeUserForm();
            if (DialogResult.OK == frm.ShowDialog())
            {
                MessageBox.Show(Settings.Default.SysChangeUserSuccess);
                Utility.UpdateLoginHistory(LoginUser.CurrentUser.UserName);
                RefreshStatus();
            }
        }

        /// <summary>
        /// 切换账本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmSysChangeAB_Click(object sender, EventArgs e)
        {
            SysChangeAB frm = new SysChangeAB();
            if (DialogResult.OK == frm.ShowDialog())
            {   
                MessageBox.Show(Settings.Default.SysChangeABSuccess);
                Utility.UpdateLoginHistory(LoginUser.CurrentUser.UserName);
                RefreshStatus();
                return;
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmSysChangePwd_Click(object sender, EventArgs e)
        {
            SysChangePwd frm = new SysChangePwd();
            if (DialogResult.OK == frm.ShowDialog())
            {
                MessageBox.Show(Settings.Default.SysChangePwdSuccess);
                return;
            }
        }

        /// <summary>
        /// 商品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmGoodsInfo_Click(object sender, EventArgs e)
        {
            TabPage page = new TabPage("商品信息");
            GoodsViewer viewer = new GoodsViewer();
            page.Controls.Add(viewer);
            viewer.Dock = DockStyle.Fill;
            this.tclMain.TabPages.Add(page);
        }

        /// <summary>
        /// 初始化选项卡缩略图
        /// </summary>
        private void InitImageListTapThumb()
        {
            imgListTapThumb.Images.Add("导", Image.FromFile(Settings.Default.PictureFolder + "/导.gif"));
            imgListTapThumb.Images.Add(Image.FromFile(Settings.Default.PictureFolder + "/商.gif"));
        }

        //private void tclMain_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    try
        //    {
        //        Rectangle curTabRect = tclMain.GetTabRect(e.Index);
        //        SizeF SText = e.Graphics.MeasureString(tclMain.TabPages[e.Index].Text, this.Font);
        //        int top = (curTabRect.Height - (int)SText.Height) / 2 + curTabRect.Y;
        //        int left = curTabRect.X;
        //        // 绘画前标志
        //        e.Graphics.DrawImage(imgListTapThumb.Images["导"], left, (curTabRect.Height - SText.Height) /2 + curTabRect.Y);
        //        // 绘画文字
        //        left += 16;
        //        e.Graphics.DrawString(tclMain.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText, left, top);
        //        // 绘画后标志
        //        left += (int)SText.Width;
        //        e.Graphics.DrawImage(Image.FromFile(Settings.Default.PictureFolder + "/close_leave.png"), new Point(left, top));
        //        e.Graphics.Dispose();
        //        tclMain.Tag = new Rectangle(new Point(left, top), new Size(16, 16));
        //    }
        //    catch (Exception anyExp)
        //    {
        //        MessageBox.Show(anyExp.Message);
        //    }
            
        //    return;
        //}

        //private void tclMain_MouseMove(object sender, MouseEventArgs e)
        //{
        //    Rectangle imgRec = (Rectangle)tclMain.Tag;
        //    if (e.X >= imgRec.Left && e.X <= imgRec.Right && e.Y >= imgRec.Top && e.Y <= imgRec.Bottom)
        //    {
        //        if (this.tclMain.SelectedIndex > 0)
        //        {
        //            this.tclMain.TabPages.Remove(this.tclMain.SelectedTab);
        //        }
        //    }
        //}

        private void tclMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnGoodsInfo_Click(object sender, EventArgs e)
        {
            tclMain.TabPages.Add("商品信息", "商品信息", 1);
            TabPage newpage = tclMain.TabPages[tclMain.TabCount - 1];
            GoodsViewer viewer = new GoodsViewer();
            newpage.Controls.Add(viewer);
            viewer.Dock = DockStyle.Fill;
            tclMain.SelectedIndex = tclMain.TabCount - 1;
            newpage.SuspendLayout();
            newpage.ResumeLayout(false);
            newpage.PerformLayout();
        }

        private void tsmSendReport_Click(object sender, EventArgs e)
        {
            string emailType = "smtp.163.com";//你的邮箱类型-这里是163，要是QQ就smtp.qq.com
            string emailName = "luodingjia1985@163.com";
            string emailPass = "intel@123";
            string toEmail = "luodingjia@gmail.com";
            string emailTitle = "LandMen IP";

            //aa是邮件内容
            string aa = "<table width=\"224\" height=\"114\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td>"+Utility.InternetIP+"</td></tr></table>";

            //调用发邮件
            Utility.SendSMTPEMail(emailType, emailName, emailPass, toEmail, emailTitle, aa);
        }

        private void tsmPicCompress_Click(object sender, EventArgs e)
        {
            using (PicCompressForm frm = new PicCompressForm())
            {
                frm.ShowDialog(this);
            }

        }

    }

   
}
