using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace CapturePicture_Sample
{
    public partial class Form1 : Form
    {
        private int screenCount = 0;
        private System.Windows.Forms.Timer screenTimer;
        public Form1()
        {
            InitializeComponent();
            //InitializeCustomComponents();
        }

        #region 初始化自定義按鈕並綁定事件-多做的按鈕
        //private void InitializeCustomComponents()
        //{
        //    Button screebBtn = new Button
        //    {
        //        Text = "開始截圖",
        //        Location = new Point(10, 10),
        //        Size = new Size(100, 30)
        //    };

        //    screebBtn.Click += btn_CapturePicture_Click;
        //    Controls.Add(screebBtn);
        //}
        #endregion

        #region 啟動計時器
        private void btn_CapturePicture_Click(object sender, EventArgs e)
        {
            screenCount = 0;
            screenTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000 //設定間隔時間為1000毫秒（1秒）
            };

            screenTimer.Tick += ScreenTimer_Tick;
            screenTimer.Start();
        }
        #endregion

        #region 計時器_每秒擷取一次截圖
        private void ScreenTimer_Tick(object sender, EventArgs e)
        {
            if (screenCount < 10)
            {
                TakeScreen();
                screenCount++;
            }
            else
            {
                screenTimer.Stop();
                MessageBox.Show("截圖完成！");
            }
        }
        #endregion

        #region 截圖並儲存到指定路徑
        private void TakeScreen()
        {
            try
            {
                // 檢查並建立目標文件夾
                string directoryPath = @"C:\Users\chuny\OneDrive\桌面\群創專案\攝影機程式\CapturePic";
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                //獲取螢幕尺寸
                Rectangle bounds = Screen.GetBounds(Point.Empty);

                //建立一個Bitmap來儲存影像
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }

                    // 儲存影像到文件夾中
                    string filePath = $@"{directoryPath}\Pic_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";
                    bitmap.Save(filePath, ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"截圖失敗: {ex.Message}");
            }
        }
        #endregion
    }
}