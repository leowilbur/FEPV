// ?2007 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Shell.Steps
{
    internal class SplashForm : Form
    {
        System.Windows.Forms.Timer m_Timer;
        PictureBox m_SplashPictureBox;
        private System.ComponentModel.IContainer components;
        private Label label1;
        bool m_HideSplash = false;

        public SplashForm(Bitmap splashImage)
        {
            InitializeComponent();
            m_SplashPictureBox.Image = splashImage;
            ClientSize = m_SplashPictureBox.Size;
        }
        #region Windows Form Designer generated code
        void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            this.m_SplashPictureBox = new System.Windows.Forms.PictureBox();
            this.m_Timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_SplashPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // m_SplashPictureBox
            // 
            this.m_SplashPictureBox.Location = new System.Drawing.Point(0, 0);
            this.m_SplashPictureBox.Name = "m_SplashPictureBox";
            this.m_SplashPictureBox.Size = new System.Drawing.Size(112, 80);
            this.m_SplashPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_SplashPictureBox.TabIndex = 0;
            this.m_SplashPictureBox.TabStop = false;
            // 
            // m_Timer
            // 
            this.m_Timer.Enabled = true;
            this.m_Timer.Interval = 500;
            this.m_Timer.Tick += new System.EventHandler(this.OnTick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashForm
            // 
            this.ClientSize = new System.Drawing.Size(227, 172);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_SplashPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.m_SplashPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        DateTime b = DateTime.Now;
        private void OnTick(object sender, EventArgs e)
        {
            label1.Text = (DateTime.Now - b).ToString();
            if (HideSplash == true)
            {
                m_Timer.Enabled = false;
                Close();
            }
        }
        public bool HideSplash
        {
            get
            {
                lock (this)
                {
                    return m_HideSplash;
                }
            }
            set
            {
                lock (this)
                {
                    m_HideSplash = value;
                }
            }
        }
    }
    public class SplashScreen
    {
        public SplashScreen(Bitmap splash)
        {
            m_SplashImage = splash;
            ThreadStart threadStart = new ThreadStart(Show);
            m_WorkerThread = new Thread(threadStart);
            m_WorkerThread.Start();
        }
        void Show()
        {
            m_SplashForm = new SplashForm(m_SplashImage);
            m_SplashForm.ShowDialog();
        }
        public void Close()
        {
            m_SplashForm.HideSplash = true;
            m_WorkerThread.Join();
        }
        Bitmap m_SplashImage;
        SplashForm m_SplashForm;
        Thread m_WorkerThread;
    }
}