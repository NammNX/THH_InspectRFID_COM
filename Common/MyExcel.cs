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


    }
}
