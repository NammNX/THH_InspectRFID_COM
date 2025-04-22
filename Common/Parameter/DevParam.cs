using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanHungHa.Common
{
    public class DevParam
    {
        private static DevParam _instance;
        private static readonly object _lock = new object();
        public static DevParam GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DevParam();
                    }
                }
            }
            return _instance;
        }


        //--------------------Variable------------------

        [Category("Validation"), DescriptionAttribute("Độ dài tối đa của chuỗi NG")]
        public int LengthNG { get; set; }

        [Category("Layout"), DescriptionAttribute("Layout size when zoom out")]
        public Size LayoutMax { get; set; }
        [Category("Layout"), DescriptionAttribute("Layout size when zoom in")]
        public Size LayoutMin { get; set; }

        [Category("Logging Param"), DescriptionAttribute("Hide date in log line")]
        public bool hideDate
        {
            get; set;
        }

        [Category("Logging Param"), DescriptionAttribute("Max log line in listview")]
        public int maxLine
        {
            get; set;
        }

       


      

        //--------------------------------------------
        DevParam()
        {
            LengthNG = 5;
            LayoutMax = new Size(100, 1500);
            LayoutMin = new Size(400, 1050);
           
            maxLine = 1000;
            hideDate = true;
           
        }
    }

}
