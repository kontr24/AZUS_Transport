using AZUS_Transport.Models;
using AZUS_Transport.OtherForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZUS_Transport.MyUserControl
{
    public partial class UserUserControl : UserControl
    {
        private Users _Us;

        private int _DvID;

        private int _Rgs;
        public UserUserControl()
        {
            InitializeComponent();
            LoadDataBase();
        }

        private void BlankPage()
        {
            lUser.Text = null;
            lEmail.Text = null;
            lPost.Text = null;
            lDivision.Text = null;
            lBuilding.Text = null;
            lRoom.Text = null;
            lWorkPhone.Text = null;
            lMobilePhone.Text = null;
            lStatusUser.Text = null;
            lUsername.Text = null;
            lPassword.Text = null;
            lDirectorFullName.Text = null;
            lEconomistFullName.Text = null;
            if (bsUserView.Count == 0)
            {
                lUserNotFound.Visible = true;
            }
            else
            {
                lUserNotFound.Visible = false;
            }
        }
        private void DataPage()
        {
            if (bsUserView.Count != 0)
            {
                var usView = bsUserView.Current as UserView;

                lUser.Text = usView.Customer;
                lEmail.Text = usView.Email;
                lPost.Text = usView.Post;
                lDivision.Text = usView.Division;
                lBuilding.Text = usView.Building.ToString();
                lRoom.Text = usView.Room.ToString();
                lWorkPhone.Text = usView.WorkPhone;
                lMobilePhone.Text = usView.MobilePhone;
                lStatusUser.Text = "(" + usView.Status + ")";
                lUsername.Text = _Us.Username;
                lPassword.Text = _Us.Password;
                if (_Us.StatusID == 2 || _Us.StatusID == 3 || _Us.StatusID == 4)
                {
                    using (var db = new MyDataModelDataContext())
                    {
                        var usrView = bsUserView.Current as UserView;

                        var usrDrc = db.UserView.FirstOrDefault(x => x.Status == "Руководитель" && x.Division == usrView.Division);
                        var usrEcn = db.UserView.FirstOrDefault(x => x.Status == "Экономист" && x.Division == usrView.Division);

                        if (_Us.StatusID == 2 && usrDrc != null && usrEcn != null)
                        {


                            lDirectorFullName.Text = usrDrc.Customer;
                            lEconomistFullName.Text = usrEcn.Customer;
                        }


                    
                        if (_Us.StatusID == 3 && usrEcn != null)
                        {
                            lDirectorFullName.Text = null;
                            lEconomistFullName.Text = usrEcn.Customer;
                        }
                        if (_Us.StatusID == 4 && usrDrc != null)
                        {
                            lDirectorFullName.Text = usrDrc.Customer;
                            lEconomistFullName.Text = null;
                        }
                    }
                }
                else
                {
                    lDirectorFullName.Text = null;
                    lEconomistFullName.Text = null;
                }

                tsbUpdateUser.Enabled = true;
                tsbDeleteUser.Enabled = true;

            }
            else
            {
                BlankPage();
                tsbDeleteUser.Enabled = false;
                tsbUpdateUser.Enabled = false;
            }

        }


        public void LoadDataBase()
        {
            //cbSearchCar.SelectedIndex = 0;
            //cbSortCar.SelectedIndex = 0;

            try
            {
                using (MyDataModelDataContext db = new MyDataModelDataContext())
                {

                    bsUserView.DataSource = db.UserView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataPage();
        }

        private void bsUserView_CurrentChanged(object sender, EventArgs e)
        {
            if (bsUserView.Count == 0) return;

            var usView = bsUserView.Current as UserView;

            using (var db = new MyDataModelDataContext())
            {
                _Us = db.Users.FirstOrDefault(x => x.Id == usView.Id);
            }

        }

        private void tUserView_Tick(object sender, EventArgs e)
        {
            LoadDataBase();
        }

        private void tsbFunctionUser_Click(object sender, EventArgs e)
        {
            cbSearchUser.SelectedIndex = 0;
            cbSearchStatusUser.SelectedIndex = 0;
            cbSortUser.SelectedIndex = 0;
            pFilters.Visible = !pFilters.Visible;

            if (pFilters.Visible == true)
            {
                dgvUserView.ClearSelection();
                BlankPage();
                tUserView.Stop();

            }
            else
            {
                tUserView.Start();
                mtbSearchUser.Text = "Поиск...";
                mtbSearchUser.ForeColor = Color.Silver;
                LoadDataBase();

            }
        }
        private void tsbInsertUser_Click(object sender, EventArgs e)
        {
            InsertUpdateUserForm form = new InsertUpdateUserForm();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                LoadDataBase();
            }
        }
        private void tsbUpdateUser_Click(object sender, EventArgs e)
        {
            if (_Us == null) return;

            _DvID = _Us.DivisionID;
            InsertUpdateUserForm form = new InsertUpdateUserForm(_Us,_DvID,_Rgs);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                LoadDataBase();
            }
        }
        private void tsbDeleteUser_Click(object sender, EventArgs e)
        {
            if (_Us == null) return;
            try
            {
                using (var db = new MyDataModelDataContext())
                {
                    var us = db.Users.FirstOrDefault(w => w.Id == _Us.Id);

                    var msgResult = MessageBox.Show("Вы действительно хотите удалить пользователя " + us.SurName + " " + us.Name + " " + us.Partonymic + "?", "Удаление пользователя", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


                    if (msgResult == DialogResult.OK)
                    {
                        //us.DirectorID = null;
                        //us.EconomistID = null;
                        db.SubmitChanges();
                        db.Users.DeleteOnSubmit(us);
                        db.SubmitChanges();
                        LoadDataBase();
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Невозможно удалить пользователя, так как необходимо удалить все зависимые записи в других таблицах!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUserView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataPage();
        }


        //поиск
        private void cbSearchUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchUser.SelectedIndex == 6 || cbSearchUser.SelectedIndex == 7)
            {

                if (cbSearchUser.SelectedIndex == 7)
                {
                    mtbSearchUser.ForeColor = Color.Black;
                    mtbSearchUser.Mask = "+7(999)000-00-00";
                }
                else
                {
                    mtbSearchUser.ForeColor = Color.Black;

                    mtbSearchUser.Mask = "+7(999-99)0-00-00";
                }
            }
            else
            {
                mtbSearchUser.Mask = null;
                mtbSearchUser.Text = "Поиск...";
                mtbSearchUser.ForeColor = Color.Silver;
            }

            if (cbSearchUser.SelectedIndex == 9)
            {
                cbSearchStatusUser_SelectedIndexChanged(sender, e);
                cbSearchStatusUser.Visible = true;
            }
            else
            {
                cbSearchStatusUser.Visible = false;
            }
            cbSortUser_SelectedIndexChanged(sender, e);
            BlankPage();
            dgvUserView.ClearSelection();
        }

        private void mtbSearchUser_TextChanged(object sender, EventArgs e)
        {
            using (var db = new MyDataModelDataContext())
            {
                if (cbSearchUser.SelectedIndex == 9)
                {
                    bsUserView.DataSource = db.UserView.Where(x => x.Status.ToUpper().Contains(cbSearchStatusUser.Text.ToUpper()));

                }
            }
            if (string.IsNullOrEmpty(mtbSearchUser.Text))
            {
                bsUserView.DataSource = null;
                BlankPage();
            }
            else
            {
                //dgvCarView_CellClick(this.dgvCarView, new DataGridViewCellEventArgs(0, 0));
                using (var db = new MyDataModelDataContext())
                {
                    if (cbSearchUser.SelectedIndex == 0)
                    {
                        bsUserView.DataSource = db.UserView.Where(x => x.Customer.ToUpper().Contains(mtbSearchUser.Text.ToUpper()));

                    }
                    if (cbSearchUser.SelectedIndex == 1)
                    {
                        bsUserView.DataSource = db.UserView.Where(x => x.Email.ToUpper().Contains(mtbSearchUser.Text.ToUpper()));
                    }
                    if (cbSearchUser.SelectedIndex == 2)
                    {
                        bsUserView.DataSource = db.UserView.Where(x => x.Post.ToUpper().Contains(mtbSearchUser.Text.ToUpper()));
                    }
                    if (cbSearchUser.SelectedIndex == 3)
                    {
                        bsUserView.DataSource = db.UserView.Where(x => x.Division.ToUpper().Contains(mtbSearchUser.Text.ToUpper()));
                    }
                    if (cbSearchUser.SelectedIndex == 4)
                    {
                        bsUserView.DataSource = db.UserView.Where(x => x.Building.ToString().ToUpper().Contains(mtbSearchUser.Text.ToUpper()));
                    }
                    if (cbSearchUser.SelectedIndex == 5)
                    {
                        bsUserView.DataSource = db.UserView.Where(x => x.Room.ToString().ToUpper().Contains(mtbSearchUser.Text.ToUpper()));
                    }
                    if (cbSearchUser.SelectedIndex == 6)
                    {
                        bsUserView.DataSource = db.UserView.Where(x => x.WorkPhone.ToUpper().Contains(mtbSearchUser.Text.ToUpper()));
                    }
                    if (cbSearchUser.SelectedIndex == 7)
                    {
                        bsUserView.DataSource = db.UserView.Where(x => x.MobilePhone.ToUpper().Contains(mtbSearchUser.Text.ToUpper()));
                    }
                    if (cbSearchUser.SelectedIndex == 8)
                    { 
                            bsUserView.DataSource = db.UserView.Where(x => x.Customer.ToUpper().Contains(mtbSearchUser.Text.ToUpper()) && x.Status == "Руководитель");
                        
                    }

                }
            }
            cbSortUser_SelectedIndexChanged(sender, e);
            BlankPage();
            dgvUserView.ClearSelection();


            if (bsUserView.Count == 0)
            {
                tsbDeleteUser.Enabled = false;
                tsbUpdateUser.Enabled = false;
            }
            else
            {
                tsbUpdateUser.Enabled = true;
                tsbDeleteUser.Enabled = true;
            }

        }
        private void cbSearchStatusUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new MyDataModelDataContext())
            {
                bsUserView.DataSource = db.UserView.Where(x => x.Status.ToUpper().Contains(cbSearchStatusUser.Text.ToUpper()));
            }
            cbSortUser_SelectedIndexChanged(sender, e);
            BlankPage();
            dgvUserView.ClearSelection();


            if (bsUserView.Count == 0)
            {
                tsbDeleteUser.Enabled = false;
                tsbUpdateUser.Enabled = false;
            }
            else
            {
                tsbUpdateUser.Enabled = true;
                tsbDeleteUser.Enabled = true;
            }
        }

        private void cbSortUser_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (var db = new MyDataModelDataContext())
            {

                if (cbSearchStatusUser.Visible == true)
                {
                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 9)
                    {
                        bsUserView.DataSource = db.UserView.Where(x => x.Status.ToUpper().Contains(cbSearchStatusUser.Text.ToUpper())).OrderByDescending(x => x.Customer);

                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 9)
                    {
                        bsUserView.DataSource = db.UserView.Where(x => x.Status.ToUpper().Contains(cbSearchStatusUser.Text.ToUpper())).OrderBy(x => x.Customer);
                    }
                }


                if (mtbSearchUser.Text == "Поиск...")
                {
                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 0)
                    {
                        bsUserView.DataSource = db.UserView.OrderByDescending(x => x.Customer);
                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 0)
                    {
                        bsUserView.DataSource = db.UserView.OrderBy(x => x.Customer);
                    }

                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 1)
                    {
                        bsUserView.DataSource = db.UserView.OrderByDescending(x => x.Email);
                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 1)
                    {
                        bsUserView.DataSource = db.UserView.OrderBy(x => x.Email);
                    }

                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 2)
                    {
                        bsUserView.DataSource = db.UserView.OrderByDescending(x => x.Post);
                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 2)
                    {
                        bsUserView.DataSource = db.UserView.OrderBy(x => x.Post);
                    }

                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 3)
                    {
                        bsUserView.DataSource = db.UserView.OrderByDescending(x => x.Division);
                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 3)
                    {
                        bsUserView.DataSource = db.UserView.OrderBy(x => x.Division);
                    }


                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 4)
                    {
                        bsUserView.DataSource = db.UserView.OrderByDescending(x => x.Building);
                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 4)
                    {
                        bsUserView.DataSource = db.UserView.OrderBy(x => x.Building);
                    }


                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 5)
                    {
                        bsUserView.DataSource = db.UserView.OrderByDescending(x => x.Room);
                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 5)
                    {
                        bsUserView.DataSource = db.UserView.OrderBy(x => x.Room);
                    }

                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 6)
                    {
                        bsUserView.DataSource = db.UserView.OrderByDescending(x => x.WorkPhone);
                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 6)
                    {
                        bsUserView.DataSource = db.UserView.OrderBy(x => x.WorkPhone);
                    }

                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 7)
                    {
                        bsUserView.DataSource = db.UserView.OrderByDescending(x => x.MobilePhone);
                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 7)
                    {
                        bsUserView.DataSource = db.UserView.OrderBy(x => x.MobilePhone);
                    }

                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 8)
                    {
                        bsUserView.DataSource = db.UserView.Where(x=> x.Status == "Руководитель").OrderByDescending(x => x.Customer);
                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 8)
                    {
                        bsUserView.DataSource = db.UserView.Where(x => x.Status == "Руководитель").OrderBy(x => x.Customer);
                    }

                }
                else
                {
                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 0)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.Customer.ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderByDescending(x => x.Customer);

                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 0)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.Customer.ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderBy(x => x.Customer);

                    }


                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 1)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.Email.ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderByDescending(x => x.Email);

                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 1)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.Email.ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderBy(x => x.Email);

                    }

                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 2)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.Post.ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderByDescending(x => x.Post);

                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 2)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.Post.ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderBy(x => x.Post);

                    }

                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 3)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.Division.ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderByDescending(x => x.Division);

                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 3)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.Division.ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderBy(x => x.Division);

                    }

                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 4)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.Building.ToString().ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderByDescending(x => x.Building);

                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 4)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.Building.ToString().ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderBy(x => x.Building);

                    }


                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 5)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.Room.ToString().ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderByDescending(x => x.Room);

                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 5)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.Room.ToString().ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderBy(x => x.Room);

                    }



                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 6)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.WorkPhone.ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderByDescending(x => x.WorkPhone);

                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 6)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.WorkPhone.ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderBy(x => x.WorkPhone);

                    }



                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 7)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.MobilePhone.ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderByDescending(x => x.MobilePhone);

                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 7)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.MobilePhone.ToUpper().Contains(mtbSearchUser.Text.ToUpper())).OrderBy(x => x.MobilePhone);

                    }


                    if (cbSortUser.SelectedIndex == 0 && cbSearchUser.SelectedIndex == 8)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.Customer.ToUpper().Contains(mtbSearchUser.Text.ToUpper()) && x.Status == "Руководитель").OrderByDescending(x => x.Customer);

                    }
                    if (cbSortUser.SelectedIndex == 1 && cbSearchUser.SelectedIndex == 8)
                    {

                        bsUserView.DataSource = db.UserView.Where(x => x.Customer.ToUpper().Contains(mtbSearchUser.Text.ToUpper()) && x.Status == "Руководитель").OrderBy(x => x.Customer);

                    }

                }

            }
            BlankPage();
            dgvUserView.ClearSelection();
        }

        private void mtbSearchUser_Enter(object sender, EventArgs e)
        {
            if (mtbSearchUser.Text == "Поиск...")
            {
                mtbSearchUser.Text = "";
                mtbSearchUser.ForeColor = Color.Black;
            }
        }

        private void mtbSearchUser_Leave(object sender, EventArgs e)
        {
            if (mtbSearchUser.Text == "")
            {
                mtbSearchUser.Text = "Поиск...";
                mtbSearchUser.ForeColor = Color.Silver;
            }
        }
        //поиск
    }
}
