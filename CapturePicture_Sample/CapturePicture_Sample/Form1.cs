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

        #region ��l�Ʀ۩w�q���s�øj�w�ƥ�-�h�������s
        //private void InitializeCustomComponents()
        //{
        //    Button screebBtn = new Button
        //    {
        //        Text = "�}�l�I��",
        //        Location = new Point(10, 10),
        //        Size = new Size(100, 30)
        //    };

        //    screebBtn.Click += btn_CapturePicture_Click;
        //    Controls.Add(screebBtn);
        //}
        #endregion

        #region �Ұʭp�ɾ�
        private void btn_CapturePicture_Click(object sender, EventArgs e)
        {
            screenCount = 0;
            screenTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000 //�]�w���j�ɶ���1000�@��]1��^
            };

            screenTimer.Tick += ScreenTimer_Tick;
            screenTimer.Start();
        }
        #endregion

        #region �p�ɾ�_�C���^���@���I��
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
                MessageBox.Show("�I�ϧ����I");
            }
        }
        #endregion

        #region �I�Ϩ��x�s����w���|
        private void TakeScreen()
        {
            try
            {
                // �ˬd�ëإߥؼФ��
                string directoryPath = @"C:\Users\chuny\OneDrive\�ୱ\�s�бM��\��v���{��\CapturePic";
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                //����ù��ؤo
                Rectangle bounds = Screen.GetBounds(Point.Empty);

                //�إߤ@��Bitmap���x�s�v��
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }

                    // �x�s�v�����󧨤�
                    string filePath = $@"{directoryPath}\Pic_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";
                    bitmap.Save(filePath, ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�I�ϥ���: {ex.Message}");
            }
        }
        #endregion
    }
}