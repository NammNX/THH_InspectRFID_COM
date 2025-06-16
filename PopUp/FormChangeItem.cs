using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSpreadsheet;
using DevExpress.Spreadsheet;
using TanHungHa.Common;

namespace TanHungHa.PopUp
{
    public partial class FormChangeItem : MaterialForm
    {
        private SpreadsheetControl _spreadsheet;
        private Worksheet _sheet;

        public FormChangeItem(SpreadsheetControl spreadsheet)
        {
            InitializeComponent();
            btnReplace.Enabled = false;
            _spreadsheet = spreadsheet;
            _sheet = spreadsheet.Document.Worksheets[0];
        }

        private int _selectedRowIndex = -1;
        private int _selectedColIndex = 3; // Cột D trong excel
        private void btnFind_Click(object sender, EventArgs e)
        {
            var FoundRows = MyParam.commonParam.myExcel.FindRowsByValueInTidOrQrCode(txtFind.Text.Trim());
            if (FoundRows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu nào phù hợp với từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (FoundRows.Count > 1)
            {
                MessageBox.Show("Nhập đầy đủ TID hoặc mã Code trên tem.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (FoundRows.Count == 1)
            {
               btnReplace.Enabled = true;
               _selectedRowIndex = FoundRows[0];
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (_selectedRowIndex > 0)
            {
                var newValue = txtReplace.Text.Trim(); // textbox nhập giá trị mới
                _sheet.Cells[_selectedRowIndex, _selectedColIndex].Value = newValue;
                _spreadsheet.Refresh(); // Cập nhật lại giao diện
                MyParam.runParam.HistoryDamCaMauData.Add(newValue);
                MyLib.showDlgInfo($"Đã thay thế thành công giá trị TID/QR code {txtFind.Text.Trim()} thành {newValue}");
            }
        }
    }
}
