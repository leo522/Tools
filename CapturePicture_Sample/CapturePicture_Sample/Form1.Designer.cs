namespace CapturePicture_Sample
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btn_CapturePicture = new Button();
            ScreenTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btn_CapturePicture
            // 
            btn_CapturePicture.Location = new Point(669, 163);
            btn_CapturePicture.Name = "btn_CapturePicture";
            btn_CapturePicture.Size = new Size(121, 72);
            btn_CapturePicture.TabIndex = 0;
            btn_CapturePicture.Text = "畫面截圖";
            btn_CapturePicture.UseVisualStyleBackColor = true;
            btn_CapturePicture.Click += btn_CapturePicture_Click;
            // 
            // ScreenTimer
            // 
            ScreenTimer.Tick += ScreenTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 734);
            Controls.Add(btn_CapturePicture);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_CapturePicture;
        private System.Windows.Forms.Timer ScreenTimer;
    }
}
