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
using MaterialSkin.Controls;
using TanHungHa.Tabs;

namespace TanHungHa.PopUp
{
    public partial class FormCheckMissItems : MaterialForm
    {
        private SpreadsheetControl _spreadsheet;
        private Worksheet _sheet;
        public FormCheckMissItems(SpreadsheetControl spreadsheet)
        {
            InitializeComponent();
            _spreadsheet = spreadsheet;
            _sheet = spreadsheet.Document.Worksheets[0];
            listBoxMissingRow.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            
           

        }

        public void UpdateMissingRows(List<int> missingRows)
        {
            //listBoxMissingRow.Items.Clear();
            foreach (int row in missingRows)
            {
                listBoxMissingRow.Items.Add($"Trống tem ở dòng {row}");
            }
        }
        public bool RemoveRowIfExists(int rowIndex)
        {
            string itemText = $"Trống tem ở dòng {rowIndex}";

            for (int i = 0; i < listBoxMissingRow.Items.Count; i++)
            {
                if (listBoxMissingRow.Items[i].ToString() == itemText)
                {
                    listBoxMissingRow.Items.RemoveAt(i);
                  //  lvResult.Items.Add($"Đã bổ sung tem ở dòng {rowIndex} ");
                   
                    if (listBoxMissingRow.Items.Count == 0)
                    {
                        this.BeginInvoke(new Action(() => this.Close()));
                    }
                    return true; 
                }
            }
            return false; 
        }
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox?.SelectedItem == null) return;

           // string cellRef = listBox.SelectedItem?.ToString()?.Split(' ').LastOrDefault();
            //convert cellRef from string to int
            int.TryParse(listBox.SelectedItem?.ToString()?.Split(' ').LastOrDefault(), out int rowIndex);
            string cellRef = $"D{rowIndex + 1}"; 

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


        private void btnExit_Click(object sender, EventArgs e)
        {
            listBoxMissingRow.Items.Clear();
            this.Close(); 
        }
    }
}
