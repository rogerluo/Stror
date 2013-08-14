using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StoreManagement.Properties;

namespace StoreManagement.Forms
{
    public partial class SysChangeAB : Form
    {
        private DataTable m_dt;
        public SysChangeAB()
        {
            InitializeComponent();
            this.SuspendLayout();
            InitializeLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// 初始化框架
        /// </summary>
        private void InitializeLayout()
        {
            this.pnlMain.SuspendLayout();

            this.lblDesc.Top = this.Top + 20;
            this.lblDesc.Left = this.Left + 20;
            this.lblDesc.Text = Settings.Default.SysChangeABDesc;

            this.dgvABList.Top = this.lblDesc.Bottom + 5;
            this.dgvABList.Left = this.lblDesc.Left;
            this.dgvABList.Width = 300;
            this.dgvABList.Height = 100;

            this.lblUsername.Top = this.dgvABList.Bottom + 20;
            this.lblUsername.Left = this.dgvABList.Left;
            this.lblUsername.Text = Settings.Default.UsernameInput;

            this.tbxUsername.Top = this.lblUsername.Top;
            this.tbxUsername.Left = this.Width / 3;
            this.tbxUsername.Width = 150;

            this.lblPassword.Top = this.lblUsername.Bottom + 10;
            this.lblPassword.Left = this.lblUsername.Left;
            this.lblPassword.Text = Settings.Default.PasswordInput;

            this.tbxPassword.Top = this.lblPassword.Top;
            this.tbxPassword.Left = this.tbxUsername.Left;
            this.tbxPassword.Width = 150;

            this.btnOK.Top = this.lblPassword.Bottom + 20;
            this.btnOK.Left = (this.Width - 160) / 2;
            this.btnOK.Width = 75;

            this.btnCancel.Top = this.btnOK.Top;
            this.btnCancel.Left = this.btnOK.Right + 10;
            this.btnCancel.Width = 75;

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvABList.CurrentCell == null || dgvABList.CurrentCell.RowIndex == -1 ||
                dgvABList.CurrentCell.RowIndex >= dgvABList.Rows.Count)
            {
                MessageBox.Show(Settings.Default.ABInputHint);
                dgvABList.Focus();
                return;
            }

            string username = tbxUsername.Text.Trim();
            if (string.IsNullOrEmpty(username) == true)
            {
                MessageBox.Show(Settings.Default.UsernameInputHint);
                tbxUsername.Focus();
                return;
            }

            string password = tbxPassword.Text.Trim();
            if (string.IsNullOrEmpty(password) == true)
            {
                MessageBox.Show(Settings.Default.PasswordInputHint);
                tbxPassword.Focus();
                return;
            }

            string newABName = (string)dgvABList[1, dgvABList.CurrentCell.RowIndex].Value;
            string newDBName = (string)dgvABList[2, dgvABList.CurrentCell.RowIndex].Value;
            if (string.Compare(Utility.DBProvider.ABName, newABName) == 0 ||
                string.Compare(Utility.DBProvider.DBName, newDBName) == 0)
            {
                MessageBox.Show(Settings.Default.SysChangeABSameDesc);
                dgvABList.Focus();
                return;
            }

            if (false == Utility.DBProvider.IsUser(newDBName, username, password))
            {
                MessageBox.Show(Settings.Default.SysChangeABError);
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Utility.DBProvider.ABName = newABName;
                Utility.DBProvider.DBName = newDBName;
                this.Hide();
                this.Close();
            }
        }

        /// <summary>
        /// 获取账本列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SysChangeAB_Shown(object sender, EventArgs e)
        {
            m_dt = new DataTable("ABList");
            if (false == Utility.DBProvider.GetAB(m_dt))
            {
                MessageBox.Show(Settings.Default.SysChangeABInitError);
                this.Hide();
                this.Close();
                return;
            }
            else
            {
                this.dgvABList.DataSource = m_dt;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            return;
        }
    }
}
