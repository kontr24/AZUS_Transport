
namespace AZUS_Transport.Forms
{
    partial class AuthorizationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationForm));
            this.pMain = new System.Windows.Forms.Panel();
            this.llRegistration = new System.Windows.Forms.LinkLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.cbRemember = new System.Windows.Forms.CheckBox();
            this.btnExtrance = new System.Windows.Forms.Button();
            this.pbPassword = new System.Windows.Forms.PictureBox();
            this.pbLogin = new System.Windows.Forms.PictureBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.llRecover = new System.Windows.Forms.LinkLabel();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lSend = new System.Windows.Forms.Label();
            this.llBack = new System.Windows.Forms.LinkLabel();
            this.pMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // pMain
            // 
            this.pMain.Controls.Add(this.llBack);
            this.pMain.Controls.Add(this.lSend);
            this.pMain.Controls.Add(this.tbEmail);
            this.pMain.Controls.Add(this.llRecover);
            this.pMain.Controls.Add(this.llRegistration);
            this.pMain.Controls.Add(this.pictureBox3);
            this.pMain.Controls.Add(this.cbRemember);
            this.pMain.Controls.Add(this.btnExtrance);
            this.pMain.Controls.Add(this.pbPassword);
            this.pMain.Controls.Add(this.pbLogin);
            this.pMain.Controls.Add(this.tbPassword);
            this.pMain.Controls.Add(this.tbLogin);
            this.pMain.Location = new System.Drawing.Point(7, 6);
            this.pMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(591, 369);
            this.pMain.TabIndex = 0;
            // 
            // llRegistration
            // 
            this.llRegistration.AutoSize = true;
            this.llRegistration.Location = new System.Drawing.Point(399, 267);
            this.llRegistration.Name = "llRegistration";
            this.llRegistration.Size = new System.Drawing.Size(96, 20);
            this.llRegistration.TabIndex = 7;
            this.llRegistration.TabStop = true;
            this.llRegistration.Text = "Регистрация";
            this.llRegistration.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRegistration_LinkClicked);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::AZUS_Transport.Properties.Resources.Cars;
            this.pictureBox3.Location = new System.Drawing.Point(102, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(412, 112);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // cbRemember
            // 
            this.cbRemember.AutoSize = true;
            this.cbRemember.Location = new System.Drawing.Point(131, 297);
            this.cbRemember.Name = "cbRemember";
            this.cbRemember.Size = new System.Drawing.Size(105, 24);
            this.cbRemember.TabIndex = 5;
            this.cbRemember.Text = "Запомнить";
            this.cbRemember.UseVisualStyleBackColor = true;
            this.cbRemember.CheckedChanged += new System.EventHandler(this.cbRemember_CheckedChanged);
            // 
            // btnExtrance
            // 
            this.btnExtrance.BackColor = System.Drawing.Color.Blue;
            this.btnExtrance.FlatAppearance.BorderSize = 0;
            this.btnExtrance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtrance.ForeColor = System.Drawing.Color.White;
            this.btnExtrance.Location = new System.Drawing.Point(354, 297);
            this.btnExtrance.Name = "btnExtrance";
            this.btnExtrance.Size = new System.Drawing.Size(141, 35);
            this.btnExtrance.TabIndex = 4;
            this.btnExtrance.Text = "Вход";
            this.btnExtrance.UseVisualStyleBackColor = false;
            this.btnExtrance.Click += new System.EventHandler(this.btnExtrance_Click);
            // 
            // pbPassword
            // 
            this.pbPassword.Image = ((System.Drawing.Image)(resources.GetObject("pbPassword.Image")));
            this.pbPassword.Location = new System.Drawing.Point(69, 217);
            this.pbPassword.Name = "pbPassword";
            this.pbPassword.Size = new System.Drawing.Size(56, 41);
            this.pbPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPassword.TabIndex = 3;
            this.pbPassword.TabStop = false;
            // 
            // pbLogin
            // 
            this.pbLogin.Image = ((System.Drawing.Image)(resources.GetObject("pbLogin.Image")));
            this.pbLogin.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbLogin.InitialImage")));
            this.pbLogin.Location = new System.Drawing.Point(69, 124);
            this.pbLogin.Name = "pbLogin";
            this.pbLogin.Size = new System.Drawing.Size(56, 41);
            this.pbLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogin.TabIndex = 2;
            this.pbLogin.TabStop = false;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPassword.ForeColor = System.Drawing.Color.Black;
            this.tbPassword.Location = new System.Drawing.Point(131, 217);
            this.tbPassword.Multiline = true;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(364, 41);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.TabStop = false;
            this.tbPassword.Text = "Пароль";
            this.tbPassword.Enter += new System.EventHandler(this.tbPassword_Enter);
            this.tbPassword.Leave += new System.EventHandler(this.tbPassword_Leave);
            // 
            // tbLogin
            // 
            this.tbLogin.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLogin.ForeColor = System.Drawing.Color.Black;
            this.tbLogin.Location = new System.Drawing.Point(131, 124);
            this.tbLogin.Multiline = true;
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(364, 41);
            this.tbLogin.TabIndex = 0;
            this.tbLogin.TabStop = false;
            this.tbLogin.Text = "Логин";
            this.tbLogin.Enter += new System.EventHandler(this.tbLogin_Enter);
            this.tbLogin.Leave += new System.EventHandler(this.tbLogin_Leave);
            // 
            // llRecover
            // 
            this.llRecover.AutoSize = true;
            this.llRecover.Location = new System.Drawing.Point(127, 334);
            this.llRecover.Name = "llRecover";
            this.llRecover.Size = new System.Drawing.Size(154, 20);
            this.llRecover.TabIndex = 8;
            this.llRecover.TabStop = true;
            this.llRecover.Text = "Восстановить доступ";
            this.llRecover.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRecover_LinkClicked);
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbEmail.ForeColor = System.Drawing.Color.Black;
            this.tbEmail.Location = new System.Drawing.Point(131, 170);
            this.tbEmail.Multiline = true;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(364, 41);
            this.tbEmail.TabIndex = 9;
            this.tbEmail.TabStop = false;
            this.tbEmail.Text = "ivanov78@niiar.ru ";
            this.tbEmail.Visible = false;
            this.tbEmail.Enter += new System.EventHandler(this.tbEmail_Enter);
            this.tbEmail.Leave += new System.EventHandler(this.tbEmail_Leave);
            // 
            // lSend
            // 
            this.lSend.AutoSize = true;
            this.lSend.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lSend.Location = new System.Drawing.Point(126, 142);
            this.lSend.Name = "lSend";
            this.lSend.Size = new System.Drawing.Size(325, 25);
            this.lSend.TabIndex = 10;
            this.lSend.Text = "Отправить логин и пароль на почту";
            this.lSend.Visible = false;
            // 
            // llBack
            // 
            this.llBack.AutoSize = true;
            this.llBack.Location = new System.Drawing.Point(127, 214);
            this.llBack.Name = "llBack";
            this.llBack.Size = new System.Drawing.Size(68, 20);
            this.llBack.TabIndex = 11;
            this.llBack.TabStop = true;
            this.llBack.Text = "← Назад";
            this.llBack.Visible = false;
            this.llBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llBack_LinkClicked);
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(603, 378);
            this.Controls.Add(this.pMain);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthorizationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.AuthorizationForm_Load);
            this.pMain.ResumeLayout(false);
            this.pMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.PictureBox pbPassword;
        private System.Windows.Forms.PictureBox pbLogin;
        private System.Windows.Forms.Button btnExtrance;
        private System.Windows.Forms.CheckBox cbRemember;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.LinkLabel llRegistration;
        private System.Windows.Forms.LinkLabel llRecover;
        private System.Windows.Forms.Label lSend;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.LinkLabel llBack;
    }
}