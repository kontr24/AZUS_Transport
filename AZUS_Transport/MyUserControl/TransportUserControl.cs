using AZUS_Transport.Classes;
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
    public partial class TransportUserControl : UserControl
    {
        private Cars _Crs;

        public TransportUserControl()
        {
            InitializeComponent();
            LoadDataBase();
        }
        private void BlankPage()
        {
            pbCar.Image = Image.FromFile(@"Images\Cars\NoPhoto.png");

            lModelCar.Text = null;
            lRegisterSign.Text = null;
            lTypeCar.Text = null;
            lStatusCar.Text = null;
            if (bsCarView.Count == 0)
            {
                lTransportNotFound.Visible = true;
            }
            else
            {
                lTransportNotFound.Visible = false;
            }
        }


        public void LoadDataBase()
        {
            cbSearchCar.SelectedIndex = 0;
            cbSortCar.SelectedIndex = 0;
            if (GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA)
            {
                tsbInsertCar.Visible = false;
                tsbDeleteCar.Visible = false;
            }

            try
            {

                using (MyDataModelDataContext db = new MyDataModelDataContext())
                {

                    bsCarView.DataSource = db.CarView.Where(x => x.Model != "—");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (bsCarView.Count != 0)
            {
                //изображение
                try
                {
                    pbCar.SizeMode = PictureBoxSizeMode.StretchImage; // размер изображения по pictureBox
                    if (_Crs.ImageMimeType != null)
                    {
                        pbCar.Image = Image.FromFile(@"Images\Cars\" + _Crs.ImageMimeType);
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
                //изображение

                var crsView = bsCarView.Current as CarView;

                lModelCar.Text = crsView.Model;
                lRegisterSign.Text = crsView.RegisterSign;
                lTypeCar.Text = crsView.TypeCar;
                lStatusCar.Text = crsView.StatusCar;

                tsbDeleteCar.Enabled = true;
                tsbUpdateCar.Enabled = true;
            }
            else
            {
                BlankPage();
                tsbDeleteCar.Enabled = false;
                tsbUpdateCar.Enabled = false;
            }
           

        }


        private void bsCarView_CurrentChanged(object sender, EventArgs e)
        {
            if (bsCarView.Count == 0) return;

            var crsView = bsCarView.Current as CarView;

            using (var db = new MyDataModelDataContext())
            {
                _Crs = db.Cars.FirstOrDefault(x => x.Id == crsView.Id);
            }

        }
        private void tCarView_Tick(object sender, EventArgs e)
        {
            LoadDataBase();
        }


        private void tsbFunctionCar_Click(object sender, EventArgs e)
        {
            pFilters.Visible = !pFilters.Visible;

            if (pFilters.Visible == true)
            {
                dgvCarView.ClearSelection();
                BlankPage();
                tCarView.Stop();

            }
            else
            {
                tCarView.Start();
                mtbSearchCar.Text = "Поиск...";
                mtbSearchCar.ForeColor = Color.Silver;
                LoadDataBase();

            }
        }

        private void tsbInsertCar_Click(object sender, EventArgs e)
        {
            InsertUpdateCarForm form = new InsertUpdateCarForm();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                LoadDataBase();
            }
        }

        private void tsbUpdateCar_Click(object sender, EventArgs e)
        {
            if (_Crs == null) return;
            InsertUpdateCarForm form = new InsertUpdateCarForm(_Crs);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                LoadDataBase();
            }
        }

        private void tsbDeleteCar_Click(object sender, EventArgs e)
        {
            if (_Crs == null) return;
            try
            {
                using (var db = new MyDataModelDataContext())
                {
                    var crs = db.Cars.FirstOrDefault(w => w.Id == _Crs.Id);
                    var mdl = db.ModelCars.FirstOrDefault(x => x.Id == crs.ModelCarID);

                    var msgResult = MessageBox.Show("Вы действительно хотите удалить транспорт " + mdl.Name + " - " + _Crs.RegisterSign + "?", "Удаление транспорта", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


                    if (msgResult == DialogResult.OK)
                    {
                        db.Cars.DeleteOnSubmit(crs);
                        db.SubmitChanges();
                        LoadDataBase();
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Невозможно удалить транспорт, так как необходимо удалить все зависимые записи в таблице 'Заявки'!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCarView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsCarView.Count != 0)
            {
                //изображение
                try
                {
                    pbCar.SizeMode = PictureBoxSizeMode.StretchImage; // размер изображения по pictureBox
                    if (_Crs.ImageMimeType != null)
                    {
                        pbCar.Image = Image.FromFile(@"Images\Cars\" + _Crs.ImageMimeType);
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
                //изображение

                var crsView = bsCarView.Current as CarView;

                lModelCar.Text = crsView.Model;
                lRegisterSign.Text = crsView.RegisterSign;
                lTypeCar.Text = crsView.TypeCar;
                lStatusCar.Text = crsView.StatusCar;
            }
            else
            {
                BlankPage();
            }

        }

        //поиск
        private void cbSearchCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchCar.SelectedIndex == 3)
            {
                cbSearchStatusCar_SelectedIndexChanged(sender, e);
                cbSearchStatusCar.Visible = true;
                cbSearchStatusCar.SelectedIndex = 0;
            }
            else
            {
                cbSearchStatusCar.Visible = false;
            }
            cbSortCar_SelectedIndexChanged(sender, e);
            BlankPage();
            dgvCarView.ClearSelection();
        }

        private void mtbSearchCar_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(mtbSearchCar.Text))
            {
                bsCarView.DataSource = null;
                BlankPage();
            }
            else
            {
                //dgvCarView_CellClick(this.dgvCarView, new DataGridViewCellEventArgs(0, 0));
                using (var db = new MyDataModelDataContext())
                {
                    if (cbSearchCar.SelectedIndex == 0)
                    {
                        bsCarView.DataSource = db.CarView.Where(x => x.TypeCar.ToUpper().Contains(mtbSearchCar.Text.ToUpper()) && x.RegisterSign != "—");

                    }
                    if (cbSearchCar.SelectedIndex == 1)
                    {
                        bsCarView.DataSource = db.CarView.Where(x => x.Model.ToUpper().Contains(mtbSearchCar.Text.ToUpper()) && x.RegisterSign != "—");
                    }
                    if (cbSearchCar.SelectedIndex == 2)
                    {
                        bsCarView.DataSource = db.CarView.Where(x => x.RegisterSign.ToUpper().Contains(mtbSearchCar.Text.ToUpper()) && x.RegisterSign != "—");
                    }
                }
            }
            cbSortCar_SelectedIndexChanged(sender, e);
            BlankPage();
            dgvCarView.ClearSelection();

         
            if (bsCarView.Count == 0)
            {
                tsbDeleteCar.Enabled = false;
                tsbUpdateCar.Enabled = false;
            }
            else {
                tsbDeleteCar.Enabled = true;
                tsbUpdateCar.Enabled = true;
            }
        }

        private void cbSearchStatusCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dgvCarView_CellClick(this.dgvCarView, new DataGridViewCellEventArgs(0, 0));
            using (var db = new MyDataModelDataContext())
            {
                bsCarView.DataSource = db.CarView.Where(x => x.StatusCar.ToUpper().Contains(cbSearchStatusCar.Text.ToUpper()) && x.RegisterSign != "—");
            }
            cbSortCar_SelectedIndexChanged(sender,e);
            BlankPage();
            dgvCarView.ClearSelection();

        
            if (bsCarView.Count == 0)
            {
                tsbDeleteCar.Enabled = false;
                tsbUpdateCar.Enabled = false;
            }
            else
            {
                tsbDeleteCar.Enabled = true;
                tsbUpdateCar.Enabled = true;
            }
        }
        private void cbSortCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dgvCarView_CellClick(this.dgvCarView, new DataGridViewCellEventArgs(0, 0));
            using (var db = new MyDataModelDataContext())
            {

                if (mtbSearchCar.Text == "Поиск...")
                {
                    if (cbSortCar.SelectedIndex == 0 && cbSearchCar.SelectedIndex == 0)
                    {

                        bsCarView.DataSource = db.CarView.Where(x => x.RegisterSign != "—").OrderByDescending(x => x.TypeCar);

                    }
                    if (cbSortCar.SelectedIndex == 1 && cbSearchCar.SelectedIndex == 0)
                    {

                        bsCarView.DataSource = db.CarView.Where(x => x.RegisterSign != "—").OrderBy(x => x.TypeCar);

                    }


                    if (cbSortCar.SelectedIndex == 0 && cbSearchCar.SelectedIndex == 1)
                    {

                        bsCarView.DataSource = db.CarView.Where(x => x.RegisterSign != "—").OrderByDescending(x => x.Model);

                    }
                    if (cbSortCar.SelectedIndex == 1 && cbSearchCar.SelectedIndex == 1)
                    {

                        bsCarView.DataSource = db.CarView.Where(x => x.RegisterSign != "—").OrderBy(x => x.Model);

                    }

                    if (cbSortCar.SelectedIndex == 0 && cbSearchCar.SelectedIndex == 2)
                    {

                        bsCarView.DataSource = db.CarView.Where(x => x.RegisterSign != "—").OrderByDescending(x => x.RegisterSign);

                    }
                    if (cbSortCar.SelectedIndex == 1 && cbSearchCar.SelectedIndex == 2)
                    {

                        bsCarView.DataSource = db.CarView.Where(x => x.RegisterSign != "—").OrderBy(x => x.RegisterSign);

                    }

                }
                else
                {
                    if (cbSortCar.SelectedIndex == 0 && cbSearchCar.SelectedIndex == 0)
                    {

                        bsCarView.DataSource = db.CarView.Where(x => x.TypeCar.ToUpper().Contains(mtbSearchCar.Text.ToUpper()) && x.RegisterSign != "—").OrderByDescending(x => x.TypeCar);

                    }
                    if (cbSortCar.SelectedIndex == 1 && cbSearchCar.SelectedIndex == 0)
                    {

                        bsCarView.DataSource = db.CarView.Where(x => x.TypeCar.ToUpper().Contains(mtbSearchCar.Text.ToUpper()) && x.RegisterSign != "—").OrderBy(x => x.TypeCar);

                    }


                    if (cbSortCar.SelectedIndex == 0 && cbSearchCar.SelectedIndex == 1)
                    {

                        bsCarView.DataSource = db.CarView.Where(x => x.Model.ToUpper().Contains(mtbSearchCar.Text.ToUpper()) && x.RegisterSign != "—").OrderByDescending(x => x.Model);

                    }
                    if (cbSortCar.SelectedIndex == 1 && cbSearchCar.SelectedIndex == 1)
                    {

                        bsCarView.DataSource = db.CarView.Where(x => x.Model.ToUpper().Contains(mtbSearchCar.Text.ToUpper()) && x.RegisterSign != "—").OrderBy(x => x.Model);

                    }

                    if (cbSortCar.SelectedIndex == 0 && cbSearchCar.SelectedIndex == 2)
                    {

                        bsCarView.DataSource = db.CarView.Where(x => x.RegisterSign.ToUpper().Contains(mtbSearchCar.Text.ToUpper()) && x.RegisterSign != "—").OrderByDescending(x => x.RegisterSign);

                    }
                    if (cbSortCar.SelectedIndex == 1 && cbSearchCar.SelectedIndex == 2)
                    {

                        bsCarView.DataSource = db.CarView.Where(x => x.RegisterSign.ToUpper().Contains(mtbSearchCar.Text.ToUpper()) && x.RegisterSign != "—").OrderBy(x => x.RegisterSign);

                    }

                    if (cbSortCar.SelectedIndex == 0 && cbSearchCar.SelectedIndex == 3)
                    {

                        bsCarView.DataSource = db.CarView.Where(x => x.StatusCar.ToUpper().Contains(cbSearchStatusCar.Text.ToUpper()) && x.RegisterSign != "—").OrderByDescending(x => x.StatusCar);

                    }
                    if (cbSortCar.SelectedIndex == 1 && cbSearchCar.SelectedIndex == 3)
                    {

                        bsCarView.DataSource = db.CarView.Where(x => x.StatusCar.ToUpper().Contains(cbSearchStatusCar.Text.ToUpper()) && x.RegisterSign != "—").OrderBy(x => x.StatusCar);

                    }

                }
            }
            BlankPage();
            dgvCarView.ClearSelection();
        }


        private void mtbSearchCar_Enter(object sender, EventArgs e)
        {
            if (mtbSearchCar.Text == "Поиск...")
            {
                mtbSearchCar.Text = "";
                mtbSearchCar.ForeColor = Color.Black;
            }
        }

        private void mtbSearchCar_Leave(object sender, EventArgs e)
        {
            if (mtbSearchCar.Text == "")
            {
                mtbSearchCar.Text = "Поиск...";
                mtbSearchCar.ForeColor = Color.Silver;
            }
        }



        //поиск
    }
}
