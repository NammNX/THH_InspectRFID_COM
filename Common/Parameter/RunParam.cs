using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;


namespace TanHungHa.Common
{
    public enum ePRGSTATUS
    {
        Start_Up,
        Initial,
        Started,
        Stoped,
        Reset
    }

    public class RunParam
    {
        private static RunParam _instance;
        private static readonly object _lock = new object();
        public static RunParam GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new RunParam();
                    }
                }
            }
            return _instance;
        }

        //--------------------Variable------------------


        [Category("Device"), DescriptionAttribute("COM IQC")]
        public string COM_IQC { get; set; }
        [Category("Device"), DescriptionAttribute("COM OQC")]
        public string COM_OQC { get; set; }
        [Category("Device"), DescriptionAttribute("Baudrate")]
        public int Baudrate  { get; set; }
        [Category("Device"), DescriptionAttribute("Mode")]
        public eMode Mode { get; set; }
        //[Category("Device"), DescriptionAttribute("Use TID Data")]
        //public bool getTID { get; set; }





        [Category("DataBase"), DescriptionAttribute("client")]
        public string MongoClient { get; set; }
        [Category("DataBase"), DescriptionAttribute("DataBase name")]
        public string DataBaseName { get; set; }
        [Category("DataBase"), DescriptionAttribute("Connect TimeOut")]
        public int ConnectTimeOut { get; set; }
        [Category("DataBase"), DescriptionAttribute("Time between each flush, in milliseconds")]
        public int mongoFlushIntervalMs { get; set; }



        //[Category("Device"), DescriptionAttribute("Path Save File Excel")]
        //public string Path { get; set; }

        //[Category("Device"), DescriptionAttribute("FileName Excel")]
        //public string Name { get; set; }

        //private string _iDayResetCheckDuplicate;
        //[Category("Logging"), DescriptionAttribute("Number of days to reset duplicate check data")]
        //public string iDayResetCheckDuplicate
        //{
        //    get => _iDayResetCheckDuplicate;
        //    set
        //    {
        //        if (int.TryParse(value, out _))
        //        {
        //            _iDayResetCheckDuplicate = value;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Hãy điền số");
        //            throw new ArgumentException("Only numeric values are allowed.");
        //        }
        //    }
        //}

        //private string _iMaxRowExcell;
        //[Category("Logging"), DescriptionAttribute("Number of max Row file Excel")]
        //public string iMaxRowExcell
        //{
        //    get => _iMaxRowExcell;
        //    set
        //    {
        //        if (int.TryParse(value, out _))
        //        {
        //            _iMaxRowExcell = value;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Hãy điền số");
        //            throw new ArgumentException("Only numeric values are allowed.");
        //        }
        //    }
        //}

        //private string _SizeFont;
        //[Category("Logging"), DescriptionAttribute("Size Font List View Data")]
        //public string SizeFont
        //{
        //    get => _SizeFont;
        //    set
        //    {
        //        if (int.TryParse(value, out _))
        //        {
        //            _SizeFont = value;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Hãy điền số");
        //            throw new ArgumentException("Only numeric values are allowed.");
        //        }
        //    }
        //}
        [JsonIgnore]
        [Browsable(false)]
        public ePRGSTATUS ProgramStatus = ePRGSTATUS.Start_Up;
        RunParam()
        {
            COM_IQC = "COM1";
            COM_OQC = "COM2";
            Baudrate = 9600;
            Mode = eMode.Noon;
            //getTID = false;
            MongoClient = "mongodb://localhost:27017";
            DataBaseName = "Empty";
            ConnectTimeOut = 5000;
            mongoFlushIntervalMs = 3000;
            //Path = "C:\\Users\\Windows 11\\Desktop";
            //Name = "ABC.xlsx";
            //iDayResetCheckDuplicate = "7";
            //iMaxRowExcell = "120";
            //SizeFont = "16";
           
        }
    }
}
