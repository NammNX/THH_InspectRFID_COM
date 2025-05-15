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

namespace TanHungHa.Common
{
    public class MyExcel
    {
        private SpreadsheetControl spreadsheet;
        private readonly Dictionary<string, int> epcRowMap = new Dictionary<string, int>();

        // Cấu hình cột
        private readonly int epcColumnIndex = 2; // Cột C
        private readonly int tidColumnIndex = 3; // Cột D
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
            Worksheet sheet = spreadsheet.Document.Worksheets[0];
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
        

        public bool SetTidForEpc(string epc, string tid, bool highlight = true)
        {
            Stopwatch sw = Stopwatch.StartNew();
            if (!spreadsheet.InvokeRequired)
            {
                return SetTidForEpcUIThread(epc, tid, highlight);
            }
            else
            {
                bool result = false;
                spreadsheet.Invoke(new Action(() =>
                {
                    result = SetTidForEpcUIThread(epc, tid, highlight);
                }));
                sw.Stop(); // Kết thúc đếm thời gian

                Console.WriteLine($"[Hàm vẽ excel UI] Time taken: {sw.ElapsedMilliseconds} ms");
                return result;
            }
        }
        private bool SetTidForEpcUIThread(string epc, string tid, bool highlight)
        {
            if (epcRowMap.TryGetValue(epc, out int rowIndex))
            {
                Worksheet sheet = spreadsheet.Document.Worksheets[0];
                sheet.Cells[rowIndex, tidColumnIndex].Value = tid;

                if (highlight)
                    sheet.Rows[rowIndex].FillColor = Color.LightGreen;
                if (rowIndex > 5)
                {
                    spreadsheet.ActiveWorksheet.ScrollTo(rowIndex - 5, 0);
                }
                else
                {
                    spreadsheet.ActiveWorksheet.ScrollTo(0, 0);
                }
                return true;
            }
            return false;
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
            Worksheet sheet = spreadsheet.Document.Worksheets[0];
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
        public bool SaveExcelToPath(string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                    throw new ArgumentException("Invalid file path.");

                spreadsheet.SaveDocument(filePath, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
                return true;
            }
            catch (Exception ex)
            {
                MyLib.showDlgError($"[SaveExcelToPath] Error saving Excel file: {ex.Message}");
                return false;
            }
        }
        /// <summary>
        /// Đếm số lượng dòng có dữ liệu (không rỗng) trong cột TID (cột D - index = 3),
        /// bất kể các dòng đó nằm rải rác.
        /// </summary>
        /// <returns>Số dòng có dữ liệu trong cột TID.</returns>
        public int CountRowsWithTid()
        {
            Worksheet sheet = spreadsheet.Document.Worksheets[0];
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
            Worksheet sheet = spreadsheet.Document.Worksheets[0];
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





    }
}
