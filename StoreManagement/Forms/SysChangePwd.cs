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
    public partial class SysChangePwd : Form
    {
        public SysChangePwd()
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

            this.lblOldPassword.Text = Settings.Default.SysChangePwdOldInput;
            this.lblOldPassword.Top = this.Top + 20;
            this.lblOldPassword.Left = this.Left + 20;

            this.tbxOldPassword.Top = this.lblOldPassword.Top;
            this.tbxOldPassword.Left = this.Width / 3;
            this.tbxOldPassword.Width = 150;

            this.lblNewPassword.Text = Settings.Default.SysChangePwdNewInput;
            this.lblNewPassword.Top = this.lblOldPassword.Bottom + 10;
            this.lblNewPassword.Left = this.lblOldPassword.Left;

            this.tbxNewPassword.Top = this.lblNewPassword.Top;
            this.tbxNewPassword.Left = this.tbxOldPassword.Left;
            this.tbxNewPassword.Width = 150;

            this.lblNewPassword2.Text = Settings.Default.SysChangePwdNewInput2;
            this.lblNewPassword2.Top = this.lblNewPassword.Bottom + 10;
            this.lblNewPassword2.Left = this.lblNewPassword.Left;

            this.tbxNewPassword2.Top = this.lblNewPassword2.Top;
            this.tbxNewPassword2.Left = this.tbxNewPassword.Left;
            this.tbxNewPassword2.Width = 150;

            this.btnOK.Top = this.lblNewPassword2.Bottom + 20;
            this.btnOK.Left = (this.Width - 160) / 2;
            this.btnOK.Width = 75;

            this.btnCancel.Top = this.btnOK.Top;
            this.btnCancel.Left = this.btnOK.Right + 10;
            this.btnCancel.Width = 75;

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
        }

        /// <summary>
        /// 确认新密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            string oldPassword = tbxOldPassword.Text.Trim();
            if (string.IsNullOrEmpty(oldPassword) == true)
            {
                MessageBox.Show(Settings.Default.SysChangePwdOldInputHint);
                this.tbxOldPassword.Focus();
                return;
            }

            string newPassword = tbxNewPassword.Text.Trim();
            if (string.IsNullOrEmpty(newPassword) == true)
            {
                MessageBox.Show(Settings.Default.SysChangePwdNewInputHint);
                this.tbxNewPassword.Focus();
                return;
            }

            string newPassword2 = tbxNewPassword2.Text.Trim();
            if (string.IsNullOrEmpty(newPassword2) == true)
            {
                MessageBox.Show(Settings.Default.SysChangePwdNewInput2Hint);
                this.tbxNewPassword2.Focus();
                return;
            }

            if (string.Compare(LoginUser.CurrentUser.UserPwd, oldPassword) != 0)
            {
                MessageBox.Show(Settings.Default.SysChangePwdIsNotValid);
                this.tbxOldPassword.Focus();
                return;
            }

            if (string.Compare(newPassword, newPassword2) != 0)
            {
                MessageBox.Show(Settings.Default.SysChangePwdNotMatch);
                this.tbxNewPassword2.Focus();
                return;
            }

            if (true == Utility.DBProvider.ChangePwd(Utility.DBProvider.DBName, LoginUser.CurrentUser.UserID, newPassword))
            {
                DialogResult = DialogResult.OK;
                LoginUser.CurrentUser.UserPwd = newPassword;
                this.Hide();
                this.Close();
            }
            else
            {
                MessageBox.Show(Settings.Default.SysChangePwdError);
                return;
            }
        }


    }
}
