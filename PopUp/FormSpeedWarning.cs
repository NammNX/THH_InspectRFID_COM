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

namespace TanHungHa.PopUp
{
    public partial class FormSpeedWarning : MaterialForm
    {
        public FormSpeedWarning()
        {
            InitializeComponent();
            btnWarning.Text = "⚠ Tốc độ vượt quá giới hạn! Vui lòng giảm xuống ≤ 10 pcs/s";
        }
    }
}
