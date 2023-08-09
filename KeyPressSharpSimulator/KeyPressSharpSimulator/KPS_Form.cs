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

            KPS_Timer.Interval = 3000;
            KPS_Timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SendKeys.SendWait("{DOWN}");
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            KPS_Timer.Start();
        }

        private void Stop_Button_Click(object sender, EventArgs e)
        {
            KPS_Timer.Stop();
        }

        private void Hide_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
