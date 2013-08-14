using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using StoreManagement.Properties;

namespace StoreManagement.Forms
{
    public partial class GoodsInfoForm : Form
    {
        private Dictionary<int, string> m_BarCodeFmts = new Dictionary<int, string>();
        private DataTable m_dtAllColors = new DataTable();
        private DataTable m_dtAllSizes = new DataTable();
        private HashSet<int> m_hsSelectedColor = new HashSet<int>();
        private HashSet<int> m_hsSelectedSize = new HashSet<int>();

        private bool m_Modified = false;
        // test data
        private Random m_random = new Random();
        
        public GoodsInfoForm()
        {
            InitializeComponent();
            this.SuspendLayout();
            InitializeLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            // Test Data
            int testId = (int)(m_random.NextDouble() * 1000);
            this.tbxGoodsId.Text = string.Format("80{0}{1:D3}", DateTime.Now.ToString("yyMMdd"), testId);
            this.tbxGoodsFullName.Text = string.Format("Full-{0:D3}", testId);
            this.tbxGoodsAbbrName.Text = string.Format("Abbr-{0:D3}", testId);
            this.tbxGoodsUnit.Text = "件";
            this.tbxBarCode.Text = this.tbxGoodsId.Text;
            int price = 100;
            this.tbxGoodsPrice1.Text = price.ToString();
            price = 200;
            this.tbxGoodsPrice2.Text = price.ToString();
            price = 300;
            this.tbxGoodsPrice3.Text = price.ToString();

        }

        /// <summary>
        /// 初始化框架
        /// </summary>
        private void InitializeLayout()
        {
            this.pnlMain.SuspendLayout();

            InitializeNavigation();
            InitializeTabList();

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
        }

        /// <summary>
        /// 初始化底部按钮组
        /// </summary>
        private void InitializeNavigation()
        {
            this.pnlBottom.SuspendLayout();

            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Height = 40;

            this.btnPrev.Top = this.Top + 10;
            this.btnPrev.Left = this.Left + 10;
            this.btnPrev.Height = 20;
            this.btnPrev.Click += TabChange_ButtonClick;

            this.btnNext.Top = this.btnPrev.Top;
            this.btnNext.Left = this.btnPrev.Right + 10;
            this.btnNext.Height = this.btnPrev.Height;
            this.btnNext.Click += TabChange_ButtonClick;

            this.btnOK.Top = this.btnNext.Top;
            this.btnOK.Left = this.btnNext.Right + 10;
            this.btnOK.Height = this.btnNext.Height;

            this.btnCancel.Top = this.btnOK.Top;
            this.btnCancel.Left = this.btnOK.Right + 10;
            this.btnCancel.Height = this.btnOK.Height;
            this.btnCancel.Click += new EventHandler(btnCancel_Click);

            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            if (m_Modified == true)
            {
                if (DialogResult.OK == MessageBox.Show(Settings.Default.SaveModifyHint, Settings.Default.InformationTitle, MessageBoxButtons.OKCancel))
                {
                    return;
                }
            }
            this.Hide();
            this.Dispose();
        }

        /// <summary>
        /// 初始化选项表
        /// </summary>
        private void InitializeTabList()
        {
            this.tclMain.SuspendLayout();

            this.tclMain.Dock = DockStyle.Fill;

            this.tpgColor.Parent = null;    // 隐藏颜色选项卡
            this.tpgSzie.Parent = null;     // 隐藏尺寸选项卡
            InitializeBasicInfoTag();

            this.tclMain.ResumeLayout(false);
            this.tclMain.PerformLayout();
        }

        private void InitializeBasicInfoTag()
        {
            this.tpgBasic.SuspendLayout();
            

            this.gpbBasciInfo.Top = 10;
            this.gpbBasciInfo.Left = 10;
            this.gpbBasciInfo.Width = this.tpgBasic.Width - 242;
            this.gpbBasciInfo.Height = this.tpgBasic.Height - 5;
            this.gpbBasciInfo.Text = Settings.Default.GoodsInfoBasicInfo;

            InitializeBasicInfoGroup();


            this.gpbPicture.Top = this.gpbBasciInfo.Top;
            this.gpbPicture.Left = this.gpbBasciInfo.Right + 10;
            this.gpbPicture.Width = 230;
            this.gpbPicture.Height = this.gpbBasciInfo.Height;
            this.gpbPicture.Text = Settings.Default.GoodsInfoPicture;

            InitializePictureGroup();

            this.tpgBasic.ResumeLayout(false);
            this.tpgBasic.PerformLayout();
        }

        private void InitializeBasicInfoGroup()
        {
            this.gpbBasciInfo.SuspendLayout();

            this.lblGoodsId.Text = Settings.Default.GoodsInfoGoodsId;
            this.lblGoodsId.Top = 20;
            this.lblGoodsId.Left = 10;

            this.tbxGoodsId.Top = this.lblGoodsId.Top;
            this.tbxGoodsId.Left = this.gpbBasciInfo.Width / 5;
            this.tbxGoodsId.Width = 280;

            this.lblGoodsFullName.Top = this.tbxGoodsId.Bottom + 10;
            this.lblGoodsFullName.Left = this.lblGoodsId.Left;
            this.lblGoodsFullName.Text = Settings.Default.GoodsInfoGoodsFullName;

            this.tbxGoodsFullName.Top = this.lblGoodsFullName.Top;
            this.tbxGoodsFullName.Left = this.tbxGoodsId.Left;
            this.tbxGoodsFullName.Width = tbxGoodsId.Width;

            this.lblGoodsAbbrName.Top = this.tbxGoodsFullName.Bottom + 10;
            this.lblGoodsAbbrName.Left = this.lblGoodsFullName.Left;
            this.lblGoodsAbbrName.Text = Settings.Default.GoodsInfoGoodsAbbrName;

            this.tbxGoodsAbbrName.Top = this.lblGoodsAbbrName.Top;
            this.tbxGoodsAbbrName.Left = this.tbxGoodsFullName.Left;
            this.tbxGoodsAbbrName.Width = 180;

            this.lblGoodsUnit.Top = this.tbxGoodsAbbrName.Top;
            this.lblGoodsUnit.Left = this.tbxGoodsAbbrName.Right + 5;
            this.lblGoodsUnit.Text = Settings.Default.GoodsInfoUnit;

            this.tbxGoodsUnit.Top = this.lblGoodsUnit.Top;
            this.tbxGoodsUnit.Left = this.lblGoodsUnit.Right + 5;
            this.tbxGoodsUnit.Width = this.tbxGoodsFullName.Right - this.tbxGoodsUnit.Left;

            this.lblBarCodeFormat.Top = this.tbxGoodsUnit.Bottom + 10;
            this.lblBarCodeFormat.Left = this.lblGoodsAbbrName.Left;
            this.lblBarCodeFormat.Text = Settings.Default.GoodsInfoBarCodeFormat;

            this.cmbBarCodeFormat.Top = this.lblBarCodeFormat.Top;
            this.cmbBarCodeFormat.Left = this.tbxGoodsAbbrName.Left;
            this.cmbBarCodeFormat.Width = 120;
            this.cmbBarCodeFormat.Items.Clear();
            this.cmbBarCodeFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBarCodeFormat.AutoCompleteMode = AutoCompleteMode.None;
            // 获取条形码格式
            if (Utility.DBProvider.GetBarCodeFormat(Utility.DBProvider.DBName, m_BarCodeFmts) == false)
            {
                MessageBox.Show(string.Format("{0}:{1}", Settings.Default.GetBarCodeFormatError, Utility.LastErrorMessage));
            }
            else
            {
                foreach (var elem in m_BarCodeFmts)
                {
                    this.cmbBarCodeFormat.Items.Add(elem.Value);
                }
            }

            this.lblBarCode.Top = this.lblBarCodeFormat.Top;
            this.lblBarCode.Left = this.cmbBarCodeFormat.Right + 5;
            this.lblBarCode.Text = Settings.Default.GoodsInfoBarCode;

            this.tbxBarCode.Top = this.lblBarCode.Top;
            this.tbxBarCode.Left = this.lblBarCode.Right + 5;
            this.tbxBarCode.Width = this.tbxGoodsUnit.Right - this.tbxBarCode.Left;

            this.lblSeason.Top = this.tbxBarCode.Bottom + 10;
            this.lblSeason.Left = this.lblBarCodeFormat.Left;
            this.lblSeason.Text = Settings.Default.GoodsInfoSeason;

            this.cmbSeason.Top = this.lblSeason.Top;
            this.cmbSeason.Left = this.lblSeason.Right + 5;
            this.cmbSeason.Width = 70;

            this.lblBrand.Top = this.lblSeason.Top;
            this.lblBrand.Left = this.cmbSeason.Right + 5;
            this.lblBrand.Text = Settings.Default.GoodsInfoBrand;

            this.cmbBrand.Top = this.lblBrand.Top;
            this.cmbBrand.Left = this.lblBrand.Right + 5;
            this.cmbBrand.Width = 100;

            this.lblStuff.Top = this.cmbBrand.Top;
            this.lblStuff.Left = this.cmbBrand.Right + 5;
            this.lblStuff.Text = Settings.Default.GoodsInfoStuff;

            this.cmbStuff.Top = this.lblStuff.Top;
            this.cmbStuff.Left = this.lblStuff.Right + 5;
            this.cmbStuff.Width = this.tbxGoodsUnit.Right - this.cmbStuff.Left;

            this.lblExpired.Top = this.cmbStuff.Bottom + 10;
            this.lblExpired.Left = this.lblSeason.Left;
            this.lblExpired.Text = Settings.Default.GoodsInfoExpired;

            this.dptExpired.Top = this.lblExpired.Top;
            this.dptExpired.Left = this.tbxGoodsFullName.Left;
            this.dptExpired.Width = 200;
            this.dptExpired.Value = this.dptExpired.Value.AddYears(2);

            this.lblGoodsPrice1.Top = this.dptExpired.Bottom + 10;
            this.lblGoodsPrice1.Left = this.lblExpired.Left;
            this.lblGoodsPrice1.Text = Settings.Default.GoodsInfoPrice1;

            this.tbxGoodsPrice1.Top = this.lblGoodsPrice1.Top;
            this.tbxGoodsPrice1.Left = this.lblGoodsPrice1.Right + 5;
            this.tbxGoodsPrice1.Width = 80;

            this.lblGoodsPrice2.Top = this.tbxGoodsPrice1.Top;
            this.lblGoodsPrice2.Left = this.tbxGoodsPrice1.Right + 5;
            this.lblGoodsPrice2.Text = Settings.Default.GoodsInfoPrice2;

            this.tbxGoodsPrice2.Top = this.lblGoodsPrice2.Top;
            this.tbxGoodsPrice2.Left = this.lblGoodsPrice2.Right + 5;
            this.tbxGoodsPrice2.Width = 80;

            this.lblGoodsPrice3.Top = this.tbxGoodsPrice2.Bottom + 5;
            this.lblGoodsPrice3.Left = this.lblGoodsPrice1.Left;
            this.lblGoodsPrice3.Text = Settings.Default.GoodsInfoPrice3;

            this.tbxGoodsPrice3.Top = this.lblGoodsPrice3.Top;
            this.tbxGoodsPrice3.Left = this.lblGoodsPrice3.Right + 5;
            this.tbxGoodsPrice3.Width = 80;

            this.gpbBasciInfo.ResumeLayout(false);
            this.gpbBasciInfo.PerformLayout();

            // 获取所有颜色
            if (Utility.DBProvider.GetAllColor(Utility.DBProvider.DBName, m_dtAllColors) == false)
            {
                MessageBox.Show(string.Format("{0}:{1}", Settings.Default.GetAllColorError, Utility.LastErrorMessage));
            }
            else 
            {
                Color.DataSource = m_dtAllColors;
                Color.DisplayMember = "Value";
                Color.ValueMember = "Key";
            }
        }
        

        private void InitializePictureGroup()
        {
            this.gpbPicture.SuspendLayout();

            this.pbxPicture.Top = 20;
            this.pbxPicture.Left = 1;
            this.pbxPicture.Width = 220;
            this.pbxPicture.Height = 220;
            this.pbxPicture.SizeMode = PictureBoxSizeMode.AutoSize;

            string unspecified = string.Format("./{0}/{1}", Settings.Default.PictureFolder, Settings.Default.UnspecifiedPicture);
            if (File.Exists(unspecified) == true)
                this.pbxPicture.Image = Image.FromFile(unspecified);

            this.pnlPicBottom.Top = this.pbxPicture.Bottom + 5;
            this.pnlPicBottom.Left = this.pbxPicture.Left;
            this.pnlPicBottom.Width = this.pbxPicture.Width;
            this.pnlPicBottom.Height = this.tpgBasic.Bottom - this.pnlPicBottom.Top;

            InitializePictureBottom();

            this.gpbPicture.ResumeLayout(false);
            this.gpbPicture.PerformLayout();
        }

        private void InitializePictureBottom()
        {
            this.pnlPicBottom.SuspendLayout();


            this.btnPicPrev.Image = Image.FromFile("./Pics/left.gif");
            this.btnPicPrev.Width = 25;
            this.btnPicPrev.Height = 25;
            this.btnPicPrev.Top = 0;
            this.btnPicPrev.Left = 10;
            this.btnPicPrev.Enabled = false;

            this.btnPicNext.Image = Image.FromFile("./Pics/right.gif");
            this.btnPicNext.Width = 25;
            this.btnPicNext.Height = 25;
            this.btnPicNext.Top = this.btnPicPrev.Top;
            this.btnPicNext.Left = this.btnPicPrev.Right + 10;
            this.btnPicNext.Enabled = false;

            this.btnPicImport.Image = Image.FromFile("./Pics/Add.gif");
            this.btnPicImport.Top = this.btnPicNext.Top;
            this.btnPicImport.Left = this.btnPicNext.Right + 10;
            this.btnPicImport.Width = 25;
            this.btnPicImport.Height = 25;

            this.btnPicRemove.Image = Image.FromFile("./Pics/Remove.gif");
            this.btnPicRemove.Top = this.btnPicImport.Top;
            this.btnPicRemove.Left = this.btnPicImport.Right + 10;
            this.btnPicRemove.Width = 25;
            this.btnPicRemove.Height = 25;
            

            this.pnlPicBottom.ResumeLayout(false);
            this.pnlPicBottom.PerformLayout();
        }


        /// <summary>
        /// 按钮上下页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabChange_ButtonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == btnPrev)
                if (tclMain.SelectedIndex < tclMain.Controls.Count && tclMain.SelectedIndex > 0)
                    tclMain.SelectedIndex--;

            if (btn == btnNext)
                if (tclMain.SelectedIndex < tclMain.Controls.Count - 1)
                    tclMain.SelectedIndex++;
        }

        /// <summary>
        /// 选项页切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tclMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tclMain.SelectedIndex == 0)
            {
                btnPrev.Enabled = false;
                btnNext.Enabled = true;
            }
            else if (tclMain.SelectedIndex == tclMain.Controls.Count - 1)
            {
                btnNext.Enabled = false;
                btnPrev.Enabled = true;
            }
            else
            {
                btnNext.Enabled = true;
                btnPrev.Enabled = true;
            }
        }

        /// <summary>
        /// 校验GoodsId，只能是数字，并且需要小于64位表示的最大数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxGoodsId_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnSizeDel_Click(object sender, EventArgs e)
        {

        }

        private void btnSizeAllAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSizeAllDel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 修改条形码格式，将会导致颜色选项页以及尺寸选项页的隐藏或者显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBarCodeFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbBarCodeFormat.SelectedIndex >= 0 &&
                this.cmbBarCodeFormat.SelectedIndex < this.cmbBarCodeFormat.Items.Count)
            {
                string value = this.cmbBarCodeFormat.Items[this.cmbBarCodeFormat.SelectedIndex].ToString();
                if (value.Contains(Settings.Default.Color) == true)
                    this.tpgColor.Parent = this.tclMain;
                else
                    this.tpgColor.Parent = null;

                if (value.Contains(Settings.Default.Size) == true)
                    this.tpgSzie.Parent = this.tclMain;
                else
                    this.tpgSzie.Parent = null;
            }
        }
    }
}
