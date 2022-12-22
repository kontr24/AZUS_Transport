using AZUS_Transport.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZUS_Transport.OtherForms
{
    public partial class InsertUpdateCarForm : Form
    {
        private Cars _Crs;
        private ModelCars _MC;

        private string _Msg;
        private string _fileLocation;


        public InsertUpdateCarForm()
        {
            InitializeComponent();
        }

        public InsertUpdateCarForm(Cars crs) : this()
        {
            _Crs = crs;
        }

        private void InsertUpdateCarForm_Load(object sender, EventArgs e)
        {
            pbCar.SizeMode = PictureBoxSizeMode.StretchImage; // размер изображения по pictureBox

            if (_Crs == null)
            {
                Text = "Добавление";
                _Msg = "Данные успешно добавлены!";
                _Crs = new Cars();

                using (var db = new MyDataModelDataContext())
                {
                    cbTransportModel.DataSource = db.ModelCarView.Where(x => x.Model != "—");
                    cbTransportType.DataSource = db.TypeCarView;
                    pbCar.Image = Image.FromFile(@"Images\Cars\NoPhoto.png");
                    rbStatusAvailable.Checked = true;
                    //tbTypeCar.Text = cbTransportType.Text;
                }

                tbRegisterSign.Text = "C777МC 78 RUS ";
                tbRegisterSign.ForeColor = Color.Silver;


            }
            else
            {
                Text = "Редактирование";
                _Msg = "Данные успешно обновлены!";

                using (var db = new MyDataModelDataContext())
                {
                    cbTransportModel.DataSource = db.ModelCarView.Where(x => x.Model != "—");
                    cbTransportType.DataSource = db.TypeCarView;
                    cbTransportModel.SelectedValue = _Crs.ModelCarID;
                    cbTransportType.SelectedValue = _Crs.TypeCarID;
                    tbRegisterSign.Text = _Crs.RegisterSign;
                    //tbTypeCar.Text = cbTransportType.Text;

                    if (_Crs.StatusCarID == 1)
                    {
                        rbStatusAvailable.Checked = true;
                        rbStatusNotAvailable.Checked = false;
                    }
                    if (_Crs.StatusCarID == 2)
                    {

                        rbStatusAvailable.Checked = false;
                        rbStatusNotAvailable.Checked = true;
                    }
                    //изображение
                    try
                    {


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
                }

            }
        }

        private void tbRegisterSign_TextChanged(object sender, EventArgs e)
        {
            using (var db = new MyDataModelDataContext())
            {
                if (_Crs.Id == 0)
                {
                    var crsCheck = db.Cars.FirstOrDefault(x => x.RegisterSign == tbRegisterSign.Text);

                    if (crsCheck != null)
                    {
                        MessageBox.Show("Гос. номер транспорта '" + crsCheck.RegisterSign + "' присутствует в базе данных!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }
        }

        private void btnInsertUpdateCar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbRegisterSign.Text) || tbRegisterSign.Text == "C777МC 78 RUS ")
            {
                MessageBox.Show("Введите гос. номер!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new MyDataModelDataContext())
            {
                if (_Crs.Id == 0)
                {
                    var crsCheck = db.Cars.FirstOrDefault(x => x.RegisterSign == tbRegisterSign.Text);

                    if (crsCheck!= null)
                    {
                        MessageBox.Show("Гос. номер транспорта '" + crsCheck.RegisterSign + "' присутствует в базе данных!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }
            _Crs.TypeCarID = (int)cbTransportType.SelectedValue;
            _Crs.ModelCarID = (int)cbTransportModel.SelectedValue;
            _Crs.RegisterSign = tbRegisterSign.Text;
            if (rbStatusAvailable.Checked == true)
            {
                _Crs.StatusCarID = 1;
            }
            if (rbStatusNotAvailable.Checked == true)
            {
                _Crs.StatusCarID = 2;
            }

            if (_fileLocation != null)
            {
                if (!(File.Exists(@"Images\Cars\" + "\\" + Path.GetFileName(_fileLocation)))) // Проверка, существует ли файл
                {
                    File.Copy(_fileLocation, @"Images\Cars\" + "\\" + Path.GetFileName(_fileLocation));// копирование файла
                }
                _Crs.ImageMimeType = Path.GetFileName(_fileLocation);
            }


            try
            {
                using (var db = new MyDataModelDataContext())
                {

                    if (_Crs.Id == 0)
                    {
                        db.Cars.InsertOnSubmit(_Crs);

                    }
                    else
                    {
                        var crs = db.Cars.FirstOrDefault(w => w.Id == _Crs.Id);

                        crs.TypeCarID = (int)cbTransportType.SelectedValue;
                        crs.ModelCarID = (int)cbTransportModel.SelectedValue;
                        crs.RegisterSign = tbRegisterSign.Text;
                        if (rbStatusAvailable.Checked == true)
                        {
                            crs.StatusCarID = 1;
                        }
                        if (rbStatusNotAvailable.Checked == true)
                        {
                            crs.StatusCarID = 2;
                        }
                        if (_fileLocation != null)
                        {
                            crs.ImageMimeType = Path.GetFileName(_fileLocation);
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
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnDeclineInsertUpdateCar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {
            Bitmap image; //Bitmap для открываемого изображения
            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.InitialDirectory = @"Images\Cars\";// расположение по умолчанию
            open_dialog.RestoreDirectory = true;


            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    _fileLocation = open_dialog.FileName;
                    image = new Bitmap(open_dialog.FileName);
                    //this.pbCar.Size = image.Size;
                    pbCar.SizeMode = PictureBoxSizeMode.StretchImage; // размер изображения по pictureBox

                    pbCar.Image = image;
                    pbCar.Invalidate();

                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTypeCar.Text))
            {
                MessageBox.Show("Введите тип транспорта!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (var db = new MyDataModelDataContext())
                {
                    var selectedIndex = cbTransportType.SelectedIndex;

                    var tp = db.TypeCars.Where(x => x.Name == cbTransportType.Text).FirstOrDefault();

                    tp.Name = tbTypeCar.Text;

                    db.SubmitChanges();
                    cbTransportType.DataSource = db.TypeCarView;
                    cbTransportType.SelectedIndex = selectedIndex;
                    //cbTransportType.Text = tbTypeCar.Text;

                    //InsertUpdateCarForm_Load(sender, e);
                }
                MessageBox.Show("Данные обновлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTransportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbTypeCar.Text = cbTransportType.Text;
        }

        private void btnModelCarChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbModelCarChange.Text))
            {
                MessageBox.Show("Введите название модели!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (var db = new MyDataModelDataContext())
                {
                    var selectedIndex = cbTransportModel.SelectedIndex;

                    var tp = db.ModelCars.Where(x => x.Id == (int)cbTransportModel.SelectedValue).FirstOrDefault();

                    tp.Name = tbModelCarChange.Text;

                    db.SubmitChanges();
                    cbTransportModel.DataSource = db.ModelCarView.Where(x => x.Model != "—");
                    cbTransportModel.SelectedIndex = selectedIndex;

                }
                MessageBox.Show("Данные обновлены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTransportModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbModelCarChange.Text = cbTransportModel.Text;
        }

        private void tbModelCarAdd_TextChanged(object sender, EventArgs e)
        {
            using (var db = new MyDataModelDataContext())
            {
                if (_MC == null)
                {
                    var mdlCheck = db.ModelCars.FirstOrDefault(x => x.Name == tbModelCarAdd.Text);

                    if (mdlCheck != null)
                    {
                        MessageBox.Show("Модель транспорта '" + mdlCheck.Name + "'  присутствует в базе данных!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }

        }

        private void btnModelCarAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbModelCarAdd.Text) || tbModelCarAdd.Text == "BMW E90 ")
            {
                MessageBox.Show("Введите название модели!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new MyDataModelDataContext())
            {
                if (_MC == null)
                {
                    var mdlCheck = db.ModelCars.FirstOrDefault(x => x.Name == tbModelCarAdd.Text);

                    if (mdlCheck != null)
                    {
                        MessageBox.Show("Модель транспорта '" + mdlCheck.Name + "' присутствует в базе данных!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }

           
            _MC = new ModelCars();
            _MC.Name = tbModelCarAdd.Text;
            try
            {
                using (var db = new MyDataModelDataContext())
                {

                    db.ModelCars.InsertOnSubmit(_MC);
                    db.SubmitChanges();
                    cbTransportModel.DataSource = db.ModelCarView.Where(x => x.Model != "—");
                    cbTransportModel.Text = tbModelCarAdd.Text;

                }
                MessageBox.Show(_Msg, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModelCarDelete_Click(object sender, EventArgs e)
        {
            //if (_MC == null) return;

            try
            {
                using (var db = new MyDataModelDataContext())
                {
                    var mdl = db.ModelCars.FirstOrDefault(x => x.Id == (int)cbTransportModel.SelectedValue);
                    if (mdl == null) return;
                    var msgResult = MessageBox.Show("Вы действительно хотите удалить " + mdl.Name + "?", "Удаление модели", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (msgResult == DialogResult.OK)
                    {
                        db.ModelCars.DeleteOnSubmit(mdl);
                        db.SubmitChanges();
                        cbTransportModel.DataSource = db.ModelCarView.Where(x => x.Model != "—");
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Невозможно удалить модель, так как необходимо удалить все зависимые записи в таблице 'Транспорт'!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbRegisterSign_Enter(object sender, EventArgs e)
        {
            if (tbRegisterSign.Text == "C777МC 78 RUS ")
            {
                tbRegisterSign.Text = "";
                tbRegisterSign.ForeColor = Color.Black;

            }
        }

        private void tbRegisterSign_Leave(object sender, EventArgs e)
        {

            if (tbRegisterSign.Text == "")
            {
                tbRegisterSign.Text = "C777МC 78 RUS ";
                tbRegisterSign.ForeColor = Color.Silver;
            }
        }

        private void tbModelCarAdd_Enter(object sender, EventArgs e)
        {

            if (tbModelCarAdd.Text == "BMW E90 ")
            {
                tbModelCarAdd.Text = "";
                tbModelCarAdd.ForeColor = Color.Black;

            }
        }

        private void tbModelCarAdd_Leave(object sender, EventArgs e)
        {
            if (tbModelCarAdd.Text == "")
            {
                tbModelCarAdd.Text = "BMW E90 ";
                tbModelCarAdd.ForeColor = Color.Silver;
            }
        }


    }
}
