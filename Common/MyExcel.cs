using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DevExpress.XtraRichEdit.Model;
using DocumentFormat.OpenXml.Drawing;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using System.IO;
using System.Collections.Concurrent;
using TanHungHa.PopUp;
using SharpCompress.Common;
using System.Threading;

namespace TanHungHa.Common
{
    public class MyExcel
    {
        private SpreadsheetControl spreadsheet;
        private readonly ConcurrentDictionary<string, int> epcRowMap = new ConcurrentDictionary<string, int>();
        private Worksheet sheet;
        // Cấu hình cột
        private readonly int epcColumnIndex = 2; // Cột C
        private readonly int tidColumnIndex = 3; // Cột D
        private readonly int QrCodeColumnIndex = 4; // Cột E
        public MyExcel()
        {

        }

        /// <summary>
        /// Gán đối tượng SpreadsheetControl để sử dụng trong class
        /// </summary>
        public void SetSpreadSheet(SpreadsheetControl spr)
        {
            spreadsheet = spr ?? throw new ArgumentNullException(nameof(spr));
            

        }
        /// <summary>
        /// Gọi hàm này sau khi LoadDocument
        /// </summary>
        public void LoadEpcFromExcel()
        {
            epcRowMap.Clear();
            sheet = spreadsheet.Document.Worksheets[0];
            if (spreadsheet.InvokeRequired)
            {
                spreadsheet.BeginInvoke(new Action(() =>
                {
                    sheet.Columns.AutoFit(0, sheet.Columns.LastUsedIndex);
                    sheet.Columns[tidColumnIndex].Width = MyParam.commonParam.devParam.WidthTidColumn;
                }));
            }
            else
            {
                sheet.Columns.AutoFit(0, sheet.Columns.LastUsedIndex);
                sheet.Columns[tidColumnIndex].Width = MyParam.commonParam.devParam.WidthTidColumn;
            }
            
            CellRange usedRange = sheet.GetUsedRange();

            int startRow = usedRange.TopRowIndex;
            int endRow = usedRange.BottomRowIndex;

            for (int row = startRow + 1; row <= endRow; row++) // Bỏ dòng tiêu đề
            {
                string epc = sheet.Cells[row, epcColumnIndex].Value.TextValue.Trim();
                if (!string.IsNullOrEmpty(epc) && !epcRowMap.ContainsKey(epc))
                {
                    epcRowMap[epc] = row;
                }
            }
            Console.WriteLine($"Loaded {epcRowMap.Count} EPCs from Excel.");
        }

        /// <summary>
        /// Gán TID vào đúng dòng EPC trong Excel nếu có
        /// </summary>
        //public bool SetTidForEpc(string epc, string tid, bool highlight = true)
        //{
        //    if (epcRowMap.TryGetValue(epc, out int rowIndex))
        //    {
        //        Worksheet sheet = spreadsheet.Document.Worksheets[0];
        //        sheet.Cells[rowIndex, tidColumnIndex].Value = tid;

        //        if (highlight)
        //            sheet.Rows[rowIndex].FillColor = Color.LightGreen;

        //        return true;
        //    }
        //    return false;
        //}

        public void SetTidForEpc(string epc, string tid)
        {

            if (!spreadsheet.InvokeRequired)
            {
                SetTidForEpcUIThread(epc, tid);
            }
            else
            {
                spreadsheet.BeginInvoke(new Action(() =>
                {
                    SetTidForEpcUIThread(epc, tid);
                }));
            }
            //Kết thúc đếm thời gian

        }
        private void SetTidForEpcUIThread(string epc, string tid)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            if (epcRowMap.TryGetValue(epc, out int rowIndex))
            {
                sheet = spreadsheet.Document.Worksheets[0];
                sheet.Cells[rowIndex, tidColumnIndex].Value = tid;
                sheet.Rows[rowIndex].FillColor = Color.LightGreen;

                ScrollExcel(rowIndex);
                UpdateIndexRoll(rowIndex);


                if (MyParam.autoForm.swCheckMissItem.Checked)
                {
                    CheckMissItem(rowIndex);
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"[---Hàm vẽ excel UI---] Time taken: {stopwatch.ElapsedMilliseconds} ms");
        }

        private int lastIndexRoll = -1;
        private void UpdateIndexRoll(int rowIndex)
        {
            int indexRoll = ((rowIndex - 1) / 3000) + 1;
            if (indexRoll == lastIndexRoll) return; // không đổi thì bỏ qua

            lastIndexRoll = indexRoll;

            if (MyParam.autoForm.btnIndexRoll.InvokeRequired)
            {
                MyParam.autoForm.btnIndexRoll.BeginInvoke(new Action(() =>
                {
                    MyParam.autoForm.btnIndexRoll.Text = $"Cuộn số: {indexRoll}";
                }));
            }
            else
            {
                MyParam.autoForm.btnIndexRoll.Text = $"Cuộn số: {indexRoll}";
            }
        }

        private FormCheckMissItems checkMissItemForm = null;
        private void CheckMissItem(int rowIndex)
        {
            if (int.TryParse(MyParam.autoForm.SpeedDCM, out int speed))
            {
                
                if (checkMissItemForm?.RemoveRowIfExists(rowIndex) == true)
                {
                    return;
                }
                if (speed < MyParam.commonParam.devParam.SpeedCheckMissItem)
                {
                    lastTidRowIndex = null;
                    return;
                }
                int? _lastTidRowIndex = lastTidRowIndex;
                if (!IsRowAdjacentToPrevious(rowIndex))
                {
                    MyParam.commonParam.myComportIQC.SendData(MyDefine.StopMachine);
                    // Tính danh sách các dòng bị thiếu
                    List<int> missingRows = new List<int>();
                    if (_lastTidRowIndex.HasValue)
                    {
                        int start = Math.Min(_lastTidRowIndex.Value, rowIndex);
                        int end = Math.Max(_lastTidRowIndex.Value, rowIndex);

                        for (int i = start + 1; i < end; i++)
                        {
                            missingRows.Add(i);
                        }
                    }
                    if (checkMissItemForm == null || checkMissItemForm.IsDisposed)
                    {
                        checkMissItemForm = new FormCheckMissItems(spreadsheet);
                        checkMissItemForm.Show();
                    }

                    checkMissItemForm.UpdateMissingRows(missingRows);
                }
            }
        }

        private DateTime lastScrollTime = DateTime.MinValue;
        private const int SCROLL_THROTTLE_MS = 2000;
        private void ScrollExcel(int rowIndex)
        {
            DateTime now = DateTime.Now;
            if ((now - lastScrollTime).TotalMilliseconds < SCROLL_THROTTLE_MS)
                return; 

            lastScrollTime = now;

            if (rowIndex > 8)
            {
                spreadsheet.ActiveWorksheet.ScrollTo(rowIndex - 8, 0);
            }
            else
            {
                spreadsheet.ActiveWorksheet.ScrollTo(0, 0);
            }
        }

        /// <summary>
        /// Kiểm tra xem EPC có tồn tại trong danh sách không
        /// </summary>
        public bool ContainsEpc(string epc)
        {
            return epcRowMap.ContainsKey(epc);
        }


        /// <summary>
        /// Xóa định dạng và dữ liệu trong file Excel đang mở
        /// </summary>
        public void ClearWorksheet()
        {
            sheet = spreadsheet.Document.Worksheets[0];
            CellRange usedRange = sheet.GetUsedRange();
            sheet.Clear(usedRange);
        }
        /// <summary>
        /// Tạo file excel mới
        /// </summary>
        public void CreateNewExcelFile()
        {
            spreadsheet.CreateNewDocument();
        }
        /// <summary>
        /// Lưu file Excel đang mở tới đường dẫn cụ thể.
        /// </summary>
        /// <param name="filePath">Đường dẫn muốn lưu file, ví dụ: "C:\\Data\\output.xlsx"</param>
        /// <returns>True nếu lưu thành công, false nếu có lỗi.</returns>
        /// 
        // Throttle: Lần đầu save ngay, các lần sau phải đợi đủ 3 giây
        private DateTime lastSaveTime = DateTime.MinValue;
        private readonly object saveLock = new object();

        public void SaveExcelToPath1(string filePath)
        {
            lock (saveLock)
            {
                var now = DateTime.Now;
                var timeSinceLastSave = now - lastSaveTime;

                // Nếu chưa từng save hoặc đã đủ 3 giây -> save ngay
                if (lastSaveTime == DateTime.MinValue || timeSinceLastSave >= TimeSpan.FromSeconds(3))
                {
                    ExecuteSave(filePath);
                    lastSaveTime = DateTime.Now;
                }
                else
                {
                    // Chưa đủ 3 giây -> phải đợi
                    var remainingTime = TimeSpan.FromSeconds(3) - timeSinceLastSave;
                    Console.WriteLine($"Phải đợi thêm {remainingTime.TotalMilliseconds:F0}ms trước khi save tiếp");

                    // Đợi trên background thread để không block UI
                    Task.Run(() =>
                    {
                        Thread.Sleep(remainingTime);
                        lock (saveLock)
                        {
                            ExecuteSave(filePath);
                            lastSaveTime = DateTime.Now;
                        }
                    });
                }
            }
        }

        private void ExecuteSave(string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                    throw new ArgumentException("Invalid file path.");
                string tempFilePath = filePath + ".tmp";

                // Đảm bảo gọi SaveDocument trên UI thread
                if (spreadsheet.InvokeRequired)
                {
                    spreadsheet.BeginInvoke(new Action(() =>
                    {
                       // spreadsheet.SaveDocument(filePath, DevExpress.Spreadsheet.DocumentFormat.Xlsx);

                        spreadsheet.SaveDocument(tempFilePath, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
                        File.Copy(tempFilePath, filePath, true);
                        File.Delete(tempFilePath);
                    }));
                }
                else
                {
                   // spreadsheet.SaveDocument(filePath, DevExpress.Spreadsheet.DocumentFormat.Xlsx);

                    spreadsheet.SaveDocument(tempFilePath, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
                    File.Copy(tempFilePath, filePath, true);
                    File.Delete(tempFilePath);
                }

                Console.WriteLine($"Đã save file: {filePath} lúc {DateTime.Now}");
            }
            catch (Exception ex)
            {
                MainProcess.AddLogAuto($"[SOS]-----Error saving Excel file: {ex.Message}\n\nPath: {filePath}----------");
                Console.WriteLine($"--[SaveExcelToPath] Error saving Excel file:\n{ex.Message}\n\nPath: {filePath}-------------------------");
            }
        }



        public void SaveExcelToPathBackUp(string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                    throw new ArgumentException("Invalid file path.");

                // Nếu file đã tồn tại, tạo tên file mới với hậu tố (01), (02), ...
                string directory = System.IO.Path.GetDirectoryName(filePath);
                string filenameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(filePath);
                string extension = System.IO.Path.GetExtension(filePath);

                string finalPath = filePath;
                int index = 1;

                while (File.Exists(finalPath))
                {
                    finalPath = System.IO.Path.Combine(directory, $"{filenameWithoutExt} ({index}){extension}");
                    index++;
                }

                string tempFilePath = finalPath + ".tmp";

                Action saveAction = () =>
                {
                    spreadsheet.SaveDocument(tempFilePath, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
                    File.Copy(tempFilePath, finalPath, true);
                    File.Delete(tempFilePath);
                };

                if (spreadsheet.InvokeRequired)
                {
                    spreadsheet.BeginInvoke(saveAction);
                }
                else
                {
                    saveAction();
                }
            }
            catch (Exception ex)
            {
                MainProcess.AddLogAuto($"SOS-----Error saving Excel file: {ex.Message}\n\nPath: {filePath}----------");
                Console.WriteLine($"----------------------[SaveExcelToPath] Error saving Excel file:\n{ex.Message}\n\nPath: {filePath}-------------------------");
            }
        }


        public void SaveExcelToPath(string filePath)
        {
            try
            {
                string tempFilePath = filePath + ".tmp";
                if (string.IsNullOrWhiteSpace(filePath))
                    throw new ArgumentException("Invalid file path.");
                // Đảm bảo gọi SaveDocument trên UI thread
                if (spreadsheet.InvokeRequired)
                {
                    spreadsheet.BeginInvoke(new Action(() =>
                    {
                      //  spreadsheet.SaveDocument(filePath, DevExpress.Spreadsheet.DocumentFormat.Xlsx);

                        spreadsheet.SaveDocument(tempFilePath, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
                        File.Copy(tempFilePath, filePath, true);
                        File.Delete(tempFilePath);
                    }));
                }
                else
                {
                  //  spreadsheet.SaveDocument(filePath, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
                    spreadsheet.SaveDocument(tempFilePath, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
                    File.Copy(tempFilePath, filePath, true);
                    File.Delete(tempFilePath);
                }
               
            }
            catch (Exception ex)
            {
                MainProcess.AddLogAuto($"SOS-----Error saving Excel file: {ex.Message}\n\nPath: {filePath}----------");
                Console.WriteLine($"----------------------[SaveExcelToPath] Error saving Excel file:\n{ex.Message}\n\nPath: {filePath}-------------------------");
                
            }
        }





        /// <summary>
        /// Đếm số lượng dòng có dữ liệu (không rỗng) trong cột TID ,
        /// bất kể các dòng đó nằm rải rác.
        /// </summary>
        /// <returns>Số dòng có dữ liệu trong cột TID.</returns>
        public int CountRowsWithTid()
        {
            sheet = spreadsheet.Document.Worksheets[0];
            int rowCount = sheet.Rows.LastUsedIndex; // Lấy chỉ số dòng cuối cùng có sử dụng

            int count = 0;
            for (int row = 1; row <= rowCount; row++)
            {
                var cell = sheet.Cells[row, tidColumnIndex];
                if (!cell.Value.IsEmpty && !string.IsNullOrWhiteSpace(cell.Value.TextValue))
                {
                    count++;
                }
            }
            return count;
        }

        public void LoadTidToHistory(HashSet<string> historySet)
        {
            sheet = spreadsheet.Document.Worksheets[0];
            if (historySet == null)
                throw new ArgumentNullException(nameof(historySet));

            int rowCount = sheet.Rows.LastUsedIndex;

            for (int row = 1; row <= rowCount; row++)
            {
                var cell = sheet.Cells[row, tidColumnIndex];
                if (!cell.Value.IsEmpty)
                {
                    string tid = cell.Value.TextValue?.Trim();
                    if (!string.IsNullOrEmpty(tid))
                    {
                        historySet.Add(tid);
                    }
                }
            }

            Console.WriteLine($"[Count HashSet Data] DCM: {historySet.Count}");
        }
        /// <summary>
        /// Tìm tất cả các dòng chứa giá trị tương ứng trong cột TID (D) hoặc cột E.
        /// </summary>
        /// <param name="value">Giá trị cần tìm (không phân biệt hoa thường, bỏ khoảng trắng đầu/cuối).</param>
        /// <returns>Danh sách chỉ số dòng (bắt đầu từ 0) tìm thấy dữ liệu.</returns>
        public List<int> FindRowsByValueInTidOrQrCode(string value)
        {

            if (string.IsNullOrWhiteSpace(value))
                return new List<int>();

            string target = value.Trim().ToLower();
            List<int> matchedRows = new List<int>();

            sheet = spreadsheet.Document.Worksheets[0];
            int rowCount = sheet.Rows.LastUsedIndex;

            for (int row = 1; row <= rowCount; row++)
            {
                string valD = sheet.Cells[row, tidColumnIndex].Value.TextValue?.Trim().ToLower();
                string valE = sheet.Cells[row, QrCodeColumnIndex].Value.TextValue?.Trim().ToLower(); // Cột E

                if ((valD != null && valD == target) || (valE != null && valE==target))
                {
                    matchedRows.Add(row);
                }
            }

            // Scroll đến dòng đầu tiên tìm thấy
            if (matchedRows.Count == 1)
            {
                int scrollRow = matchedRows[0] > 5 ? matchedRows[0] - 5 : 0;

                if (!spreadsheet.InvokeRequired)
                {
                    spreadsheet.ActiveWorksheet.ScrollTo(scrollRow, 0);
                }
                else
                {
                    spreadsheet.BeginInvoke(new Action(() =>
                    {
                        spreadsheet.ActiveWorksheet.ScrollTo(scrollRow, 0);
                    }));
                }
                spreadsheet.SelectedCell = sheet.Cells[matchedRows[0], tidColumnIndex]; // hoặc QrCodeColumnIndex
            }

            return matchedRows;
        }

        private int? lastTidRowIndex = null;
        /// <summary>
        /// Kiểm tra xem dòng hiện tại có liền kề dòng trước đó đã gán TID hay không.
        /// Nếu đúng sẽ cập nhật dòng cuối và trả về true, nếu sai trả false.
        /// </summary>
        /// <param name="currentRowIndex">Dòng hiện tại (bắt đầu từ 0)</param>
        /// <returns>True nếu liền kề, false nếu không</returns>
        public bool IsRowAdjacentToPrevious(int currentRowIndex)
        {
            if (!lastTidRowIndex.HasValue)
            {
                // Trường hợp lần đầu tiên gán ⇒ luôn hợp lệ
                lastTidRowIndex = currentRowIndex;
                return true;
            }
            int diff = Math.Abs(currentRowIndex - lastTidRowIndex.Value);
            lastTidRowIndex = currentRowIndex;
            if (diff == 1)
            {
                return true;
            }
            // Không liền kề
            return false;
        }



    }
}
