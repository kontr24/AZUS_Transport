using AZUS_Transport.Classes;
using AZUS_Transport.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZUS_Transport.OtherForms
{
    public partial class ApplicationJoinForm : Form
    {
        private Applications _App;

        private ApplicationView _AppView;

        private string _Msg;

        public ApplicationJoinForm()
        {
            InitializeComponent();
        }

        public ApplicationJoinForm(Applications app, ApplicationView appView) : this()
        {
            _App = app;
            _AppView = appView;
        }

        private void ApplicationJoinForm_Load(object sender, EventArgs e)
        {
            using (var db = new MyDataModelDataContext())
            {

                //Text = "Редактировние";
                if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
                {
                    _Msg = "Заявки успешно объединены!";
                    tsmiApplicationsAssociation.Text = "Заявки на объединение";
                    Text = "Объединение заявок";
                    btnApplicationJoin.Text = "Объединить";

                    Width = 1070;
                    Height = 279;
                    btnApplicationJoin.Location = new Point(774, 194);
                    btnCancel.Location = new Point(911, 194);

                    bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.Route == _App.Route && x.StartDate == _App.StartDate && x.TypeCar == _AppView.TypeCar && x.DispatcherNIIAR_StatusDone == _AppView.DispatcherNIIAR_StatusDone);


                }
                else
                {
                    Width = 1070;
                    Height = 330;
                    pbComment.Location = new Point(12, 177);
                    tbComment.Location = new Point(12, 198);
                    lComment.Location = new Point(38, 177);
                    btnReject.Location = new Point(638, 243);
                    btnApplicationJoin.Location = new Point(775, 243);
                    btnCancel.Location = new Point(912, 243);


                    tsmiApplicationsAssociation.Text = "Объединенные заявки на исполнение";
                    Text = "Исполнение объединенных заявок";
                    btnReject.Visible = true;
                    tbComment.Visible = true;
                    lComment.Visible = true;
                    pbComment.Visible = true;
                    btnApplicationJoin.Text = "Исполнено";
                    bsApplicationsView.DataSource = db.ApplicationView.Where(x => x.ApplicationJoin == _App.ApplicationJoin);


                }
            }
        }

        private void btnApplicationJoin_Click(object sender, EventArgs e)
        {
            if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
            {

                try
                {
                    using (var db = new MyDataModelDataContext())
                    {
                        var appSelectionJoinCount = db.Applications.Where(x => x.StartDate == _App.StartDate && x.Route == _App.Route && x.TypeCarID == _App.TypeCarID && DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && x.DispatcherNIIAR_StatusDoneID == _App.DispatcherNIIAR_StatusDoneID && x.SelectionApplicationJoin == true).Count();
                        if (appSelectionJoinCount >= 2)
                        {

                            foreach (var appSelectionJoin in db.Applications.Where(x => x.StartDate == _App.StartDate && x.Route == _App.Route && x.TypeCarID == _App.TypeCarID && DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && x.DispatcherNIIAR_StatusDoneID == _App.DispatcherNIIAR_StatusDoneID && x.SelectionApplicationJoin == true))
                            {
                                foreach (var appJoinAll in db.Applications.Where(x => x.StartDate == _App.StartDate && x.Route == _App.Route && x.TypeCarID == _App.TypeCarID && DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && x.DispatcherNIIAR_StatusDoneID == _App.DispatcherNIIAR_StatusDoneID && x.SelectionApplicationJoin == true).GroupBy(x => x.Route, (k, ie) => string.Join(" -> ", ie.Select(x => x.Id)))) // из столбца в строку
                                {
                                    appSelectionJoin.ApplicationJoin = appJoinAll;
                                    db.SubmitChanges();
                                }
                            }
                            MessageBox.Show(_Msg, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GeneralClass.applicationJoin = 1;
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Выберите больше одной заявки!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    using (var db = new MyDataModelDataContext())
                    {
                        var appSelectionJoinCount = db.Applications.Where(x => x.ApplicationJoin == _App.ApplicationJoin && x.SelectionApplicationJoin == true).Count();
                        if (appSelectionJoinCount >= 2)
                        {
                            var us = db.Users.FirstOrDefault(x => x.Id == GeneralClass.UserID);

                            foreach (var appSelectionJoin in db.Applications.Where(x => x.ApplicationJoin == _App.ApplicationJoin && x.SelectionApplicationJoin == true))
                            {

                                appSelectionJoin.DispatcherATA_StatusDoneID = 4;
                                db.SubmitChanges();

                                var usClient = db.Users.Where(x => x.Id == appSelectionJoin.UserID).FirstOrDefault();

                                SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 2525);
                                Smtp.Credentials = new NetworkCredential(us.Email, "DC7zZ5CvANF9GZhzK65V");
                                MailMessage Message = new MailMessage();
                                Smtp.EnableSsl = true;
                                Message.From = new MailAddress(us.Email);

                                Message.To.Add(new MailAddress(usClient.Email));

                                Message.Subject = "Статус заявки № " + appSelectionJoin.Id;

                                Message.IsBodyHtml = true;


                                if (tbComment.Text == "Комментарий")
                                {
                                    Message.Body = "Ваша заявка исполнена!" + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                                }
                                else
                                {
                                    Message.Body = "Ваша заявка исполнена!"
                                        + "\n" + "Комментарий: " + tbComment.Text + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                                }
                                try
                                {
                                    Smtp.Send(Message);
                                    MessageBox.Show("Уведомление отправлено клиенту на электронный адрес " + usClient.Email + "!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Уведомление не отправлено клиенту на электронный адрес " + usClient.Email + "!" + "Причина:\n" + ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                foreach (var appResetSelectionJoin in db.Applications.Where(x => x.ApplicationJoin == _App.ApplicationJoin).GroupBy(x => x.Route, (k, ie) => string.Join(", ", ie.Select(x => x.Id))))
                                {
                                    // задаем иконку всплывающей подсказки
                                    niTaskbar.BalloonTipIcon = ToolTipIcon.Info;
                                    // задаем текст подсказки
                                    niTaskbar.BalloonTipText = "Заявки № " + appResetSelectionJoin + " исполнены вами!";

                                }
                            }
                            MessageBox.Show("Выбранные заявки исполнены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // устанавливаем заголовка
                            niTaskbar.BalloonTipTitle = "Информация";
                            niTaskbar.ShowBalloonTip(12);

                            DialogResult = DialogResult.OK;
                            Close();
                            GeneralClass.applicationJoin = 1;
                        }
                        else
                        {
                            MessageBox.Show("Выберите больше одной заявки!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
            {

                using (var db = new MyDataModelDataContext())
                {
                    foreach (var appSelectionJoin in db.Applications.Where(x => x.StartDate == _App.StartDate && x.Route == _App.Route && x.TypeCarID == _App.TypeCarID && DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && x.DispatcherNIIAR_StatusDoneID == _App.DispatcherNIIAR_StatusDoneID))
                    {
                        appSelectionJoin.SelectionApplicationJoin = false;
                        appSelectionJoin.ApplicationJoin = null;
                        db.SubmitChanges();
                    }
                    GeneralClass.applicationJoin = 0;
                    DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                using (var db = new MyDataModelDataContext())
                {
                    foreach (var appSelectionJoin in db.Applications.Where(x => x.ApplicationJoin == _App.ApplicationJoin))
                    {
                        appSelectionJoin.SelectionApplicationJoin = false;
                        db.SubmitChanges();
                    }
                }
                DialogResult = DialogResult.Cancel;
            }

        }


        private void dgvApplicationView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR)
            {
                using (var db = new MyDataModelDataContext())
                {
                    foreach (DataGridViewRow row in dgvApplicationView.Rows)
                    {
                        if (row.Cells["RowSelection"].Value != null)
                        {
                            if ((Boolean)row.Cells["RowSelection"].Value == true)
                            {

                                var appJoin = db.Applications.FirstOrDefault(x => x.Id.ToString() == row.Cells["ApplicationNumber"].Value.ToString());
                                appJoin.SelectionApplicationJoin = true;

                            }
                            else
                            {
                                var appJoin = db.Applications.FirstOrDefault(x => x.Id.ToString() == row.Cells["ApplicationNumber"].Value.ToString());
                                appJoin.SelectionApplicationJoin = false;
                            }
                            db.SubmitChanges();
                        }
                    }
                }
            }

            else
            {
                using (var db = new MyDataModelDataContext())
                {
                    foreach (DataGridViewRow row in dgvApplicationView.Rows)
                    {
                        if (row.Cells["RowSelection"].Value != null)
                        {

                            if ((Boolean)row.Cells["RowSelection"].Value == true)
                            {
                                var appJoin = db.Applications.FirstOrDefault(x => x.Id.ToString() == row.Cells["ApplicationNumber"].Value.ToString());
                                appJoin.SelectionApplicationJoin = true;


                            }
                            else
                            {
                                var appJoin = db.Applications.FirstOrDefault(x => x.Id.ToString() == row.Cells["ApplicationNumber"].Value.ToString());
                                appJoin.SelectionApplicationJoin = false;
                            }
                            db.SubmitChanges();
                        }
                    }
                }
            }



        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new MyDataModelDataContext())
                {
                    var appSelectionJoinCount = db.Applications.Where(x => x.ApplicationJoin == _App.ApplicationJoin && x.SelectionApplicationJoin == true).Count();
                    if (appSelectionJoinCount >= 2)
                    {
                        var us = db.Users.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                        foreach (var appSelectionJoin in db.Applications.Where(x => x.ApplicationJoin == _App.ApplicationJoin && x.SelectionApplicationJoin == true))
                        {
                            appSelectionJoin.DispatcherATA_StatusDoneID = 5;
                            db.SubmitChanges();


                            var usClient = db.Users.Where(x => x.Id == appSelectionJoin.UserID).FirstOrDefault();

                            SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 2525);
                            Smtp.Credentials = new NetworkCredential(us.Email, "DC7zZ5CvANF9GZhzK65V");
                            MailMessage Message = new MailMessage();
                            Smtp.EnableSsl = true;
                            Message.From = new MailAddress(us.Email);

                            Message.To.Add(new MailAddress(usClient.Email));

                            Message.Subject = "Статус заявки № " + appSelectionJoin.Id;

                            Message.IsBodyHtml = true;


                            if (tbComment.Text == "Комментарий")
                            {
                                Message.Body = "Ваша заявка не исполнена!" + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                            }
                            else
                            {
                                Message.Body = "Ваша заявка не исполнена!"
                                    + "\n" + "Комментарий: " + tbComment.Text + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>" + "<style> .colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";
                            }
                            try
                            {
                                Smtp.Send(Message);
                                MessageBox.Show("Уведомление отправлено клиенту на электронный адрес " + usClient.Email + "!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Уведомление не отправлено клиенту на электронный адрес " + usClient.Email + "!" + "Причина:\n" + ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            foreach (var appResetSelectionJoin in db.Applications.Where(x => x.ApplicationJoin == _App.ApplicationJoin).GroupBy(x => x.Route, (k, ie) => string.Join(", ", ie.Select(x => x.Id))))
                            {
                                // задаем иконку всплывающей подсказки
                                niTaskbar.BalloonTipIcon = ToolTipIcon.Info;
                                // задаем текст подсказки
                                niTaskbar.BalloonTipText = "Заявки № " + appResetSelectionJoin + " не исполнены вами!";

                            }
                        }
                        MessageBox.Show("Выбранные заявки не исполнены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // устанавливаем заголовка
                        niTaskbar.BalloonTipTitle = "Информация";
                        niTaskbar.ShowBalloonTip(12);

                        DialogResult = DialogResult.OK;
                        Close();
                        GeneralClass.applicationJoin = 1;
                    }
                    else
                    {
                        MessageBox.Show("Выберите больше одной заявки!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

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
    }
}
