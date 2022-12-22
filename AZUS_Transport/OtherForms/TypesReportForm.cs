using AZUS_Transport.Models;
using AZUS_Transport.Classes;
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
    public partial class TypesReportForm : Form
    {
        public TypesReportForm()
        {
            InitializeComponent();
        }

        private void TypesReportForm_Load(object sender, EventArgs e)
        {
            rbWeeklyReport.Checked = true;
            rbWeeklyReport.Text = "Отчёт за неделю " + "(" + String.Format("{0:d} - {0:t}", DateTime.Now.AddDays(-7)) + " — " + String.Format("{0:d} - {0:t}", DateTime.Now) + ")";
            rbReportDay.Text = "Отчёт за сутки " + "(" + String.Format("{0:d} - {0:t}", DateTime.Now.AddDays(-1)) + " — " + String.Format("{0:d} - {0:t}", DateTime.Now) + ")";
        }


        private void btnLssueReport_Click(object sender, EventArgs e)
        {
            using (var db = new MyDataModelDataContext())
            {
                if (GeneralClass.mode == (int)GeneralClass.Status.Admin || GeneralClass.mode == (int)GeneralClass.Status.DispatcherATA ||
                GeneralClass.mode == (int)GeneralClass.Status.DispatcherNIIAR || GeneralClass.mode == (int)GeneralClass.Status.Department)
                {
                    if (rbWeeklyReport.Checked == true)
                    {
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

                        var firstColumnValuesDispatcherNIIARStatusDone = db.ApplicationAgreedView.Where(x => (x.DateCreation > DateTime.Now.AddDays(-7) && x.DispatcherNIIAR_StatusDone != "На рассмотрении") || x.DateCreation.AddDays(1) > DateTime.Now).GroupBy(x => x.DispatcherNIIAR_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDispatcherNIIARStatusDone = firstColumnValuesDispatcherNIIARStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("Согласовано", out agreedDispatcherNIIARStatusDone);
                        int considerationDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIARStatusDone);
                        int rejectedDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIARStatusDone);

                        var firstColumnValuesDispatcherATAStatusDone = db.ApplicationAgreedView.Where(x => (x.DateCreation > DateTime.Now.AddDays(-7) && x.DispatcherNIIAR_StatusDone != "На рассмотрении") || (x.DateCreation.AddDays(1) > DateTime.Now)).GroupBy(x => x.DispatcherATA_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDispatcherATAStatusDone = firstColumnValuesDispatcherATAStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int ExecutedDispatcherATAStatusDone;
                        resultDispatcherATAStatusDone.TryGetValue("Исполнено", out ExecutedDispatcherATAStatusDone);
                        int NotExecutedDispatcherATAStatusDone;
                        resultDispatcherATAStatusDone.TryGetValue("Не исполнено", out NotExecutedDispatcherATAStatusDone);
                        //посчитать количество определенных одинаковых данных
                        var firstColumnValuesSumm = db.ApplicationAgreedView.Where(x => x.DateCreation > DateTime.Now.AddDays(-7)).Count();
                        var firstColumnValuesTimeUpSumm = db.ApplicationAgreedView.Where(x => x.DateCreation > DateTime.Now.AddDays(-7) && (x.DateCreation.AddDays(1) < DateTime.Now && (x.DirectorStatusDone == "На рассмотрении" || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))).Count();

                        report.Load(@"Reports\ApplicationWeekReportAdmin.frx");

                        report.SetParameterValue("dateTimesPeriod", String.Format("{0:d} - {0:t}", DateTime.Now.AddDays(-7)) + " — " + String.Format("{0:d} - {0:t}", DateTime.Now));
                        report.SetParameterValue("dateCreation", String.Format("{0:d} - {0:t}", DateTime.Now));

                        report.SetParameterValue("considerationDirector", considerationDirector);
                        report.SetParameterValue("considerationEconomist", considerationEconomist);
                        report.SetParameterValue("considerationDepartment", considerationDepartment);
                        report.SetParameterValue("considerationDispatcherNIIAR", considerationDispatcherNIIARStatusDone);
                        report.SetParameterValue("rejectedDirector", rejectedDirector);
                        report.SetParameterValue("rejectedEconomist", rejectedEconomist);
                        report.SetParameterValue("rejectedDepartment", rejectedDepartment);
                        report.SetParameterValue("rejectedDispatcherNIIAR", rejectedDispatcherNIIARStatusDone);
                        report.SetParameterValue("agreedDirector", agreedDirector);
                        report.SetParameterValue("agreedEconomist", agreedEconomist);
                        report.SetParameterValue("agreedDepartment", agreedDepartment);
                        report.SetParameterValue("agreedDispatcherNIIAR", agreedDispatcherNIIARStatusDone);

                        report.SetParameterValue("executedDispatcherATA", ExecutedDispatcherATAStatusDone);
                        report.SetParameterValue("notExecutedDispatcherAT", NotExecutedDispatcherATAStatusDone);

                        report.SetParameterValue("totalApplications", firstColumnValuesSumm);
                        report.SetParameterValue("weeklyReport", firstColumnValuesTimeUpSumm);

                        report.Show();
                    }
                    else
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

                        report.Load(@"Reports\ApplicationDayReportAdmin.frx");

                        report.SetParameterValue("dateTimesPeriod", String.Format("{0:d} - {0:t}", DateTime.Now.AddDays(-1)) + " — " + String.Format("{0:d} - {0:t}", DateTime.Now));
                        report.SetParameterValue("dateCreation", String.Format("{0:d} - {0:t}", DateTime.Now));

                        report.SetParameterValue("considerationDirector", considerationDirector);
                        report.SetParameterValue("considerationEconomist", considerationEconomist);
                        report.SetParameterValue("considerationDepartment", considerationDepartment);
                        report.SetParameterValue("considerationDispatcherNIIAR", considerationDispatcherNIIARStatusDone);
                        report.SetParameterValue("rejectedDirector", rejectedDirector);
                        report.SetParameterValue("rejectedEconomist", rejectedEconomist);
                        report.SetParameterValue("rejectedDepartment", rejectedDepartment);
                        report.SetParameterValue("rejectedDispatcherNIIAR", rejectedDispatcherNIIARStatusDone);
                        report.SetParameterValue("agreedDirector", agreedDirector);
                        report.SetParameterValue("agreedEconomist", agreedEconomist);
                        report.SetParameterValue("agreedDepartment", agreedDepartment);
                        report.SetParameterValue("agreedDispatcherNIIAR", agreedDispatcherNIIARStatusDone);

                        report.SetParameterValue("executedDispatcherATA", ExecutedDispatcherATAStatusDone);
                        report.SetParameterValue("notExecutedDispatcherAT", NotExecutedDispatcherATAStatusDone);

                        report.SetParameterValue("totalApplications", firstColumnValuesSumm);

                        report.Show();
                    }
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.Director)
                {
                    if (rbWeeklyReport.Checked == true)
                    {
                        var usrDrc = db.UserView.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                        var usrEcn = db.UserView.FirstOrDefault(x => x.Division == usrDrc.Division && x.Status == "Экономист");

                        if (usrEcn == null)
                        {
                            MessageBox.Show("Экономист вашего подразделения не зарегистрирован в системе! Вы сможете оформить отчёт только после его регистрации!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //посчитать количество определенных одинаковых данных
                        var firstColumnValuesDirector = db.ApplicationAgreedView.Where(x => ((x.DateCreation > DateTime.Now.AddDays(-7) && x.DirectorStatusDone != "На рассмотрении") || x.DateCreation.AddDays(1) > DateTime.Now) && x.Director == usrDrc.Customer).GroupBy(x => x.DirectorStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDirector = firstColumnValuesDirector.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDirector;
                        resultDirector.TryGetValue("Согласовано", out agreedDirector);
                        int considerationDirector;
                        resultDirector.TryGetValue("На рассмотрении", out considerationDirector);
                        int rejectedDirector;
                        resultDirector.TryGetValue("Отклонена", out rejectedDirector);

                        var firstColumnValuesEconomist = db.ApplicationAgreedView.Where(x => ((x.DateCreation > DateTime.Now.AddDays(-7) && x.EconomistStatusDone != "На рассмотрении") || x.DateCreation.AddDays(1) > DateTime.Now) && x.Economist == usrEcn.Customer).GroupBy(x => x.EconomistStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultEconomist = firstColumnValuesEconomist.ToDictionary(arg => arg.Key, arg => arg.Count);


                        int agreedEconomist;
                        resultEconomist.TryGetValue("Согласовано", out agreedEconomist);
                        int considerationEconomist;
                        resultEconomist.TryGetValue("На рассмотрении", out considerationEconomist);
                        int rejectedEconomist;
                        resultEconomist.TryGetValue("Отклонена", out rejectedEconomist);

                        var firstColumnValuesDepartment = db.ApplicationAgreedView.Where(x => ((x.DateCreation > DateTime.Now.AddDays(-7) && x.DepartmentStatusDone != "На рассмотрении" && (x.IntercityСity != true || x.DaysWorkerOrWeekend != true)) || (x.DateCreation.AddDays(1) > DateTime.Now && (x.IntercityСity != true || x.DaysWorkerOrWeekend != true))) && x.Director == usrDrc.Customer).GroupBy(x => x.DepartmentStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDepartment = firstColumnValuesDepartment.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDepartment;
                        resultDepartment.TryGetValue("Согласовано", out agreedDepartment);
                        int considerationDepartment;
                        resultDepartment.TryGetValue("На рассмотрении", out considerationDepartment);
                        int rejectedDepartment;
                        resultDepartment.TryGetValue("Отклонена", out rejectedDepartment);

                        var firstColumnValuesDispatcherNIIARStatusDone = db.ApplicationAgreedView.Where(x => ((x.DateCreation > DateTime.Now.AddDays(-7) && x.DispatcherNIIAR_StatusDone != "На рассмотрении") || x.DateCreation.AddDays(1) > DateTime.Now) && x.Director == usrDrc.Customer).GroupBy(x => x.DispatcherNIIAR_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDispatcherNIIARStatusDone = firstColumnValuesDispatcherNIIARStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("Согласовано", out agreedDispatcherNIIARStatusDone);
                        int considerationDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIARStatusDone);
                        int rejectedDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIARStatusDone);

                        var firstColumnValuesDispatcherATAStatusDone = db.ApplicationAgreedView.Where(x => ((x.DateCreation > DateTime.Now.AddDays(-7) && x.DispatcherNIIAR_StatusDone != "На рассмотрении") || (x.DateCreation.AddDays(1) > DateTime.Now)) && x.Director == usrDrc.Customer).GroupBy(x => x.DispatcherATA_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDispatcherATAStatusDone = firstColumnValuesDispatcherATAStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int ExecutedDispatcherATAStatusDone;
                        resultDispatcherATAStatusDone.TryGetValue("Исполнено", out ExecutedDispatcherATAStatusDone);
                        int NotExecutedDispatcherATAStatusDone;
                        resultDispatcherATAStatusDone.TryGetValue("Не исполнено", out NotExecutedDispatcherATAStatusDone);
                        //посчитать количество определенных одинаковых данных
                        var firstColumnValuesSumm = db.ApplicationAgreedView.Where(x => x.DateCreation > DateTime.Now.AddDays(-7) && x.Director == usrDrc.Customer).Count();
                        var firstColumnValuesTimeUpSumm = db.ApplicationAgreedView.Where(x => (x.DateCreation > DateTime.Now.AddDays(-7) && (x.DateCreation.AddDays(1) < DateTime.Now && (x.DirectorStatusDone == "На рассмотрении" || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))) && x.Director == usrDrc.Customer).Count();

                        report.Load(@"Reports\ApplicationWeekReportDirector.frx");

                        report.SetParameterValue("dateTimesPeriod", String.Format("{0:d} - {0:t}", DateTime.Now.AddDays(-7)) + " — " + String.Format("{0:d} - {0:t}", DateTime.Now));
                        report.SetParameterValue("dateCreation", String.Format("{0:d} - {0:t}", DateTime.Now));


                        report.SetParameterValue("considerationDirector", considerationDirector);
                        report.SetParameterValue("considerationEconomist", considerationEconomist);
                        report.SetParameterValue("considerationDepartment", considerationDepartment);
                        report.SetParameterValue("considerationDispatcherNIIAR", considerationDispatcherNIIARStatusDone);
                        report.SetParameterValue("rejectedDirector", rejectedDirector);
                        report.SetParameterValue("rejectedEconomist", rejectedEconomist);
                        report.SetParameterValue("rejectedDepartment", rejectedDepartment);
                        report.SetParameterValue("rejectedDispatcherNIIAR", rejectedDispatcherNIIARStatusDone);
                        report.SetParameterValue("agreedDirector", agreedDirector);
                        report.SetParameterValue("agreedEconomist", agreedEconomist);
                        report.SetParameterValue("agreedDepartment", agreedDepartment);
                        report.SetParameterValue("agreedDispatcherNIIAR", agreedDispatcherNIIARStatusDone);

                        report.SetParameterValue("executedDispatcherATA", ExecutedDispatcherATAStatusDone);
                        report.SetParameterValue("notExecutedDispatcherAT", NotExecutedDispatcherATAStatusDone);

                        report.SetParameterValue("totalApplications", firstColumnValuesSumm);
                        report.SetParameterValue("weeklyReport", firstColumnValuesTimeUpSumm);

                        report.Show();
                    }
                    else
                    {
                        var usrDrc = db.UserView.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                        var usrEcn = db.UserView.FirstOrDefault(x => x.Division == usrDrc.Division && x.Status == "Экономист");

                        if (usrEcn == null)
                        {
                            MessageBox.Show("Экономист вашего подразделения не зарегистрирован в системе! Вы сможете оформить отчёт только после его регистрации!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                        report.Load(@"Reports\ApplicationDayReportDirector.frx");

                        report.SetParameterValue("dateTimesPeriod", String.Format("{0:d} - {0:t}", DateTime.Now.AddDays(-1)) + " — " + String.Format("{0:d} - {0:t}", DateTime.Now));
                        report.SetParameterValue("dateCreation", String.Format("{0:d} - {0:t}", DateTime.Now));

                        report.SetParameterValue("considerationDirector", considerationDirector);
                        report.SetParameterValue("considerationEconomist", considerationEconomist);
                        report.SetParameterValue("considerationDepartment", considerationDepartment);
                        report.SetParameterValue("considerationDispatcherNIIAR", considerationDispatcherNIIARStatusDone);
                        report.SetParameterValue("rejectedDirector", rejectedDirector);
                        report.SetParameterValue("rejectedEconomist", rejectedEconomist);
                        report.SetParameterValue("rejectedDepartment", rejectedDepartment);
                        report.SetParameterValue("rejectedDispatcherNIIAR", rejectedDispatcherNIIARStatusDone);
                        report.SetParameterValue("agreedDirector", agreedDirector);
                        report.SetParameterValue("agreedEconomist", agreedEconomist);
                        report.SetParameterValue("agreedDepartment", agreedDepartment);
                        report.SetParameterValue("agreedDispatcherNIIAR", agreedDispatcherNIIARStatusDone);

                        report.SetParameterValue("executedDispatcherATA", ExecutedDispatcherATAStatusDone);
                        report.SetParameterValue("notExecutedDispatcherAT", NotExecutedDispatcherATAStatusDone);

                        report.SetParameterValue("totalApplications", firstColumnValuesSumm);

                        report.Show();
                    }
                }
                if (GeneralClass.mode == (int)GeneralClass.Status.Economist)
                {
                    if (rbWeeklyReport.Checked == true)
                    {
                        var usrEcn = db.UserView.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                        var usrDrc = db.UserView.FirstOrDefault(x => x.Division == usrEcn.Division && x.Status == "Руководитель");
                        if (usrDrc == null)
                        {
                            MessageBox.Show("Руководитель вашего подразделения не зарегистрирован в системе! Вы сможете оформить отчёт только после его регистрации!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //посчитать количество определенных одинаковых данных
                        var firstColumnValuesDirector = db.ApplicationAgreedView.Where(x => ((x.DateCreation > DateTime.Now.AddDays(-7) && x.DirectorStatusDone != "На рассмотрении") || x.DateCreation.AddDays(1) > DateTime.Now) && x.Director == usrDrc.Customer).GroupBy(x => x.DirectorStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDirector = firstColumnValuesDirector.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDirector;
                        resultDirector.TryGetValue("Согласовано", out agreedDirector);
                        int considerationDirector;
                        resultDirector.TryGetValue("На рассмотрении", out considerationDirector);
                        int rejectedDirector;
                        resultDirector.TryGetValue("Отклонена", out rejectedDirector);

                        var firstColumnValuesEconomist = db.ApplicationAgreedView.Where(x => ((x.DateCreation > DateTime.Now.AddDays(-7) && x.EconomistStatusDone != "На рассмотрении") || x.DateCreation.AddDays(1) > DateTime.Now) && x.Economist == usrEcn.Customer).GroupBy(x => x.EconomistStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultEconomist = firstColumnValuesEconomist.ToDictionary(arg => arg.Key, arg => arg.Count);


                        int agreedEconomist;
                        resultEconomist.TryGetValue("Согласовано", out agreedEconomist);
                        int considerationEconomist;
                        resultEconomist.TryGetValue("На рассмотрении", out considerationEconomist);
                        int rejectedEconomist;
                        resultEconomist.TryGetValue("Отклонена", out rejectedEconomist);

                        var firstColumnValuesDepartment = db.ApplicationAgreedView.Where(x => ((x.DateCreation > DateTime.Now.AddDays(-7) && x.DepartmentStatusDone != "На рассмотрении" && (x.IntercityСity != true || x.DaysWorkerOrWeekend != true)) || (x.DateCreation.AddDays(1) > DateTime.Now && (x.IntercityСity != true || x.DaysWorkerOrWeekend != true))) && x.Economist == usrEcn.Customer).GroupBy(x => x.DepartmentStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDepartment = firstColumnValuesDepartment.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDepartment;
                        resultDepartment.TryGetValue("Согласовано", out agreedDepartment);
                        int considerationDepartment;
                        resultDepartment.TryGetValue("На рассмотрении", out considerationDepartment);
                        int rejectedDepartment;
                        resultDepartment.TryGetValue("Отклонена", out rejectedDepartment);

                        var firstColumnValuesDispatcherNIIARStatusDone = db.ApplicationAgreedView.Where(x => ((x.DateCreation > DateTime.Now.AddDays(-7) && x.DispatcherNIIAR_StatusDone != "На рассмотрении") || x.DateCreation.AddDays(1) > DateTime.Now) && x.Economist == usrEcn.Customer).GroupBy(x => x.DispatcherNIIAR_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDispatcherNIIARStatusDone = firstColumnValuesDispatcherNIIARStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("Согласовано", out agreedDispatcherNIIARStatusDone);
                        int considerationDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIARStatusDone);
                        int rejectedDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIARStatusDone);

                        var firstColumnValuesDispatcherATAStatusDone = db.ApplicationAgreedView.Where(x => ((x.DateCreation > DateTime.Now.AddDays(-7) && x.DispatcherNIIAR_StatusDone != "На рассмотрении") || (x.DateCreation.AddDays(1) > DateTime.Now)) && x.Economist == usrEcn.Customer).GroupBy(x => x.DispatcherATA_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDispatcherATAStatusDone = firstColumnValuesDispatcherATAStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int ExecutedDispatcherATAStatusDone;
                        resultDispatcherATAStatusDone.TryGetValue("Исполнено", out ExecutedDispatcherATAStatusDone);
                        int NotExecutedDispatcherATAStatusDone;
                        resultDispatcherATAStatusDone.TryGetValue("Не исполнено", out NotExecutedDispatcherATAStatusDone);
                        //посчитать количество определенных одинаковых данных
                        var firstColumnValuesSumm = db.ApplicationAgreedView.Where(x => x.DateCreation > DateTime.Now.AddDays(-7) && x.Economist == usrEcn.Customer).Count();
                        var firstColumnValuesTimeUpSumm = db.ApplicationAgreedView.Where(x => (x.DateCreation > DateTime.Now.AddDays(-7) && (x.DateCreation.AddDays(1) < DateTime.Now && (x.DirectorStatusDone == "На рассмотрении" || x.EconomistStatusDone == "На рассмотрении" || x.DepartmentStatusDone == "На рассмотрении" || x.DispatcherNIIAR_StatusDone == "На рассмотрении"))) && x.Economist == usrEcn.Customer).Count();

                        report.Load(@"Reports\ApplicationWeekReportEconomist.frx");

                        report.SetParameterValue("dateTimesPeriod", String.Format("{0:d} - {0:t}", DateTime.Now.AddDays(-7)) + " — " + String.Format("{0:d} - {0:t}", DateTime.Now));
                        report.SetParameterValue("dateCreation", String.Format("{0:d} - {0:t}", DateTime.Now));


                        report.SetParameterValue("considerationDirector", considerationDirector);
                        report.SetParameterValue("considerationEconomist", considerationEconomist);
                        report.SetParameterValue("considerationDepartment", considerationDepartment);
                        report.SetParameterValue("considerationDispatcherNIIAR", considerationDispatcherNIIARStatusDone);
                        report.SetParameterValue("rejectedDirector", rejectedDirector);
                        report.SetParameterValue("rejectedEconomist", rejectedEconomist);
                        report.SetParameterValue("rejectedDepartment", rejectedDepartment);
                        report.SetParameterValue("rejectedDispatcherNIIAR", rejectedDispatcherNIIARStatusDone);
                        report.SetParameterValue("agreedDirector", agreedDirector);
                        report.SetParameterValue("agreedEconomist", agreedEconomist);
                        report.SetParameterValue("agreedDepartment", agreedDepartment);
                        report.SetParameterValue("agreedDispatcherNIIAR", agreedDispatcherNIIARStatusDone);

                        report.SetParameterValue("executedDispatcherATA", ExecutedDispatcherATAStatusDone);
                        report.SetParameterValue("notExecutedDispatcherAT", NotExecutedDispatcherATAStatusDone);

                        report.SetParameterValue("totalApplications", firstColumnValuesSumm);
                        report.SetParameterValue("weeklyReport", firstColumnValuesTimeUpSumm);

                        report.Show();
                    }
                    else
                    {
                        var usrEcn = db.UserView.FirstOrDefault(x => x.Id == GeneralClass.UserID);
                        var usrDrc = db.UserView.FirstOrDefault(x => x.Division == usrEcn.Division && x.Status == "Руководитель");
                        if (usrDrc == null)
                        {
                            MessageBox.Show("Руководитель вашего подразделения не зарегистрирован в системе! Вы сможете оформить отчёт только после его регистрации!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                        var firstColumnValuesDepartment = db.ApplicationAgreedView.Where(x => (x.DateCreation.AddDays(1) > DateTime.Now && (x.IntercityСity != true || x.DaysWorkerOrWeekend != true)) && x.Economist == usrEcn.Customer).GroupBy(x => x.DepartmentStatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDepartment = firstColumnValuesDepartment.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDepartment;
                        resultDepartment.TryGetValue("Согласовано", out agreedDepartment);
                        int considerationDepartment;
                        resultDepartment.TryGetValue("На рассмотрении", out considerationDepartment);
                        int rejectedDepartment;
                        resultDepartment.TryGetValue("Отклонена", out rejectedDepartment);

                        var firstColumnValuesDispatcherNIIARStatusDone = db.ApplicationAgreedView.Where(x => (x.DateCreation.AddDays(1) > DateTime.Now) && x.Economist == usrEcn.Customer).GroupBy(x => x.DispatcherNIIAR_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDispatcherNIIARStatusDone = firstColumnValuesDispatcherNIIARStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int agreedDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("Согласовано", out agreedDispatcherNIIARStatusDone);
                        int considerationDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("На рассмотрении", out considerationDispatcherNIIARStatusDone);
                        int rejectedDispatcherNIIARStatusDone;
                        resultDispatcherNIIARStatusDone.TryGetValue("Отклонена", out rejectedDispatcherNIIARStatusDone);

                        var firstColumnValuesDispatcherATAStatusDone = db.ApplicationAgreedView.Where(x => (x.DateCreation.AddDays(1) > DateTime.Now) && x.Economist == usrEcn.Customer).GroupBy(x => x.DispatcherATA_StatusDone).Where(x => x.Key != null).Select(x => new { x.Key, Count = x.Count() });
                        Dictionary<string, int> resultDispatcherATAStatusDone = firstColumnValuesDispatcherATAStatusDone.ToDictionary(arg => arg.Key, arg => arg.Count);

                        int ExecutedDispatcherATAStatusDone;
                        resultDispatcherATAStatusDone.TryGetValue("Исполнено", out ExecutedDispatcherATAStatusDone);
                        int NotExecutedDispatcherATAStatusDone;
                        resultDispatcherATAStatusDone.TryGetValue("Не исполнено", out NotExecutedDispatcherATAStatusDone);
                        //посчитать количество определенных одинаковых данных
                        var firstColumnValuesSumm = db.ApplicationAgreedView.Where(x => x.DateCreation.AddDays(1) > DateTime.Now && x.Economist == usrEcn.Customer).Count();

                        report.Load(@"Reports\ApplicationDayReportEconomist.frx");

                        report.SetParameterValue("dateTimesPeriod", String.Format("{0:d} - {0:t}", DateTime.Now.AddDays(-1)) + " — " + String.Format("{0:d} - {0:t}", DateTime.Now));
                        report.SetParameterValue("dateCreation", String.Format("{0:d} - {0:t}", DateTime.Now));

                        report.SetParameterValue("considerationDirector", considerationDirector);
                        report.SetParameterValue("considerationEconomist", considerationEconomist);
                        report.SetParameterValue("considerationDepartment", considerationDepartment);
                        report.SetParameterValue("considerationDispatcherNIIAR", considerationDispatcherNIIARStatusDone);
                        report.SetParameterValue("rejectedDirector", rejectedDirector);
                        report.SetParameterValue("rejectedEconomist", rejectedEconomist);
                        report.SetParameterValue("rejectedDepartment", rejectedDepartment);
                        report.SetParameterValue("rejectedDispatcherNIIAR", rejectedDispatcherNIIARStatusDone);
                        report.SetParameterValue("agreedDirector", agreedDirector);
                        report.SetParameterValue("agreedEconomist", agreedEconomist);
                        report.SetParameterValue("agreedDepartment", agreedDepartment);
                        report.SetParameterValue("agreedDispatcherNIIAR", agreedDispatcherNIIARStatusDone);

                        report.SetParameterValue("executedDispatcherATA", ExecutedDispatcherATAStatusDone);
                        report.SetParameterValue("notExecutedDispatcherAT", NotExecutedDispatcherATAStatusDone);

                        report.SetParameterValue("totalApplications", firstColumnValuesSumm);

                        report.Show();
                    }
                }
            }

            Close();
        }


    }
}
