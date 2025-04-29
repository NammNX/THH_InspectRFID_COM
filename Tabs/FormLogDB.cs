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
using ClosedXML.Excel;
using ClosedXML.Excel.Drawings;
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
            DateTime startDate = mtDatePicker1.Date.Date;
            DateTime endDate = mtDatePicker2.Date.Date.AddDays(1); // inclusive

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
                    EPC = doc.GetValue("EPC", "").AsString,
                    TID = doc.GetValue("TID", "").AsString,
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
        private string HexToAscii(string hexValue)
        {
            try
            {
                // Chuyển đổi Hex thành ASCII
                if (hexValue.Length % 2 != 0)
                    hexValue = "0" + hexValue;  // Nếu số ký tự là lẻ, thêm số 0 vào đầu

                byte[] bytes = new byte[hexValue.Length / 2];
                for (int i = 0; i < hexValue.Length; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(hexValue.Substring(i, 2), 16);
                }
                return System.Text.Encoding.ASCII.GetString(bytes);
            }
            catch
            {
                return hexValue;  // Trả lại giá trị gốc nếu có lỗi
            }
        }



        private void ExportToExcel()
        {
            // Kiểm tra nếu DataGridView không có dữ liệu
            if (dataGridView1.Rows.Count == 0)
            {
                MyLib.showDlgError("DataGridView không có dữ liệu để xuất!");
                return; // Không tiếp tục nếu không có dữ liệu
            }
            this.Cursor = Cursors.WaitCursor;

            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Log");

                int headerRow = 1;

                // 1. Header
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    var headerCell = ws.Cell(headerRow, i + 1);
                    string headerText = dataGridView1.Columns[i].HeaderText;

                    headerCell.Value = headerText;
                    headerCell.Style.Font.Bold = true;
                    headerCell.Style.Fill.BackgroundColor = XLColor.Yellow;
                    headerCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    headerCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

                // 2. Data Rows
                int rowIndex = 2;
                int countOK = 0, countNG = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    bool isNG = false;

                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        var cell = ws.Cell(rowIndex, col + 1);
                        var value = row.Cells[col].Value?.ToString() ?? "";

                        // Kiểm tra nếu checkbox "Convert Hex to ASCII" được tick và nếu cột là "EPC"
                        if (cbHex2AciiEPC.Checked && dataGridView1.Columns[col].HeaderText == "EPC")
                        {
                            value = HexToAscii(value);  // Chuyển đổi Hex sang ASCII
                        }

                        cell.Value = value;
                        cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        if (dataGridView1.Columns[col].HeaderText == "Type" && value == "NG")
                            isNG = true;
                    }

                    if (isNG)
                    {
                        for (int col = 0; col < dataGridView1.Columns.Count; col++)
                        {
                            var cell = ws.Cell(rowIndex, col + 1);
                            cell.Style.Font.FontColor = XLColor.Red;
                        }
                        countNG++;
                    }
                    else
                    {
                        countOK++;
                    }

                    rowIndex++;
                }

                // 3. Auto-fit columns
                ws.Columns().AdjustToContents();

                // 4. Add Total table (cách 1 cột)
                int totalColStart = dataGridView1.Columns.Count + 2;
                int totalRowStart = 1;

                ws.Cell(totalRowStart, totalColStart).Value = "Total";
                ws.Range(totalRowStart, totalColStart, totalRowStart, totalColStart + 1).Merge();
                ws.Cell(totalRowStart, totalColStart).Style.Font.Bold = true;
                ws.Cell(totalRowStart, totalColStart).Style.Fill.BackgroundColor = XLColor.LightGray;
                ws.Cell(totalRowStart, totalColStart).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell(totalRowStart, totalColStart).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                // OK | NG
                ws.Cell(totalRowStart + 1, totalColStart).Value = "OK";
                ws.Cell(totalRowStart + 1, totalColStart + 1).Value = "NG";
                ws.Cell(totalRowStart + 2, totalColStart).Value = countOK;
                ws.Cell(totalRowStart + 2, totalColStart + 1).Value = countNG;

                // Kẻ bảng cho bảng total
                for (int r = totalRowStart + 1; r <= totalRowStart + 2; r++)
                {
                    for (int c = totalColStart; c <= totalColStart + 1; c++)
                    {
                        ws.Cell(r, c).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        ws.Cell(r, c).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }
                }

                // 5. Save to file
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    // Thêm "_convert2ascii" vào tên file nếu checkbox được tick chọn
                    string fileName = $"Log_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    if (cbHex2AciiEPC.Checked)
                    {
                        fileName = fileName.Replace(".xlsx", "_convert2ascii.xlsx");
                    }
                    sfd.FileName = fileName;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(sfd.FileName);
                       MyLib.showDlgInfo("Export thành công!");
                    }
                }

                this.Cursor = Cursors.Default;
            }
        }


        private void ExportToExcel2()
        {
            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Log");

                int headerRow = 1;

                // 1. Header
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    var headerCell = ws.Cell(headerRow, i + 1);
                    string headerText = dataGridView1.Columns[i].HeaderText;

                    headerCell.Value = headerText;
                    headerCell.Style.Font.Bold = true;
                    headerCell.Style.Fill.BackgroundColor = XLColor.Yellow;
                    headerCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    headerCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

                // 2. Data Rows
                int rowIndex = 2;
                int countOK = 0, countNG = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    bool isNG = false;

                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        var cell = ws.Cell(rowIndex, col + 1);
                        var value = row.Cells[col].Value?.ToString() ?? "";
                        cell.Value = value;
                        cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        if (dataGridView1.Columns[col].HeaderText == "Type" && value == "NG")
                            isNG = true;
                    }

                    if (isNG)
                    {
                        for (int col = 0; col < dataGridView1.Columns.Count; col++)
                        {
                            var cell = ws.Cell(rowIndex, col + 1);
                            cell.Style.Font.FontColor = XLColor.Red;
                        }
                        countNG++;
                    }
                    else
                    {
                        countOK++;
                    }

                    rowIndex++;
                }

                // 3. Auto-fit columns
                ws.Columns().AdjustToContents();

                // 4. Add Total table (cách 1 cột)
                int totalColStart = dataGridView1.Columns.Count + 2;
                int totalRowStart = 1;

                ws.Cell(totalRowStart, totalColStart).Value = "Total";
                ws.Range(totalRowStart, totalColStart, totalRowStart, totalColStart + 1).Merge();
                ws.Cell(totalRowStart, totalColStart).Style.Font.Bold = true;
                ws.Cell(totalRowStart, totalColStart).Style.Fill.BackgroundColor = XLColor.LightGray;
                ws.Cell(totalRowStart, totalColStart).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell(totalRowStart, totalColStart).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                // OK | NG
                ws.Cell(totalRowStart + 1, totalColStart).Value = "OK";
                ws.Cell(totalRowStart + 1, totalColStart + 1).Value = "NG";
                ws.Cell(totalRowStart + 2, totalColStart).Value = countOK;
                ws.Cell(totalRowStart + 2, totalColStart + 1).Value = countNG;

                // Kẻ bảng cho bảng total
                for (int r = totalRowStart + 1; r <= totalRowStart + 2; r++)
                {
                    for (int c = totalColStart; c <= totalColStart + 1; c++)
                    {
                        ws.Cell(r, c).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        ws.Cell(r, c).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }
                }

                // 5. Save to file
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    sfd.FileName = $"Log_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Export thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
            //if (dataGridView1.Rows.Count == 0)
            //{
            //    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //using (var sfd = new SaveFileDialog { Filter = "Excel Workbook|*.xlsx", FileName = "LogDB.xlsx" })
            //{
            //    if (sfd.ShowDialog() != DialogResult.OK) return;

            //    try
            //    {
            //        using (var wb = new XLWorkbook())
            //        {
            //            var ws = wb.Worksheets.Add("LogData");

            //            // Đầu tiên, ghi header
            //            for (int col = 0; col < dataGridView1.Columns.Count; col++)
            //            {
            //                var header = dataGridView1.Columns[col].HeaderText;
            //                var cell = ws.Cell(1, col + 1);
            //                cell.Value = header;

            //                // Kẻ viền cho ô
            //                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

            //                // Nếu ô header có chữ -> tô nền vàng
            //                if (!string.IsNullOrEmpty(header))
            //                {
            //                    cell.Style.Fill.BackgroundColor = XLColor.Yellow;
            //                }
            //            }

            //            // Sau đó ghi dữ liệu
            //            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            //            {
            //                bool isNG = false;

            //                for (int col = 0; col < dataGridView1.Columns.Count; col++)
            //                {
            //                    var value = dataGridView1.Rows[row].Cells[col].Value?.ToString() ?? "";
            //                    var cell = ws.Cell(row + 2, col + 1);
            //                    cell.Value = value;

            //                    // Kẻ viền cho ô
            //                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

            //                    // Kiểm tra nếu cột Type có giá trị "NG"
            //                    if (dataGridView1.Columns[col].HeaderText == "Type" && value == "NG")
            //                    {
            //                        isNG = true;
            //                    }
            //                }

            //                if (isNG)
            //                {
            //                    ws.Row(row + 2).Style.Font.FontColor = XLColor.Red;
            //                }
            //            }


            //            // 3. Tự động điều chỉnh kích thước cột
            //            ws.Columns().AdjustToContents();

            //            // 4. Lưu file
            //            wb.SaveAs(sfd.FileName);
            //        }

            //        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            }
        }
    }

