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
        [Category("Common Param"), DescriptionAttribute("If not used DataBase, set to True, else set to False")]
        public bool ignoreDataBase { get; set; }
        [Category("Common Param"), DescriptionAttribute("If not used IQC, set to True, else set to False")]
        public bool ignoreIQC { get; set; }
        [Category("Common Param"), DescriptionAttribute("If not used OQC, set to True, else set to False")]
        public bool ignoreOQC { get; set; }

        [Category("Excel DCM"), DescriptionAttribute("Template col1 file excel DCM")]
        public string col1 { get; set; } 
        [Category("Excel DCM"), DescriptionAttribute("Template col2 file excel DCM")]
        public string col2 { get; set; } 
        [Category("Excel DCM"), DescriptionAttribute("Template col3 file excel DCM")]
        public string col3 { get; set; }
        [Category("Excel DCM"), DescriptionAttribute("Template col4 file excel DCM")]
        public string col4 { get; set; }
        [Category("Excel DCM"), DescriptionAttribute("Template col5 file excel DCM")]
        public string col5 { get; set; }

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
            ignoreDataBase = false;
            ignoreIQC = false;
            ignoreOQC = false;
            LengthNG = 5;
            LayoutMax = new Size(100, 1500);
            LayoutMin = new Size(400, 1050);
           
            maxLine = 1000;
            hideDate = true;
            col1 = MyDefine.col1;
            col2 = MyDefine.col2;
            col3 = MyDefine.col3;
            col4 = MyDefine.col4;
            col5 = MyDefine.col5;

        }
    }

}
