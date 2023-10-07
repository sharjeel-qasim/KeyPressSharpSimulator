using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyPressSharpSimulator
{
    public partial class KPS_Form : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

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
            int randomAction = Random.Next(10); // Generate a random number between 0 and 5

            // Use a switch statement to perform a random action
            switch (randomAction)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 6:
                case 7:
                case 8:
                case 9:
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
                    MoveMouse();
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
                case 6:
                case 7:
                case 8:
                case 9:
                    SendKeys.SendWait("{DOWN}");
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

        private void MoveMouse()
        {
            // Define the screen boundaries and the vertical range (adjust these values as needed)
            int minX = 0;
            int minY = 0;
            int maxX = ScreenWidth(); // Get the screen width
            int maxY = ScreenHeight(); // Get the screen height

            int verticalRange = maxY / 2; // Adjust this value to control the vertical range

            // Generate random X and Y coordinates within the screen boundaries, limiting Y to the vertical range
            int randomX = Random.Next(minX, maxX);
            int randomY = Random.Next(minY, maxY - verticalRange) + verticalRange / 2;

            // Move the mouse cursor to the randomly generated position
            SetCursorPos(randomX, randomY);
        }

        // Function to get the screen width
        static int ScreenWidth()
        {
            return System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        }

        // Function to get the screen height
        static int ScreenHeight()
        {
            return System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        }
    }
}
