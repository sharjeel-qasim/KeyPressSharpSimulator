namespace KeyPressSharpSimulator
{
    partial class KPS_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KPS_Form));
            this.Start_Button = new System.Windows.Forms.Button();
            this.Stop_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start_Button
            // 
            this.Start_Button.Location = new System.Drawing.Point(34, 24);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(126, 55);
            this.Start_Button.TabIndex = 0;
            this.Start_Button.Text = "Start";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // Stop_Button
            // 
            this.Stop_Button.Location = new System.Drawing.Point(167, 24);
            this.Stop_Button.Name = "Stop_Button";
            this.Stop_Button.Size = new System.Drawing.Size(126, 55);
            this.Stop_Button.TabIndex = 1;
            this.Stop_Button.Text = "Stop";
            this.Stop_Button.UseVisualStyleBackColor = true;
            this.Stop_Button.Click += new System.EventHandler(this.Stop_Button_Click);
            // 
            // KPS_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 101);
            this.Controls.Add(this.Stop_Button);
            this.Controls.Add(this.Start_Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "KPS_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KPS";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.Button Stop_Button;
    }
}

