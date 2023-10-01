using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyPressSharpSimulator
{
    public partial class KPS_Form : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        private Random Random = new Random();
        private Timer KPS_Timer = new Timer();

        public KPS_Form()
        {
            InitializeComponent();

            KeyPreview = true;
            KeyDown += MainForm_KeyDown;

            KPS_Timer.Interval = 1000;
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
            int randomAction = Random.Next(6); // Generate a random number between 0 and 5

            // Use a switch statement to perform a random action
            switch (randomAction)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    // Send a random arrow key
                    int randomDirection = Random.Next(4); // Generate a random number between 0 and 3
                    SendRandomArrowKey(randomDirection);
                    break;
                case 4:
                    // Simulate a mouse left click
                    SimulateMouseClick();
                    break;
                case 5:
                    // Simulate pressing the Ctrl key
                    SimulateCTRLClick();
                    break;
                default:
                    break;
            }
        }

        private void SendRandomArrowKey(int direction)
        {
            switch (direction)
            {
                case 0:
                    SendKeys.SendWait("{UP}");
                    break;
                case 1:
                    SendKeys.SendWait("{DOWN}");
                    break;
                case 2:
                    SendKeys.SendWait("{LEFT}");
                    break;
                case 3:
                    SendKeys.SendWait("{RIGHT}");
                    break;
                default:
                    break;
            }
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

        private void SimulateMouseClick()
        {
            // Simulate a mouse left click using mouse_event
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void SimulateCTRLClick()
        {
            SendKeys.SendWait("^{DOWN}");
            SendKeys.SendWait("^{UP}");
        }
    }
}
