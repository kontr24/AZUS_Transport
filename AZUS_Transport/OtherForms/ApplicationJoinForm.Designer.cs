
namespace AZUS_Transport.OtherForms
{
    partial class ApplicationJoinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationJoinForm));
            this.pMain = new System.Windows.Forms.Panel();
            this.pbComment = new System.Windows.Forms.PictureBox();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.lComment = new System.Windows.Forms.Label();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApplicationJoin = new System.Windows.Forms.Button();
            this.dgvApplicationView = new System.Windows.Forms.DataGridView();
            this.RowSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ApplicationNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.divisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.economistDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intercityСityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purposeUsingTransportDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daysWorkerOrWeekendDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobilePhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeCarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityPassengersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargoWeightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placeSubmissionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentClientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сommentDirectorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сommentEconomistDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сommentDepartmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сommentDispatcherNIIARDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сommentDispatcherATADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directorStatusDoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.economistStatusDoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentStatusDoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dispatcherNIIARStatusDoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dispatcherATAStatusDoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsApplicationsView = new System.Windows.Forms.BindingSource(this.components);
            this.msAgreedApplications = new System.Windows.Forms.MenuStrip();
            this.tsmiApplicationsAssociation = new System.Windows.Forms.ToolStripMenuItem();
            this.niTaskbar = new System.Windows.Forms.NotifyIcon(this.components);
            this.pMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsApplicationsView)).BeginInit();
            this.msAgreedApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMain
            // 
            this.pMain.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.pMain.Controls.Add(this.pbComment);
            this.pMain.Controls.Add(this.tbComment);
            this.pMain.Controls.Add(this.lComment);
            this.pMain.Controls.Add(this.btnReject);
            this.pMain.Controls.Add(this.btnCancel);
            this.pMain.Controls.Add(this.btnApplicationJoin);
            this.pMain.Controls.Add(this.dgvApplicationView);
            this.pMain.Controls.Add(this.msAgreedApplications);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1054, 291);
            this.pMain.TabIndex = 0;
            // 
            // pbComment
            // 
            this.pbComment.ErrorImage = null;
            this.pbComment.Image = global::AZUS_Transport.Properties.Resources.Comment;
            this.pbComment.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbComment.InitialImage")));
            this.pbComment.Location = new System.Drawing.Point(12, 177);
            this.pbComment.Name = "pbComment";
            this.pbComment.Size = new System.Drawing.Size(20, 19);
            this.pbComment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbComment.TabIndex = 36;
            this.pbComment.TabStop = false;
            this.pbComment.Visible = false;
            // 
            // tbComment
            // 
            this.tbComment.ForeColor = System.Drawing.Color.Silver;
            this.tbComment.Location = new System.Drawing.Point(12, 198);
            this.tbComment.MaxLength = 500;
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(590, 80);
            this.tbComment.TabIndex = 35;
            this.tbComment.TabStop = false;
            this.tbComment.Text = "Комментарий";
            this.tbComment.Visible = false;
            this.tbComment.Enter += new System.EventHandler(this.tbComment_Enter);
            this.tbComment.Leave += new System.EventHandler(this.tbComment_Leave);
            // 
            // lComment
            // 
            this.lComment.AutoSize = true;
            this.lComment.Location = new System.Drawing.Point(38, 177);
            this.lComment.Name = "lComment";
            this.lComment.Size = new System.Drawing.Size(270, 20);
            this.lComment.TabIndex = 34;
            this.lComment.Text = "Комментарий / Причина отклонения";
            this.lComment.Visible = false;
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.Crimson;
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(638, 243);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(131, 35);
            this.btnReject.TabIndex = 33;
            this.btnReject.Text = "Не исполнено";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Visible = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(912, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 35);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApplicationJoin
            // 
            this.btnApplicationJoin.BackColor = System.Drawing.Color.Blue;
            this.btnApplicationJoin.FlatAppearance.BorderSize = 0;
            this.btnApplicationJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplicationJoin.ForeColor = System.Drawing.Color.White;
            this.btnApplicationJoin.Location = new System.Drawing.Point(775, 243);
            this.btnApplicationJoin.Name = "btnApplicationJoin";
            this.btnApplicationJoin.Size = new System.Drawing.Size(131, 35);
            this.btnApplicationJoin.TabIndex = 23;
            this.btnApplicationJoin.Text = "Объединить";
            this.btnApplicationJoin.UseVisualStyleBackColor = false;
            this.btnApplicationJoin.Click += new System.EventHandler(this.btnApplicationJoin_Click);
            // 
            // dgvApplicationView
            // 
            this.dgvApplicationView.AllowUserToAddRows = false;
            this.dgvApplicationView.AllowUserToDeleteRows = false;
            this.dgvApplicationView.AutoGenerateColumns = false;
            this.dgvApplicationView.BackgroundColor = System.Drawing.Color.White;
            this.dgvApplicationView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicationView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowSelection,
            this.ApplicationNumber,
            this.clientDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.postDataGridViewTextBoxColumn,
            this.divisionDataGridViewTextBoxColumn,
            this.directorDataGridViewTextBoxColumn,
            this.economistDataGridViewTextBoxColumn,
            this.cPCDataGridViewTextBoxColumn,
            this.intercityСityDataGridViewTextBoxColumn,
            this.purposeUsingTransportDataGridViewTextBoxColumn,
            this.daysWorkerOrWeekendDataGridViewTextBoxColumn,
            this.workPhoneDataGridViewTextBoxColumn,
            this.mobilePhoneDataGridViewTextBoxColumn,
            this.dateCreationDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn,
            this.typeCarDataGridViewTextBoxColumn,
            this.quantityPassengersDataGridViewTextBoxColumn,
            this.cargoWeightDataGridViewTextBoxColumn,
            this.placeSubmissionDataGridViewTextBoxColumn,
            this.routeDataGridViewTextBoxColumn,
            this.commentClientDataGridViewTextBoxColumn,
            this.сommentDirectorDataGridViewTextBoxColumn,
            this.сommentEconomistDataGridViewTextBoxColumn,
            this.сommentDepartmentDataGridViewTextBoxColumn,
            this.сommentDispatcherNIIARDataGridViewTextBoxColumn,
            this.сommentDispatcherATADataGridViewTextBoxColumn,
            this.directorStatusDoneDataGridViewTextBoxColumn,
            this.economistStatusDoneDataGridViewTextBoxColumn,
            this.departmentStatusDoneDataGridViewTextBoxColumn,
            this.dispatcherNIIARStatusDoneDataGridViewTextBoxColumn,
            this.dispatcherATAStatusDoneDataGridViewTextBoxColumn});
            this.dgvApplicationView.DataSource = this.bsApplicationsView;
            this.dgvApplicationView.Location = new System.Drawing.Point(12, 37);
            this.dgvApplicationView.Name = "dgvApplicationView";
            this.dgvApplicationView.RowHeadersVisible = false;
            this.dgvApplicationView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvApplicationView.Size = new System.Drawing.Size(1030, 134);
            this.dgvApplicationView.TabIndex = 10;
            this.dgvApplicationView.TabStop = false;
            this.dgvApplicationView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApplicationView_CellValueChanged);
            // 
            // RowSelection
            // 
            this.RowSelection.HeaderText = "Выбор заявки";
            this.RowSelection.Name = "RowSelection";
            // 
            // ApplicationNumber
            // 
            this.ApplicationNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ApplicationNumber.DataPropertyName = "Id";
            this.ApplicationNumber.HeaderText = "№";
            this.ApplicationNumber.Name = "ApplicationNumber";
            this.ApplicationNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ApplicationNumber.Width = 32;
            // 
            // clientDataGridViewTextBoxColumn
            // 
            this.clientDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clientDataGridViewTextBoxColumn.DataPropertyName = "Client";
            this.clientDataGridViewTextBoxColumn.HeaderText = "Клиент";
            this.clientDataGridViewTextBoxColumn.Name = "clientDataGridViewTextBoxColumn";
            this.clientDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clientDataGridViewTextBoxColumn.Width = 64;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Visible = false;
            // 
            // postDataGridViewTextBoxColumn
            // 
            this.postDataGridViewTextBoxColumn.DataPropertyName = "Post";
            this.postDataGridViewTextBoxColumn.HeaderText = "Post";
            this.postDataGridViewTextBoxColumn.Name = "postDataGridViewTextBoxColumn";
            this.postDataGridViewTextBoxColumn.Visible = false;
            // 
            // divisionDataGridViewTextBoxColumn
            // 
            this.divisionDataGridViewTextBoxColumn.DataPropertyName = "Division";
            this.divisionDataGridViewTextBoxColumn.HeaderText = "Division";
            this.divisionDataGridViewTextBoxColumn.Name = "divisionDataGridViewTextBoxColumn";
            this.divisionDataGridViewTextBoxColumn.Visible = false;
            // 
            // directorDataGridViewTextBoxColumn
            // 
            this.directorDataGridViewTextBoxColumn.DataPropertyName = "Director";
            this.directorDataGridViewTextBoxColumn.HeaderText = "Director";
            this.directorDataGridViewTextBoxColumn.Name = "directorDataGridViewTextBoxColumn";
            this.directorDataGridViewTextBoxColumn.Visible = false;
            // 
            // economistDataGridViewTextBoxColumn
            // 
            this.economistDataGridViewTextBoxColumn.DataPropertyName = "Economist";
            this.economistDataGridViewTextBoxColumn.HeaderText = "Economist";
            this.economistDataGridViewTextBoxColumn.Name = "economistDataGridViewTextBoxColumn";
            this.economistDataGridViewTextBoxColumn.Visible = false;
            // 
            // cPCDataGridViewTextBoxColumn
            // 
            this.cPCDataGridViewTextBoxColumn.DataPropertyName = "CPC";
            this.cPCDataGridViewTextBoxColumn.HeaderText = "CPC";
            this.cPCDataGridViewTextBoxColumn.Name = "cPCDataGridViewTextBoxColumn";
            this.cPCDataGridViewTextBoxColumn.Visible = false;
            // 
            // intercityСityDataGridViewTextBoxColumn
            // 
            this.intercityСityDataGridViewTextBoxColumn.DataPropertyName = "IntercityСity";
            this.intercityСityDataGridViewTextBoxColumn.HeaderText = "IntercityСity";
            this.intercityСityDataGridViewTextBoxColumn.Name = "intercityСityDataGridViewTextBoxColumn";
            this.intercityСityDataGridViewTextBoxColumn.Visible = false;
            // 
            // purposeUsingTransportDataGridViewTextBoxColumn
            // 
            this.purposeUsingTransportDataGridViewTextBoxColumn.DataPropertyName = "PurposeUsingTransport";
            this.purposeUsingTransportDataGridViewTextBoxColumn.HeaderText = "PurposeUsingTransport";
            this.purposeUsingTransportDataGridViewTextBoxColumn.Name = "purposeUsingTransportDataGridViewTextBoxColumn";
            this.purposeUsingTransportDataGridViewTextBoxColumn.Visible = false;
            // 
            // daysWorkerOrWeekendDataGridViewTextBoxColumn
            // 
            this.daysWorkerOrWeekendDataGridViewTextBoxColumn.DataPropertyName = "DaysWorkerOrWeekend";
            this.daysWorkerOrWeekendDataGridViewTextBoxColumn.HeaderText = "DaysWorkerOrWeekend";
            this.daysWorkerOrWeekendDataGridViewTextBoxColumn.Name = "daysWorkerOrWeekendDataGridViewTextBoxColumn";
            this.daysWorkerOrWeekendDataGridViewTextBoxColumn.Visible = false;
            // 
            // workPhoneDataGridViewTextBoxColumn
            // 
            this.workPhoneDataGridViewTextBoxColumn.DataPropertyName = "WorkPhone";
            this.workPhoneDataGridViewTextBoxColumn.HeaderText = "WorkPhone";
            this.workPhoneDataGridViewTextBoxColumn.Name = "workPhoneDataGridViewTextBoxColumn";
            this.workPhoneDataGridViewTextBoxColumn.Visible = false;
            // 
            // mobilePhoneDataGridViewTextBoxColumn
            // 
            this.mobilePhoneDataGridViewTextBoxColumn.DataPropertyName = "MobilePhone";
            this.mobilePhoneDataGridViewTextBoxColumn.HeaderText = "MobilePhone";
            this.mobilePhoneDataGridViewTextBoxColumn.Name = "mobilePhoneDataGridViewTextBoxColumn";
            this.mobilePhoneDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateCreationDataGridViewTextBoxColumn
            // 
            this.dateCreationDataGridViewTextBoxColumn.DataPropertyName = "DateCreation";
            this.dateCreationDataGridViewTextBoxColumn.HeaderText = "DateCreation";
            this.dateCreationDataGridViewTextBoxColumn.Name = "dateCreationDataGridViewTextBoxColumn";
            this.dateCreationDataGridViewTextBoxColumn.Visible = false;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "Начало работы";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.startDateDataGridViewTextBoxColumn.Width = 111;
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "Завершение работы";
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.endDateDataGridViewTextBoxColumn.Width = 142;
            // 
            // typeCarDataGridViewTextBoxColumn
            // 
            this.typeCarDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.typeCarDataGridViewTextBoxColumn.DataPropertyName = "TypeCar";
            this.typeCarDataGridViewTextBoxColumn.HeaderText = "Тип транспорта";
            this.typeCarDataGridViewTextBoxColumn.Name = "typeCarDataGridViewTextBoxColumn";
            this.typeCarDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.typeCarDataGridViewTextBoxColumn.Width = 113;
            // 
            // quantityPassengersDataGridViewTextBoxColumn
            // 
            this.quantityPassengersDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityPassengersDataGridViewTextBoxColumn.DataPropertyName = "QuantityPassengers";
            this.quantityPassengersDataGridViewTextBoxColumn.HeaderText = "Кол-во пассажиров";
            this.quantityPassengersDataGridViewTextBoxColumn.Name = "quantityPassengersDataGridViewTextBoxColumn";
            this.quantityPassengersDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantityPassengersDataGridViewTextBoxColumn.Width = 138;
            // 
            // cargoWeightDataGridViewTextBoxColumn
            // 
            this.cargoWeightDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cargoWeightDataGridViewTextBoxColumn.DataPropertyName = "CargoWeight";
            this.cargoWeightDataGridViewTextBoxColumn.HeaderText = "Груз (кг)";
            this.cargoWeightDataGridViewTextBoxColumn.Name = "cargoWeightDataGridViewTextBoxColumn";
            this.cargoWeightDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cargoWeightDataGridViewTextBoxColumn.Width = 65;
            // 
            // placeSubmissionDataGridViewTextBoxColumn
            // 
            this.placeSubmissionDataGridViewTextBoxColumn.DataPropertyName = "PlaceSubmission";
            this.placeSubmissionDataGridViewTextBoxColumn.HeaderText = "PlaceSubmission";
            this.placeSubmissionDataGridViewTextBoxColumn.Name = "placeSubmissionDataGridViewTextBoxColumn";
            this.placeSubmissionDataGridViewTextBoxColumn.Visible = false;
            // 
            // routeDataGridViewTextBoxColumn
            // 
            this.routeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.routeDataGridViewTextBoxColumn.DataPropertyName = "Route";
            this.routeDataGridViewTextBoxColumn.HeaderText = "Маршрут";
            this.routeDataGridViewTextBoxColumn.Name = "routeDataGridViewTextBoxColumn";
            this.routeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.routeDataGridViewTextBoxColumn.Width = 79;
            // 
            // commentClientDataGridViewTextBoxColumn
            // 
            this.commentClientDataGridViewTextBoxColumn.DataPropertyName = "CommentClient";
            this.commentClientDataGridViewTextBoxColumn.HeaderText = "CommentClient";
            this.commentClientDataGridViewTextBoxColumn.Name = "commentClientDataGridViewTextBoxColumn";
            this.commentClientDataGridViewTextBoxColumn.Visible = false;
            // 
            // сommentDirectorDataGridViewTextBoxColumn
            // 
            this.сommentDirectorDataGridViewTextBoxColumn.DataPropertyName = "СommentDirector";
            this.сommentDirectorDataGridViewTextBoxColumn.HeaderText = "СommentDirector";
            this.сommentDirectorDataGridViewTextBoxColumn.Name = "сommentDirectorDataGridViewTextBoxColumn";
            this.сommentDirectorDataGridViewTextBoxColumn.Visible = false;
            // 
            // сommentEconomistDataGridViewTextBoxColumn
            // 
            this.сommentEconomistDataGridViewTextBoxColumn.DataPropertyName = "СommentEconomist";
            this.сommentEconomistDataGridViewTextBoxColumn.HeaderText = "СommentEconomist";
            this.сommentEconomistDataGridViewTextBoxColumn.Name = "сommentEconomistDataGridViewTextBoxColumn";
            this.сommentEconomistDataGridViewTextBoxColumn.Visible = false;
            // 
            // сommentDepartmentDataGridViewTextBoxColumn
            // 
            this.сommentDepartmentDataGridViewTextBoxColumn.DataPropertyName = "СommentDepartment";
            this.сommentDepartmentDataGridViewTextBoxColumn.HeaderText = "СommentDepartment";
            this.сommentDepartmentDataGridViewTextBoxColumn.Name = "сommentDepartmentDataGridViewTextBoxColumn";
            this.сommentDepartmentDataGridViewTextBoxColumn.Visible = false;
            // 
            // сommentDispatcherNIIARDataGridViewTextBoxColumn
            // 
            this.сommentDispatcherNIIARDataGridViewTextBoxColumn.DataPropertyName = "СommentDispatcherNIIAR";
            this.сommentDispatcherNIIARDataGridViewTextBoxColumn.HeaderText = "СommentDispatcherNIIAR";
            this.сommentDispatcherNIIARDataGridViewTextBoxColumn.Name = "сommentDispatcherNIIARDataGridViewTextBoxColumn";
            this.сommentDispatcherNIIARDataGridViewTextBoxColumn.Visible = false;
            // 
            // сommentDispatcherATADataGridViewTextBoxColumn
            // 
            this.сommentDispatcherATADataGridViewTextBoxColumn.DataPropertyName = "СommentDispatcherATA";
            this.сommentDispatcherATADataGridViewTextBoxColumn.HeaderText = "СommentDispatcherATA";
            this.сommentDispatcherATADataGridViewTextBoxColumn.Name = "сommentDispatcherATADataGridViewTextBoxColumn";
            this.сommentDispatcherATADataGridViewTextBoxColumn.Visible = false;
            // 
            // directorStatusDoneDataGridViewTextBoxColumn
            // 
            this.directorStatusDoneDataGridViewTextBoxColumn.DataPropertyName = "DirectorStatusDone";
            this.directorStatusDoneDataGridViewTextBoxColumn.HeaderText = "DirectorStatusDone";
            this.directorStatusDoneDataGridViewTextBoxColumn.Name = "directorStatusDoneDataGridViewTextBoxColumn";
            this.directorStatusDoneDataGridViewTextBoxColumn.Visible = false;
            // 
            // economistStatusDoneDataGridViewTextBoxColumn
            // 
            this.economistStatusDoneDataGridViewTextBoxColumn.DataPropertyName = "EconomistStatusDone";
            this.economistStatusDoneDataGridViewTextBoxColumn.HeaderText = "EconomistStatusDone";
            this.economistStatusDoneDataGridViewTextBoxColumn.Name = "economistStatusDoneDataGridViewTextBoxColumn";
            this.economistStatusDoneDataGridViewTextBoxColumn.Visible = false;
            // 
            // departmentStatusDoneDataGridViewTextBoxColumn
            // 
            this.departmentStatusDoneDataGridViewTextBoxColumn.DataPropertyName = "DepartmentStatusDone";
            this.departmentStatusDoneDataGridViewTextBoxColumn.HeaderText = "DepartmentStatusDone";
            this.departmentStatusDoneDataGridViewTextBoxColumn.Name = "departmentStatusDoneDataGridViewTextBoxColumn";
            this.departmentStatusDoneDataGridViewTextBoxColumn.Visible = false;
            // 
            // dispatcherNIIARStatusDoneDataGridViewTextBoxColumn
            // 
            this.dispatcherNIIARStatusDoneDataGridViewTextBoxColumn.DataPropertyName = "DispatcherNIIAR_StatusDone";
            this.dispatcherNIIARStatusDoneDataGridViewTextBoxColumn.HeaderText = "DispatcherNIIAR_StatusDone";
            this.dispatcherNIIARStatusDoneDataGridViewTextBoxColumn.Name = "dispatcherNIIARStatusDoneDataGridViewTextBoxColumn";
            this.dispatcherNIIARStatusDoneDataGridViewTextBoxColumn.Visible = false;
            // 
            // dispatcherATAStatusDoneDataGridViewTextBoxColumn
            // 
            this.dispatcherATAStatusDoneDataGridViewTextBoxColumn.DataPropertyName = "DispatcherATA_StatusDone";
            this.dispatcherATAStatusDoneDataGridViewTextBoxColumn.HeaderText = "DispatcherATA_StatusDone";
            this.dispatcherATAStatusDoneDataGridViewTextBoxColumn.Name = "dispatcherATAStatusDoneDataGridViewTextBoxColumn";
            this.dispatcherATAStatusDoneDataGridViewTextBoxColumn.Visible = false;
            // 
            // bsApplicationsView
            // 
            this.bsApplicationsView.DataSource = typeof(AZUS_Transport.Models.ApplicationView);
            // 
            // msAgreedApplications
            // 
            this.msAgreedApplications.BackColor = System.Drawing.Color.Sienna;
            this.msAgreedApplications.Dock = System.Windows.Forms.DockStyle.None;
            this.msAgreedApplications.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.msAgreedApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiApplicationsAssociation});
            this.msAgreedApplications.Location = new System.Drawing.Point(12, 6);
            this.msAgreedApplications.Name = "msAgreedApplications";
            this.msAgreedApplications.Size = new System.Drawing.Size(197, 28);
            this.msAgreedApplications.TabIndex = 11;
            this.msAgreedApplications.Text = "menuStrip3";
            // 
            // tsmiApplicationsAssociation
            // 
            this.tsmiApplicationsAssociation.ForeColor = System.Drawing.Color.White;
            this.tsmiApplicationsAssociation.Name = "tsmiApplicationsAssociation";
            this.tsmiApplicationsAssociation.Size = new System.Drawing.Size(189, 24);
            this.tsmiApplicationsAssociation.Text = "Заявки на объединение";
            // 
            // niTaskbar
            // 
            this.niTaskbar.Icon = ((System.Drawing.Icon)(resources.GetObject("niTaskbar.Icon")));
            this.niTaskbar.Text = "АСУЗ \"Транспорт\"";
            this.niTaskbar.Visible = true;
            // 
            // ApplicationJoinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1054, 291);
            this.Controls.Add(this.pMain);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApplicationJoinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Объединение заявок";
            this.Load += new System.EventHandler(this.ApplicationJoinForm_Load);
            this.pMain.ResumeLayout(false);
            this.pMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsApplicationsView)).EndInit();
            this.msAgreedApplications.ResumeLayout(false);
            this.msAgreedApplications.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.DataGridView dgvApplicationView;
        private System.Windows.Forms.MenuStrip msAgreedApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmiApplicationsAssociation;
        private System.Windows.Forms.BindingSource bsApplicationsView;
        private System.Windows.Forms.Button btnApplicationJoin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RowSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicationNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn divisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn economistDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn intercityСityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purposeUsingTransportDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn daysWorkerOrWeekendDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobilePhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeCarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityPassengersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargoWeightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placeSubmissionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn routeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentClientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сommentDirectorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сommentEconomistDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сommentDepartmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сommentDispatcherNIIARDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сommentDispatcherATADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directorStatusDoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn economistStatusDoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentStatusDoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dispatcherNIIARStatusDoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dispatcherATAStatusDoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.PictureBox pbComment;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label lComment;
        private System.Windows.Forms.NotifyIcon niTaskbar;
    }
}