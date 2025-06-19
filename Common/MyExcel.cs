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
                CheckMissItem(rowIndex);
                //if (rowIndex > 5)
                //{
                //    spreadsheet.ActiveWorksheet.ScrollTo(rowIndex - 5, 0);
                //}
                //else
                //{
                //    spreadsheet.ActiveWorksheet.ScrollTo(0, 0);
                //}

                //if (MyParam.autoForm.swCheckMissItem.Enabled)
                //{
                //    if (int.TryParse(MyParam.autoForm.SpeedDCM, out int speed))
                //    {
                //        if (speed < 5)
                //        {
                //            lastTidRowIndex = null;
                //        }
                //        else if (speed >= 5)
                //        {
                //            if (!IsRowAdjacentToPrevious(rowIndex))
                //            {
                //                MyLib.showDlgWarning($"Phát hiện có tem trống từ {rowIndex} đến {lastTidRowIndex}, Kiểm tra lại");
                //                MyParam.commonParam.myComportIQC.SendData(MyDefine.StopMachine);
                //            }
                //        }
                //    }
                //}
            }
            stopwatch.Stop();
            Console.WriteLine($"[---Hàm vẽ excel UI---] Time taken: {stopwatch.ElapsedMilliseconds} ms");
        }
        private void CheckMissItem(int rowIndex)
        {
            if (!MyParam.autoForm.swCheckMissItem.Checked)
                return;

            if (int.TryParse(MyParam.autoForm.SpeedDCM, out int speed))
            {
                if (speed < MyParam.commonParam.devParam.SpeedCheckMissItem)
                {
                    lastTidRowIndex = null;
                    return;
                }
                int? _lastTidRowIndex = lastTidRowIndex;
                if (!IsRowAdjacentToPrevious(rowIndex))
                {
                    MyLib.showDlgWarning($"Phát hiện có tem trống, Kiểm tra vị trí từ {rowIndex} đến {_lastTidRowIndex}");
                    MyParam.commonParam.myComportIQC.SendData(MyDefine.StopMachine);
                }
                
            }

        }

        private DateTime lastScrollTime = DateTime.MinValue;
        private const int SCROLL_THROTTLE_MS = 1500;
        private void ScrollExcel(int rowIndex)
        {
            var now = DateTime.Now;
            if ((now - lastScrollTime).TotalMilliseconds < SCROLL_THROTTLE_MS)
                return; 

            lastScrollTime = now;

            if (rowIndex > 5)
            {
                spreadsheet.ActiveWorksheet.ScrollTo(rowIndex - 5, 0);
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

        public bool SaveExcelToPath(string filePath)
        {
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                    throw new ArgumentException("Invalid file path.");



                // Đảm bảo gọi SaveDocument trên UI thread
                if (spreadsheet.InvokeRequired)
                {
                    spreadsheet.BeginInvoke(new Action(() =>
                    {
                        spreadsheet.SaveDocument(filePath, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
                    }));
                }
                else
                {
                    spreadsheet.SaveDocument(filePath, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
                }

                sw.Stop();
                Console.WriteLine($"[SaveExcelToPath] Save done in {sw.ElapsedMilliseconds} ms");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"----------------------[SaveExcelToPath] Error saving Excel file:\n{ex.Message}\n\nPath: {filePath}-------------------------");
                return false;
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

                if ((valD != null && valD.Contains(target)) || (valE != null && valE.Contains(target)))
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
