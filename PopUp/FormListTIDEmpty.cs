using DevExpress.XtraSpreadsheet;
using DevExpress.Spreadsheet;
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
using DevExpress.XtraRichEdit.Model;

namespace TanHungHa.PopUp
{
    public partial class FormListTIDEmpty : MaterialForm
    {
        private SpreadsheetControl _spreadsheet;
        private Worksheet _sheet;

        public FormListTIDEmpty(List<string> emptyCells, SpreadsheetControl spreadsheet)
        {
            InitializeComponent();

            _spreadsheet = spreadsheet;
            _sheet = spreadsheet.Document.Worksheets[0];

           
            listBoxTidEmpty.Items.Clear();
            listBoxTidEmpty.Items.AddRange(emptyCells.Cast<object>().ToArray());

           
            listBoxTidEmpty.SelectedIndexChanged += ListBox_SelectedIndexChanged;

            // Cấu hình form (nếu là form rời)
           // this.Text = "Danh sách ô trống";
            this.Size = new Size(200, 400);
           // this.StartPosition = FormStartPosition.Manual; // Cho phép đặt vị trí tùy ý
        }


        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox?.SelectedItem == null) return;

            string cellRef = listBox.SelectedItem.ToString();
            if (!cellRef.StartsWith("D")) return;

            Cell cell = _sheet.Cells[cellRef];
            _sheet.SelectedCell = cell; // Chọn ô
            if (cell.TopRowIndex > 5)
            {
                _spreadsheet.ActiveWorksheet.ScrollTo(cell.TopRowIndex - 5, 0);
            }
            else
            {
                _spreadsheet.ActiveWorksheet.ScrollTo(0, 0);
            }
        }

    }
}
