using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ImageProcessingSpeedComp
{
    public partial class FormMain : Form
    {
        enum Pixel
        {
            B = 0,
            G ,
            R,
            A,
            MAX,
        };

        private const int m_nMaskSize = 3;
        private short[,] m_nMask;
        private Bitmap m_bitmapImageFilter;
        private byte[,,] m_pixelData;
        private string m_strOpenFileName;
        private bool m_bStatusView;
        private CancellationTokenSource m_tokenSource;

        public FormMain()
        {
            InitializeComponent();

            SetFormMain();

            btnFileSelect.Enabled = true;
            btnAllClear.Enabled = true;
            btnFilterStartUnsafe.Enabled = false;
            btnFilterStartNormal.Enabled = false;
            btnStop.Enabled = false;

            pictureBoxStatus.Visible = false;

            checkBoxView.Checked = false;

            labelStart.Visible = false;
            labelEnd.Visible = false;

            SetToolTip();

            m_nMask = new short[m_nMaskSize, m_nMaskSize]
            {
                {1,  1, 1},
                {1, -8, 1},
                {1,  1, 1}
            };

            m_bitmapImageFilter = null;
            m_tokenSource = null;
        }

        public void SetFormMain()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            return;
        }

        public void SetToolTip()
        {
            toolTipBtnFileSelect.InitialDelay = 1000;
            toolTipBtnFileSelect.ReshowDelay = 1000;
            toolTipBtnFileSelect.AutoPopDelay = 10000;
            toolTipBtnFileSelect.ShowAlways = false;
            toolTipBtnFileSelect.SetToolTip(btnFileSelect, "Please select a file to open.\nDisplay the image on the original image.");

            toolTipBtnAllClear.InitialDelay = 1000;
            toolTipBtnAllClear.ReshowDelay = 1000;
            toolTipBtnAllClear.AutoPopDelay = 10000;
            toolTipBtnAllClear.ShowAlways = false;
            toolTipBtnAllClear.SetToolTip(btnAllClear, "Clear the display.");

            toolTipBtnFilterStartUnsafe.InitialDelay = 1000;
            toolTipBtnFilterStartUnsafe.ReshowDelay = 1000;
            toolTipBtnFilterStartUnsafe.AutoPopDelay = 10000;
            toolTipBtnFilterStartUnsafe.ShowAlways = false;
            toolTipBtnFilterStartUnsafe.SetToolTip(btnFilterStartUnsafe, "Perform unstable filter processing.");

            toolTipBtnFilterStartNormal.InitialDelay = 1000;
            toolTipBtnFilterStartNormal.ReshowDelay = 1000;
            toolTipBtnFilterStartNormal.AutoPopDelay = 10000;
            toolTipBtnFilterStartNormal.ShowAlways = false;
            toolTipBtnFilterStartNormal.SetToolTip(btnFilterStartNormal, "Perform normal filter processing.");

            toolTipBtnStop.InitialDelay = 1000;
            toolTipBtnStop.ReshowDelay = 1000;
            toolTipBtnStop.AutoPopDelay = 10000;
            toolTipBtnStop.ShowAlways = false;
            toolTipBtnStop.SetToolTip(btnStop, "Processing stop.");

            return;
        }


        ~FormMain()
        {
            m_nMask = null;
            m_bitmapImageFilter = null;
            m_pixelData = null;
            m_tokenSource = null;
        }

        public void SetButtonEnable()
        {
            btnFileSelect.Enabled = true;
            btnAllClear.Enabled = true;
            btnFilterStartUnsafe.Enabled = true;
            btnFilterStartNormal.Enabled = true;
            btnStop.Enabled = false;
            checkBoxView.Enabled = true;
        }

        public void SetTextTime(long lTime)
        {
            textBoxTime.Text = lTime.ToString();
        }

        public void SetProgressBar(int nCount)
        {
            progressBar.Value = nCount;
        }

        public void SetPictureBoxStatus()
        {
            pictureBoxStatus.Visible = false;
        }

        public async Task<bool> TaskWorkUnsafe()
        {
            m_tokenSource = new CancellationTokenSource();
            CancellationToken token = m_tokenSource.Token;
            bool bResult = await Task.Run(() => FilterUnsafe(token));
            return bResult;
        }

        public async Task<bool> TaskWorkNormal()
        {
            m_tokenSource = new CancellationTokenSource();
            CancellationToken token = m_tokenSource.Token;
            bool bResult = await Task.Run(() => FilterNormal(token));
            return bResult;
        }

        public async Task<bool> TaskSetPixelData()
        {
            m_tokenSource = new CancellationTokenSource();
            CancellationToken token = m_tokenSource.Token;
            bool bResult = await Task.Run(() => SetPixelData(token));
            return bResult;
        }

        public void LoadImage()
        {
            m_bitmapImageFilter = new Bitmap(m_strOpenFileName);

            return;
        }

        public bool FilterUnsafe(CancellationToken token)
        {
            bool bResult = true;
            int nWidthSize = m_bitmapImageFilter.Width;
            int nHeightSize = m_bitmapImageFilter.Height;
            int nMasksize = m_nMask.GetLength(0);

            BitmapData bitmapData = m_bitmapImageFilter.LockBits(new Rectangle(0, 0, nWidthSize, nHeightSize), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            int nIndexWidth;
            int nIndexHeight;
            int nCount = 0;
            unsafe
            {
                for (nIndexHeight = 0; nIndexHeight < nHeightSize; nIndexHeight++)
                {
                    for (nIndexWidth = 0; nIndexWidth < nWidthSize; nIndexWidth++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            bResult = false;
                            break;
                        }

                        byte* pPixel = (byte*)bitmapData.Scan0 + nIndexHeight * bitmapData.Stride + nIndexWidth * 4;

                        long lCalB = 0;
                        long lCalG = 0;
                        long lCalR = 0;
                        int nIndexWidthMask;
                        int nIndexHightMask;

                        for (nIndexHightMask = 0; nIndexHightMask < nMasksize; nIndexHightMask++)
                        {
                            for (nIndexWidthMask = 0; nIndexWidthMask < nMasksize; nIndexWidthMask++)
                            {
                                if (nIndexWidth + nIndexWidthMask > 0 &&
                                    nIndexWidth + nIndexWidthMask < nWidthSize &&
                                    nIndexHeight + nIndexHightMask > 0 &&
                                    nIndexHeight + nIndexHightMask < nHeightSize)
                                {
                                    byte* pPixel2 = (byte*)bitmapData.Scan0 + (nIndexHeight + nIndexHightMask) * bitmapData.Stride + (nIndexWidth + nIndexWidthMask) * 4;

                                    lCalB += pPixel2[0] * m_nMask[nIndexWidthMask, nIndexHightMask];
                                    lCalG += pPixel2[1] * m_nMask[nIndexWidthMask, nIndexHightMask];
                                    lCalR += pPixel2[2] * m_nMask[nIndexWidthMask, nIndexHightMask];
                                }
                            }
                        }
                        pPixel[0] = LongToByte(lCalB);
                        pPixel[1] = LongToByte(lCalG);
                        pPixel[2] = LongToByte(lCalR);

                        nCount++;
                    }
                    if (m_bStatusView)
                    {
                        Invoke(new Action<int>(SetProgressBar), nCount);
                    }
                }
                m_bitmapImageFilter.UnlockBits(bitmapData);
            }
            return bResult;
        }

        public bool FilterNormal(CancellationToken token)
        {
            bool bResult = true;
            int nWidthSize = m_bitmapImageFilter.Width;
            int nHeightSize = m_bitmapImageFilter.Height;
            int nMasksize = m_nMask.GetLength(0);

            int nIndexWidth;
            int nIndexHeight;
            int nCount = 0;

            for (nIndexHeight = 0; nIndexHeight < nHeightSize; nIndexHeight++)
            {
                for (nIndexWidth = 0; nIndexWidth < nWidthSize; nIndexWidth++)
                {
                    if (token.IsCancellationRequested)
                    {
                        bResult = false;
                        break;
                    }

                    byte nPixelB;
                    byte nPixelG;
                    byte nPixelR;
                    byte nPixelA;

                    long lCalB = 0;
                    long lCalG = 0;
                    long lCalR = 0;

                    int nIndexWidthMask;
                    int nIndexHightMask;

                    for (nIndexHightMask = 0; nIndexHightMask < nMasksize; nIndexHightMask++)
                    {
                        for (nIndexWidthMask = 0; nIndexWidthMask < nMasksize; nIndexWidthMask++)
                        {
                            if (nIndexWidth + nIndexWidthMask > 0 &&
                                nIndexWidth + nIndexWidthMask < nWidthSize &&
                                nIndexHeight + nIndexHightMask > 0 &&
                                nIndexHeight + nIndexHightMask < nHeightSize)
                            {
                                byte nPixel2B = m_pixelData[nIndexWidth + nIndexWidthMask, nIndexHeight + nIndexHightMask, (int)Pixel.B];
                                byte nPixel2G = m_pixelData[nIndexWidth + nIndexWidthMask, nIndexHeight + nIndexHightMask, (int)Pixel.G];
                                byte nPixel2R = m_pixelData[nIndexWidth + nIndexWidthMask, nIndexHeight + nIndexHightMask, (int)Pixel.R];
                                byte nPixel2A = m_pixelData[nIndexWidth + nIndexWidthMask, nIndexHeight + nIndexHightMask, (int)Pixel.A];

                                lCalB += nPixel2B * m_nMask[nIndexWidthMask, nIndexHightMask];
                                lCalG += nPixel2G * m_nMask[nIndexWidthMask, nIndexHightMask];
                                lCalR += nPixel2R * m_nMask[nIndexWidthMask, nIndexHightMask];
                            }
                        }
                    }
                    nPixelB = LongToByte(lCalB);
                    nPixelG = LongToByte(lCalG);
                    nPixelR = LongToByte(lCalR);
                    nPixelA = m_pixelData[nIndexWidth, nIndexHeight, (int)Pixel.A];

                    m_bitmapImageFilter.SetPixel(nIndexWidth, nIndexHeight, Color.FromArgb(nPixelA, nPixelR, nPixelG, nPixelB));

                    nCount++;
                }
                if (m_bStatusView)
                {
                    Invoke(new Action<int>(SetProgressBar), nCount);
                }
            }
            return bResult;
        }

        public bool SetPixelData(CancellationToken token)
        {
            bool bResult = true;
            int nIndexWidth;
            int nIndexHeight;
            try
            {
                for (nIndexHeight = 0; nIndexHeight < m_bitmapImageFilter.Height; nIndexHeight++)
                {
                    for (nIndexWidth = 0; nIndexWidth < m_bitmapImageFilter.Width; nIndexWidth++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            bResult = false;
                            break;
                        }

                        m_pixelData[nIndexWidth, nIndexHeight, (int)Pixel.B] = m_bitmapImageFilter.GetPixel(nIndexWidth, nIndexHeight).B;
                        m_pixelData[nIndexWidth, nIndexHeight, (int)Pixel.G] = m_bitmapImageFilter.GetPixel(nIndexWidth, nIndexHeight).G;
                        m_pixelData[nIndexWidth, nIndexHeight, (int)Pixel.R] = m_bitmapImageFilter.GetPixel(nIndexWidth, nIndexHeight).R;
                        m_pixelData[nIndexWidth, nIndexHeight, (int)Pixel.A] = m_bitmapImageFilter.GetPixel(nIndexWidth, nIndexHeight).A;
                    }
                }
            }
            catch
            {
                bResult = false;
            }

            return bResult;
        }

        public byte DoubleToByte(double _dValue)
        {
            byte nCnvValue = 0;
            if (_dValue > 255.0)
            {
                nCnvValue = 255;
            }
            else if (_dValue < 0)
            {
                nCnvValue = 0;
            }
            else
            {
                nCnvValue = (byte)_dValue;
            }
            return nCnvValue;
        }

        public byte LongToByte(long _lValue)
        {
            byte nCnvValue = 0;
            if (_lValue > 255.0)
            {
                nCnvValue = 255;
            }
            else if (_lValue < 0)
            {
                nCnvValue = 0;
            }
            else
            {
                nCnvValue = (byte)_lValue;
            }
            return nCnvValue;
        }

        public void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_tokenSource != null)
            {
                e.Cancel = true;
            }
            return;
        }

        public void BtnFileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();

            openFileDlg.FileName = "default.jpg";
            openFileDlg.InitialDirectory = @"C:\";
            openFileDlg.Filter = "All Files(*.*)|*.*";
            openFileDlg.FilterIndex = 1;
            openFileDlg.Title = "Please select a file to open";
            openFileDlg.RestoreDirectory = true;
            openFileDlg.CheckFileExists = true;
            openFileDlg.CheckPathExists = true;

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxOriginal.Image = null;
                pictureBoxFilter.Image = null;
                m_strOpenFileName = openFileDlg.FileName;
                try
                {
                    LoadImage();
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Open File Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pictureBoxOriginal.ImageLocation = m_strOpenFileName;
                btnFilterStartUnsafe.Enabled = true;
                btnFilterStartNormal.Enabled = true;
                progressBar.Value = 0;
                textBoxTime.Text = "";

                labelStart.Visible = true;
                labelEnd.Visible = true;
                labelStart.Text = "0";
                labelEnd.Text = (m_bitmapImageFilter.Width * m_bitmapImageFilter.Height).ToString();
            }
            return;
        }

        private void BtnAllClear_Click(object sender, EventArgs e)
        {
            pictureBoxOriginal.ImageLocation = null;
            pictureBoxFilter.Image = null;

            m_bitmapImageFilter = null;
            m_pixelData = null;
            m_strOpenFileName = "";

            progressBar.Value = 0;
            textBoxTime.Text = "";

            btnFileSelect.Enabled = true;
            btnAllClear.Enabled = true;
            btnFilterStartUnsafe.Enabled = false;
            btnFilterStartNormal.Enabled = false;

            labelStart.Visible = false;
            labelEnd.Visible = false;

            return;
        }

        private async void BtnFilterStartUnsafe_Click(object sender, EventArgs e)
        {
            pictureBoxFilter.Image = null;

            btnFileSelect.Enabled = false;
            btnAllClear.Enabled = false;
            btnFilterStartUnsafe.Enabled = false;
            btnFilterStartNormal.Enabled = false;

            checkBoxView.Enabled = false;

            textBoxTime.Text = "";

            m_bStatusView = checkBoxView.Checked;

            pictureBoxStatus.Visible = true;

            LoadImage();
            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = m_bitmapImageFilter.Width * m_bitmapImageFilter.Height;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            btnStop.Enabled = true;
            bool bResult = await TaskWorkUnsafe();
            if (bResult)
            {
                pictureBoxOriginal.ImageLocation = m_strOpenFileName;
                pictureBoxFilter.Image = m_bitmapImageFilter;

                stopwatch.Stop();

                Invoke(new Action<long>(SetTextTime), stopwatch.ElapsedMilliseconds);
            }
            Invoke(new Action(SetPictureBoxStatus));
            Invoke(new Action(SetButtonEnable));

            stopwatch = null;
            m_tokenSource = null;
            m_bitmapImageFilter = null;

            return;
        }

        private async void BtnFilterStartNormal_Click(object sender, EventArgs e)
        {
            pictureBoxFilter.Image = null;

            btnFileSelect.Enabled = false;
            btnAllClear.Enabled = false;
            btnFilterStartUnsafe.Enabled = false;
            btnFilterStartNormal.Enabled = false;

            checkBoxView.Enabled = false;

            textBoxTime.Text = "";

            m_bStatusView = checkBoxView.Checked;

            pictureBoxStatus.Visible = true;

            LoadImage();
            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = m_bitmapImageFilter.Width * m_bitmapImageFilter.Height;
            m_pixelData = new byte[m_bitmapImageFilter.Width, m_bitmapImageFilter.Height, (int)Pixel.MAX];

            bool bResult;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            btnStop.Enabled = true;
            bResult = await TaskSetPixelData();
            if (bResult)
            {
                bResult = await TaskWorkNormal();
                if (bResult)
                {
                    pictureBoxOriginal.ImageLocation = m_strOpenFileName;
                    pictureBoxFilter.Image = m_bitmapImageFilter;

                    stopwatch.Stop();

                    Invoke(new Action<long>(SetTextTime), stopwatch.ElapsedMilliseconds);
                }
            }
            Invoke(new Action(SetPictureBoxStatus));
            Invoke(new Action(SetButtonEnable));

            stopwatch = null;
            m_tokenSource = null;
            m_bitmapImageFilter = null;
            m_pixelData = null;

            return;
        }

        private void CheckBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            m_bStatusView = checkBoxView.Checked;

            return;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (m_tokenSource != null)
            {
                m_tokenSource.Cancel();
            }

            return;
        }
    }
}