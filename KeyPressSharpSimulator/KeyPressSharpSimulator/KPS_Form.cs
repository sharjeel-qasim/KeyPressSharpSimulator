using System;
using System.Windows.Forms;

namespace KeyPressSharpSimulator
{
    public partial class KPS_Form : Form
    {
        private Timer KPS_Timer = new Timer();
        public KPS_Form()
        {
            InitializeComponent();

            KeyPreview = true;
            KeyDown += MainForm_KeyDown;

            KPS_Timer.Interval = 3000;
            KPS_Timer.Tick += Timer_Tick;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
                StartKPS();
            else if (e.KeyCode == Keys.F4)
                StopKPS();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SendKeys.SendWait("{DOWN}");
        }

        private void StartKPS()
        {
            KPS_Timer.Start();
            messageLabel.Visible = true;
        }

        private void StopKPS()
        {
            KPS_Timer.Stop();
            messageLabel.Visible = false;
        }

        private void KPS_Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notify_Icon.Visible = true;
            }
        }

        private void notify_Icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notify_Icon.Visible = false;
        }
    }
}
