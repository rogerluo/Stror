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
    public partial class FolderSettingForm : Form
    {
        public string FolderName { get; set; }
        public FolderSettingForm(string name)
        {
            InitializeComponent();
            this.SuspendLayout();
            this.tbxName.Text = name;
            InitializeLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void FolderSettingForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeLayout()
        {
            this.pnlMain.SuspendLayout();

            if (string.IsNullOrEmpty(this.tbxName.Text))
                this.lblDesc.Text = Settings.Default.FolderSettingCreateDesc;
            else
                this.lblDesc.Text = Settings.Default.FolderSettingModifyDesc;
            //this.lblDesc.Top = this.pnlMain.Top + 10;
            //this.lblDesc.Left = this.pnlMain.Left + 10;

            //this.lblName.Top = this.lblDesc.Bottom + 5;
            this.lblName.Left = this.lblDesc.Left;
            this.lblName.Text = Settings.Default.FolderSettingName;
            this.Text = "商品分类";
            //this.tbxName.Top = this.lblName.Top;
            //this.tbxName.Left = this.lblName.Right + 5;

            //this.btnOK.Top = this.tbxName.Bottom + 5;
            //this.btnOK.Left = (this.pnlMain.Width - 160)/2;
            //this.btnOK.Width = 80;

            //this.btnCancel.Top = this.btnOK.Top;
            //this.btnCancel.Left = this.btnOK.Right;
            //this.btnCancel.Width = 80;

            this.pnlMain.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxName.Text))
            {
                MessageBox.Show(Settings.Default.FolderSettingEmptyName);
                this.tbxName.Focus();
                return;
            }
            FolderName = tbxName.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Hide();
            //this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
            this.Dispose();
        }

        private void FolderSettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
