using System;
using System.Data;
using System.Diagnostics;
using System.Threading;
using TanHungHa.Common.Parameter;
using MongoDB.Bson;
using MongoDB.Driver;
using static TanHungHa.Common.MyComport;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace TanHungHa.Common
{
    public enum eIndex
    {
        Index_OQC_Data,
        Index_IQC_Data,
        Index_IQC_OQC_Log,
        Index_MongoDB_Log
    }
    public class MongoDBService
    {
        private static MongoClient _client;
        private static IMongoDatabase _database;
        private static IMongoCollection<BsonDocument> iqcCollection;
        private static IMongoCollection<BsonDocument> oqcCollection;

        private static readonly List<BsonDocument> iqcBuffer = new List<BsonDocument>();
        private static readonly List<BsonDocument> oqcBuffer = new List<BsonDocument>();

        private static readonly object iqcLock = new object();
        private static readonly object oqcLock = new object();
        private static int totalIqcFlushed = 0;
        private static int totalOqcFlushed = 0;

        private static CancellationTokenSource _cancellationTokenSource;

        public static bool ConnectMongoDb(string connectionString, string databaseName)
        {
            try
            {
                if (_client == null)
                {
                    _client = new MongoClient(connectionString);
                }

                _database = _client.GetDatabase(databaseName);

                var ping = _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Result;
                Console.WriteLine($"Connected to MongoDB: {databaseName}");

                iqcCollection = _database.GetCollection<BsonDocument>("iqcData");
                oqcCollection = _database.GetCollection<BsonDocument>("oqcData");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("MongoDB connection error: " + ex.Message);
                MyLib.showDlgError("MongoDB connection error: " + ex.Message + "\r\n" + "Kiểm tra lại kết nối MongoDB");
                return false;
            }
        }

        //public static IMongoDatabase ConnectMongoDb(string connectionString, string databaseName)
        //{
        //    try
        //    {
        //        if (_client == null)
        //        {
        //            _client = new MongoClient(connectionString);
        //        }

        //        _database = _client.GetDatabase(databaseName);

        //        // Kiểm tra kết nối
        //        var ping = _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Result;
        //        Console.WriteLine($"Connected to MongoDB: {databaseName}");

        //        iqcCollection = _database.GetCollection<BsonDocument>("iqcData");
        //        oqcCollection = _database.GetCollection<BsonDocument>("oqcData");

        //        return _database;
        //    }
        //    catch (MongoConnectionException ex)
        //    {
        //        // Lỗi kết nối MongoDB
        //        Console.WriteLine("MongoDB connection failed: " + ex.Message);
        //        MyLib.showDlgError("MongoDB connection failed: " + ex.Message);
        //    }
        //    catch (TimeoutException ex)
        //    {
        //        // Lỗi timeout kết nối
        //        Console.WriteLine("MongoDB connection timeout: " + ex.Message);
        //        MyLib.showDlgError("Lỗi timeout kết nối MongoDB: " + ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Lỗi chung
        //        Console.WriteLine("An error occurred: " + ex.Message);
        //        MyLib.showDlgError("MongoDB connection failed: " + ex.Message);
        //    }

        //    return false; // Trả về null nếu không thể kết nối
        //}


        public static void AddToBuffer(string data, DateTime timestamp, string collectionName)
        {
            var doc = new BsonDocument
        {
            { "Timestamp", BsonDateTime.Create(timestamp) },
            { "Data", data }
        };

            if (collectionName == "IQC")
            {
                lock (iqcLock)
                {
                    iqcBuffer.Add(doc);
                }
            }
            else if (collectionName == "OQC")
            {
                lock (oqcLock)
                {
                    oqcBuffer.Add(doc);
                }
            }
        }
        public static void FlushBuffersIQC()
        {
            try
            {
                lock (iqcLock)
                {
                    if (iqcBuffer.Count > 0)
                    {
                        iqcCollection.InsertMany(iqcBuffer);
                        totalIqcFlushed += iqcBuffer.Count;
                        iqcBuffer.Clear();
                        Console.WriteLine($"IQC buffer đã flush lên MongoDB.Tổng: {totalIqcFlushed}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Flush lỗi: " + ex.Message);
                MyLib.showDlgError("Flush lỗi: " + ex.Message);
               // ????
            }
        }
        public static void FlushBuffersOQC()
        {
            try
            {
                lock (oqcLock)
                {
                    if (oqcBuffer.Count > 0)
                    {
                        oqcCollection.InsertMany(oqcBuffer);
                        totalOqcFlushed += oqcBuffer.Count;
                        oqcBuffer.Clear();
                        Console.WriteLine($"OQC buffer đã flush lên MongoDB. Tổng: {totalOqcFlushed}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Flush lỗi: " + ex.Message);
                MyLib.showDlgError("Flush lỗi: " + ex.Message);
              //  StopFlushLoop();
            }
        }

        //public static void StartFlushLoop()
        //{
        //    _cancellationTokenSource = new CancellationTokenSource();
        //    Task.Run(async () =>
        //    {
        //        while (!_cancellationTokenSource.Token.IsCancellationRequested)
        //        {
        //            FlushBuffers();
        //            await Task.Delay(3000);
        //        }
        //    });
        //}

        //public static void StopFlushLoop()
        //{
        //    _cancellationTokenSource?.Cancel();
        //}
        public static int GetIqcBufferCount()
        {
            lock (iqcLock)
            {
                return iqcBuffer.Count;
            }
        }

        public static int GetOqcBufferCount()
        {
            lock (oqcLock)
            {
                return oqcBuffer.Count;
            }
        }
        public static bool IsFlushingCompleted()
        {
            return GetIqcBufferCount() == 0 && GetOqcBufferCount() == 0;
        }

        public static int GetTotalIqcFlushed() => totalIqcFlushed;
        public static int GetTotalOqcFlushed() => totalOqcFlushed;
        public static void ClearDBFlushed()
        {
            totalIqcFlushed = 0;
            totalOqcFlushed = 0;
        }
        public static bool isFlushLoop = false;
        public static void StopFlushLoop()
        {
            MyParam.taskLoops[(int)eTaskLoop.Task_FlushBuffersIQC].StopLoop();
            MyParam.taskLoops[(int)eTaskLoop.Task_FlushBuffersOQC].StopLoop();

            isFlushLoop = false;
        }
        public static void RunFlushLoop()
        {
            if (isFlushLoop)
            {
                MyLib.showDlgInfo("Loop Flush Mongo is running!");
                return;
            }
            //IQC
            MyParam.taskLoops[(int)eTaskLoop.Task_FlushBuffersIQC].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_FlushBuffersIQC].RunLoop(MyParam.runParam.mongoFlushIntervalMs, FlushBuffersIQC).ContinueWith((a) =>
            {
                MyLib.log($"Done task FlushBuffersIQC!");
            });
            //OQC
            MyParam.taskLoops[(int)eTaskLoop.Task_FlushBuffersOQC].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_FlushBuffersOQC].RunLoop(MyParam.runParam.mongoFlushIntervalMs, FlushBuffersOQC).ContinueWith((a) =>
            {
                MyLib.log($"Done task FlushBuffersOQC!");
            });
            isFlushLoop = true;
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
                MyLib.log($"Done task COM IQC!");
            });
            //OQC
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_OQC].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_OQC].RunLoop(MyParam.commonParam.timeDelay.timeLoop, LoopProcessOQC).ContinueWith((a) =>
            {
                MyLib.log($"Done task COM OQC!");
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
                    MainIQC_StepCtrl.SetStep(eProcessing.FlushDataBase);
                    break;
                case eProcessing.FlushDataBase:
                    {
                        if (MyParam.autoForm.swFlushDB.Checked)
                        {
                            MongoDBService.AddToBuffer(dataComIQC.Data, dataComIQC.Timestamp, "IQC");
                        }
                        MainIQC_StepCtrl.SetStep(eProcessing.UpdateLog);
                        break;
                    }    
                case eProcessing.UpdateLog:
                    AddLogAuto(dataComIQC.Data,dataComIQC.Timestamp, eIndex.Index_IQC_Data);
                    MainIQC_StepCtrl.SetStep(eProcessing.UpdateChart);
                    break;
                case eProcessing.UpdateChart:
                    if (dataComIQC.Data.Replace("\r", "").Replace("\n", "").Trim().Length <= MyParam.commonParam.devParam.LengthNG)
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
                    MainOQC_StepCtrl.SetStep(eProcessing.FlushDataBase);
                    break;
                case eProcessing.FlushDataBase:
                    {
                        if (MyParam.autoForm.swFlushDB.Checked)
                        {
                            MongoDBService.AddToBuffer(dataComOQC.Data, dataComOQC.Timestamp, "OQC");
                        }
                        MainOQC_StepCtrl.SetStep(eProcessing.UpdateLog);
                        break;
                    }
                case eProcessing.UpdateLog:
                    AddLogAuto(dataComOQC.Data, dataComOQC.Timestamp, eIndex.Index_OQC_Data);
                    MainOQC_StepCtrl.SetStep(eProcessing.UpdateChart);
                    break;
                case eProcessing.UpdateChart:
                    if (dataComOQC.Data.Replace("\r", "").Replace("\n", "").Trim().Length <= MyParam.commonParam.devParam.LengthNG)
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


   

        public static void AddLogAuto(string message,DateTime dateTime, eIndex index = eIndex.Index_IQC_Data)
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

        public static void AddLogAuto(string message, eIndex index = eIndex.Index_IQC_OQC_Log)
        {
            //if (!MyParam.autoForm.IsHandleCreated) return;
            switch (index)
            {
                case eIndex.Index_IQC_OQC_Log:
                    MyLib.ShowLogListview(MyParam.autoForm.lvLogIQC_OQC, message);
                    break;

                case eIndex.Index_MongoDB_Log:
                    MyLib.ShowLogListview(MyParam.autoForm.lvLogDB, message);
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
            MyParam.autoForm.UpdateLabelDataBase();
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
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_Manual].RunLoop(MyParam.commonParam.timeDelay.timeLoop, LoopProcessRS232_Manual).ContinueWith((a) =>
            {
                MyLib.showDlgInfo($"Done task RS232 Manual");
            });
        }

        public static void LoopProcessRS232_Manual()
        {
                int queueSize = MyParam.commonParam.myComport.GetQueueCount();
                if (queueSize > 0)
                {
                    SerialData dataFromCom = MyParam.commonParam.myComport.GetDataCom();
                    MyParam.tabRS232.setText(dataFromCom.Data);
                }
        }
        #endregion End RS232 manual

    }
}
