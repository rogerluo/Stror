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
    public partial class SysChangeUserForm : Form
    {
        public SysChangeUserForm()
        {
            InitializeComponent();
            this.SuspendLayout();
            InitializeLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// 初始化控件布局
        /// </summary>
        private void InitializeLayout()
        {
            this.pnlMain.SuspendLayout();

            this.lblDesc.Text = Settings.Default.SysChangeUserDesc;
            this.lblDesc.Top = this.Top + 20;
            this.lblDesc.Left = this.Left + 20;

            this.lblUsername.Top = this.lblDesc.Bottom + 20;
            this.lblUsername.Left = this.lblDesc.Left;
            this.lblUsername.Text = Settings.Default.UsernameInput;

            this.tbxUsername.Top = this.lblUsername.Top;
            this.tbxUsername.Left = this.Width / 3;
            this.tbxUsername.Width = 150;

            this.lblPassword.Top = this.lblUsername.Bottom + 20;
            this.lblPassword.Left = this.lblUsername.Left;
            this.lblPassword.Text = Settings.Default.PasswordInput;

            this.tbxPassword.Top = this.lblPassword.Top;
            this.tbxPassword.Left = this.tbxUsername.Left;
            this.tbxPassword.Width = 150;

            this.btnChangeUser.Top = this.tbxPassword.Bottom + 20;
            this.btnChangeUser.Left = (this.Width - 160) / 2;
            this.btnChangeUser.Width = 75;

            this.btnCancel.Top = this.btnChangeUser.Top;
            this.btnCancel.Left = this.btnChangeUser.Right + 10;
            this.btnCancel.Width = 75;

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
        }

        private void btnChangeUser_Click(object sender, EventArgs e)
        {
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
            if (string.Compare(LoginUser.CurrentUser.UserName, username) == 0)
            {
                MessageBox.Show("已经是当前用户");
                return;
            }


            if (false == Utility.DBProvider.IsUser(Utility.DBProvider.DBName, username, password))
            {
                MessageBox.Show(Utility.LastErrorMessage);
                return;
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Hide();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
            this.Close();
        }
    }
}
