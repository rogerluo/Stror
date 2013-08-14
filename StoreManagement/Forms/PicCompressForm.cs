using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using StoreManagement;
using StoreManagement.Properties;

namespace StoreManagement
{
    public partial class PicCompressForm : Form
    {
        public string PICDIR { get; set; }
        public string PICTYPE { get; set; }
        public string PICFULLNAME { get; set; }
        public string ORIPIC { get; set; }
        public string COMPPIC { get; set; }
        public string COMPPICFULLNAME { get; set; }
        public bool Loaded { get; set; }
        public bool HasComp { get; set; }

        private Bitmap m_loadImage = null;
        public Bitmap LoadImage
        {
            get
            {
                if (m_loadImage == null)
                {
                    if (File.Exists(Utility.RunningPath + Settings.Default.ThrobberImage))
                        m_loadImage = new Bitmap(Utility.RunningPath + Settings.Default.ThrobberImage);
                }
                return m_loadImage;
            }
        }

        public PicCompressForm()
        {
            InitializeComponent();
            // 自定义初始化
            this.SuspendLayout();
            InitCtrlPnl();
            InitPicPnl();
            InitStatusBar();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitCtrlPnl()
        {
            this.pnlCtrl.SuspendLayout();
            // 初始化控制面板
            this.pnlCtrl.Dock = DockStyle.Left;
            this.pnlCtrl.Width = 150;

            this.btnOpen.Text = "打开";
            this.btnOpen.Top = 5;
            this.btnOpen.Left = 5;
            this.btnOpen.Width = (this.pnlCtrl.Width - 15) / 2;
            this.btnOpen.Height = 20;

            this.btnComp.Text = "压缩";
            this.btnComp.Top = this.btnOpen.Top;
            this.btnComp.Left = this.btnOpen.Right + 2;
            this.btnComp.Width = this.btnOpen.Width;
            this.btnComp.Height = this.btnOpen.Height;
            this.btnComp.Enabled = false;

            this.lblCompRadio.Top = this.btnOpen.Bottom + 10;
            this.lblCompRadio.Left = this.btnOpen.Left;
            this.lblCompRadio.Width = 100;
            this.lblCompRadio.Height = 20;

            this.tbrCompRadio.Top = this.lblCompRadio.Bottom + 5;
            this.tbrCompRadio.Left = this.lblCompRadio.Left;
            this.tbrCompRadio.Width = this.pnlCtrl.Width - 15;
            this.tbrCompRadio.Height = 40;

            this.lblBeforeComp.Top = this.tbrCompRadio.Bottom + 10;
            this.lblBeforeComp.Left = this.tbrCompRadio.Left;
            this.lblBeforeComp.Width = this.pnlCtrl.Width - 20;
            this.lblBeforeComp.Height = 20;

            this.lblAfterComp.Top = this.lblBeforeComp.Bottom + 5;
            this.lblAfterComp.Left = this.lblBeforeComp.Left;
            this.lblAfterComp.Width = this.lblBeforeComp.Width;
            this.lblAfterComp.Height = 20;

            this.btnBeforeComp.Text = "压缩前";
            this.btnBeforeComp.Top = this.lblAfterComp.Bottom + 10;
            this.btnBeforeComp.Left = this.btnOpen.Left;
            this.btnBeforeComp.Width = (this.pnlCtrl.Width - 15) / 2;
            this.btnBeforeComp.Height = 20;

            this.btnAfterComp.Text = "压缩后";
            this.btnAfterComp.Top = this.btnBeforeComp.Top;
            this.btnAfterComp.Left = this.btnComp.Left;
            this.btnAfterComp.Width = this.btnBeforeComp.Width;
            this.btnAfterComp.Height = this.btnBeforeComp.Height;

            this.lblWidth.Text = "宽";
            this.lblWidth.Top = this.btnAfterComp.Bottom + 10;
            this.lblWidth.Left = this.btnBeforeComp.Left;
            this.lblWidth.Width = 30;

            this.tbxWidth.Left = this.lblWidth.Right;
            this.tbxWidth.Top = this.lblWidth.Top;
            this.tbxWidth.Width = 50;

            this.lblHeight.Text = "高";
            this.lblHeight.Top = this.tbxWidth.Bottom + 10;
            this.lblHeight.Left = this.lblWidth.Left;
            this.lblHeight.Width = 30;

            this.tbxHeight.Left = this.lblHeight.Right;
            this.tbxHeight.Top = this.lblHeight.Top;
            this.tbxHeight.Width = 50;

            this.cbxRestrain.Top = this.tbxHeight.Bottom + 5;
            this.cbxRestrain.Left = this.lblHeight.Left;
            this.cbxRestrain.Text = "等比例缩放";
            this.cbxRestrain.Checked = true;

            //ofdOpen.InitialDirectory = System.Environment.CurrentDirectory;
            ofdOpen.Filter =    "支持的文件类型|*.jpg;*.jpeg;*.gif;*.png;*.bmp" +
                                "|JPG, JPEG格式|*.jpg;*.jpeg;" + 
                                "|GIF格式|*.gif" +
                                "|PNG格式|*.png" +
                                "|BMP|*.bmp";

            SetCtrlPnl(false);

            this.pnlCtrl.ResumeLayout(false);
            this.pnlCtrl.PerformLayout();
        }

        private void InitPicPnl()
        {
            this.pnlPic.SuspendLayout();
            // 初始化图片面板
            this.pnlPic.Dock = DockStyle.Fill;

            this.pbxPic.Dock = DockStyle.Fill;
            this.pbxPic.SizeMode = PictureBoxSizeMode.Zoom;

            this.pnlPic.ResumeLayout(false);
            this.pnlPic.PerformLayout();
        }

        private void InitStatusBar()
        {
            this.stsStatus.SuspendLayout();
            
            this.stsStatus.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            //this.stsStatus.Dock = DockStyle.Bottom;

            ToolStripLabel tsslblLoading = new ToolStripLabel();
            tsslblLoading.Text = "努力加载中...";
            tsslblLoading.Name = "tsslblLoading";
            tsslblLoading.Visible = false;

            ToolStripProgressBar tsspgbLoading = new ToolStripProgressBar();
            tsspgbLoading.Name = "tsspgbLoading";
            tsspgbLoading.Value = 0;
            tsspgbLoading.Width = 100;
            tsspgbLoading.ImageIndex = 0;
            tsspgbLoading.Visible = false;

            ToolStripLabel tsslblLocation = new ToolStripLabel();
            tsslblLocation.Text = "tsslblLocation";
            tsslblLocation.Name = "tsslblLocation";
            tsslblLocation.Visible = false;

            ToolStripSeparator sp1 = new ToolStripSeparator();
            sp1.Name = "sp1";
            ToolStripSeparator sp2 = new ToolStripSeparator();

            ToolStripLabel tsslblResolution = new ToolStripLabel();
            tsslblResolution.Text = "tsslblResolution";
            tsslblResolution.Name = "tsslblResolution";
            tsslblResolution.Visible = false;

            ToolStripLabel tsslblType = new ToolStripLabel();
            tsslblType.Text = "tsslblType";
            tsslblType.Name = "tsslblType";
            tsslblType.Visible = false;

            this.stsStatus.Items.AddRange(new ToolStripItem[] { tsslblLoading, tsspgbLoading, tsslblLocation, sp1, tsslblResolution, sp2, tsslblType });

            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
        }

        private void SetCtrlPnl(bool bReady)
        {
            this.pnlCtrl.SuspendLayout();

            this.tbrCompRadio.Enabled = bReady;
            this.tbrCompRadio.Value = Properties.Settings.Default.DftCompressRadio;
            this.lblCompRadio.Text = string.Format("压缩比: {0}%", this.tbrCompRadio.Value);

            this.lblBeforeComp.Text = string.Format("压缩前: {0} KB", "");
            this.lblAfterComp.Text = string.Format("压缩后: {0} KB", "");

            this.btnBeforeComp.Enabled = bReady;
            this.btnBeforeComp.BackColor = bReady == true ? SystemColors.Highlight : SystemColors.Control;
            this.btnAfterComp.Enabled = false;
            this.btnAfterComp.BackColor = SystemColors.Control;
            
            this.pnlCtrl.ResumeLayout(false);
            this.pnlCtrl.PerformLayout();
        }

        private void tbrCompRadio_Scroll(object sender, EventArgs e)
        {
            this.lblCompRadio.Text = string.Format("压缩比: {0}%", this.tbrCompRadio.Value);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.ofdOpen.ShowDialog())
            {
                if (File.Exists(ofdOpen.FileName) == true)
                {
                    PICFULLNAME = ofdOpen.FileName;
                    PICDIR = System.IO.Path.GetDirectoryName(PICFULLNAME);
                    PICTYPE = System.IO.Path.GetExtension(PICFULLNAME);
                    ORIPIC = System.IO.Path.GetFileNameWithoutExtension(PICFULLNAME);
                    COMPPIC = string.Format("{0}_压缩", ORIPIC);
                    COMPPICFULLNAME = string.Format("{0}\\{1}{2}", PICDIR, COMPPIC, PICTYPE);
                    SetCtrlPnl(true);

                    this.lblBeforeComp.Text = string.Format("压缩前: {0}", Utility.GetFileSize(PICFULLNAME));

                    pbxPic.WaitOnLoad = false;

                    if (LoadImage != null)
                        pbxPic.InitialImage = LoadImage;
                    pbxPic.LoadAsync(PICFULLNAME);
                    this.stsStatus.Items["tsslblLoading"].Visible = true;
                    this.stsStatus.Items["tsspgbLoading"].Visible = true;
                    this.stsStatus.Items["tsslblLocation"].Visible = false;
                    this.stsStatus.Items["tsslblResolution"].Visible = false;
                    this.stsStatus.Items["tsslblType"].Visible = false;

                    this.btnComp.Enabled = false;
                    HasComp = false;
                }
            }
        }

        private void pbxPic_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // set panel for picture box
            this.pnlPic.SuspendLayout();

            if (this.pbxPic.Image != null)
            {
                if (this.pnlPic.Width > this.pbxPic.Image.Width
                    && this.pnlPic.Height > this.pbxPic.Image.Height)
                {
                    this.pbxPic.SizeMode = PictureBoxSizeMode.Normal;
                    this.pbxPic.Width = this.pbxPic.Image.Width;
                    this.pbxPic.Height = this.pbxPic.Image.Height;
                    this.pbxPic.Top = (this.pnlPic.Height - this.pbxPic.Height) / 2;
                    this.pbxPic.Left = (this.pnlPic.Width - this.pbxPic.Width) / 2;
                }
                else
                {
                    this.pbxPic.Width = this.pnlPic.Width;
                    this.pbxPic.Height = this.pnlPic.Height;
                    this.pbxPic.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }

            this.pnlPic.ResumeLayout(false);
            this.pnlPic.PerformLayout();
            // set status bar
            this.stsStatus.SuspendLayout();

            this.stsStatus.Items["tsslblLoading"].Visible = false;
            this.stsStatus.Items["tsspgbLoading"].Visible = false;               
            if (this.btnAfterComp.Enabled == false && COMPPIC != null)
                this.stsStatus.Items["tsslblLocation"].Text = COMPPIC + PICTYPE;
            else
                this.stsStatus.Items["tsslblLocation"].Text = ORIPIC + PICTYPE;
            this.stsStatus.Items["tsslblLocation"].Visible = true;
            this.stsStatus.Items["tsslblResolution"].Text = string.Format("{0} x {1}", pbxPic.Image.Width, pbxPic.Image.Height);
            this.stsStatus.Items["tsslblResolution"].Visible = true;
            this.stsStatus.Items["tsslblType"].Text = string.Format("{0} 文件", System.IO.Path.GetExtension(pbxPic.ImageLocation));
            this.stsStatus.Items["tsslblType"].Visible = true;
            this.tbxWidth.Text = this.pbxPic.Image.Width.ToString();
            this.tbxHeight.Text = this.pbxPic.Image.Height.ToString();

            this.btnComp.Enabled = true;

            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
        }

        private void pbxPic_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ToolStripProgressBar pgb = this.stsStatus.Items["tsspgbLoading"] as ToolStripProgressBar;
            if (pgb != null)
            {
                pgb.Value = e.ProgressPercentage;
            }
        }
        
        private void btnComp_Click(object sender, EventArgs e)
        {
            Bitmap pic = pbxPic.Image as Bitmap;
            if (pic != null)
            {
                ImageCodecInfo[] infos = ImageCodecInfo.GetImageDecoders();
                ImageCodecInfo jpgInfo = null;
                foreach (ImageCodecInfo info in infos)
                {
                    if (ImageFormat.Jpeg.Guid == info.FormatID)
                    {
                        jpgInfo = info;
                    }
                }
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myParams = new EncoderParameters(1);
                EncoderParameter myParam = new EncoderParameter(myEncoder, Convert.ToInt64(tbrCompRadio.Value));
                myParams.Param[0] = myParam;
                //pic.Save("c:/temp/half.jpg", jpgInfo, myParams);

                int srcWidth = pic.Width;
                int srcHeight = pic.Height;
                int srcX = 0;
                int srcY = 0; 

                int Width = Int32.Parse(this.tbxWidth.Text);
                int Height = Int32.Parse(this.tbxHeight.Text);

                int dstWidth = 0;
                int dstHeight = 0;
                int dstX = 0;
                int dstY = 0;

                float nPercentW = (float)Width / srcWidth;
                float nPercentH = (float)Height / srcHeight;
                float nPercent = 0;

                if (nPercentW < nPercentH)
                {
                    nPercent = nPercentW;
                    dstY = System.Convert.ToInt16((Height - srcHeight * nPercent) / 2);
                }
                else
                {
                    nPercent = nPercentH;
                    dstX = System.Convert.ToInt16((Width - srcWidth * nPercent) / 2);
                }

                dstWidth = (int)(srcWidth * nPercent);
                dstHeight = (int)(srcHeight * nPercent);

                Bitmap scalePic = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
                scalePic.SetResolution(pic.HorizontalResolution, pic.VerticalResolution);

                Graphics scaleG = System.Drawing.Graphics.FromImage(scalePic);
                scaleG.Clear(Color.White);
                scaleG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                scaleG.DrawImage(pic,
                                new Rectangle(dstX, dstY, dstWidth, dstHeight),
                                new Rectangle(0, 0, srcWidth, srcHeight),
                                GraphicsUnit.Pixel);
                scaleG.Dispose();

                //scalePic.Save("c:\\temp\\scale.jpg", ImageFormat.Jpeg);
                scalePic.Save(COMPPICFULLNAME, jpgInfo, myParams);
                scalePic.Dispose();

                lblAfterComp.Text = string.Format("压缩后: {0}", Utility.GetFileSize(COMPPICFULLNAME));
                this.btnAfterComp.Enabled = true;
                HasComp = true;
            }
        }

        private void cbxRestrain_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxRestrain.Checked == true)
            {
                this.tbxHeight.Enabled = false;
                if (this.pbxPic.Image != null
                    && this.tbxWidth.Text.Trim().Length > 0)
                {
                    int width = 0;
                    width = Int32.Parse(this.tbxWidth.Text);
                    this.tbxHeight.Text = (width * this.pbxPic.Image.Height / this.pbxPic.Image.Width).ToString();
                }
                else
                {
                    this.tbxHeight.Text = "";
                }
            }
            else
            {
                this.tbxHeight.Enabled = true;
            }
        }

        private void tbxHeight_Validating(object sender, CancelEventArgs e)
        {
            if (this.tbxHeight.Text.Trim().Length > 0)
            {
                int width = 0;
                if (Int32.TryParse(tbxHeight.Text.Trim(), out width) == false)
                {
                    MessageBox.Show("请输入数字");
                    this.tbxHeight.Focus();
                }
            }
        }

        private void tbxWidth_TextChanged(object sender, EventArgs e)
        {
            if (this.tbxWidth.Text.Trim().Length > 0)
            {
                int width = 0;
                if (Int32.TryParse(tbxWidth.Text.Trim(), out width) == false)
                {
                    MessageBox.Show("请输入数字");
                    this.tbxWidth.Focus();
                    return;
                }
                if (cbxRestrain.Checked == true && this.pbxPic.Image != null)
                {
                    width = Int32.Parse(this.tbxWidth.Text);
                    this.tbxHeight.Text = (width * this.pbxPic.Image.Height / this.pbxPic.Image.Width).ToString();
                }
            }
        }

        private void btnAfterComp_Click(object sender, EventArgs e)
        {
            if (File.Exists(COMPPICFULLNAME) == true && HasComp)
            {
                this.btnAfterComp.Enabled = false;
                this.btnBeforeComp.Enabled = true;
                if (LoadImage != null)
                    pbxPic.InitialImage = LoadImage;
                pbxPic.LoadAsync(COMPPICFULLNAME);
            }
        }

        private void pnlPic_Resize(object sender, EventArgs e)
        {
            this.pnlPic.SuspendLayout();

            if (this.pbxPic.Image != null)
            {
                if (this.pnlPic.Width > this.pbxPic.Image.Width
                    && this.pnlPic.Height > this.pbxPic.Image.Height)
                {
                    this.pbxPic.SizeMode = PictureBoxSizeMode.Normal;
                    this.pbxPic.Width = this.pbxPic.Image.Width;
                    this.pbxPic.Height = this.pbxPic.Image.Height;
                    this.pbxPic.Top = (this.pnlPic.Height - this.pbxPic.Height) / 2;
                    this.pbxPic.Left = (this.pnlPic.Width - this.pbxPic.Width) / 2;
                }
                else
                {
                    this.pbxPic.Width = this.pnlPic.Width;
                    this.pbxPic.Height = this.pnlPic.Height;
                    this.pbxPic.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            

            this.pnlPic.ResumeLayout(false);
            this.pnlPic.PerformLayout();
        }

        private void btnBeforeComp_Click(object sender, EventArgs e)
        {
            if (HasComp)
            {
                this.btnBeforeComp.Enabled = false;
                this.btnAfterComp.Enabled = true;
            }
            if (LoadImage != null)
                pbxPic.InitialImage = LoadImage;
            pbxPic.LoadAsync(PICFULLNAME);
        }
    }
}
