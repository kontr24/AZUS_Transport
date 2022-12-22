
namespace AZUS_Transport.OtherForms
{
    partial class InsertUpdateCarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertUpdateCarForm));
            this.pMain = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lCarPhoto = new System.Windows.Forms.Label();
            this.lTransportType = new System.Windows.Forms.Label();
            this.pTypeCar = new System.Windows.Forms.Panel();
            this.cbTransportType = new System.Windows.Forms.ComboBox();
            this.bsTypeCarView = new System.Windows.Forms.BindingSource(this.components);
            this.btnChange = new System.Windows.Forms.Button();
            this.tbTypeCar = new System.Windows.Forms.TextBox();
            this.pModelCar = new System.Windows.Forms.Panel();
            this.cbTransportModel = new System.Windows.Forms.ComboBox();
            this.bsModelCarView = new System.Windows.Forms.BindingSource(this.components);
            this.btnModelCarDelete = new System.Windows.Forms.Button();
            this.tbModelCarChange = new System.Windows.Forms.TextBox();
            this.btnModelCarAdd = new System.Windows.Forms.Button();
            this.btnModelCarChange = new System.Windows.Forms.Button();
            this.tbModelCarAdd = new System.Windows.Forms.TextBox();
            this.btnChoosePhoto = new System.Windows.Forms.Button();
            this.pbCar = new System.Windows.Forms.PictureBox();
            this.btnDeclineInsertUpdateCar = new System.Windows.Forms.Button();
            this.btnInsertUpdateCar = new System.Windows.Forms.Button();
            this.lStatus = new System.Windows.Forms.Label();
            this.rbStatusNotAvailable = new System.Windows.Forms.RadioButton();
            this.rbStatusAvailable = new System.Windows.Forms.RadioButton();
            this.lRegisterSign = new System.Windows.Forms.Label();
            this.tbRegisterSign = new System.Windows.Forms.TextBox();
            this.lTransportModel = new System.Windows.Forms.Label();
            this.pMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pTypeCar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTypeCarView)).BeginInit();
            this.pModelCar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsModelCarView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCar)).BeginInit();
            this.SuspendLayout();
            // 
            // pMain
            // 
            this.pMain.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.pMain.Controls.Add(this.pictureBox1);
            this.pMain.Controls.Add(this.lCarPhoto);
            this.pMain.Controls.Add(this.lTransportType);
            this.pMain.Controls.Add(this.pTypeCar);
            this.pMain.Controls.Add(this.pModelCar);
            this.pMain.Controls.Add(this.btnChoosePhoto);
            this.pMain.Controls.Add(this.pbCar);
            this.pMain.Controls.Add(this.btnDeclineInsertUpdateCar);
            this.pMain.Controls.Add(this.btnInsertUpdateCar);
            this.pMain.Controls.Add(this.lStatus);
            this.pMain.Controls.Add(this.rbStatusNotAvailable);
            this.pMain.Controls.Add(this.rbStatusAvailable);
            this.pMain.Controls.Add(this.lRegisterSign);
            this.pMain.Controls.Add(this.tbRegisterSign);
            this.pMain.Controls.Add(this.lTransportModel);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(879, 427);
            this.pMain.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(448, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // lCarPhoto
            // 
            this.lCarPhoto.AutoSize = true;
            this.lCarPhoto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCarPhoto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lCarPhoto.Location = new System.Drawing.Point(484, 9);
            this.lCarPhoto.Name = "lCarPhoto";
            this.lCarPhoto.Size = new System.Drawing.Size(47, 20);
            this.lCarPhoto.TabIndex = 55;
            this.lCarPhoto.Text = "Фото";
            // 
            // lTransportType
            // 
            this.lTransportType.AutoSize = true;
            this.lTransportType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTransportType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lTransportType.Location = new System.Drawing.Point(19, 9);
            this.lTransportType.Name = "lTransportType";
            this.lTransportType.Size = new System.Drawing.Size(121, 20);
            this.lTransportType.TabIndex = 34;
            this.lTransportType.Text = "Тип транспорта";
            // 
            // pTypeCar
            // 
            this.pTypeCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTypeCar.Controls.Add(this.cbTransportType);
            this.pTypeCar.Controls.Add(this.btnChange);
            this.pTypeCar.Controls.Add(this.tbTypeCar);
            this.pTypeCar.Location = new System.Drawing.Point(23, 32);
            this.pTypeCar.Name = "pTypeCar";
            this.pTypeCar.Size = new System.Drawing.Size(404, 86);
            this.pTypeCar.TabIndex = 54;
            // 
            // cbTransportType
            // 
            this.cbTransportType.DataSource = this.bsTypeCarView;
            this.cbTransportType.DisplayMember = "TypeCar";
            this.cbTransportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransportType.FormattingEnabled = true;
            this.cbTransportType.Location = new System.Drawing.Point(12, 12);
            this.cbTransportType.Name = "cbTransportType";
            this.cbTransportType.Size = new System.Drawing.Size(385, 28);
            this.cbTransportType.TabIndex = 35;
            this.cbTransportType.ValueMember = "Id";
            this.cbTransportType.SelectedIndexChanged += new System.EventHandler(this.cbTransportType_SelectedIndexChanged);
            // 
            // bsTypeCarView
            // 
            this.bsTypeCarView.DataSource = typeof(AZUS_Transport.Models.TypeCarView);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.Blue;
            this.btnChange.FlatAppearance.BorderSize = 0;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.ForeColor = System.Drawing.Color.White;
            this.btnChange.Location = new System.Drawing.Point(301, 46);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(96, 28);
            this.btnChange.TabIndex = 47;
            this.btnChange.Text = "Изменить";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // tbTypeCar
            // 
            this.tbTypeCar.Location = new System.Drawing.Point(12, 46);
            this.tbTypeCar.MaxLength = 50;
            this.tbTypeCar.Name = "tbTypeCar";
            this.tbTypeCar.Size = new System.Drawing.Size(283, 27);
            this.tbTypeCar.TabIndex = 46;
            // 
            // pModelCar
            // 
            this.pModelCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pModelCar.Controls.Add(this.cbTransportModel);
            this.pModelCar.Controls.Add(this.btnModelCarDelete);
            this.pModelCar.Controls.Add(this.tbModelCarChange);
            this.pModelCar.Controls.Add(this.btnModelCarAdd);
            this.pModelCar.Controls.Add(this.btnModelCarChange);
            this.pModelCar.Controls.Add(this.tbModelCarAdd);
            this.pModelCar.Location = new System.Drawing.Point(23, 151);
            this.pModelCar.Name = "pModelCar";
            this.pModelCar.Size = new System.Drawing.Size(404, 125);
            this.pModelCar.TabIndex = 53;
            // 
            // cbTransportModel
            // 
            this.cbTransportModel.DataSource = this.bsModelCarView;
            this.cbTransportModel.DisplayMember = "Model";
            this.cbTransportModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransportModel.FormattingEnabled = true;
            this.cbTransportModel.Location = new System.Drawing.Point(12, 12);
            this.cbTransportModel.Name = "cbTransportModel";
            this.cbTransportModel.Size = new System.Drawing.Size(283, 28);
            this.cbTransportModel.TabIndex = 33;
            this.cbTransportModel.ValueMember = "Id";
            this.cbTransportModel.SelectedIndexChanged += new System.EventHandler(this.cbTransportModel_SelectedIndexChanged);
            // 
            // bsModelCarView
            // 
            this.bsModelCarView.DataSource = typeof(AZUS_Transport.Models.ModelCarView);
            // 
            // btnModelCarDelete
            // 
            this.btnModelCarDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnModelCarDelete.FlatAppearance.BorderSize = 0;
            this.btnModelCarDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModelCarDelete.ForeColor = System.Drawing.Color.White;
            this.btnModelCarDelete.Location = new System.Drawing.Point(301, 12);
            this.btnModelCarDelete.Name = "btnModelCarDelete";
            this.btnModelCarDelete.Size = new System.Drawing.Size(96, 28);
            this.btnModelCarDelete.TabIndex = 52;
            this.btnModelCarDelete.Text = "Удалить";
            this.btnModelCarDelete.UseVisualStyleBackColor = false;
            this.btnModelCarDelete.Click += new System.EventHandler(this.btnModelCarDelete_Click);
            // 
            // tbModelCarChange
            // 
            this.tbModelCarChange.Location = new System.Drawing.Point(12, 46);
            this.tbModelCarChange.MaxLength = 50;
            this.tbModelCarChange.Name = "tbModelCarChange";
            this.tbModelCarChange.Size = new System.Drawing.Size(283, 27);
            this.tbModelCarChange.TabIndex = 48;
            // 
            // btnModelCarAdd
            // 
            this.btnModelCarAdd.BackColor = System.Drawing.Color.Blue;
            this.btnModelCarAdd.FlatAppearance.BorderSize = 0;
            this.btnModelCarAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModelCarAdd.ForeColor = System.Drawing.Color.White;
            this.btnModelCarAdd.Location = new System.Drawing.Point(301, 80);
            this.btnModelCarAdd.Name = "btnModelCarAdd";
            this.btnModelCarAdd.Size = new System.Drawing.Size(96, 28);
            this.btnModelCarAdd.TabIndex = 51;
            this.btnModelCarAdd.Text = "Добавить";
            this.btnModelCarAdd.UseVisualStyleBackColor = false;
            this.btnModelCarAdd.Click += new System.EventHandler(this.btnModelCarAdd_Click);
            // 
            // btnModelCarChange
            // 
            this.btnModelCarChange.BackColor = System.Drawing.Color.Blue;
            this.btnModelCarChange.FlatAppearance.BorderSize = 0;
            this.btnModelCarChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModelCarChange.ForeColor = System.Drawing.Color.White;
            this.btnModelCarChange.Location = new System.Drawing.Point(301, 46);
            this.btnModelCarChange.Name = "btnModelCarChange";
            this.btnModelCarChange.Size = new System.Drawing.Size(96, 28);
            this.btnModelCarChange.TabIndex = 49;
            this.btnModelCarChange.Text = "Изменить";
            this.btnModelCarChange.UseVisualStyleBackColor = false;
            this.btnModelCarChange.Click += new System.EventHandler(this.btnModelCarChange_Click);
            // 
            // tbModelCarAdd
            // 
            this.tbModelCarAdd.ForeColor = System.Drawing.Color.Silver;
            this.tbModelCarAdd.Location = new System.Drawing.Point(12, 80);
            this.tbModelCarAdd.MaxLength = 50;
            this.tbModelCarAdd.Name = "tbModelCarAdd";
            this.tbModelCarAdd.Size = new System.Drawing.Size(283, 27);
            this.tbModelCarAdd.TabIndex = 50;
            this.tbModelCarAdd.TabStop = false;
            this.tbModelCarAdd.Text = "BMW E90 ";
            this.tbModelCarAdd.TextChanged += new System.EventHandler(this.tbModelCarAdd_TextChanged);
            this.tbModelCarAdd.Enter += new System.EventHandler(this.tbModelCarAdd_Enter);
            this.tbModelCarAdd.Leave += new System.EventHandler(this.tbModelCarAdd_Leave);
            // 
            // btnChoosePhoto
            // 
            this.btnChoosePhoto.BackColor = System.Drawing.Color.Blue;
            this.btnChoosePhoto.FlatAppearance.BorderSize = 0;
            this.btnChoosePhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoosePhoto.ForeColor = System.Drawing.Color.White;
            this.btnChoosePhoto.Location = new System.Drawing.Point(730, 307);
            this.btnChoosePhoto.Name = "btnChoosePhoto";
            this.btnChoosePhoto.Size = new System.Drawing.Size(119, 35);
            this.btnChoosePhoto.TabIndex = 45;
            this.btnChoosePhoto.Text = "Выбрать фото";
            this.btnChoosePhoto.UseVisualStyleBackColor = false;
            this.btnChoosePhoto.Click += new System.EventHandler(this.btnChoosePhoto_Click);
            // 
            // pbCar
            // 
            this.pbCar.Location = new System.Drawing.Point(448, 32);
            this.pbCar.Name = "pbCar";
            this.pbCar.Size = new System.Drawing.Size(401, 269);
            this.pbCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCar.TabIndex = 44;
            this.pbCar.TabStop = false;
            // 
            // btnDeclineInsertUpdateCar
            // 
            this.btnDeclineInsertUpdateCar.BackColor = System.Drawing.Color.Crimson;
            this.btnDeclineInsertUpdateCar.FlatAppearance.BorderSize = 0;
            this.btnDeclineInsertUpdateCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeclineInsertUpdateCar.ForeColor = System.Drawing.Color.White;
            this.btnDeclineInsertUpdateCar.Location = new System.Drawing.Point(730, 380);
            this.btnDeclineInsertUpdateCar.Name = "btnDeclineInsertUpdateCar";
            this.btnDeclineInsertUpdateCar.Size = new System.Drawing.Size(119, 35);
            this.btnDeclineInsertUpdateCar.TabIndex = 43;
            this.btnDeclineInsertUpdateCar.Text = "Отмена";
            this.btnDeclineInsertUpdateCar.UseVisualStyleBackColor = false;
            this.btnDeclineInsertUpdateCar.Click += new System.EventHandler(this.btnDeclineInsertUpdateCar_Click);
            // 
            // btnInsertUpdateCar
            // 
            this.btnInsertUpdateCar.BackColor = System.Drawing.Color.Blue;
            this.btnInsertUpdateCar.FlatAppearance.BorderSize = 0;
            this.btnInsertUpdateCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertUpdateCar.ForeColor = System.Drawing.Color.White;
            this.btnInsertUpdateCar.Location = new System.Drawing.Point(605, 380);
            this.btnInsertUpdateCar.Name = "btnInsertUpdateCar";
            this.btnInsertUpdateCar.Size = new System.Drawing.Size(119, 35);
            this.btnInsertUpdateCar.TabIndex = 42;
            this.btnInsertUpdateCar.Text = "OK";
            this.btnInsertUpdateCar.UseVisualStyleBackColor = false;
            this.btnInsertUpdateCar.Click += new System.EventHandler(this.btnInsertUpdateCar_Click);
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lStatus.Location = new System.Drawing.Point(19, 338);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(55, 20);
            this.lStatus.TabIndex = 40;
            this.lStatus.Text = "Статус";
            // 
            // rbStatusNotAvailable
            // 
            this.rbStatusNotAvailable.AutoSize = true;
            this.rbStatusNotAvailable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbStatusNotAvailable.Location = new System.Drawing.Point(21, 391);
            this.rbStatusNotAvailable.Name = "rbStatusNotAvailable";
            this.rbStatusNotAvailable.Size = new System.Drawing.Size(117, 24);
            this.rbStatusNotAvailable.TabIndex = 39;
            this.rbStatusNotAvailable.TabStop = true;
            this.rbStatusNotAvailable.Text = "Нет на месте";
            this.rbStatusNotAvailable.UseVisualStyleBackColor = true;
            // 
            // rbStatusAvailable
            // 
            this.rbStatusAvailable.AutoSize = true;
            this.rbStatusAvailable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbStatusAvailable.Location = new System.Drawing.Point(23, 361);
            this.rbStatusAvailable.Name = "rbStatusAvailable";
            this.rbStatusAvailable.Size = new System.Drawing.Size(92, 24);
            this.rbStatusAvailable.TabIndex = 38;
            this.rbStatusAvailable.TabStop = true;
            this.rbStatusAvailable.Text = "Доступна";
            this.rbStatusAvailable.UseVisualStyleBackColor = true;
            // 
            // lRegisterSign
            // 
            this.lRegisterSign.AutoSize = true;
            this.lRegisterSign.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lRegisterSign.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lRegisterSign.Location = new System.Drawing.Point(19, 279);
            this.lRegisterSign.Name = "lRegisterSign";
            this.lRegisterSign.Size = new System.Drawing.Size(87, 20);
            this.lRegisterSign.TabIndex = 37;
            this.lRegisterSign.Text = "Гос. номер";
            // 
            // tbRegisterSign
            // 
            this.tbRegisterSign.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbRegisterSign.Location = new System.Drawing.Point(23, 302);
            this.tbRegisterSign.MaxLength = 30;
            this.tbRegisterSign.Name = "tbRegisterSign";
            this.tbRegisterSign.Size = new System.Drawing.Size(296, 27);
            this.tbRegisterSign.TabIndex = 36;
            this.tbRegisterSign.TabStop = false;
            this.tbRegisterSign.TextChanged += new System.EventHandler(this.tbRegisterSign_TextChanged);
            this.tbRegisterSign.Enter += new System.EventHandler(this.tbRegisterSign_Enter);
            this.tbRegisterSign.Leave += new System.EventHandler(this.tbRegisterSign_Leave);
            // 
            // lTransportModel
            // 
            this.lTransportModel.AutoSize = true;
            this.lTransportModel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTransportModel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lTransportModel.Location = new System.Drawing.Point(19, 128);
            this.lTransportModel.Name = "lTransportModel";
            this.lTransportModel.Size = new System.Drawing.Size(66, 20);
            this.lTransportModel.TabIndex = 32;
            this.lTransportModel.Text = "Модель";
            // 
            // InsertUpdateCarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(879, 427);
            this.Controls.Add(this.pMain);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertUpdateCarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InsertUpdateCarForm";
            this.Load += new System.EventHandler(this.InsertUpdateCarForm_Load);
            this.pMain.ResumeLayout(false);
            this.pMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pTypeCar.ResumeLayout(false);
            this.pTypeCar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTypeCarView)).EndInit();
            this.pModelCar.ResumeLayout(false);
            this.pModelCar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsModelCarView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.ComboBox cbTransportType;
        private System.Windows.Forms.Label lTransportType;
        private System.Windows.Forms.ComboBox cbTransportModel;
        private System.Windows.Forms.Label lTransportModel;
        private System.Windows.Forms.TextBox tbRegisterSign;
        private System.Windows.Forms.Label lRegisterSign;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.RadioButton rbStatusNotAvailable;
        private System.Windows.Forms.RadioButton rbStatusAvailable;
        private System.Windows.Forms.Button btnDeclineInsertUpdateCar;
        private System.Windows.Forms.Button btnInsertUpdateCar;
        private System.Windows.Forms.BindingSource bsTypeCarView;
        private System.Windows.Forms.BindingSource bsModelCarView;
        private System.Windows.Forms.PictureBox pbCar;
        private System.Windows.Forms.Button btnChoosePhoto;
        private System.Windows.Forms.TextBox tbTypeCar;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnModelCarAdd;
        private System.Windows.Forms.TextBox tbModelCarAdd;
        private System.Windows.Forms.Button btnModelCarChange;
        private System.Windows.Forms.TextBox tbModelCarChange;
        private System.Windows.Forms.Button btnModelCarDelete;
        private System.Windows.Forms.Panel pTypeCar;
        private System.Windows.Forms.Panel pModelCar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lCarPhoto;
    }
}