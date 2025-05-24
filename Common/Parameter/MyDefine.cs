using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TanHungHa.Common
{
    public class MyDefine
    {
        //public static DateTime expried_time = new DateTime(2024, 8, 13, 9, 0, 0);
        public const string VERSION = @"Ver 1.0.0.100525";
        
        public const int HEIGHT_OF_ROW = 50;
        
        public const int MIN_ROW = 1;
        public const int MAX_ROW = 5;
        
        public const int ROUND_DIGIT = 5;
        public const int RATIO = 1000;
        
       


        public static readonly string title = "RFID Inspection";
        public static readonly string version = "Version 1.0.0 \r\n 10/05/2025";

        public const string treenodeRunParam = "Run Param";
        public const string treenodeRS232 = "RS232";
        public const string treenodeTime = "Time";
        public const string treenodeTheme = "Theme";
        public const string treenodeDev = "Developer";

        public const string dataBaseNameDefault  = "Default";


        // control Module RFID of Mr.TruTho
        public const string ResetIO_RFID = "r";
        public const string NoByPass = "s"; //Dừng máy khi lỗi
        public const string ByPass = "x"; //Không dừng máy khi lỗi
        public const string EnableModeOnlyEPCModuleRFID = "1";
        public const string EnableModeEPCTIDModuleRFID = "2";
        public const string EnableModeOnlyTIDModuleRFID = "3";
        public const string TriggerAndEnableO8 = "d"; // Trigger và bật O8
        public const string StopMachine = "a"; // Dừng máy



        public const int NUM_FAIL_HEART_BEAR = 5;
        public const int NUM_THREAD = 11;
        public const int MAX_QUEUE_DATA = 30;
        public const int NUM_DEVICES = 2;

        public static int[] baudrates = new int[] { 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200 } ;
        public static int[] dataSize = new int[] { 7,8 };

        

        public static readonly string workingDirectory = Environment.CurrentDirectory;
        public static readonly string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        //public static readonly string workspaceDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;


        public static readonly string pathDefaultSaveFileExcel = String.Format($"{workingDirectory}\\Excel");

        #region Path file json



        public static readonly string file_config = String.Format($"{workingDirectory}\\Configs\\config_param.json");
        public static readonly string file_uiParam= String.Format($"{workingDirectory}\\Configs\\uiParameter.json");
        public static readonly string file_runParam= String.Format($"{workingDirectory}\\Configs\\runParameter.json");
        public static readonly string file_model= String.Format($"{workingDirectory}\\Configs\\models.json");
        
        //public static readonly string path_solution= String.Format($"{workingDirectory}\\Data\\TapeAlignment.sol");
       

        public static readonly string file_cameraParam= String.Format($"{workingDirectory}\\Configs\\camParameter.json");
        public static readonly string file_excel = String.Format($"{workingDirectory}\\Data\\ImportData.xlsx");

        public static readonly string file_config_format_data = String.Format($"{workingDirectory}\\Data\\configs\\format_data.json");
        public static readonly string file_config_common_param = String.Format($"{workingDirectory}\\Data\\configs\\common_param.json");
        public static readonly string file_config_filter_window = String.Format($"{workingDirectory}\\Data\\configs\\filter_window.json");
        
        

        public static readonly string key_thh = @"https://tanhungha.com.vn/";
        public static readonly string hash_key = "";
        #endregion


        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);


        [DllImport("kernel32", SetLastError = true)]
        static extern IntPtr LoadLibrary(string lpFileName);

        public static bool CheckLibrary(string fileName)
        {
            return LoadLibrary(fileName) == IntPtr.Zero;
        }



    }
}
