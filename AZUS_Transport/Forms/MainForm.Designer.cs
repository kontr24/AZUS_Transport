
namespace AZUS_Transport.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.niTaskbar = new System.Windows.Forms.NotifyIcon(this.components);
            this.mainUserControl1 = new AZUS_Transport.MyUserControl.MainUserControl();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 4500;
            // 
            // niTaskbar
            // 
            this.niTaskbar.Icon = ((System.Drawing.Icon)(resources.GetObject("niTaskbar.Icon")));
            this.niTaskbar.Text = "АСУЗ \"Транспорт\"";
            this.niTaskbar.Visible = true;
            this.niTaskbar.Click += new System.EventHandler(this.niTaskbar_Click);
            // 
            // mainUserControl1
            // 
            this.mainUserControl1.AutoSize = true;
            this.mainUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainUserControl1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainUserControl1.Location = new System.Drawing.Point(0, 0);
            this.mainUserControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainUserControl1.Name = "mainUserControl1";
            this.mainUserControl1.Size = new System.Drawing.Size(1172, 961);
            this.mainUserControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 961);
            this.Controls.Add(this.mainUserControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АСУЗ \"Транспорт\"";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyUserControl.MainUserControl mainUserControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon niTaskbar;
    }
}