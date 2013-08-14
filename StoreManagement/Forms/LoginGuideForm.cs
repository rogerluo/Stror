using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using StoreManagement.Properties;

namespace StoreManagement
{
    public partial class LoginGuideForm : Form
    {
        public enum LOGINPNLTYPE
        { 
            NONE,
            ADDRESS,
            DATABASE,
            AUTHENTICATION,
        }
        private LOGINPNLTYPE m_curPnl = LOGINPNLTYPE.NONE;
        private IPAddress m_IP = null;
        private short m_port = 0;
        private IPEndPoint m_EP = null;
        private DBType m_DBType = DBType.MYSQL;
        private string m_User = null;
        private string m_Pwd = null;  
        private DataTable m_DT = null;
        private bool m_bRunning = false;
        private WaitForm m_WaitForm = null;
        private List<string> logins = null;
        
        private bool m_bValid = false;

        public LoginGuideForm()
        {
            InitializeComponent();
            InitLMTable();
            // Test
            logins = Utility.GetLoginHistory();

        }

        private void LoginGuide_Load(object sender, EventArgs e)
        {
            SuspendLayout();

            InitNavButtons();
            InitAddressPanel();
            InitDataBasePanel();
            InitAuthPanel();

            SwitchPanel(LOGINPNLTYPE.ADDRESS);
            
            ResumeLayout(false);
            PerformLayout();
        }

        private void InitNavButtons()
        {
            this.btnCancel.Top =  5;
            this.btnCancel.Width = 75;
            this.btnCancel.Height = 25;
            this.btnCancel.Left = this.pnlControl.Width - this.btnCancel.Width - 10;
            this.btnCancel.Enabled = true;

            this.btnNext.Top = this.btnCancel.Top;
            this.btnNext.Width = 75;
            this.btnNext.Height = 25;
            this.btnNext.Left = this.btnCancel.Left - 10 - this.btnNext.Width;
            this.btnNext.Enabled = true;

            this.btnPrev.Top = this.btnNext.Top;
            this.btnPrev.Width = 75;
            this.btnPrev.Height = 25;
            this.btnPrev.Left = this.btnNext.Left - 10 - this.btnPrev.Width;
            this.btnPrev.Enabled = true;

            this.btnFin.Location = this.btnNext.Location;
            this.btnFin.Visible = false;
            this.btnFin.Enabled = true;

            return;
        }

        private void InitAddressPanel()
        {
            this.pnlAddr.SuspendLayout();
            this.pnlAddr.Dock = DockStyle.Fill;

            this.lblAddrDesc.Text = "选择服务器";
            this.lblAddrDesc.Top = 10;
            this.lblAddrDesc.Left = 10;
            this.lblAddrDesc.Width = 100;
            this.lblAddrDesc.Height = 15;

            this.lblAddrList.Text = "请输入服务器名字或者IP地址：";
            this.lblAddrList.Top = lblAddrDesc.Top + lblAddrDesc.Height + 10;
            this.lblAddrList.Left = lblAddrDesc.Left;
            this.lblAddrList.Height = 15;

            this.cmbAddrList.Top = this.lblAddrList.Top;
            this.cmbAddrList.Left = this.lblAddrList.Right + 5;
            this.cmbAddrList.Width = 200;
            this.cmbAddrList.Height = 20;
            this.cmbAddrList.Items.AddRange(Utility.GetLocalIPAddress().ToArray());

            this.lblDBList.Text = "请选择数据库类型：";
            this.lblDBList.Top = this.lblAddrList.Top + this.lblAddrList.Height + 10;
            this.lblDBList.Left = this.lblAddrList.Left;
            this.lblDBList.Height = 20;

            this.cmbDBList.Top = this.lblDBList.Top;
            this.cmbDBList.Left = this.lblDBList.Right + 5;
            this.cmbDBList.Width = 100;
            this.cmbDBList.Height = 20;
            this.cmbDBList.Items.AddRange(new string[]{"MySQL", "MSSQL", "ORACLE"});
            //this.cmbDBList.SelectedIndex = 0;

            this.lblAddrPort.Text = "端口";
            this.lblAddrPort.Top = this.lblDBList.Top;
            this.lblAddrPort.Left = this.cmbDBList.Right + 5;
            this.lblAddrPort.Height = 20;

            //this.tbxAddrPort.Text = "3306";
            this.tbxAddrPort.Top = this.lblAddrPort.Top;
            this.tbxAddrPort.Left = this.lblAddrPort.Right + 5;
            this.tbxAddrPort.Width = 50;
            this.tbxAddrPort.Height = 20;

            this.pbxLoad.Top = this.lblDBList.Bottom + 10;
            this.pbxLoad.Left = this.lblDBList.Left;
            this.pbxLoad.Width = 27;
            this.pbxLoad.Height = 27;
            this.pbxLoad.Visible = false;

            this.lblTestConnetc.Text = "连接中...";
            this.lblTestConnetc.Top = this.pbxLoad.Top;
            this.lblTestConnetc.Left = this.pbxLoad.Right + 5;
            this.lblTestConnetc.Height = 25;
            this.lblTestConnetc.Visible = false;

            this.lblDBUser.Text = "登录名:";
            this.lblDBUser.Top = this.pbxLoad.Bottom + 10;
            this.lblDBUser.Left = 100;
            this.lblDBUser.Width = 100;
            this.lblDBUser.Height = 20;

            this.tbxDBUser.Top = this.lblDBUser.Top;
            this.tbxDBUser.Left = this.lblDBUser.Right + 5;
            this.tbxDBUser.Width = 200;
            this.tbxDBUser.Height = 20;

            this.lblDBPwd.Text = "密码:";
            this.lblDBPwd.Top = this.lblDBUser.Bottom + 10;
            this.lblDBPwd.Left = this.lblDBUser.Left;
            this.lblDBPwd.Width = 100;
            this.lblDBPwd.Height = 20;

            this.tbxDBPwd.Top = this.lblDBPwd.Top;
            this.tbxDBPwd.Left = this.tbxDBUser.Left;
            this.tbxDBPwd.Width = 200;
            this.tbxDBPwd.Height = 20;

            this.btnTestConnect.Text = "测试连接";
            this.btnTestConnect.Top = this.tbxDBPwd.Bottom + 10;
            this.btnTestConnect.Left = this.Width / 3 * 2;
            this.btnTestConnect.Width = 70;
            this.btnTestConnect.Height = 20;

            // DEBUG
            this.cmbAddrList.Text = Settings.Default.ServerIP;
            this.cmbDBList.SelectedIndex = 1;
            this.tbxDBPwd.Text = "intel@123";
            this.pnlAddr.Visible = false;
            this.pnlAddr.ResumeLayout(false);
            this.pnlAddr.PerformLayout();
            
            return;
        }

        private void InitDataBasePanel()
        {
            this.pnlDB.SuspendLayout();
            this.pnlDB.Dock = DockStyle.Fill;

            this.lblABDesc.Text = Settings.Default.ABDescMessage;
            this.lblABDesc.Top = 10;
            this.lblABDesc.Left = 10;
            this.lblABDesc.Width = 400;
            this.lblABDesc.Height = 50;

            this.dgvABList.Top = this.lblABDesc.Bottom + 10;
            this.dgvABList.Left = this.lblABDesc.Left;
            this.dgvABList.Width = 300;
            this.dgvABList.Height = 150;

            this.btnAddAB.Text = "增加账本";
            this.btnAddAB.Top = this.dgvABList.Top;
            this.btnAddAB.Left = this.dgvABList.Right + 5;
            this.btnAddAB.Width = 75;
            this.btnAddAB.Height = 30;

            this.btnDelAB.Text = "删除账本";
            this.btnDelAB.Top = this.btnAddAB.Bottom + 5;
            this.btnDelAB.Left = this.btnAddAB.Left;
            this.btnDelAB.Width = 75;
            this.btnDelAB.Height = 30;

            this.btnAllAB.Text = "全选";
            this.btnAllAB.Top = this.btnDelAB.Bottom + 5;
            this.btnAllAB.Left = this.btnDelAB.Left;
            this.btnAllAB.Width = 75;
            this.btnAllAB.Height = 30;
            this.btnAllAB.Enabled = false;

            this.btnInvAB.Text = "反选";
            this.btnInvAB.Top = this.btnAllAB.Bottom + 5;
            this.btnInvAB.Left = this.btnAllAB.Left;
            this.btnInvAB.Width = 75;
            this.btnInvAB.Height = 30;
            this.btnInvAB.Enabled = false;

            this.pnlDB.Visible = false;
            this.pnlDB.ResumeLayout(false);
            this.pnlDB.PerformLayout();

            return;
        }

        private void InitAuthPanel()
        {
            this.pnlAuth.SuspendLayout();
            this.pnlAuth.Dock = DockStyle.Fill;

            this.lblLogDateDesc.Text = "登录时间";
            this.lblLogDateDesc.Top = this.pnlAuth.Top + this.pnlAuth.Height / 3;
            this.lblLogDateDesc.Left = this.pnlAuth.Left +this.pnlAuth.Width / 5;
            this.lblLogDateDesc.Width = 100;
            this.lblLogDateDesc.Height = 20;

            this.dtpLogDate.Top = this.lblLogDateDesc.Top;
            this.dtpLogDate.Left = this.lblLogDateDesc.Right + 5;
            this.dtpLogDate.Width = 200;
            this.dtpLogDate.Height = 20;

            this.lblAuthUser.Text = "登录人员";
            this.lblAuthUser.Top = this.lblLogDateDesc.Bottom + 20;
            this.lblAuthUser.Left = this.lblLogDateDesc.Left;
            this.lblAuthUser.Width = 100;
            this.lblAuthUser.Height = 20;

            this.cmbAuthUser.Top = this.lblAuthUser.Top;
            this.cmbAuthUser.Left = this.dtpLogDate.Left;
            this.cmbAuthUser.Width = 200;
            this.cmbAuthUser.Height = 20;

            this.lblAuthPwd.Text = "登录密码";
            this.lblAuthPwd.Top = this.lblAuthUser.Bottom + 20;
            this.lblAuthPwd.Left = this.lblAuthUser.Left;
            this.lblAuthPwd.Width = 100;
            this.lblAuthPwd.Height = 20;

            this.tbxAuthPwd.Top = this.lblAuthPwd.Top;
            this.tbxAuthPwd.Left = this.dtpLogDate.Left;
            this.tbxAuthPwd.Width = 200;
            this.tbxAuthPwd.Height = 20;

            this.pnlAuth.Visible = false;
            this.pnlAuth.ResumeLayout(false);
            this.pnlAuth.PerformLayout();

            // Load login history
            this.cmbAuthUser.Items.Clear();
            List<string> lgnHis = Utility.GetLoginHistory();
            if (lgnHis != null && lgnHis.Count > 0)
            {
                this.cmbAuthUser.Items.AddRange(lgnHis.ToArray());
                this.cmbAuthUser.SelectedIndex = 0;
            }

            // DEBUG
            this.tbxAuthPwd.Text = "000000";

            return;
        }

        private void SwitchPanel(LOGINPNLTYPE newPnl)
        {
            if (m_curPnl == newPnl)
                return;
            // Hide current panel
            switch (m_curPnl)
            {
                case LOGINPNLTYPE.NONE:
                    { 
                        
                    }
                    break;
                case LOGINPNLTYPE.ADDRESS:
                    {
                        this.pnlAddr.Visible = false;
                    }
                    break;
                case LOGINPNLTYPE.DATABASE:
                    {
                        this.pnlDB.Visible = false;
                    }
                    break;
                case LOGINPNLTYPE.AUTHENTICATION:
                    {
                        this.pnlAuth.Visible = false;
                    }
                    break;
                default:
                    {
                        MessageBox.Show(string.Format("非定义登录代码: {0}", newPnl), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }

            // Show new panel
            switch (newPnl)
            {
                case LOGINPNLTYPE.ADDRESS:
                    {
                        this.pnlAddr.Visible = true;
                    }
                    break;
                case LOGINPNLTYPE.DATABASE:
                    {
                        this.pnlDB.Visible = true;
                    }
                    break;
                case LOGINPNLTYPE.AUTHENTICATION:
                    {
                        this.pnlAuth.Visible = true;
                    }
                    break;
                default:
                    {
                        MessageBox.Show(string.Format("非定义登录代码: {0}", newPnl), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
            m_curPnl = newPnl;
            return;
        }

        private void SetNavButtons()
        {
            switch (m_curPnl)
            {
                case LOGINPNLTYPE.ADDRESS:
                    {
                        this.btnPrev.Enabled = false;
                        this.btnNext.Enabled = true;
                    }
                    break;
                case LOGINPNLTYPE.DATABASE:
                    {
                        this.btnPrev.Enabled = true;
                        this.btnNext.Visible = true;
                        this.btnFin.Visible = false;
                    }
                    break;
                case LOGINPNLTYPE.AUTHENTICATION:
                    {
                        this.btnPrev.Enabled = true;
                        this.btnNext.Visible = false;
                        this.btnFin.Visible = true;
                    }
                    break;
                default:
                    {
                        MessageBox.Show(string.Format("非定义登录代码: {0}", m_curPnl), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;  
            }
            return;
        }

        private void InitLMTable()
        {
            m_DT = new DataTable(Settings.Default.LMTABLE);
            //m_DT.Columns.Add(new DataColumn("编号", typeof(int)));
            //m_DT.Columns.Add(new DataColumn("账本", typeof(string)));
            //m_DT.Columns.Add(new DataColumn("数据库", typeof(string)));
            //m_DT.Columns.Add(new DataColumn("创建时间", typeof(DateTime)));
            //m_DT.PrimaryKey = new DataColumn[1] { m_DT.Columns["编号"] };

            
        }

        private void BuildLMTable()
        {
            this.pnlDB.SuspendLayout();

            if (false == Utility.DBProvider.GetAB(m_DT))
            {
                MessageBox.Show(Utility.LastErrorMessage, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //this.dgvABList.Columns.Add("ABNAME", "账本");
                //this.dgvABList.Columns["ABNAME"].DataPropertyName = "ABNAME";
                this.dgvABList.DataSource = m_DT;
            }
            if (m_DT.Rows.Count == 0)
            {
                btnDelAB.Enabled = false;
                btnAllAB.Enabled = false;
                btnInvAB.Enabled = false;
            }
            else
            {
                btnDelAB.Enabled = true;
                btnAllAB.Enabled = true;
                btnInvAB.Enabled = true;
            }
            this.pnlDB.ResumeLayout(false);
            this.pnlDB.PerformLayout();
            
            //if (Utility.DBProvider.State == ConnectionState.Open)
            //{
            //    m_DT.Clear();
            //    if (false == Utility.DBProvider.GetAB(m_DT))
            //    {
            //        MessageBox.Show(Utility.LastErrorMessage, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    if (false == m_DT.Columns.Contains("ABName") ||
            //        false == m_DT.Columns.Contains("DBName"))
            //    {
            //        MessageBox.Show("主表列定义出错", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    this.dgvABList.Rows.Clear();
            //    //foreach (DataRow row in m_DT.Rows)
            //    //{
            //    //    dgvABList.Rows.Add(new object[] { "false", row["id"], row["ABName"], row["DBName"], row["CrtDate"]});
            //    //}
                
            //    if (m_DT.Rows.Count == 0)
            //    {
            //        btnDelAB.Enabled = false;
            //        btnAllAB.Enabled = false;
            //        btnInvAB.Enabled = false;
            //    }
            //    else
            //    {
            //        btnDelAB.Enabled = true;
            //        btnAllAB.Enabled = true;
            //        btnInvAB.Enabled = true;
            //    }
            //}
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            switch (m_curPnl)
            {
                case LOGINPNLTYPE.ADDRESS:
                    {
                        if (m_bValid == false)
                        {
                            TestConnect();
                            return;
                        }

                        BuildLMTable();
                        SwitchPanel(LOGINPNLTYPE.DATABASE);
                    }
                    break;
                case LOGINPNLTYPE.DATABASE:
                    {
                        if (dgvABList.CurrentCell == null || dgvABList.CurrentCell.RowIndex == -1)
                        {
                            MessageBox.Show("请选择账本");
                            btnNext.Enabled = false;
                            return;
                        }
                        Utility.DBProvider.ABName = (string)dgvABList[1, dgvABList.CurrentCell.RowIndex].Value;
                        Utility.DBProvider.DBName = (string)dgvABList[2, dgvABList.CurrentCell.RowIndex].Value;
                        SwitchPanel(LOGINPNLTYPE.AUTHENTICATION);
                    }
                    break;
                case LOGINPNLTYPE.AUTHENTICATION:
                    {
                        MessageBox.Show("登录成功");
                    }
                    break;
                default:
                    {
                        MessageBox.Show(string.Format("非定义登录代码: {0}", m_curPnl), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
            SetNavButtons();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("你确定要退出程序吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                DialogResult = DialogResult.Cancel;
                this.Hide();
                this.Close();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            switch (m_curPnl)
            {
                case LOGINPNLTYPE.ADDRESS:
                    {
                        MessageBox.Show("无法返回上一步");
                    }
                    break;
                case LOGINPNLTYPE.DATABASE:
                    {
                        SwitchPanel(LOGINPNLTYPE.ADDRESS);
                    }
                    break;
                case LOGINPNLTYPE.AUTHENTICATION:
                    {
                        SwitchPanel(LOGINPNLTYPE.DATABASE);
                    }
                    break;
                default:
                    {
                        MessageBox.Show(string.Format("非定义登录代码: {0}", m_curPnl), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
            SetNavButtons();
            return;
        }

        private void TestConnect()
        {
            // check IP address
            if (IPAddress.TryParse(cmbAddrList.Text.Trim(), out m_IP) == false)
            {
                MessageBox.Show(Settings.Default.InvalidIPAddressMsg);
                cmbAddrList.Focus();
                return;
            }
            // check IP port
            if (m_port == 0)
            {
                IsValidIPPort();
                return;
            }
            // check DBType
            if (cmbDBList.SelectedIndex == -1)
            {
                MessageBox.Show("请选择数据库类型");
                cmbDBList.Focus();
                return;
            }
            // check DB User 
            if (string.IsNullOrEmpty(tbxDBUser.Text.Trim()) == true)
            {
                MessageBox.Show("请输入登录名");
                tbxDBUser.Focus();
                return;
            }
            //// check connection
            if (Utility.SvrSocket != null && Utility.SvrSocket.Connected == true)
            {
                Utility.SvrSocket.Disconnect(false);
                Utility.SvrSocket.Close();
            }
            m_EP = new IPEndPoint(m_IP, m_port);
            Utility.SvrSocket = new Socket(m_EP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
            Utility.SvrSocket.BeginConnect(m_EP, ConnCallback, Utility.SvrSocket);
            ChkIPCtrlStat(true);
        }

        public void ConnCallback(IAsyncResult ar)
        {
            try
            {
                Socket sock = ar.AsyncState as Socket;
                if (sock != null)
                {
                    sock.EndConnect(ar);
                    // connect DB provider
                    Utility.DBProvider = DBFactory.InitProvider(m_DBType, Utility.SvrSocket.RemoteEndPoint as IPEndPoint, m_User, m_Pwd, null);
                    if (true == Utility.DBProvider.Connect())
                    {
                        m_bValid = true;
                        if (m_bPosTest == true)
                        {
                            MessageBox.Show("连接成功");
                            m_bPosTest = false;
                        }
                    }
                    //if (sock.Connected == true && (Utility.DBProvider.State == ConnectionState.Open || Utility.DBProvider.State == ConnectionState.Connecting))
                    //{
                    //    m_bValid = true;
                    //    if (m_bPosTest == true)
                    //    {
                    //        MessageBox.Show("连接成功");
                    //        m_bPosTest = false;
                    //    }
                    //}
                    else
                    {
                        MessageBox.Show(Utility.LastErrorMessage);
                    }
                }
            }
            catch (Exception exp)
            {
                Utility.LastErrorMessage = exp.Message;
                MessageBox.Show(Utility.LastErrorMessage);
                
            }
            finally
            {
                ChkIPCtrlStat(false);
                if (btnNext.InvokeRequired)
                {
                    btnNext.BeginInvoke((MethodInvoker)delegate
                    {
                        btnNext.Enabled = m_bValid;
                        if (m_bPosTest == false && m_bValid == true)
                            btnNext_Click(btnNext, EventArgs.Empty);
                    });
                }
                else
                {
                    btnNext.Enabled = m_bValid;
                    if (m_bPosTest == false && m_bPosTest == false)
                        btnNext_Click(btnNext, EventArgs.Empty);
                }
                
                    
            }
        }

        private void ChkIPCtrlStat(bool bRunning)
        {
            if (this.InvokeRequired == true)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    pbxLoad.Visible = bRunning;
                    lblTestConnetc.Visible = bRunning;
                    btnTestConnect.Enabled = !bRunning;
                    btnPrev.Enabled = !bRunning;
                    btnNext.Enabled = !bRunning;
                    cmbAddrList.Enabled = !bRunning;
                    cmbDBList.Enabled = !bRunning;
                    tbxAddrPort.Enabled = !bRunning;
                    tbxDBUser.Enabled = !bRunning;
                    tbxDBPwd.Enabled = !bRunning;
                });
            }
            else
            {
                pbxLoad.Visible = bRunning;
                lblTestConnetc.Visible = bRunning;
                btnTestConnect.Enabled = !bRunning;
                btnPrev.Enabled = !bRunning;
                btnNext.Enabled = !bRunning;
                cmbAddrList.Enabled = !bRunning;
                cmbDBList.Enabled = !bRunning;
                tbxAddrPort.Enabled = !bRunning;
                tbxDBUser.Enabled = !bRunning;
                tbxDBPwd.Enabled = !bRunning;
            }
        }

        private bool m_bPosTest = false;
        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            m_bPosTest = true;
            TestConnect();
        }

        private void IsValidIPAddress()
        {
            m_IP = null;
            m_bValid = false;

            string ipstring = this.cmbAddrList.Text.Trim();
            if (string.IsNullOrEmpty(ipstring) == true || (m_IP = Utility.VerifyIPAddress(ipstring)) == null)
            {
                MessageBox.Show(Utility.LastErrorMessage + "\r\n" + Settings.Default.InvalidIPAddressMsg);
                cmbAddrList.Focus();
                return;
            }
            return;
        }

        private void IsValidIPPort()
        {
            // check IP Port
            short port = Utility.VerifyIPPort(tbxAddrPort.Text.Trim());
            if (port == 0)
            {
                MessageBox.Show(Utility.LastErrorMessage + "\r\n" + Settings.Default.InvalidIPPortMsg);
                tbxAddrPort.Focus();
                return;
            }

            if (m_port == port)
            {
                return;
            }
            else
            {
                m_port = port;
            }
            // change
            m_bValid = false;
        }

        private void cmbAddrList_Leave(object sender, EventArgs e)
        {
            if (m_IP != null && string.Compare(cmbAddrList.SelectedText.ToString().Trim(), m_IP.ToString(), true) == 0)
                return;
            // change
            m_bValid = false;
            IsValidIPAddress();
        }

        private void tbxAddrPort_TextChanged(object sender, EventArgs e)
        {
            if (tbxAddrPort.Focused == false)
                IsValidIPPort();
        }

        private void tbxAddrPort_Validating(object sender, CancelEventArgs e)
        {
            IsValidIPPort();
        }

        private void cmbDBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strDBName = this.cmbDBList.Text;
            if (string.Compare(strDBName, "MYSQL", true) == 0)
            {
                tbxAddrPort.Text = "3306";
                m_DBType = DBType.MYSQL;
                tbxDBUser.Text = "root";
            }
            else if (string.Compare(strDBName, "MSSQL", true) == 0)
            {
                tbxAddrPort.Text = "1433";
                m_DBType = DBType.MSSQL;
                tbxDBUser.Text = "sa";
            }
            else if (string.Compare(strDBName, "ORACLE", true) == 0)
            {
                tbxAddrPort.Text = "2030";
                m_DBType = DBType.ORACLE;
                tbxDBUser.Text = "admin";
            }
        }

        private void tbxDBUser_Validating(object sender, CancelEventArgs e)
        {
            string user = tbxDBUser.Text.Trim();
            if (string.Compare(m_User, user, false) == 0)
                return;
            m_User = user;
            m_bValid = false;
        }

        private void tbxDBPwd_Validating(object sender, CancelEventArgs e)
        {
            string pwd = tbxDBPwd.Text.Trim();
            if (string.Compare(m_Pwd, pwd, false) == 0)
                return;
            m_Pwd = pwd;
            m_bValid = false;
        }

        private void tbxDBUser_TextChanged(object sender, EventArgs e)
        {
            if (tbxDBUser.Focused == false)
            {
                m_User = tbxDBUser.Text.Trim();
                m_bValid = false;
            }
        }

        private void tbxDBPwd_TextChanged(object sender, EventArgs e)
        {
            if (tbxDBPwd.Focused == false)
            {
                m_Pwd = tbxDBPwd.Text.Trim();
                m_bValid = false;
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (this.m_curPnl == LOGINPNLTYPE.AUTHENTICATION)
            {
                string username = this.cmbAuthUser.Text.Trim();
                if (string.IsNullOrEmpty(username) == true)
                {
                    MessageBox.Show("请输入用户");
                    this.cmbAuthUser.Focus();
                    return;
                }

                string password = this.tbxAuthPwd.Text.Trim();
                if (string.IsNullOrEmpty(password) == true)
                {
                    MessageBox.Show("请输入密码");
                    this.tbxAuthPwd.Focus();
                    return;
                }

                if (false == Utility.DBProvider.IsUser(Utility.DBProvider.DBName, username, password))
                {
                    MessageBox.Show("用户名或者密码错误");
                    return;
                }

                DialogResult = DialogResult.Yes;
                Utility.UpdateLoginHistory(cmbAuthUser.Text.Trim()); 
                this.Hide();
                this.Close();
            }
        }

        private void btnAddAB_Click(object sender, EventArgs e)
        {
            AddABForm newABFrm = new AddABForm();
            newABFrm.ShowDialog();
            if (!newABFrm.Good)
                return;
            
            bool bExist = false;
            foreach (DataRow row in m_DT.Rows)
            {
                if (string.Compare((string)row[1], newABFrm.NewABName, true) == 0)
                {
                    bExist = true;
                    break;
                }
                if (string.Compare((string)row[2], newABFrm.NewDBName, true) == 0)
                {
                    bExist = true;
                    break;
                }
            }

            if (bExist)
            {
                MessageBox.Show("账本名称或数据库名称已存在，请重新输入");
            }
            else
            {
                if (true == Utility.DBProvider.AddAB(newABFrm.NewABName, newABFrm.NewDBName))
                {
                    MessageBox.Show("账本创建成功");
                    // 重新获取账本
                    BuildLMTable();
                }
                else
                {
                    MessageBox.Show("账本创建失败:" + Utility.LastErrorMessage);
                }
            }
            newABFrm.Dispose();
        }

        private void btnDelAB_Click(object sender, EventArgs e)
        {
            // 删除账本
            if (this.dgvABList.CurrentCell.RowIndex < 0 ||
                this.dgvABList.CurrentCell.RowIndex >= this.dgvABList.Rows.Count)
            {
                MessageBox.Show("请选择需要删除的数据库");
                dgvABList.Focus();
                return;
            }

            // 确认是否拥有管理员权限
            if (Utility.IsAdminUser == false)
            {
                AdminConfirm frm = new AdminConfirm((string)dgvABList[2, dgvABList.CurrentCell.RowIndex].Value);
                
                DialogResult dret = frm.ShowDialog(this);
                if (DialogResult.OK != dret)
                {
                    if (DialogResult.Abort == dret)
                    {
                        MessageBox.Show("管理员登陆失败");
                    }
                    return;
                }
            }

            if (true == Utility.DBProvider.DelAB(   (int)dgvABList[0, dgvABList.CurrentCell.RowIndex].Value, 
                                                    (string)dgvABList[2, dgvABList.CurrentCell.RowIndex].Value))
            {
                MessageBox.Show("账本删除成功");
                // 重新获取账本
                BuildLMTable();
            }
            else
            {
                MessageBox.Show("账本删除失败:" + Utility.LastErrorMessage);
            }
        }

        private delegate void DBOps(IAsyncResult ar);

        private void ShowWaitForm(string msg)
        {
            m_WaitForm = new WaitForm() { Msg = msg };
            m_WaitForm.ShowDialog();
        }

        private void CloseWaitForm()
        {
            m_WaitForm.Hide();
            m_WaitForm.Dispose();
            m_WaitForm = null;
        }

        private List<string> m_delABs = new List<string>();
        private void dgvABList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                this.btnNext.Enabled = true;
            }
        }
    }
}
