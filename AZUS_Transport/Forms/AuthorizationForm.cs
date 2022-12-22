using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using AZUS_Transport.Classes;
using System.Security.Cryptography;
using AZUS_Transport.Models;
using AZUS_Transport.OtherForms;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace AZUS_Transport.Forms
{
    public partial class AuthorizationForm : Form
    {
        Thread MainFormFlow;

        private Users _Us;
        private int _DvID;
        private int _Rgs = 1;
        public AuthorizationForm()
        {
            InitializeComponent();
            tbLogin.Text = Properties.Settings.Default.tbLogin;
            tbPassword.Text = Properties.Settings.Default.tbPassword;

        }
        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            if (tbPassword.Text != "Пароль" || string.IsNullOrEmpty(tbPassword.Text))
            {
                tbPassword.PasswordChar = '*';
                tbPassword.ForeColor = Color.Black;
            }
            else
            {

                tbPassword.ForeColor = Color.Silver;
            }
            if (tbLogin.Text != "Логин")
            {
                tbLogin.ForeColor = Color.Black;

            }
            else
            {
                tbLogin.ForeColor = Color.Silver;
            }
            if (tbEmail.Text != "ivanov78@niiar.ru ")
            {
                tbEmail.ForeColor = Color.Black;
            }
            else
            {
                tbEmail.ForeColor = Color.Silver;
            }
            using (var db = new MyDataModelDataContext())
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.tbLogin)
                    || DateTime.Now - DateTime.Parse(Properties.Settings.Default.dataTime) > new TimeSpan(10, 0, 0, 0))
                {
                    Properties.Settings.Default.tbLogin = "";
                    Properties.Settings.Default.tbPassword = "";
                    Properties.Settings.Default.dataTime = "";
                    Properties.Settings.Default.Save();
                    tbLogin.ForeColor = Color.Silver;
                    tbLogin.Text = "Логин";
                    tbPassword.PasswordChar = '\0';
                    tbPassword.Text = "Пароль";
                    tbPassword.ForeColor = Color.Silver;
                }
                else
                {
                    tbLogin.Text = Properties.Settings.Default.tbLogin;
                    tbPassword.Text = Properties.Settings.Default.tbPassword;
                    Properties.Settings.Default.dataTime = DateTime.Now.ToString();
                    Properties.Settings.Default.Save();
                    tbLogin.ForeColor = Color.Black;
                    tbPassword.ForeColor = Color.Black;
                    try
                    {
                        var usr = db.Users.FirstOrDefault(u => u.Username == Properties.Settings.Default.tbLogin && u.Password == Properties.Settings.Default.tbPassword);

                        if (usr != null)
                        {
                            var us = db.Users.FirstOrDefault(u => u.DivisionID == usr.DivisionID);
                            var usDrc = db.Users.Where(x => x.StatusID == 3 && x.DivisionID == us.DivisionID).FirstOrDefault();
                            var usEcn = db.Users.Where(x => x.StatusID == 4 && x.DivisionID == us.DivisionID).FirstOrDefault();


                            var sts = db.Statuses.FirstOrDefault(u => u.Id == usr.StatusID);

                            var dvs = db.Divisions.FirstOrDefault(u => u.Id == us.DivisionID);

                            if (us != null)
                            {
                                GeneralClass.client = usr.SurName + " " + usr.Name + " " + usr.Partonymic;
                                GeneralClass.email = usr.Email;
                                GeneralClass.post = usr.Post;
                                GeneralClass.workPhone = usr.WorkPhone;
                                GeneralClass.mobilePhone = usr.MobilePhone;
                                GeneralClass.mode = usr.StatusID;
                                GeneralClass.UserID = usr.Id;
                                GeneralClass.room = usr.Room.ToString();
                            }
                            if (dvs != null)
                            {
                                GeneralClass.division = dvs.Name;
                                GeneralClass.building = dvs.Building;
                            }

                            if (usDrc != null)
                            {
                                GeneralClass.directorClient = usDrc.SurName + " " + usDrc.Name + " " + usDrc.Partonymic;

                            }
                            if (usEcn != null)
                            {
                                GeneralClass.economistClient = usEcn.SurName + " " + usEcn.Name + " " + usEcn.Partonymic;
                            }
                            if (sts != null)
                            {
                                GeneralClass.statusUser = sts.Name;
                            }

                        }
                        if (GeneralClass.mode == 1 || GeneralClass.mode == 2
                                || GeneralClass.mode == 3 || GeneralClass.mode == 4 || GeneralClass.mode == 5 || GeneralClass.mode == 6 || GeneralClass.mode == 7)
                        {
                            this.Visible = false;
                            GeneralClass.nickname = tbLogin.Text.Trim();
                            tbLogin.Text = "";
                            tbPassword.Text = "";
                            this.Close();
                            MainFormFlow = new Thread(OpenMainForm);
                            MainFormFlow.SetApartmentState(ApartmentState.STA);
                            MainFormFlow.Start();
                            try
                            {
                                this.Visible = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }

                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка подключения к базе данных! Обратитесь к администратору", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        //private void AuthorizationForm_Load(object sender, EventArgs e)
        //{
        //    tbLogin.Text = "Логин";
        //    tbPassword.Text = "Пароль";
        //    tbLogin.ForeColor = Color.Gray;
        //    tbPassword.ForeColor = Color.Gray;
        //}

        //private void tbLogin_Enter(object sender, EventArgs e)
        //{
        //    tbLogin.Text = null;
        //    tbLogin.ForeColor = Color.Black;
        //}

        //private void tbPassword_Enter(object sender, EventArgs e)
        //{
        //    tbPassword.Text = null;
        //    tbPassword.ForeColor = Color.Black;
        //}

        //private void tbLogin_Leave(object sender, EventArgs e)
        //{
        //    if (tbLogin.Text == null)
        //    {
        //        tbLogin.Text = "Логин";

        //        tbLogin.ForeColor = Color.Gray;

        //    }
        //    else {
        //        tbLogin.Text = "";
        //    }

        //    if (tbPassword.Text == null)
        //    {
        //        tbPassword.Text = "Пароль";
        //        tbPassword.ForeColor = Color.Gray;
        //    }
        //}



        private void cbRemember_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRemember.Checked)
            {
                Properties.Settings.Default.tbLogin = tbLogin.Text;
                Properties.Settings.Default.tbPassword = tbPassword.Text;
                Properties.Settings.Default.dataTime = DateTime.Now.ToString();
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.tbLogin = null;
                Properties.Settings.Default.tbPassword = null;
                Properties.Settings.Default.dataTime = null;
                Properties.Settings.Default.Save();
            }
        }

        private void btnExtrance_Click(object sender, EventArgs e)
        {
            if (btnExtrance.Text == "Вход")
            {
                if (string.IsNullOrEmpty(tbLogin.Text) || tbLogin.Text == "Логин")
                {
                    MessageBox.Show("Введите 'Логин'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(tbPassword.Text) || tbPassword.Text == "Пароль")
                {
                    MessageBox.Show("Введите 'Пароль'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    if (tbLogin.Text.Trim() != "" && tbPassword.Text.Trim() != "")
                    {
                        MD5 md5 = new MD5CryptoServiceProvider();
                        string pass = tbPassword.Text.Trim();
                        byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
                        string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                        MyDataModelDataContext db = new MyDataModelDataContext();
                        //GeneralClass.mode = db.Users.Where(x => x.Username == tbLogin.Text.Trim() && x.Password == tbPassword.Text.Trim()).Select(t => t.StatusID).FirstOrDefault();
                        //GeneralClass.client = db.Users.Where(x => x.Username == tbLogin.Text.Trim() && x.Password == tbPassword.Text.Trim()).Select(t => t.SurName + " " + t.Name + " " + t.Partonymic).FirstOrDefault();

                        var usr = db.Users.FirstOrDefault(u => u.Username == tbLogin.Text.Trim() && u.Password == tbPassword.Text.Trim());



                        //var us = db.Users.Where(x => x.Id == usr.DirectorID);
                        if (usr != null)
                        {
                            var us = db.Users.FirstOrDefault(u => u.DivisionID == usr.DivisionID);
                            var usDrc = db.Users.Where(x => x.StatusID == 3 && x.DivisionID == us.DivisionID).FirstOrDefault();
                            var usEcn = db.Users.Where(x => x.StatusID == 4 && x.DivisionID == us.DivisionID).FirstOrDefault();


                            var sts = db.Statuses.FirstOrDefault(u => u.Id == usr.StatusID);

                            var dvs = db.Divisions.FirstOrDefault(u => u.Id == us.DivisionID);

                            if (us != null)
                            {
                                GeneralClass.client = usr.SurName + " " + usr.Name + " " + usr.Partonymic;
                                GeneralClass.email = usr.Email;
                                GeneralClass.post = usr.Post;
                                GeneralClass.workPhone = usr.WorkPhone;
                                GeneralClass.mobilePhone = usr.MobilePhone;
                                GeneralClass.mode = usr.StatusID;
                                GeneralClass.UserID = usr.Id;
                                GeneralClass.room = usr.Room.ToString();
                            }
                            if (dvs != null)
                            {
                                GeneralClass.division = dvs.Name;
                                GeneralClass.building = dvs.Building;
                                
                            }

                            if (usDrc != null)
                            {
                                GeneralClass.directorClient = usDrc.SurName + " " + usDrc.Name + " " + usDrc.Partonymic;

                            }
                            if (usEcn != null)
                            {
                                GeneralClass.economistClient = usEcn.SurName + " " + usEcn.Name + " " + usEcn.Partonymic;
                            }
                            if (sts != null)
                            {
                                GeneralClass.statusUser = sts.Name;
                            }

                        }



                        if (GeneralClass.mode == 1 || GeneralClass.mode == 2
                                || GeneralClass.mode == 3 || GeneralClass.mode == 4 || GeneralClass.mode == 5 || GeneralClass.mode == 6 || GeneralClass.mode == 7)
                        {
                            this.Visible = false;
                            GeneralClass.nickname = tbLogin.Text.Trim();
                            tbLogin.Text = "";
                            tbPassword.Text = "";
                            this.Close();
                            MainFormFlow = new Thread(OpenMainForm);
                            MainFormFlow.SetApartmentState(ApartmentState.STA);
                            MainFormFlow.Start();
                            try
                            {
                                this.Visible = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }

                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка подключения к базе данных! Обратитесь к администратору", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(tbEmail.Text) || tbEmail.Text == "ivanov78@niiar.ru ")
                {
                    MessageBox.Show("Введите ваш электронный адрес!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    using (var db = new MyDataModelDataContext())
                    {
                        var us = db.Users.FirstOrDefault(x => x.Email == tbEmail.Text);
                        var usr = db.Users.FirstOrDefault(x => x.StatusID == 5);
                        const string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                        var email = tbEmail.Text.Trim().ToLowerInvariant();

                        if (!Regex.Match(email, pattern).Success)
                        {
                            MessageBox.Show("Введен некорректный адрес электронной почты!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                       
                        if (us != null)
                        {
                            SmtpClient SmtpClient = new SmtpClient("smtp.mail.ru", 2525);
                            SmtpClient.Credentials = new NetworkCredential(usr.Email, "DC7zZ5CvANF9GZhzK65V");
                            MailMessage Message = new MailMessage();
                            SmtpClient.EnableSsl = true;
                            Message.IsBodyHtml = true;
                            Message.From = new MailAddress(usr.Email);
                            Message.To.Add(new MailAddress(us.Email));
                            Message.Subject = "Восстановление доступа";
                            Message.Body = "Ваш логин: " + us.Username + "<br/>" + "Ваш пароль: " + us.Password + "<br/><br/>Перейти в " + "<a href=\'s2x:run\'>АСУЗ 'Транспорт'</a>"
                                     + "<style>.colorDiv {color: #d0d4ce}</style>" + "<br/><br/><hr><div class='colorDiv'>Данное письмо было сформировано автоматически подсистемой уведомления АСУЗ 'Транспорт'. Ответ не требуется</div>";

                            try
                            {
                                SmtpClient.Send(Message);
                                MessageBox.Show("Логин и пароль отправлены на электронную почту " + us.Email + "!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Логин и пароль не отправлены на электронную почту! Причина:\n" + ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с почтой " + tbEmail.Text +" не зарегистрирован"+ "!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        lSend.Visible = false;
                        tbEmail.Visible = false;
                        tbLogin.Visible = true;
                        tbPassword.Visible = true;
                        pbLogin.Visible = true;
                        pbPassword.Visible = true;
                        llRegistration.Visible = true;
                        cbRemember.Visible = true;
                        btnExtrance.Text = "Вход";
                        btnExtrance.Location = new Point(354, 297);
                        llRecover.Visible = true;
                        llBack.Visible = false;
                        

                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка подключения к базе данных! Обратитесь к администратору", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
        public void OpenMainForm(object obj)
        {
            Application.Run(new MainForm());
        }



        private void llRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InsertUpdateUserForm form = new InsertUpdateUserForm(_Us, _DvID, _Rgs);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                _Rgs = 0;
                try
                {
                    MyDataModelDataContext db = new MyDataModelDataContext();

                    var usr = db.Users.FirstOrDefault(u => u.Username == GeneralClass.login && u.Password == GeneralClass.password);

                    if (usr != null)
                    {


                        var us = db.Users.FirstOrDefault(u => u.DivisionID == usr.DivisionID);
                        var usDrc = db.Users.Where(x => x.StatusID == 3 && x.DivisionID == us.DivisionID).FirstOrDefault();
                        var usEcn = db.Users.Where(x => x.StatusID == 4 && x.DivisionID == us.DivisionID).FirstOrDefault();


                        var sts = db.Statuses.FirstOrDefault(u => u.Id == usr.StatusID);

                        var dvs = db.Divisions.FirstOrDefault(u => u.Id == us.DivisionID);

                        if (us != null)
                        {
                            GeneralClass.client = usr.SurName + " " + usr.Name + " " + usr.Partonymic;
                            GeneralClass.email = usr.Email;
                            GeneralClass.post = usr.Post;
                            GeneralClass.workPhone = usr.WorkPhone;
                            GeneralClass.mobilePhone = usr.MobilePhone;
                            GeneralClass.mode = usr.StatusID;
                            GeneralClass.UserID = usr.Id;
                            GeneralClass.room = usr.Room.ToString();
                        }
                        if (dvs != null)
                        {
                            GeneralClass.division = dvs.Name;
                            GeneralClass.building = dvs.Building;
                            
                        }

                        if (usDrc != null)
                        {
                            GeneralClass.directorClient = usDrc.SurName + " " + usDrc.Name + " " + usDrc.Partonymic;

                        }
                        if (usEcn != null)
                        {
                            GeneralClass.economistClient = usEcn.SurName + " " + usEcn.Name + " " + usEcn.Partonymic;
                        }
                        if (sts != null)
                        {
                            GeneralClass.statusUser = sts.Name;
                        }


                    }

                    if (GeneralClass.mode == 1 || GeneralClass.mode == 2
                            || GeneralClass.mode == 3 || GeneralClass.mode == 4 || GeneralClass.mode == 5 || GeneralClass.mode == 6 || GeneralClass.mode == 7)
                    {

                        this.Visible = false;
                        GeneralClass.nickname = GeneralClass.login;
                        GeneralClass.login = "";
                        GeneralClass.password = "";
                        this.Close();
                        MainFormFlow = new Thread(OpenMainForm);
                        MainFormFlow.SetApartmentState(ApartmentState.STA);
                        MainFormFlow.Start();
                        try
                        {
                            this.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }

                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка подключения к базе данных! Обратитесь к администратору", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //восстановить доступ
        private void llRecover_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lSend.Visible = true;
            tbEmail.Visible = true;
            tbLogin.Visible = false;
            tbPassword.Visible = false;
            pbLogin.Visible = false;
            pbPassword.Visible = false;
            llRegistration.Visible = false;
            cbRemember.Visible = false;
            btnExtrance.Text = "Отправить";
            btnExtrance.Location = new Point(354, 220);
            llRecover.Visible = false;
            llBack.Visible = true;


        }

        private void llBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lSend.Visible = false;
            tbEmail.Visible = false;
            tbLogin.Visible = true;
            tbPassword.Visible = true;
            pbLogin.Visible = true;
            pbPassword.Visible = true;
            llRegistration.Visible = true;
            cbRemember.Visible = true;
            btnExtrance.Text = "Вход";
            btnExtrance.Location = new Point(354, 297);
            llRecover.Visible = true;
            llBack.Visible = false;
        }

        private void tbEmail_Enter(object sender, EventArgs e)
        {
            if (tbEmail.Text == "ivanov78@niiar.ru ")
            {
                tbEmail.Text = "";
                tbEmail.ForeColor = Color.Black;
            }
        }

        private void tbEmail_Leave(object sender, EventArgs e)
        {
            if (tbEmail.Text == "")
            {
                tbEmail.Text = "ivanov78@niiar.ru ";
                tbEmail.ForeColor = Color.Silver;
            }
        }
        //восстановить доступ
        private void tbLogin_Enter(object sender, EventArgs e)
        {
            if (tbLogin.Text == "Логин")
            {
                tbLogin.Text = "";
                tbLogin.ForeColor = Color.Black;
            }
        }

        private void tbLogin_Leave(object sender, EventArgs e)
        {
            if (tbLogin.Text == "")
            {
                tbLogin.Text = "Логин";
                tbLogin.ForeColor = Color.Silver;
            }
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.Text == "Пароль")
            {
                tbPassword.PasswordChar = '*';

                tbPassword.Text = "";
                tbPassword.ForeColor = Color.Black;
            }
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text == "")
            {
                tbPassword.PasswordChar = '\0';
                tbPassword.Text = "Пароль";
                tbPassword.ForeColor = Color.Silver;
            }
        }
        //private void tbLogin_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyData == Keys.Enter)
        //        btnExtrance.PerformClick();
        //}
    }
}

