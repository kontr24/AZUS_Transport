
namespace AZUS_Transport.OtherForms
{
    partial class InsertUpdateUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertUpdateUserForm));
            this.bsDivisionView = new System.Windows.Forms.BindingSource(this.components);
            this.pMain = new System.Windows.Forms.Panel();
            this.pNeuteral = new System.Windows.Forms.Panel();
            this.pUser = new System.Windows.Forms.Panel();
            this.pStatus = new System.Windows.Forms.Panel();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.rbEconomist = new System.Windows.Forms.RadioButton();
            this.rbDirector = new System.Windows.Forms.RadioButton();
            this.rbDispatcherATA = new System.Windows.Forms.RadioButton();
            this.rbDispatcherNIIAR = new System.Windows.Forms.RadioButton();
            this.rbDepartment = new System.Windows.Forms.RadioButton();
            this.pDivisionInformation = new System.Windows.Forms.Panel();
            this.btnDivisionAdd = new System.Windows.Forms.Button();
            this.pDivision = new System.Windows.Forms.Panel();
            this.btnDivisionDelete = new System.Windows.Forms.Button();
            this.cbDivision = new System.Windows.Forms.ComboBox();
            this.lBuilding_ = new System.Windows.Forms.Label();
            this.tbDivisionChange = new System.Windows.Forms.TextBox();
            this.tbRoom = new System.Windows.Forms.TextBox();
            this.lDivision_ = new System.Windows.Forms.Label();
            this.lLocation_ = new System.Windows.Forms.Label();
            this.tbBuilding = new System.Windows.Forms.TextBox();
            this.btnDivisionChange = new System.Windows.Forms.Button();
            this.lOrganizationInformation = new System.Windows.Forms.Label();
            this.pMainUser = new System.Windows.Forms.Panel();
            this.lUsername = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lPassword = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.mtbMobilePhone = new System.Windows.Forms.MaskedTextBox();
            this.mtbWorkPhone = new System.Windows.Forms.MaskedTextBox();
            this.lSurName_ = new System.Windows.Forms.Label();
            this.tbPartonymic = new System.Windows.Forms.TextBox();
            this.lPartonymic_ = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lEmail_ = new System.Windows.Forms.Label();
            this.lPost_ = new System.Windows.Forms.Label();
            this.tbPost = new System.Windows.Forms.TextBox();
            this.lWorkPhone_ = new System.Windows.Forms.Label();
            this.lMobilePhone_ = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lName_ = new System.Windows.Forms.Label();
            this.tbSurName = new System.Windows.Forms.TextBox();
            this.lUser = new System.Windows.Forms.Label();
            this.lDirectorAndEconomist = new System.Windows.Forms.Label();
            this.pDirectorAndEconomist = new System.Windows.Forms.Panel();
            this.tbEconomist = new System.Windows.Forms.TextBox();
            this.tbDirector = new System.Windows.Forms.TextBox();
            this.lAttentionNotDirector = new System.Windows.Forms.Label();
            this.lEconomistFullName = new System.Windows.Forms.Label();
            this.lDirectorFullName = new System.Windows.Forms.Label();
            this.lStatus = new System.Windows.Forms.Label();
            this.btnDeclineInsertUpdateUser = new System.Windows.Forms.Button();
            this.btnInsertUpdateUser = new System.Windows.Forms.Button();
            this.bsUserView = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsDivisionView)).BeginInit();
            this.pMain.SuspendLayout();
            this.pNeuteral.SuspendLayout();
            this.pUser.SuspendLayout();
            this.pStatus.SuspendLayout();
            this.pDivisionInformation.SuspendLayout();
            this.pDivision.SuspendLayout();
            this.pMainUser.SuspendLayout();
            this.pDirectorAndEconomist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsUserView)).BeginInit();
            this.SuspendLayout();
            // 
            // bsDivisionView
            // 
            this.bsDivisionView.DataSource = typeof(AZUS_Transport.Models.DivisionView);
            // 
            // pMain
            // 
            this.pMain.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.pMain.Controls.Add(this.pNeuteral);
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(548, 1061);
            this.pMain.TabIndex = 1;
            // 
            // pNeuteral
            // 
            this.pNeuteral.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.pNeuteral.Controls.Add(this.pUser);
            this.pNeuteral.Controls.Add(this.btnDeclineInsertUpdateUser);
            this.pNeuteral.Controls.Add(this.btnInsertUpdateUser);
            this.pNeuteral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pNeuteral.Location = new System.Drawing.Point(0, 0);
            this.pNeuteral.Name = "pNeuteral";
            this.pNeuteral.Size = new System.Drawing.Size(548, 1061);
            this.pNeuteral.TabIndex = 57;
            // 
            // pUser
            // 
            this.pUser.AutoScroll = true;
            this.pUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pUser.Controls.Add(this.pStatus);
            this.pUser.Controls.Add(this.pDivisionInformation);
            this.pUser.Controls.Add(this.lOrganizationInformation);
            this.pUser.Controls.Add(this.pMainUser);
            this.pUser.Controls.Add(this.lUser);
            this.pUser.Controls.Add(this.lDirectorAndEconomist);
            this.pUser.Controls.Add(this.pDirectorAndEconomist);
            this.pUser.Controls.Add(this.lStatus);
            this.pUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.pUser.Location = new System.Drawing.Point(0, 0);
            this.pUser.Name = "pUser";
            this.pUser.Size = new System.Drawing.Size(548, 688);
            this.pUser.TabIndex = 56;
            // 
            // pStatus
            // 
            this.pStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pStatus.Controls.Add(this.rbClient);
            this.pStatus.Controls.Add(this.rbAdmin);
            this.pStatus.Controls.Add(this.rbEconomist);
            this.pStatus.Controls.Add(this.rbDirector);
            this.pStatus.Controls.Add(this.rbDispatcherATA);
            this.pStatus.Controls.Add(this.rbDispatcherNIIAR);
            this.pStatus.Controls.Add(this.rbDepartment);
            this.pStatus.Location = new System.Drawing.Point(11, 892);
            this.pStatus.Name = "pStatus";
            this.pStatus.Size = new System.Drawing.Size(511, 98);
            this.pStatus.TabIndex = 68;
            // 
            // rbClient
            // 
            this.rbClient.AutoSize = true;
            this.rbClient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbClient.Location = new System.Drawing.Point(3, 3);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(76, 24);
            this.rbClient.TabIndex = 55;
            this.rbClient.TabStop = true;
            this.rbClient.Text = "Клиент";
            this.rbClient.UseVisualStyleBackColor = true;
            this.rbClient.CheckedChanged += new System.EventHandler(this.rbClient_CheckedChanged);
            // 
            // rbAdmin
            // 
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbAdmin.Location = new System.Drawing.Point(3, 33);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(137, 24);
            this.rbAdmin.TabIndex = 56;
            this.rbAdmin.TabStop = true;
            this.rbAdmin.Text = "Администратор";
            this.rbAdmin.UseVisualStyleBackColor = true;
            this.rbAdmin.CheckedChanged += new System.EventHandler(this.rbAdmin_CheckedChanged);
            // 
            // rbEconomist
            // 
            this.rbEconomist.AutoSize = true;
            this.rbEconomist.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbEconomist.Location = new System.Drawing.Point(156, 33);
            this.rbEconomist.Name = "rbEconomist";
            this.rbEconomist.Size = new System.Drawing.Size(103, 24);
            this.rbEconomist.TabIndex = 58;
            this.rbEconomist.TabStop = true;
            this.rbEconomist.Text = "Экономист";
            this.rbEconomist.UseVisualStyleBackColor = true;
            this.rbEconomist.CheckedChanged += new System.EventHandler(this.rbEconomist_CheckedChanged);
            // 
            // rbDirector
            // 
            this.rbDirector.AutoSize = true;
            this.rbDirector.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbDirector.Location = new System.Drawing.Point(156, 3);
            this.rbDirector.Name = "rbDirector";
            this.rbDirector.Size = new System.Drawing.Size(122, 24);
            this.rbDirector.TabIndex = 59;
            this.rbDirector.TabStop = true;
            this.rbDirector.Text = "Руководитель";
            this.rbDirector.UseVisualStyleBackColor = true;
            this.rbDirector.CheckedChanged += new System.EventHandler(this.rbDirector_CheckedChanged);
            // 
            // rbDispatcherATA
            // 
            this.rbDispatcherATA.AutoSize = true;
            this.rbDispatcherATA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbDispatcherATA.Location = new System.Drawing.Point(302, 33);
            this.rbDispatcherATA.Name = "rbDispatcherATA";
            this.rbDispatcherATA.Size = new System.Drawing.Size(133, 24);
            this.rbDispatcherATA.TabIndex = 60;
            this.rbDispatcherATA.TabStop = true;
            this.rbDispatcherATA.Text = "Диспетчер АТА";
            this.rbDispatcherATA.UseVisualStyleBackColor = true;
            this.rbDispatcherATA.CheckedChanged += new System.EventHandler(this.rbDispatcherATA_CheckedChanged);
            // 
            // rbDispatcherNIIAR
            // 
            this.rbDispatcherNIIAR.AutoSize = true;
            this.rbDispatcherNIIAR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbDispatcherNIIAR.Location = new System.Drawing.Point(302, 3);
            this.rbDispatcherNIIAR.Name = "rbDispatcherNIIAR";
            this.rbDispatcherNIIAR.Size = new System.Drawing.Size(156, 24);
            this.rbDispatcherNIIAR.TabIndex = 61;
            this.rbDispatcherNIIAR.TabStop = true;
            this.rbDispatcherNIIAR.Text = "Диспетчер НИИАР";
            this.rbDispatcherNIIAR.UseVisualStyleBackColor = true;
            this.rbDispatcherNIIAR.CheckedChanged += new System.EventHandler(this.rbDispatcherNIIAR_CheckedChanged);
            // 
            // rbDepartment
            // 
            this.rbDepartment.AutoSize = true;
            this.rbDepartment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbDepartment.Location = new System.Drawing.Point(3, 63);
            this.rbDepartment.Name = "rbDepartment";
            this.rbDepartment.Size = new System.Drawing.Size(58, 24);
            this.rbDepartment.TabIndex = 62;
            this.rbDepartment.TabStop = true;
            this.rbDepartment.Text = "ДИД";
            this.rbDepartment.UseVisualStyleBackColor = true;
            this.rbDepartment.CheckedChanged += new System.EventHandler(this.rbDepartment_CheckedChanged);
            // 
            // pDivisionInformation
            // 
            this.pDivisionInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDivisionInformation.Controls.Add(this.btnDivisionAdd);
            this.pDivisionInformation.Controls.Add(this.pDivision);
            this.pDivisionInformation.Controls.Add(this.btnDivisionChange);
            this.pDivisionInformation.Location = new System.Drawing.Point(15, 591);
            this.pDivisionInformation.Name = "pDivisionInformation";
            this.pDivisionInformation.Size = new System.Drawing.Size(511, 267);
            this.pDivisionInformation.TabIndex = 67;
            // 
            // btnDivisionAdd
            // 
            this.btnDivisionAdd.BackColor = System.Drawing.Color.Blue;
            this.btnDivisionAdd.FlatAppearance.BorderSize = 0;
            this.btnDivisionAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDivisionAdd.ForeColor = System.Drawing.Color.White;
            this.btnDivisionAdd.Location = new System.Drawing.Point(397, 225);
            this.btnDivisionAdd.Name = "btnDivisionAdd";
            this.btnDivisionAdd.Size = new System.Drawing.Size(96, 28);
            this.btnDivisionAdd.TabIndex = 61;
            this.btnDivisionAdd.Text = "Добавить";
            this.btnDivisionAdd.UseVisualStyleBackColor = false;
            this.btnDivisionAdd.Click += new System.EventHandler(this.btnDivisionAdd_Click);
            // 
            // pDivision
            // 
            this.pDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDivision.Controls.Add(this.btnDivisionDelete);
            this.pDivision.Controls.Add(this.cbDivision);
            this.pDivision.Controls.Add(this.lBuilding_);
            this.pDivision.Controls.Add(this.tbDivisionChange);
            this.pDivision.Controls.Add(this.tbRoom);
            this.pDivision.Controls.Add(this.lDivision_);
            this.pDivision.Controls.Add(this.lLocation_);
            this.pDivision.Controls.Add(this.tbBuilding);
            this.pDivision.Location = new System.Drawing.Point(6, 13);
            this.pDivision.Name = "pDivision";
            this.pDivision.Size = new System.Drawing.Size(500, 206);
            this.pDivision.TabIndex = 59;
            // 
            // btnDivisionDelete
            // 
            this.btnDivisionDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDivisionDelete.FlatAppearance.BorderSize = 0;
            this.btnDivisionDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDivisionDelete.ForeColor = System.Drawing.Color.White;
            this.btnDivisionDelete.Location = new System.Drawing.Point(390, 22);
            this.btnDivisionDelete.Name = "btnDivisionDelete";
            this.btnDivisionDelete.Size = new System.Drawing.Size(96, 28);
            this.btnDivisionDelete.TabIndex = 57;
            this.btnDivisionDelete.Text = "Удалить";
            this.btnDivisionDelete.UseVisualStyleBackColor = false;
            this.btnDivisionDelete.Click += new System.EventHandler(this.btnDivisionDelete_Click);
            // 
            // cbDivision
            // 
            this.cbDivision.DataSource = this.bsDivisionView;
            this.cbDivision.DisplayMember = "Division";
            this.cbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDivision.FormattingEnabled = true;
            this.cbDivision.Location = new System.Drawing.Point(7, 22);
            this.cbDivision.Name = "cbDivision";
            this.cbDivision.Size = new System.Drawing.Size(372, 28);
            this.cbDivision.TabIndex = 53;
            this.cbDivision.ValueMember = "Id";
            this.cbDivision.SelectedIndexChanged += new System.EventHandler(this.cbDivision_SelectedIndexChanged);
            // 
            // lBuilding_
            // 
            this.lBuilding_.AutoSize = true;
            this.lBuilding_.Location = new System.Drawing.Point(3, 87);
            this.lBuilding_.Name = "lBuilding_";
            this.lBuilding_.Size = new System.Drawing.Size(59, 20);
            this.lBuilding_.TabIndex = 9;
            this.lBuilding_.Text = "Здание";
            // 
            // tbDivisionChange
            // 
            this.tbDivisionChange.Location = new System.Drawing.Point(7, 56);
            this.tbDivisionChange.MaxLength = 200;
            this.tbDivisionChange.Name = "tbDivisionChange";
            this.tbDivisionChange.Size = new System.Drawing.Size(479, 27);
            this.tbDivisionChange.TabIndex = 8;
            // 
            // tbRoom
            // 
            this.tbRoom.ForeColor = System.Drawing.Color.Silver;
            this.tbRoom.Location = new System.Drawing.Point(7, 163);
            this.tbRoom.MaxLength = 200;
            this.tbRoom.Name = "tbRoom";
            this.tbRoom.Size = new System.Drawing.Size(478, 27);
            this.tbRoom.TabIndex = 12;
            this.tbRoom.Text = "102 ";
            this.tbRoom.Enter += new System.EventHandler(this.tbRoom_Enter);
            this.tbRoom.Leave += new System.EventHandler(this.tbRoom_Leave);
            // 
            // lDivision_
            // 
            this.lDivision_.AutoSize = true;
            this.lDivision_.Location = new System.Drawing.Point(3, -1);
            this.lDivision_.Name = "lDivision_";
            this.lDivision_.Size = new System.Drawing.Size(119, 20);
            this.lDivision_.TabIndex = 7;
            this.lDivision_.Text = "Подразделение";
            // 
            // lLocation_
            // 
            this.lLocation_.AutoSize = true;
            this.lLocation_.Location = new System.Drawing.Point(3, 140);
            this.lLocation_.Name = "lLocation_";
            this.lLocation_.Size = new System.Drawing.Size(69, 20);
            this.lLocation_.TabIndex = 11;
            this.lLocation_.Text = "Комната";
            // 
            // tbBuilding
            // 
            this.tbBuilding.Location = new System.Drawing.Point(7, 110);
            this.tbBuilding.MaxLength = 200;
            this.tbBuilding.Name = "tbBuilding";
            this.tbBuilding.Size = new System.Drawing.Size(478, 27);
            this.tbBuilding.TabIndex = 10;
            // 
            // btnDivisionChange
            // 
            this.btnDivisionChange.BackColor = System.Drawing.Color.Blue;
            this.btnDivisionChange.FlatAppearance.BorderSize = 0;
            this.btnDivisionChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDivisionChange.ForeColor = System.Drawing.Color.White;
            this.btnDivisionChange.Location = new System.Drawing.Point(295, 225);
            this.btnDivisionChange.Name = "btnDivisionChange";
            this.btnDivisionChange.Size = new System.Drawing.Size(96, 28);
            this.btnDivisionChange.TabIndex = 54;
            this.btnDivisionChange.Text = "Изменить";
            this.btnDivisionChange.UseVisualStyleBackColor = false;
            this.btnDivisionChange.Click += new System.EventHandler(this.btnDivisionChange_Click);
            // 
            // lOrganizationInformation
            // 
            this.lOrganizationInformation.AutoSize = true;
            this.lOrganizationInformation.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lOrganizationInformation.Location = new System.Drawing.Point(11, 568);
            this.lOrganizationInformation.Name = "lOrganizationInformation";
            this.lOrganizationInformation.Size = new System.Drawing.Size(237, 20);
            this.lOrganizationInformation.TabIndex = 66;
            this.lOrganizationInformation.Text = "Информация о подразделении";
            // 
            // pMainUser
            // 
            this.pMainUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pMainUser.Controls.Add(this.lUsername);
            this.pMainUser.Controls.Add(this.tbPassword);
            this.pMainUser.Controls.Add(this.lPassword);
            this.pMainUser.Controls.Add(this.tbUsername);
            this.pMainUser.Controls.Add(this.mtbMobilePhone);
            this.pMainUser.Controls.Add(this.mtbWorkPhone);
            this.pMainUser.Controls.Add(this.lSurName_);
            this.pMainUser.Controls.Add(this.tbPartonymic);
            this.pMainUser.Controls.Add(this.lPartonymic_);
            this.pMainUser.Controls.Add(this.tbEmail);
            this.pMainUser.Controls.Add(this.lEmail_);
            this.pMainUser.Controls.Add(this.lPost_);
            this.pMainUser.Controls.Add(this.tbPost);
            this.pMainUser.Controls.Add(this.lWorkPhone_);
            this.pMainUser.Controls.Add(this.lMobilePhone_);
            this.pMainUser.Controls.Add(this.tbName);
            this.pMainUser.Controls.Add(this.lName_);
            this.pMainUser.Controls.Add(this.tbSurName);
            this.pMainUser.Location = new System.Drawing.Point(15, 51);
            this.pMainUser.Name = "pMainUser";
            this.pMainUser.Size = new System.Drawing.Size(511, 506);
            this.pMainUser.TabIndex = 65;
            // 
            // lUsername
            // 
            this.lUsername.AutoSize = true;
            this.lUsername.Location = new System.Drawing.Point(6, 13);
            this.lUsername.Name = "lUsername";
            this.lUsername.Size = new System.Drawing.Size(52, 20);
            this.lUsername.TabIndex = 73;
            this.lUsername.Text = "Логин";
            // 
            // tbPassword
            // 
            this.tbPassword.ForeColor = System.Drawing.Color.Silver;
            this.tbPassword.Location = new System.Drawing.Point(10, 89);
            this.tbPassword.MaxLength = 50;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(482, 27);
            this.tbPassword.TabIndex = 70;
            this.tbPassword.Text = "7UnR4po3 ";
            this.tbPassword.Enter += new System.EventHandler(this.tbPassword_Enter);
            this.tbPassword.Leave += new System.EventHandler(this.tbPassword_Leave);
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Location = new System.Drawing.Point(6, 66);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(62, 20);
            this.lPassword.TabIndex = 71;
            this.lPassword.Text = "Пароль";
            // 
            // tbUsername
            // 
            this.tbUsername.ForeColor = System.Drawing.Color.Silver;
            this.tbUsername.Location = new System.Drawing.Point(10, 36);
            this.tbUsername.MaxLength = 50;
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(482, 27);
            this.tbUsername.TabIndex = 72;
            this.tbUsername.Text = "petrov1245 ";
            this.tbUsername.TextChanged += new System.EventHandler(this.tbUsername_TextChanged);
            this.tbUsername.Enter += new System.EventHandler(this.tbUsername_Enter);
            this.tbUsername.Leave += new System.EventHandler(this.tbUsername_Leave);
            // 
            // mtbMobilePhone
            // 
            this.mtbMobilePhone.Location = new System.Drawing.Point(10, 464);
            this.mtbMobilePhone.Mask = "+7(999)000-00-00";
            this.mtbMobilePhone.Name = "mtbMobilePhone";
            this.mtbMobilePhone.Size = new System.Drawing.Size(482, 27);
            this.mtbMobilePhone.TabIndex = 69;
            // 
            // mtbWorkPhone
            // 
            this.mtbWorkPhone.Location = new System.Drawing.Point(10, 411);
            this.mtbWorkPhone.Mask = "+7(999-99)0-00-00";
            this.mtbWorkPhone.Name = "mtbWorkPhone";
            this.mtbWorkPhone.Size = new System.Drawing.Size(482, 27);
            this.mtbWorkPhone.TabIndex = 26;
            // 
            // lSurName_
            // 
            this.lSurName_.AutoSize = true;
            this.lSurName_.Location = new System.Drawing.Point(6, 123);
            this.lSurName_.Name = "lSurName_";
            this.lSurName_.Size = new System.Drawing.Size(73, 20);
            this.lSurName_.TabIndex = 20;
            this.lSurName_.Text = "Фамилия";
            // 
            // tbPartonymic
            // 
            this.tbPartonymic.ForeColor = System.Drawing.Color.Silver;
            this.tbPartonymic.Location = new System.Drawing.Point(10, 252);
            this.tbPartonymic.MaxLength = 50;
            this.tbPartonymic.Name = "tbPartonymic";
            this.tbPartonymic.Size = new System.Drawing.Size(482, 27);
            this.tbPartonymic.TabIndex = 1;
            this.tbPartonymic.Text = "Петрович ";
            this.tbPartonymic.Enter += new System.EventHandler(this.tbPartonymic_Enter);
            this.tbPartonymic.Leave += new System.EventHandler(this.tbPartonymic_Leave);
            // 
            // lPartonymic_
            // 
            this.lPartonymic_.AutoSize = true;
            this.lPartonymic_.Location = new System.Drawing.Point(6, 229);
            this.lPartonymic_.Name = "lPartonymic_";
            this.lPartonymic_.Size = new System.Drawing.Size(72, 20);
            this.lPartonymic_.TabIndex = 2;
            this.lPartonymic_.Text = "Отчество";
            // 
            // tbEmail
            // 
            this.tbEmail.ForeColor = System.Drawing.Color.Silver;
            this.tbEmail.Location = new System.Drawing.Point(10, 302);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(482, 27);
            this.tbEmail.TabIndex = 3;
            this.tbEmail.Text = "petrov1990@mail.ru ";
            this.tbEmail.Enter += new System.EventHandler(this.tbEmail_Enter);
            this.tbEmail.Leave += new System.EventHandler(this.tbEmail_Leave);
            // 
            // lEmail_
            // 
            this.lEmail_.AutoSize = true;
            this.lEmail_.Location = new System.Drawing.Point(6, 282);
            this.lEmail_.Name = "lEmail_";
            this.lEmail_.Size = new System.Drawing.Size(52, 20);
            this.lEmail_.TabIndex = 4;
            this.lEmail_.Text = "E-mail";
            // 
            // lPost_
            // 
            this.lPost_.AutoSize = true;
            this.lPost_.Location = new System.Drawing.Point(6, 335);
            this.lPost_.Name = "lPost_";
            this.lPost_.Size = new System.Drawing.Size(86, 20);
            this.lPost_.TabIndex = 5;
            this.lPost_.Text = "Должность";
            // 
            // tbPost
            // 
            this.tbPost.ForeColor = System.Drawing.Color.Silver;
            this.tbPost.Location = new System.Drawing.Point(10, 358);
            this.tbPost.MaxLength = 200;
            this.tbPost.Name = "tbPost";
            this.tbPost.Size = new System.Drawing.Size(482, 27);
            this.tbPost.TabIndex = 6;
            this.tbPost.Text = "Главный инженер ";
            this.tbPost.Enter += new System.EventHandler(this.tbPost_Enter);
            this.tbPost.Leave += new System.EventHandler(this.tbPost_Leave);
            // 
            // lWorkPhone_
            // 
            this.lWorkPhone_.AutoSize = true;
            this.lWorkPhone_.Location = new System.Drawing.Point(6, 388);
            this.lWorkPhone_.Name = "lWorkPhone_";
            this.lWorkPhone_.Size = new System.Drawing.Size(131, 20);
            this.lWorkPhone_.TabIndex = 13;
            this.lWorkPhone_.Text = "Рабочий телефон";
            // 
            // lMobilePhone_
            // 
            this.lMobilePhone_.AutoSize = true;
            this.lMobilePhone_.Location = new System.Drawing.Point(6, 441);
            this.lMobilePhone_.Name = "lMobilePhone_";
            this.lMobilePhone_.Size = new System.Drawing.Size(156, 20);
            this.lMobilePhone_.TabIndex = 16;
            this.lMobilePhone_.Text = "Мобильный телефон";
            // 
            // tbName
            // 
            this.tbName.ForeColor = System.Drawing.Color.Silver;
            this.tbName.Location = new System.Drawing.Point(10, 199);
            this.tbName.MaxLength = 50;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(482, 27);
            this.tbName.TabIndex = 17;
            this.tbName.Text = "Пётр ";
            this.tbName.Enter += new System.EventHandler(this.tbName_Enter);
            this.tbName.Leave += new System.EventHandler(this.tbName_Leave);
            // 
            // lName_
            // 
            this.lName_.AutoSize = true;
            this.lName_.Location = new System.Drawing.Point(6, 176);
            this.lName_.Name = "lName_";
            this.lName_.Size = new System.Drawing.Size(39, 20);
            this.lName_.TabIndex = 18;
            this.lName_.Text = "Имя";
            // 
            // tbSurName
            // 
            this.tbSurName.ForeColor = System.Drawing.Color.Silver;
            this.tbSurName.Location = new System.Drawing.Point(10, 146);
            this.tbSurName.MaxLength = 50;
            this.tbSurName.Name = "tbSurName";
            this.tbSurName.Size = new System.Drawing.Size(482, 27);
            this.tbSurName.TabIndex = 19;
            this.tbSurName.Text = "Петров ";
            this.tbSurName.Enter += new System.EventHandler(this.tbSurName_Enter);
            this.tbSurName.Leave += new System.EventHandler(this.tbSurName_Leave);
            // 
            // lUser
            // 
            this.lUser.AutoSize = true;
            this.lUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lUser.Location = new System.Drawing.Point(11, 28);
            this.lUser.Name = "lUser";
            this.lUser.Size = new System.Drawing.Size(111, 20);
            this.lUser.TabIndex = 56;
            this.lUser.Text = "Пользователь";
            // 
            // lDirectorAndEconomist
            // 
            this.lDirectorAndEconomist.AutoSize = true;
            this.lDirectorAndEconomist.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lDirectorAndEconomist.Location = new System.Drawing.Point(7, 1004);
            this.lDirectorAndEconomist.Name = "lDirectorAndEconomist";
            this.lDirectorAndEconomist.Size = new System.Drawing.Size(205, 20);
            this.lDirectorAndEconomist.TabIndex = 64;
            this.lDirectorAndEconomist.Text = "Руководитель и экономист";
            // 
            // pDirectorAndEconomist
            // 
            this.pDirectorAndEconomist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDirectorAndEconomist.Controls.Add(this.tbEconomist);
            this.pDirectorAndEconomist.Controls.Add(this.tbDirector);
            this.pDirectorAndEconomist.Controls.Add(this.lAttentionNotDirector);
            this.pDirectorAndEconomist.Controls.Add(this.lEconomistFullName);
            this.pDirectorAndEconomist.Controls.Add(this.lDirectorFullName);
            this.pDirectorAndEconomist.Location = new System.Drawing.Point(11, 1028);
            this.pDirectorAndEconomist.Name = "pDirectorAndEconomist";
            this.pDirectorAndEconomist.Size = new System.Drawing.Size(511, 190);
            this.pDirectorAndEconomist.TabIndex = 63;
            // 
            // tbEconomist
            // 
            this.tbEconomist.Enabled = false;
            this.tbEconomist.Location = new System.Drawing.Point(7, 145);
            this.tbEconomist.Name = "tbEconomist";
            this.tbEconomist.Size = new System.Drawing.Size(486, 27);
            this.tbEconomist.TabIndex = 70;
            // 
            // tbDirector
            // 
            this.tbDirector.Enabled = false;
            this.tbDirector.Location = new System.Drawing.Point(7, 81);
            this.tbDirector.Name = "tbDirector";
            this.tbDirector.Size = new System.Drawing.Size(486, 27);
            this.tbDirector.TabIndex = 69;
            // 
            // lAttentionNotDirector
            // 
            this.lAttentionNotDirector.AutoSize = true;
            this.lAttentionNotDirector.ForeColor = System.Drawing.Color.Red;
            this.lAttentionNotDirector.Location = new System.Drawing.Point(8, 9);
            this.lAttentionNotDirector.Name = "lAttentionNotDirector";
            this.lAttentionNotDirector.Size = new System.Drawing.Size(455, 40);
            this.lAttentionNotDirector.TabIndex = 64;
            this.lAttentionNotDirector.Text = "Внимание! Если руководитель или экономист не отображается,\r\nто предупредите об эт" +
    "ом администратора!";
            // 
            // lEconomistFullName
            // 
            this.lEconomistFullName.AutoSize = true;
            this.lEconomistFullName.Location = new System.Drawing.Point(3, 122);
            this.lEconomistFullName.Name = "lEconomistFullName";
            this.lEconomistFullName.Size = new System.Drawing.Size(141, 20);
            this.lEconomistFullName.TabIndex = 18;
            this.lEconomistFullName.Text = "Ф.И.О.  экономиста";
            // 
            // lDirectorFullName
            // 
            this.lDirectorFullName.AutoSize = true;
            this.lDirectorFullName.Location = new System.Drawing.Point(3, 58);
            this.lDirectorFullName.Name = "lDirectorFullName";
            this.lDirectorFullName.Size = new System.Drawing.Size(155, 20);
            this.lDirectorFullName.TabIndex = 17;
            this.lDirectorFullName.Text = "Ф.И.О.  руководителя";
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lStatus.Location = new System.Drawing.Point(7, 869);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(55, 20);
            this.lStatus.TabIndex = 57;
            this.lStatus.Text = "Статус";
            // 
            // btnDeclineInsertUpdateUser
            // 
            this.btnDeclineInsertUpdateUser.BackColor = System.Drawing.Color.Crimson;
            this.btnDeclineInsertUpdateUser.FlatAppearance.BorderSize = 0;
            this.btnDeclineInsertUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeclineInsertUpdateUser.ForeColor = System.Drawing.Color.White;
            this.btnDeclineInsertUpdateUser.Location = new System.Drawing.Point(282, 710);
            this.btnDeclineInsertUpdateUser.Name = "btnDeclineInsertUpdateUser";
            this.btnDeclineInsertUpdateUser.Size = new System.Drawing.Size(119, 35);
            this.btnDeclineInsertUpdateUser.TabIndex = 45;
            this.btnDeclineInsertUpdateUser.Text = "Отмена";
            this.btnDeclineInsertUpdateUser.UseVisualStyleBackColor = false;
            this.btnDeclineInsertUpdateUser.Click += new System.EventHandler(this.btnDeclineInsertUpdateUser_Click);
            // 
            // btnInsertUpdateUser
            // 
            this.btnInsertUpdateUser.BackColor = System.Drawing.Color.Blue;
            this.btnInsertUpdateUser.FlatAppearance.BorderSize = 0;
            this.btnInsertUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertUpdateUser.ForeColor = System.Drawing.Color.White;
            this.btnInsertUpdateUser.Location = new System.Drawing.Point(157, 710);
            this.btnInsertUpdateUser.Name = "btnInsertUpdateUser";
            this.btnInsertUpdateUser.Size = new System.Drawing.Size(119, 35);
            this.btnInsertUpdateUser.TabIndex = 44;
            this.btnInsertUpdateUser.Text = "OK";
            this.btnInsertUpdateUser.UseVisualStyleBackColor = false;
            this.btnInsertUpdateUser.Click += new System.EventHandler(this.btnInsertUpdateUser_Click);
            // 
            // bsUserView
            // 
            this.bsUserView.DataSource = typeof(AZUS_Transport.Models.UserView);
            // 
            // InsertUpdateUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(548, 758);
            this.Controls.Add(this.pMain);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertUpdateUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InsertUpdateUserForm";
            this.Load += new System.EventHandler(this.InsertUpdateUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsDivisionView)).EndInit();
            this.pMain.ResumeLayout(false);
            this.pNeuteral.ResumeLayout(false);
            this.pUser.ResumeLayout(false);
            this.pUser.PerformLayout();
            this.pStatus.ResumeLayout(false);
            this.pStatus.PerformLayout();
            this.pDivisionInformation.ResumeLayout(false);
            this.pDivision.ResumeLayout(false);
            this.pDivision.PerformLayout();
            this.pMainUser.ResumeLayout(false);
            this.pMainUser.PerformLayout();
            this.pDirectorAndEconomist.ResumeLayout(false);
            this.pDirectorAndEconomist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsUserView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bsDivisionView;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Panel pNeuteral;
        private System.Windows.Forms.Button btnDeclineInsertUpdateUser;
        private System.Windows.Forms.Button btnInsertUpdateUser;
        private System.Windows.Forms.Panel pUser;
        private System.Windows.Forms.Label lUser;
        private System.Windows.Forms.Label lDirectorAndEconomist;
        private System.Windows.Forms.Panel pDirectorAndEconomist;
        private System.Windows.Forms.Label lEconomistFullName;
        private System.Windows.Forms.Label lDirectorFullName;
        private System.Windows.Forms.RadioButton rbDepartment;
        private System.Windows.Forms.RadioButton rbDispatcherNIIAR;
        private System.Windows.Forms.RadioButton rbDispatcherATA;
        private System.Windows.Forms.RadioButton rbDirector;
        private System.Windows.Forms.RadioButton rbEconomist;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.RadioButton rbAdmin;
        private System.Windows.Forms.RadioButton rbClient;
        private System.Windows.Forms.Button btnDivisionDelete;
        private System.Windows.Forms.ComboBox cbDivision;
        private System.Windows.Forms.TextBox tbDivisionChange;
        private System.Windows.Forms.Button btnDivisionChange;
        private System.Windows.Forms.Label lSurName_;
        private System.Windows.Forms.TextBox tbSurName;
        private System.Windows.Forms.Label lName_;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lMobilePhone_;
        private System.Windows.Forms.TextBox tbRoom;
        private System.Windows.Forms.Label lWorkPhone_;
        private System.Windows.Forms.TextBox tbPost;
        private System.Windows.Forms.Label lLocation_;
        private System.Windows.Forms.Label lPost_;
        private System.Windows.Forms.Label lEmail_;
        private System.Windows.Forms.TextBox tbBuilding;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lPartonymic_;
        private System.Windows.Forms.Label lBuilding_;
        private System.Windows.Forms.TextBox tbPartonymic;
        private System.Windows.Forms.Label lDivision_;
        private System.Windows.Forms.Panel pMainUser;
        private System.Windows.Forms.Label lOrganizationInformation;
        private System.Windows.Forms.Panel pDivisionInformation;
        private System.Windows.Forms.Panel pDivision;
        private System.Windows.Forms.Button btnDivisionAdd;
        private System.Windows.Forms.Panel pStatus;
        private System.Windows.Forms.MaskedTextBox mtbMobilePhone;
        private System.Windows.Forms.MaskedTextBox mtbWorkPhone;
        private System.Windows.Forms.BindingSource bsUserView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn divisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lAttentionNotDirector;
        private System.Windows.Forms.TextBox tbEconomist;
        private System.Windows.Forms.TextBox tbDirector;
    }
}