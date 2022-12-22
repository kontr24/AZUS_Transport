
namespace AZUS_Transport.MyUserControl
{
    partial class TransportUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransportUserControl));
            this.pMain = new System.Windows.Forms.Panel();
            this.pMainTwo = new System.Windows.Forms.Panel();
            this.lTransportNotFound = new System.Windows.Forms.Label();
            this.pMainCar = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pSpecifications = new System.Windows.Forms.Panel();
            this.lStatusCar = new System.Windows.Forms.Label();
            this.lTypeCar = new System.Windows.Forms.Label();
            this.lRegisterSign = new System.Windows.Forms.Label();
            this.lModelCar = new System.Windows.Forms.Label();
            this.ppSpecificationCar = new System.Windows.Forms.Panel();
            this.lStatusCar_ = new System.Windows.Forms.Label();
            this.lRegisterSign_ = new System.Windows.Forms.Label();
            this.lModelCar_ = new System.Windows.Forms.Label();
            this.lTypeCar_ = new System.Windows.Forms.Label();
            this.lSpecifications = new System.Windows.Forms.Label();
            this.lCarPhoto = new System.Windows.Forms.Label();
            this.pbCar = new System.Windows.Forms.PictureBox();
            this.dgvCarView = new System.Windows.Forms.DataGridView();
            this.bsCarView = new System.Windows.Forms.BindingSource(this.components);
            this.tsTransport = new System.Windows.Forms.ToolStrip();
            this.tsbInsertCar = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdateCar = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteCar = new System.Windows.Forms.ToolStripButton();
            this.tsbFunctionCar = new System.Windows.Forms.ToolStripButton();
            this.pFilters = new System.Windows.Forms.Panel();
            this.cbSearchStatusCar = new System.Windows.Forms.ComboBox();
            this.cbSortCar = new System.Windows.Forms.ComboBox();
            this.lSortCar = new System.Windows.Forms.Label();
            this.mtbSearchCar = new System.Windows.Forms.MaskedTextBox();
            this.cbSearchCar = new System.Windows.Forms.ComboBox();
            this.lSearchCar = new System.Windows.Forms.Label();
            this.tCarView = new System.Windows.Forms.Timer(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeCarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registerSignDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusCarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pMain.SuspendLayout();
            this.pMainTwo.SuspendLayout();
            this.pMainCar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pSpecifications.SuspendLayout();
            this.ppSpecificationCar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCarView)).BeginInit();
            this.tsTransport.SuspendLayout();
            this.pFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMain
            // 
            this.pMain.Controls.Add(this.pMainTwo);
            this.pMain.Controls.Add(this.pFilters);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1100, 632);
            this.pMain.TabIndex = 0;
            // 
            // pMainTwo
            // 
            this.pMainTwo.BackColor = System.Drawing.Color.White;
            this.pMainTwo.Controls.Add(this.lTransportNotFound);
            this.pMainTwo.Controls.Add(this.pMainCar);
            this.pMainTwo.Controls.Add(this.dgvCarView);
            this.pMainTwo.Controls.Add(this.tsTransport);
            this.pMainTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMainTwo.Location = new System.Drawing.Point(0, 100);
            this.pMainTwo.Name = "pMainTwo";
            this.pMainTwo.Size = new System.Drawing.Size(1100, 532);
            this.pMainTwo.TabIndex = 1;
            // 
            // lTransportNotFound
            // 
            this.lTransportNotFound.AutoSize = true;
            this.lTransportNotFound.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTransportNotFound.ForeColor = System.Drawing.Color.Silver;
            this.lTransportNotFound.Location = new System.Drawing.Point(125, 253);
            this.lTransportNotFound.Name = "lTransportNotFound";
            this.lTransportNotFound.Size = new System.Drawing.Size(283, 37);
            this.lTransportNotFound.TabIndex = 34;
            this.lTransportNotFound.Text = "Транспорт не найден";
            this.lTransportNotFound.Visible = false;
            // 
            // pMainCar
            // 
            this.pMainCar.AutoScroll = true;
            this.pMainCar.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.pMainCar.Controls.Add(this.pictureBox2);
            this.pMainCar.Controls.Add(this.pictureBox1);
            this.pMainCar.Controls.Add(this.pSpecifications);
            this.pMainCar.Controls.Add(this.lSpecifications);
            this.pMainCar.Controls.Add(this.lCarPhoto);
            this.pMainCar.Controls.Add(this.pbCar);
            this.pMainCar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pMainCar.Location = new System.Drawing.Point(564, 27);
            this.pMainCar.Name = "pMainCar";
            this.pMainCar.Size = new System.Drawing.Size(536, 505);
            this.pMainCar.TabIndex = 33;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(39, 331);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // pSpecifications
            // 
            this.pSpecifications.BackColor = System.Drawing.Color.White;
            this.pSpecifications.Controls.Add(this.lStatusCar);
            this.pSpecifications.Controls.Add(this.lTypeCar);
            this.pSpecifications.Controls.Add(this.lRegisterSign);
            this.pSpecifications.Controls.Add(this.lModelCar);
            this.pSpecifications.Controls.Add(this.ppSpecificationCar);
            this.pSpecifications.Location = new System.Drawing.Point(39, 354);
            this.pSpecifications.Name = "pSpecifications";
            this.pSpecifications.Size = new System.Drawing.Size(473, 148);
            this.pSpecifications.TabIndex = 34;
            // 
            // lStatusCar
            // 
            this.lStatusCar.AutoSize = true;
            this.lStatusCar.Location = new System.Drawing.Point(164, 115);
            this.lStatusCar.Name = "lStatusCar";
            this.lStatusCar.Size = new System.Drawing.Size(52, 20);
            this.lStatusCar.TabIndex = 4;
            this.lStatusCar.Text = "Статус";
            // 
            // lTypeCar
            // 
            this.lTypeCar.AutoSize = true;
            this.lTypeCar.Location = new System.Drawing.Point(164, 81);
            this.lTypeCar.Name = "lTypeCar";
            this.lTypeCar.Size = new System.Drawing.Size(119, 20);
            this.lTypeCar.TabIndex = 4;
            this.lTypeCar.Text = "Тип транспорта";
            // 
            // lRegisterSign
            // 
            this.lRegisterSign.AutoSize = true;
            this.lRegisterSign.Location = new System.Drawing.Point(164, 46);
            this.lRegisterSign.Name = "lRegisterSign";
            this.lRegisterSign.Size = new System.Drawing.Size(85, 20);
            this.lRegisterSign.TabIndex = 4;
            this.lRegisterSign.Text = "Гос. номер";
            // 
            // lModelCar
            // 
            this.lModelCar.AutoSize = true;
            this.lModelCar.Location = new System.Drawing.Point(164, 15);
            this.lModelCar.Name = "lModelCar";
            this.lModelCar.Size = new System.Drawing.Size(63, 20);
            this.lModelCar.TabIndex = 4;
            this.lModelCar.Text = "Модель";
            // 
            // ppSpecificationCar
            // 
            this.ppSpecificationCar.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ppSpecificationCar.Controls.Add(this.lStatusCar_);
            this.ppSpecificationCar.Controls.Add(this.lRegisterSign_);
            this.ppSpecificationCar.Controls.Add(this.lModelCar_);
            this.ppSpecificationCar.Controls.Add(this.lTypeCar_);
            this.ppSpecificationCar.Location = new System.Drawing.Point(3, 3);
            this.ppSpecificationCar.Name = "ppSpecificationCar";
            this.ppSpecificationCar.Size = new System.Drawing.Size(155, 142);
            this.ppSpecificationCar.TabIndex = 1;
            // 
            // lStatusCar_
            // 
            this.lStatusCar_.AutoSize = true;
            this.lStatusCar_.Location = new System.Drawing.Point(100, 112);
            this.lStatusCar_.Name = "lStatusCar_";
            this.lStatusCar_.Size = new System.Drawing.Size(52, 20);
            this.lStatusCar_.TabIndex = 3;
            this.lStatusCar_.Text = "Статус";
            // 
            // lRegisterSign_
            // 
            this.lRegisterSign_.AutoSize = true;
            this.lRegisterSign_.Location = new System.Drawing.Point(67, 43);
            this.lRegisterSign_.Name = "lRegisterSign_";
            this.lRegisterSign_.Size = new System.Drawing.Size(85, 20);
            this.lRegisterSign_.TabIndex = 2;
            this.lRegisterSign_.Text = "Гос. номер";
            // 
            // lModelCar_
            // 
            this.lModelCar_.AutoSize = true;
            this.lModelCar_.Location = new System.Drawing.Point(89, 12);
            this.lModelCar_.Name = "lModelCar_";
            this.lModelCar_.Size = new System.Drawing.Size(63, 20);
            this.lModelCar_.TabIndex = 1;
            this.lModelCar_.Text = "Модель";
            // 
            // lTypeCar_
            // 
            this.lTypeCar_.AutoSize = true;
            this.lTypeCar_.Location = new System.Drawing.Point(33, 78);
            this.lTypeCar_.Name = "lTypeCar_";
            this.lTypeCar_.Size = new System.Drawing.Size(119, 20);
            this.lTypeCar_.TabIndex = 0;
            this.lTypeCar_.Text = "Тип транспорта";
            // 
            // lSpecifications
            // 
            this.lSpecifications.AutoSize = true;
            this.lSpecifications.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lSpecifications.Location = new System.Drawing.Point(75, 331);
            this.lSpecifications.Name = "lSpecifications";
            this.lSpecifications.Size = new System.Drawing.Size(149, 20);
            this.lSpecifications.TabIndex = 33;
            this.lSpecifications.Text = "ХАРАКТЕРИСТИКИ";
            // 
            // lCarPhoto
            // 
            this.lCarPhoto.AutoSize = true;
            this.lCarPhoto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCarPhoto.Location = new System.Drawing.Point(75, 11);
            this.lCarPhoto.Name = "lCarPhoto";
            this.lCarPhoto.Size = new System.Drawing.Size(162, 20);
            this.lCarPhoto.TabIndex = 32;
            this.lCarPhoto.Text = "ФОТО АВТОМОБИЛЯ";
            // 
            // pbCar
            // 
            this.pbCar.Location = new System.Drawing.Point(39, 34);
            this.pbCar.Name = "pbCar";
            this.pbCar.Size = new System.Drawing.Size(473, 269);
            this.pbCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCar.TabIndex = 31;
            this.pbCar.TabStop = false;
            // 
            // dgvCarView
            // 
            this.dgvCarView.AllowUserToAddRows = false;
            this.dgvCarView.AllowUserToDeleteRows = false;
            this.dgvCarView.AutoGenerateColumns = false;
            this.dgvCarView.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.typeCarDataGridViewTextBoxColumn,
            this.modelDataGridViewTextBoxColumn,
            this.registerSignDataGridViewTextBoxColumn,
            this.statusCarDataGridViewTextBoxColumn});
            this.dgvCarView.DataSource = this.bsCarView;
            this.dgvCarView.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvCarView.Location = new System.Drawing.Point(0, 27);
            this.dgvCarView.MultiSelect = false;
            this.dgvCarView.Name = "dgvCarView";
            this.dgvCarView.ReadOnly = true;
            this.dgvCarView.RowHeadersVisible = false;
            this.dgvCarView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarView.Size = new System.Drawing.Size(558, 505);
            this.dgvCarView.TabIndex = 7;
            this.dgvCarView.TabStop = false;
            this.dgvCarView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarView_CellClick);
            // 
            // bsCarView
            // 
            this.bsCarView.DataSource = typeof(AZUS_Transport.Models.CarView);
            this.bsCarView.CurrentChanged += new System.EventHandler(this.bsCarView_CurrentChanged);
            // 
            // tsTransport
            // 
            this.tsTransport.BackColor = System.Drawing.Color.Sienna;
            this.tsTransport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsTransport.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTransport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbInsertCar,
            this.tsbUpdateCar,
            this.tsbDeleteCar,
            this.tsbFunctionCar});
            this.tsTransport.Location = new System.Drawing.Point(0, 0);
            this.tsTransport.Name = "tsTransport";
            this.tsTransport.Size = new System.Drawing.Size(1100, 27);
            this.tsTransport.TabIndex = 6;
            this.tsTransport.Text = "toolStrip1";
            // 
            // tsbInsertCar
            // 
            this.tsbInsertCar.ForeColor = System.Drawing.Color.White;
            this.tsbInsertCar.Image = ((System.Drawing.Image)(resources.GetObject("tsbInsertCar.Image")));
            this.tsbInsertCar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertCar.Name = "tsbInsertCar";
            this.tsbInsertCar.Size = new System.Drawing.Size(96, 24);
            this.tsbInsertCar.Text = "Добавить";
            this.tsbInsertCar.Click += new System.EventHandler(this.tsbInsertCar_Click);
            // 
            // tsbUpdateCar
            // 
            this.tsbUpdateCar.ForeColor = System.Drawing.Color.White;
            this.tsbUpdateCar.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdateCar.Image")));
            this.tsbUpdateCar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdateCar.Name = "tsbUpdateCar";
            this.tsbUpdateCar.Size = new System.Drawing.Size(131, 24);
            this.tsbUpdateCar.Text = "Редактировать";
            this.tsbUpdateCar.Click += new System.EventHandler(this.tsbUpdateCar_Click);
            // 
            // tsbDeleteCar
            // 
            this.tsbDeleteCar.ForeColor = System.Drawing.Color.White;
            this.tsbDeleteCar.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteCar.Image")));
            this.tsbDeleteCar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteCar.Name = "tsbDeleteCar";
            this.tsbDeleteCar.Size = new System.Drawing.Size(85, 24);
            this.tsbDeleteCar.Text = "Удалить";
            this.tsbDeleteCar.Click += new System.EventHandler(this.tsbDeleteCar_Click);
            // 
            // tsbFunctionCar
            // 
            this.tsbFunctionCar.ForeColor = System.Drawing.Color.White;
            this.tsbFunctionCar.Image = ((System.Drawing.Image)(resources.GetObject("tsbFunctionCar.Image")));
            this.tsbFunctionCar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFunctionCar.Name = "tsbFunctionCar";
            this.tsbFunctionCar.Size = new System.Drawing.Size(159, 24);
            this.tsbFunctionCar.Text = "Поиск/сортировка";
            this.tsbFunctionCar.Click += new System.EventHandler(this.tsbFunctionCar_Click);
            // 
            // pFilters
            // 
            this.pFilters.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.pFilters.Controls.Add(this.cbSearchStatusCar);
            this.pFilters.Controls.Add(this.cbSortCar);
            this.pFilters.Controls.Add(this.lSortCar);
            this.pFilters.Controls.Add(this.mtbSearchCar);
            this.pFilters.Controls.Add(this.cbSearchCar);
            this.pFilters.Controls.Add(this.lSearchCar);
            this.pFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pFilters.Location = new System.Drawing.Point(0, 0);
            this.pFilters.Name = "pFilters";
            this.pFilters.Size = new System.Drawing.Size(1100, 100);
            this.pFilters.TabIndex = 0;
            this.pFilters.Visible = false;
            // 
            // cbSearchStatusCar
            // 
            this.cbSearchStatusCar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearchStatusCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchStatusCar.FormattingEnabled = true;
            this.cbSearchStatusCar.Items.AddRange(new object[] {
            "Доступна",
            "Нет на месте"});
            this.cbSearchStatusCar.Location = new System.Drawing.Point(210, 43);
            this.cbSearchStatusCar.Name = "cbSearchStatusCar";
            this.cbSearchStatusCar.Size = new System.Drawing.Size(246, 28);
            this.cbSearchStatusCar.TabIndex = 36;
            this.cbSearchStatusCar.Visible = false;
            this.cbSearchStatusCar.SelectedIndexChanged += new System.EventHandler(this.cbSearchStatusCar_SelectedIndexChanged);
            // 
            // cbSortCar
            // 
            this.cbSortCar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSortCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSortCar.FormattingEnabled = true;
            this.cbSortCar.Items.AddRange(new object[] {
            "По убыванию (z-a, 10-1)",
            "По возрастанию (a-z, 1-10)"});
            this.cbSortCar.Location = new System.Drawing.Point(513, 43);
            this.cbSortCar.Name = "cbSortCar";
            this.cbSortCar.Size = new System.Drawing.Size(212, 28);
            this.cbSortCar.TabIndex = 35;
            this.cbSortCar.SelectedIndexChanged += new System.EventHandler(this.cbSortCar_SelectedIndexChanged);
            // 
            // lSortCar
            // 
            this.lSortCar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lSortCar.AutoSize = true;
            this.lSortCar.Location = new System.Drawing.Point(509, 20);
            this.lSortCar.Name = "lSortCar";
            this.lSortCar.Size = new System.Drawing.Size(124, 20);
            this.lSortCar.TabIndex = 34;
            this.lSortCar.Text = "Сортировать по:";
            // 
            // mtbSearchCar
            // 
            this.mtbSearchCar.ForeColor = System.Drawing.Color.Silver;
            this.mtbSearchCar.Location = new System.Drawing.Point(217, 44);
            this.mtbSearchCar.Name = "mtbSearchCar";
            this.mtbSearchCar.Size = new System.Drawing.Size(239, 27);
            this.mtbSearchCar.TabIndex = 33;
            this.mtbSearchCar.Text = "Поиск...";
            this.mtbSearchCar.TextChanged += new System.EventHandler(this.mtbSearchCar_TextChanged);
            this.mtbSearchCar.Enter += new System.EventHandler(this.mtbSearchCar_Enter);
            this.mtbSearchCar.Leave += new System.EventHandler(this.mtbSearchCar_Leave);
            // 
            // cbSearchCar
            // 
            this.cbSearchCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchCar.FormattingEnabled = true;
            this.cbSearchCar.Items.AddRange(new object[] {
            "Тип",
            "Модель",
            "Гос. номер",
            "Статус"});
            this.cbSearchCar.Location = new System.Drawing.Point(14, 43);
            this.cbSearchCar.Name = "cbSearchCar";
            this.cbSearchCar.Size = new System.Drawing.Size(176, 28);
            this.cbSearchCar.TabIndex = 30;
            this.cbSearchCar.SelectedIndexChanged += new System.EventHandler(this.cbSearchCar_SelectedIndexChanged);
            // 
            // lSearchCar
            // 
            this.lSearchCar.AutoSize = true;
            this.lSearchCar.Location = new System.Drawing.Point(10, 20);
            this.lSearchCar.Name = "lSearchCar";
            this.lSearchCar.Size = new System.Drawing.Size(77, 20);
            this.lSearchCar.TabIndex = 29;
            this.lSearchCar.Text = "Поиск по:";
            // 
            // tCarView
            // 
            this.tCarView.Enabled = true;
            this.tCarView.Interval = 10000;
            this.tCarView.Tick += new System.EventHandler(this.tCarView_Tick);
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
            // typeCarDataGridViewTextBoxColumn
            // 
            this.typeCarDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.typeCarDataGridViewTextBoxColumn.DataPropertyName = "TypeCar";
            this.typeCarDataGridViewTextBoxColumn.HeaderText = "Тип транспорта";
            this.typeCarDataGridViewTextBoxColumn.Name = "typeCarDataGridViewTextBoxColumn";
            this.typeCarDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeCarDataGridViewTextBoxColumn.Width = 144;
            // 
            // modelDataGridViewTextBoxColumn
            // 
            this.modelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            this.modelDataGridViewTextBoxColumn.HeaderText = "Модель";
            this.modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            this.modelDataGridViewTextBoxColumn.ReadOnly = true;
            this.modelDataGridViewTextBoxColumn.Width = 88;
            // 
            // registerSignDataGridViewTextBoxColumn
            // 
            this.registerSignDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.registerSignDataGridViewTextBoxColumn.DataPropertyName = "RegisterSign";
            this.registerSignDataGridViewTextBoxColumn.HeaderText = "Гос. номер";
            this.registerSignDataGridViewTextBoxColumn.Name = "registerSignDataGridViewTextBoxColumn";
            this.registerSignDataGridViewTextBoxColumn.ReadOnly = true;
            this.registerSignDataGridViewTextBoxColumn.Width = 110;
            // 
            // statusCarDataGridViewTextBoxColumn
            // 
            this.statusCarDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusCarDataGridViewTextBoxColumn.DataPropertyName = "StatusCar";
            this.statusCarDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusCarDataGridViewTextBoxColumn.Name = "statusCarDataGridViewTextBoxColumn";
            this.statusCarDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusCarDataGridViewTextBoxColumn.Width = 77;
            // 
            // TransportUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pMain);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TransportUserControl";
            this.Size = new System.Drawing.Size(1100, 632);
            this.pMain.ResumeLayout(false);
            this.pMainTwo.ResumeLayout(false);
            this.pMainTwo.PerformLayout();
            this.pMainCar.ResumeLayout(false);
            this.pMainCar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pSpecifications.ResumeLayout(false);
            this.pSpecifications.PerformLayout();
            this.ppSpecificationCar.ResumeLayout(false);
            this.ppSpecificationCar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCarView)).EndInit();
            this.tsTransport.ResumeLayout(false);
            this.tsTransport.PerformLayout();
            this.pFilters.ResumeLayout(false);
            this.pFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Panel pFilters;
        private System.Windows.Forms.Panel pMainTwo;
        private System.Windows.Forms.ToolStrip tsTransport;
        private System.Windows.Forms.ToolStripButton tsbInsertCar;
        private System.Windows.Forms.ToolStripButton tsbUpdateCar;
        private System.Windows.Forms.ToolStripButton tsbFunctionCar;
        private System.Windows.Forms.DataGridView dgvCarView;
        private System.Windows.Forms.BindingSource bsCarView;
        private System.Windows.Forms.ToolStripButton tsbDeleteCar;
        private System.Windows.Forms.Timer tCarView;
        private System.Windows.Forms.Label lCarPhoto;
        private System.Windows.Forms.PictureBox pbCar;
        private System.Windows.Forms.Panel pMainCar;
        private System.Windows.Forms.Panel pSpecifications;
        private System.Windows.Forms.Label lSpecifications;
        private System.Windows.Forms.Label lTypeCar_;
        private System.Windows.Forms.Panel ppSpecificationCar;
        private System.Windows.Forms.Label lStatusCar_;
        private System.Windows.Forms.Label lRegisterSign_;
        private System.Windows.Forms.Label lModelCar_;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lStatusCar;
        private System.Windows.Forms.Label lTypeCar;
        private System.Windows.Forms.Label lRegisterSign;
        private System.Windows.Forms.Label lModelCar;
        private System.Windows.Forms.ComboBox cbSortCar;
        private System.Windows.Forms.Label lSortCar;
        private System.Windows.Forms.MaskedTextBox mtbSearchCar;
        private System.Windows.Forms.ComboBox cbSearchCar;
        private System.Windows.Forms.Label lSearchCar;
        private System.Windows.Forms.ComboBox cbSearchStatusCar;
        private System.Windows.Forms.Label lTransportNotFound;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeCarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registerSignDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusCarDataGridViewTextBoxColumn;
    }
}
