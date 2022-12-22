
namespace AZUS_Transport.OtherForms
{
    partial class TypesReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypesReportForm));
            this.pMain = new System.Windows.Forms.Panel();
            this.btnLssueReport = new System.Windows.Forms.Button();
            this.rbReportDay = new System.Windows.Forms.RadioButton();
            this.rbWeeklyReport = new System.Windows.Forms.RadioButton();
            this.report = new FastReport.Report();
            this.pMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report)).BeginInit();
            this.SuspendLayout();
            // 
            // pMain
            // 
            this.pMain.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.pMain.Controls.Add(this.btnLssueReport);
            this.pMain.Controls.Add(this.rbReportDay);
            this.pMain.Controls.Add(this.rbWeeklyReport);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(475, 141);
            this.pMain.TabIndex = 0;
            // 
            // btnLssueReport
            // 
            this.btnLssueReport.BackColor = System.Drawing.Color.Blue;
            this.btnLssueReport.FlatAppearance.BorderSize = 0;
            this.btnLssueReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLssueReport.ForeColor = System.Drawing.Color.White;
            this.btnLssueReport.Location = new System.Drawing.Point(169, 94);
            this.btnLssueReport.Name = "btnLssueReport";
            this.btnLssueReport.Size = new System.Drawing.Size(161, 35);
            this.btnLssueReport.TabIndex = 24;
            this.btnLssueReport.Text = "Оформить отчёт";
            this.btnLssueReport.UseVisualStyleBackColor = false;
            this.btnLssueReport.Click += new System.EventHandler(this.btnLssueReport_Click);
            // 
            // rbReportDay
            // 
            this.rbReportDay.AutoSize = true;
            this.rbReportDay.Location = new System.Drawing.Point(12, 52);
            this.rbReportDay.Name = "rbReportDay";
            this.rbReportDay.Size = new System.Drawing.Size(125, 24);
            this.rbReportDay.TabIndex = 1;
            this.rbReportDay.TabStop = true;
            this.rbReportDay.Text = "Отчёт за сутки";
            this.rbReportDay.UseVisualStyleBackColor = true;
            // 
            // rbWeeklyReport
            // 
            this.rbWeeklyReport.AutoSize = true;
            this.rbWeeklyReport.Location = new System.Drawing.Point(12, 12);
            this.rbWeeklyReport.Name = "rbWeeklyReport";
            this.rbWeeklyReport.Size = new System.Drawing.Size(142, 24);
            this.rbWeeklyReport.TabIndex = 0;
            this.rbWeeklyReport.TabStop = true;
            this.rbWeeklyReport.Text = "Отчёт за неделю";
            this.rbWeeklyReport.UseVisualStyleBackColor = true;
            // 
            // report
            // 
            this.report.NeedRefresh = false;
            this.report.ReportResourceString = resources.GetString("report.ReportResourceString");
            this.report.Tag = null;
            // 
            // TypesReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 141);
            this.Controls.Add(this.pMain);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TypesReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет за период";
            this.Load += new System.EventHandler(this.TypesReportForm_Load);
            this.pMain.ResumeLayout(false);
            this.pMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.RadioButton rbReportDay;
        private System.Windows.Forms.RadioButton rbWeeklyReport;
        private System.Windows.Forms.Button btnLssueReport;
        private FastReport.Report report;
    }
}