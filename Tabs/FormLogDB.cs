using MaterialSkin.Controls;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TanHungHa.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TanHungHa.Tabs
{
    public partial class FormLogDB : MaterialForm
    {
        private static FormLogDB _instance;
        private static readonly object _lock = new object();
        public static FormLogDB GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FormLogDB();
                    }
                }
            }
            return _instance;
        }
        public FormLogDB()
        {
            InitializeComponent();
            SetupChart(chart);
            //MongoDBService.ConnectMongoDb($"{MyParam.runParam.MongoClient}?connectTimeoutMS={MyParam.runParam.ConnectTimeOut}&socketTimeoutMS=10000&serverSelectionTimeoutMS=5000", $"{MyParam.runParam.DataBaseName}");
            //  dataGridView1.Columns["Time"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            //  dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

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
        private void LoadDataToGrid()
        {
            DateTime startDate = mtDatePicker.Date.Date;
            DateTime endDate = materialDropDownDatePicker1.Date.Date.AddDays(1); // inclusive

            var dataList = new List<BsonDocument>();

            if (cbIQC.Checked)
            {
                if (cbOK.Checked) dataList.AddRange(MongoDBService.QueryByTypeAndDateRange("IQC", "OK", startDate, endDate));
                if (cbNG.Checked) dataList.AddRange(MongoDBService.QueryByTypeAndDateRange("IQC", "NG", startDate, endDate));
                if (!cbOK.Checked && !cbNG.Checked) dataList.AddRange(MongoDBService.QueryByDateRange("IQC", startDate, endDate));
            }

            if (cbOQC.Checked)
            {
                if (cbOK.Checked) dataList.AddRange(MongoDBService.QueryByTypeAndDateRange("OQC", "OK", startDate, endDate));
                if (cbNG.Checked) dataList.AddRange(MongoDBService.QueryByTypeAndDateRange("OQC", "NG", startDate, endDate));
                if (!cbOK.Checked && !cbNG.Checked) dataList.AddRange(MongoDBService.QueryByDateRange("OQC", startDate, endDate));
            }

            // Count OK / NG
            int countOK = dataList.Count(d => d.GetValue("Type", "").AsString == "OK");
            int countNG = dataList.Count(d => d.GetValue("Type", "").AsString == "NG");

            UpdateChart(chart, countOK, countNG);   // Cập nhật biểu đồ

            UpdateLabel(countOK, countNG); // Cập nhật label

            var viewList = dataList.Select(doc =>
            {
                var timestamp = doc.GetValue("Timestamp").ToLocalTime();
                return new
                {
                    Date = timestamp.ToString("yyyy-MM-dd"),
                    Time = timestamp.ToString("HH:mm:ss"),
                    Data = doc.GetValue("Data", "").AsString,
                    Type = doc.GetValue("Type", "").AsString
                };
            }).ToList();

            dataGridView1.DataSource = viewList;
        }
        private void UpdateLabel(int OK,int NG)
        {
            lbOK.Text = ($"OK: {OK.ToString()}");
            lbNG.Text = ($"NG: {NG.ToString()}");
            lbTotal.Text = ($"Total: {OK + NG}");
        }

        private void UpdateGroupBox()
        {
                if (cbIQC.Checked)
                {
                    groupGridView.Text = "IQC";
                    groupBoxChart.Text = "Chart IQC";
                }
                else if (cbOQC.Checked)
                {
                    groupGridView.Text = "OQC";
                    groupBoxChart.Text = "Chart OQC";
                }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           
            MongoDBService.ConnectMongoDb($"{MyParam.runParam.MongoClient}?connectTimeoutMS={MyParam.runParam.ConnectTimeOut}&socketTimeoutMS=10000&serverSelectionTimeoutMS=5000", $"{MyParam.runParam.DataBaseName}");
            try
            {
                LoadDataToGrid();
            }
            catch (Exception ex)
            {
                MyLib.showDlgError($"Error loading data: {ex.Message}");
            }
            UpdateGroupBox();
        }
        bool isHandling = false;
        private void cbIQC_CheckedChanged(object sender, EventArgs e)
        {
            if (isHandling) return;
            isHandling = true;

            if (cbIQC.Checked)
            {
                cbOQC.Checked = false;
            }

            isHandling = false;
        }

        private void cbOQC_CheckedChanged(object sender, EventArgs e)
        {
            if (isHandling) return;
            isHandling = true;

            if (cbOQC.Checked)
            {
                cbIQC.Checked = false;
            }

            isHandling = false;
        }

        private void cbOQC_CheckStateChanged(object sender, EventArgs e)
        {
           
        }

        private void cbIQC_CheckStateChanged(object sender, EventArgs e)
        {
          
        }
    }
}
