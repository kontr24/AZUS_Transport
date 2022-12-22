
namespace AZUS_Transport.MyUserControl
{
    partial class UserUserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserUserControl));
            this.tsbFunctionUser = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdateUser = new System.Windows.Forms.ToolStripButton();
            this.tsbInsertUser = new System.Windows.Forms.ToolStripButton();
            this.tUserView = new System.Windows.Forms.Timer(this.components);
            this.tsbDeleteUser = new System.Windows.Forms.ToolStripButton();
            this.pFilters = new System.Windows.Forms.Panel();
            this.cbSearchStatusUser = new System.Windows.Forms.ComboBox();
            this.cbSortUser = new System.Windows.Forms.ComboBox();
            this.lSortCar = new System.Windows.Forms.Label();
            this.mtbSearchUser = new System.Windows.Forms.MaskedTextBox();
            this.cbSearchUser = new System.Windows.Forms.ComboBox();
            this.lSearchUser = new System.Windows.Forms.Label();
            this.tsUser = new System.Windows.Forms.ToolStrip();
            this.dgvUserView = new System.Windows.Forms.DataGridView();
            this.bsUserView = new System.Windows.Forms.BindingSource(this.components);
            this.pMain = new System.Windows.Forms.Panel();
            this.pMainTwo = new System.Windows.Forms.Panel();
            this.lUserNotFound = new System.Windows.Forms.Label();
            this.pMainUser = new System.Windows.Forms.Panel();
            this.pUserInformation = new System.Windows.Forms.Panel();
            this.lPassword = new System.Windows.Forms.Label();
            this.lUsername = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lEconomistFullName = new System.Windows.Forms.Label();
            this.lDirectorFullName = new System.Windows.Forms.Label();
            this.lDirectorAndEconomist = new System.Windows.Forms.Label();
            this.pDirectorAndEconomist = new System.Windows.Forms.Panel();
            this.lEconomistFullName_ = new System.Windows.Forms.Label();
            this.lDirectorFullName_ = new System.Windows.Forms.Label();
            this.pUser = new System.Windows.Forms.Panel();
            this.lPassword_ = new System.Windows.Forms.Label();
            this.lUsername_ = new System.Windows.Forms.Label();
            this.lMobilePhone_ = new System.Windows.Forms.Label();
            this.lWorkPhone_ = new System.Windows.Forms.Label();
            this.lRoom_ = new System.Windows.Forms.Label();
            this.lBuilding_ = new System.Windows.Forms.Label();
            this.lDivision_ = new System.Windows.Forms.Label();
            this.lPost_ = new System.Windows.Forms.Label();
            this.lEmail_ = new System.Windows.Forms.Label();
            this.lUser_ = new System.Windows.Forms.Label();
            this.lMobilePhone = new System.Windows.Forms.Label();
            this.lWorkPhone = new System.Windows.Forms.Label();
            this.lRoom = new System.Windows.Forms.Label();
            this.lBuilding = new System.Windows.Forms.Label();
            this.lPost = new System.Windows.Forms.Label();
            this.lEmail = new System.Windows.Forms.Label();
            this.lUser = new System.Windows.Forms.Label();
            this.lDivision = new System.Windows.Forms.Label();
            this.lUserInformation = new System.Windows.Forms.Label();
            this.pbClient = new System.Windows.Forms.PictureBox();
            this.lStatusUser = new System.Windows.Forms.Label();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.divisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobilePhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pFilters.SuspendLayout();
            this.tsUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUserView)).BeginInit();
            this.pMain.SuspendLayout();
            this.pMainTwo.SuspendLayout();
            this.pMainUser.SuspendLayout();
            this.pUserInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pDirectorAndEconomist.SuspendLayout();
            this.pUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClient)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbFunctionUser
            // 
            this.tsbFunctionUser.ForeColor = System.Drawing.Color.White;
            this.tsbFunctionUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbFunctionUser.Image")));
            this.tsbFunctionUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFunctionUser.Name = "tsbFunctionUser";
            this.tsbFunctionUser.Size = new System.Drawing.Size(159, 24);
            this.tsbFunctionUser.Text = "Поиск/сортировка";
            this.tsbFunctionUser.Click += new System.EventHandler(this.tsbFunctionUser_Click);
            // 
            // tsbUpdateUser
            // 
            this.tsbUpdateUser.ForeColor = System.Drawing.Color.White;
            this.tsbUpdateUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdateUser.Image")));
            this.tsbUpdateUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdateUser.Name = "tsbUpdateUser";
            this.tsbUpdateUser.Size = new System.Drawing.Size(131, 24);
            this.tsbUpdateUser.Text = "Редактировать";
            this.tsbUpdateUser.Click += new System.EventHandler(this.tsbUpdateUser_Click);
            // 
            // tsbInsertUser
            // 
            this.tsbInsertUser.ForeColor = System.Drawing.Color.White;
            this.tsbInsertUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbInsertUser.Image")));
            this.tsbInsertUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertUser.Name = "tsbInsertUser";
            this.tsbInsertUser.Size = new System.Drawing.Size(96, 24);
            this.tsbInsertUser.Text = "Добавить";
            this.tsbInsertUser.Click += new System.EventHandler(this.tsbInsertUser_Click);
            // 
            // tUserView
            // 
            this.tUserView.Enabled = true;
            this.tUserView.Interval = 10000;
            this.tUserView.Tick += new System.EventHandler(this.tUserView_Tick);
            // 
            // tsbDeleteUser
            // 
            this.tsbDeleteUser.ForeColor = System.Drawing.Color.White;
            this.tsbDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteUser.Image")));
            this.tsbDeleteUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteUser.Name = "tsbDeleteUser";
            this.tsbDeleteUser.Size = new System.Drawing.Size(85, 24);
            this.tsbDeleteUser.Text = "Удалить";
            this.tsbDeleteUser.Click += new System.EventHandler(this.tsbDeleteUser_Click);
            // 
            // pFilters
            // 
            this.pFilters.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.pFilters.Controls.Add(this.cbSearchStatusUser);
            this.pFilters.Controls.Add(this.cbSortUser);
            this.pFilters.Controls.Add(this.lSortCar);
            this.pFilters.Controls.Add(this.mtbSearchUser);
            this.pFilters.Controls.Add(this.cbSearchUser);
            this.pFilters.Controls.Add(this.lSearchUser);
            this.pFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pFilters.Location = new System.Drawing.Point(0, 0);
            this.pFilters.Name = "pFilters";
            this.pFilters.Size = new System.Drawing.Size(1209, 77);
            this.pFilters.TabIndex = 0;
            this.pFilters.Visible = false;
            // 
            // cbSearchStatusUser
            // 
            this.cbSearchStatusUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearchStatusUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchStatusUser.FormattingEnabled = true;
            this.cbSearchStatusUser.Items.AddRange(new object[] {
            "Клиент",
            "Администратор",
            "Руководитель",
            "Экономист",
            "Диспетчер НИИАР",
            "ДИД",
            "Диспетчер АТА"});
            this.cbSearchStatusUser.Location = new System.Drawing.Point(226, 33);
            this.cbSearchStatusUser.Name = "cbSearchStatusUser";
            this.cbSearchStatusUser.Size = new System.Drawing.Size(239, 28);
            this.cbSearchStatusUser.TabIndex = 37;
            this.cbSearchStatusUser.Visible = false;
            this.cbSearchStatusUser.SelectedIndexChanged += new System.EventHandler(this.cbSearchStatusUser_SelectedIndexChanged);
            // 
            // cbSortUser
            // 
            this.cbSortUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSortUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSortUser.FormattingEnabled = true;
            this.cbSortUser.Items.AddRange(new object[] {
            "По убыванию (z-a, 10-1)",
            "По возрастанию (a-z, 1-10)"});
            this.cbSortUser.Location = new System.Drawing.Point(533, 33);
            this.cbSortUser.Name = "cbSortUser";
            this.cbSortUser.Size = new System.Drawing.Size(212, 28);
            this.cbSortUser.TabIndex = 35;
            this.cbSortUser.SelectedIndexChanged += new System.EventHandler(this.cbSortUser_SelectedIndexChanged);
            // 
            // lSortCar
            // 
            this.lSortCar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lSortCar.AutoSize = true;
            this.lSortCar.Location = new System.Drawing.Point(529, 10);
            this.lSortCar.Name = "lSortCar";
            this.lSortCar.Size = new System.Drawing.Size(124, 20);
            this.lSortCar.TabIndex = 34;
            this.lSortCar.Text = "Сортировать по:";
            // 
            // mtbSearchUser
            // 
            this.mtbSearchUser.ForeColor = System.Drawing.Color.Silver;
            this.mtbSearchUser.Location = new System.Drawing.Point(226, 34);
            this.mtbSearchUser.Name = "mtbSearchUser";
            this.mtbSearchUser.Size = new System.Drawing.Size(239, 27);
            this.mtbSearchUser.TabIndex = 33;
            this.mtbSearchUser.Text = "Поиск...";
            this.mtbSearchUser.TextChanged += new System.EventHandler(this.mtbSearchUser_TextChanged);
            this.mtbSearchUser.Enter += new System.EventHandler(this.mtbSearchUser_Enter);
            this.mtbSearchUser.Leave += new System.EventHandler(this.mtbSearchUser_Leave);
            // 
            // cbSearchUser
            // 
            this.cbSearchUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchUser.FormattingEnabled = true;
            this.cbSearchUser.Items.AddRange(new object[] {
            "Ф. И. O. пользователя",
            "E-mail",
            "Должность",
            "Подразделение",
            "Здание",
            "Комната",
            "Рабочий телефон",
            "Мобильный телефон",
            "Непосредственный руководитель",
            "Статус"});
            this.cbSearchUser.Location = new System.Drawing.Point(23, 33);
            this.cbSearchUser.Name = "cbSearchUser";
            this.cbSearchUser.Size = new System.Drawing.Size(176, 28);
            this.cbSearchUser.TabIndex = 30;
            this.cbSearchUser.SelectedIndexChanged += new System.EventHandler(this.cbSearchUser_SelectedIndexChanged);
            // 
            // lSearchUser
            // 
            this.lSearchUser.AutoSize = true;
            this.lSearchUser.Location = new System.Drawing.Point(19, 10);
            this.lSearchUser.Name = "lSearchUser";
            this.lSearchUser.Size = new System.Drawing.Size(77, 20);
            this.lSearchUser.TabIndex = 29;
            this.lSearchUser.Text = "Поиск по:";
            // 
            // tsUser
            // 
            this.tsUser.BackColor = System.Drawing.Color.Sienna;
            this.tsUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsUser.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbInsertUser,
            this.tsbUpdateUser,
            this.tsbDeleteUser,
            this.tsbFunctionUser});
            this.tsUser.Location = new System.Drawing.Point(0, 0);
            this.tsUser.Name = "tsUser";
            this.tsUser.Size = new System.Drawing.Size(1209, 27);
            this.tsUser.TabIndex = 6;
            this.tsUser.Text = "toolStrip1";
            // 
            // dgvUserView
            // 
            this.dgvUserView.AllowUserToAddRows = false;
            this.dgvUserView.AllowUserToDeleteRows = false;
            this.dgvUserView.AutoGenerateColumns = false;
            this.dgvUserView.BackgroundColor = System.Drawing.Color.White;
            this.dgvUserView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.customerDataGridViewTextBoxColumn,
            this.postDataGridViewTextBoxColumn,
            this.divisionDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.buildingDataGridViewTextBoxColumn,
            this.roomDataGridViewTextBoxColumn,
            this.workPhoneDataGridViewTextBoxColumn,
            this.mobilePhoneDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dgvUserView.DataSource = this.bsUserView;
            this.dgvUserView.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvUserView.Location = new System.Drawing.Point(0, 27);
            this.dgvUserView.MultiSelect = false;
            this.dgvUserView.Name = "dgvUserView";
            this.dgvUserView.ReadOnly = true;
            this.dgvUserView.RowHeadersVisible = false;
            this.dgvUserView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserView.Size = new System.Drawing.Size(465, 486);
            this.dgvUserView.TabIndex = 7;
            this.dgvUserView.TabStop = false;
            this.dgvUserView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserView_CellClick);
            // 
            // bsUserView
            // 
            this.bsUserView.DataSource = typeof(AZUS_Transport.Models.UserView);
            this.bsUserView.CurrentChanged += new System.EventHandler(this.bsUserView_CurrentChanged);
            // 
            // pMain
            // 
            this.pMain.Controls.Add(this.pMainTwo);
            this.pMain.Controls.Add(this.pFilters);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1209, 590);
            this.pMain.TabIndex = 1;
            // 
            // pMainTwo
            // 
            this.pMainTwo.BackColor = System.Drawing.Color.White;
            this.pMainTwo.Controls.Add(this.lUserNotFound);
            this.pMainTwo.Controls.Add(this.pMainUser);
            this.pMainTwo.Controls.Add(this.dgvUserView);
            this.pMainTwo.Controls.Add(this.tsUser);
            this.pMainTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMainTwo.Location = new System.Drawing.Point(0, 77);
            this.pMainTwo.Name = "pMainTwo";
            this.pMainTwo.Size = new System.Drawing.Size(1209, 513);
            this.pMainTwo.TabIndex = 1;
            // 
            // lUserNotFound
            // 
            this.lUserNotFound.AutoSize = true;
            this.lUserNotFound.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lUserNotFound.ForeColor = System.Drawing.Color.Silver;
            this.lUserNotFound.Location = new System.Drawing.Point(56, 248);
            this.lUserNotFound.Name = "lUserNotFound";
            this.lUserNotFound.Size = new System.Drawing.Size(345, 37);
            this.lUserNotFound.TabIndex = 34;
            this.lUserNotFound.Text = "Пользователи не найдены";
            this.lUserNotFound.Visible = false;
            // 
            // pMainUser
            // 
            this.pMainUser.AutoScroll = true;
            this.pMainUser.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.pMainUser.Controls.Add(this.pUserInformation);
            this.pMainUser.Controls.Add(this.lUserInformation);
            this.pMainUser.Controls.Add(this.pbClient);
            this.pMainUser.Controls.Add(this.lStatusUser);
            this.pMainUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.pMainUser.Location = new System.Drawing.Point(471, 27);
            this.pMainUser.Name = "pMainUser";
            this.pMainUser.Size = new System.Drawing.Size(738, 486);
            this.pMainUser.TabIndex = 33;
            // 
            // pUserInformation
            // 
            this.pUserInformation.BackColor = System.Drawing.Color.White;
            this.pUserInformation.Controls.Add(this.lPassword);
            this.pUserInformation.Controls.Add(this.lUsername);
            this.pUserInformation.Controls.Add(this.pictureBox1);
            this.pUserInformation.Controls.Add(this.lEconomistFullName);
            this.pUserInformation.Controls.Add(this.lDirectorFullName);
            this.pUserInformation.Controls.Add(this.lDirectorAndEconomist);
            this.pUserInformation.Controls.Add(this.pDirectorAndEconomist);
            this.pUserInformation.Controls.Add(this.pUser);
            this.pUserInformation.Controls.Add(this.lMobilePhone);
            this.pUserInformation.Controls.Add(this.lWorkPhone);
            this.pUserInformation.Controls.Add(this.lRoom);
            this.pUserInformation.Controls.Add(this.lBuilding);
            this.pUserInformation.Controls.Add(this.lPost);
            this.pUserInformation.Controls.Add(this.lEmail);
            this.pUserInformation.Controls.Add(this.lUser);
            this.pUserInformation.Controls.Add(this.lDivision);
            this.pUserInformation.Location = new System.Drawing.Point(3, 38);
            this.pUserInformation.Name = "pUserInformation";
            this.pUserInformation.Size = new System.Drawing.Size(732, 444);
            this.pUserInformation.TabIndex = 34;
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Location = new System.Drawing.Point(217, 292);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(62, 20);
            this.lPassword.TabIndex = 11;
            this.lPassword.Text = "Пароль";
            // 
            // lUsername
            // 
            this.lUsername.AutoSize = true;
            this.lUsername.Location = new System.Drawing.Point(217, 263);
            this.lUsername.Name = "lUsername";
            this.lUsername.Size = new System.Drawing.Size(52, 20);
            this.lUsername.TabIndex = 11;
            this.lUsername.Text = "Логин";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::AZUS_Transport.Properties.Resources.DirectorAndEconomist;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 362);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // lEconomistFullName
            // 
            this.lEconomistFullName.AutoSize = true;
            this.lEconomistFullName.Location = new System.Drawing.Point(217, 415);
            this.lEconomistFullName.Name = "lEconomistFullName";
            this.lEconomistFullName.Size = new System.Drawing.Size(141, 20);
            this.lEconomistFullName.TabIndex = 35;
            this.lEconomistFullName.Text = "Ф.И.О.  экономиста";
            // 
            // lDirectorFullName
            // 
            this.lDirectorFullName.AutoSize = true;
            this.lDirectorFullName.Location = new System.Drawing.Point(217, 384);
            this.lDirectorFullName.Name = "lDirectorFullName";
            this.lDirectorFullName.Size = new System.Drawing.Size(155, 20);
            this.lDirectorFullName.TabIndex = 36;
            this.lDirectorFullName.Text = "Ф.И.О.  руководителя";
            // 
            // lDirectorAndEconomist
            // 
            this.lDirectorAndEconomist.AutoSize = true;
            this.lDirectorAndEconomist.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lDirectorAndEconomist.Location = new System.Drawing.Point(21, 361);
            this.lDirectorAndEconomist.Name = "lDirectorAndEconomist";
            this.lDirectorAndEconomist.Size = new System.Drawing.Size(195, 20);
            this.lDirectorAndEconomist.TabIndex = 38;
            this.lDirectorAndEconomist.Text = "Руководитель и экономист";
            // 
            // pDirectorAndEconomist
            // 
            this.pDirectorAndEconomist.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.pDirectorAndEconomist.Controls.Add(this.lEconomistFullName_);
            this.pDirectorAndEconomist.Controls.Add(this.lDirectorFullName_);
            this.pDirectorAndEconomist.Location = new System.Drawing.Point(4, 384);
            this.pDirectorAndEconomist.Name = "pDirectorAndEconomist";
            this.pDirectorAndEconomist.Size = new System.Drawing.Size(212, 53);
            this.pDirectorAndEconomist.TabIndex = 37;
            // 
            // lEconomistFullName_
            // 
            this.lEconomistFullName_.AutoSize = true;
            this.lEconomistFullName_.Location = new System.Drawing.Point(68, 31);
            this.lEconomistFullName_.Name = "lEconomistFullName_";
            this.lEconomistFullName_.Size = new System.Drawing.Size(141, 20);
            this.lEconomistFullName_.TabIndex = 19;
            this.lEconomistFullName_.Text = "Ф.И.О.  экономиста";
            // 
            // lDirectorFullName_
            // 
            this.lDirectorFullName_.AutoSize = true;
            this.lDirectorFullName_.Location = new System.Drawing.Point(53, 0);
            this.lDirectorFullName_.Name = "lDirectorFullName_";
            this.lDirectorFullName_.Size = new System.Drawing.Size(155, 20);
            this.lDirectorFullName_.TabIndex = 18;
            this.lDirectorFullName_.Text = "Ф.И.О.  руководителя";
            // 
            // pUser
            // 
            this.pUser.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.pUser.Controls.Add(this.lPassword_);
            this.pUser.Controls.Add(this.lUsername_);
            this.pUser.Controls.Add(this.lMobilePhone_);
            this.pUser.Controls.Add(this.lWorkPhone_);
            this.pUser.Controls.Add(this.lRoom_);
            this.pUser.Controls.Add(this.lBuilding_);
            this.pUser.Controls.Add(this.lDivision_);
            this.pUser.Controls.Add(this.lPost_);
            this.pUser.Controls.Add(this.lEmail_);
            this.pUser.Controls.Add(this.lUser_);
            this.pUser.Location = new System.Drawing.Point(3, 3);
            this.pUser.Name = "pUser";
            this.pUser.Size = new System.Drawing.Size(212, 318);
            this.pUser.TabIndex = 26;
            // 
            // lPassword_
            // 
            this.lPassword_.AutoSize = true;
            this.lPassword_.Location = new System.Drawing.Point(147, 289);
            this.lPassword_.Name = "lPassword_";
            this.lPassword_.Size = new System.Drawing.Size(62, 20);
            this.lPassword_.TabIndex = 10;
            this.lPassword_.Text = "Пароль";
            // 
            // lUsername_
            // 
            this.lUsername_.AutoSize = true;
            this.lUsername_.Location = new System.Drawing.Point(156, 260);
            this.lUsername_.Name = "lUsername_";
            this.lUsername_.Size = new System.Drawing.Size(52, 20);
            this.lUsername_.TabIndex = 9;
            this.lUsername_.Text = "Логин";
            // 
            // lMobilePhone_
            // 
            this.lMobilePhone_.AutoSize = true;
            this.lMobilePhone_.Location = new System.Drawing.Point(52, 229);
            this.lMobilePhone_.Name = "lMobilePhone_";
            this.lMobilePhone_.Size = new System.Drawing.Size(156, 20);
            this.lMobilePhone_.TabIndex = 7;
            this.lMobilePhone_.Text = "Мобильный телефон";
            // 
            // lWorkPhone_
            // 
            this.lWorkPhone_.AutoSize = true;
            this.lWorkPhone_.Location = new System.Drawing.Point(78, 194);
            this.lWorkPhone_.Name = "lWorkPhone_";
            this.lWorkPhone_.Size = new System.Drawing.Size(131, 20);
            this.lWorkPhone_.TabIndex = 6;
            this.lWorkPhone_.Text = "Рабочий телефон";
            // 
            // lRoom_
            // 
            this.lRoom_.AutoSize = true;
            this.lRoom_.Location = new System.Drawing.Point(139, 160);
            this.lRoom_.Name = "lRoom_";
            this.lRoom_.Size = new System.Drawing.Size(69, 20);
            this.lRoom_.TabIndex = 5;
            this.lRoom_.Text = "Комната";
            // 
            // lBuilding_
            // 
            this.lBuilding_.AutoSize = true;
            this.lBuilding_.Location = new System.Drawing.Point(149, 127);
            this.lBuilding_.Name = "lBuilding_";
            this.lBuilding_.Size = new System.Drawing.Size(59, 20);
            this.lBuilding_.TabIndex = 4;
            this.lBuilding_.Text = "Здание";
            // 
            // lDivision_
            // 
            this.lDivision_.AutoSize = true;
            this.lDivision_.Location = new System.Drawing.Point(89, 95);
            this.lDivision_.Name = "lDivision_";
            this.lDivision_.Size = new System.Drawing.Size(119, 20);
            this.lDivision_.TabIndex = 3;
            this.lDivision_.Text = "Подразделение";
            // 
            // lPost_
            // 
            this.lPost_.AutoSize = true;
            this.lPost_.Location = new System.Drawing.Point(123, 61);
            this.lPost_.Name = "lPost_";
            this.lPost_.Size = new System.Drawing.Size(86, 20);
            this.lPost_.TabIndex = 2;
            this.lPost_.Text = "Должность";
            // 
            // lEmail_
            // 
            this.lEmail_.AutoSize = true;
            this.lEmail_.Location = new System.Drawing.Point(156, 31);
            this.lEmail_.Name = "lEmail_";
            this.lEmail_.Size = new System.Drawing.Size(52, 20);
            this.lEmail_.TabIndex = 1;
            this.lEmail_.Text = "E-mail";
            // 
            // lUser_
            // 
            this.lUser_.AutoSize = true;
            this.lUser_.Location = new System.Drawing.Point(158, 0);
            this.lUser_.Name = "lUser_";
            this.lUser_.Size = new System.Drawing.Size(51, 20);
            this.lUser_.TabIndex = 0;
            this.lUser_.Text = "Ф.И.О.";
            // 
            // lMobilePhone
            // 
            this.lMobilePhone.AutoSize = true;
            this.lMobilePhone.Location = new System.Drawing.Point(217, 232);
            this.lMobilePhone.Name = "lMobilePhone";
            this.lMobilePhone.Size = new System.Drawing.Size(156, 20);
            this.lMobilePhone.TabIndex = 27;
            this.lMobilePhone.Text = "Мобильный телефон";
            // 
            // lWorkPhone
            // 
            this.lWorkPhone.AutoSize = true;
            this.lWorkPhone.Location = new System.Drawing.Point(217, 197);
            this.lWorkPhone.Name = "lWorkPhone";
            this.lWorkPhone.Size = new System.Drawing.Size(69, 20);
            this.lWorkPhone.TabIndex = 28;
            this.lWorkPhone.Text = "Телефон";
            // 
            // lRoom
            // 
            this.lRoom.AutoSize = true;
            this.lRoom.Location = new System.Drawing.Point(217, 163);
            this.lRoom.Name = "lRoom";
            this.lRoom.Size = new System.Drawing.Size(69, 20);
            this.lRoom.TabIndex = 29;
            this.lRoom.Text = "Комната";
            // 
            // lBuilding
            // 
            this.lBuilding.AutoSize = true;
            this.lBuilding.Location = new System.Drawing.Point(217, 130);
            this.lBuilding.Name = "lBuilding";
            this.lBuilding.Size = new System.Drawing.Size(59, 20);
            this.lBuilding.TabIndex = 30;
            this.lBuilding.Text = "Здание";
            // 
            // lPost
            // 
            this.lPost.AutoSize = true;
            this.lPost.Location = new System.Drawing.Point(217, 64);
            this.lPost.Name = "lPost";
            this.lPost.Size = new System.Drawing.Size(86, 20);
            this.lPost.TabIndex = 31;
            this.lPost.Text = "Должность";
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Location = new System.Drawing.Point(217, 34);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(46, 20);
            this.lEmail.TabIndex = 34;
            this.lEmail.Text = "Email";
            // 
            // lUser
            // 
            this.lUser.AutoSize = true;
            this.lUser.Location = new System.Drawing.Point(217, 3);
            this.lUser.Name = "lUser";
            this.lUser.Size = new System.Drawing.Size(59, 20);
            this.lUser.TabIndex = 33;
            this.lUser.Text = "Ф. И. О.";
            // 
            // lDivision
            // 
            this.lDivision.AutoSize = true;
            this.lDivision.Location = new System.Drawing.Point(217, 98);
            this.lDivision.Name = "lDivision";
            this.lDivision.Size = new System.Drawing.Size(119, 20);
            this.lDivision.TabIndex = 32;
            this.lDivision.Text = "Подразделение";
            // 
            // lUserInformation
            // 
            this.lUserInformation.AutoSize = true;
            this.lUserInformation.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lUserInformation.Location = new System.Drawing.Point(41, 12);
            this.lUserInformation.Name = "lUserInformation";
            this.lUserInformation.Size = new System.Drawing.Size(260, 20);
            this.lUserInformation.TabIndex = 25;
            this.lUserInformation.Text = "ИНФОРМАЦИЯ О ПОЛЬЗОВАТЕЛЕ";
            // 
            // pbClient
            // 
            this.pbClient.ErrorImage = null;
            this.pbClient.Image = global::AZUS_Transport.Properties.Resources.Client;
            this.pbClient.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbClient.InitialImage")));
            this.pbClient.Location = new System.Drawing.Point(6, 6);
            this.pbClient.Name = "pbClient";
            this.pbClient.Size = new System.Drawing.Size(36, 29);
            this.pbClient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClient.TabIndex = 35;
            this.pbClient.TabStop = false;
            // 
            // lStatusUser
            // 
            this.lStatusUser.AutoSize = true;
            this.lStatusUser.Location = new System.Drawing.Point(307, 12);
            this.lStatusUser.Name = "lStatusUser";
            this.lStatusUser.Size = new System.Drawing.Size(124, 20);
            this.lStatusUser.TabIndex = 9;
            this.lStatusUser.Text = "Статус в системе";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 28;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            this.customerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.customerDataGridViewTextBoxColumn.DataPropertyName = "Customer";
            this.customerDataGridViewTextBoxColumn.HeaderText = "Клиент";
            this.customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            this.customerDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerDataGridViewTextBoxColumn.Width = 83;
            // 
            // postDataGridViewTextBoxColumn
            // 
            this.postDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.postDataGridViewTextBoxColumn.DataPropertyName = "Post";
            this.postDataGridViewTextBoxColumn.HeaderText = "Должность";
            this.postDataGridViewTextBoxColumn.Name = "postDataGridViewTextBoxColumn";
            this.postDataGridViewTextBoxColumn.ReadOnly = true;
            this.postDataGridViewTextBoxColumn.Width = 111;
            // 
            // divisionDataGridViewTextBoxColumn
            // 
            this.divisionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.divisionDataGridViewTextBoxColumn.DataPropertyName = "Division";
            this.divisionDataGridViewTextBoxColumn.HeaderText = "Подразделение";
            this.divisionDataGridViewTextBoxColumn.Name = "divisionDataGridViewTextBoxColumn";
            this.divisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.divisionDataGridViewTextBoxColumn.Width = 144;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // buildingDataGridViewTextBoxColumn
            // 
            this.buildingDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.buildingDataGridViewTextBoxColumn.DataPropertyName = "Building";
            this.buildingDataGridViewTextBoxColumn.HeaderText = "Здание";
            this.buildingDataGridViewTextBoxColumn.Name = "buildingDataGridViewTextBoxColumn";
            this.buildingDataGridViewTextBoxColumn.ReadOnly = true;
            this.buildingDataGridViewTextBoxColumn.Width = 84;
            // 
            // roomDataGridViewTextBoxColumn
            // 
            this.roomDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.roomDataGridViewTextBoxColumn.DataPropertyName = "Room";
            this.roomDataGridViewTextBoxColumn.HeaderText = "Комната";
            this.roomDataGridViewTextBoxColumn.Name = "roomDataGridViewTextBoxColumn";
            this.roomDataGridViewTextBoxColumn.ReadOnly = true;
            this.roomDataGridViewTextBoxColumn.Width = 94;
            // 
            // workPhoneDataGridViewTextBoxColumn
            // 
            this.workPhoneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.workPhoneDataGridViewTextBoxColumn.DataPropertyName = "WorkPhone";
            this.workPhoneDataGridViewTextBoxColumn.HeaderText = "Рабочий телефон";
            this.workPhoneDataGridViewTextBoxColumn.Name = "workPhoneDataGridViewTextBoxColumn";
            this.workPhoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.workPhoneDataGridViewTextBoxColumn.Width = 142;
            // 
            // mobilePhoneDataGridViewTextBoxColumn
            // 
            this.mobilePhoneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.mobilePhoneDataGridViewTextBoxColumn.DataPropertyName = "MobilePhone";
            this.mobilePhoneDataGridViewTextBoxColumn.HeaderText = "Мобильный телефон";
            this.mobilePhoneDataGridViewTextBoxColumn.Name = "mobilePhoneDataGridViewTextBoxColumn";
            this.mobilePhoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.mobilePhoneDataGridViewTextBoxColumn.Width = 165;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 77;
            // 
            // UserUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pMain);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserUserControl";
            this.Size = new System.Drawing.Size(1209, 590);
            this.pFilters.ResumeLayout(false);
            this.pFilters.PerformLayout();
            this.tsUser.ResumeLayout(false);
            this.tsUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUserView)).EndInit();
            this.pMain.ResumeLayout(false);
            this.pMainTwo.ResumeLayout(false);
            this.pMainTwo.PerformLayout();
            this.pMainUser.ResumeLayout(false);
            this.pMainUser.PerformLayout();
            this.pUserInformation.ResumeLayout(false);
            this.pUserInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pDirectorAndEconomist.ResumeLayout(false);
            this.pDirectorAndEconomist.PerformLayout();
            this.pUser.ResumeLayout(false);
            this.pUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton tsbFunctionUser;
        private System.Windows.Forms.ToolStripButton tsbUpdateUser;
        private System.Windows.Forms.ToolStripButton tsbInsertUser;
        private System.Windows.Forms.BindingSource bsUserView;
        private System.Windows.Forms.Timer tUserView;
        private System.Windows.Forms.ToolStripButton tsbDeleteUser;
        private System.Windows.Forms.Panel pFilters;
        private System.Windows.Forms.ComboBox cbSortUser;
        private System.Windows.Forms.Label lSortCar;
        private System.Windows.Forms.MaskedTextBox mtbSearchUser;
        private System.Windows.Forms.ComboBox cbSearchUser;
        private System.Windows.Forms.Label lSearchUser;
        private System.Windows.Forms.ToolStrip tsUser;
        private System.Windows.Forms.DataGridView dgvUserView;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Panel pMainTwo;
        private System.Windows.Forms.Label lUserNotFound;
        private System.Windows.Forms.Panel pMainUser;
        private System.Windows.Forms.Panel pUserInformation;
        private System.Windows.Forms.Panel pUser;
        private System.Windows.Forms.Label lMobilePhone_;
        private System.Windows.Forms.Label lWorkPhone_;
        private System.Windows.Forms.Label lRoom_;
        private System.Windows.Forms.Label lBuilding_;
        private System.Windows.Forms.Label lDivision_;
        private System.Windows.Forms.Label lPost_;
        private System.Windows.Forms.Label lEmail_;
        private System.Windows.Forms.Label lUser_;
        private System.Windows.Forms.Label lMobilePhone;
        private System.Windows.Forms.Label lWorkPhone;
        private System.Windows.Forms.Label lRoom;
        private System.Windows.Forms.Label lBuilding;
        private System.Windows.Forms.Label lPost;
        private System.Windows.Forms.Label lEmail;
        private System.Windows.Forms.Label lUser;
        private System.Windows.Forms.PictureBox pbClient;
        private System.Windows.Forms.Label lDivision;
        private System.Windows.Forms.Label lUserInformation;
        private System.Windows.Forms.Label lStatusUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lEconomistFullName;
        private System.Windows.Forms.Label lDirectorFullName;
        private System.Windows.Forms.Label lDirectorAndEconomist;
        private System.Windows.Forms.Panel pDirectorAndEconomist;
        private System.Windows.Forms.Label lEconomistFullName_;
        private System.Windows.Forms.Label lDirectorFullName_;
        private System.Windows.Forms.Label lPassword_;
        private System.Windows.Forms.Label lUsername_;
        private System.Windows.Forms.Label lUsername;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.ComboBox cbSearchStatusUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn economistDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn divisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobilePhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}
