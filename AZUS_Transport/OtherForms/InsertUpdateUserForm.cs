using AZUS_Transport.Classes;
using AZUS_Transport.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZUS_Transport.OtherForms
{
    public partial class InsertUpdateUserForm : Form
    {
        private Users _Us;
        private Divisions _Dvs;
        private int _DvID;
        private int _Rgs;
        private string _Msg;

        public InsertUpdateUserForm()
        {
            InitializeComponent();
        }
        public InsertUpdateUserForm(Users us, int dvId, int rgs) : this()
        {
            _Us = us;
            _DvID = dvId;
            _Rgs = rgs;
        }

        private void InsertUpdateUserForm_Load(object sender, EventArgs e)
        {

            if (_Us == null)
            {
                if (_Rgs == 1)
                {
                    rbClient.Checked = true;
                    pDivisionInformation.Height = 225;
                    cbDivision.Width = 479;
                    btnDivisionDelete.Visible = false;
                    btnDivisionAdd.Visible = false;
                    btnDivisionChange.Visible = false;
                    lStatus.Location = new Point(11,828);
                    pStatus.Location = new Point(15,851);
                    lDirectorAndEconomist.Location = new Point(11, 962);
                    pDirectorAndEconomist.Location = new Point(15,986);

                }
                else
                {
                    rbAdmin.Checked = true;
                }
                Text = "Регистрация";
                _Msg = "Регистрация прошла успешно!";
                _Us = new Users();

                using (var db = new MyDataModelDataContext())
                {
                    bsDivisionView.DataSource = db.DivisionView;
                    cbDivision.DataSource = db.DivisionView;


                }
            }
            else
            {

                if (_Rgs == 1)
                {
                    rbClient.Checked = true;
                    pDivisionInformation.Height = 225;
                    cbDivision.Width = 479;
                    btnDivisionDelete.Visible = false;
                    btnDivisionAdd.Visible = false;
                    btnDivisionChange.Visible = false;
                    lStatus.Location = new Point(11, 828);
                    pStatus.Location = new Point(15, 851);
                    lDirectorAndEconomist.Location = new Point(11, 962);
                    pDirectorAndEconomist.Location = new Point(15, 986);

                }

                tbSurName.ForeColor = Color.Black;
                tbName.ForeColor = Color.Black;
                tbPartonymic.ForeColor = Color.Black;
                tbEmail.ForeColor = Color.Black;
                tbPost.ForeColor = Color.Black;
                tbPassword.ForeColor = Color.Black;
                tbUsername.ForeColor = Color.Black;
                tbRoom.ForeColor = Color.Black;


                Text = "Редактирование";
                _Msg = "Данные успешно обновлены!";

                using (var db = new MyDataModelDataContext())
                {
                    //bsOrganizationView.Position = bsOrganizationView.Find("Id", 1);

                    bsDivisionView.DataSource = db.DivisionView;

                    //foreach (DataGridViewRow rows in dgvDivisionView.Rows)
                    //{
                    //    if ((int)rows.Cells["Id"].Value == _Us.DivisionID)
                    //    {
                    //        bsDivisionView.Position = rows.Index;
                    //    }
                    //}


                    var usrDrc = db.Users.FirstOrDefault(x => x.DivisionID == _Us.DivisionID && x.StatusID == 3);
                    var usrEcn = db.Users.FirstOrDefault(x => x.DivisionID == _Us.DivisionID && x.StatusID == 4);
                    var usrAdm = db.Users.FirstOrDefault(x => x.StatusID == 1);

                    var usrDspNIIAR = db.Users.FirstOrDefault(x => x.StatusID == 5);
                    var usrDspATA = db.Users.FirstOrDefault(x => x.StatusID == 7);
                    var usrDpr = db.Users.FirstOrDefault(x => x.StatusID == 6);


                    if (usrDpr != null)
                    {
                        rbDepartment.Enabled = false;
                    }
                    else
                    {
                        rbDepartment.Enabled = true;
                    }

                    if (usrDspATA != null)
                    {
                        rbDispatcherATA.Enabled = false;
                    }
                    else
                    {
                        rbDispatcherATA.Enabled = true;
                    }

                    if (usrDspNIIAR != null)
                    {
                        rbDispatcherNIIAR.Enabled = false;
                    }
                    else
                    {
                        rbDispatcherNIIAR.Enabled = true;
                    }

                    if (usrAdm != null)
                    {
                        rbAdmin.Enabled = false;
                    }
                    else
                    {
                        rbAdmin.Enabled = true;
                    }

                    if (usrDrc != null)
                    {
                        rbDirector.Enabled = false;
                    }
                    else
                    {
                        rbDirector.Enabled = true;
                    }
                    if (usrEcn != null)
                    {
                        rbEconomist.Enabled = false;
                    }
                    else
                    {
                        rbEconomist.Enabled = true;
                    }

                    tbUsername.Text = _Us.Username;
                    tbPassword.Text = _Us.Password;

                    cbDivision.DataSource = db.DivisionView;

                    cbDivision.SelectedValue = _DvID;


                    tbSurName.Text = _Us.SurName;
                    tbName.Text = _Us.Name;
                    tbPartonymic.Text = _Us.Partonymic;
                    tbEmail.Text = _Us.Email;
                    tbPost.Text = _Us.Post;
                    mtbWorkPhone.Text = _Us.WorkPhone;
                    mtbMobilePhone.Text = _Us.MobilePhone;
                    tbRoom.Text = _Us.Room.ToString();

                    if (_Us.StatusID == 2)
                    {
                        rbClient.Checked = true;
                    }
                    if (_Us.StatusID == 1)
                    {
                        rbAdmin.Checked = true;
                    }
                    if (_Us.StatusID == 3)
                    {
                        rbDirector.Checked = true;
                    }
                    if (_Us.StatusID == 4)
                    {
                        rbEconomist.Checked = true;

                    }
                    if (_Us.StatusID == 5)
                    {
                        rbDispatcherNIIAR.Checked = true;
                    }
                    if (_Us.StatusID == 6)
                    {
                        rbDepartment.Checked = true;
                    }
                    if (_Us.StatusID == 7)
                    {
                        rbDispatcherATA.Checked = true;
                    }

                }

            }

        }


        private void btnDivisionChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbDivision.Text))
            {
                MessageBox.Show("Выберите подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbDivisionChange.Text))
            {
                MessageBox.Show("Введите название подразделения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbBuilding.Text))
            {
                MessageBox.Show("Введите номер здания!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                using (var db = new MyDataModelDataContext())
                {
                    var selectedIndex = cbDivision.SelectedIndex;

                    var dvs = db.Divisions.Where(x => x.Id == (int)cbDivision.SelectedValue).FirstOrDefault();

                    dvs.Name = tbDivisionChange.Text;
                    dvs.Building = tbBuilding.Text;

                    db.SubmitChanges();
                    bsDivisionView.DataSource = db.DivisionView;
                    cbDivision.DataSource = db.DivisionView;
                    cbDivision.SelectedIndex = selectedIndex;

                    //foreach (DataGridViewRow rows in dgvDivisionView.Rows)
                    //{
                    //    if ((int)rows.Cells["Id"].Value == _Us.DivisionID)
                    //    {
                    //        bsDivisionView.Position = rows.Index;
                    //    }
                    //}

                }
                MessageBox.Show("Данные обновлены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDivisionDelete_Click(object sender, EventArgs e)
        {

            try
            {
                using (var db = new MyDataModelDataContext())
                {
                    var dvs = db.Divisions.FirstOrDefault(x => x.Id == (int)cbDivision.SelectedValue);
                    if (dvs == null) return;
                    var msgResult = MessageBox.Show("Вы действительно хотите удалить " + dvs.Name + "?", "Удаление подразделения", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (msgResult == DialogResult.OK)
                    {
                        db.Divisions.DeleteOnSubmit(dvs);
                        db.SubmitChanges();
                        bsDivisionView.DataSource = db.DivisionView;
                        cbDivision.DataSource = db.DivisionView;


                        //foreach (DataGridViewRow rows in dgvDivisionView.Rows)
                        //{
                        //    if ((int)rows.Cells["Id"].Value == _Us.DivisionID)
                        //    {
                        //        bsDivisionView.Position = rows.Index;
                        //    }
                        //}
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Невозможно удалить подразделение, так как необходимо удалить все зависимые записи в таблице 'Пользователи'!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDivisionAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDivisionChange.Text))
            {
                MessageBox.Show("Введите название подразделения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbBuilding.Text))
            {
                MessageBox.Show("Введите номер здания!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Dvs = new Divisions();

            _Dvs.Name = tbDivisionChange.Text;
            _Dvs.Building = tbBuilding.Text;
           

            try
            {
                using (var db = new MyDataModelDataContext())
                {

                    db.Divisions.InsertOnSubmit(_Dvs);
                    db.SubmitChanges();
                    bsDivisionView.DataSource = db.DivisionView;
                    cbDivision.DataSource = db.DivisionView;
                    cbDivision.SelectedIndex = cbDivision.Items.Count - 1; //переход к последней добавленной записи
                    /*bsDivisionView.Position = bsDivisionView.Count;*/ //переход к последней добавленной записи

                }
                MessageBox.Show("Данные добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void cbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbDivisionChange.Text = cbDivision.Text;
            using (var db = new MyDataModelDataContext())
            {
                var dvs = db.Divisions.FirstOrDefault(x => x.Id == (int)cbDivision.SelectedValue);
                if (dvs != null)
                {
                    tbBuilding.Text = dvs.Building;
                }

                var usrDrc = db.Users.FirstOrDefault(x => x.DivisionID == (int)cbDivision.SelectedValue && x.StatusID == 3);

                var usrEcn = db.Users.FirstOrDefault(x => x.DivisionID == (int)cbDivision.SelectedValue && x.StatusID == 4);
                if (usrDrc != null)
                {
                    tbDirector.Text = usrDrc.SurName + " " + usrDrc.Name + " " + usrDrc.Partonymic;
                }
                else
                {
                    tbDirector.Text = null;
                }
                if (usrEcn != null)
                {
                    tbEconomist.Text = usrEcn.SurName + " " + usrEcn.Name + " " + usrEcn.Partonymic;
                }
                else
                {
                    tbEconomist.Text = null;
                }

            }

        }


        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            using (var db = new MyDataModelDataContext())
            {
                if (_Us.Id == 0)
                {
                    var usrCheck = db.Users.FirstOrDefault(x => x.Username == tbUsername.Text);

                    if (usrCheck != null)
                    {
                        MessageBox.Show("Логин '" + usrCheck.Username + "' занят!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }
        }

        private void btnInsertUpdateUser_Click(object sender, EventArgs e)
        {
            const string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            var email = tbEmail.Text.Trim().ToLowerInvariant();
            using (var db = new MyDataModelDataContext())
            {
                if (_Us.Id == 0)
                {
                    var usrCheck = db.Users.FirstOrDefault(x => x.Username == tbUsername.Text);

                    if (usrCheck != null)
                    {
                        MessageBox.Show("Логин '" + usrCheck.Username + "' занят!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }

            if (string.IsNullOrEmpty(tbUsername.Text) || tbUsername.Text == "petrov1245 ")
            {
                MessageBox.Show("Введите логин!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbPassword.Text) || tbPassword.Text == "7UnR4po3 ")
            {
                MessageBox.Show("Введите пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbSurName.Text) || tbSurName.Text == "Петров ")
            {
                MessageBox.Show("Введите фамилию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbName.Text) || tbName.Text == "Пётр ")
            {
                MessageBox.Show("Введите имя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbPartonymic.Text) || tbPartonymic.Text == "Петрович ")
            {
                MessageBox.Show("Введите отчество!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbEmail.Text) || tbEmail.Text == "petrov1990@mail.ru ")
            {
                MessageBox.Show("Введите адрес электронной почты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Regex.Match(email, pattern).Success)
            {
                MessageBox.Show("Введен некорректный адрес электронной почты!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(tbPost.Text) || tbPost.Text == "Главный инженер ")
            {
                MessageBox.Show("Введите должность!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (mtbWorkPhone.MaskCompleted == false)
            {
                MessageBox.Show("Введите номер рабочего телефона!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (mtbMobilePhone.MaskCompleted == false)
            {
                MessageBox.Show("Введите номер мобильного телефона!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (bsDivisionView.Count == 0)
            {
                MessageBox.Show("Подразделения не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbRoom.Text) || tbRoom.Text == "102 ")
            {
                MessageBox.Show("Введите номер комнаты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rbClient.Checked == true)
            {
                if (string.IsNullOrEmpty(tbDirector.Text))
                {
                    MessageBox.Show("Руководитель вашего подразделения ещё не зарегистрирован в системе, поэтому предупредите администратора об этом! Вы сможете пройти регистрацию только после того, как руководитель вашего подразделения зарегистрируется!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(tbEconomist.Text))
                {
                    MessageBox.Show("Экономист вашего подразделения ещё не зарегистрирован в системе, поэтому предупредите администратора об этом! Вы сможете пройти регистрацию только после того, как экономист вашего подразделения зарегистрируется!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }

            using (var db = new MyDataModelDataContext())
            {
                var usrDrc = db.Users.FirstOrDefault(x => x.DivisionID == (int)cbDivision.SelectedValue && x.StatusID == 3);
                var usrEcn = db.Users.FirstOrDefault(x => x.DivisionID == (int)cbDivision.SelectedValue && x.StatusID == 4);

                var usrAdm = db.Users.FirstOrDefault(x => x.StatusID == 1);

                var usrDspNIIAR = db.Users.FirstOrDefault(x => x.StatusID == 5);
                var usrDspATA = db.Users.FirstOrDefault(x => x.StatusID == 7);
                var usrDpr = db.Users.FirstOrDefault(x => x.StatusID == 6);

                if (usrDrc != null && rbDirector.Checked == true && _Us.Id == 0)
                {
                    MessageBox.Show("Руководитель для выбранного подразделения уже зарегистрирован в системе!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (usrEcn != null && rbEconomist.Checked == true && _Us.Id == 0)
                {
                    MessageBox.Show("Экономист для выбранного подразделения уже зарегистрирован в системе!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (usrAdm != null && rbAdmin.Checked == true && _Us.Id == 0)
                {
                    MessageBox.Show("Администратор уже зарегистрирован в системе!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (usrDspNIIAR != null && rbDispatcherNIIAR.Checked == true && _Us.Id == 0)
                {
                    MessageBox.Show("Диспетчер НИИАР уже зарегистрирован в системе!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (usrDspATA != null && rbDispatcherATA.Checked == true && _Us.Id == 0)
                {
                    MessageBox.Show("Диспетчер АТА уже зарегистрирован в системе!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (usrDpr != null && rbDepartment.Checked == true && _Us.Id == 0)
                {
                    MessageBox.Show("ДИД уже зарегистрирован в системе!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }


            _Us.Username = tbUsername.Text;
            _Us.Password = tbPassword.Text;
            _Us.SurName = tbSurName.Text;
            _Us.Name = tbName.Text;
            _Us.Partonymic = tbPartonymic.Text;
            _Us.Email = tbEmail.Text;
            _Us.Post = tbPost.Text;
            _Us.WorkPhone = mtbWorkPhone.Text;
            _Us.MobilePhone = mtbMobilePhone.Text;
            _Us.Room = Int32.Parse(tbRoom.Text);
            _Us.DivisionID = (int)cbDivision.SelectedValue;


            using (var db = new MyDataModelDataContext())
            {
                var drt = db.Users.Where(x => x.StatusID == 1).FirstOrDefault();


                if (rbClient.Checked == true)
                {
                    _Us.StatusID = 2;

                }

                if (rbAdmin.Checked == true)
                {
                    _Us.StatusID = 1;
                }
                if (rbDirector.Checked == true)
                {
                    _Us.StatusID = 3;
                }
                if (rbEconomist.Checked == true)
                {
                    _Us.StatusID = 4;
                }


                if (rbDispatcherNIIAR.Checked == true)
                {
                    _Us.StatusID = 5;

                }
                if (rbDepartment.Checked == true)
                {
                    _Us.StatusID = 6;
                }
                if (rbDispatcherATA.Checked == true)
                {
                    _Us.StatusID = 7;

                }

            }

            try
            {
                using (var db = new MyDataModelDataContext())
                {

                    if (_Us.Id == 0)
                    {
                        db.Users.InsertOnSubmit(_Us);

                    }
                    else
                    {
                        var usr = db.Users.FirstOrDefault(w => w.Id == _Us.Id);

                        if (usr != null)
                        {
                            usr.Username = tbUsername.Text;
                            usr.Password = tbPassword.Text;
                            usr.SurName = tbSurName.Text;
                            usr.Name = tbName.Text;
                            usr.Partonymic = tbPartonymic.Text;
                            usr.Email = tbEmail.Text;
                            usr.Post = tbPost.Text;
                            usr.WorkPhone = mtbWorkPhone.Text;
                            usr.MobilePhone = mtbMobilePhone.Text;
                            usr.Room =Int32.Parse(tbRoom.Text);
                            usr.DivisionID = (int)cbDivision.SelectedValue;
                        }

                        if (rbClient.Checked == true)
                        {
                            usr.StatusID = 2;

                        }
                        if (rbAdmin.Checked == true)
                        {
                            usr.StatusID = 1;
                        }
                        if (rbDirector.Checked == true)
                        {
                            usr.StatusID = 3;
                        }
                        if (rbEconomist.Checked == true)
                        {
                            usr.StatusID = 4;
                        }


                        if (rbDispatcherNIIAR.Checked == true)
                        {
                            usr.StatusID = 5;

                        }
                        if (rbDepartment.Checked == true)
                        {
                            usr.StatusID = 6;
                        }
                        if (rbDispatcherATA.Checked == true)
                        {
                            usr.StatusID = 7;

                        }

                    }
                    db.SubmitChanges();

                }
                MessageBox.Show(_Msg, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_Rgs == 1)
            {
                GeneralClass.login = tbUsername.Text;
                GeneralClass.password = tbPassword.Text;
                Properties.Settings.Default.tbLogin = tbUsername.Text;
                Properties.Settings.Default.tbPassword = tbPassword.Text;
                Properties.Settings.Default.Save();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void tbSurName_Enter(object sender, EventArgs e)
        {
            if (tbSurName.Text == "Петров ")
            {
                tbSurName.Text = "";
                tbSurName.ForeColor = Color.Black;

            }
        }

        private void tbSurName_Leave(object sender, EventArgs e)
        {

            if (tbSurName.Text == "")
            {
                tbSurName.Text = "Петров ";
                tbSurName.ForeColor = Color.Silver;
            }
        }

        private void tbName_Enter(object sender, EventArgs e)
        {
            if (tbName.Text == "Пётр ")
            {
                tbName.Text = "";
                tbName.ForeColor = Color.Black;

            }
        }

        private void tbName_Leave(object sender, EventArgs e)
        {

            if (tbName.Text == "")
            {
                tbName.Text = "Пётр ";
                tbName.ForeColor = Color.Silver;
            }
        }

        private void tbPartonymic_Enter(object sender, EventArgs e)
        {
            if (tbPartonymic.Text == "Петрович ")
            {
                tbPartonymic.Text = "";
                tbPartonymic.ForeColor = Color.Black;

            }
        }

        private void tbPartonymic_Leave(object sender, EventArgs e)
        {

            if (tbPartonymic.Text == "")
            {
                tbPartonymic.Text = "Петрович ";
                tbPartonymic.ForeColor = Color.Silver;
            }
        }

        private void tbEmail_Enter(object sender, EventArgs e)
        {
            if (tbEmail.Text == "petrov1990@mail.ru ")
            {
                tbEmail.Text = "";
                tbEmail.ForeColor = Color.Black;

            }
        }

        private void tbEmail_Leave(object sender, EventArgs e)
        {
            if (tbEmail.Text == "")
            {
                tbEmail.Text = "petrov1990@mail.ru ";
                tbEmail.ForeColor = Color.Silver;
            }
        }

        private void tbPost_Enter(object sender, EventArgs e)
        {
            if (tbPost.Text == "Главный инженер ")
            {
                tbPost.Text = "";
                tbPost.ForeColor = Color.Black;

            }
        }

        private void tbPost_Leave(object sender, EventArgs e)
        {
            if (tbPost.Text == "")
            {
                tbPost.Text = "Главный инженер ";
                tbPost.ForeColor = Color.Silver;
            }
        }

        private void tbUsername_Enter(object sender, EventArgs e)
        {
            if (tbUsername.Text == "petrov1245 ")
            {
                tbUsername.Text = "";
                tbUsername.ForeColor = Color.Black;

            }
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                tbUsername.Text = "petrov1245 ";
                tbUsername.ForeColor = Color.Silver;
            }
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.Text == "7UnR4po3 ")
            {
                tbPassword.Text = "";
                tbPassword.ForeColor = Color.Black;

            }
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text == "")
            {
                tbPassword.Text = "7UnR4po3 ";
                tbPassword.ForeColor = Color.Silver;
            }
        }

        private void tbRoom_Enter(object sender, EventArgs e)
        {
            if (tbRoom.Text == "102 ")
            {
                tbRoom.Text = "";
                tbRoom.ForeColor = Color.Black;

            }
        }

        private void tbRoom_Leave(object sender, EventArgs e)
        {
            if (tbRoom.Text == "")
            {
                tbRoom.Text = "102 ";
                tbRoom.ForeColor = Color.Silver;
            }
        }


        private void rbClient_CheckedChanged(object sender, EventArgs e)
        {
            lDirectorAndEconomist.Visible = true;
            pDirectorAndEconomist.Visible = true;

        }

        private void rbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            lDirectorAndEconomist.Visible = false;
            pDirectorAndEconomist.Visible = false;

        }

        private void rbDirector_CheckedChanged(object sender, EventArgs e)
        {
            lDirectorAndEconomist.Visible = true;
            pDirectorAndEconomist.Visible = true;



        }

        private void rbEconomist_CheckedChanged(object sender, EventArgs e)
        {
            lDirectorAndEconomist.Visible = true;
            pDirectorAndEconomist.Visible = true;

        }

        private void rbDispatcherNIIAR_CheckedChanged(object sender, EventArgs e)
        {
            lDirectorAndEconomist.Visible = false;
            pDirectorAndEconomist.Visible = false;
        }

        private void rbDispatcherATA_CheckedChanged(object sender, EventArgs e)
        {
            lDirectorAndEconomist.Visible = false;
            pDirectorAndEconomist.Visible = false;
        }

        private void rbDepartment_CheckedChanged(object sender, EventArgs e)
        {
            lDirectorAndEconomist.Visible = false;
            pDirectorAndEconomist.Visible = false;
        }


        private void btnDeclineInsertUpdateUser_Click(object sender, EventArgs e)
        {
            Close();
        }

   
    }
}
