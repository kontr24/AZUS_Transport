
namespace AZUS_Transport.OtherForms
{
    partial class CreateCarsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateCarsForm));
            this.applicationsTableAdapter1 = new AZUS_Transport.ASUZ_Transport_DBDataSet1TableAdapters.ApplicationsTableAdapter();
            this.cbTypeCars = new System.Windows.Forms.ComboBox();
            this.bsTypeCarView = new System.Windows.Forms.BindingSource(this.components);
            this.pCreateCars = new System.Windows.Forms.Panel();
            this.lNoCarStamp = new System.Windows.Forms.Label();
            this.lNoCarRegisterSign = new System.Windows.Forms.Label();
            this.lSelectedCar = new System.Windows.Forms.Label();
            this.btnСancellation = new System.Windows.Forms.Button();
            this.lCarPhoto = new System.Windows.Forms.Label();
            this.lRegisterSign = new System.Windows.Forms.Label();
            this.lType = new System.Windows.Forms.Label();
            this.lStamp = new System.Windows.Forms.Label();
            this.pbCar = new System.Windows.Forms.PictureBox();
            this.lbCarView = new System.Windows.Forms.ListBox();
            this.bsCarModelView = new System.Windows.Forms.BindingSource(this.components);
            this.lbModelCarView = new System.Windows.Forms.ListBox();
            this.bsCarView = new System.Windows.Forms.BindingSource(this.components);
            this.btnChoose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsTypeCarView)).BeginInit();
            this.pCreateCars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCarModelView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCarView)).BeginInit();
            this.SuspendLayout();
            // 
            // applicationsTableAdapter1
            // 
            this.applicationsTableAdapter1.ClearBeforeFill = true;
            // 
            // cbTypeCars
            // 
            this.cbTypeCars.DataSource = this.bsTypeCarView;
            this.cbTypeCars.DisplayMember = "TypeCar";
            this.cbTypeCars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeCars.Enabled = false;
            this.cbTypeCars.FormattingEnabled = true;
            this.cbTypeCars.Location = new System.Drawing.Point(16, 55);
            this.cbTypeCars.Name = "cbTypeCars";
            this.cbTypeCars.Size = new System.Drawing.Size(360, 28);
            this.cbTypeCars.TabIndex = 20;
            this.cbTypeCars.ValueMember = "Id";
            // 
            // bsTypeCarView
            // 
            this.bsTypeCarView.DataSource = typeof(AZUS_Transport.Models.TypeCarView);
            // 
            // pCreateCars
            // 
            this.pCreateCars.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.pCreateCars.Controls.Add(this.lNoCarStamp);
            this.pCreateCars.Controls.Add(this.lNoCarRegisterSign);
            this.pCreateCars.Controls.Add(this.lSelectedCar);
            this.pCreateCars.Controls.Add(this.btnСancellation);
            this.pCreateCars.Controls.Add(this.lCarPhoto);
            this.pCreateCars.Controls.Add(this.lRegisterSign);
            this.pCreateCars.Controls.Add(this.lType);
            this.pCreateCars.Controls.Add(this.lStamp);
            this.pCreateCars.Controls.Add(this.pbCar);
            this.pCreateCars.Controls.Add(this.lbCarView);
            this.pCreateCars.Controls.Add(this.lbModelCarView);
            this.pCreateCars.Controls.Add(this.btnChoose);
            this.pCreateCars.Controls.Add(this.cbTypeCars);
            this.pCreateCars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCreateCars.Location = new System.Drawing.Point(0, 0);
            this.pCreateCars.Name = "pCreateCars";
            this.pCreateCars.Size = new System.Drawing.Size(835, 464);
            this.pCreateCars.TabIndex = 21;
            // 
            // lNoCarStamp
            // 
            this.lNoCarStamp.AutoSize = true;
            this.lNoCarStamp.BackColor = System.Drawing.SystemColors.Window;
            this.lNoCarStamp.Location = new System.Drawing.Point(27, 221);
            this.lNoCarStamp.Name = "lNoCarStamp";
            this.lNoCarStamp.Size = new System.Drawing.Size(133, 60);
            this.lNoCarStamp.TabIndex = 34;
            this.lNoCarStamp.Text = "  Нет доступных \r\n   автомобилей \r\nв данный момент";
            this.lNoCarStamp.Visible = false;
            // 
            // lNoCarRegisterSign
            // 
            this.lNoCarRegisterSign.AutoSize = true;
            this.lNoCarRegisterSign.BackColor = System.Drawing.SystemColors.Window;
            this.lNoCarRegisterSign.Location = new System.Drawing.Point(228, 221);
            this.lNoCarRegisterSign.Name = "lNoCarRegisterSign";
            this.lNoCarRegisterSign.Size = new System.Drawing.Size(133, 60);
            this.lNoCarRegisterSign.TabIndex = 33;
            this.lNoCarRegisterSign.Text = "  Нет доступных \r\n   автомобилей \r\nв данный момент\r\n";
            this.lNoCarRegisterSign.Visible = false;
            // 
            // lSelectedCar
            // 
            this.lSelectedCar.AutoSize = true;
            this.lSelectedCar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lSelectedCar.Location = new System.Drawing.Point(12, 414);
            this.lSelectedCar.Name = "lSelectedCar";
            this.lSelectedCar.Size = new System.Drawing.Size(108, 20);
            this.lSelectedCar.TabIndex = 32;
            this.lSelectedCar.Text = "Вы выбрали: ";
            // 
            // btnСancellation
            // 
            this.btnСancellation.BackColor = System.Drawing.Color.Crimson;
            this.btnСancellation.FlatAppearance.BorderSize = 0;
            this.btnСancellation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnСancellation.ForeColor = System.Drawing.Color.White;
            this.btnСancellation.Location = new System.Drawing.Point(682, 414);
            this.btnСancellation.Name = "btnСancellation";
            this.btnСancellation.Size = new System.Drawing.Size(131, 35);
            this.btnСancellation.TabIndex = 31;
            this.btnСancellation.Text = "Отмена";
            this.btnСancellation.UseVisualStyleBackColor = false;
            this.btnСancellation.Click += new System.EventHandler(this.btnСancellation_Click);
            // 
            // lCarPhoto
            // 
            this.lCarPhoto.AutoSize = true;
            this.lCarPhoto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCarPhoto.Location = new System.Drawing.Point(408, 102);
            this.lCarPhoto.Name = "lCarPhoto";
            this.lCarPhoto.Size = new System.Drawing.Size(51, 20);
            this.lCarPhoto.TabIndex = 30;
            this.lCarPhoto.Text = "ФОТО";
            // 
            // lRegisterSign
            // 
            this.lRegisterSign.AutoSize = true;
            this.lRegisterSign.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lRegisterSign.Location = new System.Drawing.Point(205, 102);
            this.lRegisterSign.Name = "lRegisterSign";
            this.lRegisterSign.Size = new System.Drawing.Size(98, 20);
            this.lRegisterSign.TabIndex = 29;
            this.lRegisterSign.Text = "ГОС. НОМЕР";
            // 
            // lType
            // 
            this.lType.AutoSize = true;
            this.lType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lType.Location = new System.Drawing.Point(12, 32);
            this.lType.Name = "lType";
            this.lType.Size = new System.Drawing.Size(41, 20);
            this.lType.TabIndex = 28;
            this.lType.Text = "ТИП";
            // 
            // lStamp
            // 
            this.lStamp.AutoSize = true;
            this.lStamp.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStamp.Location = new System.Drawing.Point(12, 102);
            this.lStamp.Name = "lStamp";
            this.lStamp.Size = new System.Drawing.Size(64, 20);
            this.lStamp.TabIndex = 27;
            this.lStamp.Text = "МАРКА";
            // 
            // pbCar
            // 
            this.pbCar.Location = new System.Drawing.Point(412, 125);
            this.pbCar.Name = "pbCar";
            this.pbCar.Size = new System.Drawing.Size(401, 264);
            this.pbCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCar.TabIndex = 26;
            this.pbCar.TabStop = false;
            // 
            // lbCarView
            // 
            this.lbCarView.DataSource = this.bsCarModelView;
            this.lbCarView.DisplayMember = "RegisterSign";
            this.lbCarView.FormattingEnabled = true;
            this.lbCarView.ItemHeight = 20;
            this.lbCarView.Location = new System.Drawing.Point(209, 125);
            this.lbCarView.Name = "lbCarView";
            this.lbCarView.Size = new System.Drawing.Size(167, 264);
            this.lbCarView.TabIndex = 25;
            this.lbCarView.ValueMember = "Id";
            this.lbCarView.SelectedIndexChanged += new System.EventHandler(this.lbCarView_SelectedIndexChanged);
            // 
            // bsCarModelView
            // 
            this.bsCarModelView.DataSource = typeof(AZUS_Transport.Models.CarModelView);
            // 
            // lbModelCarView
            // 
            this.lbModelCarView.DataSource = this.bsCarView;
            this.lbModelCarView.DisplayMember = "Model";
            this.lbModelCarView.FormattingEnabled = true;
            this.lbModelCarView.ItemHeight = 20;
            this.lbModelCarView.Location = new System.Drawing.Point(12, 125);
            this.lbModelCarView.Name = "lbModelCarView";
            this.lbModelCarView.Size = new System.Drawing.Size(167, 264);
            this.lbModelCarView.TabIndex = 24;
            this.lbModelCarView.ValueMember = "Id";
            this.lbModelCarView.SelectedIndexChanged += new System.EventHandler(this.lbModelCarView_SelectedIndexChanged);
            // 
            // bsCarView
            // 
            this.bsCarView.DataSource = typeof(AZUS_Transport.Models.CarView);
            // 
            // btnChoose
            // 
            this.btnChoose.BackColor = System.Drawing.Color.Blue;
            this.btnChoose.FlatAppearance.BorderSize = 0;
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoose.ForeColor = System.Drawing.Color.White;
            this.btnChoose.Location = new System.Drawing.Point(545, 414);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(131, 35);
            this.btnChoose.TabIndex = 22;
            this.btnChoose.Text = "Выбрать";
            this.btnChoose.UseVisualStyleBackColor = false;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // CreateCarsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(835, 464);
            this.Controls.Add(this.pCreateCars);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateCarsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateCarsForm";
            this.Load += new System.EventHandler(this.CreateCarsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsTypeCarView)).EndInit();
            this.pCreateCars.ResumeLayout(false);
            this.pCreateCars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCarModelView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCarView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ASUZ_Transport_DBDataSet1TableAdapters.ApplicationsTableAdapter applicationsTableAdapter1;
        private System.Windows.Forms.ComboBox cbTypeCars;
        private System.Windows.Forms.Panel pCreateCars;
        private System.Windows.Forms.BindingSource bsTypeCarView;
        private System.Windows.Forms.BindingSource bsCarModelView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource bsCarView;
        private System.Windows.Forms.ListBox lbModelCarView;
        private System.Windows.Forms.ListBox lbCarView;
        private System.Windows.Forms.PictureBox pbCar;
        private System.Windows.Forms.Label lCarPhoto;
        private System.Windows.Forms.Label lRegisterSign;
        private System.Windows.Forms.Label lType;
        private System.Windows.Forms.Label lStamp;
        private System.Windows.Forms.Button btnСancellation;
        private System.Windows.Forms.Label lSelectedCar;
        private System.Windows.Forms.Label lNoCarStamp;
        private System.Windows.Forms.Label lNoCarRegisterSign;
    }
}