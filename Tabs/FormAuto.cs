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
using System.Security.Cryptography;

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

        public FormAuto()
        {
            InitializeComponent();
            SetupChart(chartIQC);
            SetupChart(chartOQC);
        }

        public void StopProgram()
        {
            if ((MyParam.commonParam.myComportIQC.GetQueueCount() > 0) || (MyParam.commonParam.myComportOQC.GetQueueCount() > 0)
                || (MongoDBService.GetIqcBufferCount() > 0) || (MongoDBService.GetOqcBufferCount() > 0))
            {
                Console.WriteLine($"{MyParam.commonParam.myComportIQC.GetQueueCount()},{MongoDBService.GetIqcBufferCount()}");
                MyLib.showDlgInfo("Quá trình ghi dữ liệu vào data base chưa hoàn tất, vui lòng đợi trong giây lát");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            //Close all connection
            MyLib.CloseAllDevices((int)eTaskLoop.Task_HEATBEAT);

            MyParam.commonParam.myComportIQC.DisConnect();
            MyParam.commonParam.myComportOQC.DisConnect();

            EnableBtn(btnStart, true);
            EnableBtn(btnReset, true);
            EnableBtn(btnStop, false);
            ChangeColor(groupBoxIQC, false);
            ChangeColor(groupBoxOQC, false);
            ChangeColor(groupBoxChartIQC, false);
            ChangeColor(groupBoxOQChart, false);

            if (MyParam.runParam.ProgramStatus == ePRGSTATUS.Started)
            {
                MainProcess.AddLogAuto($"Disconnect COM IQC", eIndex.Index_IQC_OQC_Log);
                MainProcess.AddLogAuto($"Disconnect COM OQC", eIndex.Index_IQC_OQC_Log);
            }
            MainProcess.isRunLoopCOM = false;
            MainProcess.isChartUpdateRunning = false;
            MongoDBService.isFlushLoop = false;

            MyParam.runParam.ProgramStatus = ePRGSTATUS.Stoped;
            this.Cursor = Cursors.Default;
        }



        //void StartProgram()
        //{

        //    EnableBtn(btnReset, false);
        //    EnableBtn(btnStop, true); 
        //    MyParam.runParam.ProgramStatus = ePRGSTATUS.Started;
        //}

        public async void StartProgram()
        {
            this.Cursor = Cursors.WaitCursor;
            var x = THHInitial.InitDevice();
            await x;
            Console.WriteLine("-------------btnInitial = " + x.Result);

            if (x.Result)
            {
                EnableBtn(btnStart, false);
                EnableBtn(btnReset, false);
                EnableBtn(btnStop, true);
                ChangeColor(groupBoxIQC, true);
                ChangeColor(groupBoxOQC, true);
                ChangeColor(groupBoxOQChart, true);
                ChangeColor(groupBoxChartIQC, true);

                MyParam.commonParam.myComportIQC.ClearDataRev();
                MyParam.commonParam.myComportOQC.ClearDataRev();

                MainProcess.RunLoopChartUpdate();

                MainProcess.RunLoopCOM();
                if (!MyParam.commonParam.devParam.ignoreDataBase)
                {
                    swFlushDB.Checked = true;
                    MongoDBService.RunFlushLoop();
                }
                else
                {
                   swFlushDB.Checked = false;
                }
                MainProcess.MainIQC_StepCtrl.SetStep(eProcessing.ReceiveData);
                MainProcess.MainOQC_StepCtrl.SetStep(eProcessing.ReceiveData);
                MyParam.runParam.ProgramStatus = ePRGSTATUS.Started;
            }
            else
            {
                EnableBtn(btnReset, false);
                EnableBtn(btnStop, false);
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
                //reset label IQCOQC
                resetIQC();
                resetOQC();
                StopProgram();
                EnableBtn(btnReset, false);
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
            MyParam.commonParam.myComportIQC.SendData(MyDefine.ResetIO_RFID);
        }
        void resetOQC()
        {
            lvOQC.Items.Clear();
            UpdateChart(chartOQC, 0, 0);
            countOK_OQC = 0;
            countNG_OQC = 0;
            UpdateLabelOQC();
            MyParam.commonParam.myComportOQC.SendData(MyDefine.ResetIO_RFID);
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

        private void btnProgramAction(object sender, EventArgs e)
        {
            var btnName = ((MaterialButton)sender).Name;
            switch (btnName)
            {
                case "btnStop":

                    StopProgram();
                    break;

                case "btnStart":
                    StartProgram();
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
            lbIQCbuffer.Text = ($"IQC Buffer: {MongoDBService.GetIqcBufferCount()}");
            lbOQCbuffer.Text = ($"OQC Buffer: {MongoDBService.GetOqcBufferCount()}");
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
                btnRollName.Text = result;
                MyParam.runParam.DataBaseName = result;
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

    }
}
