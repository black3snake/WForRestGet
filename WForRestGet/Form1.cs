using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WForRestGet.DataModel;
using WForRestGet.Properties;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using NLog;
using System.Diagnostics;
using System.IO;

namespace WForRestGet
{
    public partial class Form1 : Form
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        Point lastPoint;
        public string sServiceUser { get; set; }
        public string sServicePassword { get; set; }
        public string sServiceDomain { get; set; }
        public bool statusRimsTest = false;
        public bool statusDBTest = false;

        Dictionary<string, string> DLeaveType = new Dictionary<string, string>()
        {
            {"VC","Отпуск"},
            {"SL","Больничный"},
            {"BT","Командировка"},
            {"DV","Декретный отпуск"}
        };
        Dictionary<string, int> DLeaveType2C = new Dictionary<string, int>()
        {
            {"VC", 1},
            {"SL", 2},
            {"BT", 3},
            {"DV", 4}
        };

        List<Datauser> Datauserslist = new List<Datauser>();

        // Структура формирование эл. ответа в Exchange
        struct OutOfOffice
        {
            public string leaveName { get; set; }
            public DateTime DateStart { get; set; }
            public DateTime DateEnd { get; set; }
            public string DS { get; set; }
            public string DE;
            public string FIO { get; set; }

            public OutOfOffice(string leaveName, DateTime DateStart, DateTime DateEnd, string FIO)
            {
                this.leaveName = leaveName;
                this.DateStart = DateStart;
                this.DateEnd = DateEnd;
                this.DS = "";
                this.DE = "";
                this.FIO = FIO;
            }

            public string As() {

                DS = DateStart.ToString().Remove(DateStart.ToString().IndexOf(" "));
                DE = DateEnd.ToString().Remove(DateStart.ToString().IndexOf(" "));

                if (leaveName == "VC")
                {
                    return leaveName = $"<html><body><b>Добрый день.</b><br> В данный момент я нахожусь в отпуске c {DS} по {DE}<br>    С уважением {FIO}</body></html>";
                }
                else if (leaveName == "SL")
                {
                    return leaveName = $"<html><body><b>Добрый день.</b><br> В данный момент я нахожусь на больничном c {DS} по {DE}<br>    С уважением {FIO}</body></html>";
                }
                else if (leaveName == "BT")
                {
                    return leaveName = $"<html><body><b>Добрый день.</b><br> В данный момент я нахожусь в командировке c {DS} по {DE}<br>   С уважением {FIO}</body></html>";
                }
                else if (leaveName == "DV")
                {
                    return leaveName = $"<html><body><b>Добрый день.</b><br> В данный момент я нахожусь в декретном отпуске c {DS} по {DE}<br>  С уважением {FIO}</body></html>";
                }
                else
                    return leaveName;

            }
        }



        public Form1()
        {
            InitializeComponent();

            // Описание событий
            picBoxXclose.MouseEnter += (s, a) => { picBoxXclose.BackgroundImage = Resources.x_red; };
            picBoxXclose.MouseLeave += (s, a) => { picBoxXclose.BackgroundImage = Resources.square_x_icon_215388; };
            picBoxXclose.Click += (s, a) => { this.Close(); };

            panelTop.MouseDown += (s, a) => { lastPoint = new Point(a.X, a.Y); };
            panelTop.MouseMove += (s, a) => {
                if (a.Button == MouseButtons.Left)
                {
                    this.Left += a.X - lastPoint.X;
                    this.Top += a.Y - lastPoint.Y;
                }
            };

            #region ListView - Инициализация

            ColumnHeader header1, header2, header3, header4, header5, header6;
            header1 = new ColumnHeader();  // 
            header2 = new ColumnHeader();
            header3 = new ColumnHeader();
            header4 = new ColumnHeader();
            header5 = new ColumnHeader();
            header6 = new ColumnHeader();

            header1.Text = "AccountName";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 90;

            header2.Text = "FullName";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 180;

            header3.Text = "City";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 110;

            header4.Text = "LT";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 110;

            header5.Text = "LStart";
            header5.TextAlign = HorizontalAlignment.Left;
            header5.Width = 70;

            header6.Text = "LEnd";
            header6.TextAlign = HorizontalAlignment.Left;
            header6.Width = 70;


            listView1.Columns.Add(header1);
            listView1.Columns.Add(header2);
            listView1.Columns.Add(header3);
            listView1.Columns.Add(header4);
            listView1.Columns.Add(header5);
            listView1.Columns.Add(header6);
            //listView1.Columns[0].Width = 200;
            listView1.View = View.Details;

            #endregion

            #region ListView - События выпадающего меню
            listView1.MouseUp += (s, a) => {
                if (a.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                }
            };

            toolStripMenuItem1.Click += (s, a) => {
                foreach (ListViewItem item in listView1.Items)
                {
                    item.Selected = true;
                }
            };

            toolStripMenuItem2.Click += (s, a) =>
            {
                if (listView1.SelectedItems.Count > 1)
                {
                    string manyCl = "";
                    foreach (ListViewItem lV in listView1.SelectedItems)
                    {
                        if (lV.SubItems.Count > 1)
                        {
                            manyCl += lV.Text + " : " + lV.SubItems[1].Text + " : " +
                            lV.SubItems[2].Text + " : " + lV.SubItems[3].Text + " : " + lV.SubItems[4].Text + " - " +
                            lV.SubItems[5].Text + Environment.NewLine;
                        }
                        else
                        {
                            manyCl += lV.Text + " : " + lV.SubItems[1].Text + " : " +
                            lV.SubItems[2].Text + " : " + lV.SubItems[3].Text + " : " + lV.SubItems[4].Text + " - " +
                            lV.SubItems[5].Text + Environment.NewLine;
                        }
                    }
                    Clipboard.SetText(manyCl);

                }
                else if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Ничего не выбрано", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Clipboard.SetText(listView1.SelectedItems[0].Text);
                }
            };
            #endregion

        }

        // TEST connection RIMS
        private async void btnTestRims_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBLogin.Text) | string.IsNullOrEmpty(txtBPass.Text) | string.IsNullOrEmpty(txtBDomen.Text))
            {
                MessageBox.Show("Заполни все поля Login, Password, Domain!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sServiceUser = txtBLogin.Text.Trim();
            sServicePassword = txtBPass.Text.Trim();
            sServiceDomain = txtBDomen.Text.Trim();
            // NTLM Secured URL
            var uri = new Uri("https://fim.sib.rual.ru/Export/api/Person/EmployeesAccountsOdata?%24filter=Domain%20eq%20'IE.Corp'%20&%24top=1");
            // Create a new Credential
            var credentialsCache = new CredentialCache();
            credentialsCache.Add(uri, "NTLM", new NetworkCredential(
                sServiceUser, sServicePassword, sServiceDomain));

            var handler = new HttpClientHandler() { Credentials = credentialsCache, PreAuthenticate = true };
            var httpClient = new HttpClient(handler) { Timeout = new TimeSpan(0, 0, 10) };

            var response = await httpClient.GetAsync(uri);

            var result = await response.Content.ReadAsStringAsync();

            //txtBoxConsole.AppendText(result + Environment.NewLine);
            //Console.WriteLine(result);
            if (response.IsSuccessStatusCode)
            {
                txtBoxConsole.AppendText($"Статус проверки REST Get: {response.ReasonPhrase}" + Environment.NewLine);
                picBoxTestRIMS.BackgroundImage = Resources.Ok_27007;
                statusRimsTest = true;
            } else
            {
                txtBoxConsole.AppendText($"Статус проверки REST Get: {response.ReasonPhrase}" + Environment.NewLine);
                picBoxTestRIMS.BackgroundImage = Resources.Close_2_26986;
                statusRimsTest = false;
            }

        }

        // TEST connection MS SQL
        private void btnTestDB_Click(object sender, EventArgs e)
        {
            using (DataModelContext context = new DataModelContext())
            {
                IEnumerable<Leave> listsLEnum = context.Leaves;
                var countDL = listsLEnum.ToList().LongCount();

                //var listsL = context.Leaves.ToList();
                //var countDL = listsL.LongCount();

                IEnumerable<Datauser> listsDEnum = context.Datausers;
                var countDD = listsDEnum.ToList().LongCount();


                txtBoxConsole.AppendText($"Quantity items in DB Datausers: {countDD}" + Environment.NewLine);

                if (countDL > 0)
                {
                    picBoxTestDB.BackgroundImage = Resources.Ok_27007;
                    statusDBTest = true;
                } else
                {
                    picBoxTestDB.BackgroundImage = Resources.Close_2_26986;
                    statusDBTest = false;
                }
            }

            using (DataModelContext contextOld = new DataModelContext())
            {
                var usersOld = contextOld.Datausers.Where(p => p.LeaveEnd <= DateTime.Now.AddHours(-24)).ToList();
                foreach (var uOld in usersOld)
                {
                    txtBoxConsole.AppendText($"{uOld.LastName} {uOld.FirstName} {uOld.MiddleName} :: {uOld.LeaveStart} -  {uOld.LeaveEnd}" + Environment.NewLine);
                    contextOld.Datausers.Remove(uOld);
                    contextOld.SaveChanges();

                }
                txtBoxConsole.AppendText($"Quantity olds: {usersOld.Count}" + Environment.NewLine);
            }

            using (DataModelContext status4 = new DataModelContext())
            {
                var listsC = status4.Datausers.Where(l => l.AnswerId == 4).ToList();
                txtBoxConsole.AppendText($"Пользователей со своим установленным статусом автоответа: {listsC.Count()}" + Environment.NewLine);


                // проверим на Null и при нахождении заменим на 1
                var listsNull = status4.Datausers.Where(l => l.AnswerId == null).ToList();
                foreach (var item in listsNull)
                {
                    item.AnswerId = 1;
                    status4.SaveChanges();
                }
            }

        }

        //Eye hidden
        private void picBoxEye_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBPass.Text) && txtBPass.UseSystemPasswordChar)
            {
                txtBPass.UseSystemPasswordChar = false;
                picBoxEye.BackgroundImage = Resources.eye_icon_224636;
                txtBPass.Focus();
            }
            else
            {
                txtBPass.UseSystemPasswordChar = true;
                picBoxEye.BackgroundImage = Resources.slash_eye_icon_224538;
                txtBPass.Focus();
            }
        }

        // Заберем данные с РИМС
        private async void btnZRims_Click(object sender, EventArgs e)
        {
            if (!statusRimsTest)
            {
                MessageBox.Show("Нажми на кнопку Test RIMS\r\nПроверь Логин и Пароль\r\n Проверь связь", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sServiceUser = txtBLogin.Text.Trim();
            sServicePassword = txtBPass.Text.Trim();
            sServiceDomain = txtBDomen.Text.Trim();
            // NTLM Secured URL
            //var uri = new Uri("https://fim.sib.rual.ru/Export/api/Person/Odata?%24filter=Domain%20eq%20'IE.Corp'%20and%20Disabled%20eq%20false%20and%20LeaveType%20ne%20null&%24top=11");
            // без ограничения
            var uri = new Uri("https://fim.sib.rual.ru/Export/api/Person/Odata?%24filter=Domain%20eq%20'IE.Corp'%20and%20Disabled%20eq%20false%20and%20LeaveType%20ne%20null");
            // Create a new Credential
            var credentialsCache = new CredentialCache();
            credentialsCache.Add(uri, "NTLM", new NetworkCredential(
                sServiceUser, sServicePassword, sServiceDomain));

            var handler = new HttpClientHandler() { Credentials = credentialsCache, PreAuthenticate = true };
            var httpClient = new HttpClient(handler) { Timeout = new TimeSpan(0, 0, 10) };
            var response = await httpClient.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            #region Test array
            // Test array
            //JArray jArray = JArray.Parse(result);
            #endregion
            var statusL = JsonConvert.DeserializeObject<List<RimsZaprosOutput>>(result);

            double count = 0;
            txtBoxConsole.AppendText($"Начинаем заполнять список..");
            foreach (var item in statusL)
            {
                count++;
                if ((count % 100) == 0)
                {
                    txtBoxConsole.AppendText($"..{(int)count}");
                }
                ListViewItem viewItem = new ListViewItem(item.AccountName);
                string FIO = $"{item.LastName} {item.FirstName} {item.MiddleName}";
                viewItem.SubItems.Add(FIO);
                viewItem.SubItems.Add(item.City);
                #region old Dict
                /*string LeaveType = "";
                foreach (var DLT in DLeaveType)
                {
                    if(DLT.Key == item.LeaveType)
                    {
                        LeaveType = DLT.Value;
                        break;
                    }
                }*/

                //viewItem.SubItems.Add(LeaveType);
                #endregion
                viewItem.SubItems.Add(DLeaveType[item.LeaveType]);
                viewItem.SubItems.Add(item.LeaveStart.ToString().Remove(item.LeaveStart.ToString().IndexOf(" ")));
                viewItem.SubItems.Add(item.LeaveEnd.ToString().Remove(item.LeaveEnd.ToString().IndexOf(" ")));
                listView1.Items.Add(viewItem);

                Datauser userObject = new Datauser()
                {
                    FimSyncKey = item.FimSyncKey,
                    AccountId = item.AccountId,
                    AccountName = item.AccountName.Count() > 50 ? item.AccountName.Substring(49) : item.AccountName,
                    LastName = item.LastName?.Count() > 100 ? item.LastName.Substring(99) : item.LastName,
                    FirstName = item.FirstName?.Count() > 100 ? item.FirstName.Substring(99) : item.FirstName,
                    MiddleName = item.MiddleName?.Count() > 100 ? item.MiddleName.Substring(99) : item.MiddleName,
                    EmployeeNumber = item.EmployeeNumber?.Count() > 20 ? item.EmployeeNumber.Substring(19) : item.EmployeeNumber,
                    Birthday = item.Birthday,
                    CompanyName = item.CompanyName?.Count() > 300 ? item.CompanyName.Substring(299) : item.CompanyName,
                    DepartmentName = item.DepartmentName?.Count() > 200 ? item.DepartmentName.Substring(199) : item.DepartmentName,
                    JobTitle = item.JobTitle?.Count() > 200 ? item.JobTitle.Substring(199) : item.JobTitle,
                    DateIn = item.DateIn,
                    LeaveId = DLeaveType2C[item.LeaveType],
                    LeaveStart = item.LeaveStart,
                    LeaveEnd = item.LeaveEnd,
                    City = item.City?.Count() > 100 ? item.City.Substring(99) : item.City,
                    Phone = item.Phone?.Count() > 100 ? item.Phone.Substring(99) : item.Phone,
                    Email = item.Email?.Count() > 100 ? item.Email.Substring(99) : item.Email,
                    Disabled = item.DisabledDomain,
                    AnswerId = 1

                };
                Datauserslist.Add(userObject);

            }

            txtBoxConsole.AppendText(Environment.NewLine);
            txtBoxConsole.AppendText($"Пользователей в списке: {listView1.Items.Count}" + Environment.NewLine);


        }

        // Save in DataBase
        private void btnSaveDB_Click(object sender, EventArgs e)
        {
            if (!statusDBTest & listView1.Items.Count < 1)
            {
                MessageBox.Show("Нажми на кнопку Test DB\r\nИ убедись , что появилась зеленая галочка\r\nПроверь связь", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long count_db = 0;
            using (DataModelContext countDB = new DataModelContext())
            {
                var lists = countDB.Datausers.ToList();
                count_db = lists.LongCount();
            }

            txtBoxConsole.AppendText($"Начинаем запись в Базу данных..." + Environment.NewLine);
            Stopwatch stopwatchBD = new Stopwatch();
            stopwatchBD.Start();

            using (DataModelContext context = new DataModelContext())
            {

                if (count_db > 1000)
                {
                    foreach (var item in Datauserslist)
                    {
                        try
                        {
                            context.Datausers.Update(item);
                            context.SaveChanges();
                        }
                        catch 
                        {
                            context.Datausers.Add(item);
                            //MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            context.SaveChanges();
                        }

                    }

                } else
                {
                    foreach (var item in Datauserslist)
                    {
                        try
                        {
                            context.Datausers.Add(item);
                            context.SaveChanges();
                        }
                        catch 
                        {
                            context.Datausers.Update(item);
                            //MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            context.SaveChanges();
                        }
                    }

                }
                stopwatchBD.Stop();
                TimeSpan stopwatchElapsed = stopwatchBD.Elapsed;
                var milsec = Convert.ToInt32(stopwatchElapsed.TotalMilliseconds);
                var sec = milsec / 1000;
                var ts = TimeSpan.FromSeconds(sec);
                txtBoxConsole.AppendText($"На запись ушло времени: {ts.Hours}ч:{ts.Minutes}м:{ts.Seconds}с\r\n");


                #region AddRange List no work AddAndUpdate
                /*try
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.Datausers.  Range(Datauserslist);
                    context.SaveChanges();
                }
                catch
                {
                    context.Datausers.UpdateRange(Datauserslist);
                    context.SaveChanges();
                }
                finally
                {
                    //context.Configuration.AutoDetectChangesEnabled = true;
                }*/
                #endregion

            };

            using (DataModelContext countDB2 = new DataModelContext())
            {
                var lists = countDB2.Datausers.ToList();
                var countD = lists.LongCount();
                txtBoxConsole.AppendText($"Quantity items after Save in DB: {countD}" + Environment.NewLine);
            }


        }

        // c EWS не получилось - прав доступа нет :( будем делать через РИМС + PLINQ
        private void btnEWS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBLogin.Text) | string.IsNullOrEmpty(txtBPass.Text) | string.IsNullOrEmpty(txtBDomen.Text))
            {
                MessageBox.Show("Заполни все поля Login, Password, Domain!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> listsID = new List<string>();

            using (DataModelContext context = new DataModelContext())
            {
                var listsIdDB = context.Datausers.Where(l => l.AnswerId != 4).Select(l => l.AccountName).ToList();
                foreach (var item in listsIdDB)
                {
                    listsID.Add(item);
                    //if (listsID.Count > 40) break;   // Ограничение на Внесение стутуса 3 кнопка
                }

            }
            int threadId = Thread.CurrentThread.ManagedThreadId;
            txtBoxConsole.AppendText($"Main: запущен в потоке # {threadId}" + Environment.NewLine);
            logger.Info($"Main: запущен потоке: {threadId}");

            Thread.Sleep(1000);

            ParallelOptions options = new ParallelOptions();
            // Выделить определенное количество процессорных ядер.
            //options.MaxDegreeOfParallelism = Environment.ProcessorCount > 4 ? Environment.ProcessorCount - 1 : 1;
            if (Environment.ProcessorCount > 4)
                options.MaxDegreeOfParallelism = Environment.ProcessorCount < 10 ? 4 : 5;
            else
                options.MaxDegreeOfParallelism = 1;

            txtBoxConsole.AppendText($"Количество логических ядер CPU: {Environment.ProcessorCount}" + Environment.NewLine);
            txtBoxConsole.AppendText($"Будем использовать: {options.MaxDegreeOfParallelism} потоков" + Environment.NewLine);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            listsID.AsParallel().WithDegreeOfParallelism(options.MaxDegreeOfParallelism).ForAll(ls => { MyTask(ls); });

            stopwatch.Stop();
            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
            var milsec = Convert.ToInt32(stopwatchElapsed.TotalMilliseconds);
            var sec = milsec / 1000;
            var ts = TimeSpan.FromSeconds(sec);

            txtBoxConsole.AppendText($"Затраченное время: {ts.Hours}ч:{ts.Minutes}м:{ts.Seconds}с\r\n");
            txtBoxConsole.AppendText($"Всего AcountName попавших в обработку: {listsID.Count}\r\n");
            txtBoxConsole.AppendText($"Основной поток завершен.\r\n");
            logger.Info($"Затраченное время на обработку получения Статуса пользователей из РИМСа: {ts.Hours}ч:{ts.Minutes}м:{ts.Seconds}с");
            logger.Info($"Всего AcountName попавших в обработку: {listsID.Count}");
            logger.Info($"Основной поток завершен.");

            using (DataModelContext contextC = new DataModelContext())
            {
                var listsC = contextC.Datausers.Where(l => l.AnswerId == 4).ToList();
                txtBoxConsole.AppendText($"Итого добавлено {listsC.Count()} статусов в DBase о наличии пользовательских автоответов, которые мы сохраним" + Environment.NewLine);
            }



        }

        // Отправка запросов REST POST в РИМС для установки статуса в EXchange
        private void btnExToRims_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBLogin.Text) | string.IsNullOrEmpty(txtBPass.Text) | string.IsNullOrEmpty(txtBDomen.Text)) {
                MessageBox.Show("Заполни все поля Login, Password, Domain!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Qtable> qtables = new List<Qtable>();
            #region start for RIMS
            /*sServiceUser = txtBLogin.Text.Trim();
            sServicePassword = txtBPass.Text.Trim();
            sServiceDomain = txtBDomen.Text.Trim();

            var uri = new Uri("https://kraz-s-rims01.hq.root.ad/api/Exchange/SetOutOfOffice");

            var credentialsCache = new CredentialCache();
            credentialsCache.Add(uri, "NTLM", new NetworkCredential(
                sServiceUser, sServicePassword, sServiceDomain));

            var handler = new HttpClientHandler() { Credentials = credentialsCache, PreAuthenticate = true };
            var httpClient = new HttpClient(handler) { Timeout = new TimeSpan(0, 0, 30) };*/
            #endregion

            // Join new table
            using (DataModelContext context = new DataModelContext())
            {
                var datausers = from d in context.Datausers
                                join l in context.Leaves on d.LeaveId equals l.Id
                                join a in context.Answers on d.AnswerId equals a.Id
                                select new Qtable()
                                {
                                    AccountName = d.AccountName,
                                    LeaveName = l.LeaveType,
                                    LeaveStart = d.LeaveStart,
                                    LeaveEnd = d.LeaveEnd,
                                    Uid = d.FimSyncKey,
                                    LastName = d.LastName,
                                    FirstName = d.FirstName,
                                    MiddleName = d.MiddleName,
                                    AnswerName = a.AnswerType
                                };
                /*context.Datausers.Join(context.Leaves, 
                    d => d.LeaveId,
                    l => l.Id,
                    (d, l) => new Qtable()
                    {
                        AccountName = d.AccountName,
                        LeaveName = l.LeaveType,
                        LeaveStart = d.LeaveStart,
                        LeaveEnd = d.LeaveEnd,
                        Uid = d.FimSyncKey,
                        LastName = d.LastName,
                        FirstName = d.FirstName,
                        MiddleName = d.MiddleName,
                    });*/




                int count0 = 1;
                foreach (var ds in datausers)
                {
                    // для проверки только 2 записи
                    //if (count0 > 100) break;

                    qtables.Add(ds);
                    count0++;
                }
            }

            // Ограничение по core
            ParallelOptions options = new ParallelOptions();
            if (Environment.ProcessorCount > 4)
                options.MaxDegreeOfParallelism = Environment.ProcessorCount < 10 ? 4 : 5;
            else
                options.MaxDegreeOfParallelism = 1;

            
            txtBoxConsole.AppendText($"Начинаем запись статусов для пользователей в Exchange: {DateTime.Now}\r\n");
            txtBoxConsole.AppendText($"Количество используемых потоков: {options.MaxDegreeOfParallelism}.\r\n");
            logger.Info($"\r\n !!!! -------- Начинаем запись статусов для пользователей в Exchange ------------!!!!:{DateTime.Now}");
            logger.Info($"Количество используемых потоков: {options.MaxDegreeOfParallelism}.");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            qtables.Where(q => q.AnswerName != "AU").AsParallel().WithDegreeOfParallelism(options.MaxDegreeOfParallelism).ForAll(q => { MyTaskSet(q);});

            stopwatch.Stop();
            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
            var milsec = Convert.ToInt32(stopwatchElapsed.TotalMilliseconds);
            var sec = milsec / 1000;
            var ts = TimeSpan.FromSeconds(sec);

            txtBoxConsole.AppendText($"Затраченное время: {ts.Hours}ч:{ts.Minutes}м:{ts.Seconds}с\r\n");
            txtBoxConsole.AppendText($"Всего пользователей попавших в обработку: {qtables.Count}\r\n");
            txtBoxConsole.AppendText($"Основной поток завершен.{DateTime.Now}\r\n");
            logger.Info($"Затраченное время: {ts.Hours}ч:{ts.Minutes}м:{ts.Seconds}с");
            logger.Info($"Всего пользователей попавших в обработку: {qtables.Count}");
            logger.Info($"Основной поток завершен.{DateTime.Now}");


            // old 
            #region OLD запрос в 1 поток

            /*foreach (var qt in qtables)
            {
                // проверим на уже имеющиеся записи
                if(qt.AnswerName == "AU" )
                {
                    continue;
                }
                
                *//*using (DataModelContext dbTestAc = new DataModelContext())
                {
                    var user1 = dbTestAc.Datausers.FirstOrDefault(u => u.AccountName == qt.AccountName);
                    if (user1 != null & user1.AnswerId != 3 & user1.AnswerId == 4)
                    {
                        continue ;
                    }
                }*//*




                // Структура формирования автоОтвета
                OutOfOffice ofOffice = new OutOfOffice
                {
                    leaveName = qt.LeaveName,
                    DateStart = (DateTime)qt.LeaveStart,
                    DateEnd = (DateTime)qt.LeaveEnd,
                    FIO = $"{qt.LastName} {qt.FirstName} {qt.MiddleName}"
                };
                txtBoxConsole.AppendText($"Статус: {ofOffice.As()}" + Environment.NewLine);
                string setStatusUser = ofOffice.As();

                #region OLDz
                // REST POST
                //var uri = new Uri("https://kraz-s-rims01.hq.root.ad/api/Exchange/SetOutOfOffice");
                // Create a new Credential
                *//*var credentialsCache = new CredentialCache();
                credentialsCache.Add(uri, "NTLM", new NetworkCredential(
                    sServiceUser, sServicePassword, sServiceDomain));

                var handler = new HttpClientHandler() { Credentials = credentialsCache, PreAuthenticate = true };
                var httpClient = new HttpClient(handler); //{ Timeout = new TimeSpan(0, 0, 10) };
*//*
                #endregion
                // JSON формирование
                SetOutOfOffice setOutOf = new SetOutOfOffice()
                {
                    InternalContent = setStatusUser,
                    ExternalContent = setStatusUser,
                    DateStart = (DateTime)qt.LeaveStart,
                    DateEnd = (DateTime)qt.LeaveEnd,
                    Uid = qt.Uid,
                    Account = qt.AccountName,
                    Disable = false

                };
                var content = JsonConvert.SerializeObject(setOutOf);
                var data = new StringContent(content, Encoding.UTF8, "application/json");

                // проверочный статус
                bool sts = false;
                int count = 0;
                do
                {
                    try
                    {
                        count++;
                        var response = await httpClient.PostAsync(uri, data);
                        response.EnsureSuccessStatusCode();
                        var json = await response.Content.ReadAsStringAsync();
                        var status = JsonConvert.DeserializeObject<SetOutOffResult>(json);
                        txtBoxConsole.AppendText($"Статус добавления: {status.Status} Message:{status.Message}" + Environment.NewLine);
                        sts = status.Status;
                        if (status.Status)
                        {
                            txtBoxConsole.AppendText($"Для {qt.AccountName} добавлен автоматический ответ в почте" + Environment.NewLine);
                            using (DataModelContext context = new DataModelContext())
                            {
                                var user1 = context.Datausers.FirstOrDefault(u => u.AccountName == qt.AccountName);
                                if (user1 != null)
                                {
                                    user1.AnswerId = 3;
                                    context.SaveChanges();
                                }
                            }
                        } else
                        {
                            using (DataModelContext context = new DataModelContext())
                            {
                                var user1 = context.Datausers.FirstOrDefault(u => u.AccountName == qt.AccountName);
                                if (user1 != null)
                                {
                                    user1.AnswerId = 2;
                                    context.SaveChanges();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        txtBoxConsole.AppendText($"Исключение: {ex.Message} - попытка N{count}" + Environment.NewLine);
                        await Task.Delay(2000);
                        using (DataModelContext context = new DataModelContext())
                        {
                            var user1 = context.Datausers.FirstOrDefault(u => u.AccountName == qt.AccountName);
                            if (user1 != null)
                            {
                                user1.AnswerId = 2;
                                context.SaveChanges();
                            }
                        }
                    }
                } while (!sts & count < 3);

                logger.Info($"Пользователю {qt.AccountName} прописан автоответ: {sts} ");
            }*/

            #endregion


        }



        #region Методы по получению Статуса из РИМС
        // Task for Plinq.
        public void MyTask(object arg)
        {
            string ak = (string)arg;

            logger.Info($"MyTask: CurrentId {Task.CurrentId} with ManagedThreadId {Thread.CurrentThread.ManagedThreadId} запущен, ак пользователя {ak}" + Environment.NewLine);

            #region Random
            /*var random = new Random();
            var lowerBound = 2000;
            var upperBound = 2000;
            var rNum = random.Next(lowerBound, upperBound);
            Thread.Sleep(rNum);*/
            #endregion
            //Task state = GetOutState(ak);   // пока притормозим асинхрон
            GetOutState2(ak);

            logger.Info($"MyTask: CurrentId {Task.CurrentId} завершен." + Environment.NewLine);
        }

        // Первая
        public async Task GetOutState(string acount) {
        
            #region RIMS отправка запроса POST и запись в Базу Данных стутуса 4 если включен автоответ пользователем
            sServiceUser = txtBLogin.Text.Trim();
            sServicePassword = txtBPass.Text.Trim();
            sServiceDomain = txtBDomen.Text.Trim();
            // NTLM Secured URL
            var uri = new Uri("https://kraz-s-rims01.hq.root.ad/api/Exchange/GetOutOfOffice");
            // Create a new Credential
            var credentialsCache = new CredentialCache();
            credentialsCache.Add(uri, "NTLM", new NetworkCredential(
                sServiceUser, sServicePassword, sServiceDomain));
            var handler = new HttpClientHandler() { Credentials = credentialsCache, PreAuthenticate = true };
            var httpClient = new HttpClient(handler) { Timeout = new TimeSpan(0, 0, 30) };

            GetOutOfOffice getOutOf = new GetOutOfOffice()
            {
                Account = acount,
                Domain = "IE.CORP"
            };
            var content = JsonConvert.SerializeObject(getOutOf);
            var data = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(uri, data);  //await


            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();   //await
            var status = JsonConvert.DeserializeObject<GetOutOfResult>(json);
            logger.Info($"Статус проверки: CurrentId:{Task.CurrentId}, ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
            try
            {
                logger.Info($"Статус автоответа {acount}: {status.Data?.Enabled} DateS&E:{status.Data?.DateStart}-{status.Data?.DateEnd} ");
                bool? stE = status.Data?.Enabled;
                if (stE.HasValue)
                {
                    using (DataModelContext context = new DataModelContext())
                    {
                        var user1 = context.Datausers.FirstOrDefault(u => u.AccountName == acount);
                        if (user1 != null)
                        {
                            user1.AnswerId = 4;
                            context.SaveChanges();
                            logger.Info($"Статус автоответа {acount}: 4 и он прописан в DB");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info($"Статус автоответа {acount}: Data Exception {ex.Message}");

            }
            #endregion
           return;
        
        }

        // Вторая версия доступа к RIMS в потоках
        public void GetOutState2(string acount)
        {
            sServiceUser = txtBLogin.Text.Trim();
            sServicePassword = txtBPass.Text.Trim();
            sServiceDomain = txtBDomen.Text.Trim();
            //string url = $"{adressRims}/api/ActiveDirectory/CheckExistsGroup";
            // NTLM Secured URL
            var uri = new Uri("https://kraz-s-rims01.hq.root.ad/api/Exchange/GetOutOfOffice");

            var httpRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpRequest.Timeout = 30000;
            httpRequest.Method = "POST";
            httpRequest.Accept = "application/json";

            if (!string.IsNullOrEmpty(sServiceUser) & !string.IsNullOrEmpty(sServicePassword))
            {
                NetworkCredential credential =
                    new NetworkCredential(sServiceUser, sServicePassword, sServiceDomain);
                httpRequest.Credentials = credential;
            }
            else
            {
                httpRequest.UseDefaultCredentials = true;
            }
            httpRequest.ContentType = "application/json";

            GetOutOfOffice getOutOf = new GetOutOfOffice()
            {
                Account = acount,
                Domain = "IE.CORP"
            };

            string jsonz = JsonConvert.SerializeObject(getOutOf);
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonz);
            }
            try
            {
                var result = "";
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                //Console.WriteLine(httpResponse.StatusCode);
                //Console.WriteLine(result);
                var status = JsonConvert.DeserializeObject<GetOutOfResult>(result);

                logger.Info($"Статус проверки: CurrentId:{Task.CurrentId}, ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
                logger.Info($"Статус автоответа {acount}: {status.Data?.Enabled} DateS&E:{status.Data?.DateStart}-{status.Data?.DateEnd} ");
                
                bool? stE = status.Data?.Enabled;
                if (stE.HasValue) {
                    if(stE.Value)
                    {
                        using (DataModelContext context = new DataModelContext())
                        {
                            var user1 = context.Datausers.FirstOrDefault(u => u.AccountName == acount);
                            if (user1 != null)
                            {
                                user1.AnswerId = 4;
                                context.SaveChanges();
                                logger.Info($"Статус автоответа {acount}: 4 и он прописан в DB");
                            }
                        }

                    }
                
                }

            }
            catch (Exception ex)
            {
                logger.Info($"CurrentId:{Task.CurrentId}: " + ex.Message);
            }
            //return groupID_tmp;
        }

        #endregion


        #region Методы по установке автоответа в многопоточном варианте
        public void MyTaskSet(object arg)
        {
            Qtable qtable = (Qtable)arg;

            sServiceUser = txtBLogin.Text.Trim();
            sServicePassword = txtBPass.Text.Trim();
            sServiceDomain = txtBDomen.Text.Trim();
            var uri = new Uri("https://kraz-s-rims01.hq.root.ad/api/Exchange/SetOutOfOffice");

            var httpRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpRequest.Timeout = 30000;
            httpRequest.Method = "POST";
            httpRequest.Accept = "application/json";

            if (!string.IsNullOrEmpty(sServiceUser) & !string.IsNullOrEmpty(sServicePassword))
            {
                NetworkCredential credential =
                    new NetworkCredential(sServiceUser, sServicePassword, sServiceDomain);
                httpRequest.Credentials = credential;
            }
            else
            {
                httpRequest.UseDefaultCredentials = true;
            }
            httpRequest.ContentType = "application/json";


            // Структура формирования автоОтвета
            OutOfOffice ofOffice = new OutOfOffice
            {
                leaveName = qtable.LeaveName,
                DateStart = (DateTime)qtable.LeaveStart,
                DateEnd = (DateTime)qtable.LeaveEnd,
                FIO = $"{qtable.LastName} {qtable.FirstName} {qtable.MiddleName}"
            };
            logger.Info($"Автоответ для пользователя: {ofOffice.As()}");
            string setStatusUser = ofOffice.As();

            // JSON формирование
            SetOutOfOffice setOutOf = new SetOutOfOffice()
            {
                InternalContent = setStatusUser,
                ExternalContent = setStatusUser,
                DateStart = (DateTime)qtable.LeaveStart,
                DateEnd = (DateTime)qtable.LeaveEnd,
                Uid = qtable.Uid,
                Account = qtable.AccountName,
                Disable = false

            };

            string jsonz = JsonConvert.SerializeObject(setOutOf);
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonz);
            }

            // проверочный статус
            bool sts = false;
            int count = 0;
            do {
                try
                {
                    count++;
                    var result = "";
                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }

                    var status = JsonConvert.DeserializeObject<SetOutOffResult>(result);
                    sts = status.Status;
                    if (status.Status)
                    {
                        //logger.Info($"Для {qtable.AccountName} добавлен автоматический ответ в почте" + Environment.NewLine);
                        using (DataModelContext context = new DataModelContext())
                        {
                            var user1 = context.Datausers.FirstOrDefault(u => u.AccountName == qtable.AccountName);
                            if (user1 != null & user1.AnswerId != 3)
                            {
                                user1.AnswerId = 3;
                                context.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        using (DataModelContext context = new DataModelContext())
                        {
                            var user1 = context.Datausers.FirstOrDefault(u => u.AccountName == qtable.AccountName);
                            if (user1 != null & user1.AnswerId != 2)
                            {
                                user1.AnswerId = 2;
                                context.SaveChanges();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Info($"Исключение: {ex.Message} - попытка N{count} для пользователя {qtable.AccountName}. CurrentId {Task.CurrentId}, ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
                    using (DataModelContext context = new DataModelContext())
                    {
                        var user1 = context.Datausers.FirstOrDefault(u => u.AccountName == qtable.AccountName);
                        if (user1 != null & user1.AnswerId != 2)
                        {
                            user1.AnswerId = 2;
                            context.SaveChanges();
                        }
                    }
                }
            } while (!sts & count < 3);

            logger.Info($"Пользователю {qtable.AccountName} прописан автоответ: {sts}.");
            logger.Info($"MyTaskSet: CurrentId {Task.CurrentId}, ManagedThreadId:{Thread.CurrentThread.ManagedThreadId} завершен.");
        }

        #endregion

    }

}
