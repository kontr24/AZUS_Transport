
namespace AZUS_Transport.Forms
{
    partial class TransportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransportForm));
            this.transportUserControl1 = new AZUS_Transport.MyUserControl.TransportUserControl();
            this.SuspendLayout();
            // 
            // transportUserControl1
            // 
            this.transportUserControl1.BackColor = System.Drawing.Color.White;
            this.transportUserControl1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.transportUserControl1.Location = new System.Drawing.Point(5, 7);
            this.transportUserControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.transportUserControl1.Name = "transportUserControl1";
            this.transportUserControl1.Size = new System.Drawing.Size(1101, 548);
            this.transportUserControl1.TabIndex = 0;
            // 
            // TransportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1113, 559);
            this.Controls.Add(this.transportUserControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Транспорт";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransportForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private MyUserControl.TransportUserControl transportUserControl1;
    }
}