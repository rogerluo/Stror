using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using StoreManagement.Properties;

namespace StoreManagement
{
    public partial class AddABForm : Form
    {
        public string NewABName { get; set; }
        public string NewDBName { get; set; }
        public bool Good { get; set; }

        public AddABForm()
        {
            InitializeComponent();
        }

        private void InitPanel()
        {
            this.lblABName.Text = "账本名称";
            this.lblABName.Top = 10;
            this.lblABName.Left = 10;
            this.lblABName.Width = 100;
            this.lblABName.Height = 30;

            this.tbxABName.Top = this.lblABName.Top;
            this.tbxABName.Left = 105;
            this.tbxABName.Width = 100;
            this.tbxABName.Height = 30;

            this.lblDBName.Text = "数据库名称";
            this.lblDBName.Top = this.tbxABName.Bottom + 5;
            this.lblDBName.Left = this.lblABName.Left;
            this.lblDBName.Width = 100;
            this.lblDBName.Height = 20;

            this.tbxDBName.Top = this.lblDBName.Top;
            this.tbxDBName.Left = this.tbxABName.Left;
            this.tbxDBName.Width = 100;
            this.tbxDBName.Height = 20;

            this.btnYes.Text = "确定";
            this.btnYes.Top = this.tbxABName.Top;
            this.btnYes.Left = this.tbxABName.Right + 10;
            this.btnYes.Width = 75;
            this.btnYes.Height = 20;

            this.btnNo.Text = "取消";
            this.btnNo.Top = this.btnYes.Bottom + 5;
            this.btnNo.Left = this.btnYes.Left;
            this.btnNo.Width = 75;
            this.btnNo.Height = 20;

            this.lblDesc.Text = "注意：数据库名称只能是英文字符";
            this.lblDesc.Top = this.tbxDBName.Bottom + 10;
            this.lblDesc.Left = this.lblDBName.Left;
            this.lblDesc.Width = 200;
            this.lblDesc.Height = 20;
        }

        private void AddAB_Load(object sender, EventArgs e)
        {
            InitPanel();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            string newABName = tbxABName.Text.Trim();
            if (string.IsNullOrEmpty(newABName) == true)
            {
                MessageBox.Show(Settings.Default.InvalidABNameMessage, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NewABName = newABName;

            string newDBName = tbxDBName.Text.Trim();
            if (string.IsNullOrEmpty(newDBName) == true || Regex.IsMatch(newDBName, "^[a-z|A-Z|0-9][a-z|A-Z|0-9|_]*$") == false)
            {
                MessageBox.Show(Settings.Default.InvalidDBNameMessage, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NewDBName = newDBName;
            Good = true;
            
            this.Hide();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Good = false;
            this.Hide();
        }
    }
}
