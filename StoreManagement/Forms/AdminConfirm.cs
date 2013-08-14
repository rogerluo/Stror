using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StoreManagement.Properties;

namespace StoreManagement
{
    public partial class AdminConfirm : Form
    {
        private string DBName = null;
        public AdminConfirm(string strDBName)
        {
            DBName = strDBName;
            InitializeComponent();
            this.SuspendLayout();
            InitLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitLayout()
        {
            this.pnlMain.SuspendLayout();
            this.pnlMain.Dock = DockStyle.Fill;

            this.lblDesc.Top = this.Top + 20;
            this.lblDesc.Left = this.Left + 20;
            this.lblDesc.Text = Settings.Default.AdminConfirmDescription;

            this.lblUserName.Top = this.lblDesc.Bottom + 20;
            this.lblUserName.Left = this.lblDesc.Left;
            this.lblUserName.Text = Settings.Default.UsernameInput;
            this.lblUserName.Width = 100;

            this.tbxUsername.Top = this.lblUserName.Top;
            this.tbxUsername.Left = this.Width / 3;
            this.tbxUsername.Width = 150;
            this.tbxUsername.Enabled = false;
            this.tbxUsername.Text = "管理员";

            this.lblPassword.Top = this.lblUserName.Bottom + 20;
            this.lblPassword.Left = this.lblDesc.Left;
            this.lblPassword.Text = Settings.Default.PasswordInput;
            this.lblPassword.Width = 100;

            this.tbxPassword.Top = this.lblPassword.Top;
            this.tbxPassword.Left = this.tbxUsername.Left;
            this.tbxPassword.Width = 150;

            this.ckbKeep.Top = this.lblPassword.Bottom + 20;
            this.ckbKeep.Left = this.lblPassword.Left;
            this.ckbKeep.Text = Settings.Default.KeepHistoryInput;
            this.ckbKeep.Checked = false;

            this.btnOk.Top = this.ckbKeep.Top;
            this.btnOk.Left = this.ckbKeep.Right + 10;
            this.btnCancel.Top = this.btnOk.Top;
            this.btnCancel.Left = this.btnOk.Right + 10;

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text.Trim();
           
            string password = tbxPassword.Text.Trim();
            if (string.IsNullOrEmpty(password) == true)
            {
                MessageBox.Show("请输入密码");
                tbxPassword.Focus();
                return;
            }
            if (false == Utility.DBProvider.IsUser(DBName, "管理员", password))
            {
                MessageBox.Show(Utility.LastErrorMessage);
                DialogResult = DialogResult.Abort;
                this.tbxUsername.ResetText();
                this.tbxPassword.ResetText();
                this.tbxPassword.Focus();
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
