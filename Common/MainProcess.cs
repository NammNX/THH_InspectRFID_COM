using System;
using System.Data;
using System.Diagnostics;
using System.Threading;
using TanHungHa.Common.Parameter;
using MongoDB.Bson;
using MongoDB.Driver;
using static TanHungHa.Common.MyComport;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;


namespace TanHungHa.Common
{
    public enum eIndex
    {
        Index_OQC_Data,
        Index_IQC_Data,
        Index_OQC_Log,
        Index_IQC_Log,
    }
    public class MongoDBService
    {
        private static readonly MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");

        private static readonly IMongoDatabase database = mongoClient.GetDatabase("myDatabase");
        private static readonly IMongoCollection<BsonDocument> iqcCollection = database.GetCollection<BsonDocument>("iqcData");
        private static readonly IMongoCollection<BsonDocument> oqcCollection = database.GetCollection<BsonDocument>("oqcData");

        public static void InsertData(string data, string collectionName)
        {
            var collection = collectionName == "IQC" ? iqcCollection : oqcCollection;

            var document = new BsonDocument
        {
            { "Timestamp", BsonDateTime.Create(DateTime.UtcNow) },
            { "Data", data }
        };

            collection.InsertOne(document);
            Console.WriteLine($"Dữ liệu đã được gửi lên MongoDB ({collectionName})");
        }
    }
    public class MainProcess
    {
       
        public static StepControl MainIQC_StepCtrl = new StepControl();
        public static StepControl MainOQC_StepCtrl = new StepControl();
        public string TAG = null;
        public MainProcess()
        {
            MainIQC_StepCtrl.Cur_Processing = eProcessing.None;
            MainOQC_StepCtrl.Cur_Processing = eProcessing.None;
          
        }


        public static bool isRunLoopCOM = false;
        public static void StopLoopCOM()
        {
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_IQC].StopLoop();
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_OQC].StopLoop();

            isRunLoopCOM = false;
        }
        public static void RunLoopCOM()
        {
            if (isRunLoopCOM)
            {
                MyLib.showDlgInfo("Loop COM is running!");
                return;
            }
            //IQC
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_IQC].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_IQC].RunLoop(MyParam.commonParam.timeDelay.timeLoop, LoopProcessIQC).ContinueWith((a) =>
            {
                MyLib.log($"Done task IQC!");
            });
            //OQC
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_OQC].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_OQC].RunLoop(MyParam.commonParam.timeDelay.timeLoop, LoopProcessOQC).ContinueWith((a) =>
            {
                MyLib.log($"Done task OQC!");
            });
            isRunLoopCOM = true;
        }


        static SerialData dataComIQC = new SerialData();
        public static void LoopProcessIQC()
        {
            switch (MainIQC_StepCtrl.Cur_Processing)
            {
                case eProcessing.None:
                    break;
                case eProcessing.ReceiveData:
                    dataComIQC = MyParam.commonParam.myComportIQC.GetDataCom();
                    // -----------------wait signal from RS232--------------
                    if (string.IsNullOrEmpty(dataComIQC.Data))
                    {
                        return;
                    }
                    //UpdateTextBox(dataCom);
                    dataComIQC.Data = dataComIQC.Data.TrimEnd(new char[] { '\r', '\n' });
                    MyParam.commonParam.myComportIQC.ClearDataCom();
                    MainIQC_StepCtrl.SetStep(eProcessing.UpdateLog);
                    break;
                case eProcessing.UpdateLog:
                    AddLogAuto(dataComIQC.Data,dataComIQC.Timestamp, eIndex.Index_IQC_Data);

                    //  MongoDBService.InsertData(dataComIQC, "IQC");
                    MainIQC_StepCtrl.SetStep(eProcessing.UpdateChart);
                    break;
                case eProcessing.UpdateChart:
                    if (dataComIQC.Data.Replace("\r", "").Replace("\n", "").Trim().Length == 1)
                    {
                        MyParam.autoForm.UpdateChartIQC_NG();
                    }
                    else
                    {
                        MyParam.autoForm.UpdateChartIQC_OK();
                    }
                    MainIQC_StepCtrl.SetStep(eProcessing.ReceiveData);
                    break;

            }
        }

        static SerialData dataComOQC = new SerialData();

        public static void LoopProcessOQC()
        {
            switch (MainOQC_StepCtrl.Cur_Processing)
            {
                case eProcessing.None:
                    break;
                case eProcessing.ReceiveData:
                    dataComOQC = MyParam.commonParam.myComportOQC.GetDataCom();
                    // -----------------wait signal from RS232--------------
                    if (string.IsNullOrEmpty(dataComOQC.Data))
                    {
                        return;
                    }
                    //UpdateTextBox(dataCom);
                    dataComOQC.Data = dataComOQC.Data.TrimEnd(new char[] { '\r', '\n' });
                    MyParam.commonParam.myComportOQC.ClearDataCom();
                    MainOQC_StepCtrl.SetStep(eProcessing.UpdateLog);
                    break;
                case eProcessing.UpdateLog:
                    AddLogAuto(dataComOQC.Data, dataComOQC.Timestamp, eIndex.Index_OQC_Data);

                    //  MongoDBService.InsertData(dataComIQC, "IQC");
                    MainOQC_StepCtrl.SetStep(eProcessing.UpdateChart);
                    break;
                case eProcessing.UpdateChart:
                    if (dataComOQC.Data.Replace("\r", "").Replace("\n", "").Trim().Length == 1)
                    {
                        MyParam.autoForm.UpdateChartOQC_NG();
                    }
                    else
                    {
                        MyParam.autoForm.UpdateChartOQC_OK();
                    }
                    MainOQC_StepCtrl.SetStep(eProcessing.ReceiveData);
                    break;

            }
        }


        public static void AddLogAuto(string message,DateTime dateTime, eIndex index = eIndex.Index_IQC_Log)
        {
            //if (!MyParam.autoForm.IsHandleCreated) return;
            switch (index)
            {
                case eIndex.Index_IQC_Data:
                    MyLib.ShowLogListview(MyParam.autoForm.lvIQC, dateTime, message);
                    break;

                case eIndex.Index_OQC_Data:
                    MyLib.ShowLogListview(MyParam.autoForm.lvOQC, dateTime, message);
                    break;
                default:
                    break;
            }
            MyLib.log(message, SvLogger.LogType.SEQUENCE);
        }

        public static void AddLogAuto(string message, eIndex index = eIndex.Index_IQC_Log)
        {
            //if (!MyParam.autoForm.IsHandleCreated) return;
            switch (index)
            {
                //case eIndex.Index_IQC_Data:
                //    MyLib.ShowLogListview(MyParam.autoForm.lvIQC, message);
                //    break;

                //case eIndex.Index_OQC_Data:
                //    MyLib.ShowLogListview(MyParam.autoForm.lvOQC, message);
                //    break;

                case eIndex.Index_IQC_Log:
                    MyLib.ShowLogListview(MyParam.autoForm.lvLogIQC, message);
                    break;

                case eIndex.Index_OQC_Log:
                    MyLib.ShowLogListview(MyParam.autoForm.lvLogOQC, message);
                    break;
                default:
                    break;
            }
            MyLib.log(message, SvLogger.LogType.SEQUENCE);
        }




        #region Heartbeat
        //Thread scan RAM
        public static Process cur = null;
        public static PerformanceCounter curpcp = null;
        //private static PerformanceCounter myAppCpu = null;
        public const int MB_DIV = 1024 * 1024;

        public static void StopLoopHeartbeat()
        {
            MyParam.taskLoops[(int)eTaskLoop.Task_HEATBEAT].StopLoop();
        }
        public static bool RunLoopHeartBeat()
        {
            try
            {
                //RAM
                //myAppCpu = new PerformanceCounter("Process", "% Processor Time", cur.ProcessName);
                //myAppCpu.NextValue();
                cur = Process.GetCurrentProcess();
                curpcp = new PerformanceCounter("Process", "Working Set - Private", cur.ProcessName);
                Console.WriteLine("----------------------");


            }
            catch
            {

            }



#if !TEST
            MyParam.taskLoops[(int)eTaskLoop.Task_HEATBEAT].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_HEATBEAT].RunLoop(MyParam.commonParam.timeDelay.delayHeatbeat, LoopProcessHEARTBEAT).ContinueWith((a) =>
            {
                //MyLib.showDlgInfo($"Done task Task_RESOURCE!");
                MyLib.log("Done task Task_RESOURCE!");
            });
#else
            MyParam.taskLoops[(int)eTaskLoop.Task_HEATBEAT].ResetToken();
            _ = MyParam.taskLoops[(int)eTaskLoop.Task_HEATBEAT].RunLoop(MyParam.commonParam.timeDelay.delayHeatbeat, LoopProcessHEARTBEAT);
#endif

            return true;
        }

        public static int iCountFailHeartBear = 0;
        public static void LoopProcessHEARTBEAT()
        {
            //RAM
            string RamInfo = "";
            if (curpcp != null)
            {
                RamInfo = (curpcp.NextValue() / MB_DIV).ToString("F1") + "MB";
            }
            string IQC = $"(IQC:{MyParam.runParam.COM_IQC},{MyParam.commonParam.myComportIQC.isConnected()})";
            string OQC = $"(OQC:{MyParam.runParam.COM_OQC},{MyParam.commonParam.myComportOQC.isConnected()})";
            if (!MyParam.mainForm.IsHandleCreated)
                return;
            if (MyParam.mainForm.statusStrip1.InvokeRequired)
            {
                MyParam.mainForm.statusStrip1.BeginInvoke(new Action(() =>
                {
                    MyParam.mainForm.sttRAM.Text = $"(RAM: {RamInfo})";
                    MyParam.mainForm.sttIQC.Text = IQC;
                    MyParam.mainForm.sttOQC.Text = OQC;
                  

                }));

            }

        }
        #endregion
        #region RS232 manual
        public static void StopLoopRS232_Manual()
        {
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_Manual].StopLoop();
        }

        public static void RunLoopRS232_Manual()
        {
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_Manual].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_Manual].RunLoop(150, LoopProcessRS232_Manual).ContinueWith((a) =>
            {
                MyLib.showDlgInfo($"Done task RS232 Manual");
            });
        }

        public static void LoopProcessRS232_Manual()
        {


            lock (MyParam.commonParam.queueLock)
            {
                int queueSize = MyParam.commonParam.myComport.queueData.Count;
                if (queueSize > 0)
                {
                    SerialData dataFromCom = MyParam.commonParam.myComport.GetDataCom();
                    MyParam.tabRS232.setText(dataFromCom.Timestamp.ToString());
                }
            }
        }
        #endregion End RS232 manual







    }
}






    
