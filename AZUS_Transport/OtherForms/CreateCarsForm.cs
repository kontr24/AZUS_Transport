using AZUS_Transport.Classes;
using AZUS_Transport.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AZUS_Transport.OtherForms
{
    public partial class CreateCarsForm : Form
    {
        private Applications _App;

        private ApplicationView _AppView;


        private string _Msg;

        public CreateCarsForm()
        {
            InitializeComponent();
        }

        public CreateCarsForm(Applications app, ApplicationView appView) : this()
        {
            _App = app;
            _AppView = appView;

        }

        private void CreateCarsForm_Load(object sender, EventArgs e)
        {
            Text = "Автомобили";
            _Msg = "Вы назначили автомобиль!";
            try
            {
                using (var db = new MyDataModelDataContext())
                {
                    bsCarView.DataSource = db.CarView.Where(x => x.TypeCar == _AppView.TypeCar && x.Model != "—").Select(x => x.Model).Distinct();

                    //lbModelCarView.ClearSelected();
                    lbModelCarView_SelectedIndexChanged(this, e);
                    lbCarView_SelectedIndexChanged(this, e);



                    cbTypeCars.DataSource = db.TypeCarView;
                    cbTypeCars.SelectedValue = _App.TypeCarID;

                    if (lbModelCarView.Items.Count == 0)
                    {
                        lNoCarStamp.Visible = true;
                        btnChoose.Enabled = false;
                    }
                    else {
                        btnChoose.Enabled = true;
                    }



                    //tbClient.Text = GeneralClass.client;
                    //tbEmail.Text = GeneralClass.email;
                    //tbPost.Text = GeneralClass.post;
                    //tbDivision.Text = GeneralClass.division;
                    //tbDepartment.Text = GeneralClass.department;
                    //tbLocation.Text = GeneralClass.location;
                    //tbWorkPhone.Text = GeneralClass.workPhone;
                    //tbMobilePhone.Text = GeneralClass.mobilePhone;
                    //cbTypeCars.DataSource = db.TypeCarView;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnChoose_Click(object sender, EventArgs e)
        {

            //if (string.IsNullOrEmpty(tbPlaceSubmission.Text) || tbPlaceSubmission.Text == "управление")
            //{
            //    MessageBox.Show("Укажите место подачи транспорта''", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (string.IsNullOrEmpty(tbRoute.Text) || tbRoute.Text == "управление - объекты ПАО 'ППГХО' управление")
            //{
            //    MessageBox.Show("Укажите маршрут''", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            try
            {
                using (var db = new MyDataModelDataContext())
                {
                    var crsView = bsCarModelView.Current as CarModelView;
                    if (GeneralClass.applicationJoin == 0)
                    {
                        
                        var app = db.Applications.FirstOrDefault(w => w.Id == _App.Id);
                        app.CarID = crsView.Id;
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        foreach (var appJoin in db.Applications.Where(x => x.StartDate == _App.StartDate && x.Route == _App.Route && x.TypeCarID == _App.TypeCarID && DateTime.Now - x.DateCreation < new TimeSpan(1, 0, 0, 0) && x.DispatcherNIIAR_StatusDoneID == x.DispatcherNIIAR_StatusDoneID))
                        {
                            appJoin.CarID = crsView.Id;
                        }

                    }
                    //app.TypeCarID = (int)cbTypeCars.SelectedValue;
                    

                    GeneralClass.ModelCar = lbModelCarView.Text;
                    GeneralClass.RegisterSign = lbCarView.Text;


                    //var cln = db.Clients.FirstOrDefault(w => w.Id == _Cln.Id);
                    //cln.SurName = tbClientSurName.Text;
                    //cln.Name = tbClientName.Text;
                    //cln.Patronymic = tbClientPatronomic.Text;
                    //cln.Birthday = dtpClientBirthday.Value;
                    //cln.Phone = tbClientPhone.Text;
                    //cln.ModelCarID = (int)cbClientModelCar.SelectedValue;
                    //cln.AutoRegisterSign = tbClientRegisterSignCar.Text;

                    db.SubmitChanges();

                }
                MessageBox.Show(_Msg, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void lbModelCarView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var db = new MyDataModelDataContext())
                {
                    //var mdl = bsCarView.Current as CarView;

                    bsCarModelView.DataSource = db.CarModelView.Where(x => x.Model == lbModelCarView.Text/* mdl.Model*/ && x.StatusCar == "Доступна");
                    lbCarView_SelectedIndexChanged(this, e);

                    if (lbCarView.Items.Count == 0)
                    {
                        lNoCarRegisterSign.Visible = true;
                        btnChoose.Enabled = false;
                    }
                    else {
                        lNoCarRegisterSign.Visible = false;
                        btnChoose.Enabled = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbCarView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var crsModel = bsCarModelView.Current as CarModelView;

                lSelectedCar.Text = "Вы выбрали: " + lbModelCarView.Text  + " - " + lbCarView.Text;
                pbCar.SizeMode = PictureBoxSizeMode.StretchImage; // размер изображения по pictureBox
                if (crsModel != null && crsModel.ImageData != null)
                {
                   
                    pbCar.Image = Image.FromFile(@"Images\Cars\" + crsModel.ImageData);
                }
                else
                {
                    pbCar.Image = Image.FromFile(@"Images\Cars\NoPhoto.png");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnСancellation_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

