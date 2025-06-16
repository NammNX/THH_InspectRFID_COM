using MaterialSkin.Controls;
using System;
using System.Threading;
using System.Windows.Forms;
using TanHungHa.Common;
using TanHungHa.Common.TaskCustomize;
using System.Drawing;
using System.Collections.Generic;
using TanHungHa.Common.Parameter;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using System.Security.Cryptography;
using DevExpress.XtraSpreadsheet;
using DevExpress.Spreadsheet;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using TanHungHa.PopUp;
using static TanHungHa.Common.MyComport;




namespace TanHungHa.Tabs
{

    public partial class FormAuto : MaterialForm
    {
        private static FormAuto _instance;
        private static readonly object _lock = new object();
        public static FormAuto GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {

                    if (_instance == null)
                    {
                        _instance = new FormAuto();
                    }
                }
            }
            return _instance;
        }
        private static List<LogItem> logList = new List<LogItem>();

        public FormAuto()
        {
            InitializeComponent();
            // UpdateModeUI();
            SetupChart(chartIQC);
            SetupChart(chartOQC);
            SetupChart(chartDCM);
            
        }
        public static void InitVirtualListView(ListView listView)
        {
            listView.RetrieveVirtualItem += (s, e) =>
            {
                if (e.ItemIndex >= 0 && e.ItemIndex < logList.Count)
                {
                    var log = logList[e.ItemIndex];
                    var item = new ListViewItem(log.Time.ToString("HH:mm:ss"));
                    item.SubItems.Add(log.EPC);
                    item.SubItems.Add(log.TID);
                    item.SubItems.Add(log.Type.ToString());

                    switch (log.Type)
                    {
                        case eSerialDataType.NG:
                            item.BackColor = Color.Red;
                            item.ForeColor = Color.White;
                            break;
                        case eSerialDataType.Duplicate:
                            item.BackColor = Color.Orange;
                            item.ForeColor = Color.Black;
                            break;
                        case eSerialDataType.Unknown:
                            item.BackColor = Color.Black;
                            item.ForeColor = Color.White;
                            break;
                    }

                    e.Item = item;
                }
            };
        }
        public void AddLogBatchToList(List<LogItem> batch)
        {
            logList.InsertRange(0, batch);

            // Giới hạn số dòng tối đa
           
            if (logList.Count > MyParam.commonParam.devParam.maxLine)
                logList.RemoveRange(MyParam.commonParam.devParam.maxLine, logList.Count - MyParam.commonParam.devParam.maxLine);

            lvDataModeDCM.VirtualListSize = logList.Count;
            lvDataModeDCM.Invalidate();
        }


        public void UpdateModeUI()
        {
            var mode = MyParam.runParam.Mode;
            switch (mode)
            {
                case eMode.eEPC_TID:
                    SetModeAndHighlight(eMode.eEPC_TID, btnEPCTID);
                    break;
                case eMode.eOnlyEPC:
                    SetModeAndHighlight(eMode.eOnlyEPC, btnOnlyEPC);
                    break;
                case eMode.eOnlyTID:
                    SetModeAndHighlight(eMode.eOnlyTID, btnOnlyTID);
                    break;
                case eMode.None:
                    SetModeAndHighlight(eMode.None); // reset, không nút nào sáng
                    break;
            }
        }
        public void UpdateFuncUI()
        {
            var func = MyParam.runParam.Func;
            switch (func)
            {
                case eFunc.eFunctionNormal:
                    FuncNormal();
                    break;
                case eFunc.eFunctionDamCaMau:
                    FuncDCM();
                    break;
            }
        }

        public void StopProgram()
        {
            if ((MyParam.commonParam.myComportIQC.GetQueueCount() > 0) || (MyParam.commonParam.myComportOQC.GetQueueCount() > 0)
                || (MyParam.commonParam.mongoDBService.GetIqcBufferCount() > 0) || (MyParam.commonParam.mongoDBService.GetOqcBufferCount() > 0))
            {
                Console.WriteLine($"{MyParam.commonParam.myComportIQC.GetQueueCount()},{MyParam.commonParam.mongoDBService.GetIqcBufferCount()}");
                MyLib.showDlgInfo("Quá trình ghi dữ liệu vào data base chưa hoàn tất, vui lòng đợi trong giây lát");
                return;
            }
            if (MyParam.runParam.Func == eFunc.eFunctionDamCaMau)
            {  
               MyLib.KillAllExcelProcesses();
               var x =  MyParam.autoForm.SaveFileExcel();
               if (!x)
               {
                    MyLib.showDlgError($"Đóng file Excel {MyParam.runParam.FileNameDamCaMau}, sau đó thử Stop lại");
                    return;
               }
            }

            this.Cursor = Cursors.WaitCursor;
            //Close all connection
            MyLib.CloseAllDevices((int)eTaskLoop.Task_HEATBEAT);

            MyParam.commonParam.myComportIQC.DisConnect();
            MyParam.commonParam.myComportOQC.DisConnect();

            EnableBtn(btnInit, true);
            EnableBtn(btnStart, false);
            EnableBtn(btnReset, true);
            EnableBtn(btnStop, false);
            ChangeColor(groupBoxIQC, false);
            ChangeColor(groupBoxOQC, false);
            ChangeColor(groupBoxChartIQC, false);
            ChangeColor(groupBoxOQChart, false);
            swByPass.Enabled = false;
            swFlushDB.Enabled = true;



            if (MyParam.runParam.ProgramStatus == ePRGSTATUS.Started)
            {
                MainProcess.AddLogAuto($"Disconnect COM IQC", eIndex.Index_IQC_OQC_Log);
                MainProcess.AddLogAuto($"Disconnect COM OQC", eIndex.Index_IQC_OQC_Log);
                if (MyParam.runParam.Func == eFunc.eFunctionDamCaMau)
                {
                    MaterialDialog materialDialog = new MaterialDialog(this, "Thông báo", "Bạn có muốn mở thư mục chứa file Excel", "OK", true, "Cancel");
                    DialogResult result = materialDialog.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        Process.Start("explorer.exe", MyParam.runParam.PathFolderSaveFileExcel);
                    }
                }
            }
            MainProcess.isRunLoopProcess = false;
            MainProcess.isChartUpdateRunning = false;
            MainProcess.isRunLoopProcessDCM = false;
            MainProcess.isChartUpdateRunningDamCaMau = false;
            MainProcess.isRunLoopProcessAutoSaveExcel = false;
            MainProcess.isRunLoopWriteExcel = false;
            MainProcess.isRunLoopShowListView = false;
            MongoDBService.isFlushLoop = false;



            MyParam.runParam.ProgramStatus = ePRGSTATUS.Stoped;
   
            this.Cursor = Cursors.Default;
        }
        
        public bool SaveFileExcel(FileExistsAction action = FileExistsAction.Overwrite)
        {
            Stopwatch sw = Stopwatch.StartNew();
            // Đường dẫn đầy đủ tới file
            string folderPath = MyParam.runParam.PathFolderSaveFileExcel;
            string fullPath = System.IO.Path.Combine(folderPath, MyParam.runParam.FileNameDamCaMau);


            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            bool shouldSave = true;

            if (File.Exists(fullPath))
            {
                switch (action)
                {
                    case FileExistsAction.Question:
                        MaterialDialog materialDialog = new MaterialDialog(this, "File exists", $"File {MyParam.runParam.FileNameDamCaMau} đã tồn tại, bạn có muốn ghi đè không?", "Yes", true, "No");
                        DialogResult result = materialDialog.ShowDialog(this);
                        if (result == DialogResult.OK) //ghi đè
                        {
                            shouldSave = true;

                        }
                        else 
                        {
                            MyLib.showDlgInfo($"Kiểm tra đường dẫn {fullPath}");
                            Process.Start("explorer.exe", MyParam.runParam.PathFolderSaveFileExcel);
                            shouldSave = false;
                        }
                        break;
                    case FileExistsAction.Overwrite:
                        shouldSave = true;
                        break;
                }
            }
            if (shouldSave)
            {
                MyParam.commonParam.myExcel.SaveExcelToPath(fullPath);
                MyParam.runParam.FullPathSaveFileExcel = fullPath;
            }
            sw.Stop(); // Kết thúc đếm thời gian
            Console.WriteLine($"[SaveFileExcel] Time taken: {sw.ElapsedMilliseconds} ms");
            return shouldSave;

        }
        public enum FileExistsAction
        {
            Question,  // Hỏi người dùng
            Overwrite,  // Ghi đè (mặc định)
            CreateNew,  // Tạo file mới với timestamp
            Cancel      // Hủy thao tác
        }

        public bool LoadFileExcel()
        {
            try
            {
                if( MyParam.runParam.FullPathSaveFileExcel == MyDefine.pathDefaultSaveFileExcel)
                {
                    return false;
                }
                // Đường dẫn đầy đủ tới file
                spreadsheetControl1.LoadDocument(MyParam.runParam.FullPathSaveFileExcel);

            }
            catch (Exception ex)
            {
                MyParam.runParam.FullPathSaveFileExcel = MyDefine.pathDefaultSaveFileExcel;
                AddLog($"Lỗi khi mở file Excel:{ex.ToString()}", eIndex.Index_IQC_OQC_Log);
                return false;
            }
            return true;
        }
        
        








        //void StartProgram()
        //{

        //    EnableBtn(btnReset, false);
        //    EnableBtn(btnStop, true); 
        //    MyParam.runParam.ProgramStatus = ePRGSTATUS.Started;
        //}
        public async void InitProgram()
        {
            if (MyParam.runParam.Func == eFunc.eFunctionNormal)
            {
                if (MyParam.runParam.DataBaseName == MyDefine.dataBaseNameDefault) 
                {
                    MyLib.showDlgError("Vui lòng nhập tên cuộn trước khi khởi động");
                    return;
                }
            }
            if (MyParam.runParam.Func == eFunc.eFunctionDamCaMau)
            {
                if (MyParam.runParam.DataBaseNameDamCaMau == MyDefine.dataBaseNameDefault)
                {
                    MyLib.showDlgError("Vui lòng nhập tên cuộn trước khi khởi động");
                    return;
                }
            }
            try
            {
                btnInit.Enabled = false;

                MyLib.CloseAllDevices((int)eTaskLoop.Task_HEATBEAT);
                this.Cursor = Cursors.WaitCursor;
                var x = THHInitial.InitDevice();
                await x;
                Console.WriteLine("-------------btnInitial = " + x.Result);

                if (x.Result)
                {
                    MainProcess.AddLogAuto("Connect Com&DataBase success", eIndex.Index_IQC_OQC_Log);
                    //if (MyParam.runParam.Func == eFunc.eFunctionDamCaMau)
                    //{
                    //    MainProcess.AddLogAuto("Import File Excel sau đó Start chương trình", eIndex.Index_IQC_OQC_Log);
                    //    EnableBtn(btnInputDataSourceDCM, false); // sau khi nhập file excel thì mới cho phép Init
                    //}

                    EnableBtn(btnStart, true);
                    EnableBtn(btnEPCTID, true);
                    EnableBtn(btnOnlyEPC, true);
                    EnableBtn(btnOnlyTID, true);
                    swByPass.Enabled = true;
                    MyParam.commonParam.myComportIQC.ClearDataRev();
                    MyParam.commonParam.myComportOQC.ClearDataRev();
                }
                else
                {
                    MainProcess.AddLogAuto("Please check the connections again", eIndex.Index_IQC_OQC_Log);
                    EnableBtn(btnInit, true);
                    EnableBtn(btnStart, false);
                }

                MyParam.runParam.ProgramStatus = ePRGSTATUS.Initial;
                this.Cursor = Cursors.Default;
            }
            catch 
            {
                MyLib.showDlgError("Lỗi khởi động chương trình, vui lòng kiểm tra lại kết nối");
                this.Cursor = Cursors.Default;
            }
        }
        public void StartProgramDCM()
        {

            MaterialDialog materialDialog =
                new MaterialDialog(this, "Start", $"Bắt đầu chạy cuộn {MyParam.runParam.DataBaseNameDamCaMau}", "OK", true, "Cancel");
            DialogResult result = materialDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                MyParam.commonParam.myComportIQC.ClearDataRev();
                MyParam.commonParam.myComportOQC.ClearDataRev();

                EnableBtn(btnEPCTID, false);
                EnableBtn(btnOnlyEPC, false);
                EnableBtn(btnOnlyTID, false);
                EnableBtn(btnNewRoll, false);
                EnableBtn(btnStart, false);
                EnableBtn(btnReset, false);
                EnableBtn(btnStop, true);
                ChangeColor(groupBoxIQC, true);
                ChangeColor(groupBoxOQC, true);
                ChangeColor(groupBoxOQChart, true);
                ChangeColor(groupBoxChartIQC, true);

                MainProcess.RunLoopChartUpdateDCM();
                MainProcess.RunLoopProcessDCM();
                MainProcess.RunLoopProcessAutoSaveExcel();
                MainProcess.RunLoopWriteExcel();
                MainProcess.RunLoopShowListView();

                if (!MyParam.commonParam.devParam.ignoreDataBase)
                {
                    MyParam.commonParam.mongoDBService.RunFlushLoop();
                }
                MainProcess.MainIQC_StepCtrl.SetStep(eProcessing.ReceiveData);
                //MainProcess.MainOQC_StepCtrl.SetStep(eProcessing.ReceiveData);
                MyParam.runParam.ProgramStatus = ePRGSTATUS.Started;
            }
            else
            {
                EnableBtn(btnReset, false);
                EnableBtn(btnStop, false);
                EnableBtn(btnNewRoll, true);
                EnableBtn(btnEPCTID, true);
                EnableBtn(btnOnlyEPC, true);
                EnableBtn(btnOnlyTID, true);
            }

            this.Cursor = Cursors.Default;



        }
        public void StartProgram()
        {
            var checkmode = MainProcess.CheckMode();
            if (!checkmode)
            {
                MyLib.showDlgError(" Vui lòng chọn chế độ chạy");
                return;
            }

            MaterialDialog materialDialog =
                new MaterialDialog(this, "Start", $"Bắt đầu chạy cuộn {MyParam.runParam.DataBaseName}", "OK", true, "Cancel");
            DialogResult result = materialDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                MyParam.commonParam.myComportIQC.ClearDataRev();
                MyParam.commonParam.myComportOQC.ClearDataRev();
                EnableBtn(btnEPCTID, false);
                EnableBtn(btnOnlyEPC, false);
                EnableBtn(btnOnlyTID, false);
                EnableBtn(btnNewRoll, false);
                EnableBtn(btnStart, false);
                EnableBtn(btnReset, false);
                EnableBtn(btnStop, true);
                ChangeColor(groupBoxIQC, true);
                ChangeColor(groupBoxOQC, true);
                ChangeColor(groupBoxOQChart, true);
                ChangeColor(groupBoxChartIQC, true);

                MainProcess.RunLoopChartUpdate();
                MainProcess.RunLoopProcess();

                if (!MyParam.commonParam.devParam.ignoreDataBase)
                {
                    MyParam.commonParam.mongoDBService.RunFlushLoop();
                }
                MainProcess.MainIQC_StepCtrl.SetStep(eProcessing.ReceiveData);
                MainProcess.MainOQC_StepCtrl.SetStep(eProcessing.ReceiveData);
                MyParam.runParam.ProgramStatus = ePRGSTATUS.Started;
            }
            else
            {
                EnableBtn(btnReset, false);
                EnableBtn(btnStop, false);
                EnableBtn(btnNewRoll, true);
                EnableBtn(btnEPCTID, true);
                EnableBtn(btnOnlyEPC, true);
                EnableBtn(btnOnlyTID, true);
            }

            this.Cursor = Cursors.Default;
        }




        void ResetProgram()
        {
            MaterialDialog materialDialog = new MaterialDialog(this, "Reset?", "Tất cả bộ đếm và log sẽ bị Clear", "OK", true, "Cancel");
            DialogResult result = materialDialog.ShowDialog(this);

            //MaterialSnackBar SnackBarMessage = new MaterialSnackBar(result.ToString(), 750);
            //SnackBarMessage.Show(this);

            if (result == DialogResult.OK)
            {

                this.Cursor = Cursors.WaitCursor;
                // reset listview
                lvLogIQC_OQC.Items.Clear();
                lvLogDB.Items.Clear();
                // reset labelDataBase
                MongoDBService.ClearDBFlushed();
                UpdateLabelDataBase();
                //reset label IQCOQC
                resetIQC();
                resetOQC();
                resetDCM();
                StopProgram();
                EnableBtn(btnReset, false);
                if (MyParam.runParam.Func == eFunc.eFunctionDamCaMau)
                {

                    groupBoxMode.Enabled = false;
                    EnableBtn(btnNewRoll, false);
                    EnableBtn(btnInit, false);
                    EnableBtn(btnInputDataSourceDCM, true);
                    StartBlinkButtonImportFileExcel();
                    MyParam.commonParam.myExcel.CreateNewExcelFile();
                    MyParam.runParam.FullPathSaveFileExcel = MyDefine.pathDefaultSaveFileExcel;
                    MyParam.runParam.DataBaseNameDamCaMau = MyDefine.dataBaseNameDefault;
                    UpdateLabelRollName(MyParam.runParam.DataBaseNameDamCaMau);

                }
                else
                {
                    groupBoxMode.Enabled = true;
                    EnableBtn(btnNewRoll, true);
                    EnableBtn(btnInit, true);
                }
                groupBoxDcm.Enabled = true;
                MyParam.runParam.ProgramStatus = ePRGSTATUS.Reset;
                this.Cursor = Cursors.Default;
            }
        }

        void resetIQC()
        {
            lvIQC.Items.Clear();
            UpdateChart(chartIQC, 0, 0);
            countOK_IQC = 0;
            countNG_IQC = 0;
            UpdateLabelIQC();
            //  MyParam.commonParam.myComportIQC.SendData(MyDefine.ResetIO_RFID);
        }
        void resetOQC()
        {
            lvOQC.Items.Clear();
            UpdateChart(chartOQC, 0, 0);
            countOK_OQC = 0;
            countNG_OQC = 0;
            UpdateLabelOQC();
            //  MyParam.commonParam.myComportOQC.SendData(MyDefine.ResetIO_RFID);
        }
        void resetDCM()
        {
            lvDataModeDCM.Items.Clear();
            UpdateChart(chartDCM, 0, 0);
            countOK_DamCaMau = 0;
            countNG_DamCaMau = 0;
            UpdateLabelDCM();
        }





        void EnableBtn(MaterialButton btn, bool bEnable)
        {
            if (btn.InvokeRequired)
            {
                btn.BeginInvoke(new Action(() =>
                {
                    btn.Enabled = bEnable;
                }));
            }
            else
            {
                btn.Enabled = bEnable;
            }
        }
        void EnableBtn(Button btn, bool bEnable)
        {
            if (btn.InvokeRequired)
            {
                btn.BeginInvoke(new Action(() =>
                {
                    btn.Enabled = bEnable;
                }));
            }
            else
            {
                btn.Enabled = bEnable;
            }
        }

        private void btnProgramAction(object sender, EventArgs e)
        {
            var btnName = ((MaterialButton)sender).Name;
            switch (btnName)
            {
                case "btnInit":
                    InitProgram();

                    break;
                case "btnStop":
                    StopProgram();
                    break;

                case "btnStart":
                    if (MyParam.runParam.Func == eFunc.eFunctionDamCaMau)
                    {
                        StartProgramDCM();
                    }
                    else
                    {
                        StartProgram();
                    }
                    groupBoxDcm.Enabled = false;
                    swFlushDB.Enabled = false;
                    break;

                case "btnReset":
                    ResetProgram();
                    break;
            }
        }


        private void clearLogTapeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lvIQC.Items.Clear();
            lvLogDB.Items.Clear();
            lvLogIQC_OQC.Items.Clear();
            lvLogIQC_OQC.Items.Clear();

        }

        private void SetupChart(Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();

            chart.ChartAreas.Add(new ChartArea("Main"));
            var area = chart.ChartAreas[0];

            // Tắt grid
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisX.Enabled = AxisEnabled.False;
            //  area.AxisY.Enabled = AxisEnabled.False;
            area.AxisX.Title = "Result";
            area.AxisY.Title = "Tỉ lệ OK/NG (%)";


            // Series OK
            var seriesOK = new Series("OK");
            seriesOK.ChartType = SeriesChartType.Column;
            seriesOK.Color = Color.Green;

            chart.Series.Add(seriesOK);

            // Series NG
            var seriesNG = new Series("NG");
            seriesNG.ChartType = SeriesChartType.Column;
            seriesNG.Color = Color.Red;

            chart.Series.Add(seriesNG);

            chart.Legends[0].Docking = Docking.Right;

            UpdateChart(chart, 0, 0);
        }
        private void UpdateChart(Chart chart, int countOK, int countNG)
        {
            if (chart.InvokeRequired)
            {
                chart.Invoke(new Action(() => UpdateChart(chart, countOK, countNG)));
                return;
            }
            chart.Series["OK"].Points.Clear();
            chart.Series["NG"].Points.Clear();
            chart.ChartAreas[0].AxisX.CustomLabels.Clear();

            int total = countOK + countNG;
            double percentOK = total > 0 ? countOK * 100.0 / total : 0;
            double percentNG = total > 0 ? countNG * 100.0 / total : 0;

            // Gán giá trị phần trăm cho cột OK
            int idxOK = chart.Series["OK"].Points.AddXY("", percentOK);
            var pointOK = chart.Series["OK"].Points[idxOK];
            pointOK.Label = $"{percentOK:F1}%";
            pointOK.LabelForeColor = Color.White;
            pointOK.Font = new Font("Arial", 10, FontStyle.Bold);
            pointOK.LabelBackColor = Color.Green;
            pointOK.LabelBorderColor = Color.Transparent;

            // Gán giá trị phần trăm cho cột NG
            int idxNG = chart.Series["NG"].Points.AddXY("", percentNG);
            var pointNG = chart.Series["NG"].Points[idxNG];
            pointNG.Label = $"{percentNG:F1}%";
            pointNG.LabelForeColor = Color.White;
            pointNG.Font = new Font("Arial", 10, FontStyle.Bold);
            pointNG.LabelBackColor = Color.Red;
            pointNG.LabelBorderColor = Color.Transparent;

            // Hiển thị số lượng OK/NG bên dưới
            var cl = new CustomLabel
            {
                FromPosition = 0.5,
                ToPosition = 1.5,
                Text = $"OK: {countOK}  NG: {countNG}",
                RowIndex = 1
            };
            chart.ChartAreas[0].AxisX.CustomLabels.Add(cl);

            // Cố định trục Y từ 0 đến 100%
            var axisY = chart.ChartAreas[0].AxisY;
            axisY.Minimum = 0;
            axisY.Maximum = 100;
            axisY.Interval = 10;
            axisY.Title = "Tỉ lệ OK/NG (%)";
        }


        public void ChangeColor(GroupBox groupBox, bool bState)
        {
            if (groupBox.InvokeRequired)
            {
                groupBox.BeginInvoke(new Action(() =>
                {
                    if (bState)
                    {
                        groupBox.BackColor = Color.FromArgb(0, 120, 215);
                    }
                    else
                    {
                        groupBox.BackColor = Color.Gray;
                    }
                }));
            }
            else
            {
                if (bState)
                {
                    groupBox.BackColor = Color.FromArgb(0, 120, 215);
                }
                else
                {
                    groupBox.BackColor = Color.Gray;
                }
            }
        }

        public void AddLog(string message, eIndex index = eIndex.Index_IQC_Data)
        {
            //if (!MyParam.autoForm.IsHandleCreated) return;
            switch (index)
            {
                case eIndex.Index_IQC_Data:
                    MyLib.ShowLogListview(MyParam.autoForm.lvIQC, message);
                    break;

                case eIndex.Index_OQC_Data:
                    MyLib.ShowLogListview(MyParam.autoForm.lvOQC, message);
                    break;

                case eIndex.Index_IQC_OQC_Log:
                    MyLib.ShowLogListview(MyParam.autoForm.lvLogIQC_OQC, message);
                    break;

                case eIndex.Index_MongoDB_Log:
                    MyLib.ShowLogListview(MyParam.autoForm.lvLogDB, message);
                    break;
                default:
                    break;
            }
            MyLib.log(message, SvLogger.LogType.SEQUENCE);
        }
        private int countOK_IQC = 0;
        private int countNG_IQC = 0;
        private int countOK_OQC = 0;
        private int countNG_OQC = 0;
        private int countOK_DamCaMau = 0;
        private int countNG_DamCaMau = 0;


        public void UpdateChartDCM_OK()
        {
            countOK_DamCaMau++;
            UpdateChart(chartDCM, countOK_DamCaMau, countNG_DamCaMau);
            UpdateLabelDCM();
        }
        public void UpdateChartDCM_NG()
        {
            countNG_DamCaMau++;
            UpdateChart(chartDCM, countOK_DamCaMau, countNG_DamCaMau);
            UpdateLabelDCM();
        }
        public void UpdateLabelDCM()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateLabelDCM));
                return;
            }
            lbDCM_OK.Text = ($"OK: {countOK_DamCaMau.ToString()}");
            lbDCM_NG.Text = ($"NG: {countNG_DamCaMau.ToString()}");
            lbTotal_DCM.Text = ($"Total: {countOK_DamCaMau + countNG_DamCaMau}");
        }
        public void UpdateChartOQC_OK()
        {
            countOK_OQC++;
            UpdateChart(chartOQC, countOK_OQC, countNG_OQC);
            UpdateLabelOQC();
        }
        public void UpdateChartOQC_NG()
        {
            countNG_OQC++;
            UpdateChart(chartOQC, countOK_OQC, countNG_OQC);
            UpdateLabelOQC();
        }

        private void UpdateLabelOQC()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateLabelOQC));
                return;
            }
            lbOQC_OK.Text = ($"OK: {countOK_OQC.ToString()}");
            lbOQC_NG.Text = ($"NG: {countNG_OQC.ToString()}");
            lbOQC_Total.Text = ($"Total: {countOK_OQC + countNG_OQC}");

        }

        public void UpdateChartIQC_OK()
        {
            countOK_IQC++;
            UpdateChart(chartIQC, countOK_IQC, countNG_IQC);
            UpdateLabelIQC();
        }
        public void UpdateChartIQC_NG()
        {
            countNG_IQC++;
            UpdateChart(chartIQC, countOK_IQC, countNG_IQC);
            UpdateLabelIQC();
        }

        private void UpdateLabelIQC()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateLabelIQC));
                return;
            }
            lbIQC_OK.Text = ($"OK: {countOK_IQC.ToString()}");
            lbNG_IQC.Text = ($"NG: {countNG_IQC.ToString()}");
            lbTotal_IQC.Text = ($"Total: {countOK_IQC + countNG_IQC}");

        }
        public void UpdateLabelDataBase()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateLabelDataBase));
                return;
            }
            lbIQCflushed.Text = ($"IQC Flushed: {MongoDBService.GetTotalIqcFlushed()}");
            lbOQCflushed.Text = ($"OQC Flushed: {MongoDBService.GetTotalOqcFlushed()}");
            lbIQCbuffer.Text = ($"IQC Buffer: {MyParam.commonParam.mongoDBService.GetIqcBufferCount()}");
            lbOQCbuffer.Text = ($"OQC Buffer: {MyParam.commonParam.mongoDBService.GetOqcBufferCount()}");
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetIQC();
            MongoDBService.ClearDBFlushed();
            // MyParam.commonParam.myComportIQC.SendData(MyDefine.ResetIO_RFID);
        }

        private void clearLogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            resetOQC();
            MongoDBService.ClearDBFlushed();
            //  MyParam.commonParam.myComportIQC.SendData(MyDefine.ResetIO_RFID);

        }

        private void btnNewRoll_Click(object sender, EventArgs e)
        {

            string result = ShowInputDialog("Tên File", "Tạo tên File cuộn mới");
            if (!string.IsNullOrWhiteSpace(result))
            {
                char[] invalidChars = { '/', '\\', '.', '"', '*', '<', '>', ':', '|', '?', ' ' };
                if (result.IndexOfAny(invalidChars) >= 0)
                {
                    MyLib.showDlgError("Tên cuộn không hợp lệ, Không dùng dấu cách hoặc kí tự đặc biệt để đặt tên");
                    return;
                }
                var x = MyParam.commonParam.mongoDBService.ConnectMongoDb($"{MyParam.runParam.MongoClient}?connectTimeoutMS={MyParam.runParam.ConnectTimeOut}&socketTimeoutMS=10000&serverSelectionTimeoutMS=5000");
                if (x)
                {
                    var allDataBaseName = MyParam.commonParam.mongoDBService.GetAllDatabaseNames();
                    if (allDataBaseName.Contains(result.ToUpper()))
                    {
                        MyLib.showDlgError($"Tên cuộn {result.ToUpper()} đã tồn tại, vui lòng chọn tên khác");
                        return;
                    }
                }
                else
                {
                    MyLib.showDlgError("Kết nối đến MongoDB thất bại, vui lòng kiểm tra lại");
                    return;
                }
                btnRollName.Text = result.ToUpper();
                MyParam.runParam.DataBaseName = result.ToUpper();
                SetModeAndHighlight(eMode.eEPC_TID,btnEPCTID);
                MyParam.runParam.HistoryIQCData.Clear();
                MyParam.runParam.HistoryOQCData.Clear();
                EnableBtn(btnInit, true);
                EnableBtn(btnStart, false);
                MyLib.showDlgInfo("Tạo cuộn mới thành công");

            }
        }
        private string ShowInputDialog(string title, string prompt)
        {
            Form inputForm = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label label = new Label() { Left = 10, Top = 20, Text = prompt, Width = 460 };
            TextBox textBox = new TextBox() { Left = 10, Top = 50, Width = 560 };

            Button btnOK = new Button() { Text = "OK", Left = 220, Width = 70, Top = 80, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Cancel", Left = 300, Width = 70, Top = 80, DialogResult = DialogResult.Cancel };

            inputForm.Controls.Add(label);
            inputForm.Controls.Add(textBox);
            inputForm.Controls.Add(btnOK);
            inputForm.Controls.Add(btnCancel);

            inputForm.AcceptButton = btnOK;
            inputForm.CancelButton = btnCancel;

            return inputForm.ShowDialog() == DialogResult.OK ? textBox.Text.Trim() : null;
        }
        private void SetFuncAndHighlightButton(eFunc func, Button selectedButton = null)
        {
            MainProcess.SetFunc(func);
            MainProcess.AddLogAuto($"Function hiện tại: {func}", eIndex.Index_IQC_OQC_Log);
            var buttons = new[] { btnFuncNormal, btnFuncDCM };
            foreach (var btn in buttons)
            {
                btn.BackColor = Color.White;
            }
            if (selectedButton != null)
            {
                selectedButton.BackColor = Color.YellowGreen;
            }

        }



        private void SetModeAndHighlight(eMode mode, Button selectedButton = null)
        {
            MainProcess.SetMode(mode);
            MainProcess.AddLogAuto($"Chế độ hiện tại: {mode}", eIndex.Index_IQC_OQC_Log);
            var buttons = new[] { btnEPCTID, btnOnlyEPC, btnOnlyTID };
            foreach (var btn in buttons)
            {
                btn.BackColor = Color.White;
            }
            if (selectedButton != null)
            {
                selectedButton.BackColor = Color.YellowGreen;
            }
        }
        private void btnEPCTID_Click(object sender, EventArgs e)
        {
            SetModeAndHighlight(eMode.eEPC_TID, btnEPCTID);
            MyParam.commonParam.myComportIQC.SendData(MyDefine.EnableModeEPCTIDModuleRFID);
            MyParam.commonParam.myComportOQC.SendData(MyDefine.EnableModeEPCTIDModuleRFID);

        }

        private void btnOnlyEPC_Click(object sender, EventArgs e)
        {
            SetModeAndHighlight(eMode.eOnlyEPC, btnOnlyEPC);
            MyParam.commonParam.myComportIQC.SendData(MyDefine.EnableModeOnlyEPCModuleRFID);
            MyParam.commonParam.myComportOQC.SendData(MyDefine.EnableModeOnlyEPCModuleRFID);
        }

        private void btnOnlyTID_Click(object sender, EventArgs e)
        {
            SetModeAndHighlight(eMode.eOnlyTID, btnOnlyTID);
            MyParam.commonParam.myComportIQC.SendData(MyDefine.EnableModeOnlyTIDModuleRFID);
            MyParam.commonParam.myComportOQC.SendData(MyDefine.EnableModeOnlyTIDModuleRFID);
        }

        private void clearAllLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetIQC();
            MongoDBService.ClearDBFlushed();
            resetOQC();
            MongoDBService.ClearDBFlushed();
            lvLogIQC_OQC.Items.Clear();
            lvLogDB.Items.Clear();

        }

        private void swByPass_CheckedChanged(object sender, EventArgs e)
        {
            if (swByPass.Checked)
            {
                MyParam.commonParam.myComportIQC.SendData(MyDefine.ByPass);
                MyParam.commonParam.myComportOQC.SendData(MyDefine.ByPass);
                Console.WriteLine("ByPass");
            }
            else
            {
                MyParam.commonParam.myComportIQC.SendData(MyDefine.NoByPass);
                MyParam.commonParam.myComportOQC.SendData(MyDefine.NoByPass);
                Console.WriteLine("NoByPass");
            }

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRollName_Click(object sender, EventArgs e)
        {
            MyParam.commonParam.myComportIQC.SendData(MyDefine.TriggerAndEnableO8);
            MyParam.commonParam.myComportOQC.SendData(MyDefine.TriggerAndEnableO8);
        }
        private void SetUIFunc(eFunc func)
        {
            if (func == eFunc.eFunctionDamCaMau)
            {
                tableLayoutPanelModeDCM.Visible = true;
                splitContainer1.Visible = false;
                groupBoxDCMChart.Visible = true;
                tableLayoutPanelIQCOQCChart.Visible = false;
                groupBoxSpeedDCM.Visible = true;
                tableLayoutPanelSpeedIQCOQC.Visible = false;
            }
            else if (func == eFunc.eFunctionNormal)
            {
                tableLayoutPanelModeDCM.Visible = false;
                splitContainer1.Visible = true;
                groupBoxDCMChart.Visible = false;
                tableLayoutPanelIQCOQCChart.Visible = true;
                groupBoxSpeedDCM.Visible = false;
                tableLayoutPanelSpeedIQCOQC.Visible = true;
            }
        }


        //private void swModeDCM_CheckedChanged(object sender, EventArgs e)
        //{

        //    if (swModeDCM.Checked)
        //    {
        //        MaterialDialog materialDialog =
        //        new MaterialDialog(this, "Mode", "Chạy Mode Đạm Cà Mau", "OK", true, "Cancel");
        //        DialogResult result = materialDialog.ShowDialog(this);
        //        if (result == DialogResult.Cancel)
        //        {
        //            swModeDCM.Checked = false;
        //            return;
        //        }
        //        MyParam.runParam.Func = eFunc.eFunctionDamCaMau;
        //        SetUIFunc(eFunc.eFunctionDamCaMau);
        //        EnableBtn(btnInit,false);
        //        EnableBtn(btnStart, false);
        //        btnInputDataSourceDCM.Enabled = true;
        //        MyParam.commonParam.myExcel.SetSpreadSheet(spreadsheetControl1);
        //        if (MyParam.runParam.ProgramStatus == ePRGSTATUS.Initial)
        //        {
        //            AddLog(" Import File Excel sau đó Start chương trình", eIndex.Index_IQC_OQC_Log);
        //            StartBlinkButton();
        //        }
        //    }
        //    else
        //    {
        //        MyParam.runParam.Func = eFunc.eFunctionNormal;
        //        EnableBtn(btnInit, true);
        //        StopBlinkButton();
        //        SetUIFunc(eFunc.eFunctionNormal);
        //        if (MyParam.runParam.ProgramStatus == ePRGSTATUS.Initial)
        //        {
        //            EnableBtn(btnStart, true);
        //        }
        //        else
        //        {
        //            EnableBtn(btnStart, false);
        //        }
        //        btnInputDataSourceDCM.Enabled = false;
        //    }
        //}
        private bool IsValidExcelTemplate(SpreadsheetControl spreadsheet)
        {
            try
            {
                Worksheet sheet = spreadsheet.Document.Worksheets[0];

                // Lấy các tiêu đề với null-safe operator
                string col1 = sheet.Cells["A1"].Value?.TextValue?.Trim() ?? "";
                string col2 = sheet.Cells["B1"].Value?.TextValue?.Trim() ?? "";
                string col3 = sheet.Cells["C1"].Value?.TextValue?.Trim() ?? "";
                string col4 = sheet.Cells["D1"].Value?.TextValue?.Trim() ?? "";
                string col5 = sheet.Cells["E1"].Value?.TextValue?.Trim() ?? "";

                // So sánh với tiêu đề mẫu
                return col1 == MyParam.commonParam.devParam.col1
                    && col2 == MyParam.commonParam.devParam.col2
                    && col3 == MyParam.commonParam.devParam.col3
                    && col4 == MyParam.commonParam.devParam.col4
                    && col5 == MyParam.commonParam.devParam.col5;
            }
            catch
            {
                return false;
            }
        }
        private void btnInputDataSourceDCM_Click(object sender, EventArgs e)
        {
            var bconnectDB = MyParam.commonParam.mongoDBService.ConnectMongoDb($"{MyParam.runParam.MongoClient}?connectTimeoutMS={MyParam.runParam.ConnectTimeOut}&socketTimeoutMS=10000&serverSelectionTimeoutMS=5000");
            if (!bconnectDB)
            {
                MyLib.showDlgError("Kết nối đến MongoDB thất bại, vui lòng kiểm tra lại");
                return;
            }
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files|*.xlsx;*.xls";
                ofd.Title = "Select an Excel File";


                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        spreadsheetControl1.LoadDocument(ofd.FileName);
                        MyParam.runParam.FileNameDamCaMau = Path.GetFileName(ofd.FileName);
                        

                        if (!IsValidExcelTemplate(spreadsheetControl1))
                        {
                            MyLib.showDlgError("❌ File Excel không đúng định dạng yêu cầu. Vui lòng kiểm tra lại!");
                            spreadsheetControl1.CreateNewDocument(); // Trả về trạng thái trống
                        }
                        else // Load OK
                        {
                            var x = SaveFileExcel(FileExistsAction.Question);
                            if(!x)
                            {
                                spreadsheetControl1.CreateNewDocument();
                                MyParam.runParam.FileNameDamCaMau = string.Empty;
                                return;
                            }
                            StopBlinkButtonImportFileExcel();
                            EnableBtn(btnInit, true);
                            EnableBtn(btnReset, true);
                            groupBoxDcm.Enabled = false; 
                          
                            MyParam.commonParam.myExcel.LoadEpcFromExcel();

                            var dbName = Regex.Replace(Path.GetFileNameWithoutExtension(ofd.FileName), @"[^a-zA-Z0-9_]", "_").ToUpper();
                            
                            var allDataBaseName = MyParam.commonParam.mongoDBService.GetAllDatabaseNames();
                            if (allDataBaseName.Contains(dbName))
                            {
                                dbName = dbName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                            }
                            MyParam.runParam.DataBaseNameDamCaMau = dbName;
                            UpdateLabelRollName(dbName);
                            UpdateLabelDCMAfterLoadNewFileExcel();
                            MyParam.runParam.HistoryDamCaMauData.Clear();
                            MyParam.commonParam.myExcel.LoadTidToHistory(MyParam.runParam.HistoryDamCaMauData);
                            MyLib.showDlgInfo("Tạo cuộn mới thành công");
                        }
                    }
                    catch (Exception ex)
                    {
                        MyLib.showDlgError("Lỗi khi load file: " + ex.Message);
                        spreadsheetControl1.CreateNewDocument(); 
                    }
                }
            }
        }
       
        private System.Windows.Forms.Timer checkTimerIQC;
        private DateTime lastUpdateTimeIQC;
        private System.Windows.Forms.Timer checkTimerOQC;
        private DateTime lastUpdateTimeOQC;
        private System.Windows.Forms.Timer checkTimerDCM;
        private DateTime lastUpdateTimeDCM;
        private void CheckTimer_Tick_IQC(object sender, EventArgs e)
        {
            // Nếu không có sự thay đổi trong 2 giây, gán lại label = 0
            if ((DateTime.Now - lastUpdateTimeIQC).TotalSeconds >= 2)
            {
                lbSpeedIQC.Text = "0 pcs/s";
                checkTimerIQC.Stop(); // Dừng timer khi không cần kiểm tra nữa
            }
        }
        private void CheckTimer_Tick_OQC(object sender, EventArgs e)
        {
            // Nếu không có sự thay đổi trong 2 giây, gán lại label = 0
            if ((DateTime.Now - lastUpdateTimeOQC).TotalSeconds >= 2)
            {
                lbSpeedOQC.Text = "0 pcs/s";
                checkTimerOQC.Stop(); // Dừng timer khi không cần kiểm tra nữa
            }
        }
        private void CheckTimer_Tick_DCM(object sender, EventArgs e)
        {
            // Nếu không có sự thay đổi trong 2 giây, gán lại label = 0
            if ((DateTime.Now - lastUpdateTimeDCM).TotalSeconds >= 2)
            {
                lbSpeedDCM.Text = "0 pcs/s";
                checkTimerDCM.Stop(); // Dừng timer khi không cần kiểm tra nữa
            }
        }
        private static string GetLastDataAfterColon(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return string.Empty;

            int lastColonIndex = raw.LastIndexOf(':');

            // Không có dấu :
            if (lastColonIndex < 0)
                return string.Empty;

            // Dấu : nằm ở cuối chuỗi (không có gì phía sau)
            if (lastColonIndex == raw.Length - 1)
                return string.Empty;

            // Dữ liệu sau dấu : cuối cùng
            return raw.Substring(lastColonIndex + 1).Trim();
        }
        public void UpdateLabelSpeedIQC(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateLabelSpeedIQC), data);
                return;
            }

            var speed = GetLastDataAfterColon(data);

            lbSpeedIQC.Text = $"{speed} pcs/s";
            lastUpdateTimeIQC = DateTime.Now;

            if (checkTimerIQC == null)
            {
                checkTimerIQC = new System.Windows.Forms.Timer();
                checkTimerIQC.Interval = 1000;
                checkTimerIQC.Tick += CheckTimer_Tick_IQC;
            }

            if (!checkTimerIQC.Enabled)
            {
                checkTimerIQC.Start();
            }
        }
        public void UpdateLabelSpeedOQC(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateLabelSpeedOQC), data);
                return;
            }
            var speed = GetLastDataAfterColon(data);
            lbSpeedOQC.Text = $"{speed} pcs/s";
            lastUpdateTimeOQC = DateTime.Now;
            if (checkTimerOQC == null)
            {
                checkTimerOQC = new System.Windows.Forms.Timer();
                checkTimerOQC.Interval = 1000;
                checkTimerOQC.Tick += CheckTimer_Tick_OQC;
            }
            if (!checkTimerOQC.Enabled)
            {
                checkTimerOQC.Start();
            }
        }
        public void UpdateLabelSpeedDCM(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateLabelSpeedDCM), data);
                return;
            }
            var speed = GetLastDataAfterColon(data);
            lbSpeedDCM.Text = $"{speed} pcs/s";
            lastUpdateTimeDCM = DateTime.Now;
            if (checkTimerDCM == null)
            {
                checkTimerDCM = new System.Windows.Forms.Timer();
                checkTimerDCM.Interval = 1000;
                checkTimerDCM.Tick += CheckTimer_Tick_DCM;
            }
            if (!checkTimerDCM.Enabled)
            {
                checkTimerDCM.Start();
            }
        }
        private System.Windows.Forms.Timer blinkTimer;
        private bool isBlinkState = false;
        private void StartBlinkButtonImportFileExcel()
        {
            if (blinkTimer == null)
            {
                blinkTimer = new System.Windows.Forms.Timer();
                blinkTimer.Interval = 500; // Mỗi 0.5 giây đổi màu
                blinkTimer.Tick += BlinkTimer_Tick;
            }
            blinkTimer.Start();
        }

        private void StopBlinkButtonImportFileExcel()
        {
            if (blinkTimer != null)
            {
                blinkTimer.Stop();
                btnInputDataSourceDCM.Type = MaterialButton.MaterialButtonType.Contained;
                isBlinkState = false;
            }
        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            if (isBlinkState)
                btnInputDataSourceDCM.Type = MaterialButton.MaterialButtonType.Contained;
            else
                btnInputDataSourceDCM.Type = MaterialButton.MaterialButtonType.Outlined;

            isBlinkState = !isBlinkState;
        }

        private void btnFuncNormal_Click(object sender, EventArgs e)
        {
            EnableBtn(btnFuncNormal, false);
            EnableBtn(btnFuncDCM, true);
            FuncNormal();
        }
        public void FuncNormal()
        {
            SetFuncAndHighlightButton(eFunc.eFunctionNormal, btnFuncNormal);
            SetUIFunc(eFunc.eFunctionNormal);

            EnableBtn(btnInit, true);
            EnableBtn(btnStart, false);
            EnableBtn(btnNewRoll, true);
            EnableBtn(btnInputDataSourceDCM, false);
            StopBlinkButtonImportFileExcel();
            groupBoxMode.Enabled = true;

            UpdateLabelRollName(MyParam.runParam.DataBaseName);
            swFlushDB.Checked = true;

        }

        public void UpdateLabelRollName(string name)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateLabelRollName), name);
                return;
            }
            string dbName = Regex.Replace(name, ".{10}", "$0\n"); // xuống dòng mỗi 10 ký tự
            btnRollName.Text = dbName;
            
        }
        private void btnFuncDCM_Click(object sender, EventArgs e) // Chạy chế độ Đạm Cà Mau
        {
            EnableBtn(btnFuncDCM, false);
            EnableBtn(btnFuncNormal, true);
            FuncDCM();
        }
        public void FuncDCM()
        {
            MyParam.commonParam.myExcel.SetSpreadSheet(spreadsheetControl1);
            swFlushDB.Checked = false;
            var x = LoadFileExcel();
            if (!x)
            {
                SetFuncAndHighlightButton(eFunc.eFunctionDamCaMau, btnFuncDCM);
                SetUIFunc(eFunc.eFunctionDamCaMau);
                SetModeAndHighlight(eMode.eEPC_TID, btnEPCTID);
                EnableBtn(btnInit, false);
                EnableBtn(btnStart, false);
                EnableBtn(btnNewRoll, false);
                EnableBtn(btnInputDataSourceDCM, true);
                groupBoxMode.Enabled = false;

                AddLog("Import File Excel sau đó Start chương trình", eIndex.Index_IQC_OQC_Log);
                StartBlinkButtonImportFileExcel();
                MyParam.runParam.DataBaseNameDamCaMau = MyDefine.dataBaseNameDefault;
                UpdateLabelRollName(MyParam.runParam.DataBaseNameDamCaMau);
            }
            else
            {
                SetFuncAndHighlightButton(eFunc.eFunctionDamCaMau, btnFuncDCM);
                SetUIFunc(eFunc.eFunctionDamCaMau);
                SetModeAndHighlight(eMode.eEPC_TID, btnEPCTID);
                EnableBtn(btnInit, true);
                EnableBtn(btnStart, false);
                EnableBtn(btnNewRoll, false);
                EnableBtn(btnReset, true);
                groupBoxMode.Enabled = false;

                AddLog($"Load File Excel {MyParam.runParam.FileNameDamCaMau} thành công", eIndex.Index_IQC_OQC_Log);
                UpdateLabelRollName(MyParam.runParam.DataBaseNameDamCaMau);
                MyParam.commonParam.myExcel.LoadEpcFromExcel();
                MyParam.commonParam.myExcel.LoadTidToHistory(MyParam.runParam.HistoryDamCaMauData);
                UpdateLabelDCMAfterLoadNewFileExcel();
               
            }
        }
        void UpdateLabelDCMAfterLoadNewFileExcel()
        {
            int rowsWithTid = MyParam.commonParam.myExcel.CountRowsWithTid();
            countOK_DamCaMau = rowsWithTid;
            UpdateLabelDCM();
            UpdateChart(chartDCM, countOK_DamCaMau, countNG_DamCaMau);
        }

        private void spreadsheetControl1_Click(object sender, EventArgs e)
        {

        }
        private FormListTIDEmpty _formListTIDEmpty = null;
        private FormChangeItem _formChangeItem = null;
        private void cbbFindRoll_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rollIndex = cbbFindRoll.SelectedIndex;
            int startRow = rollIndex * 3000 + 1;
            int endRow = startRow + 3000;

            var emptyCells = GetEmptyCellsInColumnD(startRow, endRow);

            // Nếu popup cũ còn mở thì đóng lại
            if (_formListTIDEmpty != null && !_formListTIDEmpty.IsDisposed)
            {
                _formListTIDEmpty.Close();
            }
            // Mở popup mới
            _formListTIDEmpty = new FormListTIDEmpty(emptyCells, spreadsheetControl1);
          //  _formListTIDEmpty.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            _formListTIDEmpty.Show();
            _formListTIDEmpty.FormClosed += (s, args) => _formListTIDEmpty = null;
        }
        private List<string> GetEmptyCellsInColumnD(int startRow, int endRow)
        {
            Worksheet sheet = spreadsheetControl1.Document.Worksheets[0];
            List<string> emptyCells = new List<string>();

            for (int row = startRow; row < endRow; row++)
            {
                Cell cell = sheet.Cells[row, 3]; // 3 tương ứng cột D
                if (cell.Value.IsEmpty)
                {
                    emptyCells.Add(cell.GetReferenceA1());
                }
            }

            return emptyCells;
        }

        private void btnReplaceItem_Click(object sender, EventArgs e)
        {
            // Nếu popup cũ còn mở thì đóng lại
            if (_formChangeItem != null && !_formChangeItem.IsDisposed)
            {
                _formChangeItem.Close();
            }
            // Mở popup mới
            _formChangeItem = new FormChangeItem(spreadsheetControl1);
          //  _formChangeItem.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            _formChangeItem.Show();
            _formChangeItem.FormClosed += (s, args) => _formChangeItem = null;
        }

        private void swFlushDB_CheckedChanged(object sender, EventArgs e)
        {
            if (swFlushDB.Checked)
            {
                MyParam.commonParam.devParam.ignoreDataBase = false;
            }
            else
            {
                MyParam.commonParam.devParam.ignoreDataBase = true;
            }
        }
    }
}
