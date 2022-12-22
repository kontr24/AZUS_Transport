using AZUS_Transport.Classes;
using AZUS_Transport.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AZUS_Transport.OtherForms;
using System.Net.Mail;
using System.Net;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using OfficeOpenXml.Style;
using AZUS_Transport.Forms;
using System.Threading;
//using Timer = System.Timers.Timer;

namespace AZUS_Transport.MyUserControl
{
    public partial class MainUserControl : UserControl
    {
        Thread AuthorizationFormFlow;

        private Applications _App;
        private Applications _AppAgreed;
        private Users _Us;
        private int _Rgs = 1;
        private int _DvID;
        private ApplicationView _AppView;

        private int _MaxId = 0;

        private string _Msg;

        //public FormWindowState WindowState { get; set; }
        //public bool ShowInTaskbar { get; set; }

        public MainUserControl()
        {
            InitializeComponent();
            //dgvApplication.RowsAdded += dgvApplication_RowsAdded;
            LoadDataBase();

        }

        private void BlankPage()
        {
            lNumber.Text = null;
            lStatus.Text = null;
            lTimeLeft.Text = "Времени осталось:";
            lClients.Text = null;
            lEmail.Text = null;
            lDivision.Text = null;
            lPost.Text = null;
            lDivision.Text = null;
            lBuilding.Text = null;
            lRoom.Text = null;
            lWorkPhone.Text = null;
            lMobilePhone.Text = null;
            lStartDate.Text = null;
            lEndDate.Text = null;
            lTypeCar.Text = null;
            lPassenger.Text = null;
            lCargo.Text = null;
            lPlaceSubmission.Text = null;
            lRoute.Text = null;

            lDirectorFullName.Text = null;
            lEconomistFullName.Text = null;
            lDaysWorkerOrWeekend.Text = null;
            lIntercityСity.Text = null;
            lPurposeUsingTransport.Text = null;

            //lNumber.Visible = false;
            //lStatus.Visible = false;
            //lTimeLeft.Text = "Времени осталось:";
            //lClients.Visible = false;
            //lEmail.Visible = false;
            //lDivision.Visible = false;
            //lPost.Visible = false;
            //lDivision.Visible = false;
            //lDepartment.Visible = false;
            //lLocation.Visible = false;
            //lWorkPhone.Visible = false;
            //lMobilePhone.Visible = false;
            //lStartDate.Visible = false;
            //lEndDate.Visible = false;
            //lTypeCar.Visible = false;
            //lPassenger.Visible = false;
            //lCargo.Visible = false;
            //lPlaceSubmission.Visible = false;
            //lRoute.Visible = false;

            //lDirectorFullName.Visible = false;
            //lEconomistFullName.Visible = false;
            //lDaysWorkerOrWeekend.Visible = false;
            //lIntercityСity.Visible = false;
            //lPurposeUsingTransport.Visible = false;
        }



        private void DataPage()
        {
            lNumber.Visible = true;
            lStatus.Visible = true;
            lClients.Visible = true;
            lEmail.Visible = true;
            lDivision.Visible = true;
            lPost.Visible = true;
            lDivision.Visible = true;
            lBuilding.Visible = true;
            lRoom.Visible = true;
            lWorkPhone.Visible = true;
            lMobilePhone.Visible = true;
            lDirectorFullName.Visible = true;
            lEconomistFullName.Visible = true;
            lDaysWorkerOrWeekend.Visible = true;
            lStartDate.Visible = true;
            lEndDate.Visible = true;
            lIntercityСity.Visible = true;
            lTypeCar.Visible = true;
            lPassenger.Visible = true;
            lCargo.Visible = true;
            lPlaceSubmission.Visible = true;
            lRoute.Visible = true;
            lPurposeUsingTransport.Visible = true;
        }

        //максимальный id
        private int CheckMaxId()
        {
            int tek_max_id = 0;
            using (var db = new MyDataModelDataContext())
            {
                if (GeneralClass.mode == (int)GeneralClass.Status.Director)
                {

                    var usDrc = db.Users.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                    var us = db.Users.FirstOrDefault(x => x.DivisionID == usDrc.DivisionID);
                    var idMax = db.ApplicationView.Where(x => DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") && x.Client == us.SurName + " " + us.Name + " " + us.Partonymic).Max(x => x.Id);

                    tek_max_id = idMax;
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.Economist)
                {
                    var usEcn = db.Users.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                    var usr = db.Users.FirstOrDefault(x => x.DivisionID == usEcn.DivisionID);

                    var idMax = db.ApplicationView.Where(x => DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "На рассмотрении") && x.Client == usr.SurName + " " + usr.Name + " " + usr.Partonymic).Max(x => x.Id);
                    tek_max_id = idMax;
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.Department)
                {
                    var idMax = db.ApplicationView.Where(x => DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && (x.DepartmentStatusDone == "На рассмотрении" && x.EconomistStatusDone == "Согласовано" && (x.IntercityСity == false || x.DaysWorkerOrWeekend == false))).Max(x => x.Id);
                    tek_max_id = idMax;
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
                {
                    var idMax = db.ApplicationView.Where(x => DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && ((x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано"
                    && x.DepartmentStatusDone == "Согласовано"
            && x.DispatcherNIIAR_StatusDone == "На рассмотрении" && ((x.DaysWorkerOrWeekend == true && x.IntercityСity == false) ||
             (x.DaysWorkerOrWeekend == false && x.IntercityСity == true) || (x.DaysWorkerOrWeekend == false && x.IntercityСity == false)
           || (x.DaysWorkerOrWeekend == true && x.IntercityСity == true))) || (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано"
                    && x.DepartmentStatusDone == "На рассмотрении"
            && x.DispatcherNIIAR_StatusDone == "На рассмотрении" && (x.DaysWorkerOrWeekend == true && x.IntercityСity == true)))).Max(x => x.Id);
                    tek_max_id = idMax;
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                {
                    var idMax = db.ApplicationView.Where(x => /*DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) &&*/ (
               (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
               (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                && (x.DepartmentStatusDone != "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
               (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                && (x.DepartmentStatusDone == "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении").Max(x => x.Id);
                    tek_max_id = idMax;
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.Client)
                {
                    var idMax = db.ApplicationAgreedView.Where(x => (((x.Client == GeneralClass.client && x.DispatcherNIIAR_StatusDone == "Согласовано") ||
                      (x.Client == GeneralClass.client && x.DirectorStatusDone == "Отклонена") || (x.Client == GeneralClass.client && x.EconomistStatusDone == "Отклонена") || (x.Client == GeneralClass.client && x.DispatcherNIIAR_StatusDone == "Отклонена") || (x.Client == GeneralClass.client && x.DepartmentStatusDone == "Отклонена"))) ||
                      (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && ((x.Client == GeneralClass.client && x.DirectorStatusDone == "На рассмотрении") ||
                       (x.Client == GeneralClass.client && x.EconomistStatusDone == "На рассмотрении") ||
                      (x.Client == GeneralClass.client && x.DispatcherNIIAR_StatusDone == "На рассмотрении") || (x.Client == GeneralClass.client && x.DispatcherNIIAR_StatusDone == "На рассмотрении")
                       && (x.Client == GeneralClass.client && x.DepartmentStatusDone == "На рассмотрении") || (x.Client == GeneralClass.client && x.DirectorStatusDone == "Согласовано") ||
                       (x.Client == GeneralClass.client && x.EconomistStatusDone == "Согласовано") || (x.Client == GeneralClass.client && x.DepartmentStatusDone == "Согласовано")))).Max(x => x.Id);
                    tek_max_id = idMax;
                }
            }
            return tek_max_id;
        }
        //максимальный id

        private void NotificationNewApp()
        {
            // задаем иконку всплывающей подсказки
            niTaskbar.BalloonTipIcon = ToolTipIcon.Info;

            if (GeneralClass.mode != (int)GeneralClass.Status.Client)
            { // задаем текст подсказки
                niTaskbar.BalloonTipText = "Поступила новая заявка № " + CheckMaxId();
            }
            else
            {
                niTaskbar.BalloonTipText = "Ваша заявка № " + CheckMaxId() + " рассмотрена!";
            }
            // устанавливаем заголовка
            niTaskbar.BalloonTipTitle = "Информация";
            niTaskbar.ShowBalloonTip(12);
        }

        public void LoadDataBase() //Загрузка данных таблицы
        {
            Properties.Settings.Default.dataTime = DateTime.Now.ToString();
            Properties.Settings.Default.Save();

            var appView = bsApplicationsView.Current as ApplicationView;

            cbSearchApplications.SelectedIndex = 0;
            cbSortModeApplications.SelectedIndex = 0;
            tslUser.Text = GeneralClass.statusUser;
            dgvApplication.Enabled = true;


            try
            {
                //int position = bsApplicationsView.Position;
                //int positionAgree = bsApplicationAgreedView.Position;

                using (MyDataModelDataContext db = new MyDataModelDataContext())
                {

                    if (GeneralClass.mode == (int)GeneralClass.Status.Admin)
                    {
                        cbArchiveApplications.Visible = true;

                        tsmiAdmin.Visible = true;

                        tsmiAllApplications.Text = "Архив заявок";
                        pAll.Height = 903;
                        dgvApplication.Visible = false;
                        dgvApplicationAgreedView.Visible = true;
                        pSecondary.Visible = true;
                        pSecondary.Controls.Add(dgvApplicationAgreedView);// программное перемещение элемента в другую панель
                        dgvApplicationAgreedView.Location = new Point(0, 28);
                        dgvApplicationAgreedView.Dock = DockStyle.Fill;

                        pAddition.Visible = false;


                        msAgreedApplications.Visible = false;
                        //bsApplicationsView.DataSource = db.ApplicationView;
                        if (cbArchiveApplications.Checked == false)
                        {
                            tsmiAllApplications.Text = "Актуальные заявки";
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => /*x.StartDate > DateTime.Now &&*/ DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) &&
                         ((x.DirectorStatusDone == "На рассмотрении" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                        }
                        else
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => /*x.StartDate < DateTime.Now ||*/ DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) || ((x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && (x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                          x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена")));
                        }

                        //if (bsApplicationAgreedView.Count == 0)
                        //{
                        //    pInformation.Height = 844;
                        //    lSelectRequest.Text = "Заявок нет";

                        //    lSelectRequest.Visible = false;
                        //}

                        //pInformation.Height = 1374;
                        //pDetails.Height = 1282;
                        //pComments.Height = 507;

                    }
                    if (GeneralClass.mode == (int)GeneralClass.Status.Director)
                    {
                        tsbFunction.Visible = false;
                        var usDrc = db.Users.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                        var us = db.Users.FirstOrDefault(x => x.DivisionID == usDrc.DivisionID);

                        bsApplicationsView.DataSource = db.ApplicationView.Where(x => /*x.StartDate > DateTime.Now */DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") && x.Client == us.SurName + " " + us.Name + " " + us.Partonymic)/*.Where(x => x.Done == "В процессе").OrderBy(x => x.Client)*/;

                        btnDeclineApplication.Enabled = false;
                        btnTakeApplication.Enabled = false;
                        msAgreedApplications.Visible = false;

                        pComments.Height = 143;
                        pDetails.Height = 922;
                        pInformation.Height = 1005;

                        //оповещение если пришла новая заявка
                        if (bsApplicationsView.Count != 0)
                        {
                            if (_MaxId < CheckMaxId())
                            {
                                _MaxId = CheckMaxId();
                                NotificationNewApp();
                            }
                        }
                        //оповещение если пришла новая заявка
                    }

                    if (GeneralClass.mode == (int)GeneralClass.Status.Economist)
                    {
                        tsbFunction.Visible = false;

                        var usEcn = db.Users.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                        var usr = db.Users.FirstOrDefault(x => x.DivisionID == usEcn.DivisionID);

                        bsApplicationsView.DataSource = db.ApplicationView.Where(x => /*x.StartDate > DateTime.Now*/ DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "На рассмотрении") && x.Client == usr.SurName + " " + usr.Name + " " + usr.Partonymic)/*.Where(x => x.Done == "В процессе").OrderBy(x => x.Client)*/;

                        btnDeclineApplication.Enabled = false;
                        btnTakeApplication.Enabled = false;
                        msAgreedApplications.Visible = false;


                        pComments.Height = 268;
                        pDetails.Height = 1048;
                        pInformation.Height = 1137;

                        lCPC.Visible = true;
                        tbCPC.Visible = true;

                        if (bsApplicationsView.Count != 0)
                        {
                            if (_MaxId < CheckMaxId())
                            {
                                _MaxId = CheckMaxId();
                                NotificationNewApp();
                            }
                        }
                    }

                    if (GeneralClass.mode == (int)GeneralClass.Status.Department)
                    {
                        tsbFunction.Visible = false;
                        bsApplicationsView.DataSource = db.ApplicationView.Where(x => /*x.StartDate > DateTime.Now*/ DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && (x.DepartmentStatusDone == "На рассмотрении" && x.EconomistStatusDone == "Согласовано" && (x.IntercityСity == false || x.DaysWorkerOrWeekend == false)))/*.Where(x => x.Done == "В процессе").OrderBy(x => x.Client)*/;

                        btnDeclineApplication.Enabled = false;
                        btnTakeApplication.Enabled = false;
                        msAgreedApplications.Visible = false;

                        pComments.Height = 398;
                        pDetails.Height = 1179;
                        pInformation.Height = 1267;

                        if (bsApplicationsView.Count != 0)
                        {
                            if (_MaxId < CheckMaxId())
                            {
                                _MaxId = CheckMaxId();
                                NotificationNewApp();
                            }
                        }

                    }

                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
                    {
                        tsbFunction.Visible = false;

                        bsApplicationsView.DataSource = db.ApplicationView.Where(x => /*x.StartDate > DateTime.Now*/ DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && ((x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано"
                        && x.DepartmentStatusDone == "Согласовано"
                && x.DispatcherNIIAR_StatusDone == "На рассмотрении" && ((x.DaysWorkerOrWeekend == true && x.IntercityСity == false) ||
                 (x.DaysWorkerOrWeekend == false && x.IntercityСity == true) || (x.DaysWorkerOrWeekend == false && x.IntercityСity == false)
               || (x.DaysWorkerOrWeekend == true && x.IntercityСity == true))) || (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано"
                        && x.DepartmentStatusDone == "На рассмотрении"
                && x.DispatcherNIIAR_StatusDone == "На рассмотрении" && (x.DaysWorkerOrWeekend == true && x.IntercityСity == true))));

                        btnDeclineApplication.Enabled = false;
                        btnTakeApplication.Enabled = false;

                        lStamp.Visible = true;
                        lRegisterSign_.Visible = true;
                        btnCreate.Visible = true;
                        btnDelete.Visible = true;
                        msAgreedApplications.Visible = false;

                        pInformation.Height = 1394;
                        pDetails.Height = 1303;
                        pComments.Height = 523;

                        tsmiAllApplications.Text = "Заявки на согласование";

                        if (bsApplicationsView.Count != 0)
                        {
                            if (_MaxId < CheckMaxId())
                            {
                                _MaxId = CheckMaxId();
                                NotificationNewApp();
                            }
                        }

                    }
                    if (GeneralClass.mode == (int)GeneralClass.Status.Client)
                    {
                        tsbExcelSave.Visible = false;
                        tsbReport.Visible = false;
                        tsbFunction.Visible = false;

                        bsApplicationsView.DataSource = db.ApplicationView.Where(x => /*x.StartDate > DateTime.Now*/ DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && ((x.Client == GeneralClass.client && x.DirectorStatusDone == "На рассмотрении") ||
                        (x.Client == GeneralClass.client && x.DirectorStatusDone != "Отклонена") && (x.Client == GeneralClass.client && x.EconomistStatusDone != "Отклонена") &&
                        (x.Client == GeneralClass.client && x.DispatcherNIIAR_StatusDone != "Отклонена") && (x.Client == GeneralClass.client && x.DispatcherNIIAR_StatusDone != "Согласовано")
                         && (x.Client == GeneralClass.client && x.DepartmentStatusDone != "Отклонена")));
                        dgvApplicationAgreedView.Visible = true;

                        lComment.Visible = false;
                        tbComment.Visible = false;
                        dgvApplicationAgreedView.Visible = true;
                        btnTakeApplication.Visible = false;
                        btnDeclineApplication.Visible = false;
                        tsbCreateRequest.Visible = true;
                        pbComment.Visible = false;

                        //pComments.Height = 143;
                        //pDetails.Height = 922;
                        //pInformation.Height = 1005;

                        tsmiAdmin.Visible = false;

                        bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (((x.Client == GeneralClass.client && x.DispatcherNIIAR_StatusDone == "Согласовано") ||
                        (x.Client == GeneralClass.client && x.DirectorStatusDone == "Отклонена") || (x.Client == GeneralClass.client && x.EconomistStatusDone == "Отклонена") || (x.Client == GeneralClass.client && x.DispatcherNIIAR_StatusDone == "Отклонена") || (x.Client == GeneralClass.client && x.DepartmentStatusDone == "Отклонена"))) ||
                        (/*x.StartDate < DateTime.Now*/ DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && ((x.Client == GeneralClass.client && x.DirectorStatusDone == "На рассмотрении") ||
                       /* (x.Client == GeneralClass.client && x.DirectorStatusDone != "Отклонена")*/  (x.Client == GeneralClass.client && x.EconomistStatusDone == "На рассмотрении") ||
                        (x.Client == GeneralClass.client && x.DispatcherNIIAR_StatusDone == "На рассмотрении") || (x.Client == GeneralClass.client && x.DispatcherNIIAR_StatusDone == "На рассмотрении")
                         && (x.Client == GeneralClass.client && x.DepartmentStatusDone == "На рассмотрении") || (x.Client == GeneralClass.client && x.DirectorStatusDone == "Согласовано") ||
                         (x.Client == GeneralClass.client && x.EconomistStatusDone == "Согласовано") || (x.Client == GeneralClass.client && x.DepartmentStatusDone == "Согласовано"))));

                        if (bsApplicationAgreedView.Count != 0)
                        {
                            if (_MaxId < CheckMaxId())
                            {
                                _MaxId = CheckMaxId();
                                NotificationNewApp();
                            }
                        }
                    }

                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                    {
                        cbArchiveApplications.Visible = true;
                        tsmiAdmin.Visible = true;
                        tsmiUsers.Visible = false;
                        tsmiAllApplications.Text = "Заявки на исполнение";
                        if (cbArchiveApplications.Checked == false)
                        {
                            pSecondary.Visible = false;
                            bsApplicationsView.DataSource = db.ApplicationView.Where(x => /*DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) &&*/ (
                       (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone != "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone == "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении");

                            dgvApplication.Visible = true;
                            dgvApplicationAgreedView.Visible = false;

                            if (bsApplicationsView.Count != 0)

                            {
                                dgvApplication_CellClick(this.dgvApplication, new DataGridViewCellEventArgs(0, 0));
                            }

                        }
                        else
                        {
                            dgvApplication.ClearSelection();

                            btnDeclineApplication.Enabled = false;
                            btnTakeApplication.Enabled = false;

                            dgvApplication.Visible = false;
                            dgvApplicationAgreedView.Visible = true;
                            tsmiAllApplications.Text = "Архив заявок";
                            pSecondary.Visible = true;
                            pSecondary.Controls.Add(dgvApplicationAgreedView);// программное перемещение элемента в другую панель
                            dgvApplicationAgreedView.Location = new Point(0, 28);
                            dgvApplicationAgreedView.Dock = DockStyle.Fill;



                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => /*x.StartDate < DateTime.Now ||/*(DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) || DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0)) &&*/ (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                         x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                            if (bsApplicationAgreedView.Count != 0)

                            {
                                dgvApplicationAgreedView_CellClick(this.dgvApplicationAgreedView, new DataGridViewCellEventArgs(0, 0));
                            }
                        }
                        btnTakeApplication.Text = "Исполнено";
                        btnDeclineApplication.Text = "Не исполнено";
                        btnDeclineApplication.Enabled = false;
                        btnTakeApplication.Enabled = false;
                        msAgreedApplications.Visible = false;

                        if (bsApplicationsView.Count != 0)
                        {
                            if (_MaxId < CheckMaxId())
                            {
                                _MaxId = CheckMaxId();
                                NotificationNewApp();
                            }
                        }
                    }
                    //if (GeneralClass.mode == (int)GeneralClass.Status.Client)
                    //{
                    //    bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.Client == GeneralClass.client && x.DispatchersStatusDone == "Согласовано") || (x.Client == GeneralClass.client && x.DirectorStatusDone == "Отклонена") || (x.Client == GeneralClass.client && x.EconomistStatusDone == "Отклонена") || (x.Client == GeneralClass.client && x.DispatchersStatusDone == "Отклонена"));
                    //    dgvApplicationAgreedView.Visible = true;

                    //}


                    if (appView == null  /*bsApplicationsView.Count == 0*/ && GeneralClass.mode != (int)GeneralClass.Status.Admin)
                    {
                        BlankPage();
                        if (dgvApplication.Visible == true /*&& lNumber.Text == null*/)
                        {
                            lSelectRequest.Visible = true;
                            lSelectRequest.Text = "Заявок нет";
                            if (GeneralClass.mode != (int)GeneralClass.Status.Client)
                            {
                                pInformation.Height = 846;
                                pDetails.Height = 757;
                            }

                        }

                        btnCreate.Enabled = false;
                        dgvApplication.Enabled = true;


                    }
                    else
                    {

                        //if (dgvApplication.Visible == true /*&& lNumber.Text == null*/)
                        //{
                        //    lSelectRequest.Visible = true;
                        //    lSelectRequest.Text = "Выберите заявку";
                        //    pInformation.Height = 846;
                        //    pDetails.Height = 757;

                        //}
                        if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
                        {
                            btnCreate.Enabled = true;
                        }
                    }

                    var appAgreeView = bsApplicationAgreedView.Current as ApplicationAgreedView;

                    if (appAgreeView == null /*bsApplicationAgreedView.Count == 0*/ && (GeneralClass.mode == (int)GeneralClass.Status.Admin || GeneralClass.mode == (int)GeneralClass.Status.Client))
                    {
                        if (dgvApplicationAgreedView.Visible == true /*&& lNumber.Text == null*/)
                        {
                            lSelectRequest.Visible = true;
                            lSelectRequest.Text = "Заявок нет";

                            pInformation.Height = 846;
                            pDetails.Height = 757;
                        }
                        BlankPage();
                        btnCreate.Enabled = false;
                        dgvApplication.Enabled = true;
                        if (pInformation.Height > 846 && string.IsNullOrEmpty(lNumber.Text))
                        {
                            pInformation.Height = 846;
                            pDetails.Height = 757;
                        }

                    }
                    else
                    {
                        //if (dgvApplicationAgreedView.Visible == true/* && lNumber.Text == null*/)
                        //{
                        //    lSelectRequest.Visible = true;
                        //    if (pInformation.Height > 846)
                        //    {
                        //        pInformation.Height = 846;
                        //        pDetails.Height = 757;

                        //    }
                        //    lSelectRequest.Text = "Выберите заявку";

                        //    pInformation.Height = 846;
                        //    pDetails.Height = 757;
                        //}
                        if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
                        {
                            btnCreate.Enabled = true;
                        }

                    }


                    if (GeneralClass.RegisterSign != null)
                    {
                        btnDelete.Enabled = true;
                        btnCreate.Enabled = false;
                        dgvApplication.Enabled = false;

                        btnTakeApplication.Enabled = true;

                    }
                    else
                    {
                        btnDelete.Enabled = false;
                    }
                    if (bsApplicationsView.Count == 0)
                    {
                        btnCreate.Enabled = false;
                    }
                    else
                    {
                        if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
                        {
                            btnCreate.Enabled = true;
                        }
                    }


                    if (_App != null)
                    {
                        _Msg = "Заявка одобрена вами!";
                    }


                    lCarModel.Text = GeneralClass.ModelCar;
                    lRegisterSign.Text = GeneralClass.RegisterSign;

                    if (GeneralClass.bsPositionAgreed >= 0 && (GeneralClass.mode == (int)GeneralClass.Status.Client || GeneralClass.mode == (int)GeneralClass.Status.Admin) && bsApplicationAgreedView.Count != 0)
                    {
                        dgvApplicationAgreedView_CellClick(this.dgvApplicationAgreedView, new DataGridViewCellEventArgs(0, 0));

                    }

                    if (GeneralClass.bsPosition >= 0 && bsApplicationsView.Count != 0)
                    {
                        dgvApplication_CellClick(this.dgvApplication, new DataGridViewCellEventArgs(0, 0));

                    }
                    //bsApplicationsView.Position = position;

                    //dgvApplication.CurrentCell = dgvApplication[0, position];

                    //if (bsApplicationAgreedView.Count== 0)
                    //{



                    //}


                    //if (bsApplicationsView.Count == 0) {

                    //}

                    //dgvApplication.CurrentCell = dgvApplication.Rows[GeneralClass.bsPosition].Cells[0];
                    //this.dgvApplication.FirstDisplayedCell = dgvApplication.CurrentCell;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bsApplicationsView_CurrentChanged(object sender, EventArgs e)
        {

            if (bsApplicationsView.Count == 0) return;

            var appView = bsApplicationsView.Current as ApplicationView;

            using (var db = new MyDataModelDataContext())
            {
                _App = db.Applications.FirstOrDefault(x => x.Id == appView.Id);
            }

            using (var db = new MyDataModelDataContext())
            {
                _AppView = db.ApplicationView.FirstOrDefault(x => x.Id == appView.Id);
            }


        }
        private void bsApplicationAgreedView_CurrentChanged(object sender, EventArgs e)
        {
            if (bsApplicationAgreedView.Count == 0) return;

            var appAgreeView = bsApplicationAgreedView.Current as ApplicationAgreedView;

            using (var db = new MyDataModelDataContext())
            {
                _AppAgreed = db.Applications.FirstOrDefault(x => x.Id == appAgreeView.Id);
            }

        }

        private void MainUserControl_Load(object sender, EventArgs e)
        {
            //if (GeneralClass.mode == (int)GeneralClass.Status.User)
            //{
            //    /*tsmiUsers.Enabled = false;
            //    tsmiClients.Enabled = false;
            //    tsmiMasters.Enabled = false;
            //    tsmiModelAuto.Enabled = false;
            //    tsmiService.Enabled = false;
            //    */
            //    //tsmiAdmin.Enabled = false;
            //    tsmiAdmin.Visible = false;
            //}
            //tslUser.Text = GeneralClass.nickname;

            //LoadDataBase();
        }

        private void tsbFunction_Click(object sender, EventArgs e)
        {
            pFilters.Visible = !pFilters.Visible; //скрыть / показать панель
            if (pFilters.Visible == true)
            {
                tsmiAllApplications.Text = "Найденные заявки";
                if (GeneralClass.mode == (int)GeneralClass.Status.Admin)
                {
                    dgvApplicationAgreedView.Height = 778;
                    pAll.Height = 810;
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                {

                    //BlankPage();
                    if (cbArchiveApplications.Checked == true)
                    {
                        dgvApplication.Visible = false;
                        dgvApplicationAgreedView.Visible = true;
                        pSecondary.Visible = true;
                        dgvApplicationAgreedView.Dock = DockStyle.Fill;
                        pSecondary.Controls.Add(dgvApplicationAgreedView);// программное перемещение элемента в другую панель
                        dgvApplicationAgreedView.Location = new Point(0, 28);


                    }
                    else
                    {
                        pAddition.Location = new Point(7, 600);
                        dgvApplication.Visible = true;
                        dgvApplicationAgreedView.Visible = false;
                    }
                }

                timer.Stop();
                cbArchiveApplications.Enabled = false;
                if (bsApplicationsView.Count == 0)
                {

                    pTransport.Visible = false;
                    lSelectRequest.Text = "Заявок нет";

                }


            }
            else
            {
                tsmiAllApplications.Text = "Заявки на согласование";
                if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                {

                    DataPage();
                    pAddition.Location = new Point(7, 693);

                    dgvApplication.Visible = true;
                    dgvApplicationAgreedView.Visible = false;
                    dgvApplication_CellClick(this.dgvApplication, new DataGridViewCellEventArgs(0, 0));


                    if (bsApplicationAgreedView.Count == 0 && cbArchiveApplications.Checked == true)
                    {
                        lSelectRequest.Text = null;

                    }

                    if (bsApplicationsView.Count == 0 && cbArchiveApplications.Checked == false)
                    {
                        lSelectRequest.Text = null;

                    }
                }
                timer.Start();
                //cbSearchApplications.SelectedIndex = 0;

                mtbSearchApplications.Text = "Поиск...";
                mtbSearchApplications.ForeColor = Color.Silver;
                cbArchiveApplications.Enabled = true;
                LoadDataBase();

                if (bsApplicationAgreedView.Count == 0)
                {
                    lSelectRequest.Text = "Заявок нет";

                }

            }
        }

        private void dgvApplication_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsApplicationsView.Count == 0) return;


            //lStamp.Text = dgvApplication.CurrentCell.RowIndex.ToString();
            //int position = Int32.Parse(lStamp.Text);

            //if (cbSearchApplications.SelectedIndex == 0)
            //{
            using (var db = new MyDataModelDataContext())
            {

                //foreach (var appSearch in db.Applications.Where(x => x.Route == _App.Route))
                //{
                //    //MessageBox.Show("Введите шифр производственных затрат", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //appSearch.Id = 1;
                //}
                //var firstColumnValuesApplicationJoin = db.ApplicationView.GroupBy(x => x.Route).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                //Dictionary<string, int> resultApplicationJoin = firstColumnValuesApplicationJoin.ToDictionary(arg => arg.Key, arg => arg.Count);

                //int applicationJoinCount;
                //resultApplicationJoin.TryGetValue(_App.Route, out applicationJoinCount);



                //отображение окна объединения если совпадает время, маршрут и тип транспорта
                if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
                {
                    var firstColumnValuesApplicationJoin = db.ApplicationView.Where(x => x.StartDate == _App.StartDate && x.Route == _App.Route && x.TypeCar == _AppView.TypeCar && DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && x.DispatcherNIIAR_StatusDone == _AppView.DispatcherNIIAR_StatusDone && x.SelectionApplicationJoin == null).Count();

                    if (firstColumnValuesApplicationJoin >= 2)
                    {
                        timer.Stop();
                        if (_App == null) return;
                        //ApplicationJoinForm form = new ApplicationJoinForm(/*_App*/);
                        //form.ShowDialog();
                        ApplicationJoinForm form = new ApplicationJoinForm(_App, _AppView);
                        form.ShowDialog();
                        if (form.DialogResult == DialogResult.OK)
                        {
                            timer.Stop();
                            //dgvApplication.Enabled = false;
                            tsmiAllApplications.Text = "Объединенные заявки";
                            bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.StartDate == _App.StartDate && x.Route == _App.Route && x.TypeCar == _AppView.TypeCar && DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && x.DispatcherNIIAR_StatusDone == _AppView.DispatcherNIIAR_StatusDone && x.SelectionApplicationJoin == true);
                            btnCancelJoin.Visible = true;

                        }
                        if (form.DialogResult == DialogResult.Cancel)
                        {
                            GeneralClass.applicationJoin = 0;
                            //LoadDataBase();
                            timer.Start();
                        }
                        //MessageBox.Show("Найдена ещё " + (firstColumnValuesApplicationJoin - 1) + " заявка, которую можно объединить с выбранной, так как у них совпадает время и маршрут!".ToString(), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //отображение окна объединения если совпадает время, маршрут и тип транспорта

                //отображение формы исполения заявок, если найдены объединенные заявки
                if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                {
                    var firstColumnValuesApplicationJoin = db.ApplicationView.Where(x => x.ApplicationJoin == _App.ApplicationJoin && x.SelectionApplicationJoin == true).Count();
                    if (firstColumnValuesApplicationJoin >= 2)
                    {
                        foreach (var appResetSelectionJoin in db.Applications.Where(x => x.ApplicationJoin == _App.ApplicationJoin))
                        {
                            appResetSelectionJoin.SelectionApplicationJoin = null;
                            db.SubmitChanges();
                        }
                        timer.Stop();
                        if (_App == null) return;
                        ApplicationJoinForm form = new ApplicationJoinForm(_App, _AppView);
                        form.ShowDialog();
                        if (form.DialogResult == DialogResult.OK)
                        {
                            timer.Start();
                            LoadDataBase();
                            GeneralClass.applicationJoin = 0;
                        }
                        if (form.DialogResult == DialogResult.Cancel)
                        {
                            GeneralClass.applicationJoin = 0;
                            timer.Start();
                        }

                    }

                }
                //отображение формы исполения заявок, если найдены объединенные заявки

                //if (firstColumnValuesApplicationJoin == 3 || firstColumnValuesApplicationJoin == 4)
                //{
                //    MessageBox.Show("Найдены ещё " + (firstColumnValuesApplicationJoin - 1) + " заявки, которые можно объединить с выбранной, так как у них совпадает время и маршрут!".ToString(), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //if (firstColumnValuesApplicationJoin >= 5)
                //{
                //    MessageBox.Show("Найдены ещё " + (firstColumnValuesApplicationJoin - 1) + " заявок, которые можно объединить с выбранной, так как у них совпадает время и маршрут!".ToString(), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}



                //int considerationDispatcherNIIAR_StatusDone;
                //resultDispatcherNIIAR_StatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIAR_StatusDone);
                //int rejectedDispatcherNIIAR_StatusDone;
                //resultDispatcherNIIAR_StatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIAR_StatusDone);


            }
            //}
            var appView = bsApplicationsView.Current as ApplicationView;


            if (/*_App.StartDate > DateTime.Now*/DateTime.Now - _App.DateCreation < new TimeSpan(1, 0, 0, 0))
            {
                TimeSpan TimeRemaining = /*appView.StartDate - DateTime.Now*/ appView.DateCreation.AddDays(1) - DateTime.Now;
                lTimeLeft.Text = "Времени осталось: " + TimeRemaining.Days + " дн. " + TimeRemaining.Hours + " час. " + TimeRemaining.Minutes + " мин. "/* + TimeRemaining.Seconds + " сек."*/;
            }
            else
            {
                TimeSpan TimeRemaining = /*DateTime.Now - appView.StartDate*/DateTime.Now - appView.DateCreation;
                lTimeLeft.Text = "Времени прошло: " + TimeRemaining.Days + " дн. " + TimeRemaining.Hours + " час. " + TimeRemaining.Minutes + " мин. " /*+ TimeRemaining.Seconds + " сек."*/;
            }

            lClients.Text = appView.Client;
            lEmail.Text = appView.Email;
            lPost.Text = appView.Post;
            lDivision.Text = appView.Division;
            lBuilding.Text = appView.Building;
            lRoom.Text = appView.Room.ToString();
            lWorkPhone.Text = appView.WorkPhone;
            lMobilePhone.Text = appView.MobilePhone;

            lDirectorFullName.Text = appView.Director;
            lEconomistFullName.Text = appView.Economist;

            lCommentClient.Text = "Комментарий клиента " + "(" + appView.Client + ")";
            lCommentDirector.Text = "Комментарий руководителя " + "(" + appView.Director + ")";
            lCommentEconomist.Text = "Комментарий экономиста " + "(" + appView.Economist + ")";

            using (var db = new MyDataModelDataContext())
            {
                var commentDpt = db.Users.FirstOrDefault(x => x.StatusID == 6);
                var commentDspNIIAR = db.Users.FirstOrDefault(x => x.StatusID == 5);
                var commentDspATA = db.Users.FirstOrDefault(x => x.StatusID == 7);

                lCommentDepartment.Text = "Комментарий ДИД " + "(" + commentDpt.SurName + " " + commentDpt.Name + " " + commentDpt.Partonymic + ")";
                lCommentDispatcherrNIIAR.Text = "Комментарий диспетчера НИИАР " + "(" + commentDspNIIAR.SurName + " " + commentDspNIIAR.Name + " " + commentDspNIIAR.Partonymic + ")";
                lCommentDispatcherATA.Text = "Комментарий диспетчера АТА " + "(" + commentDspATA.SurName + " " + commentDspATA.Name + " " + commentDspATA.Partonymic + ")";
            }



            if (appView.CommentClient != null)
            {
                tbCommentClient.BackColor = Color.White;
                tbCommentClient.ForeColor = Color.Black;
                tbCommentClient.Text = appView.CommentClient;
            }
            else
            {
                tbCommentClient.BackColor = Color.White;
                tbCommentClient.Text = "Клиент не оставил комментария";
                tbCommentClient.ForeColor = Color.Silver;
            }

            if (appView.СommentDirector != null)
            {
                tbCommentDirector.BackColor = Color.White;
                tbCommentDirector.ForeColor = Color.Black;
                tbCommentDirector.Text = appView.СommentDirector;
            }
            else
            {
                tbCommentDirector.BackColor = Color.White;
                tbCommentDirector.Text = "Руководитель не оставил комментария";
                tbCommentDirector.ForeColor = Color.Silver;
            }

            if (appView.СommentEconomist != null)
            {
                tbCommentEconomist.BackColor = Color.White;
                tbCommentEconomist.ForeColor = Color.Black;
                tbCommentEconomist.Text = appView.СommentEconomist;
            }
            else
            {
                tbCommentEconomist.BackColor = Color.White;
                tbCommentEconomist.Text = "Экономист не оставил комментария";
                tbCommentEconomist.ForeColor = Color.Silver;
            }
            if (appView.СommentDepartment != null)
            {
                tbCommentDepartment.BackColor = Color.White;
                tbCommentDepartment.ForeColor = Color.Black;
                tbCommentDepartment.Text = appView.СommentDepartment;
            }
            else
            {
                tbCommentDepartment.BackColor = Color.White;
                tbCommentDepartment.Text = "ДИД не оставил комментария";
                tbCommentDepartment.ForeColor = Color.Silver;
            }
            if (appView.СommentDispatcherNIIAR != null)
            {
                tbCommentDispatcherNIIAR.BackColor = Color.White;
                tbCommentDispatcherNIIAR.ForeColor = Color.Black;
                tbCommentDispatcherNIIAR.Text = appView.СommentDispatcherNIIAR;
            }
            else
            {
                tbCommentDispatcherNIIAR.BackColor = Color.White;
                tbCommentDispatcherNIIAR.Text = "Диспетчер НИИАР не оставил комментария";
                tbCommentDispatcherNIIAR.ForeColor = Color.Silver;
            }

            if (appView.СommentDispatcherATA != null)
            {
                tbCommentDispatcherATA.BackColor = Color.White;
                tbCommentDispatcherATA.ForeColor = Color.Black;
                tbCommentDispatcherATA.Text = appView.СommentDispatcherATA;
            }
            else
            {
                tbCommentDispatcherATA.BackColor = Color.White;
                tbCommentDispatcherATA.Text = "Диспетчер АТА не оставил комментария";
                tbCommentDispatcherATA.ForeColor = Color.Silver;
            }




            if (_App.DirectorStatusDoneID == 1 && _App.EconomistStatusDoneID == 3
                && _App.DepartmentStatusDoneID == 3 && _App.DispatcherNIIAR_StatusDoneID == 3)
            {
                lStatus.Text = "На рассмотрении у Экономиста";
                pComments.Height = 268;
                pDetails.Height = 1048;
                pInformation.Height = 1137;
            }
            if (_App.DirectorStatusDoneID == 3 && _App.EconomistStatusDoneID == 3
                && _App.DepartmentStatusDoneID == 3 && _App.DispatcherNIIAR_StatusDoneID == 3)
            {
                lStatus.Text = "На рассмотрении у Руководителя";
                pComments.Height = 143;
                pDetails.Height = 922;
                pInformation.Height = 1005;
            }

            if (_App.DirectorStatusDoneID == 1 && _App.EconomistStatusDoneID == 1 && _App.DepartmentStatusDoneID == 3
                && _App.DispatcherNIIAR_StatusDoneID == 3 && ((_App.Days == true && _App.IntercityСity == false)
                || (_App.Days == false && _App.IntercityСity == true) ||
               (_App.Days == false && _App.IntercityСity == false)))
            {
                lStatus.Text = "На рассмотрении у ДИД";
                pComments.Height = 398;
                pDetails.Height = 1179;
                pInformation.Height = 1267;
            }



            if (_App.DirectorStatusDoneID == 1 && _App.EconomistStatusDoneID == 1 && _App.DepartmentStatusDoneID == 3 &&
                _App.DispatcherNIIAR_StatusDoneID == 3 && (_App.Days == true && _App.IntercityСity == true))
            {
                lStatus.Text = "На рассмотрении у Диспетчера НИИАР";
                pInformation.Height = 1394;
                pDetails.Height = 1303;
                pComments.Height = 523;

            }

            if (_App.DirectorStatusDoneID == 1 && _App.EconomistStatusDoneID == 1 && _App.DepartmentStatusDoneID == 1
                && _App.DispatcherNIIAR_StatusDoneID == 3 && ((_App.Days == true && _App.IntercityСity == false)
                || (_App.Days == false && _App.IntercityСity == true) ||
               (_App.Days == false && _App.IntercityСity == false) || (_App.Days == true && _App.IntercityСity == true)))
            {
                lStatus.Text = "На рассмотрении у Диспетчера НИИАР";
                pInformation.Height = 1394;
                pDetails.Height = 1303;
                pComments.Height = 523;
            }

            if (/*_App.StartDate > DateTime.Now*/DateTime.Now - _App.DateCreation < new TimeSpan(1, 0, 0, 0) && (_App.DirectorStatusDoneID == 1 && _App.EconomistStatusDoneID == 1 && _App.DepartmentStatusDoneID == 1
              && _App.DispatcherNIIAR_StatusDoneID == 1 && _App.DispatcherATA_StatusDoneID == 3 && ((_App.Days == true && _App.IntercityСity == false)
              || (_App.Days == false && _App.IntercityСity == true) ||
              (_App.Days == false && _App.IntercityСity == false) || (_App.Days == true && _App.IntercityСity == true))))
            {
                lStatus.Text = "Согласовано у Диспетчера НИИАР";
                //pInformation.Height = 1374;
                //pDetails.Height = 1282;
                //pComments.Height = 507;

                pInformation.Height = 1515;
                pDetails.Height = 1425;
                pComments.Height = 645;

            }
            if (/*_App.StartDate > DateTime.Now*/DateTime.Now - _App.DateCreation < new TimeSpan(1, 0, 0, 0) && (_App.DirectorStatusDoneID == 1 && _App.EconomistStatusDoneID == 1 && _App.DepartmentStatusDoneID == 3 &&
              _App.DispatcherNIIAR_StatusDoneID == 1 && _App.DispatcherATA_StatusDoneID == 3 && (_App.Days == true && _App.IntercityСity == true)))
            {
                lStatus.Text = "Согласовано у Диспетчера НИИАР";
                pInformation.Height = 1515;
                pDetails.Height = 1425;
                pComments.Height = 645;

            }



            if (DateTime.Now - _App.DateCreation > new TimeSpan(1, 0, 0, 0) && (_App.DirectorStatusDoneID == 1 && _App.EconomistStatusDoneID == 1 && _App.DepartmentStatusDoneID == 1
           && _App.DispatcherNIIAR_StatusDoneID == 1 && _App.DispatcherATA_StatusDoneID == 3 && ((_App.Days == true && _App.IntercityСity == false)
           || (_App.Days == false && _App.IntercityСity == true) ||
           (_App.Days == false && _App.IntercityСity == false) || (_App.Days == true && _App.IntercityСity == true))))
            {
                lStatus.Text = "Согласовано у Диспетчера НИИАР";
                //pInformation.Height = 1374;
                //pDetails.Height = 1282;
                //pComments.Height = 507;

                pInformation.Height = 1515;
                pDetails.Height = 1425;
                pComments.Height = 645;

            }
            if (DateTime.Now - _App.DateCreation > new TimeSpan(1, 0, 0, 0) && (_App.DirectorStatusDoneID == 1 && _App.EconomistStatusDoneID == 1 && _App.DepartmentStatusDoneID == 3 &&
              _App.DispatcherNIIAR_StatusDoneID == 1 && _App.DispatcherATA_StatusDoneID == 3 && (_App.Days == true && _App.IntercityСity == true)))
            {
                lStatus.Text = "Согласовано у Диспетчера НИИАР";
                pInformation.Height = 1515;
                pDetails.Height = 1425;
                pComments.Height = 645;
            }




            lDaysWorkerOrWeekend.Text = string.Format("{0}", appView.DaysWorkerOrWeekend.Value ? "Рабочий" : "Выходной");
            lStartDate.Text = String.Format("{0:d} - {0:t}", appView.StartDate);
            lEndDate.Text = String.Format("{0:d} - {0:t}", appView.EndDate);

            lIntercityСity.Text = string.Format("{0}", appView.IntercityСity.Value ? "Город" : "Межгород");
            lTypeCar.Text = appView.TypeCar;
            lPassenger.Text = appView.QuantityPassengers.ToString();
            lCargo.Text = appView.CargoWeight.ToString();
            lPlaceSubmission.Text = appView.PlaceSubmission;
            lRoute.Text = appView.Route;
            lNumber.Text = appView.Id.ToString() + "    [ от " + String.Format("{0:d} - {0:t}", appView.DateCreation) + " ]";
            lPurposeUsingTransport.Text = appView.PurposeUsingTransport;


            //lNumber.Text = dgvApplication.CurrentRow.Cells[0].Value.ToString();
            if (lNumber.Text != null)
            {
                DataPage();
                lSelectRequest.Visible = false;
                btnDeclineApplication.Enabled = true;
                if (GeneralClass.RegisterSign != null)
                {
                    btnTakeApplication.Enabled = true;
                }
                if (GeneralClass.mode != (int)GeneralClass.Status.DispatcherNIIAR)
                {
                    btnTakeApplication.Enabled = true;
                }
            }


            if (GeneralClass.mode == (int)GeneralClass.Status.Client || GeneralClass.mode == (int)GeneralClass.Status.Admin || GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
            {
                GeneralClass.bsPosition = bsApplicationsView.Position;
                GeneralClass.bsPositionAgreed = -1;
                if (GeneralClass.mode != (int)GeneralClass.Status.DispatcherATA)
                {
                    dgvApplicationAgreedView.Visible = true;
                }

            }
            else
            {
                dgvApplicationAgreedView.Visible = false;
                lComment.Visible = true;
                tbComment.Visible = true;
                btnTakeApplication.Visible = true;
                btnDeclineApplication.Visible = true;

            }
            if (_App.DispatcherNIIAR_StatusDoneID == 1 && GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
            {
                using (var db = new MyDataModelDataContext())
                {
                    var crs = db.Cars.FirstOrDefault(x => x.Id == _App.CarID);
                    var md = db.ModelCars.FirstOrDefault(x => x.Id == crs.ModelCarID);
                    pTransport.Visible = true;
                    lTransport.Text = md.Name + " - " + crs.RegisterSign;
                }
            }
            else
            {
                pTransport.Visible = false;
            }

            if (appView != null)
            {
                lSelectRequest.Text = null;
            }

            //bsApplicationsView.Position = GeneralClass.bsPosition;
            dgvApplicationAgreedView.ClearSelection();

            //lbTypeCar.ClearSelected();

        }


        //public override string ToString()
        //{
        //    var appAgreedView = bsApplicationAgreedView.Current as ApplicationAgreedView;
        //    return string.Format("sss {0}", appAgreedView.DaysWorkerOrWeekend.Value ? "Рабочий" : "Выходной");
        //}


        private void dgvApplicationAgreedView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsApplicationAgreedView.Count == 0) return;



            var appAgreedView = bsApplicationAgreedView.Current as ApplicationAgreedView;

            if (/*_AppAgreed.StartDate > DateTime.Now*/DateTime.Now - _AppAgreed.DateCreation < new TimeSpan(1, 0, 0, 0))
            {
                TimeSpan TimeRemaining = /*appAgreedView.StartDate - DateTime.Now*/ appAgreedView.DateCreation.AddDays(1) - DateTime.Now;
                lTimeLeft.Text = "Времени осталось: " + TimeRemaining.Days + " дн. " + TimeRemaining.Hours + " час. " + TimeRemaining.Minutes + " мин. " /*+ TimeRemaining.Seconds + " сек."*/;

            }
            else
            {
                TimeSpan TimeRemaining = /*DateTime.Now - appAgreedView.StartDate*/DateTime.Now - appAgreedView.DateCreation;
                lTimeLeft.Text = "Времени прошло: " + TimeRemaining.Days + " дн. " + TimeRemaining.Hours + " час. " + TimeRemaining.Minutes + " мин. "/* + TimeRemaining.Seconds + " сек."*/;
            }



            lClients.Text = appAgreedView.Client;
            lEmail.Text = appAgreedView.Email;
            lPost.Text = appAgreedView.Post;
            lDivision.Text = appAgreedView.Division;
            lBuilding.Text = appAgreedView.Building;
            lRoom.Text = appAgreedView.Room.ToString();
            lWorkPhone.Text = appAgreedView.WorkPhone;
            lMobilePhone.Text = appAgreedView.MobilePhone;

            lDirectorFullName.Text = appAgreedView.Director;
            lEconomistFullName.Text = appAgreedView.Economist;



            lCommentClient.Text = "Комментарий клиента " + "(" + appAgreedView.Client + ")";
            lCommentDirector.Text = "Комментарий руководителя " + "(" + appAgreedView.Director + ")";
            lCommentEconomist.Text = "Комментарий экономиста " + "(" + appAgreedView.Economist + ")";

            using (var db = new MyDataModelDataContext())
            {
                var commentDpt = db.Users.FirstOrDefault(x => x.StatusID == 6);
                var commentDspNIIAR = db.Users.FirstOrDefault(x => x.StatusID == 5);
                var commentDspATA = db.Users.FirstOrDefault(x => x.StatusID == 7);

                lCommentDepartment.Text = "Комментарий ДИД " + "(" + commentDpt.SurName + " " + commentDpt.Name + " " + commentDpt.Partonymic + ")";
                lCommentDispatcherrNIIAR.Text = "Комментарий диспетчера НИИАР " + "(" + commentDspNIIAR.SurName + " " + commentDspNIIAR.Name + " " + commentDspNIIAR.Partonymic + ")";
                lCommentDispatcherATA.Text = "Комментарий диспетчера АТА " + "(" + commentDspATA.SurName + " " + commentDspATA.Name + " " + commentDspATA.Partonymic + ")";
            }


            if (appAgreedView.CommentClient != null)
            {
                tbCommentClient.BackColor = Color.White;
                tbCommentClient.ForeColor = Color.Black;
                tbCommentClient.Text = appAgreedView.CommentClient;
            }
            else
            {
                tbCommentClient.BackColor = Color.White;
                tbCommentClient.Text = "Клиент не оставил комментария";
                tbCommentClient.ForeColor = Color.Silver;
            }

            if (appAgreedView.СommentDirector != null)
            {
                tbCommentDirector.BackColor = Color.White;
                tbCommentDirector.ForeColor = Color.Black;
                tbCommentDirector.Text = appAgreedView.СommentDirector;
            }
            else
            {
                tbCommentDirector.BackColor = Color.White;
                tbCommentDirector.Text = "Руководитель не оставил комментария";
                tbCommentDirector.ForeColor = Color.Silver;
            }
            if (appAgreedView.СommentEconomist != null)
            {
                tbCommentEconomist.BackColor = Color.White;
                tbCommentEconomist.ForeColor = Color.Black;
                tbCommentEconomist.Text = appAgreedView.СommentEconomist;
            }
            else
            {
                tbCommentEconomist.BackColor = Color.White;
                tbCommentEconomist.Text = "Экономист не оставил комментария";
                tbCommentEconomist.ForeColor = Color.Silver;
            }
            if (appAgreedView.СommentDepartment != null)
            {
                tbCommentDepartment.BackColor = Color.White;
                tbCommentDepartment.ForeColor = Color.Black;
                tbCommentDepartment.Text = appAgreedView.СommentDepartment;
            }
            else
            {
                tbCommentDepartment.BackColor = Color.White;
                tbCommentDepartment.Text = "ДИД не оставил комментария";
                tbCommentDepartment.ForeColor = Color.Silver;
            }
            if (appAgreedView.СommentDispatcherNIIAR != null)
            {
                tbCommentDispatcherNIIAR.BackColor = Color.White;
                tbCommentDispatcherNIIAR.ForeColor = Color.Black;
                tbCommentDispatcherNIIAR.Text = appAgreedView.СommentDispatcherNIIAR;
            }
            else
            {
                tbCommentDispatcherNIIAR.BackColor = Color.White;
                tbCommentDispatcherNIIAR.Text = "Диспетчер НИИАР не оставил комментария";
                tbCommentDispatcherNIIAR.ForeColor = Color.Silver;
            }

            if (appAgreedView.СommentDispatcherATA != null)
            {
                tbCommentDispatcherATA.BackColor = Color.White;
                tbCommentDispatcherATA.ForeColor = Color.Black;
                tbCommentDispatcherATA.Text = appAgreedView.СommentDispatcherATA;
            }
            else
            {
                tbCommentDispatcherATA.BackColor = Color.White;
                tbCommentDispatcherATA.Text = "Диспетчер АТА не оставил комментария";
                tbCommentDispatcherATA.ForeColor = Color.Silver;
            }


            //pInformation.Height = 1655;
            //pDetails.Height = 1566;
            //pComments.Height = 787;




            lDaysWorkerOrWeekend.Text = string.Format("{0}", appAgreedView.DaysWorkerOrWeekend.Value ? "Рабочий" : "Выходной");
            lStartDate.Text = String.Format("{0:d} - {0:t}", appAgreedView.StartDate);
            lEndDate.Text = String.Format("{0:d} - {0:t}", appAgreedView.EndDate);

            lIntercityСity.Text = string.Format("{0}", appAgreedView.IntercityСity.Value ? "Город" : "Межгород");
            lTypeCar.Text = appAgreedView.TypeCar;
            lPassenger.Text = appAgreedView.QuantityPassengers.ToString();
            lCargo.Text = appAgreedView.CargoWeight.ToString();
            lPlaceSubmission.Text = appAgreedView.PlaceSubmission;
            lRoute.Text = appAgreedView.Route;
            lNumber.Text = appAgreedView.Id.ToString() + "    [ от " + String.Format("{0:d} - {0:t}", appAgreedView.DateCreation) + " ]";
            lPurposeUsingTransport.Text = appAgreedView.PurposeUsingTransport;

            lTransport.Text = appAgreedView.Model + " - " + appAgreedView.RegisterSign;


            if (/*_AppAgreed.StartDate > DateTime.Now*/DateTime.Now - _AppAgreed.DateCreation < new TimeSpan(1, 0, 0, 0) && (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 3
               && _AppAgreed.DepartmentStatusDoneID == 3 && _AppAgreed.DispatcherNIIAR_StatusDoneID == 3))
            {
                lStatus.Text = "На рассмотрении у Экономиста";
                pComments.Height = 268;
                pDetails.Height = 1048;
                pInformation.Height = 1137;
            }

            if (/*_AppAgreed.StartDate > DateTime.Now*/ DateTime.Now - _AppAgreed.DateCreation < new TimeSpan(1, 0, 0, 0) && (_AppAgreed.DirectorStatusDoneID == 3 && _AppAgreed.EconomistStatusDoneID == 3
                && _AppAgreed.DepartmentStatusDoneID == 3 && _AppAgreed.DispatcherNIIAR_StatusDoneID == 3))
            {
                lStatus.Text = "На рассмотрении у Руководителя";
                pComments.Height = 143;
                pDetails.Height = 922;
                pInformation.Height = 1005;

            }

            if (/*_AppAgreed.StartDate > DateTime.Now*/DateTime.Now - _AppAgreed.DateCreation < new TimeSpan(1, 0, 0, 0) && (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 && _AppAgreed.DepartmentStatusDoneID == 3
                && _AppAgreed.DispatcherNIIAR_StatusDoneID == 3 && ((_AppAgreed.Days == true && _AppAgreed.IntercityСity == false)
                || (_AppAgreed.Days == false && _AppAgreed.IntercityСity == true) ||
               (_AppAgreed.Days == false && _AppAgreed.IntercityСity == false))))
            {
                lStatus.Text = "На рассмотрении у ДИД";
                pComments.Height = 398;
                pDetails.Height = 1179;
                pInformation.Height = 1267;
            }



            if (/*_AppAgreed.StartDate > DateTime.Now */DateTime.Now - _AppAgreed.DateCreation < new TimeSpan(1, 0, 0, 0) && (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 && _AppAgreed.DepartmentStatusDoneID == 3 &&
                _AppAgreed.DispatcherNIIAR_StatusDoneID == 3 && (_AppAgreed.Days == true && _AppAgreed.IntercityСity == true)))
            {
                lStatus.Text = "На рассмотрении у Диспетчера НИИАР";
                pInformation.Height = 1394;
                pDetails.Height = 1303;
                pComments.Height = 523;

            }

            if (/*_AppAgreed.StartDate > DateTime.Now */ DateTime.Now - _AppAgreed.DateCreation < new TimeSpan(1, 0, 0, 0) && (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 && _AppAgreed.DepartmentStatusDoneID == 1
                && _AppAgreed.DispatcherNIIAR_StatusDoneID == 3 && ((_AppAgreed.Days == true && _AppAgreed.IntercityСity == false)
                || (_AppAgreed.Days == false && _AppAgreed.IntercityСity == true) ||
               (_AppAgreed.Days == false && _AppAgreed.IntercityСity == false) || (_AppAgreed.Days == true && _AppAgreed.IntercityСity == true))))
            {
                lStatus.Text = "На рассмотрении у Диспетчера НИИАР";
                pInformation.Height = 1394;
                pDetails.Height = 1303;
                pComments.Height = 523;

            }

            if (/*_AppAgreed.StartDate > DateTime.Now*/DateTime.Now - _AppAgreed.DateCreation < new TimeSpan(1, 0, 0, 0) && (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 && _AppAgreed.DepartmentStatusDoneID == 1
               && _AppAgreed.DispatcherNIIAR_StatusDoneID == 1 && _AppAgreed.DispatcherATA_StatusDoneID == 3 && ((_AppAgreed.Days == true && _AppAgreed.IntercityСity == false)
               || (_AppAgreed.Days == false && _AppAgreed.IntercityСity == true) ||
               (_AppAgreed.Days == false && _AppAgreed.IntercityСity == false) || (_AppAgreed.Days == true && _AppAgreed.IntercityСity == true))))
            {
                lStatus.Text = "Согласовано у Диспетчера НИИАР";
                pInformation.Height = 1515;
                pDetails.Height = 1425;
                pComments.Height = 645;

            }
            if (/*_AppAgreed.StartDate > DateTime.Now*/DateTime.Now - _AppAgreed.DateCreation < new TimeSpan(1, 0, 0, 0) && (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 && _AppAgreed.DepartmentStatusDoneID == 3 &&
              _AppAgreed.DispatcherNIIAR_StatusDoneID == 1 && _AppAgreed.DispatcherATA_StatusDoneID == 3 && (_AppAgreed.Days == true && _AppAgreed.IntercityСity == true)))
            {
                lStatus.Text = "Согласовано у Диспетчера НИИАР";
                pInformation.Height = 1515;
                pDetails.Height = 1425;
                pComments.Height = 645;
            }



            if (DateTime.Now - _AppAgreed.DateCreation > new TimeSpan(1, 0, 0, 0) && (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 && _AppAgreed.DepartmentStatusDoneID == 1
          && _AppAgreed.DispatcherNIIAR_StatusDoneID == 1 && _AppAgreed.DispatcherATA_StatusDoneID == 3 && ((_AppAgreed.Days == true && _AppAgreed.IntercityСity == false)
          || (_AppAgreed.Days == false && _AppAgreed.IntercityСity == true) ||
          (_AppAgreed.Days == false && _AppAgreed.IntercityСity == false) || (_AppAgreed.Days == true && _AppAgreed.IntercityСity == true))))
            {
                lStatus.Text = "Согласовано у Диспетчера НИИАР";


                pInformation.Height = 1515;
                pDetails.Height = 1425;
                pComments.Height = 645;

            }
            if (DateTime.Now - _AppAgreed.DateCreation > new TimeSpan(1, 0, 0, 0) && (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 && _AppAgreed.DepartmentStatusDoneID == 3 &&
              _AppAgreed.DispatcherNIIAR_StatusDoneID == 1 && _AppAgreed.DispatcherATA_StatusDoneID == 3 && (_AppAgreed.Days == true && _AppAgreed.IntercityСity == true)))
            {
                lStatus.Text = "Согласовано у Диспетчера НИИАР";
                pInformation.Height = 1515;
                pDetails.Height = 1425;
                pComments.Height = 645;

            }



            if (_AppAgreed.DirectorStatusDoneID == 2 && _AppAgreed.EconomistStatusDoneID == 3
           && _AppAgreed.DepartmentStatusDoneID == 3 && _AppAgreed.DispatcherNIIAR_StatusDoneID == 3)
            {
                lStatus.Text = "Заявка отклонена Руководителем";
                pComments.Height = 268;
                pDetails.Height = 1048;
                pInformation.Height = 1137;

            }

            if (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 2
             && _AppAgreed.DepartmentStatusDoneID == 3 && _AppAgreed.DispatcherNIIAR_StatusDoneID == 3 && _AppAgreed.DispatcherATA_StatusDoneID == 3)
            {
                lStatus.Text = "Заявка отклонена Экономистом";
                pComments.Height = 398;
                pDetails.Height = 1179;
                pInformation.Height = 1267;
            }


            if (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 && _AppAgreed.DepartmentStatusDoneID == 2
                && _AppAgreed.DispatcherNIIAR_StatusDoneID == 3 && ((_AppAgreed.Days == true && _AppAgreed.IntercityСity == false)
                || (_AppAgreed.Days == false && _AppAgreed.IntercityСity == true) ||
               (_AppAgreed.Days == false && _AppAgreed.IntercityСity == false)))
            {
                lStatus.Text = "Заявка отклонена ДИД";
                pInformation.Height = 1394;
                pDetails.Height = 1303;
                pComments.Height = 523;

            }

            if (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 && _AppAgreed.DepartmentStatusDoneID == 3 &&
                _AppAgreed.DispatcherNIIAR_StatusDoneID == 2 && (_AppAgreed.Days == true && _AppAgreed.IntercityСity == true))
            {
                lStatus.Text = "Заявка отклонена Диспетчером НИИАР";
                pInformation.Height = 1515;
                pDetails.Height = 1425;
                pComments.Height = 645;
            }

            if (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 && _AppAgreed.DepartmentStatusDoneID == 1
                && _AppAgreed.DispatcherNIIAR_StatusDoneID == 2 && ((_AppAgreed.Days == true && _AppAgreed.IntercityСity == false)
                || (_AppAgreed.Days == false && _AppAgreed.IntercityСity == true) ||
               (_AppAgreed.Days == false && _AppAgreed.IntercityСity == false) || (_AppAgreed.Days == true && _AppAgreed.IntercityСity == true)))
            {
                lStatus.Text = "Заявка отклонена Диспетчером НИИАР";
                pInformation.Height = 1515;
                pDetails.Height = 1425;
                pComments.Height = 645;

            }


            //lTimeLeft.Text = null;
            if (/*_AppAgreed.StartDate < DateTime.Now*/DateTime.Now - _AppAgreed.DateCreation > new TimeSpan(1, 0, 0, 0) && (((_AppAgreed.DirectorStatusDoneID == 3 ||
                _AppAgreed.DirectorStatusDoneID == 1) && (_AppAgreed.EconomistStatusDoneID == 1 ||
                _AppAgreed.EconomistStatusDoneID == 3) &&
                (_AppAgreed.DepartmentStatusDoneID == 1
                || _AppAgreed.DepartmentStatusDoneID == 3) && (/*_AppAgreed.DispatcherNIIAR_StatusDoneID == 1 ||*/ _AppAgreed.DispatcherNIIAR_StatusDoneID == 3) && (_AppAgreed.DispatcherATA_StatusDoneID == 5))))
            {
                lStatus.Text = "Не исполнено. Заявку не успели рассмотреть";


                if (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 3 &&
                    _AppAgreed.DepartmentStatusDoneID == 3 && _AppAgreed.DispatcherNIIAR_StatusDoneID == 3
                    /*&& _AppAgreed.DispatcherATA_StatusDoneID == 3*/)
                {
                    pComments.Height = 268;
                    pDetails.Height = 1048;
                    pInformation.Height = 1137;

                }
                if (_AppAgreed.DirectorStatusDoneID == 3 && _AppAgreed.EconomistStatusDoneID == 3 &&
                    _AppAgreed.DepartmentStatusDoneID == 3 && _AppAgreed.DispatcherNIIAR_StatusDoneID == 3
                    /*&& _AppAgreed.DispatcherATA_StatusDoneID == 3*/)
                {
                    pComments.Height = 143;
                    pDetails.Height = 922;
                    pInformation.Height = 1005;
                }
                if (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 &&
                    _AppAgreed.DepartmentStatusDoneID == 3 && _AppAgreed.DispatcherNIIAR_StatusDoneID == 3
                   /* && _AppAgreed.DispatcherATA_StatusDoneID == 3*/)
                {
                    pComments.Height = 398;
                    pDetails.Height = 1179;
                    pInformation.Height = 1267;
                }
                if (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 &&
                    _AppAgreed.DepartmentStatusDoneID == 1 && _AppAgreed.DispatcherNIIAR_StatusDoneID == 3
                  /*  && _AppAgreed.DispatcherATA_StatusDoneID == 3*/)
                {
                    pInformation.Height = 1394;
                    pDetails.Height = 1303;
                    pComments.Height = 523;

                }
                if (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 &&
                    _AppAgreed.DepartmentStatusDoneID == 1 && _AppAgreed.DispatcherNIIAR_StatusDoneID == 1
                    /*&& _AppAgreed.DispatcherATA_StatusDoneID == 3*/)
                {
                    pInformation.Height = 1515;
                    pDetails.Height = 1425;
                    pComments.Height = 645;
                }
                if (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 &&
                    _AppAgreed.DepartmentStatusDoneID == 3 && _AppAgreed.DispatcherNIIAR_StatusDoneID == 1
                   /* && _AppAgreed.DispatcherATA_StatusDoneID == 3*/)
                {
                    pInformation.Height = 1515;
                    pDetails.Height = 1425;
                    pComments.Height = 645;
                    //pComments.Height = 787;
                    //pDetails.Height = 1566;
                    //pInformation.Height = 1655;
                }


            }


            if (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 && _AppAgreed.DepartmentStatusDoneID == 1
               && _AppAgreed.DispatcherNIIAR_StatusDoneID == 1 && (_AppAgreed.DispatcherATA_StatusDoneID == 4 || _AppAgreed.DispatcherATA_StatusDoneID != 3) && ((_AppAgreed.Days == true && _AppAgreed.IntercityСity == false)
               || (_AppAgreed.Days == false && _AppAgreed.IntercityСity == true) ||
               (_AppAgreed.Days == false && _AppAgreed.IntercityСity == false) || (_AppAgreed.Days == true && _AppAgreed.IntercityСity == true)))
            {
                pComments.Height = 787;
                pDetails.Height = 1566;
                pInformation.Height = 1655;
                if (_AppAgreed.DispatcherATA_StatusDoneID == 4)
                {
                    lStatus.Text = "Исполнено";
                }

            }
            if (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 && _AppAgreed.DepartmentStatusDoneID == 3 &&
              _AppAgreed.DispatcherNIIAR_StatusDoneID == 1 && (_AppAgreed.DispatcherATA_StatusDoneID == 4 || _AppAgreed.DispatcherATA_StatusDoneID != 3) && (_AppAgreed.Days == true && _AppAgreed.IntercityСity == true))
            {
                pComments.Height = 787;
                pDetails.Height = 1566;
                pInformation.Height = 1655;
                if (_AppAgreed.DispatcherATA_StatusDoneID == 4)
                {
                    lStatus.Text = "Исполнено";
                }
            }

            if (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 && _AppAgreed.DepartmentStatusDoneID == 1
             && _AppAgreed.DispatcherNIIAR_StatusDoneID == 1 && (_AppAgreed.DispatcherATA_StatusDoneID == 5) && ((_AppAgreed.Days == true && _AppAgreed.IntercityСity == false)
             || (_AppAgreed.Days == false && _AppAgreed.IntercityСity == true) ||
             (_AppAgreed.Days == false && _AppAgreed.IntercityСity == false) || (_AppAgreed.Days == true && _AppAgreed.IntercityСity == true)))
            {
                pComments.Height = 787;
                pDetails.Height = 1566;
                pInformation.Height = 1655;
                if (_AppAgreed.DispatcherATA_StatusDoneID == 5)
                {
                    lStatus.Text = "Не исполнено";
                }
            }
            if (_AppAgreed.DirectorStatusDoneID == 1 && _AppAgreed.EconomistStatusDoneID == 1 && _AppAgreed.DepartmentStatusDoneID == 3 &&
              _AppAgreed.DispatcherNIIAR_StatusDoneID == 1 && _AppAgreed.DispatcherATA_StatusDoneID == 5 && (_AppAgreed.Days == true && _AppAgreed.IntercityСity == true))
            {
                pComments.Height = 787;
                pDetails.Height = 1566;
                pInformation.Height = 1655;
                if (_AppAgreed.DispatcherATA_StatusDoneID == 5)
                {
                    lStatus.Text = "Не исполнено";
                }

            }



            //lNumber.Text = dgvApplication.CurrentRow.Cells[0].Value.ToString();
            if (lNumber.Text != null)
            {
                if (_AppAgreed.DispatcherNIIAR_StatusDoneID == 1 && _AppAgreed.CarID != 1)
                {
                    pTransport.Visible = true;
                }
                else
                {
                    pTransport.Visible = false;
                }

                lSelectRequest.Visible = false;


                if (GeneralClass.RegisterSign != null)
                {
                    btnDeclineApplication.Enabled = true;
                    btnTakeApplication.Enabled = true;
                }
                DataPage();
            }


            if (GeneralClass.mode == (int)GeneralClass.Status.Client || GeneralClass.mode == (int)GeneralClass.Status.Admin || GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
            {
                GeneralClass.bsPositionAgreed = bsApplicationAgreedView.Position;
                GeneralClass.bsPosition = -1;

                dgvApplicationAgreedView.Visible = true;

            }
            else
            {
                dgvApplicationAgreedView.Visible = false;
                lComment.Visible = true;
                tbComment.Visible = true;
                btnTakeApplication.Visible = true;
                btnDeclineApplication.Visible = true;

            }
            dgvApplication.ClearSelection();
        }

        //таймер обновления 
        private void timer_Tick(object sender, EventArgs e)
        {
            LoadDataBase();
            //если время на согласование вышло, автоматически "не исполнено"
            using (var db = new MyDataModelDataContext())
            {
                var ap = db.Applications.Where(x => (x.DispatcherATA_StatusDoneID == 3)
                && (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0))
                && (x.DirectorStatusDoneID == 3 || x.EconomistStatusDoneID == 3 || x.DepartmentStatusDoneID == 3 || x.DispatcherNIIAR_StatusDoneID == 3)).FirstOrDefault();

                if (ap != null)
                {

                    foreach (var app in db.Applications.Where(x => (x.DispatcherATA_StatusDoneID != 4 && x.DispatcherATA_StatusDoneID != 5)
                    && (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0))
                    && (x.DirectorStatusDoneID == 3 || x.EconomistStatusDoneID == 3 || x.DepartmentStatusDoneID == 3 || x.DispatcherNIIAR_StatusDoneID == 3)))
                    {
                        app.DispatcherATA_StatusDoneID = 5;
                        var crs = db.Cars.Where(x => x.Id == app.CarID).FirstOrDefault();
                        crs.StatusCarID = 1;
                        db.SubmitChanges();

                        var usr = db.Users.FirstOrDefault(x => x.StatusID == 7);
                        var us = db.Users.FirstOrDefault(x => x.Id == app.UserID);
                        //Почта
                        SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 2525);
                        Smtp.Credentials = new NetworkCredential(usr.Email, "DC7zZ5CvANF9GZhzK65V");
                        MailMessage Message = new MailMessage();
                        Smtp.EnableSsl = true;
                        Message.From = new MailAddress(usr.Email);
                        Message.To.Add(new MailAddress(us.Email));
                        Message.Subject = "Статус заявки № " + app.Id;
                        Message.IsBodyHtml = true;//html отображение
                        Message.Body = "Ваша заявка не исполнена, потому что время на её согласование вышло!" + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";

                        try
                        {
                            Smtp.Send(Message);

                        }
                        catch (Exception/* ex*/)
                        {
                            return;
                        }

                    }
                }

            }
            //если время на согласование вышло, автоматически "не исполнено"

            //lNumber.Visible = false;
            //lStatus.Visible = false;
            //lClients.Visible = false;
            //lEmail.Visible = false;
            //lDivision.Visible = false;
            //lPost.Visible = false;
            //lDivision.Visible = false;
            //lDepartment.Visible = false;
            //lLocation.Visible = false;
            //lWorkPhone.Visible = false;
            //lMobilePhone.Visible = false;
            //lStartDate.Visible = false;
            //lEndDate.Visible = false;
            //lTypeCar.Visible = false;
            //lPassenger.Visible = false;
            //lCargo.Visible = false;
            //lPlaceSubmission.Visible = false;
            //lRoute.Visible = false;

            //if (lNumber.Visible == false)
            //{
            //    lSelectRequest.Visible = true;
            //}


            //btnDeclineApplication.Enabled = false;
            //btnTakeApplication.Enabled = false;

        }
        //таймер обновления

        //таймер для отправки отчётов на почту
        private void tReport_Tick(object sender, EventArgs e)
        {

            int hour = 12;
            int minute = 00;

            if ((DateTime.Now.DayOfWeek == DayOfWeek.Friday) &&
                (hour == DateTime.Now.Hour) && (minute == DateTime.Now.Minute))
            {
                using (var db = new MyDataModelDataContext())
                {
                    var usr = db.Users.FirstOrDefault(x => x.StatusID == 7);
                    var us = db.Users.FirstOrDefault(x => x.StatusID == 5);
                    //Почта
                    SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 2525);
                    Smtp.Credentials = new NetworkCredential(us.Email, "DC7zZ5CvANF9GZhzK65V");
                    MailMessage Message = new MailMessage();
                    Smtp.EnableSsl = true;
                    Message.From = new MailAddress(us.Email);
                    Message.To.Add(new MailAddress(usr.Email));
                    Message.Subject = "Отчёт по заявкам за период: " + String.Format("{0:d}", DateTime.Now.AddDays(-7)) + " - " + String.Format("{0:d}", DateTime.Now);
                    Message.IsBodyHtml = true;//html отображение

                    //посчитать количество определенных одинаковых данных
                    var firstColumnValuesDirector = db.ApplicationAgreedView.Where(x => (x.DateCreation > DateTime.Now.AddDays(-7) && x.DirectorStatusDone != "На рассмотрении") || x.DateCreation.AddDays(1) > DateTime.Now).GroupBy(x => x.DirectorStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                    Dictionary<string, int> resultDirector = firstColumnValuesDirector.ToDictionary(arg => arg.Key, arg => arg.Count);

                    int agreedDirector;
                    resultDirector.TryGetValue("Согласовано", out agreedDirector);
                    int considerationDirector;
                    resultDirector.TryGetValue("На рассмотрении", out considerationDirector);
                    int rejectedDirector;
                    resultDirector.TryGetValue("Отклонена", out rejectedDirector);


                    var firstColumnValuesEconomist = db.ApplicationAgreedView.Where(x => (x.DateCreation > DateTime.Now.AddDays(-7) && x.EconomistStatusDone != "На рассмотрении") || x.DateCreation.AddDays(1) > DateTime.Now).GroupBy(x => x.EconomistStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                    Dictionary<string, int> resultEconomist = firstColumnValuesEconomist.ToDictionary(arg => arg.Key, arg => arg.Count);

                    int agreedEconomist;
                    resultEconomist.TryGetValue("Согласовано", out agreedEconomist);
                    int considerationEconomist;
                    resultEconomist.TryGetValue("На рассмотрении", out considerationEconomist);
                    int rejectedEconomist;
                    resultEconomist.TryGetValue("Отклонена", out rejectedEconomist);

                    var firstColumnValuesDepartment = db.ApplicationAgreedView.Where(x => (x.DateCreation > DateTime.Now.AddDays(-7) && x.DepartmentStatusDone != "На рассмотрении" && (x.IntercityСity != true || x.DaysWorkerOrWeekend != true)) || (x.DateCreation.AddDays(1) > DateTime.Now && (x.IntercityСity != true || x.DaysWorkerOrWeekend != true))).GroupBy(x => x.DepartmentStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                    Dictionary<string, int> resultDepartment = firstColumnValuesDepartment.ToDictionary(arg => arg.Key, arg => arg.Count);

                    int agreedDepartment;
                    resultDepartment.TryGetValue("Согласовано", out agreedDepartment);
                    int considerationDepartment;
                    resultDepartment.TryGetValue("На рассмотрении", out considerationDepartment);
                    int rejectedDepartment;
                    resultDepartment.TryGetValue("Отклонена", out rejectedDepartment);

                    var firstColumnValuesDispatcherNIIAR_StatusDone = db.ApplicationAgreedView.Where(x => (x.DateCreation > DateTime.Now.AddDays(-7) && x.DispatcherNIIAR_StatusDone != "На рассмотрении") || x.DateCreation.AddDays(1) > DateTime.Now).GroupBy(x => x.DispatcherNIIAR_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                    Dictionary<string, int> resultDispatcherNIIAR_StatusDone = firstColumnValuesDispatcherNIIAR_StatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                    int agreedDispatcherNIIAR_StatusDone;
                    resultDispatcherNIIAR_StatusDone.TryGetValue("Согласовано", out agreedDispatcherNIIAR_StatusDone);
                    int considerationDispatcherNIIAR_StatusDone;
                    resultDispatcherNIIAR_StatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIAR_StatusDone);
                    int rejectedDispatcherNIIAR_StatusDone;
                    resultDispatcherNIIAR_StatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIAR_StatusDone);

                    var firstColumnValuesDispatcherATA_StatusDone = db.ApplicationAgreedView.Where(x => (x.DateCreation > DateTime.Now.AddDays(-7) && x.DispatcherNIIAR_StatusDone != "На рассмотрении") || (x.DateCreation.AddDays(1) > DateTime.Now)).GroupBy(x => x.DispatcherATA_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                    Dictionary<string, int> resultDispatcherATA_StatusDone = firstColumnValuesDispatcherATA_StatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                    int ExecutedDispatcherATA_StatusDone;
                    resultDispatcherATA_StatusDone.TryGetValue("Исполнено", out ExecutedDispatcherATA_StatusDone);
                    int NotExecutedDispatcherATA_StatusDone;
                    resultDispatcherATA_StatusDone.TryGetValue("Не исполнено", out NotExecutedDispatcherATA_StatusDone);
                    //посчитать количество определенных одинаковых данных
                    var firstColumnValuesSumm = db.ApplicationAgreedView.Where(x => x.DateCreation > DateTime.Now.AddDays(-7)).Count();
                    var firstColumnValuesTimeUpSumm = db.ApplicationAgreedView.Where(x => x.DateCreation > DateTime.Now.AddDays(-7) && (x.DateCreation.AddDays(1) < DateTime.Now && (x.DirectorStatusDone == "На рассмотрении" || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).Count();

                    Message.Body = "Количество поступивших заявок: " + firstColumnValuesSumm + "<br/><br/>" + "Из них: " + "<table class='table'><thead><tr><th class='text-center'>Текущий статус</th><th class='text-right_'>Количество</th></tr><tr><th class='text-left'>На рассмотрении у руководителей</th><th class='text-right'>" + considerationDirector + "</th></tr><tr><th class='text-left'>На рассмотрении у экономистов</th> <th class='text-right'>" + considerationEconomist + "</th></tr><tr><th class='text-left'>На рассмотрении у ДИД</th><th class='text-right'>" + considerationDepartment + "</th></tr><tr> <th class='text-left'>На рассмотрении у диспетчера НИИАР</th><th class='text-right'>" + considerationDispatcherNIIAR_StatusDone + "</th></tr><tr><th class='text-left'>Отклонены руководителями</th><th class='text-right'>" + rejectedDirector + "</th></tr><tr><th class='text-left'>Отклонены экономистами</th><th class='text-right'>" + rejectedEconomist + "</th></tr><tr><th class='text-left'>Отклонены ДИД</th><th class='text-right'>" + rejectedDepartment + "</th></tr><tr><th class='text-left'>Отклонены диспетчером НИИАР</th><th class='text-right'>" + rejectedDispatcherNIIAR_StatusDone + "</th></tr><tr><th class='text-left'>Согласовано руководителями</th><th class='text-right'>" + agreedDirector + "</th></tr><tr><th class='text-left'>Согласовано экономистами</th><th class='text-right'>" + agreedEconomist + "</th></tr><tr><th class='text-left'>Согласовано ДИД</th><th class='text-right'>" + agreedDepartment + "</th></tr><tr><th class='text-left'>Согласовано у диспетчера НИИАР</th><th class='text-right'>" + agreedDispatcherNIIAR_StatusDone + "</th></tr><tr><th class='text-left'>Исполнено</th><th class='text-right'>" + ExecutedDispatcherATA_StatusDone + "</th></tr><tr><th class='text-left'>Не исполнено</th><th class='text-right'>" + NotExecutedDispatcherATA_StatusDone + "</th></tr><tr><th class='text-left'>Время согласования истекло</th><th class='text-right'>" + firstColumnValuesTimeUpSumm + "</th></tr></thead></table>" +
                            "<style>  .table { width: auto; margin-bottom: 20px; border: 5px solid #edd14b; border-collapse: collapse; margin: 0px 0px 0px 0px }.table th {  width: 280px; padding: 5px; } .table td {  border: 3px solid #edd14b; padding: 5px; } .text-center {text-align: center; background: #edd14b;}  .text-right_ {text-align: right; background: #edd14b;} .text-left {text-align: left;border: 1px solid #edd14b; font-weight: 100;} .text-right {text-align: right;border: 1px solid #edd14b;font-weight: 100;} div{color: #d0d4ce}</style>" + "<br/>" + "Дата и время формирования отчёта: " + String.Format("{0:d} - {0:t}", DateTime.Now) + "<br/><br/>" + "<hr><div>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";

                    //1 Вариант
                    //Message.Body = "Количество поступивщих заявок: " + firstColumnValuesSumm + "<br/><br/>" + "Из них: " + "<table class='table'><thead><tr><th class='text-center'>Текущий статус</th><th class='text-right'>Количество</th></tr></thead> <tbody><tr><td class='text-left'>На рассмотрении у руководителя<br/><br/>На рассмотрении у экономиста<br/><br/>На рассмотрении у ДИД<br/><br/>На рассмотрении у диспетчера НИИАР<br/><br/>Отклонена руководителем<br/><br/>Отклонена экономистом<br/><br/>Отклонена ДИД<br/><br/>Отклонена диспетчером НИИАР<br/><br/>Согласовано руководителем<br/><br/>Согласовано экономистом<br/><br/>Согласовано ДИД<br/><br/>Согласовано Диспетчером НИИАР<br/><br/>Исполнено<br/><br/>Не исполнено</td><td class='text-right'>"
                    //   + considerationDirector + "<br/><br/>" + considerationEconomist + "<br/><br/>" + considerationDepartment + "<br/><br/>" + considerationDispatcherNIIAR_StatusDone + "<br/><br/>" + rejectedDirector + "<br/><br/>" + rejectedEconomist + "<br/><br/>" + rejectedDepartment + "<br/><br/>" + rejectedDispatcherNIIAR_StatusDone + "<br/><br/>" + agreedDirector + "<br/><br/>" + agreedEconomist + "<br/><br/>" + agreedDepartment + "<br/><br/>" + agreedDispatcherNIIAR_StatusDone + "<br/><br/>" + ExecutedDispatcherATA_StatusDone + "<br/><br/>" + NotExecutedDispatcherATA_StatusDone + "</td></tr></tbody></table>" +
                    //   "<style>  .table { width: auto; margin-bottom: 20px; border: 5px solid #edd14b; border-collapse: collapse; margin: 0px 0px 0px 0px }.table th {  width: 280px; font-weight: bold; padding: 5px; background: #edd14b; } .table td {  border: 3px solid #edd14b; padding: 5px; } .text-center {text-align: center;} .text-left {text-align: left;} .text-right {text-align: right;}</style>" + "<br/><br/>" + "Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется";
                    //1 Вариант
                    try
                    {
                        Smtp.Send(Message);
                    }
                    catch (Exception /*ex*/)
                    {
                        //MessageBox.Show(ex.Message);
                        return;
                    }


                }
            }


            if ((hour == DateTime.Now.Hour) && (minute == DateTime.Now.Minute))
            {

                using (var db = new MyDataModelDataContext())
                {
                    var usr = db.Users.FirstOrDefault(x => x.StatusID == 7);
                    var us = db.Users.FirstOrDefault(x => x.StatusID == 5);
                    //Почта
                    SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 2525);
                    Smtp.Credentials = new NetworkCredential(us.Email, "DC7zZ5CvANF9GZhzK65V");
                    MailMessage Message = new MailMessage();
                    Smtp.EnableSsl = true;
                    Message.From = new MailAddress(us.Email);
                    Message.To.Add(new MailAddress(usr.Email));
                    Message.Subject = "Отчёт по заявкам за " + DateTime.Now;
                    Message.IsBodyHtml = true;//html отображение

                    //посчитать количество определенных одинаковых данных
                    var firstColumnValuesDirector = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now).GroupBy(x => x.DirectorStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                    Dictionary<string, int> resultDirector = firstColumnValuesDirector.ToDictionary(arg => arg.Key, arg => arg.Count);

                    int agreedDirector;
                    resultDirector.TryGetValue("Согласовано", out agreedDirector);
                    int considerationDirector;
                    resultDirector.TryGetValue("На рассмотрении", out considerationDirector);
                    int rejectedDirector;
                    resultDirector.TryGetValue("Отклонена", out rejectedDirector);


                    var firstColumnValuesEconomist = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now).GroupBy(x => x.EconomistStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                    Dictionary<string, int> resultEconomist = firstColumnValuesEconomist.ToDictionary(arg => arg.Key, arg => arg.Count);

                    int agreedEconomist;
                    resultEconomist.TryGetValue("Согласовано", out agreedEconomist);
                    int considerationEconomist;
                    resultEconomist.TryGetValue("На рассмотрении", out considerationEconomist);
                    int rejectedEconomist;
                    resultEconomist.TryGetValue("Отклонена", out rejectedEconomist);

                    var firstColumnValuesDepartment = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now && (x.IntercityСity != true || x.DaysWorkerOrWeekend != true)).GroupBy(x => x.DepartmentStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                    Dictionary<string, int> resultDepartment = firstColumnValuesDepartment.ToDictionary(arg => arg.Key, arg => arg.Count);

                    int agreedDepartment;
                    resultDepartment.TryGetValue("Согласовано", out agreedDepartment);
                    int considerationDepartment;
                    resultDepartment.TryGetValue("На рассмотрении", out considerationDepartment);
                    int rejectedDepartment;
                    resultDepartment.TryGetValue("Отклонена", out rejectedDepartment);

                    var firstColumnValuesDispatcherNIIAR_StatusDone = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now).GroupBy(x => x.DispatcherNIIAR_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                    Dictionary<string, int> resultDispatcherNIIAR_StatusDone = firstColumnValuesDispatcherNIIAR_StatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                    int agreedDispatcherNIIAR_StatusDone;
                    resultDispatcherNIIAR_StatusDone.TryGetValue("Согласовано", out agreedDispatcherNIIAR_StatusDone);
                    int considerationDispatcherNIIAR_StatusDone;
                    resultDispatcherNIIAR_StatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIAR_StatusDone);
                    int rejectedDispatcherNIIAR_StatusDone;
                    resultDispatcherNIIAR_StatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIAR_StatusDone);

                    var firstColumnValuesDispatcherATA_StatusDone = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now).GroupBy(x => x.DispatcherATA_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                    Dictionary<string, int> resultDispatcherATA_StatusDone = firstColumnValuesDispatcherATA_StatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                    int ExecutedDispatcherATA_StatusDone;
                    resultDispatcherATA_StatusDone.TryGetValue("Исполнено", out ExecutedDispatcherATA_StatusDone);
                    int NotExecutedDispatcherATA_StatusDone;
                    resultDispatcherATA_StatusDone.TryGetValue("Не исполнено", out NotExecutedDispatcherATA_StatusDone);
                    //посчитать количество определенных одинаковых данных
                    var firstColumnValuesSumm = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now).Count();

                    Message.Body = "Количество поступивщих заявок: " + firstColumnValuesSumm + "<br/><br/>" + "Из них: " + "<table class='table'><thead><tr><th class='text-center'>Текущий статус</th><th class='text-right_'>Количество</th></tr><tr><th class='text-left'>На рассмотрении у руководителей</th><th class='text-right'>" + considerationDirector + "</th></tr><tr><th class='text-left'>На рассмотрении у экономистов</th> <th class='text-right'>" + considerationEconomist + "</th></tr><tr><th class='text-left'>На рассмотрении у ДИД</th><th class='text-right'>" + considerationDepartment + "</th></tr><tr> <th class='text-left'>На рассмотрении у диспетчера НИИАР</th><th class='text-right'>" + considerationDispatcherNIIAR_StatusDone + "</th></tr><tr><th class='text-left'>Отклонены руководителями</th><th class='text-right'>" + rejectedDirector + "</th></tr><tr><th class='text-left'>Отклонены экономистами</th><th class='text-right'>" + rejectedEconomist + "</th></tr><tr><th class='text-left'>Отклонены ДИД</th><th class='text-right'>" + rejectedDepartment + "</th></tr><tr><th class='text-left'>Отклонены диспетчером НИИАР</th><th class='text-right'>" + rejectedDispatcherNIIAR_StatusDone + "</th></tr><tr><th class='text-left'>Согласовано руководителями</th><th class='text-right'>" + agreedDirector + "</th></tr><tr><th class='text-left'>Согласовано экономистами</th><th class='text-right'>" + agreedEconomist + "</th></tr><tr><th class='text-left'>Согласовано ДИД</th><th class='text-right'>" + agreedDepartment + "</th></tr><tr><th class='text-left'>Согласовано у диспетчера НИИАР</th><th class='text-right'>" + agreedDispatcherNIIAR_StatusDone + "</th></tr><tr><th class='text-left'>Исполнено</th><th class='text-right'>" + ExecutedDispatcherATA_StatusDone + "</th></tr><tr><th class='text-left'>Не исполнено</th><th class='text-right'>" + NotExecutedDispatcherATA_StatusDone + "</th></tr></thead></table>" +
                        "<style>  .table { width: auto; margin-bottom: 20px; border: 5px solid #edd14b; border-collapse: collapse; margin: 0px 0px 0px 0px }.table th {  width: 280px; padding: 5px; } .table td {  border: 3px solid #edd14b; padding: 5px; } .text-center {text-align: center; background: #edd14b;}  .text-right_ {text-align: right; background: #edd14b;} .text-left {text-align: left;border: 1px solid #edd14b; font-weight: 100;} .text-right {text-align: right;border: 1px solid #edd14b;font-weight: 100;} div{color: #d0d4ce}</style>" + "<br/><br/>" + "<hr><div>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";


                    try
                    {
                        Smtp.Send(Message);

                    }
                    catch (Exception /*ex*/)
                    {
                        //MessageBox.Show(ex.Message);
                        return;
                    }
                }


                //Message.Body = "Ваша заявка согласована у " + GeneralClass.statusUser + "а!"
                //+ "\n" + "Комментарий: " + tbComment.Text + " <a href=@\'s2x:run\'>Запустить приложение</a>" + "<html><body><br><img src=\"https://www.cyberforum.ru/images/cyberforum_logo.jpg\" alt=\"Super Game!\"></body></html>" +
                //"<table class='table'><thead><tr><th>Категория</th><th>Товары</th></tr></thead><tbody>";


                //Message.Body = "<tr><td class='text-right'>" + app.Customer + "</td></tr>" +
                //"<tr><td class='text-right'>" + app.Status + "</td></tr>";


                //"</tbody></table><style> .table {width: auto; margin - bottom: 20px; border: 1px solid #dddddd;border - collapse: collapse;margin: 0px 0px 0px 555px} .text-left {text - align: left;}</style>";


            }
        }
        //таймер для отправки отчётов


        private void dgvApplication_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) //отключение выбора первой строки при загрузке формы
        {
            //dgvApplication.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            var appView = bsApplicationsView.Current as ApplicationView;
            if (bsApplicationsView.Count != 0 && appView == null/*&& (GeneralClass.mode == (int)GeneralClass.Status.Client ||*/
               /*GeneralClass.mode == (int)GeneralClass.Status.Admin || GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)*/)
            {
                lSelectRequest.Visible = true;
                lSelectRequest.Text = "Выберите заявку";
                pInformation.Height = 844;
                pDetails.Height = 757;
                pTransport.Visible = false;
            }
            if (bsApplicationsView.Count == 0 && appView == null)
            {
                lSelectRequest.Visible = true;
                lSelectRequest.Text = "Заявок нет";
                if (GeneralClass.mode != (int)GeneralClass.Status.Client)
                {
                    pInformation.Height = 844;
                    pDetails.Height = 757;
                }
                pTransport.Visible = false;
            }



            if (pFilters.Visible == true || GeneralClass.bsPositionAgreed >= 0 && (GeneralClass.mode == (int)GeneralClass.Status.Client || GeneralClass.mode == (int)GeneralClass.Status.Admin))
            {
                dgvApplication.ClearSelection();
            }

        }
        private void dgvApplicationAgreedView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var appAgreedView = bsApplicationAgreedView.Current as ApplicationAgreedView;
            if (bsApplicationAgreedView.Count != 0 && appAgreedView == null && (GeneralClass.mode == (int)GeneralClass.Status.Client ||
                GeneralClass.mode == (int)GeneralClass.Status.Admin || GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA))
            {
                lSelectRequest.Visible = true;
                lSelectRequest.Text = "Выберите заявку";
                pInformation.Height = 844;
                pDetails.Height = 757;
                pTransport.Visible = false;
            }
            if (bsApplicationAgreedView.Count == 0 && appAgreedView == null && (GeneralClass.mode == (int)GeneralClass.Status.Client ||
                GeneralClass.mode == (int)GeneralClass.Status.Admin || GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA))
            {
                lSelectRequest.Visible = true;
                lSelectRequest.Text = "Заявок нет";
                pInformation.Height = 844;
                pDetails.Height = 757;
                pTransport.Visible = false;
            }

            if (pFilters.Visible == true)
            {
                lSelectRequest.Visible = true;
                BlankPage();

                dgvApplicationAgreedView.ClearSelection();
            }

            if (GeneralClass.bsPosition >= 0)
            {
                dgvApplicationAgreedView.ClearSelection();
            }
        }

        //принять
        private void btnTakeApplication_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("Пожалуйста, подождите!", "Ожидание", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (_App == null) return;

            if (string.IsNullOrEmpty(tbCPC.Text) || tbCPC.Text == "Шифр производственных затрат" && GeneralClass.mode == (int)GeneralClass.Status.Economist)
            {
                MessageBox.Show("Введите шифр производственных затрат", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnCancelJoin.Visible = false;
            //почта
            var appView = bsApplicationsView.Current as ApplicationView;
            using (var db = new MyDataModelDataContext())
            {
                var us = db.Users.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                if (GeneralClass.applicationJoin == 0)
                {
                    SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 2525);
                    Smtp.Credentials = new NetworkCredential(us.Email, "DC7zZ5CvANF9GZhzK65V");
                    MailMessage Message = new MailMessage();
                    Smtp.EnableSsl = true;
                    Message.From = new MailAddress(us.Email);

                    Message.To.Add(new MailAddress(appView.Email));

                    Message.Subject = "Статус заявки № " + _App.Id;

                    Message.IsBodyHtml = true;


                    if (GeneralClass.mode == (int)GeneralClass.Status.Director)
                    {
                        if (tbComment.Text == "Комментарий")
                        {
                            Message.Body = "Ваша заявка согласована у Руководителя!" + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                        }
                        else
                        {
                            Message.Body = "Ваша заявка согласована у Руководителя!!"
                            + "\n" + "Комментарий: " + tbComment.Text + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                        }
                    }
                    if (GeneralClass.mode == (int)GeneralClass.Status.Economist)
                    {
                        if (tbComment.Text == "Комментарий")
                        {
                            Message.Body = "Ваша заявка согласована у " + GeneralClass.statusUser + "а!" + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                        }
                        else
                        {
                            Message.Body = "Ваша заявка согласована у " + GeneralClass.statusUser + "а!"
                            + "\n" + "Комментарий: " + tbComment.Text + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                        }
                    }
                    if (GeneralClass.mode == (int)GeneralClass.Status.Department)
                    {
                        if (tbComment.Text == "Комментарий")
                        {
                            Message.Body = "Ваша заявка согласована у " + GeneralClass.statusUser + "!" + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>"; ;
                        }
                        else
                        {
                            Message.Body = "Ваша заявка согласована у " + GeneralClass.statusUser + "!"
                                 + "\n" + "Комментарий: " + tbComment.Text + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                        }
                    }
                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
                    {
                        if (tbComment.Text == "Комментарий")
                        {
                            Message.Body = "<br/><br/><div>Ваша заявка согласована у Диспетчера НИИАР! Транспорт назначен (заявка № " + _App.Id + ")</div>" + "<br/>" + "<table class='table'><thead><tr><th class='text-center'>Марка</th><th class='text-center'>Гос. номер</th></tr><tr><th class='text-center_'>" + lCarModel.Text + "</th><th class='text-center_'>" + lRegisterSign.Text + "</th></tr></thead></table>" + "<br/>Время отправления: " + String.Format("{0:d} - {0:t}", _App.StartDate) + "<br/><br/>Маршрут: " + _App.Route + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" +
                             "<style>  .table { width: auto; margin-bottom: 20px; border: 5px solid #dddddd; border-collapse: collapse; margin: 0px 0px 0px 0px }.table th {  width: 280px; padding: 5px; } .text-center {text-align: center; background: #dddddd;}  .text-center_ {text-align: center;border: 1px solid #dddddd; font-weight: 100;}  div{font-weight: bold} .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                        }
                        else
                        {
                            //    Message.Body = "Ваша заявка согласована у Диспетчера НИИАР! Назначенный транспорт : " + lCarModel.Text + " - " + lRegisterSign.Text
                            //        + "\n" + "Комментарий: " + tbComment.Text;

                            Message.Body = /*"<img src=\"https://thumb.cloud.mail.ru/thumb/xw1/Учебный%20год%202021-2022_4%20курс/Весенний%20семестр/Технология%20разработки%20программного%20обеспечения/Курсовая%20работа/Cars.png\">" + */"<br/><br/><div>Ваша заявка согласована у Диспетчера НИИАР! Транспорт назначен (заявка № " + _App.Id + ")</div>" + "<br/>" + "<table class='table'><thead><tr><th class='text-center'>Марка</th><th class='text-center'>Гос. номер</th></tr><tr><th class='text-center_'>" + lCarModel.Text + "</th><th class='text-center_'>" + lRegisterSign.Text + "</th></tr></thead></table>" + "<br/>Время отправления: " + String.Format("{0:d} - {0:t}", _App.StartDate) + "<br/><br/>Маршрут: " + _App.Route + "<br/><br/>Комментарий: " + tbComment.Text + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" +
                             "<style>  .table { width: auto; margin-bottom: 20px; border: 5px solid #dddddd; border-collapse: collapse; margin: 0px 0px 0px 0px }.table th {  width: 280px; padding: 5px; } .text-center {text-align: center; background: #dddddd;}  .text-center_ {text-align: center;border: 1px solid #dddddd; font-weight: 100;}  div{font-weight: bold} .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                        }
                    }
                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                    {
                        if (tbComment.Text == "Комментарий")
                        {
                            Message.Body = "Ваша заявка исполнена!" + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                        }
                        else
                        {
                            Message.Body = "Ваша заявка исполнена!"
                                + "\n" + "Комментарий: " + tbComment.Text + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                        }
                    }

                    try
                    {
                        Smtp.Send(Message);
                        MessageBox.Show("Уведомление отправлено клиенту на электронный адрес " + appView.Email + "!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Уведомление не отправлено клиенту на электронный адрес " + appView.Email + "! Причина:\n" + ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
                    {
                        foreach (var appJoin in db.ApplicationView.Where(x => x.StartDate == _AppView.StartDate && x.Route == _AppView.Route && x.TypeCar == _AppView.TypeCar && DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0)))
                        {
                            SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 2525);
                            Smtp.Credentials = new NetworkCredential(us.Email, "DC7zZ5CvANF9GZhzK65V");
                            MailMessage Message = new MailMessage();
                            Smtp.EnableSsl = true;
                            Message.From = new MailAddress(us.Email);

                            Message.To.Add(new MailAddress(appJoin.Email));

                            Message.Subject = "Статус заявки № " + appJoin.Id;

                            Message.IsBodyHtml = true;

                            if (tbComment.Text == "Комментарий")
                            {
                                Message.Body = "<br/><br/><div>Ваша заявка согласована у Диспетчера НИИАР! Транспорт назначен (заявка № " + appJoin.Id + ")</div>" + "<br/>" + "<table class='table'><thead><tr><th class='text-center'>Марка</th><th class='text-center'>Гос. номер</th></tr><tr><th class='text-center_'>" + lCarModel.Text + "</th><th class='text-center_'>" + lRegisterSign.Text + "</th></tr></thead></table>" + "<br/>Время отправления: " + String.Format("{0:d} - {0:t}", appJoin.StartDate) + "<br/><br/>Маршрут: " + appJoin.Route + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" +
                                 "<style>  .table { width: auto; margin-bottom: 20px; border: 5px solid #dddddd; border-collapse: collapse; margin: 0px 0px 0px 0px }.table th {  width: 280px; padding: 5px; } .text-center {text-align: center; background: #dddddd;}  .text-center_ {text-align: center;border: 1px solid #dddddd; font-weight: 100;}  div{font-weight: bold} .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                            }
                            else
                            {
                                Message.Body = "<br/><br/><div>Ваша заявка согласована у Диспетчера НИИАР! Транспорт назначен (заявка № " + appJoin.Id + ")</div>" + "<br/>" + "<table class='table'><thead><tr><th class='text-center'>Марка</th><th class='text-center'>Гос. номер</th></tr><tr><th class='text-center_'>" + lCarModel.Text + "</th><th class='text-center_'>" + lRegisterSign.Text + "</th></tr></thead></table>" + "<br/>Время отправления: " + String.Format("{0:d} - {0:t}", appJoin.StartDate) + "<br/><br/>Маршрут: " + appJoin.Route + "<br/><br/>Комментарий: " + appJoin.СommentDispatcherNIIAR + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" +
                                "<style>  .table { width: auto; margin-bottom: 20px; border: 5px solid #dddddd; border-collapse: collapse; margin: 0px 0px 0px 0px }.table th {  width: 280px; padding: 5px; } .text-center {text-align: center; background: #dddddd;}  .text-center_ {text-align: center;border: 1px solid #dddddd; font-weight: 100;}  div{font-weight: bold} .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                            }


                            try
                            {
                                Smtp.Send(Message);
                                MessageBox.Show("Сообщения отправлены клиентам на почту!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Сообщения не отправлены клиентам на почту! Причина:\n" + ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }


                    }

                }

            }
            //почта

            try
            {
                using (var db = new MyDataModelDataContext())
                {
                    var cln = db.Applications.FirstOrDefault(w => w.Id == _App.Id);


                    //var appViewMessаge = db.ApplicationView.Where(x => x.Economist == appView.Economist).FirstOrDefault();


                    //var usr = db.Users.Where(x => x.SurName + " " + x.Name + " " + x.Partonymic == appView.Economist).FirstOrDefault();

                    var us = db.Users.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                    var ecn = db.Users.Where(x => x.StatusID == 4 && x.DivisionID == us.DivisionID).FirstOrDefault();

                    var usrDispatcherNIIAR = db.Users.Where(x => x.StatusID == 5).FirstOrDefault();

                    if (GeneralClass.mode == (int)GeneralClass.Status.Director)
                    {
                        cln.DirectorStatusDoneID = 1;
                        if (tbComment.Text != "Комментарий")
                        {
                            cln.СommentDirector = tbComment.Text;
                        }

                        //почта
                        SmtpClient SmtpDirector = new SmtpClient("smtp.mail.ru", 2525);
                        SmtpDirector.Credentials = new NetworkCredential(us.Email, "DC7zZ5CvANF9GZhzK65V");
                        MailMessage MessageEconomist = new MailMessage();
                        SmtpDirector.EnableSsl = true;
                        MessageEconomist.From = new MailAddress(us.Email);
                        MessageEconomist.To.Add(new MailAddress(ecn.Email));
                        MessageEconomist.IsBodyHtml = true;
                        MessageEconomist.Subject = "Заявка № " + _App.Id + " на cогласование";
                        MessageEconomist.Body = "Время согласования заявки: до " + String.Format("{0:d} - {0:t}", _App.DateCreation.AddDays(1)) + ", иначе заявка будет автоматически отклонена." + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>"
                            + "<style>.colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";


                        try
                        {
                            SmtpDirector.Send(MessageEconomist);
                            MessageBox.Show("Уведомление отправлено экономисту на электронный адрес " + ecn.Email + "!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Уведомление не отправлено экономисту на электронный адрес " + ecn.Email + "! Причина:\n" + ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        //почта
                    }
                    if (GeneralClass.mode == (int)GeneralClass.Status.Economist)
                    {


                        cln.EconomistStatusDoneID = 1;
                        if (tbComment.Text != "Комментарий")
                        {
                            cln.СommentEconomist = tbComment.Text;
                        }
                        if (tbCPC.Text != "Шифр производственных затрат")
                        {
                            cln.CPC = tbCPC.Text;
                        }

                        //почта
                        if (_App.Days == true && _App.IntercityСity == true)
                        {

                            SmtpClient SmtpEconomist = new SmtpClient("smtp.mail.ru", 2525);
                            SmtpEconomist.Credentials = new NetworkCredential(us.Email, "DC7zZ5CvANF9GZhzK65V");
                            MailMessage MessageDispatcherNIIAR = new MailMessage();
                            SmtpEconomist.EnableSsl = true;
                            MessageDispatcherNIIAR.From = new MailAddress(us.Email);
                            MessageDispatcherNIIAR.To.Add(new MailAddress(usrDispatcherNIIAR.Email));
                            MessageDispatcherNIIAR.IsBodyHtml = true;
                            MessageDispatcherNIIAR.Subject = "Заявка № " + _App.Id + " на cогласование";
                            MessageDispatcherNIIAR.Body = "Время согласования заявки: до " + String.Format("{0:d} - {0:t}", _App.DateCreation.AddDays(1)) + ", иначе заявка будет автоматически отклонена." + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>"
                                + "<style>.colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";


                            try
                            {
                                SmtpEconomist.Send(MessageDispatcherNIIAR);
                                MessageBox.Show("Уведомление отправлено диспетчеру НИИАР на электронный адрес " + usrDispatcherNIIAR.Email + "!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Уведомление не отправлено диспетчеру НИИАР на электронный адрес " + usrDispatcherNIIAR.Email + "! Причина:\n" + ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                        }
                        else
                        {
                            var usrDepartament = db.Users.Where(x => x.StatusID == 6).FirstOrDefault();
                            SmtpClient SmtpEconomist = new SmtpClient("smtp.mail.ru", 2525);
                            SmtpEconomist.Credentials = new NetworkCredential(us.Email, "DC7zZ5CvANF9GZhzK65V");
                            MailMessage MessageDepartament = new MailMessage();
                            SmtpEconomist.EnableSsl = true;
                            MessageDepartament.From = new MailAddress(us.Email);
                            MessageDepartament.To.Add(new MailAddress(usrDepartament.Email));
                            MessageDepartament.IsBodyHtml = true;
                            MessageDepartament.Subject = "Заявка № " + _App.Id + " на cогласование";
                            MessageDepartament.Body = "Время согласования заявки: до " + String.Format("{0:d} - {0:t}", _App.DateCreation.AddDays(1)) + ", иначе заявка будет автоматически отклонена." + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>"
                                + "<style>.colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";


                            try
                            {
                                SmtpEconomist.Send(MessageDepartament);
                                MessageBox.Show("Уведомление отправлено ДИД на электронный адрес " + usrDepartament.Email + "!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Уведомление не отправлено ДИД на электронный адрес " + usrDepartament.Email + "! Причина:\n" + ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                        }
                        //почта

                    }
                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
                    {
                        //var sts = db.Cars.FirstOrDefault(w => w.Id == _App.CarID);

                        var st = db.Cars.FirstOrDefault(x => x.RegisterSign == lRegisterSign.Text);

                        var usrDispatcherATA = db.Users.Where(x => x.StatusID == 7).FirstOrDefault();

                        if (GeneralClass.applicationJoin == 0)
                        {
                            cln.DispatcherNIIAR_StatusDoneID = 1;

                            if (tbComment.Text != "Комментарий")
                            {
                                cln.СommentDispatcherNIIAR = tbComment.Text;
                            }

                            //почта

                            SmtpClient SmtpDispatcherNIIAR = new SmtpClient("smtp.mail.ru", 2525);
                            SmtpDispatcherNIIAR.Credentials = new NetworkCredential(us.Email, "DC7zZ5CvANF9GZhzK65V");
                            MailMessage MessageDispatcherATA = new MailMessage();
                            SmtpDispatcherNIIAR.EnableSsl = true;
                            MessageDispatcherATA.From = new MailAddress(us.Email);
                            MessageDispatcherATA.To.Add(new MailAddress(usrDispatcherATA.Email));
                            MessageDispatcherATA.IsBodyHtml = true;
                            MessageDispatcherATA.Subject = "Заявка № " + _App.Id + " на исполнение";
                            MessageDispatcherATA.Body = "<br/><br/><div>Заявка согласована у Диспетчера НИИАР! Транспорт назначен (заявка № " + _App.Id + ")</div>" + "<br/>" + "<table class='table'><thead><tr><th class='text-center'>Марка</th><th class='text-center'>Гос. номер</th></tr><tr><th class='text-center_'>" + lCarModel.Text + "</th><th class='text-center_'>" + lRegisterSign.Text + "</th></tr></thead></table>" + "<br/>Время отправления: " + String.Format("{0:d} - {0:t}", _App.StartDate) + "<br/><br/>Маршрут: " + _App.Route + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" +
                            "<style>  .table { width: auto; margin-bottom: 20px; border: 5px solid #dddddd; border-collapse: collapse; margin: 0px 0px 0px 0px }.table th {  width: 280px; padding: 5px; } .text-center {text-align: center; background: #dddddd;}  .text-center_ {text-align: center;border: 1px solid #dddddd; font-weight: 100;}  div{font-weight: bold} .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";

                            try
                            {
                                SmtpDispatcherNIIAR.Send(MessageDispatcherATA);
                                MessageBox.Show("Уведомление отправлено диспетчеру АТА на электронный адрес " + usrDispatcherATA.Email + "!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Уведомление не отправлено диспетчеру АТА на электронный адрес " + usrDispatcherATA.Email + "! Причина:\n" + ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            //почта
                        }

                        else
                        {

                            SmtpClient SmtpDispatcherNIIAR = new SmtpClient("smtp.mail.ru", 2525);
                            SmtpDispatcherNIIAR.Credentials = new NetworkCredential(us.Email, "DC7zZ5CvANF9GZhzK65V");
                            MailMessage MessageDispatcherATA = new MailMessage();
                            SmtpDispatcherNIIAR.EnableSsl = true;
                            MessageDispatcherATA.From = new MailAddress(us.Email);
                            MessageDispatcherATA.To.Add(new MailAddress(usrDispatcherATA.Email));
                            MessageDispatcherATA.IsBodyHtml = true;
                            foreach (var appJoinAll in db.Applications.Where(x => x.StartDate == _App.StartDate && x.Route == _App.Route && x.TypeCarID == _App.TypeCarID && DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && x.DispatcherNIIAR_StatusDoneID == _App.DispatcherNIIAR_StatusDoneID && x.SelectionApplicationJoin == true).GroupBy(x => x.Route, (k, ie) => string.Join(", ", ie.Select(x => x.Id)))) // из столбца в строку
                            {
                                MessageDispatcherATA.Subject = "Заявки № " + appJoinAll + " объединены и согласованы";
                                MessageDispatcherATA.Body = "<br/><br/><div>Заявки согласованы у Диспетчера НИИАР! Транспорт назначен (заявки № " + appJoinAll + ")</div>" + "<br/>" + "<table class='table'><thead><tr><th class='text-center'>Марка</th><th class='text-center'>Гос. номер</th></tr><tr><th class='text-center_'>" + lCarModel.Text + "</th><th class='text-center_'>" + lRegisterSign.Text + "</th></tr></thead></table>" + "<br/>Время отправления: " + String.Format("{0:d} - {0:t}", _App.StartDate) + "<br/><br/>Маршрут: " + _App.Route + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" +
                                "<style>  .table { width: auto; margin-bottom: 20px; border: 5px solid #dddddd; border-collapse: collapse; margin: 0px 0px 0px 0px }.table th {  width: 280px; padding: 5px; } .text-center {text-align: center; background: #dddddd;}  .text-center_ {text-align: center;border: 1px solid #dddddd; font-weight: 100;}  div{font-weight: bold} .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";

                            }

                            try
                            {
                                SmtpDispatcherNIIAR.Send(MessageDispatcherATA);
                                MessageBox.Show("Уведомление отправлено диспетчеру АТА на электронный адрес " + usrDispatcherATA.Email + "!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Уведомление не отправлено диспетчеру АТА на электронный адрес " + usrDispatcherATA.Email + "! Причина:\n" + ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            //почта
                            foreach (var appJoin in db.Applications.Where(x => x.StartDate == _App.StartDate && x.Route == _App.Route && x.TypeCarID == _App.TypeCarID && DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && x.DispatcherNIIAR_StatusDoneID == _App.DispatcherNIIAR_StatusDoneID && x.SelectionApplicationJoin == true))
                            {
                                appJoin.DispatcherNIIAR_StatusDoneID = 1;

                                if (tbComment.Text != "Комментарий")
                                {
                                    appJoin.СommentDispatcherNIIAR = tbComment.Text;
                                }


                            }

                            //st.StatusCarID = 2;



                        }
                        //sts.StatusCarID = 2;
                        st.StatusCarID = 2;

                        GeneralClass.applicationJoin = 0;
                        GeneralClass.ModelCar = null;
                        GeneralClass.RegisterSign = null;
                        timer.Start();
                        LoadDataBase();

                    }
                    if (GeneralClass.mode == (int)GeneralClass.Status.Department)
                    {
                        cln.DepartmentStatusDoneID = 1;
                        if (tbComment.Text != "Комментарий")
                        {
                            cln.СommentDepartment = tbComment.Text;
                        }

                        //почта
                        SmtpClient SmtpDepartment = new SmtpClient("smtp.mail.ru", 2525);
                        SmtpDepartment.Credentials = new NetworkCredential(us.Email, "DC7zZ5CvANF9GZhzK65V");
                        MailMessage MessageDispatcherNIIAR = new MailMessage();
                        SmtpDepartment.EnableSsl = true;
                        MessageDispatcherNIIAR.From = new MailAddress(us.Email);
                        MessageDispatcherNIIAR.To.Add(new MailAddress(usrDispatcherNIIAR.Email));
                        MessageDispatcherNIIAR.IsBodyHtml = true;
                        MessageDispatcherNIIAR.Subject = "Заявка № " + _App.Id + " на cогласование";
                        MessageDispatcherNIIAR.Body = "Время согласования заявки: до " + String.Format("{0:d} - {0:t}", _App.DateCreation.AddDays(1)) + ", иначе заявка будет автоматически отклонена." + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>"
                            + "<style>.colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";


                        try
                        {
                            SmtpDepartment.Send(MessageDispatcherNIIAR);
                            MessageBox.Show("Уведомление отправлено диспетчеру НИИАР на электронный адрес " + usrDispatcherNIIAR.Email + "!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Уведомление не отправлено диспетчеру НИИАР на электронный адрес " + usrDispatcherNIIAR.Email + "! Причина:\n" + ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //почта
                    }
                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                    {
                        var sts = db.Cars.FirstOrDefault(w => w.Id == _App.CarID);
                        cln.DispatcherATA_StatusDoneID = 4;
                        sts.StatusCarID = 1;
                        if (tbComment.Text != "Комментарий")
                        {
                            cln.СommentDispatcherATA = tbComment.Text;
                        }
                    }


                    var appJoinNotification = db.Applications.Where(x => x.StartDate == _App.StartDate && x.Route == _App.Route && x.TypeCarID == _App.TypeCarID && DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && x.DispatcherNIIAR_StatusDoneID == _App.DispatcherNIIAR_StatusDoneID && x.SelectionApplicationJoin == true);
                    if (appJoinNotification != null)
                    {
                        foreach (var appJoinAll in db.Applications.Where(x => x.StartDate == _App.StartDate && x.Route == _App.Route && x.TypeCarID == _App.TypeCarID && DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && x.DispatcherNIIAR_StatusDoneID == _App.DispatcherNIIAR_StatusDoneID && x.SelectionApplicationJoin == true).GroupBy(x => x.Route, (k, ie) => string.Join(", ", ie.Select(x => x.Id)))) // из столбца в строку
                        {
                            // задаем иконку всплывающей подсказки
                            niTaskbar.BalloonTipIcon = ToolTipIcon.Info;
                            // задаем текст подсказки
                            niTaskbar.BalloonTipText = "Заявки № " + appJoinAll + " согласованы вами!";

                            // устанавливаем заголовка
                            niTaskbar.BalloonTipTitle = "Информация";
                            niTaskbar.ShowBalloonTip(12);
                        }

                    }
                    else
                    {
                        // задаем иконку всплывающей подсказки
                        niTaskbar.BalloonTipIcon = ToolTipIcon.Info;
                        // задаем текст подсказки
                        niTaskbar.BalloonTipText = "Заявка № " + _App.Id + " согласована вами!";

                        // устанавливаем заголовка
                        niTaskbar.BalloonTipTitle = "Информация";

                        niTaskbar.ShowBalloonTip(12);
                    }

                    db.SubmitChanges();

                }
                MessageBox.Show(_Msg, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadDataBase();

            //lNumber.Visible = false;
            //lStatus.Visible = false;
            //lClients.Visible = false;
            //lEmail.Visible = false;
            //lDivision.Visible = false;
            //lPost.Visible = false;
            //lDivision.Visible = false;
            //lDepartment.Visible = false;
            //lLocation.Visible = false;
            //lWorkPhone.Visible = false;
            //lMobilePhone.Visible = false;
            //lStartDate.Visible = false;
            //lEndDate.Visible = false;
            //lTypeCar.Visible = false;
            //lPassenger.Visible = false;
            //lCargo.Visible = false;
            //lPlaceSubmission.Visible = false;
            //lRoute.Visible = false;

            //dgvApplication.ClearSelection();

            tbComment.Text = "Комментарий";
            tbComment.ForeColor = Color.Silver;
            tbCPC.Text = "Шифр производственных затрат";
            tbCPC.ForeColor = Color.Silver;
            //tbComment_Leave(this, new EventArgs());
            //tbComment.Clear();

        }
        //принять

        //отклонить
        private void btnDeclineApplication_Click(object sender, EventArgs e)
        {
            if (_App == null) return;
            btnCancelJoin.Visible = false;
            //почта
            var appView = bsApplicationsView.Current as ApplicationView;
            using (var db = new MyDataModelDataContext())
            {
                var us = db.Users.FirstOrDefault(x => x.Id == GeneralClass.UserID);

                SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 2525);
                Smtp.Credentials = new NetworkCredential(us.Email, "DC7zZ5CvANF9GZhzK65V");
                MailMessage Message = new MailMessage();
                Smtp.EnableSsl = true;
                Message.From = new MailAddress(us.Email);
                Message.To.Add(new MailAddress(appView.Email));
                Message.IsBodyHtml = true;
                Message.Subject = "Статус заявки № " + _App.Id;
                if (GeneralClass.mode == (int)GeneralClass.Status.Director)
                {
                    if (tbComment.Text == "Комментарий")
                    {
                        Message.Body = "Ваша заявка отклонена Руководителем!" + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                    }
                    else
                    {
                        Message.Body = "Ваша заявка отклонена Руководителем!"
                            + "\n" + "Комментарий: " + tbComment.Text + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";

                    }
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.Economist)
                {
                    if (tbComment.Text == "Комментарий")
                    {
                        Message.Body = "Ваша заявка отклонена " + GeneralClass.statusUser + "ом!" + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                    }
                    else
                    {
                        Message.Body = "Ваша заявка отклонена " + GeneralClass.statusUser + "ом!"
                            + "\n" + "Комментарий: " + tbComment.Text + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";

                    }
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.Department)
                {
                    if (tbComment.Text == "Комментарий")
                    {
                        Message.Body = "Ваша заявка отклонена " + GeneralClass.statusUser + "!" + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                    }
                    else
                    {
                        Message.Body = "Ваша заявка отклонена " + GeneralClass.statusUser + "!"
                             + "\n" + "Комментарий: " + tbComment.Text + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                    }
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
                {
                    if (tbComment.Text == "Комментарий")
                    {
                        Message.Body = "Ваша заявка отклонена Диспетчером НИИАР!" + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                    }
                    else
                    {
                        Message.Body = "Ваша заявка отклонена Диспетчером НИИАР!"
                            + "\n" + "Комментарий: " + tbComment.Text + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                    }
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                {
                    if (tbComment.Text == "Комментарий")
                    {
                        Message.Body = "Ваша заявка не исполнена!" + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                    }
                    else
                    {
                        Message.Body = "Ваша заявка не исполнена!"
                            + "\n" + "Комментарий: " + tbComment.Text + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                    }
                }


                try
                {
                    Smtp.Send(Message);
                    MessageBox.Show("Уведомление отправлено клиенту на электронный адрес " + appView.Email + "!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уведомление не отправлено клиенту на электронный адрес " + appView.Email + "! Причина:\n" + ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            //почта

            try
            {
                using (var db = new MyDataModelDataContext())
                {
                    var cln = db.Applications.FirstOrDefault(w => w.Id == _App.Id);
                    if (GeneralClass.mode == (int)GeneralClass.Status.Director)
                    {

                        cln.DirectorStatusDoneID = 2;
                        cln.CarID = 1;
                        if (tbComment.Text != "Комментарий")
                        {
                            cln.СommentDirector = tbComment.Text;
                        }
                    }
                    if (GeneralClass.mode == (int)GeneralClass.Status.Economist)
                    {
                        if (string.IsNullOrEmpty(tbCPC.Text) || tbCPC.Text == "Шифр производственных затрат")
                        {
                            MessageBox.Show("Введите шифр производственных затрат", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        cln.EconomistStatusDoneID = 2;
                        cln.CarID = 1;
                        if (tbComment.Text != "Комментарий")
                        {
                            cln.СommentEconomist = tbComment.Text;
                        }
                        if (tbCPC.Text != "Шифр производственных затрат")
                        {
                            cln.CPC = tbCPC.Text;
                        }
                    }
                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
                    {
                        if (GeneralClass.applicationJoin == 0)
                        {
                            cln.DispatcherNIIAR_StatusDoneID = 2;
                            cln.CarID = 1;
                            if (tbComment.Text != "Комментарий")
                            {
                                cln.СommentDispatcherNIIAR = tbComment.Text;
                            }
                        }

                        else
                        {
                            foreach (var appJoin in db.Applications.Where(x => x.StartDate == _App.StartDate && x.Route == _App.Route && x.TypeCarID == _App.TypeCarID && DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && x.DispatcherNIIAR_StatusDoneID == _App.DispatcherNIIAR_StatusDoneID && x.SelectionApplicationJoin == true))
                            {
                                appJoin.DispatcherNIIAR_StatusDoneID = 2;
                                appJoin.CarID = 1;
                                appJoin.SelectionApplicationJoin = false;
                                //appJoin.ApplicationJoin = null;
                                if (tbComment.Text != "Комментарий")
                                {
                                    appJoin.СommentDispatcherNIIAR = tbComment.Text;
                                }
                            }
                        }
                        GeneralClass.applicationJoin = 0;
                        GeneralClass.ModelCar = null;
                        GeneralClass.RegisterSign = null;
                        timer.Start();
                        LoadDataBase();

                    }
                    if (GeneralClass.mode == (int)GeneralClass.Status.Department)
                    {

                        cln.DepartmentStatusDoneID = 2;
                        cln.CarID = 1;
                        if (tbComment.Text != "Комментарий")
                        {
                            cln.СommentDepartment = tbComment.Text;
                        }
                    }

                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                    {
                        var sts = db.Cars.FirstOrDefault(w => w.Id == _App.CarID);
                        cln.DispatcherATA_StatusDoneID = 5;
                        //cln.CarID = 1;
                        sts.StatusCarID = 1;
                        if (tbComment.Text != "Комментарий")
                        {
                            cln.СommentDispatcherATA = tbComment.Text;
                        }
                    }


                    // задаем иконку всплывающей подсказки
                    niTaskbar.BalloonTipIcon = ToolTipIcon.Info;
                    // задаем текст подсказки
                    niTaskbar.BalloonTipText = "Заявка № " + _App.Id + " отклонена вами!";

                    // устанавливаем заголовка
                    niTaskbar.BalloonTipTitle = "Информация";

                    niTaskbar.ShowBalloonTip(12);


                    db.SubmitChanges();

                }
                MessageBox.Show("Заявка отклонена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadDataBase();
            //lNumber.Visible = false;
            //lStatus.Visible = false;
            //lClients.Visible = false;
            //lEmail.Visible = false;
            //lDivision.Visible = false;
            //lPost.Visible = false;
            //lDivision.Visible = false;
            //lDepartment.Visible = false;
            //lLocation.Visible = false;
            //lWorkPhone.Visible = false;
            //lMobilePhone.Visible = false;
            //lStartDate.Visible = false;
            //lEndDate.Visible = false;
            //lTypeCar.Visible = false;
            //lPassenger.Visible = false;
            //lCargo.Visible = false;
            //lPlaceSubmission.Visible = false;
            //lRoute.Visible = false;

            //dgvApplication.ClearSelection();
            btnCancelJoin.Visible = false;
            tbComment.Text = "Комментарий";
            tbComment.ForeColor = Color.Silver;
            tbCPC.Text = "Шифр производственных затрат";
            tbCPC.ForeColor = Color.Silver;
            //tbComment_Leave(this, new EventArgs());
            //tbComment.Clear();
        }
        //отклонить

        //отменить объединение заявки
        private void btnCancelJoin_Click(object sender, EventArgs e)
        {
            GeneralClass.applicationJoin = 0;
            btnDelete_Click(sender, e);
            //lCarModel.Text = null;
            //lRegisterSign.Text = null;
            btnCancelJoin.Visible = false;
            //btnTakeApplication.Enabled = false;
            //btnDelete.Enabled = false;


            using (var db = new MyDataModelDataContext())
            {
                foreach (var appSelectionJoin in db.Applications.Where(x => x.StartDate == _App.StartDate && x.Route == _App.Route && x.TypeCarID == _App.TypeCarID && DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && x.DispatcherNIIAR_StatusDoneID == _App.DispatcherNIIAR_StatusDoneID))
                {
                    appSelectionJoin.SelectionApplicationJoin = null;
                    appSelectionJoin.ApplicationJoin = null;
                    appSelectionJoin.CarID = 1;
                    db.SubmitChanges();
                }
                timer.Start();
                LoadDataBase();
            }
        }
        //отменить объединение заявки



        //создать заявку
        private void tsbCreateRequest_Click(object sender, EventArgs e)
        {
            using (var db = new MyDataModelDataContext())
            {
                var usr = db.Users.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                var usrDrc = db.Users.FirstOrDefault(x => x.DivisionID == usr.DivisionID && x.StatusID == 3);
                var usrEcn = db.Users.FirstOrDefault(x => x.DivisionID == usr.DivisionID && x.StatusID == 4);

                if (usrDrc == null)
                {
                    MessageBox.Show("Руководитель вашего подразделения не зарегистрирован в системе! Вы сможете подать заявку только после его регистрации!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (usrEcn == null)
                {
                    MessageBox.Show("Экономист вашего подразделения не зарегистрирован в системе! Вы сможете подать заявку только после его регистрации!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            CreateUpdateApplicationsForm form = new CreateUpdateApplicationsForm();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                LoadDataBase();
            }
        }
        //создать заявку


        private void tbComment_Enter(object sender, EventArgs e)
        {
            if (tbComment.Text == "Комментарий")
            {
                tbComment.Text = "";
                tbComment.ForeColor = Color.Black;
            }
        }

        private void tbComment_Leave(object sender, EventArgs e)
        {
            if (tbComment.Text == "")
            {
                tbComment.Text = "Комментарий";
                tbComment.ForeColor = Color.Silver;
            }
        }
        private void tbCPC_Enter(object sender, EventArgs e)
        {
            if (tbCPC.Text == "Шифр производственных затрат")
            {
                tbCPC.Text = "";
                tbCPC.ForeColor = Color.Black;
            }
        }

        private void tbCPC_Leave(object sender, EventArgs e)
        {
            if (tbCPC.Text == "")
            {
                tbCPC.Text = "Шифр производственных затрат";
                tbCPC.ForeColor = Color.Silver;
            }
        }



        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (_App == null) return;
            timer.Stop();
            CreateCarsForm form = new CreateCarsForm(_App, _AppView);
            form.ShowDialog();

            if (form.DialogResult != DialogResult.Cancel)
            {
                timer.Start();
                lCarModel.Text = GeneralClass.ModelCar;
                lRegisterSign.Text = GeneralClass.RegisterSign;
                btnDelete.Enabled = true;
                btnTakeApplication.Enabled = true;
                dgvApplication.Enabled = false;
            }
            else
            {
                timer.Start();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                using (var db = new MyDataModelDataContext())
                {

                    var app = db.Applications.FirstOrDefault(w => w.Id == _App.Id);

                    app.CarID = 1;

                    GeneralClass.RegisterSign = null;
                    GeneralClass.ModelCar = null;
                    dgvApplication.Enabled = true;
                    btnTakeApplication.Enabled = false;

                    db.SubmitChanges();
                    if (GeneralClass.applicationJoin == 0)
                    {
                        LoadDataBase();
                    }
                    else
                    {
                        btnDelete.Enabled = false;
                        btnTakeApplication.Enabled = false;
                        lCarModel.Text = null;
                        lRegisterSign.Text = null;
                    }
                }
                MessageBox.Show("Информация обновлена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void pApplication_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Примите или отклоните выбранную заявку, либо удалите выбранную машину!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Form form = this.FindForm();
            form.Close();
            form.Dispose();
        }


        //word
        public readonly string TemplateFileName = @"Word\Pattern.docx";// Расположение шаблона   
        private void btnWordSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lNumber.Text) && lSelectRequest.Text == "Заявок нет")
            {
                MessageBox.Show("Данных для сохранения нет!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var num = lNumber.Text;
            var status = lStatus.Text;
            var clientFullName = lClients.Text;
            var email = lEmail.Text;
            var post = lPost.Text;
            var division = lDivision.Text;
            var building = lBuilding.Text;
            var room = lRoom.Text;
            var workPhone = lWorkPhone.Text;
            var mobilePhone = lMobilePhone.Text;
            var directorFullName = lDirectorFullName.Text;
            var economistFullName = lEconomistFullName.Text;
            var daysWorkerOrWeekend = lDaysWorkerOrWeekend.Text;
            var startDate = lStartDate.Text;
            var endDate = lEndDate.Text;
            var intercityСity = lIntercityСity.Text;
            var typeCar = lTypeCar.Text;
            var passenger = lPassenger.Text;
            var cargo = lCargo.Text;
            var placeSubmission = lPlaceSubmission.Text;
            var route = lRoute.Text;
            var purposeUsingTransport = lPurposeUsingTransport.Text;


            var wordApp = new Word.Application();//создание приложения
            wordApp.Visible = false;

            try
            {
                var fullPath = Path.GetFullPath(TemplateFileName);

                var wordDocument = wordApp.Documents.Open(fullPath); //открываем файл word

                ReplaceWordStub("{Num}", num, wordDocument);// замена
                ReplaceWordStub("{Status}", status, wordDocument);
                ReplaceWordStub("{ClientFullName}", clientFullName, wordDocument);
                ReplaceWordStub("{Emeil}", email, wordDocument);
                ReplaceWordStub("{Post}", post, wordDocument);
                ReplaceWordStub("{Division}", division, wordDocument);
                ReplaceWordStub("{Building}", building, wordDocument);
                ReplaceWordStub("{Room}", room, wordDocument);
                ReplaceWordStub("{WorkPhone}", workPhone, wordDocument);
                ReplaceWordStub("{MobilePhone}", mobilePhone, wordDocument);
                ReplaceWordStub("{DirectorFullName}", directorFullName, wordDocument);
                ReplaceWordStub("{EconomistFullName}", economistFullName, wordDocument);
                ReplaceWordStub("{DaysWorkerOrWeekend}", daysWorkerOrWeekend, wordDocument);
                ReplaceWordStub("{StartDate}", startDate, wordDocument);
                ReplaceWordStub("{EndDate}", endDate, wordDocument);
                ReplaceWordStub("{IntercityСity}", intercityСity, wordDocument);
                ReplaceWordStub("{TypeCar}", typeCar, wordDocument);
                ReplaceWordStub("{Passenger}", passenger, wordDocument);
                ReplaceWordStub("{Cargo}", cargo, wordDocument);
                ReplaceWordStub("{PlaceSubmission}", placeSubmission, wordDocument);
                ReplaceWordStub("{Route}", route, wordDocument);
                ReplaceWordStub("{PurposeUsingTransport}", purposeUsingTransport, wordDocument);
                if (pTransport.Visible == true)
                {
                    var designatedTransport = lTransport_.Text;
                    var transport = lTransport.Text;
                    ReplaceWordStub("{DesignatedTransport}", designatedTransport, wordDocument);
                    ReplaceWordStub("{Transport}", transport, wordDocument);
                }
                else
                {
                    var designatedTransport = "";
                    var transport = "";
                    ReplaceWordStub("{DesignatedTransport}", designatedTransport, wordDocument);
                    ReplaceWordStub("{Transport}", transport, wordDocument);
                }


                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "Word Documents (*.docx)|*.docx";

                sfd.FileName = "Заявка № " + lNumber.Text.Substring(0, lNumber.Text.IndexOf(@"    [")) + ".docx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    wordDocument.SaveAs(sfd.FileName);
                    wordDocument.Close();
                }
                else
                {
                    wordDocument.Close();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument) // замена меток на нашу информациию
        {
            // получить содержимое документа word
            var range = wordDocument.Content;
            range.Find.ClearFormatting();// очистить поиски в документе
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);//передача параметров (FindText-то, что хотим найти внутри документа;
                                                                           //ReplaceWith-то, чем хотим заменить)

        }
        //word

        private void cbArchiveApplications_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataBase();
        }

        //Excel
        private void tsbExcelSave_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();

            //Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            //Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            try
            {
                ////посчитать количество определенных одинаковых данных
                //var firstColumnValuesDirector =
                //   from DataGridViewRow row in dgvApplicationAgreedView.Rows
                //   group row by row.Cells["directorStatusDoneDataGridViewTextBoxColumn1"].Value into res
                //   where res.Key != null
                //   select new { res.Key, Count = res.Count() };

                //Dictionary<object, int> resultDirector = firstColumnValuesDirector.ToDictionary(arg => arg.Key, arg => arg.Count);

                //int agreedDirector;
                //resultDirector.TryGetValue("Согласовано", out agreedDirector);

                //int considerationDirector;
                //resultDirector.TryGetValue("На рассмотрении", out considerationDirector);
                //int rejectedDirector;
                //resultDirector.TryGetValue("Отклонена", out rejectedDirector);



                //var firstColumnValuesEconomist =
                //  from DataGridViewRow row in dgvApplicationAgreedView.Rows
                //  group row by row.Cells["economistStatusDoneDataGridViewTextBoxColumn1"].Value into res
                //  where res.Key != null
                //  select new { res.Key, Count = res.Count() };

                //Dictionary<object, int> resultEconomist = firstColumnValuesEconomist.ToDictionary(arg => arg.Key, arg => arg.Count);

                //int agreedEconomist;
                //resultEconomist.TryGetValue("Согласовано", out agreedEconomist);
                //int considerationEconomist;
                //resultEconomist.TryGetValue("На рассмотрении", out considerationEconomist);
                //int rejectedEconomist;
                //resultEconomist.TryGetValue("Отклонена", out rejectedEconomist);

                //var firstColumnValuesDepartment =
                //     from DataGridViewRow row in dgvApplicationAgreedView.Rows
                //     group row by row.Cells["departmentStatusDoneDataGridViewTextBoxColumn1"].Value into res
                //     where res.Key != null
                //     select new { res.Key, Count = res.Count() };

                //Dictionary<object, int> resultDepartment = firstColumnValuesDepartment.ToDictionary(arg => arg.Key, arg => arg.Count);

                //int agreedDepartment;
                //resultDepartment.TryGetValue("Согласовано", out agreedDepartment);
                //int considerationDepartment;
                //resultDepartment.TryGetValue("На рассмотрении", out considerationDepartment);
                //int rejectedDepartment;
                //resultDepartment.TryGetValue("Отклонена", out rejectedDepartment);

                //var firstColumnValuesDispatcherNIIARStatusDone =
                // from DataGridViewRow row in dgvApplicationAgreedView.Rows
                // group row by row.Cells["dispatcherNIIARStatusDoneDataGridViewTextBoxColumn1"].Value into res
                // where res.Key != null
                // select new { res.Key, Count = res.Count() };

                //Dictionary<object, int> resultDispatcherNIIARStatusDone = firstColumnValuesDispatcherNIIARStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                //int agreedDispatcherNIIARStatusDone;
                //resultDispatcherNIIARStatusDone.TryGetValue("Согласовано", out agreedDispatcherNIIARStatusDone);
                //int considerationDispatcherNIIARStatusDone;
                //resultDispatcherNIIARStatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIARStatusDone);
                //int rejectedDispatcherNIIARStatusDone;
                //resultDispatcherNIIARStatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIARStatusDone);

                //var firstColumnValuesDispatcherATAStatusDone =
                // from DataGridViewRow row in dgvApplicationAgreedView.Rows
                // group row by row.Cells["dispatcherATAStatusDoneDataGridViewTextBoxColumn1"].Value into res
                // where res.Key != null
                // select new { res.Key, Count = res.Count() };

                //Dictionary<object, int> resultDispatcherATAStatusDone = firstColumnValuesDispatcherATAStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                //int ExecutedDispatcherATAStatusDone;
                //resultDispatcherATAStatusDone.TryGetValue("Исполнено", out ExecutedDispatcherATAStatusDone);
                //int NotExecutedDispatcherATAStatusDone;
                //resultDispatcherATAStatusDone.TryGetValue("Не исполнено", out NotExecutedDispatcherATAStatusDone);
                ////посчитать количество определенных одинаковых данных


                ////минимальная/максимальная дата
                //var dateTimes = dgvApplicationAgreedView.Rows.Cast<DataGridViewRow>().Select(x => Convert.ToDateTime(x.Cells["dateCreationDataGridViewTextBoxColumn1"].Value));
                //var minValue = dateTimes.Min();
                //var maxValue = dateTimes.Max();
                ////минимальная/максимальная дата

                //Книга.
                var ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                if (GeneralClass.mode == (int)GeneralClass.Status.Director ||
                    GeneralClass.mode == (int)GeneralClass.Status.Economist)
                {
                    if (bsApplicationsView.Count == 0)
                    {
                        MessageBox.Show("Нет актуальных заявок для сохранения!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    }


                    using (var db = new MyDataModelDataContext())
                    {
                        var usrDrc = db.UserView.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                        var usrEcn = db.UserView.FirstOrDefault(x => x.Division == usrDrc.Division && x.Status == "Экономист");

                        var usrDr = db.UserView.FirstOrDefault(x => x.Division == usrEcn.Division && x.Status == "Руководитель");
                        if (usrDr == null)
                        {
                            MessageBox.Show("Руководитель вашего подразделения не зарегистрирован в системе! Вы сможете сохранить данные только после его регистрации!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (usrEcn == null)
                        {
                            MessageBox.Show("Экономист вашего подразделения не зарегистрирован в системе! Вы сможете сохранить данные только после его регистрации!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //посчитать количество определенных одинаковых данных
                        var firstColumnValuesDirector = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now && x.Director == usrDrc.Customer).GroupBy(x => x.DirectorStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDirector = firstColumnValuesDirector.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDirector;
                        resultDirector.TryGetValue("Согласовано", out agreedDirector);
                        int considerationDirector;
                        resultDirector.TryGetValue("На рассмотрении", out considerationDirector);
                        int rejectedDirector;
                        resultDirector.TryGetValue("Отклонена", out rejectedDirector);


                        var firstColumnValuesEconomist = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now && x.Economist == usrEcn.Customer).GroupBy(x => x.EconomistStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultEconomist = firstColumnValuesEconomist.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedEconomist;
                        resultEconomist.TryGetValue("Согласовано", out agreedEconomist);
                        int considerationEconomist;
                        resultEconomist.TryGetValue("На рассмотрении", out considerationEconomist);
                        int rejectedEconomist;
                        resultEconomist.TryGetValue("Отклонена", out rejectedEconomist);

                        var firstColumnValuesDepartment = db.ApplicationAgreedView.Where(x => (x.DateCreation.AddDays(1) > DateTime.Now && (x.IntercityСity != true || x.DaysWorkerOrWeekend != true)) && x.Director == usrDrc.Customer).GroupBy(x => x.DepartmentStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDepartment = firstColumnValuesDepartment.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDepartment;
                        resultDepartment.TryGetValue("Согласовано", out agreedDepartment);
                        int considerationDepartment;
                        resultDepartment.TryGetValue("На рассмотрении", out considerationDepartment);
                        int rejectedDepartment;
                        resultDepartment.TryGetValue("Отклонена", out rejectedDepartment);

                        var firstColumnValuesDispatcherNIIARStatusDone = db.ApplicationAgreedView.Where(x => (x.DateCreation.AddDays(1) > DateTime.Now) && x.Director == usrDrc.Customer).GroupBy(x => x.DispatcherNIIAR_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDispatcherNIIARStatusDone = firstColumnValuesDispatcherNIIARStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("Согласовано", out agreedDispatcherNIIARStatusDone);
                        int considerationDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIARStatusDone);
                        int rejectedDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIARStatusDone);

                        var firstColumnValuesDispatcherATAStatusDone = db.ApplicationAgreedView.Where(x => (x.DateCreation.AddDays(1) > DateTime.Now) && x.Director == usrDrc.Customer).GroupBy(x => x.DispatcherATA_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDispatcherATAStatusDone = firstColumnValuesDispatcherATAStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int ExecutedDispatcherATAStatusDone;
                        resultDispatcherATAStatusDone.TryGetValue("Исполнено", out ExecutedDispatcherATAStatusDone);
                        int NotExecutedDispatcherATAStatusDone;
                        resultDispatcherATAStatusDone.TryGetValue("Не исполнено", out NotExecutedDispatcherATAStatusDone);
                        //посчитать количество определенных одинаковых данных
                        var firstColumnValuesSumm = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now && x.Director == usrDrc.Customer).Count();




                        //Таблица.
                        //ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

                        //ExcelApp.Visible = false;
                        //var fullPath = Path.GetFullPath(@"Excel\Pattern");

                        //var ExcelDocument = ExcelApp.Workbooks.Open(fullPath); //открываем файл word
                        //ExcelApp.Columns.ColumnWidth = 33;


                        for (int i = 1; i < dgvApplication.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[21, i].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[21, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            ExcelApp.Cells[21, i].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        }
                        //цвет ячейки
                        ExcelApp.Cells[1, 1].Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);
                        ExcelApp.Cells[1, 2].Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);

                        ExcelApp.Cells[2, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        ExcelApp.Cells[2, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        ExcelApp.Cells[17, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        ExcelApp.Cells[18, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        ExcelApp.Cells[17, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        ExcelApp.Cells[18, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        ExcelApp.Cells[20, 1].Interior.Color = ColorTranslator.ToOle(Color.DarkGray);
                        //цвет ячейки


                        //строки вправо
                        for (int i = 1; i <= 18; i++)
                        {
                            ExcelApp.Cells[i, 2].HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        }
                        //строки вправо

                        ExcelApp.Cells[1, 2] = String.Format("{0:d} - {0:t}", DateTime.Now.AddDays(-1)) + " — " + String.Format("{0:d} - {0:t}", DateTime.Now);

                        ExcelApp.Cells[2, 1].Font.Bold = true;//жирный шрифт
                        ExcelApp.Cells[2, 2].Font.Bold = true;//жирный шрифт
                        ExcelApp.Cells[2, 1] = "Текущий статус";
                        ExcelApp.Cells[2, 2] = "Количество";
                        ExcelApp.Cells[3, 2] = considerationDirector;
                        ExcelApp.Cells[4, 2] = considerationEconomist;
                        ExcelApp.Cells[5, 2] = considerationDepartment;
                        ExcelApp.Cells[6, 2] = considerationDispatcherNIIARStatusDone;
                        ExcelApp.Cells[7, 2] = rejectedDirector;
                        ExcelApp.Cells[8, 2] = rejectedEconomist;
                        ExcelApp.Cells[9, 2] = rejectedDepartment;
                        ExcelApp.Cells[10, 2] = rejectedDispatcherNIIARStatusDone;
                        ExcelApp.Cells[11, 2] = agreedDirector;
                        ExcelApp.Cells[12, 2] = agreedEconomist;
                        ExcelApp.Cells[13, 2] = agreedDepartment;
                        ExcelApp.Cells[14, 2] = agreedDispatcherNIIARStatusDone;
                        ExcelApp.Cells[15, 2] = ExecutedDispatcherATAStatusDone;
                        ExcelApp.Cells[16, 2] = NotExecutedDispatcherATAStatusDone;
                        ExcelApp.Cells[17, 2].Font.Bold = true;//жирный шрифт
                        ExcelApp.Cells[18, 2].Font.Bold = true;//жирный шрифт
                        ExcelApp.Cells[17, 2] = firstColumnValuesSumm;
                        ExcelApp.Cells[18, 2] = String.Format("{0:d} - {0:t}", DateTime.Now);

                        ExcelApp.Cells[1, 1].Font.Bold = true;
                        ExcelApp.Cells[1, 2].Font.Bold = true;

                        //строки влево
                        for (int i = 1; i <= 18; i++)
                        {
                            ExcelApp.Cells[i, 1].HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        }
                        //строки влево
                        ExcelApp.Cells[1, 1].Font.Size = 16; //размер шрифта 
                        ExcelApp.Cells[1, 2].Font.Size = 16;
                        ExcelApp.Cells[20, 1] = "Заявки";
                        ExcelApp.Cells[20, 1].Font.Size = 16;
                        ExcelApp.Cells[20, 1].Font.Bold = true;
                        ExcelApp.Cells[1, 1] = "Отчёт по заявкам за период: ";
                        ExcelApp.Cells[3, 1] = "На рассмотрении у руководителей";
                        ExcelApp.Cells[4, 1] = "На рассмотрении у экономистов";
                        ExcelApp.Cells[5, 1] = "На рассмотрении у ДИД";
                        ExcelApp.Cells[6, 1] = "На рассмотрении у диспетчера НИИАР";
                        ExcelApp.Cells[7, 1] = "Отклонены руководителями";
                        ExcelApp.Cells[8, 1] = "Отклонены экономистами";
                        ExcelApp.Cells[9, 1] = "Отклонены ДИД";
                        ExcelApp.Cells[10, 1] = "Отклонены  диспетчером НИИАР";
                        ExcelApp.Cells[11, 1] = "Согласовано руководителями";
                        ExcelApp.Cells[12, 1] = "Согласовано экономистами";
                        ExcelApp.Cells[13, 1] = "Согласовано ДИД";
                        ExcelApp.Cells[14, 1] = "Согласовано диспетчером НИИАР";
                        ExcelApp.Cells[15, 1] = "Исполнено";
                        ExcelApp.Cells[16, 1] = "Не исполнено";
                        ExcelApp.Cells[17, 1].Font.Bold = true;//жирный шрифт
                        ExcelApp.Cells[17, 1] = "Количество поступивших заявок";
                        ExcelApp.Cells[18, 1].Font.Bold = true;//жирный шрифт
                        ExcelApp.Cells[18, 1] = "Дата оформления отчёта";



                        //ExcelApp.Cells[21, 1] = "№";
                        //ExcelApp.Cells[21, 2] = "Клиент";
                        //ExcelApp.Cells[21, 3] = "Email";
                        //ExcelApp.Cells[21, 4] = "Должность";
                        //ExcelApp.Cells[21, 5] = "Подразделение";
                        //ExcelApp.Cells[21, 6] = "Отдел";
                        //ExcelApp.Cells[21, 7] = "Руководитель";
                        //ExcelApp.Cells[21, 8] = "Экономист";
                        //ExcelApp.Cells[21, 9] = "ШПЗ";
                        //ExcelApp.Cells[21, 10] = "Межгород/Город";
                        //ExcelApp.Cells[21, 11] = "Цель использования транспорта";
                        //ExcelApp.Cells[21, 12] = "День";
                        //ExcelApp.Cells[21, 13] = "Расположение";
                        //ExcelApp.Cells[21, 14] = "Рабочий телефон";
                        //ExcelApp.Cells[21, 15] = "Мобильный телефон";
                        //ExcelApp.Cells[21, 16] = "Дата создания";
                        //ExcelApp.Cells[21, 17] = "Начало работы";
                        //ExcelApp.Cells[21, 18] = "Завершение работы";
                        //ExcelApp.Cells[21, 19] = "Тип транспорта";
                        //ExcelApp.Cells[21, 20] = "Модель";
                        //ExcelApp.Cells[21, 21] = "Гос. номер";
                        //ExcelApp.Cells[21, 22] = "Количество пассажиров";
                        //ExcelApp.Cells[21, 23] = "Груз (кг)";
                        //ExcelApp.Cells[21, 24] = "Место подачи";
                        //ExcelApp.Cells[21, 25] = "Маршрут";
                        //ExcelApp.Cells[21, 26] = "Комментарий клиента";
                        //ExcelApp.Cells[21, 27] = "Комментарий руководителя";
                        //ExcelApp.Cells[21, 28] = "Комментарий экономиста";
                        //ExcelApp.Cells[21, 29] = "Комментарий ДИД";
                        //ExcelApp.Cells[21, 30] = "Комментарий диспетчера";
                        //ExcelApp.Cells[21, 31] = "Статус у руководителя";
                        //ExcelApp.Cells[21, 32] = "Статус у экономиста";
                        //ExcelApp.Cells[21, 33] = "Статус у ДИД";
                        //ExcelApp.Cells[21, 34] = "Статус у диспетчера НИИАР";
                        //ExcelApp.Cells[21, 35] = "Статус у диспетчера АТА";

                        //for (char c = 'A'; c <= 'Z'; c++)
                        //{
                        //    for (char a = 'A'; a <= 'Z'; a++)
                        //    {
                        //        ExcelApp.Columns["B:C"].AutoFit();
                        //    }
                        //}


                        //Для названия столбцов из datagridview
                        for (int i = 1; i < dgvApplication.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[21, i] = dgvApplication.Columns[i - 1].HeaderText;
                        }
                        //Для названия столбцов  datagridview



                        for (int i = 0; i < dgvApplication.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvApplication.ColumnCount; j++)
                            {
                                ExcelApp.Cells[i + 22, j + 1] = dgvApplication.Rows[i].Cells[j].Value;


                            }
                        }

                        ExcelApp.Columns.AutoFit();//автоширина столбцов(ВЫПОЛНЕНИЕ ДОЛЖНО БЫТЬ ПОСЛЕ ЗАПОЛНЕНИЯ СТОЛБЦОВ ДАННЫМИ!)
                        SaveFileDialog sfd = new SaveFileDialog();

                        sfd.Filter = "Word Documents (*.xlsx)|*.xlsx";

                        sfd.FileName = "Заявки_" + String.Format("{0:d}", DateTime.Now) + ".xlsx";


                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            ExcelWorkBook.SaveAs(sfd.FileName);
                            ExcelWorkBook.Close();
                            ExcelApp.Quit();

                        }
                        else
                        {
                            ExcelWorkBook.Close(0);
                            ExcelApp.Quit();
                            //ExcelDocument.Close();
                            //ExcelWorkBook.Close();

                        }
                    }
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.Department ||
                   GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
                {
                    if (bsApplicationsView.Count == 0)
                    {
                        MessageBox.Show("Нет актуальных заявок для сохранения!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    }
                    using (var db = new MyDataModelDataContext())
                    {
                        //посчитать количество определенных одинаковых данных
                        var firstColumnValuesDirector = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now).GroupBy(x => x.DirectorStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDirector = firstColumnValuesDirector.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDirector;
                        resultDirector.TryGetValue("Согласовано", out agreedDirector);
                        int considerationDirector;
                        resultDirector.TryGetValue("На рассмотрении", out considerationDirector);
                        int rejectedDirector;
                        resultDirector.TryGetValue("Отклонена", out rejectedDirector);


                        var firstColumnValuesEconomist = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now).GroupBy(x => x.EconomistStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultEconomist = firstColumnValuesEconomist.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedEconomist;
                        resultEconomist.TryGetValue("Согласовано", out agreedEconomist);
                        int considerationEconomist;
                        resultEconomist.TryGetValue("На рассмотрении", out considerationEconomist);
                        int rejectedEconomist;
                        resultEconomist.TryGetValue("Отклонена", out rejectedEconomist);

                        var firstColumnValuesDepartment = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now && (x.IntercityСity != true || x.DaysWorkerOrWeekend != true)).GroupBy(x => x.DepartmentStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDepartment = firstColumnValuesDepartment.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDepartment;
                        resultDepartment.TryGetValue("Согласовано", out agreedDepartment);
                        int considerationDepartment;
                        resultDepartment.TryGetValue("На рассмотрении", out considerationDepartment);
                        int rejectedDepartment;
                        resultDepartment.TryGetValue("Отклонена", out rejectedDepartment);

                        var firstColumnValuesDispatcherNIIARStatusDone = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now).GroupBy(x => x.DispatcherNIIAR_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDispatcherNIIARStatusDone = firstColumnValuesDispatcherNIIARStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("Согласовано", out agreedDispatcherNIIARStatusDone);
                        int considerationDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIARStatusDone);
                        int rejectedDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIARStatusDone);

                        var firstColumnValuesDispatcherATAStatusDone = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now).GroupBy(x => x.DispatcherATA_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDispatcherATAStatusDone = firstColumnValuesDispatcherATAStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int ExecutedDispatcherATAStatusDone;
                        resultDispatcherATAStatusDone.TryGetValue("Исполнено", out ExecutedDispatcherATAStatusDone);
                        int NotExecutedDispatcherATAStatusDone;
                        resultDispatcherATAStatusDone.TryGetValue("Не исполнено", out NotExecutedDispatcherATAStatusDone);
                        //посчитать количество определенных одинаковых данных
                        var firstColumnValuesSumm = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now).Count();


                        for (int i = 1; i < dgvApplication.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[21, i].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[21, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            ExcelApp.Cells[21, i].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        }
                        //цвет ячейки
                        ExcelApp.Cells[1, 1].Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);
                        ExcelApp.Cells[1, 2].Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);

                        ExcelApp.Cells[2, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        ExcelApp.Cells[2, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        ExcelApp.Cells[17, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        ExcelApp.Cells[18, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        ExcelApp.Cells[17, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        ExcelApp.Cells[18, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        ExcelApp.Cells[20, 1].Interior.Color = ColorTranslator.ToOle(Color.DarkGray);
                        //цвет ячейки


                        //строки вправо
                        for (int i = 1; i <= 18; i++)
                        {
                            ExcelApp.Cells[i, 2].HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        }
                        //строки вправо

                        ExcelApp.Cells[1, 2] = String.Format("{0:d} - {0:t}", DateTime.Now.AddDays(-1)) + " — " + String.Format("{0:d} - {0:t}", DateTime.Now);

                        ExcelApp.Cells[2, 1].Font.Bold = true;//жирный шрифт
                        ExcelApp.Cells[2, 2].Font.Bold = true;//жирный шрифт
                        ExcelApp.Cells[2, 1] = "Текущий статус";
                        ExcelApp.Cells[2, 2] = "Количество";
                        ExcelApp.Cells[3, 2] = considerationDirector;
                        ExcelApp.Cells[4, 2] = considerationEconomist;
                        ExcelApp.Cells[5, 2] = considerationDepartment;
                        ExcelApp.Cells[6, 2] = considerationDispatcherNIIARStatusDone;
                        ExcelApp.Cells[7, 2] = rejectedDirector;
                        ExcelApp.Cells[8, 2] = rejectedEconomist;
                        ExcelApp.Cells[9, 2] = rejectedDepartment;
                        ExcelApp.Cells[10, 2] = rejectedDispatcherNIIARStatusDone;
                        ExcelApp.Cells[11, 2] = agreedDirector;
                        ExcelApp.Cells[12, 2] = agreedEconomist;
                        ExcelApp.Cells[13, 2] = agreedDepartment;
                        ExcelApp.Cells[14, 2] = agreedDispatcherNIIARStatusDone;
                        ExcelApp.Cells[15, 2] = ExecutedDispatcherATAStatusDone;
                        ExcelApp.Cells[16, 2] = NotExecutedDispatcherATAStatusDone;
                        ExcelApp.Cells[17, 2].Font.Bold = true;//жирный шрифт
                        ExcelApp.Cells[18, 2].Font.Bold = true;//жирный шрифт
                        ExcelApp.Cells[17, 2] = firstColumnValuesSumm;
                        ExcelApp.Cells[18, 2] = String.Format("{0:d} - {0:t}", DateTime.Now);

                        ExcelApp.Cells[1, 1].Font.Bold = true;
                        ExcelApp.Cells[1, 2].Font.Bold = true;

                        //строки влево
                        for (int i = 1; i <= 18; i++)
                        {
                            ExcelApp.Cells[i, 1].HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        }
                        //строки влево
                        ExcelApp.Cells[1, 1].Font.Size = 16; //размер шрифта 
                        ExcelApp.Cells[1, 2].Font.Size = 16;
                        ExcelApp.Cells[20, 1] = "Заявки";
                        ExcelApp.Cells[20, 1].Font.Size = 16;
                        ExcelApp.Cells[20, 1].Font.Bold = true;
                        ExcelApp.Cells[1, 1] = "Отчёт по заявкам за период: ";
                        ExcelApp.Cells[3, 1] = "На рассмотрении у руководителей";
                        ExcelApp.Cells[4, 1] = "На рассмотрении у экономистов";
                        ExcelApp.Cells[5, 1] = "На рассмотрении у ДИД";
                        ExcelApp.Cells[6, 1] = "На рассмотрении у диспетчера НИИАР";
                        ExcelApp.Cells[7, 1] = "Отклонены руководителями";
                        ExcelApp.Cells[8, 1] = "Отклонены экономистами";
                        ExcelApp.Cells[9, 1] = "Отклонены ДИД";
                        ExcelApp.Cells[10, 1] = "Отклонены  диспетчером НИИАР";
                        ExcelApp.Cells[11, 1] = "Согласовано руководителями";
                        ExcelApp.Cells[12, 1] = "Согласовано экономистами";
                        ExcelApp.Cells[13, 1] = "Согласовано ДИД";
                        ExcelApp.Cells[14, 1] = "Согласовано диспетчером НИИАР";
                        ExcelApp.Cells[15, 1] = "Исполнено";
                        ExcelApp.Cells[16, 1] = "Не исполнено";
                        ExcelApp.Cells[17, 1].Font.Bold = true;//жирный шрифт
                        ExcelApp.Cells[17, 1] = "Количество поступивших заявок";
                        ExcelApp.Cells[18, 1].Font.Bold = true;//жирный шрифт
                        ExcelApp.Cells[18, 1] = "Дата оформления отчёта";

                        //Для названия столбцов из datagridview
                        for (int i = 1; i < dgvApplication.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[21, i] = dgvApplication.Columns[i - 1].HeaderText;
                        }
                        //Для названия столбцов  datagridview



                        for (int i = 0; i < dgvApplication.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvApplication.ColumnCount; j++)
                            {
                                ExcelApp.Cells[i + 22, j + 1] = dgvApplication.Rows[i].Cells[j].Value;


                            }
                        }

                        ExcelApp.Columns.AutoFit();//автоширина столбцов(ВЫПОЛНЕНИЕ ДОЛЖНО БЫТЬ ПОСЛЕ ЗАПОЛНЕНИЯ СТОЛБЦОВ ДАННЫМИ!)
                        SaveFileDialog sfd = new SaveFileDialog();

                        sfd.Filter = "Word Documents (*.xlsx)|*.xlsx";

                        sfd.FileName = "Заявки_" + String.Format("{0:d}", DateTime.Now) + ".xlsx";


                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            ExcelWorkBook.SaveAs(sfd.FileName);
                            ExcelWorkBook.Close();
                            ExcelApp.Quit();

                        }
                        else
                        {
                            ExcelWorkBook.Close(0);
                            ExcelApp.Quit();

                        }
                    }
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                {
                    if (cbArchiveApplications.Checked == false)
                    {
                        if (bsApplicationsView.Count == 0)
                        {
                            MessageBox.Show("Нет актуальных заявок для сохранения!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;

                        }
                        using (var db = new MyDataModelDataContext())
                        {
                            //посчитать количество определенных одинаковых данных
                            var firstColumnValuesDirector = db.ApplicationAgreedView.Where(x => (
                       (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone != "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone == "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении").GroupBy(x => x.DirectorStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDirector = firstColumnValuesDirector.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedDirector;
                            resultDirector.TryGetValue("Согласовано", out agreedDirector);
                            int considerationDirector;
                            resultDirector.TryGetValue("На рассмотрении", out considerationDirector);
                            int rejectedDirector;
                            resultDirector.TryGetValue("Отклонена", out rejectedDirector);


                            var firstColumnValuesEconomist = db.ApplicationAgreedView.Where(x => (
                       (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone != "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone == "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении").GroupBy(x => x.EconomistStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultEconomist = firstColumnValuesEconomist.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedEconomist;
                            resultEconomist.TryGetValue("Согласовано", out agreedEconomist);
                            int considerationEconomist;
                            resultEconomist.TryGetValue("На рассмотрении", out considerationEconomist);
                            int rejectedEconomist;
                            resultEconomist.TryGetValue("Отклонена", out rejectedEconomist);

                            var firstColumnValuesDepartment = db.ApplicationAgreedView.Where(x => ((
                       (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone != "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone == "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении") && (x.IntercityСity != true || x.DaysWorkerOrWeekend != true)).GroupBy(x => x.DepartmentStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDepartment = firstColumnValuesDepartment.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedDepartment;
                            resultDepartment.TryGetValue("Согласовано", out agreedDepartment);
                            int considerationDepartment;
                            resultDepartment.TryGetValue("На рассмотрении", out considerationDepartment);
                            int rejectedDepartment;
                            resultDepartment.TryGetValue("Отклонена", out rejectedDepartment);

                            var firstColumnValuesDispatcherNIIARStatusDone = db.ApplicationAgreedView.Where(x => (
                       (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone != "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone == "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении").GroupBy(x => x.DispatcherNIIAR_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDispatcherNIIARStatusDone = firstColumnValuesDispatcherNIIARStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedDispatcherNIIARStatusDone;
                            resultDispatcherNIIARStatusDone.TryGetValue("Согласовано", out agreedDispatcherNIIARStatusDone);
                            int considerationDispatcherNIIARStatusDone;
                            resultDispatcherNIIARStatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIARStatusDone);
                            int rejectedDispatcherNIIARStatusDone;
                            resultDispatcherNIIARStatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIARStatusDone);

                            var firstColumnValuesDispatcherATAStatusDone = db.ApplicationAgreedView.Where(x => (
                       (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone != "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone == "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении").GroupBy(x => x.DispatcherATA_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDispatcherATAStatusDone = firstColumnValuesDispatcherATAStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int ExecutedDispatcherATAStatusDone;
                            resultDispatcherATAStatusDone.TryGetValue("Исполнено", out ExecutedDispatcherATAStatusDone);
                            int NotExecutedDispatcherATAStatusDone;
                            resultDispatcherATAStatusDone.TryGetValue("Не исполнено", out NotExecutedDispatcherATAStatusDone);
                            //посчитать количество определенных одинаковых данных
                            var firstColumnValuesSumm = db.ApplicationAgreedView.Where(x => (
                       (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone != "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone == "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении").Count();

                            ////минимальная/максимальная дата
                            var dateTimes = db.ApplicationAgreedView.Where(x => (
                       (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone != "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone == "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении").Select(x => x.DateCreation);
                            //var dateTimes = dgvApplicationAgreedView.Rows.Cast<DataGridViewRow>().Select(x => Convert.ToDateTime(x.Cells["dateCreationDataGridViewTextBoxColumn1"].Value));
                            var minValue = dateTimes.Min();
                            var maxValue = dateTimes.Max();
                            ////минимальная/максимальная дата



                            for (int i = 1; i < dgvApplication.Columns.Count + 1; i++)
                            {
                                ExcelApp.Cells[21, i].Font.Bold = true;//жирный шрифт
                                ExcelApp.Cells[21, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                ExcelApp.Cells[21, i].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            }
                            //цвет ячейки
                            ExcelApp.Cells[1, 1].Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);
                            ExcelApp.Cells[1, 2].Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);

                            ExcelApp.Cells[2, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[2, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[17, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[18, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[17, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[18, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[20, 1].Interior.Color = ColorTranslator.ToOle(Color.DarkGray);
                            //цвет ячейки


                            //строки вправо
                            for (int i = 1; i <= 18; i++)
                            {
                                ExcelApp.Cells[i, 2].HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            }
                            //строки вправо

                            ExcelApp.Cells[1, 2] = String.Format("{0:d} - {0:t}", minValue) + " — " + String.Format("{0:d} - {0:t}", maxValue);

                            ExcelApp.Cells[2, 1].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[2, 2].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[2, 1] = "Текущий статус";
                            ExcelApp.Cells[2, 2] = "Количество";
                            ExcelApp.Cells[3, 2] = considerationDirector;
                            ExcelApp.Cells[4, 2] = considerationEconomist;
                            ExcelApp.Cells[5, 2] = considerationDepartment;
                            ExcelApp.Cells[6, 2] = considerationDispatcherNIIARStatusDone;
                            ExcelApp.Cells[7, 2] = rejectedDirector;
                            ExcelApp.Cells[8, 2] = rejectedEconomist;
                            ExcelApp.Cells[9, 2] = rejectedDepartment;
                            ExcelApp.Cells[10, 2] = rejectedDispatcherNIIARStatusDone;
                            ExcelApp.Cells[11, 2] = agreedDirector;
                            ExcelApp.Cells[12, 2] = agreedEconomist;
                            ExcelApp.Cells[13, 2] = agreedDepartment;
                            ExcelApp.Cells[14, 2] = agreedDispatcherNIIARStatusDone;
                            ExcelApp.Cells[15, 2] = ExecutedDispatcherATAStatusDone;
                            ExcelApp.Cells[16, 2] = NotExecutedDispatcherATAStatusDone;
                            ExcelApp.Cells[17, 2].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[18, 2].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[17, 2] = firstColumnValuesSumm;
                            ExcelApp.Cells[18, 2] = String.Format("{0:d} - {0:t}", DateTime.Now);

                            ExcelApp.Cells[1, 1].Font.Bold = true;
                            ExcelApp.Cells[1, 2].Font.Bold = true;

                            //строки влево
                            for (int i = 1; i <= 18; i++)
                            {
                                ExcelApp.Cells[i, 1].HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            }
                            //строки влево
                            ExcelApp.Cells[1, 1].Font.Size = 16; //размер шрифта 
                            ExcelApp.Cells[1, 2].Font.Size = 16;
                            ExcelApp.Cells[20, 1] = "Заявки";
                            ExcelApp.Cells[20, 1].Font.Size = 16;
                            ExcelApp.Cells[20, 1].Font.Bold = true;
                            ExcelApp.Cells[1, 1] = "Отчёт по заявкам за период: ";
                            ExcelApp.Cells[3, 1] = "На рассмотрении у руководителей";
                            ExcelApp.Cells[4, 1] = "На рассмотрении у экономистов";
                            ExcelApp.Cells[5, 1] = "На рассмотрении у ДИД";
                            ExcelApp.Cells[6, 1] = "На рассмотрении у диспетчера НИИАР";
                            ExcelApp.Cells[7, 1] = "Отклонены руководителями";
                            ExcelApp.Cells[8, 1] = "Отклонены экономистами";
                            ExcelApp.Cells[9, 1] = "Отклонены ДИД";
                            ExcelApp.Cells[10, 1] = "Отклонены  диспетчером НИИАР";
                            ExcelApp.Cells[11, 1] = "Согласовано руководителями";
                            ExcelApp.Cells[12, 1] = "Согласовано экономистами";
                            ExcelApp.Cells[13, 1] = "Согласовано ДИД";
                            ExcelApp.Cells[14, 1] = "Согласовано диспетчером НИИАР";
                            ExcelApp.Cells[15, 1] = "Исполнено";
                            ExcelApp.Cells[16, 1] = "Не исполнено";
                            ExcelApp.Cells[17, 1].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[17, 1] = "Количество поступивших заявок";
                            ExcelApp.Cells[18, 1].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[18, 1] = "Дата оформления отчёта";



                            //Для названия столбцов из datagridview
                            for (int i = 1; i < dgvApplication.Columns.Count + 1; i++)
                            {
                                ExcelApp.Cells[21, i] = dgvApplication.Columns[i - 1].HeaderText;
                            }
                            //Для названия столбцов  datagridview



                            for (int i = 0; i < dgvApplication.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvApplication.ColumnCount; j++)
                                {
                                    ExcelApp.Cells[i + 22, j + 1] = dgvApplication.Rows[i].Cells[j].Value;


                                }
                            }

                            ExcelApp.Columns.AutoFit();//автоширина столбцов(ВЫПОЛНЕНИЕ ДОЛЖНО БЫТЬ ПОСЛЕ ЗАПОЛНЕНИЯ СТОЛБЦОВ ДАННЫМИ!)
                            SaveFileDialog sfd = new SaveFileDialog();

                            sfd.Filter = "Word Documents (*.xlsx)|*.xlsx";

                            sfd.FileName = "Заявки_" + String.Format("{0:d}", DateTime.Now) + ".xlsx";


                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                ExcelWorkBook.SaveAs(sfd.FileName);
                                ExcelWorkBook.Close();
                                ExcelApp.Quit();

                            }
                            else
                            {
                                ExcelWorkBook.Close(0);
                                ExcelApp.Quit();

                            }
                        }
                    }
                    else
                    {
                        if (bsApplicationAgreedView.Count == 0)
                        {
                            MessageBox.Show("В архиве нет заявок для сохранения!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;

                        }

                        using (var db = new MyDataModelDataContext())
                        {
                            //посчитать количество определенных одинаковых данных
                            var firstColumnValuesDirector = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                         x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation.AddDays(-9) > new TimeSpan(24, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).GroupBy(x => x.DirectorStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDirector = firstColumnValuesDirector.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedDirector;
                            resultDirector.TryGetValue("Согласовано", out agreedDirector);
                            int considerationDirector;
                            resultDirector.TryGetValue("На рассмотрении", out considerationDirector);
                            int rejectedDirector;
                            resultDirector.TryGetValue("Отклонена", out rejectedDirector);


                            var firstColumnValuesEconomist = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                         x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation.AddDays(-9) > new TimeSpan(24, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).GroupBy(x => x.EconomistStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultEconomist = firstColumnValuesEconomist.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedEconomist;
                            resultEconomist.TryGetValue("Согласовано", out agreedEconomist);
                            int considerationEconomist;
                            resultEconomist.TryGetValue("На рассмотрении", out considerationEconomist);
                            int rejectedEconomist;
                            resultEconomist.TryGetValue("Отклонена", out rejectedEconomist);

                            var firstColumnValuesDepartment = db.ApplicationAgreedView.Where(x => ((x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                         x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation.AddDays(-9) > new TimeSpan(24, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))) && (x.IntercityСity != true || x.DaysWorkerOrWeekend != true)).GroupBy(x => x.DepartmentStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDepartment = firstColumnValuesDepartment.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedDepartment;
                            resultDepartment.TryGetValue("Согласовано", out agreedDepartment);
                            int considerationDepartment;
                            resultDepartment.TryGetValue("На рассмотрении", out considerationDepartment);
                            int rejectedDepartment;
                            resultDepartment.TryGetValue("Отклонена", out rejectedDepartment);

                            var firstColumnValuesDispatcherNIIARStatusDone = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                         x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation.AddDays(-9) > new TimeSpan(24, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).GroupBy(x => x.DispatcherNIIAR_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDispatcherNIIARStatusDone = firstColumnValuesDispatcherNIIARStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedDispatcherNIIARStatusDone;
                            resultDispatcherNIIARStatusDone.TryGetValue("Согласовано", out agreedDispatcherNIIARStatusDone);
                            int considerationDispatcherNIIARStatusDone;
                            resultDispatcherNIIARStatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIARStatusDone);
                            int rejectedDispatcherNIIARStatusDone;
                            resultDispatcherNIIARStatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIARStatusDone);

                            var firstColumnValuesDispatcherATAStatusDone = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                         x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation.AddDays(-9) > new TimeSpan(24, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).GroupBy(x => x.DispatcherATA_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDispatcherATAStatusDone = firstColumnValuesDispatcherATAStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int ExecutedDispatcherATAStatusDone;
                            resultDispatcherATAStatusDone.TryGetValue("Исполнено", out ExecutedDispatcherATAStatusDone);
                            int NotExecutedDispatcherATAStatusDone;
                            resultDispatcherATAStatusDone.TryGetValue("Не исполнено", out NotExecutedDispatcherATAStatusDone);
                            //посчитать количество определенных одинаковых данных
                            var firstColumnValuesSumm = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                         x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation.AddDays(-9) > new TimeSpan(24, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).Count();

                            ////минимальная/максимальная дата
                            var dateTimes = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                         x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation.AddDays(-9) > new TimeSpan(24, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).Select(x => x.DateCreation);
                            //var dateTimes = dgvApplicationAgreedView.Rows.Cast<DataGridViewRow>().Select(x => Convert.ToDateTime(x.Cells["dateCreationDataGridViewTextBoxColumn1"].Value));
                            var minValue = dateTimes.Min();
                            var maxValue = dateTimes.Max();
                            ////минимальная/максимальная дата



                            for (int i = 1; i < dgvApplicationAgreedView.Columns.Count + 1; i++)
                            {
                                ExcelApp.Cells[21, i].Font.Bold = true;//жирный шрифт
                                ExcelApp.Cells[21, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                ExcelApp.Cells[21, i].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            }
                            //цвет ячейки
                            ExcelApp.Cells[1, 1].Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);
                            ExcelApp.Cells[1, 2].Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);

                            ExcelApp.Cells[2, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[2, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[17, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[18, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[17, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[18, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[20, 1].Interior.Color = ColorTranslator.ToOle(Color.DarkGray);
                            //цвет ячейки


                            //строки вправо
                            for (int i = 1; i <= 18; i++)
                            {
                                ExcelApp.Cells[i, 2].HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            }
                            //строки вправо

                            ExcelApp.Cells[1, 2] = String.Format("{0:d} - {0:t}", minValue) + " — " + String.Format("{0:d} - {0:t}", maxValue);

                            ExcelApp.Cells[2, 1].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[2, 2].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[2, 1] = "Текущий статус";
                            ExcelApp.Cells[2, 2] = "Количество";
                            ExcelApp.Cells[3, 2] = considerationDirector;
                            ExcelApp.Cells[4, 2] = considerationEconomist;
                            ExcelApp.Cells[5, 2] = considerationDepartment;
                            ExcelApp.Cells[6, 2] = considerationDispatcherNIIARStatusDone;
                            ExcelApp.Cells[7, 2] = rejectedDirector;
                            ExcelApp.Cells[8, 2] = rejectedEconomist;
                            ExcelApp.Cells[9, 2] = rejectedDepartment;
                            ExcelApp.Cells[10, 2] = rejectedDispatcherNIIARStatusDone;
                            ExcelApp.Cells[11, 2] = agreedDirector;
                            ExcelApp.Cells[12, 2] = agreedEconomist;
                            ExcelApp.Cells[13, 2] = agreedDepartment;
                            ExcelApp.Cells[14, 2] = agreedDispatcherNIIARStatusDone;
                            ExcelApp.Cells[15, 2] = ExecutedDispatcherATAStatusDone;
                            ExcelApp.Cells[16, 2] = NotExecutedDispatcherATAStatusDone;
                            ExcelApp.Cells[17, 2].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[18, 2].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[17, 2] = firstColumnValuesSumm;
                            ExcelApp.Cells[18, 2] = String.Format("{0:d} - {0:t}", DateTime.Now);

                            ExcelApp.Cells[1, 1].Font.Bold = true;
                            ExcelApp.Cells[1, 2].Font.Bold = true;

                            //строки влево
                            for (int i = 1; i <= 18; i++)
                            {
                                ExcelApp.Cells[i, 1].HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            }
                            //строки влево
                            ExcelApp.Cells[1, 1].Font.Size = 16; //размер шрифта 
                            ExcelApp.Cells[1, 2].Font.Size = 16;
                            ExcelApp.Cells[20, 1] = "Архив заявок";
                            ExcelApp.Cells[20, 1].Font.Size = 16;
                            ExcelApp.Cells[20, 1].Font.Bold = true;
                            ExcelApp.Cells[1, 1] = "Отчёт по заявкам за период: ";
                            ExcelApp.Cells[3, 1] = "На рассмотрении у руководителей";
                            ExcelApp.Cells[4, 1] = "На рассмотрении у экономистов";
                            ExcelApp.Cells[5, 1] = "На рассмотрении у ДИД";
                            ExcelApp.Cells[6, 1] = "На рассмотрении у диспетчера НИИАР";
                            ExcelApp.Cells[7, 1] = "Отклонены руководителями";
                            ExcelApp.Cells[8, 1] = "Отклонены экономистами";
                            ExcelApp.Cells[9, 1] = "Отклонены ДИД";
                            ExcelApp.Cells[10, 1] = "Отклонены  диспетчером НИИАР";
                            ExcelApp.Cells[11, 1] = "Согласовано руководителями";
                            ExcelApp.Cells[12, 1] = "Согласовано экономистами";
                            ExcelApp.Cells[13, 1] = "Согласовано ДИД";
                            ExcelApp.Cells[14, 1] = "Согласовано диспетчером НИИАР";
                            ExcelApp.Cells[15, 1] = "Исполнено";
                            ExcelApp.Cells[16, 1] = "Не исполнено";
                            ExcelApp.Cells[17, 1].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[17, 1] = "Количество поступивших заявок";
                            ExcelApp.Cells[18, 1].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[18, 1] = "Дата оформления отчёта";



                            //Для названия столбцов из datagridview
                            for (int i = 1; i < dgvApplicationAgreedView.Columns.Count + 1; i++)
                            {
                                ExcelApp.Cells[21, i] = dgvApplicationAgreedView.Columns[i - 1].HeaderText;
                            }
                            //Для названия столбцов  datagridview



                            for (int i = 0; i < dgvApplicationAgreedView.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvApplicationAgreedView.ColumnCount; j++)
                                {
                                    ExcelApp.Cells[i + 22, j + 1] = dgvApplicationAgreedView.Rows[i].Cells[j].Value;


                                }
                            }

                            ExcelApp.Columns.AutoFit();//автоширина столбцов(ВЫПОЛНЕНИЕ ДОЛЖНО БЫТЬ ПОСЛЕ ЗАПОЛНЕНИЯ СТОЛБЦОВ ДАННЫМИ!)
                            SaveFileDialog sfd = new SaveFileDialog();

                            sfd.Filter = "Word Documents (*.xlsx)|*.xlsx";

                            sfd.FileName = "Архив заявок_" + String.Format("{0:d}", DateTime.Now) + ".xlsx";


                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                ExcelWorkBook.SaveAs(sfd.FileName);
                                ExcelWorkBook.Close();
                                ExcelApp.Quit();

                            }
                            else
                            {
                                ExcelWorkBook.Close(0);
                                ExcelApp.Quit();

                            }
                        }
                    }
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.Admin)
                {
                    if (cbArchiveApplications.Checked == false)
                    {
                        if (bsApplicationAgreedView.Count == 0)
                        {
                            MessageBox.Show("Нет актуальных заявок для сохранения!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;

                        }

                        using (var db = new MyDataModelDataContext())
                        {
                            //посчитать количество определенных одинаковых данных
                            var firstColumnValuesDirector = db.ApplicationAgreedView.Where(x => DateTime.Now - x.DateCreation.AddDays(-9) < new TimeSpan(24, 0, 0, 0) &&
                         ((x.DirectorStatusDone == "На рассмотрении" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении"))).GroupBy(x => x.DirectorStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDirector = firstColumnValuesDirector.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedDirector;
                            resultDirector.TryGetValue("Согласовано", out agreedDirector);
                            int considerationDirector;
                            resultDirector.TryGetValue("На рассмотрении", out considerationDirector);
                            int rejectedDirector;
                            resultDirector.TryGetValue("Отклонена", out rejectedDirector);


                            var firstColumnValuesEconomist = db.ApplicationAgreedView.Where(x => DateTime.Now - x.DateCreation.AddDays(-9) < new TimeSpan(24, 0, 0, 0) &&
                         ((x.DirectorStatusDone == "На рассмотрении" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении"))).GroupBy(x => x.EconomistStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultEconomist = firstColumnValuesEconomist.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedEconomist;
                            resultEconomist.TryGetValue("Согласовано", out agreedEconomist);
                            int considerationEconomist;
                            resultEconomist.TryGetValue("На рассмотрении", out considerationEconomist);
                            int rejectedEconomist;
                            resultEconomist.TryGetValue("Отклонена", out rejectedEconomist);

                            var firstColumnValuesDepartment = db.ApplicationAgreedView.Where(x => (DateTime.Now - x.DateCreation.AddDays(-9) < new TimeSpan(24, 0, 0, 0) &&
                         ((x.DirectorStatusDone == "На рассмотрении" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении"))) && (x.IntercityСity != true || x.DaysWorkerOrWeekend != true)).GroupBy(x => x.DepartmentStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDepartment = firstColumnValuesDepartment.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedDepartment;
                            resultDepartment.TryGetValue("Согласовано", out agreedDepartment);
                            int considerationDepartment;
                            resultDepartment.TryGetValue("На рассмотрении", out considerationDepartment);
                            int rejectedDepartment;
                            resultDepartment.TryGetValue("Отклонена", out rejectedDepartment);

                            var firstColumnValuesDispatcherNIIARStatusDone = db.ApplicationAgreedView.Where(x => DateTime.Now - x.DateCreation.AddDays(-9) < new TimeSpan(24, 0, 0, 0) &&
                         ((x.DirectorStatusDone == "На рассмотрении" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении"))).GroupBy(x => x.DispatcherNIIAR_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDispatcherNIIARStatusDone = firstColumnValuesDispatcherNIIARStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedDispatcherNIIARStatusDone;
                            resultDispatcherNIIARStatusDone.TryGetValue("Согласовано", out agreedDispatcherNIIARStatusDone);
                            int considerationDispatcherNIIARStatusDone;
                            resultDispatcherNIIARStatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIARStatusDone);
                            int rejectedDispatcherNIIARStatusDone;
                            resultDispatcherNIIARStatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIARStatusDone);

                            var firstColumnValuesDispatcherATAStatusDone = db.ApplicationAgreedView.Where(x => DateTime.Now - x.DateCreation.AddDays(-9) < new TimeSpan(24, 0, 0, 0) &&
                         ((x.DirectorStatusDone == "На рассмотрении" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении"))).GroupBy(x => x.DispatcherATA_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDispatcherATAStatusDone = firstColumnValuesDispatcherATAStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int ExecutedDispatcherATAStatusDone;
                            resultDispatcherATAStatusDone.TryGetValue("Исполнено", out ExecutedDispatcherATAStatusDone);
                            int NotExecutedDispatcherATAStatusDone;
                            resultDispatcherATAStatusDone.TryGetValue("Не исполнено", out NotExecutedDispatcherATAStatusDone);
                            //посчитать количество определенных одинаковых данных
                            var firstColumnValuesSumm = db.ApplicationAgreedView.Where(x => DateTime.Now - x.DateCreation.AddDays(-9) < new TimeSpan(24, 0, 0, 0) &&
                         ((x.DirectorStatusDone == "На рассмотрении" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении"))).Count();

                            ////минимальная/максимальная дата
                            var dateTimes = db.ApplicationAgreedView.Where(x => DateTime.Now - x.DateCreation.AddDays(-9) < new TimeSpan(24, 0, 0, 0) &&
                         ((x.DirectorStatusDone == "На рассмотрении" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "На рассмотрении" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "Согласовано" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении") ||
                         (x.DirectorStatusDone == "Согласовано" && x.EconomistStatusDone == "Согласовано" && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherNIIAR_StatusDone == "Согласовано" && x.DispatcherATA_StatusDone == "На рассмотрении"))).Select(x => x.DateCreation);
                            //var dateTimes = dgvApplicationAgreedView.Rows.Cast<DataGridViewRow>().Select(x => Convert.ToDateTime(x.Cells["dateCreationDataGridViewTextBoxColumn1"].Value));
                            var minValue = dateTimes.Min();
                            var maxValue = dateTimes.Max();
                            ////минимальная/максимальная дата



                            for (int i = 1; i < dgvApplicationAgreedView.Columns.Count + 1; i++)
                            {
                                ExcelApp.Cells[21, i].Font.Bold = true;//жирный шрифт
                                ExcelApp.Cells[21, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                ExcelApp.Cells[21, i].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            }
                            //цвет ячейки
                            ExcelApp.Cells[1, 1].Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);
                            ExcelApp.Cells[1, 2].Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);

                            ExcelApp.Cells[2, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[2, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[17, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[18, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[17, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[18, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[20, 1].Interior.Color = ColorTranslator.ToOle(Color.DarkGray);
                            //цвет ячейки


                            //строки вправо
                            for (int i = 1; i <= 18; i++)
                            {
                                ExcelApp.Cells[i, 2].HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            }
                            //строки вправо

                            ExcelApp.Cells[1, 2] = String.Format("{0:d} - {0:t}", minValue) + " — " + String.Format("{0:d} - {0:t}", maxValue);

                            ExcelApp.Cells[2, 1].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[2, 2].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[2, 1] = "Текущий статус";
                            ExcelApp.Cells[2, 2] = "Количество";
                            ExcelApp.Cells[3, 2] = considerationDirector;
                            ExcelApp.Cells[4, 2] = considerationEconomist;
                            ExcelApp.Cells[5, 2] = considerationDepartment;
                            ExcelApp.Cells[6, 2] = considerationDispatcherNIIARStatusDone;
                            ExcelApp.Cells[7, 2] = rejectedDirector;
                            ExcelApp.Cells[8, 2] = rejectedEconomist;
                            ExcelApp.Cells[9, 2] = rejectedDepartment;
                            ExcelApp.Cells[10, 2] = rejectedDispatcherNIIARStatusDone;
                            ExcelApp.Cells[11, 2] = agreedDirector;
                            ExcelApp.Cells[12, 2] = agreedEconomist;
                            ExcelApp.Cells[13, 2] = agreedDepartment;
                            ExcelApp.Cells[14, 2] = agreedDispatcherNIIARStatusDone;
                            ExcelApp.Cells[15, 2] = ExecutedDispatcherATAStatusDone;
                            ExcelApp.Cells[16, 2] = NotExecutedDispatcherATAStatusDone;
                            ExcelApp.Cells[17, 2].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[18, 2].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[17, 2] = firstColumnValuesSumm;
                            ExcelApp.Cells[18, 2] = String.Format("{0:d} - {0:t}", DateTime.Now);

                            ExcelApp.Cells[1, 1].Font.Bold = true;
                            ExcelApp.Cells[1, 2].Font.Bold = true;

                            //строки влево
                            for (int i = 1; i <= 18; i++)
                            {
                                ExcelApp.Cells[i, 1].HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            }
                            //строки влево
                            ExcelApp.Cells[1, 1].Font.Size = 16; //размер шрифта 
                            ExcelApp.Cells[1, 2].Font.Size = 16;
                            ExcelApp.Cells[20, 1] = "Заявки";
                            ExcelApp.Cells[20, 1].Font.Size = 16;
                            ExcelApp.Cells[20, 1].Font.Bold = true;
                            ExcelApp.Cells[1, 1] = "Отчёт по заявкам за период: ";
                            ExcelApp.Cells[3, 1] = "На рассмотрении у руководителей";
                            ExcelApp.Cells[4, 1] = "На рассмотрении у экономистов";
                            ExcelApp.Cells[5, 1] = "На рассмотрении у ДИД";
                            ExcelApp.Cells[6, 1] = "На рассмотрении у диспетчера НИИАР";
                            ExcelApp.Cells[7, 1] = "Отклонены руководителями";
                            ExcelApp.Cells[8, 1] = "Отклонены экономистами";
                            ExcelApp.Cells[9, 1] = "Отклонены ДИД";
                            ExcelApp.Cells[10, 1] = "Отклонены  диспетчером НИИАР";
                            ExcelApp.Cells[11, 1] = "Согласовано руководителями";
                            ExcelApp.Cells[12, 1] = "Согласовано экономистами";
                            ExcelApp.Cells[13, 1] = "Согласовано ДИД";
                            ExcelApp.Cells[14, 1] = "Согласовано диспетчером НИИАР";
                            ExcelApp.Cells[15, 1] = "Исполнено";
                            ExcelApp.Cells[16, 1] = "Не исполнено";
                            ExcelApp.Cells[17, 1].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[17, 1] = "Количество поступивших заявок";
                            ExcelApp.Cells[18, 1].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[18, 1] = "Дата оформления отчёта";

                            //Для названия столбцов из datagridview
                            for (int i = 1; i < dgvApplicationAgreedView.Columns.Count + 1; i++)
                            {
                                ExcelApp.Cells[21, i] = dgvApplicationAgreedView.Columns[i - 1].HeaderText;
                            }
                            //Для названия столбцов  datagridview



                            for (int i = 0; i < dgvApplicationAgreedView.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvApplicationAgreedView.ColumnCount; j++)
                                {
                                    ExcelApp.Cells[i + 22, j + 1] = dgvApplicationAgreedView.Rows[i].Cells[j].Value;


                                }
                            }

                            ExcelApp.Columns.AutoFit();//автоширина столбцов(ВЫПОЛНЕНИЕ ДОЛЖНО БЫТЬ ПОСЛЕ ЗАПОЛНЕНИЯ СТОЛБЦОВ ДАННЫМИ!)
                            SaveFileDialog sfd = new SaveFileDialog();

                            sfd.Filter = "Word Documents (*.xlsx)|*.xlsx";

                            sfd.FileName = "Заявки_" + String.Format("{0:d}", DateTime.Now) + ".xlsx";


                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                ExcelWorkBook.SaveAs(sfd.FileName);
                                ExcelWorkBook.Close();
                                ExcelApp.Quit();

                            }
                            else
                            {
                                ExcelWorkBook.Close(0);
                                ExcelApp.Quit();

                            }
                        }
                    }
                    else
                    {
                        if (bsApplicationAgreedView.Count == 0)
                        {
                            MessageBox.Show("В архиве нет заявок для сохранения!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        using (var db = new MyDataModelDataContext())
                        {
                            //посчитать количество определенных одинаковых данных
                            var firstColumnValuesDirector = db.ApplicationAgreedView.Where(x => DateTime.Now - x.DateCreation.AddDays(-9) > new TimeSpan(24, 0, 0, 0) || ((x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && (x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                          x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена"))).GroupBy(x => x.DirectorStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDirector = firstColumnValuesDirector.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedDirector;
                            resultDirector.TryGetValue("Согласовано", out agreedDirector);
                            int considerationDirector;
                            resultDirector.TryGetValue("На рассмотрении", out considerationDirector);
                            int rejectedDirector;
                            resultDirector.TryGetValue("Отклонена", out rejectedDirector);


                            var firstColumnValuesEconomist = db.ApplicationAgreedView.Where(x => DateTime.Now - x.DateCreation.AddDays(-9) > new TimeSpan(24, 0, 0, 0) || ((x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && (x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                          x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена"))).GroupBy(x => x.EconomistStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultEconomist = firstColumnValuesEconomist.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedEconomist;
                            resultEconomist.TryGetValue("Согласовано", out agreedEconomist);
                            int considerationEconomist;
                            resultEconomist.TryGetValue("На рассмотрении", out considerationEconomist);
                            int rejectedEconomist;
                            resultEconomist.TryGetValue("Отклонена", out rejectedEconomist);

                            var firstColumnValuesDepartment = db.ApplicationAgreedView.Where(x => (DateTime.Now - x.DateCreation.AddDays(-9) > new TimeSpan(24, 0, 0, 0) || ((x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && (x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                          x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена"))) && (x.IntercityСity != true || x.DaysWorkerOrWeekend != true)).GroupBy(x => x.DepartmentStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDepartment = firstColumnValuesDepartment.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedDepartment;
                            resultDepartment.TryGetValue("Согласовано", out agreedDepartment);
                            int considerationDepartment;
                            resultDepartment.TryGetValue("На рассмотрении", out considerationDepartment);
                            int rejectedDepartment;
                            resultDepartment.TryGetValue("Отклонена", out rejectedDepartment);

                            var firstColumnValuesDispatcherNIIARStatusDone = db.ApplicationAgreedView.Where(x => DateTime.Now - x.DateCreation.AddDays(-9) > new TimeSpan(24, 0, 0, 0) || ((x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && (x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                          x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена"))).GroupBy(x => x.DispatcherNIIAR_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDispatcherNIIARStatusDone = firstColumnValuesDispatcherNIIARStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int agreedDispatcherNIIARStatusDone;
                            resultDispatcherNIIARStatusDone.TryGetValue("Согласовано", out agreedDispatcherNIIARStatusDone);
                            int considerationDispatcherNIIARStatusDone;
                            resultDispatcherNIIARStatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIARStatusDone);
                            int rejectedDispatcherNIIARStatusDone;
                            resultDispatcherNIIARStatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIARStatusDone);

                            var firstColumnValuesDispatcherATAStatusDone = db.ApplicationAgreedView.Where(x => DateTime.Now - x.DateCreation.AddDays(-9) > new TimeSpan(24, 0, 0, 0) || ((x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && (x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                          x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена"))).GroupBy(x => x.DispatcherATA_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                            Dictionary<string, int> resultDispatcherATAStatusDone = firstColumnValuesDispatcherATAStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                            int ExecutedDispatcherATAStatusDone;
                            resultDispatcherATAStatusDone.TryGetValue("Исполнено", out ExecutedDispatcherATAStatusDone);
                            int NotExecutedDispatcherATAStatusDone;
                            resultDispatcherATAStatusDone.TryGetValue("Не исполнено", out NotExecutedDispatcherATAStatusDone);
                            //посчитать количество определенных одинаковых данных
                            var firstColumnValuesSumm = db.ApplicationAgreedView.Where(x => DateTime.Now - x.DateCreation.AddDays(-9) > new TimeSpan(24, 0, 0, 0) || ((x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && (x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                          x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена"))).Count();

                            ////минимальная/максимальная дата
                            var dateTimes = db.ApplicationAgreedView.Where(x => DateTime.Now - x.DateCreation.AddDays(-9) > new TimeSpan(24, 0, 0, 0) || ((x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && (x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                          x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена"))).Select(x => x.DateCreation);
                            //var dateTimes = dgvApplicationAgreedView.Rows.Cast<DataGridViewRow>().Select(x => Convert.ToDateTime(x.Cells["dateCreationDataGridViewTextBoxColumn1"].Value));
                            var minValue = dateTimes.Min();
                            var maxValue = dateTimes.Max();
                            ////минимальная/максимальная дата



                            for (int i = 1; i < dgvApplicationAgreedView.Columns.Count + 1; i++)
                            {
                                ExcelApp.Cells[21, i].Font.Bold = true;//жирный шрифт
                                ExcelApp.Cells[21, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                ExcelApp.Cells[21, i].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            }
                            //цвет ячейки
                            ExcelApp.Cells[1, 1].Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);
                            ExcelApp.Cells[1, 2].Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);

                            ExcelApp.Cells[2, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[2, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[17, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[18, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[17, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[18, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                            ExcelApp.Cells[20, 1].Interior.Color = ColorTranslator.ToOle(Color.DarkGray);
                            //цвет ячейки


                            //строки вправо
                            for (int i = 1; i <= 18; i++)
                            {
                                ExcelApp.Cells[i, 2].HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            }
                            //строки вправо

                            ExcelApp.Cells[1, 2] = String.Format("{0:d} - {0:t}", minValue) + " — " + String.Format("{0:d} - {0:t}", maxValue);

                            ExcelApp.Cells[2, 1].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[2, 2].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[2, 1] = "Текущий статус";
                            ExcelApp.Cells[2, 2] = "Количество";
                            ExcelApp.Cells[3, 2] = considerationDirector;
                            ExcelApp.Cells[4, 2] = considerationEconomist;
                            ExcelApp.Cells[5, 2] = considerationDepartment;
                            ExcelApp.Cells[6, 2] = considerationDispatcherNIIARStatusDone;
                            ExcelApp.Cells[7, 2] = rejectedDirector;
                            ExcelApp.Cells[8, 2] = rejectedEconomist;
                            ExcelApp.Cells[9, 2] = rejectedDepartment;
                            ExcelApp.Cells[10, 2] = rejectedDispatcherNIIARStatusDone;
                            ExcelApp.Cells[11, 2] = agreedDirector;
                            ExcelApp.Cells[12, 2] = agreedEconomist;
                            ExcelApp.Cells[13, 2] = agreedDepartment;
                            ExcelApp.Cells[14, 2] = agreedDispatcherNIIARStatusDone;
                            ExcelApp.Cells[15, 2] = ExecutedDispatcherATAStatusDone;
                            ExcelApp.Cells[16, 2] = NotExecutedDispatcherATAStatusDone;
                            ExcelApp.Cells[17, 2].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[18, 2].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[17, 2] = firstColumnValuesSumm;
                            ExcelApp.Cells[18, 2] = String.Format("{0:d} - {0:t}", DateTime.Now);

                            ExcelApp.Cells[1, 1].Font.Bold = true;
                            ExcelApp.Cells[1, 2].Font.Bold = true;

                            //строки влево
                            for (int i = 1; i <= 18; i++)
                            {
                                ExcelApp.Cells[i, 1].HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            }
                            //строки влево
                            ExcelApp.Cells[1, 1].Font.Size = 16; //размер шрифта 
                            ExcelApp.Cells[1, 2].Font.Size = 16;
                            ExcelApp.Cells[20, 1] = "Архив заявок";
                            ExcelApp.Cells[20, 1].Font.Size = 16;
                            ExcelApp.Cells[20, 1].Font.Bold = true;
                            ExcelApp.Cells[1, 1] = "Отчёт по заявкам за период: ";
                            ExcelApp.Cells[3, 1] = "На рассмотрении у руководителей";
                            ExcelApp.Cells[4, 1] = "На рассмотрении у экономистов";
                            ExcelApp.Cells[5, 1] = "На рассмотрении у ДИД";
                            ExcelApp.Cells[6, 1] = "На рассмотрении у диспетчера НИИАР";
                            ExcelApp.Cells[7, 1] = "Отклонены руководителями";
                            ExcelApp.Cells[8, 1] = "Отклонены экономистами";
                            ExcelApp.Cells[9, 1] = "Отклонены ДИД";
                            ExcelApp.Cells[10, 1] = "Отклонены  диспетчером НИИАР";
                            ExcelApp.Cells[11, 1] = "Согласовано руководителями";
                            ExcelApp.Cells[12, 1] = "Согласовано экономистами";
                            ExcelApp.Cells[13, 1] = "Согласовано ДИД";
                            ExcelApp.Cells[14, 1] = "Согласовано диспетчером НИИАР";
                            ExcelApp.Cells[15, 1] = "Исполнено";
                            ExcelApp.Cells[16, 1] = "Не исполнено";
                            ExcelApp.Cells[17, 1].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[17, 1] = "Количество поступивших заявок";
                            ExcelApp.Cells[18, 1].Font.Bold = true;//жирный шрифт
                            ExcelApp.Cells[18, 1] = "Дата оформления отчёта";



                            //Для названия столбцов из datagridview
                            for (int i = 1; i < dgvApplicationAgreedView.Columns.Count + 1; i++)
                            {
                                ExcelApp.Cells[21, i] = dgvApplicationAgreedView.Columns[i - 1].HeaderText;
                            }
                            //Для названия столбцов  datagridview



                            for (int i = 0; i < dgvApplicationAgreedView.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvApplicationAgreedView.ColumnCount; j++)
                                {
                                    ExcelApp.Cells[i + 22, j + 1] = dgvApplicationAgreedView.Rows[i].Cells[j].Value;


                                }
                            }

                            ExcelApp.Columns.AutoFit();//автоширина столбцов(ВЫПОЛНЕНИЕ ДОЛЖНО БЫТЬ ПОСЛЕ ЗАПОЛНЕНИЯ СТОЛБЦОВ ДАННЫМИ!)
                            SaveFileDialog sfd = new SaveFileDialog();

                            sfd.Filter = "Word Documents (*.xlsx)|*.xlsx";

                            sfd.FileName = "Архив заявок_" + String.Format("{0:d}", DateTime.Now) + ".xlsx";


                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                ExcelWorkBook.SaveAs(sfd.FileName);
                                ExcelWorkBook.Close();
                                ExcelApp.Quit();

                            }
                            else
                            {
                                ExcelWorkBook.Close(0);
                                ExcelApp.Quit();

                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //Вызываем нашу созданную эксельку.
            //ExcelApp.Visible = false;
            //ExcelApp.UserControl = false;
        }
        //Excel

        //отчёт FastReport
        private void tsbReport_Click(object sender, EventArgs e)
        {

            TypesReportForm form = new TypesReportForm();
            form.ShowDialog();

            //if (bsApplicationAgreedView.Count != 0 && GeneralClass.mode == (int)GeneralClass.Status.Admin)
            //{
            //    var firstColumnValuesDirector =
            //            from DataGridViewRow row in dgvApplicationAgreedView.Rows
            //            group row by row.Cells["directorStatusDoneDataGridViewTextBoxColumn1"].Value into res
            //            where res.Key != null
            //            select new { res.Key, Count = res.Count() };

            //    Dictionary<object, int> resultDirector = firstColumnValuesDirector.ToDictionary(arg => arg.Key, arg => arg.Count);

            //    int agreedDirector;
            //    resultDirector.TryGetValue("Согласовано", out agreedDirector);

            //    int considerationDirector;
            //    resultDirector.TryGetValue("На рассмотрении", out considerationDirector);
            //    int rejectedDirector;
            //    resultDirector.TryGetValue("Отклонена", out rejectedDirector);



            //    var firstColumnValuesEconomist =
            //      from DataGridViewRow row in dgvApplicationAgreedView.Rows
            //      group row by row.Cells["economistStatusDoneDataGridViewTextBoxColumn1"].Value into res
            //      where res.Key != null
            //      select new { res.Key, Count = res.Count() };

            //    Dictionary<object, int> resultEconomist = firstColumnValuesEconomist.ToDictionary(arg => arg.Key, arg => arg.Count);

            //    int agreedEconomist;
            //    resultEconomist.TryGetValue("Согласовано", out agreedEconomist);
            //    int considerationEconomist;
            //    resultEconomist.TryGetValue("На рассмотрении", out considerationEconomist);
            //    int rejectedEconomist;
            //    resultEconomist.TryGetValue("Отклонена", out rejectedEconomist);

            //    var firstColumnValuesDepartment =
            //         from DataGridViewRow row in dgvApplicationAgreedView.Rows
            //         group row by row.Cells["departmentStatusDoneDataGridViewTextBoxColumn1"].Value into res
            //         where res.Key != null
            //         select new { res.Key, Count = res.Count() };

            //    Dictionary<object, int> resultDepartment = firstColumnValuesDepartment.ToDictionary(arg => arg.Key, arg => arg.Count);

            //    int agreedDepartment;
            //    resultDepartment.TryGetValue("Согласовано", out agreedDepartment);
            //    int considerationDepartment;
            //    resultDepartment.TryGetValue("На рассмотрении", out considerationDepartment);
            //    int rejectedDepartment;
            //    resultDepartment.TryGetValue("Отклонена", out rejectedDepartment);

            //    var firstColumnValuesDispatcherNIIAR_StatusDone =
            //     from DataGridViewRow row in dgvApplicationAgreedView.Rows
            //     group row by row.Cells["dispatcherNIIARStatusDoneDataGridViewTextBoxColumn1"].Value into res
            //     where res.Key != null
            //     select new { res.Key, Count = res.Count() };

            //    Dictionary<object, int> resultDispatcherNIIAR_StatusDone = firstColumnValuesDispatcherNIIAR_StatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

            //    int agreedDispatcherNIIAR_StatusDone;
            //    resultDispatcherNIIAR_StatusDone.TryGetValue("Согласовано", out agreedDispatcherNIIAR_StatusDone);
            //    int considerationDispatcherNIIAR_StatusDone;
            //    resultDispatcherNIIAR_StatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIAR_StatusDone);
            //    int rejectedDispatcherNIIAR_StatusDone;
            //    resultDispatcherNIIAR_StatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIAR_StatusDone);

            //    var firstColumnValuesDispatcherATA_StatusDone =
            //     from DataGridViewRow row in dgvApplicationAgreedView.Rows
            //     group row by row.Cells["dispatcherATAStatusDoneDataGridViewTextBoxColumn1"].Value into res
            //     where res.Key != null
            //     select new { res.Key, Count = res.Count() };

            //    Dictionary<object, int> resultDispatcherATA_StatusDone = firstColumnValuesDispatcherATA_StatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

            //    int ExecutedDispatcherATA_StatusDone;
            //    resultDispatcherATA_StatusDone.TryGetValue("Исполнено", out ExecutedDispatcherATA_StatusDone);
            //    int NotExecutedDispatcherATA_StatusDone;
            //    resultDispatcherATA_StatusDone.TryGetValue("Не исполнено", out NotExecutedDispatcherATA_StatusDone);

            //    //минимальная/максимальная дата
            //    var dateTimes = dgvApplicationAgreedView.Rows.Cast<DataGridViewRow>().Select(x => Convert.ToDateTime(x.Cells["dateCreationDataGridViewTextBoxColumn1"].Value));
            //    var minValue = dateTimes.Min();
            //    var maxValue = dateTimes.Max();
            //    //минимальная/максимальная дата


            //    report.Load(@"Reports\ApplicationReport.frx");


            //    report.SetParameterValue("dateTimesPeriod", String.Format("{0:d} - {0:t}", minValue) + " — " + String.Format("{0:d} - {0:t}", maxValue));
            //    report.SetParameterValue("dateCreation", String.Format("{0:d} - {0:t}", DateTime.Now));

            //    report.SetParameterValue("considerationDirector", considerationDirector);
            //    report.SetParameterValue("considerationEconomist", considerationEconomist);
            //    report.SetParameterValue("considerationDepartment", considerationDepartment);
            //    report.SetParameterValue("considerationDispatcherNIIAR", considerationDispatcherNIIAR_StatusDone);
            //    report.SetParameterValue("rejectedDirector", rejectedDirector);
            //    report.SetParameterValue("rejectedEconomist", rejectedEconomist);
            //    report.SetParameterValue("rejectedDepartment", rejectedDepartment);
            //    report.SetParameterValue("rejectedDispatcherNIIAR", rejectedDispatcherNIIAR_StatusDone);
            //    report.SetParameterValue("agreedDirector", agreedDirector);
            //    report.SetParameterValue("agreedEconomist", agreedEconomist);
            //    report.SetParameterValue("agreedDepartment", agreedDepartment);
            //    report.SetParameterValue("agreedDispatcherNIIAR", agreedDispatcherNIIAR_StatusDone);

            //    report.SetParameterValue("executedDispatcherATA", ExecutedDispatcherATA_StatusDone);
            //    report.SetParameterValue("notExecutedDispatcherAT", NotExecutedDispatcherATA_StatusDone);

            //    report.SetParameterValue("totalApplications", dgvApplicationAgreedView.RowCount);

            //    //report.SetParameterValue("totalApplications", dgvApplicationAgreedView.RowCount);


            //    report.Show();
            //}
        }
        //отчёт FastReport



        //Поиск
        private void cbSearchApplications_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tsmiAllApplications.Text = "Найденные заявки";
            if (mtbSearchApplications.Text == "" || mtbSearchApplications.Text != null)
            {
                mtbSearchApplications.Text = "Поиск...";
                mtbSearchApplications.ForeColor = Color.Silver;
            }
            cbStatus.Text = null;

            dtpSearchApplications.Value = DateTime.Now;



            if (cbSearchApplications.SelectedIndex == 1)
            {
                dtpSearchApplications.Visible = true;
                mtbSearchApplications.Text = null;
                if (bsApplicationsView.Count == 0)
                {
                    lSelectRequest.Text = "Заявок нет";
                    BlankPage();
                }
                else
                {
                    lSelectRequest.Text = "Выберите заявку";

                }
            }
            else
            {
                dtpSearchApplications.Visible = false;
            }

            if (cbSearchApplications.SelectedIndex == 8 || cbSearchApplications.SelectedIndex == 9)
            {

                if (cbSearchApplications.SelectedIndex == 9)
                {
                    mtbSearchApplications.ForeColor = Color.Black;
                    mtbSearchApplications.Mask = "+7(999)000-00-00";
                }
                else
                {
                    mtbSearchApplications.ForeColor = Color.Black;

                    mtbSearchApplications.Mask = "+7(999-99)0-00-00";
                }
            }
            else
            {
                mtbSearchApplications.Mask = null;
            }

            if (cbSearchApplications.SelectedIndex == 12 || cbSearchApplications.SelectedIndex == 13 ||
                cbSearchApplications.SelectedIndex == 14 || cbSearchApplications.SelectedIndex == 15)
            {
                cbStatus.Items.Clear();
                cbStatus.Items.Add("Согласовано");
                cbStatus.Items.Add("Отклонена");
                cbStatus.Items.Add("На рассмотрении");
                cbStatus.Visible = true;
                cbStatus.SelectedIndex = 0;
                cbSortModeApplications.Enabled = false;
            }
            else
            {
                cbSortModeApplications.Enabled = true;
                cbStatus.Visible = false;

            }

            if (cbSearchApplications.SelectedIndex == 16)
            {
                cbStatus.Items.Clear();
                cbStatus.Items.Add("Исполнено");
                cbStatus.Items.Add("Не исполнено");
                cbSortModeApplications.Enabled = false;
                cbStatus.Visible = true;
                cbStatus.SelectedIndex = 0;
            }

            NotApplicationAndChoose();

            cbSortModeApplications_SelectedIndexChanged(sender, e);
            dtpSearchApplications_ValueChanged(sender, e);
            cbStatus_SelectedIndexChanged(sender, e);
        }

        public void NotApplicationAndChoose()
        {
            if (bsApplicationAgreedView.Count == 0 && GeneralClass.mode == (int)GeneralClass.Status.Admin)
            {
                lSelectRequest.Visible = true;

                lSelectRequest.Text = "Заявок нет";
                pTransport.Visible = false;
                BlankPage();
                pInformation.Height = 844;
                pDetails.Height = 757;
            }
            else
            {
                lSelectRequest.Visible = true;
                lSelectRequest.Text = "Выберите заявку";
                pTransport.Visible = false;
                BlankPage();
                pInformation.Height = 844;
                pDetails.Height = 757;
            }

            if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA && cbArchiveApplications.Checked == true)
            {
                if (bsApplicationAgreedView.Count == 0)
                {
                    lSelectRequest.Visible = true;
                    lSelectRequest.Text = "Заявок нет";
                    pTransport.Visible = false;
                    BlankPage();
                    pInformation.Height = 844;
                    pDetails.Height = 757;
                }
                else
                {
                    lSelectRequest.Visible = true;
                    lSelectRequest.Text = "Выберите заявку";
                    pTransport.Visible = false;
                    BlankPage();
                    pInformation.Height = 844;
                    pDetails.Height = 757;
                }

            }

            if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA && cbArchiveApplications.Checked == false)
            {
                if (bsApplicationsView.Count == 0)
                {
                    lSelectRequest.Visible = true;
                    lSelectRequest.Text = "Заявок нет";
                    pTransport.Visible = false;
                    BlankPage();
                    pInformation.Height = 844;
                    pDetails.Height = 757;
                }
                else
                {
                    lSelectRequest.Visible = true;
                    lSelectRequest.Text = "Выберите заявку";
                    pTransport.Visible = false;
                    BlankPage();
                    pInformation.Height = 844;
                    pDetails.Height = 757;
                }

            }
        }

        private void dtpSearchApplications_ValueChanged(object sender, EventArgs e)
        {
            if (cbSearchApplications.SelectedIndex == 1)
            {
                using (var db = new MyDataModelDataContext())
                {
                    if (GeneralClass.mode == (int)GeneralClass.Status.Admin)
                    {

                        bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.DateCreation.Date == dtpSearchApplications.Value.Date);


                    }

                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA && cbArchiveApplications.Checked == true)
                    {
                        bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.DateCreation.Date == dtpSearchApplications.Value.Date && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                        x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));



                    }

                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA && cbArchiveApplications.Checked == false)
                    {
                        bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.DateCreation.Date == dtpSearchApplications.Value.Date && (
                       (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone != "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении") && (x.EconomistStatusDone != "На рассмотрении") &&
                       (x.DispatcherNIIAR_StatusDone != "На рассмотрении")
                        && (x.DepartmentStatusDone == "На рассмотрении") && x.DispatcherATA_StatusDone == "На рассмотрении");

                    }

                }

            }
            if (cbSearchApplications.SelectedIndex != 8 || cbSearchApplications.SelectedIndex != 9)
            {
                mtbSearchApplications.ForeColor = Color.Silver;
                mtbSearchApplications.Text = "Поиск...";
                if (mtbSearchApplications.Text != "Поиск...")
                {
                    mtbSearchApplications.ForeColor = Color.Black;
                }
            }


            NotApplicationAndChoose();
            //cbSortModeApplications_SelectedIndexChanged(sender, e);
        }

        private void UpdateDataGridView()
        {
            //var source = new BindingSource { DataSource = bsApplicationAgreedView };
            using (MyDataModelDataContext db = new MyDataModelDataContext())
            {
                if (GeneralClass.mode == (int)GeneralClass.Status.Admin || GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                {

                    bsApplicationAgreedView.DataSource = db.ApplicationAgreedView;

                }
                else
                {
                    bsApplicationsView.DataSource = db.ApplicationView;
                }
            }


        }


        private void mtbSearchApplications_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtbSearchApplications.Text))
            {
                NotApplicationAndChoose();
                if (GeneralClass.mode == (int)GeneralClass.Status.Admin)
                {
                    bsApplicationAgreedView.DataSource = null;
                    bsApplicationsView.DataSource = null;
                }

                if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA && cbArchiveApplications.Checked == false)
                {
                    btnDeclineApplication.Enabled = false;
                    btnTakeApplication.Enabled = false;
                    pTransport.Visible = false;
                    //bsApplicationsView.DataSource = null;

                    //bsApplicationAgreedView.DataSource = null;
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA && cbArchiveApplications.Checked == true)

                {
                    pTransport.Visible = false;
                    //bsApplicationAgreedView.DataSource = null;

                    //bsApplicationsView.DataSource = null;
                }
                //dgvApplicationAgreedView.DataBindings.Clear();



                //lSelectRequest.Text = "Заявок нет";
                //lSelectRequest.Visible = true;
                //BlankPage();
                //NotApplicationAndChoose();
            }
            else
            {
                UpdateDataGridView();
                if (GeneralClass.mode == (int)GeneralClass.Status.Admin)
                {

                    using (var db = new MyDataModelDataContext())
                    {

                        if (cbSearchApplications.SelectedIndex == 0)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => Convert.ToString(x.Id).ToUpper().Contains(mtbSearchApplications.Text.ToUpper()));

                        }


                        if (cbSearchApplications.SelectedIndex == 2)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Client.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()));

                        }
                        if (cbSearchApplications.SelectedIndex == 3)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Email.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()));

                        }
                        if (cbSearchApplications.SelectedIndex == 4)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Post.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()));

                        }


                        if (cbSearchApplications.SelectedIndex == 5)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Division.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()));


                        }
                        if (cbSearchApplications.SelectedIndex == 6)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Building.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()));


                        }
                        if (cbSearchApplications.SelectedIndex == 7)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Room.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper()));


                        }
                        if (cbSearchApplications.SelectedIndex == 8)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.WorkPhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()));


                        }
                        if (cbSearchApplications.SelectedIndex == 9)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.MobilePhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()));


                        }
                        if (cbSearchApplications.SelectedIndex == 10)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Director.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()));


                        }
                        if (cbSearchApplications.SelectedIndex == 11)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Economist.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()));

                        }
                    }

                }
                if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA && pFilters.Visible == true)
                {


                    using (var db = new MyDataModelDataContext())
                    {
                        if (cbArchiveApplications.Checked == true)
                        {

                            if (cbSearchApplications.SelectedIndex == 0)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Id.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                         x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                            }


                            if (cbSearchApplications.SelectedIndex == 2)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Client.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                        x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));


                            }
                            if (cbSearchApplications.SelectedIndex == 3)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Email.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                        x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                            }
                            if (cbSearchApplications.SelectedIndex == 4)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Post.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                        x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                            }


                            if (cbSearchApplications.SelectedIndex == 5)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Division.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                        x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                            }
                            if (cbSearchApplications.SelectedIndex == 6)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Building.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                        x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                            }
                            if (cbSearchApplications.SelectedIndex == 7)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Room.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                        x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                            }
                            if (cbSearchApplications.SelectedIndex == 8)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.WorkPhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                        x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                            }
                            if (cbSearchApplications.SelectedIndex == 9)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.MobilePhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                        x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                            }
                            if (cbSearchApplications.SelectedIndex == 10)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Director.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                        x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                            }
                            if (cbSearchApplications.SelectedIndex == 11)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Economist.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                        x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                            }
                        }
                        else
                        {
                            if (cbSearchApplications.SelectedIndex == 0)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Id.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));

                            }


                            if (cbSearchApplications.SelectedIndex == 2)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Client.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                            }
                            if (cbSearchApplications.SelectedIndex == 3)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Email.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                            }
                            if (cbSearchApplications.SelectedIndex == 4)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Post.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                            }


                            if (cbSearchApplications.SelectedIndex == 5)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Division.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                            }
                            if (cbSearchApplications.SelectedIndex == 6)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Building.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                            }
                            if (cbSearchApplications.SelectedIndex == 7)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Room.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                            }
                            if (cbSearchApplications.SelectedIndex == 8)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.WorkPhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                            }
                            if (cbSearchApplications.SelectedIndex == 9)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.MobilePhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                            }
                            if (cbSearchApplications.SelectedIndex == 10)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Director.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                            }
                            if (cbSearchApplications.SelectedIndex == 11)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Economist.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                            }
                        }


                    }

                }

                //tsmiAllApplications.Text = "Найденные заявки";

                NotApplicationAndChoose();
            }
            cbSortModeApplications_SelectedIndexChanged(sender, e);

        }
        private void mtbSearchApplications_Enter(object sender, EventArgs e)
        {
            if (mtbSearchApplications.Text == "Поиск...")
            {
                mtbSearchApplications.Text = "";
                mtbSearchApplications.ForeColor = Color.Black;
                tsmiAllApplications.Text = "Найденные заявки";
                BlankPage();
            }
        }

        private void mtbSearchApplications_Leave(object sender, EventArgs e)
        {
            if (mtbSearchApplications.Text == "")
            {
                mtbSearchApplications.Text = "Поиск...";
                mtbSearchApplications.ForeColor = Color.Silver;
            }
        }
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new MyDataModelDataContext())
            {
                if (GeneralClass.mode == (int)GeneralClass.Status.Admin)
                {
                    if (cbSearchApplications.SelectedIndex == 12)
                    {

                        bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.DirectorStatusDone.ToUpper().Contains(cbStatus.Text.ToUpper()));


                    }
                    if (cbSearchApplications.SelectedIndex == 13)
                    {

                        bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.EconomistStatusDone.ToUpper().Contains(cbStatus.Text.ToUpper()));


                    }
                    if (cbSearchApplications.SelectedIndex == 14)
                    {
                        bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.DepartmentStatusDone.ToUpper().Contains(cbStatus.Text.ToUpper()));


                    }
                    if (cbSearchApplications.SelectedIndex == 15)
                    {

                        bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.DispatcherNIIAR_StatusDone.ToUpper().Contains(cbStatus.Text.ToUpper()));

                    }
                    if (cbSearchApplications.SelectedIndex == 16)
                    {

                        bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.DispatcherATA_StatusDone == cbStatus.Text);

                    }
                }



                if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA && pFilters.Visible == true)
                {
                    if (cbArchiveApplications.Checked == true)
                    {

                        if (cbSearchApplications.SelectedIndex == 12)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.DirectorStatusDone.ToUpper().Contains(cbStatus.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                     x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                        }
                        if (cbSearchApplications.SelectedIndex == 13)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.EconomistStatusDone.ToUpper().Contains(cbStatus.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                     x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                        }
                        if (cbSearchApplications.SelectedIndex == 14)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.DepartmentStatusDone.ToUpper().Contains(cbStatus.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                     x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                        }
                        if (cbSearchApplications.SelectedIndex == 15)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.DispatcherNIIAR_StatusDone.ToUpper().Contains(cbStatus.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                     x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                        }
                        if (cbSearchApplications.SelectedIndex == 16)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.DispatcherATA_StatusDone.ToUpper().Contains(cbStatus.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                     x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении")));

                        }

                    }
                    else
                    {
                        if (cbSearchApplications.SelectedIndex == 12)
                        {
                            bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.DirectorStatusDone.ToUpper().Contains(cbStatus.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                        }
                        if (cbSearchApplications.SelectedIndex == 13)
                        {
                            bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.EconomistStatusDone.ToUpper().Contains(cbStatus.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                        }
                        if (cbSearchApplications.SelectedIndex == 14)
                        {
                            bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.DepartmentStatusDone.ToUpper().Contains(cbStatus.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                        }
                        if (cbSearchApplications.SelectedIndex == 15)
                        {
                            bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.DispatcherNIIAR_StatusDone.ToUpper().Contains(cbStatus.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                        }
                        if (cbSearchApplications.SelectedIndex == 16)
                        {
                            bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.DispatcherATA_StatusDone.ToUpper().Contains(cbStatus.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении")));
                        }
                    }
                }
            }

            NotApplicationAndChoose();

            //cbSortModeApplications_SelectedIndexChanged(sender, e);
        }


        private void cbSortModeApplications_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new MyDataModelDataContext())
            {
                if (dtpSearchApplications.Visible == true)
                {
                    if (GeneralClass.mode == (int)GeneralClass.Status.Admin)
                    {
                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 1)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.DateCreation.Date == dtpSearchApplications.Value.Date).OrderByDescending(x => x.DateCreation);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 1)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.DateCreation.Date == dtpSearchApplications.Value.Date).OrderBy(x => x.DateCreation.Date);
                        }
                    }

                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                    {
                        if (cbArchiveApplications.Checked == true)
                        {
                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 1)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.DateCreation.Date == dtpSearchApplications.Value.Date && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                        x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.DateCreation);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 1)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.DateCreation.Date == dtpSearchApplications.Value.Date && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                        x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.DateCreation.Date);

                            }
                        }
                        else
                        {
                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 1)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.DateCreation.Date == dtpSearchApplications.Value.Date && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.DateCreation);



                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 1)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.DateCreation.Date == dtpSearchApplications.Value.Date && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.DateCreation.Date);
                            }
                        }
                    }
                }



                if (cbStatus.Visible == true)
                {
                    if (GeneralClass.mode == (int)GeneralClass.Status.Admin)
                    {
                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 12 ||
                            cbSearchApplications.SelectedIndex == 13 || cbSearchApplications.SelectedIndex == 13 ||
                            cbSearchApplications.SelectedIndex == 14 || cbSearchApplications.SelectedIndex == 15 || cbSearchApplications.SelectedIndex == 16)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderByDescending(x => x.Id);


                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 12 ||
                            cbSearchApplications.SelectedIndex == 13 || cbSearchApplications.SelectedIndex == 13 ||
                            cbSearchApplications.SelectedIndex == 14 || cbSearchApplications.SelectedIndex == 15 || cbSearchApplications.SelectedIndex == 16)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderBy(x => x.Id);
                        }
                    }

                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                    {
                        if (cbArchiveApplications.Checked == true)
                        {
                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 12 ||
                            cbSearchApplications.SelectedIndex == 13 || cbSearchApplications.SelectedIndex == 13 ||
                            cbSearchApplications.SelectedIndex == 14 || cbSearchApplications.SelectedIndex == 15 || cbSearchApplications.SelectedIndex == 16)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                        x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Id);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 12 ||
                                cbSearchApplications.SelectedIndex == 13 || cbSearchApplications.SelectedIndex == 13 ||
                                cbSearchApplications.SelectedIndex == 14 || cbSearchApplications.SelectedIndex == 15 || cbSearchApplications.SelectedIndex == 16)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                             x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Id);

                            }
                        }
                        else
                        {
                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 12 ||
                            cbSearchApplications.SelectedIndex == 13 || cbSearchApplications.SelectedIndex == 13 ||
                            cbSearchApplications.SelectedIndex == 14 || cbSearchApplications.SelectedIndex == 15 || cbSearchApplications.SelectedIndex == 16)
                            {


                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Id);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 12 ||
                                cbSearchApplications.SelectedIndex == 13 || cbSearchApplications.SelectedIndex == 13 ||
                                cbSearchApplications.SelectedIndex == 14 || cbSearchApplications.SelectedIndex == 15 || cbSearchApplications.SelectedIndex == 16)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Id);

                            }
                        }
                    }
                }




                if (mtbSearchApplications.Text == "Поиск...")
                {
                    if (GeneralClass.mode == (int)GeneralClass.Status.Admin)
                    {

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 0)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderByDescending(x => x.Id);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 0)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderBy(x => x.Id);
                        }


                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 2)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderByDescending(x => x.Client);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 2)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderBy(x => x.Client);
                        }


                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 3)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderByDescending(x => x.Email);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 3)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderBy(x => x.Email);
                        }



                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 4)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderByDescending(x => x.Post);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 4)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderBy(x => x.Post);
                        }


                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 5)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderByDescending(x => x.Division);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 5)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderBy(x => x.Division);
                        }

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 6)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderByDescending(x => x.Building);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 6)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderBy(x => x.Building);
                        }

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 7)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderByDescending(x => x.Room);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 7)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderBy(x => x.Room);
                        }


                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 8)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderByDescending(x => x.WorkPhone);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 8)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderBy(x => x.WorkPhone);
                        }

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 9)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderByDescending(x => x.MobilePhone);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 9)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderBy(x => x.MobilePhone);
                        }

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 10)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderByDescending(x => x.Director);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 10)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderBy(x => x.Director);
                        }

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 11)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderByDescending(x => x.Economist);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 11)
                        {
                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.OrderBy(x => x.Economist);
                        }

                    }

                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                    {
                        if (cbArchiveApplications.Checked == true)
                        {
                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 0)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Id);


                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 0)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Id);
                            }


                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 2)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Client);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 2)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Client);
                            }


                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 3)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Email);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 3)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Email);
                            }



                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 4)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Post);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 4)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Post);
                            }


                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 5)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Division);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 5)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Division);
                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 6)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Building);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 6)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Room);
                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 7)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Room);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 7)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Room);
                            }


                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 8)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.WorkPhone);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 8)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.WorkPhone);
                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 9)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.MobilePhone);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 9)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.MobilePhone);
                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 10)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Director);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 10)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Director);
                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 11)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Economist);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 11)
                            {
                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Economist);
                            }
                        }
                        else
                        {
                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 0)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Id);
                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 0)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Id);

                            }


                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 2)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Client);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 2)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Client);
                            }


                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 3)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Email);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 3)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Email);
                            }



                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 4)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Post);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 4)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Post);
                            }


                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 5)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Division);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 5)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Division);
                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 6)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Building);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 6)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Building);
                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 7)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Room);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 7)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Room);
                            }


                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 8)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.WorkPhone);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 8)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.WorkPhone);
                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 9)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.MobilePhone);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 9)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.MobilePhone);
                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 10)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Director);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 10)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Director);
                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 11)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Economist);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 11)
                            {
                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Economist);
                            }
                        }
                    }
                }
                else
                {
                    if (GeneralClass.mode == (int)GeneralClass.Status.Admin)
                    {
                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 0)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Id.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderByDescending(x => x.Id);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 0)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Id.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderBy(x => x.Id);

                        }

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 2)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Client.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderByDescending(x => x.Client);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 2)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Client.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderBy(x => x.Client);

                        }

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 3)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Email.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderByDescending(x => x.Email);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 3)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Email.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderBy(x => x.Email);

                        }

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 4)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Post.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderByDescending(x => x.Post);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 4)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Post.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderBy(x => x.Post);

                        }

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 5)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Division.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderByDescending(x => x.Division);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 5)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Division.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderBy(x => x.Division);

                        }

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 6)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Building.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderByDescending(x => x.Building);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 6)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Building.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderBy(x => x.Building);

                        }

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 7)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Room.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderByDescending(x => x.Room);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 7)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Room.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderBy(x => x.Room);

                        }

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 8)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.WorkPhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderByDescending(x => x.WorkPhone);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 8)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.WorkPhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderBy(x => x.WorkPhone);

                        }

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 9)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.MobilePhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderByDescending(x => x.MobilePhone);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 9)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.MobilePhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderBy(x => x.MobilePhone);

                        }

                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 10)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Director.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderByDescending(x => x.Director);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 10)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Director.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderBy(x => x.Director);

                        }


                        if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 11)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Economist.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderByDescending(x => x.Economist);

                        }
                        if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 11)
                        {

                            bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Economist.ToUpper().Contains(mtbSearchApplications.Text.ToUpper())).OrderBy(x => x.Economist);

                        }
                    }

                    if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
                    {
                        if (cbArchiveApplications.Checked == true)
                        {
                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 0)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Id.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Id);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 0)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Id.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Id);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 2)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Client.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Client);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 2)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Client.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Client);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 3)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Email.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Email);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 3)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Email.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Email);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 4)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Post.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Post);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 4)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Post.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Post);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 5)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Division.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Division);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 5)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Division.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Division);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 6)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Building.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Building);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 6)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Building.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Building);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 7)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Room.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Room);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 7)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Room.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Room);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 8)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.WorkPhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.WorkPhone);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 8)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.WorkPhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.WorkPhone);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 9)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.MobilePhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.MobilePhone);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 9)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.MobilePhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.MobilePhone);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 10)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Director.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Director);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 10)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Director.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Director);

                            }


                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 11)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Economist.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Economist);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 11)
                            {

                                bsApplicationAgreedView.DataSource = db.ApplicationAgreedView.Where(x => x.Economist.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && (x.DispatcherATA_StatusDone == "Исполнено" || x.DispatcherATA_StatusDone == "Не исполнено") && ((x.DispatcherNIIAR_StatusDone == "Согласовано" ||
                    x.DirectorStatusDone == "Отклонена" || x.EconomistStatusDone == "Отклонена" || x.DispatcherNIIAR_StatusDone == "Отклонена" || x.DepartmentStatusDone == "Отклонена") || (DateTime.Now - x.DateCreation > new TimeSpan(1, 0, 0, 0) && (x.DirectorStatusDone == "На рассмотрении") || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).OrderBy(x => x.Economist);

                            }
                        }
                        else
                        {
                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 0)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Id.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Id);



                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 0)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Id.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Id);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 2)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Client.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Client);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 2)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Client.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Client);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 3)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Email.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Email);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 3)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Email.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Email);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 4)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Post.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Post);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 4)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Post.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Post);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 5)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Division.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Division);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 5)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Division.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Division);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 6)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Building.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Building);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 6)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Building.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Building);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 7)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Room.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Room);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 7)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Room.ToString().ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Room);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 8)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.WorkPhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.WorkPhone);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 8)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.WorkPhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.WorkPhone);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 9)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.MobilePhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.MobilePhone);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 9)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.MobilePhone.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.MobilePhone);

                            }

                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 10)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Director.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Director);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 10)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Director.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Director);

                            }


                            if (cbSortModeApplications.SelectedIndex == 0 && cbSearchApplications.SelectedIndex == 11)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Economist.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderByDescending(x => x.Economist);

                            }
                            if (cbSortModeApplications.SelectedIndex == 1 && cbSearchApplications.SelectedIndex == 11)
                            {

                                bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Economist.ToUpper().Contains(mtbSearchApplications.Text.ToUpper()) && ((
                       x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone != "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении") || (x.DirectorStatusDone != "На рассмотрении" && x.EconomistStatusDone != "На рассмотрении" &&
                       x.DispatcherNIIAR_StatusDone != "На рассмотрении"
                        && x.DepartmentStatusDone == "На рассмотрении" && x.DispatcherATA_StatusDone == "На рассмотрении"))).OrderBy(x => x.Economist);

                            }
                        }
                    }
                }

            }
        }
        //поиск


        //сменить пользователя
        private void tsmiUserClose_Click(object sender, EventArgs e)
        {
            Form form = this.FindForm();
            form.Close();
            form.Dispose();
            AuthorizationFormFlow = new Thread(OpenAuthorizationForm);
            AuthorizationFormFlow.SetApartmentState(ApartmentState.STA);
            AuthorizationFormFlow.Start();

            Properties.Settings.Default.tbLogin = null;
            Properties.Settings.Default.tbPassword = null;
            Properties.Settings.Default.dataTime = null;
            Properties.Settings.Default.Save();

            GeneralClass.client = null;
            GeneralClass.email = null;
            GeneralClass.post = null;
            GeneralClass.division = null;

            GeneralClass.building = null;
            GeneralClass.room = null;
            GeneralClass.workPhone = null;
            GeneralClass.mobilePhone = null;
            GeneralClass.mode = 0;
            GeneralClass.UserID = 0;
            GeneralClass.directorClient = null;
            GeneralClass.economistClient = null;
            GeneralClass.statusUser = null;

            GeneralClass.nickname = null;
            GeneralClass.login = null;
            GeneralClass.password = null;
        }
        public void OpenAuthorizationForm(object obj)
        {
            Application.Run(new AuthorizationForm());
        }

        //сменить пользователя

        //справка
        private void tsmiHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @"Help\Help.chm");
        }
        //справка

        //уведомления
        private void dgvApplication_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //// задаем иконку всплывающей подсказки
            //niTaskbar.BalloonTipIcon = ToolTipIcon.Info;
            //// задаем текст подсказки
            //niTaskbar.BalloonTipText = "Поступила новая заявка";

            //// устанавливаем заголовка
            //niTaskbar.BalloonTipTitle = "Информация";

            //niTaskbar.ShowBalloonTip(12);

        }


        //уведомления


        //открыть форму "транспорт"
        private void tsmiTransport_Click(object sender, EventArgs e)
        {
            timer.Stop();
            TransportForm form = new TransportForm();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.Cancel)
            {
                timer.Start();
                LoadDataBase();
            }
        }
        // открыть форму "транспорт"

        // открыть форму "Пользователи"
        private void tsmiUsers_Click(object sender, EventArgs e)
        {
            timer.Stop();
            UserForm form = new UserForm();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.Cancel)
            {
                timer.Start();
                LoadDataBase();
            }
        }

        // открыть форму "Пользователи"

        //редактировать свои данные 
        private void tsbEditUser_Click(object sender, EventArgs e)
        {
            using (var db = new MyDataModelDataContext())
            {
                _Us = db.Users.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                _DvID = _Us.DivisionID;
                InsertUpdateUserForm form = new InsertUpdateUserForm(_Us, _DvID, _Rgs);
                form.ShowDialog();
            }
        }
        //редактировать свои данные 


        //почта
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 2525);
        //    Smtp.Credentials = new NetworkCredential("a.pvrpva@mail.ru", "DC7zZ5CvANF9GZhzK65V");
        //    MailMessage Message = new MailMessage();
        //    Smtp.EnableSsl = true;
        //    Message.From = new MailAddress("a.pvrpva@mail.ru");
        //    Message.To.Add(new MailAddress("seregeisysorov@mail.ru"));
        //    Message.Subject = "И как у тебя сегодня дела";
        //    Message.Body = "супер";

        //    try
        //    {
        //        Smtp.Send(Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}
        //почта
    }
}
