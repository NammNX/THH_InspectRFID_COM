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

        [Category("Device"), DescriptionAttribute("Folder Save File Excel Mode Dam Ca Mau")]
        public string PathFolderSaveFileExcel { get; set; }


        [Browsable(false)]
        public string FileNameDamCaMau { get; set; }
        [Browsable(false)]
        public string FullPathSaveFileExcel { get; set; }

        [Category("DataBase"), DescriptionAttribute("client")]
        public string MongoClient { get; set; }
        
        [Category("DataBase"), DescriptionAttribute("Connect TimeOut")]
        public int ConnectTimeOut { get; set; }
        [Category("DataBase"), DescriptionAttribute("Time between each flush, in milliseconds")]
        public int mongoFlushIntervalMs { get; set; }


        [Browsable(false)]
        public eFunc Func { get; set; }

        [Browsable(false)]
        public eMode Mode { get; set; }

        [Browsable(false)]
        public string DataBaseName { get; set; }
        [Browsable(false)]
        public string DataBaseNameDamCaMau { get; set; }
        [Browsable(false)]
        public HashSet<string> HistoryDamCaMauData { get; set; } = new HashSet<string>();
        [Browsable(false)]
        public HashSet<string> HistoryIQCData { get; set; } = new HashSet<string>();
        [Browsable(false)]
        public HashSet<string> HistoryOQCData { get; set; } = new HashSet<string>();

        [JsonIgnore]
        [Browsable(false)]
        public ePRGSTATUS ProgramStatus = ePRGSTATUS.Start_Up;
       
        RunParam()
        {
            COM_IQC = "COM1";
            COM_OQC = "COM2";
            Baudrate = 9600;
            Mode = eMode.None;
            Func = eFunc.eFunctionNormal;
            PathFolderSaveFileExcel = MyDefine.pathDefaultSaveFileExcel;
            FullPathSaveFileExcel = $"{MyDefine.pathDefaultSaveFileExcel}\\DamCaMau.xlsx";
            FileNameDamCaMau = "DamCaMau.xlsx";
            MongoClient = "mongodb://localhost:27017";
            DataBaseName = MyDefine.dataBaseNameDefault;
            DataBaseNameDamCaMau = MyDefine.dataBaseNameDefault;
            ConnectTimeOut = 5000;
            mongoFlushIntervalMs = 3000;
            HistoryDamCaMauData = new HashSet<string>();
            HistoryIQCData = new HashSet<string>();
            HistoryOQCData = new HashSet<string>();
        }
    }
}
