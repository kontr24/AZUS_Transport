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
    public partial class CreateUpdateApplicationsForm : Form
    {
        private Applications _App;

        private string _Msg;

        public CreateUpdateApplicationsForm()
        {
            InitializeComponent();
        }

        public CreateUpdateApplicationsForm(Applications app) : this()
        {
            _App = app;
        }

        private void CreateUpdateApplicationsForm_Load(object sender, EventArgs e)
        {
            dtpDateStart.MinDate = DateTime.Now;
            dtpDateEnd.MinDate = DateTime.Now;
            dtpTimeStart.Value = DateTime.Now;
            dtpTimeEnd.Value = DateTime.Now;

            if (_App == null)
            {
                Text = "Создание заявки";
                _Msg = "Заявка успешно создана!";
                _App = new Applications();
                using (var db = new MyDataModelDataContext())
                {

                    tbClient.Text = GeneralClass.client;
                    tbEmail.Text = GeneralClass.email;
                    tbPost.Text = GeneralClass.post;
                    tbDivision.Text = GeneralClass.division;
                    tbBuilding.Text = GeneralClass.building;
                    tbRoom.Text = GeneralClass.room;
                    tbWorkPhone.Text = GeneralClass.workPhone;
                    tbMobilePhone.Text = GeneralClass.mobilePhone;
                    tbDirector.Text = GeneralClass.directorClient;
                    tbEconomist.Text = GeneralClass.economistClient;

                    cbTypeCars.DataSource = db.TypeCarView;
                }
            }
            else
            {
                Text = "Редактировние";
                _Msg = "Заявка успешно обновлена!";

                using (var db = new MyDataModelDataContext())
                {
                    tbClient.Text = GeneralClass.client;
                    tbEmail.Text = GeneralClass.email;
                    tbPost.Text = GeneralClass.post;
                    tbDivision.Text = GeneralClass.division;
                    tbBuilding.Text = GeneralClass.building;
                    tbRoom.Text = GeneralClass.room;
                    tbWorkPhone.Text = GeneralClass.workPhone;
                    tbMobilePhone.Text = GeneralClass.mobilePhone;
                    tbDirector.Text = GeneralClass.directorClient;
                    tbEconomist.Text = GeneralClass.economistClient;
                    cbTypeCars.DataSource = db.TypeCarView;
                }

            }
        }

        private void btnSendApplication_Click(object sender, EventArgs e)
        {

            if (dtpDateStart.Value.Date + dtpTimeStart.Value.TimeOfDay >= dtpDateEnd.Value.Date + dtpTimeEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Время начала превышает время завершения! ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtpTimeStart.Value.TimeOfDay <= DateTime.Now.TimeOfDay)
            {
                MessageBox.Show("Подкорректируйте время!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbPlaceSubmission.Text) || tbPlaceSubmission.Text == "управление")
            {
                MessageBox.Show("Укажите место подачи транспорта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbRouteWhereFrom.Text) || tbRouteWhereFrom.Text == "откуда")
            {
                MessageBox.Show("Укажите маршрут", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbRouteWhere.Text) || tbRouteWhere.Text == "куда")
            {
                MessageBox.Show("Укажите маршрут", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(tbPurposeUsingTransport.Text) || tbPurposeUsingTransport.Text == "для осуществления регулярных перевозок пассажиров")
            {
                MessageBox.Show("Укажите цель использования транспорта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            _App.UserID = GeneralClass.UserID;

            _App.StartDate = dtpDateStart.Value.Date + dtpTimeStart.Value.TimeOfDay;
            _App.EndDate = dtpDateEnd.Value.Date + dtpTimeEnd.Value.TimeOfDay;

            _App.DateCreation = DateTime.Now;
            _App.TypeCarID = (int)cbTypeCars.SelectedValue;

            if (rbCity.Checked == true)
            {
                _App.IntercityСity = true;
            }
            if (rbIntercityСity.Checked == true)
            {
                _App.IntercityСity = false;
            }
            if (rbDaysWorker.Checked == true)
            {
                _App.Days = true;
            }
            if (rbDaysWeekend.Checked == true)
            {
                _App.Days = false;
            }

            if (nudQuantityPassengers.Enabled == true)
            {
                _App.QuantityPassengers = (int)nudQuantityPassengers.Value;
            }
            if (nudCargo.Enabled == true)
            {
                _App.CargoWeight = (double)nudCargo.Value;
            }

            _App.PlaceSubmission = tbPlaceSubmission.Text;
            _App.Route = tbRouteWhereFrom.Text + " —> " + tbRouteWhere.Text;
            if (tbCommentClient.Text != "Комментарий")
            {
                _App.CommentClient = tbCommentClient.Text;
            }
            _App.PurposeUsingTransport = tbPurposeUsingTransport.Text;
            _App.CarID = 1;
            _App.DirectorStatusDoneID = 3;
            _App.EconomistStatusDoneID = 3;
            _App.DispatcherNIIAR_StatusDoneID = 3;
            _App.DepartmentStatusDoneID = 3;
            _App.DispatcherATA_StatusDoneID = 3;
            try
            {
                using (var db = new MyDataModelDataContext())
                {
                    var app = db.Applications.Max(x => x.Id);
                    var us = db.Users.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                    var usrDirector = db.Users.Where(x => x.StatusID == 3 && x.DivisionID == us.DivisionID).FirstOrDefault();

                    SmtpClient SmtpClient = new SmtpClient("smtp.mail.ru", 2525);
                    SmtpClient.Credentials = new NetworkCredential(us.Email, "DC7zZ5CvANF9GZhzK65V");
                    MailMessage MessageDirector = new MailMessage();
                    SmtpClient.EnableSsl = true;
                    MessageDirector.IsBodyHtml = true;
                    MessageDirector.From = new MailAddress(us.Email);
                    MessageDirector.To.Add(new MailAddress(usrDirector.Email));

                    MessageDirector.Subject = "Заявка № " + (app + 1) + " на одобрение";

                    MessageDirector.Body = "Время согласования заявки: до " + String.Format("{0:d} - {0:t}", _App.DateCreation.AddDays(1)) + ", иначе заявка будет автоматически отклонена." + "<br/><br/>Перейти в " + "<a href=\'s2x:/run\'>АСУЗ 'Транспорт'</a>"
                    + "<style>.colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";


                    try
                    {
                        SmtpClient.Send(MessageDirector);
                        MessageBox.Show("Уведомление о вашей поданной заявке отправлено вашему руководителю на электронный адрес " + usrDirector.Email + "!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Заявка не создана! Сообщение не отправлено руководителю на почту! Причина:\n" + ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (_App.Id == 0)
                    {
                        db.Applications.InsertOnSubmit(_App);


                    }
                    else
                    {
                        //var cln = db.Clients.FirstOrDefault(w => w.Id == _Cln.Id);
                        //cln.SurName = tbClientSurName.Text;
                        //cln.Name = tbClientName.Text;
                        //cln.Patronymic = tbClientPatronomic.Text;
                        //cln.Birthday = dtpClientBirthday.Value;
                        //cln.Phone = tbClientPhone.Text;
                        //cln.ModelCarID = (int)cbClientModelCar.SelectedValue;
                        //cln.AutoRegisterSign = tbClientRegisterSignCar.Text;

                    }
                    db.SubmitChanges();


                }
                MessageBox.Show(_Msg, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DialogResult = DialogResult.OK;
            /* MainForm update = this.Owner as MainForm;
             update.LoadDataBase();*/
            Close();

        }

        private void cbTypeCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cbTypeCars.SelectedValue == 1)
            {
                nudQuantityPassengers.Enabled = true;
                nudCargo.Enabled = false;
            }
            else
            {
                nudQuantityPassengers.Enabled = false;
                nudCargo.Enabled = true;

            }
            if ((int)cbTypeCars.SelectedValue == 3 || (int)cbTypeCars.SelectedValue == 5)
            {
                nudQuantityPassengers.Enabled = false;
                nudCargo.Enabled = false;
            }

        }

        private void tbPlaceSubmission_Enter(object sender, EventArgs e)
        {
            if (tbPlaceSubmission.Text == "управление")
            {
                tbPlaceSubmission.Text = "";
                tbPlaceSubmission.ForeColor = Color.Black;
            }
        }

        private void tbPlaceSubmission_Leave(object sender, EventArgs e)
        {
            if (tbPlaceSubmission.Text == "")
            {
                tbPlaceSubmission.Text = "управление";
                tbPlaceSubmission.ForeColor = Color.Silver;
            }
        }

        private void tbRoute_Enter(object sender, EventArgs e)
        {
            if (tbRouteWhereFrom.Text == "откуда")
            {
                tbRouteWhereFrom.Text = "";
                tbRouteWhereFrom.ForeColor = Color.Black;
            }
        }

        private void tbRoute_Leave(object sender, EventArgs e)
        {
            if (tbRouteWhereFrom.Text == "")
            {
                tbRouteWhereFrom.Text = "откуда";
                tbRouteWhereFrom.ForeColor = Color.Silver;
            }
        }

        private void tbRouteWhere_Enter(object sender, EventArgs e)
        {
            if (tbRouteWhere.Text == "куда")
            {
                tbRouteWhere.Text = "";
                tbRouteWhere.ForeColor = Color.Black;
            }
        }

        private void tbRouteWhere_Leave(object sender, EventArgs e)
        {
            if (tbRouteWhere.Text == "")
            {
                tbRouteWhere.Text = "куда";
                tbRouteWhere.ForeColor = Color.Silver;
            }
        }


        private void tbCommentClient_Enter(object sender, EventArgs e)
        {
            if (tbCommentClient.Text == "Комментарий")
            {
                tbCommentClient.Text = "";
                tbCommentClient.ForeColor = Color.Black;
            }
        }

        private void tbCommentClient_Leave(object sender, EventArgs e)
        {

            if (tbCommentClient.Text == "")
            {
                tbCommentClient.Text = "Комментарий";
                tbCommentClient.ForeColor = Color.Silver;
            }
        }




        private void tbPurposeUsingTransport_Enter(object sender, EventArgs e)
        {
            if (tbPurposeUsingTransport.Text == "для осуществления регулярных перевозок пассажиров")
            {
                tbPurposeUsingTransport.Text = "";
                tbPurposeUsingTransport.ForeColor = Color.Black;
            }
        }

        private void tbPurposeUsingTransport_Leave(object sender, EventArgs e)
        {
            if (tbPurposeUsingTransport.Text == "")
            {
                tbPurposeUsingTransport.Text = "для осуществления регулярных перевозок пассажиров";
                tbPurposeUsingTransport.ForeColor = Color.Silver;
            }
        }

        private void btnDeclineApplication_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}


