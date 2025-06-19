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
using System.Collections.Concurrent;
using HslCommunication.Profinet.OpenProtocol;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using DevExpress.XtraRichEdit.Commands;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace TanHungHa.Common
{
    public enum eIndex
    {
        Index_OQC_Data,
        Index_IQC_Data,
        Index_ModeDCM_Data,
        Index_IQC_OQC_Log,
        Index_MongoDB_Log
    }
    public enum eMode
    {
        None,
        eOnlyTID,
        eOnlyEPC,
        eEPC_TID
    }
    public enum eFunc
    {
        None,
        eFunctionNormal,
        eFunctionDamCaMau
    }
    public class LogItem
    {
        public DateTime Time { get; set; }
        public string EPC { get; set; }
        public string TID { get; set; }
        public eSerialDataType Type { get; set; }
    }

    public class MainProcess
    {

        public static StepControl MainIQC_StepCtrl = new StepControl();
        public static StepControl MainOQC_StepCtrl = new StepControl();
        public string TAG = null;
        
        private static ConcurrentQueue<eSerialDataType> chartIQCUpdateQueue = new ConcurrentQueue<eSerialDataType>();
        private static ConcurrentQueue<eSerialDataType> chartOQCUpdateQueue = new ConcurrentQueue<eSerialDataType>();
        private static ConcurrentQueue<eSerialDataType> chartDamCaMauUpdateQueue = new ConcurrentQueue<eSerialDataType>();

        private static List<eSerialDataType> batchChartIQC = new List<eSerialDataType>();
        private static List<eSerialDataType> batchChartOQC = new List<eSerialDataType>();
        private static List<eSerialDataType> batchChartDamCaMau = new List<eSerialDataType>();

        //public static BlockingCollection<(string EPC, string TID)> ExcelWriteQueue = new BlockingCollection<(string, string)>();
        public static ConcurrentQueue<(string EPC, string TID)> ExcelWriteQueue = new ConcurrentQueue<(string, string)>();
        public static ConcurrentQueue<(string EPC, string TID, DateTime Timestamp, eSerialDataType Type, eIndex Index)> ListViewLogQueue = new ConcurrentQueue<(string, string, DateTime, eSerialDataType, eIndex)>();
       


        public MainProcess()
        {
            MainIQC_StepCtrl.Cur_Processing = eProcessing.None;
            MainOQC_StepCtrl.Cur_Processing = eProcessing.None;

        }


        public static bool isRunLoopProcess = false;
        public static void StopLoopCOM()
        {
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_IQC].StopLoop();
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_OQC].StopLoop();

            isRunLoopProcess = false;
        }
        public static void RunLoopProcess()
        {
            if (isRunLoopProcess)
            {
                MyLib.showDlgInfo("Loop Process is running!");
                return;
            }
            //IQC
            if (!MyParam.commonParam.devParam.ignoreIQC)
            {
                MyParam.taskLoops[(int)eTaskLoop.Task_RS232_IQC].ResetToken();
                MyParam.taskLoops[(int)eTaskLoop.Task_RS232_IQC].RunLoop(MyParam.commonParam.timeDelay.timeLoopCOM, LoopProcessIQC).ContinueWith((a) =>
                {
                    MyLib.log($"Done task Process IQC!");
                });
            }
            //OQC
            if (!MyParam.commonParam.devParam.ignoreOQC)
            {
                MyParam.taskLoops[(int)eTaskLoop.Task_RS232_OQC].ResetToken();
                MyParam.taskLoops[(int)eTaskLoop.Task_RS232_OQC].RunLoop(MyParam.commonParam.timeDelay.timeLoopCOM, LoopProcessOQC).ContinueWith((a) =>
                {
                    MyLib.log($"Done task Process OQC!");
                });
            }
            isRunLoopProcess = true;
        }

        public static bool isRunLoopWriteExcel = false;
        public static void RunLoopWriteExcel()
        {
            if (isRunLoopWriteExcel)
            {
                MyLib.showDlgInfo("Loop WriteExcel is running!");
                return;
            }
            // write excel
            MyParam.taskLoops[(int)eTaskLoop.Task_LoopWriteExcel].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_LoopWriteExcel].RunLoop(MyParam.commonParam.timeDelay.timeLoopWriteExcel, LoopProcessWriteExcel).ContinueWith((a) =>
            {
                MyLib.log($"Done task Process WriteExcel!");
            });
        }
        public static bool isRunLoopShowListView = false;
        public static void RunLoopShowListView()
        {
            if (isRunLoopShowListView)
            {
                MyLib.showDlgInfo("Loop ShowListView is running!");
                return;
            }
            // write excel
            MyParam.taskLoops[(int)eTaskLoop.Task_LoopShowListViewDCM].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_LoopShowListViewDCM].RunLoop(MyParam.commonParam.timeDelay.timeLoopShowListView, LoopProcessShowListViewDCM).ContinueWith((a) =>
            {
                MyLib.log($"Done task Process ShowListView!");
            });
        }
        public static void LoopProcessShowListViewDCM()
        {
            try
            {
                while (ListViewLogQueue.TryDequeue(out var log))
                {
                    AddLogAutoEPCTID(log.EPC, log.TID, log.Timestamp, log.Type, log.Index);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[LoopProcessShowListViewDCM] Error: " + ex.Message);
            }
        }


        //public static void LoopProcessShowListViewDCM()
        //{
        //    try
        //    {
        //        if (!ListViewLogQueue.IsEmpty)
        //        {
        //            var batch = new List<(string EPC, string TID, DateTime Timestamp, eSerialDataType Type, eIndex Index)>();
        //            while (ListViewLogQueue.TryDequeue(out var item))
        //            {
        //                batch.Add(item);
        //                if (batch.Count >= 5) break;
        //            }

        //            if (batch.Count > 0)
        //            {
        //                foreach (var log in batch)
        //                {
        //                    AddLogAutoEPCTID(log.EPC, log.TID, log.Timestamp, log.Type, log.Index);

        //                }
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("[FlushListView] Error: " + ex.Message);
        //    }
        //}

        public static void LoopProcessWriteExcel()
        {
           
            if (ExcelWriteQueue.TryDequeue(out var item))
            {
                
                try
                {
                    MyParam.commonParam.myExcel.SetTidForEpc(item.EPC, item.TID);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[ExcelWriteQueue] Error: " + ex.Message);
                }
               
              
            }
        }

        public static bool isRunLoopProcessDCM = false;
        public static void RunLoopProcessDCM()
        {
            if (isRunLoopProcessDCM)
            {
                MyLib.showDlgInfo("Loop ProcessDCM is running!");
                return;
            }
            MyParam.taskLoops[(int)eTaskLoop.Task_DCM].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_DCM].RunLoop(MyParam.commonParam.timeDelay.timeLoopCOM, LoopProcessDCM).ContinueWith((a) =>
            {
                MyLib.log($"Done task Task_DCM!");
            });
            isRunLoopProcessDCM = true;
        }
        public static bool isRunLoopProcessAutoSaveExcel = false;
        public static void RunLoopProcessAutoSaveExcel()
        {
            if (isRunLoopProcessAutoSaveExcel)
            {
                MyLib.showDlgInfo("Loop ProcessProcessAutoSaveExcel is running!");
                return;
            }
            //Excel
            MyParam.taskLoops[(int)eTaskLoop.Task_AutoSaveExcel].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_AutoSaveExcel].RunLoop(MyParam.commonParam.timeDelay.timeAutoSaveExcel, LoopProcessAutoSaveExcel).ContinueWith((a) =>
            {
                MyLib.log($"Done task Task_AutoSaveExcel!");
            });
            isRunLoopProcessAutoSaveExcel = true;
        }
        public static void LoopProcessAutoSaveExcel()
        {
            if (MyParam.autoForm.swAutoSaveFileExcel.Checked == false)
            {
                return;
            }
            MyLib.KillAllExcelProcesses();
            var x = MyParam.autoForm.SaveFileExcel();
        }

        public static void LoopProcessDCM()
        {

            //while (MyParam.commonParam.myComportIQC.GetQueueCount() > 0)
            //{

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var dataComIQC = MyParam.commonParam.myComportIQC.GetDataCom();
            if (dataComIQC == null)
            {
                stopwatch.Stop();
                return;
            }
            if (dataComIQC != null)
            {
               
                dataComIQC.Data = dataComIQC.Data.TrimEnd(new char[] { '\r', '\n' });
                MyParam.autoForm.UpdateLabelSpeedDCM(dataComIQC.Data);
                var (EPC, TID) = ProcessDataEPCTID(dataComIQC.Data);
                var dataType = dataComIQC.Type;

                if (dataType == eSerialDataType.OK)
                {
                    // Kiểm tra xem dữ liệu đã tồn tại trong danh sách lịch sử chưa
                    if (MyParam.runParam.HistoryDamCaMauData.Contains(EPC) || MyParam.runParam.HistoryDamCaMauData.Contains(TID))
                    {
                        dataType = eSerialDataType.Duplicate;
                        ListViewLogQueue.Enqueue((EPC, TID, dataComIQC.Timestamp, dataType, eIndex.Index_ModeDCM_Data));
                        stopwatch.Stop();
                        // Log thời gian thực thi (trường hợp duplicate)
                        Console.WriteLine($"LoopProcessDCM execution time (duplicate): {stopwatch.ElapsedMilliseconds} ms");
                        return;
                    }
                    else
                    {
                        var EPC_Ascii = HexToAscii(EPC);

                        var isContainEPC = MyParam.commonParam.myExcel.ContainsEpc(EPC_Ascii);
                        if (isContainEPC) // EPC có trong danh sách Excel
                        {
                            ExcelWriteQueue.Enqueue((EPC_Ascii, TID)); // Thêm vào queue để ghi vào Excel
                            dataType = eSerialDataType.OK;
                            MyParam.runParam.HistoryDamCaMauData.Add(EPC);
                            MyParam.runParam.HistoryDamCaMauData.Add(TID);
                          
                        }
                        else    // EPC không có trong danh sách Excel
                        {
                            dataType = eSerialDataType.Unknown;
                            MyParam.commonParam.myComportIQC.SendData(MyDefine.StopMachine);
                            MyLib.showDlgError("EPC không tồn tại trong danh sách Excel");
                            ListViewLogQueue.Enqueue((EPC, TID, dataComIQC.Timestamp, dataType, eIndex.Index_ModeDCM_Data));
                            return;
                        }
                    }
                }

                ListViewLogQueue.Enqueue((EPC, TID, dataComIQC.Timestamp, dataType, eIndex.Index_ModeDCM_Data));
                chartDamCaMauUpdateQueue.Enqueue(dataType);
                if (MyParam.autoForm.swFlushDB.Checked)
                    MyParam.commonParam.mongoDBService.AddToBuffer(EPC, TID, dataComIQC.Timestamp, dataType.ToString(), "IQC");
            }
            stopwatch.Stop();
            Console.WriteLine($"LoopProcessDCM execution time: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Count Queue: {MyParam.commonParam.myComportIQC.GetQueueCount().ToString()}");

        }
        
        //public static void LoopProcessDCM1() // mode cũ lấy từng data EPC/TID
        //{
        //    // Lặp và xử lý dữ liệu trong queue IQC cho đến khi queue trống
        //    while (MyParam.commonParam.myComportIQC.GetQueueCount() > 0)
        //    {
        //        var dataComIQC = MyParam.commonParam.myComportIQC.GetDataCom();
        //        if (dataComIQC != null)
        //        {
        //            dataComIQC.Data = dataComIQC.Data.TrimEnd(new char[] { '\r', '\n' });



        //            if (lastEPC_IQCFormat == null) // EPC
        //            {
        //                lastEPC_IQCFull = dataComIQC.Data;
        //                lastEPC_IQCFormat = ProcessData(dataComIQC.Data);
        //                EPC_IQC_Type = dataComIQC.Type;
        //            }
        //            else //TID
        //            {
        //                var TID_IQCFull = dataComIQC.Data;
        //                var TID_IQCFormat = ProcessData(dataComIQC.Data);
        //                var TID_Type = dataComIQC.Type;
        //                var DataType = eSerialDataType.Unknown;


        //                if ((EPC_IQC_Type == eSerialDataType.OK) && (TID_Type == eSerialDataType.OK)) // Check type EPC & TID 
        //                {
        //                    if (MyParam.runParam.HistoryIQCData.Contains(lastEPC_IQCFormat) || (MyParam.runParam.HistoryIQCData.Contains(TID_IQCFormat))) //duplicate
        //                    {
        //                        DataType = eSerialDataType.Duplicate;
        //                        AddLogAutoEPCTID(lastEPC_IQCFull, TID_IQCFull, dataComIQC.Timestamp, DataType, eIndex.Index_ModeDCM_Data);
        //                        lastEPC_IQCFormat = null; // Reset data EPC
        //                        lastEPC_IQCFull = null;
        //                        EPC_IQC_Type = eSerialDataType.Unknown; // Reset data 
        //                        continue;
        //                    }
        //                    else //OK
        //                    {
        //                        var lastEPC_IQCFormat_Ascii = HexToAscii(lastEPC_IQCFormat);
        //                        var isContainEPC = MyParam.commonParam.myExcel.ContainsEpc(lastEPC_IQCFormat_Ascii);
        //                        if (isContainEPC) // EPC có trong danh sách Excel
        //                        {
        //                            MyParam.commonParam.myExcel.SetTidForEpc(lastEPC_IQCFormat_Ascii, TID_IQCFormat);

        //                            DataType = eSerialDataType.OK;
        //                            MyParam.runParam.HistoryIQCData.Add(lastEPC_IQCFormat);
        //                            MyParam.runParam.HistoryIQCData.Add(TID_IQCFormat);
        //                        }
        //                        else
        //                        {
        //                            DataType = eSerialDataType.Unknown;
        //                            MyParam.commonParam.myComportIQC.SendData(MyDefine.StopMachine);
        //                            MyLib.showDlgError("EPC không tồn tại trong danh sách Excel");
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    DataType = eSerialDataType.NG;
        //                }

        //                AddLogAutoEPCTID(lastEPC_IQCFull, TID_IQCFull, dataComIQC.Timestamp, DataType, eIndex.Index_ModeDCM_Data);

        //                chartIQCUpdateQueue.Enqueue(DataType);
        //                if (MyParam.autoForm.swFlushDB.Checked)
        //                    MyParam.commonParam.mongoDBService.AddToBuffer(lastEPC_IQCFormat, TID_IQCFormat, dataComIQC.Timestamp, DataType.ToString(), "IQC");

        //                lastEPC_IQCFull = null;
        //                lastEPC_IQCFormat = null; // Reset data EPC
        //                EPC_IQC_Type = eSerialDataType.Unknown; // Reset data 
        //            }
        //        }
        //    }
        //}
        private static string HexToAscii(string hexValue)
        {
            try
            {
                // Chuyển đổi Hex thành ASCII
                if (hexValue.Length % 2 != 0)
                    hexValue = "0" + hexValue;  // Nếu số ký tự là lẻ, thêm số 0 vào đầu

                byte[] bytes = new byte[hexValue.Length / 2];
                for (int i = 0; i < hexValue.Length; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(hexValue.Substring(i, 2), 16);
                }
                return System.Text.Encoding.ASCII.GetString(bytes);
            }
            catch
            {
                return hexValue;  // Trả lại giá trị gốc nếu có lỗi
            }
        }

        public static bool isChartUpdateRunning = false;
        public static bool isChartUpdateRunningDamCaMau = false;

        public static void StopLoopChartUpdate()
        {
            MyParam.taskLoops[(int)eTaskLoop.Task_LoopLogIQC].StopLoop();
            MyParam.taskLoops[(int)eTaskLoop.Task_LoopLogOQC].StopLoop();

            isChartUpdateRunning = false;
        }
        public static void RunLoopChartUpdate()
        {
            if (isChartUpdateRunning)
            {
                MyLib.showDlgInfo("Loop Log UI is running!");
                return;
            }
            //IQC
            MyParam.taskLoops[(int)eTaskLoop.Task_LoopLogIQC].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_LoopLogIQC].RunLoop(MyParam.commonParam.timeDelay.timeLoopChart, LoopProcessLoopChartUpdateIQC).ContinueWith((a) =>
            {
                MyLib.log($"Done task RunLoopLogUI!");
            });
            //OQC
            MyParam.taskLoops[(int)eTaskLoop.Task_LoopLogOQC].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_LoopLogOQC].RunLoop(MyParam.commonParam.timeDelay.timeLoopChart, LoopProcessLoopChartUpdateOQC).ContinueWith((a) =>
            {
                MyLib.log($"Done task RunLoopLogUI!");
            });

            isChartUpdateRunning = true;
        }
        public static void RunLoopChartUpdateDCM()
        {
            if (isChartUpdateRunningDamCaMau)
            {
                MyLib.showDlgInfo("Loop Log UI is running!");
                return;
            }
            //DamCaMau
            MyParam.taskLoops[(int)eTaskLoop.Task_LoopLogDamCaMau].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_LoopLogDamCaMau].RunLoop(MyParam.commonParam.timeDelay.timeLoopChart, LoopProcessLoopChartUpdateDamCaMau).ContinueWith((a) =>
            {
                MyLib.log($"Done task RunLoopLogUI!");
            });
            isChartUpdateRunningDamCaMau = true;
        }
        public static void LoopProcessLoopChartUpdateDamCaMau()
        {
            MyParam.autoForm.UpdateLabelDataBase();

            while (chartDamCaMauUpdateQueue.TryDequeue(out eSerialDataType dataType))
            {
                batchChartDamCaMau.Add(dataType);
            }

            if (batchChartDamCaMau.Count > 0)
            {
                int countOK = batchChartDamCaMau.Count(d => d == eSerialDataType.OK);
                int countNG = batchChartDamCaMau.Count(d => d == eSerialDataType.NG);

                try
                {
                    if (MyParam.autoForm.InvokeRequired)
                    {
                        MyParam.autoForm.Invoke(new Action(() =>
                        {
                            for (int i = 0; i < countOK; i++)
                                MyParam.autoForm.UpdateChartDCM_OK();
                            for (int i = 0; i < countNG; i++)
                                MyParam.autoForm.UpdateChartDCM_NG();
                        }));
                    }
                    else
                    {
                        for (int i = 0; i < countOK; i++)
                            MyParam.autoForm.UpdateChartDCM_OK();
                        for (int i = 0; i < countNG; i++)
                            MyParam.autoForm.UpdateChartDCM_NG();
                    }

                    Console.WriteLine($"[DCM] Chart Updated - OK: {countOK}, NG: {countNG}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DCM] Update Chart Exception: {ex.Message}");
                }

                batchChartDamCaMau.Clear();
            }
        }

        public static void LoopProcessLoopChartUpdateIQC()
        {
            MyParam.autoForm.UpdateLabelDataBase();

            while (chartIQCUpdateQueue.TryDequeue(out eSerialDataType dataType))
            {
                batchChartIQC.Add(dataType);
            }

            if (batchChartIQC.Count > 0)
            {
                int countOK = batchChartIQC.Count(d => d == eSerialDataType.OK);
                int countNG = batchChartIQC.Count(d => d == eSerialDataType.NG);

                try
                {
                    if (MyParam.autoForm.InvokeRequired)
                    {
                        MyParam.autoForm.Invoke(new Action(() =>
                        {
                            for (int i = 0; i < countOK; i++)
                                MyParam.autoForm.UpdateChartIQC_OK();
                            for (int i = 0; i < countNG; i++)
                                MyParam.autoForm.UpdateChartIQC_NG();
                        }));
                    }
                    else
                    {
                        for (int i = 0; i < countOK; i++)
                            MyParam.autoForm.UpdateChartIQC_OK();
                        for (int i = 0; i < countNG; i++)
                            MyParam.autoForm.UpdateChartIQC_NG();
                    }

                    Console.WriteLine($"[IQC] Chart Updated - OK: {countOK}, NG: {countNG}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[IQC] Update Chart Exception: {ex.Message}");
                }

                batchChartIQC.Clear();
            }
        }

        public static void LoopProcessLoopChartUpdateOQC()
        {
            while (chartOQCUpdateQueue.TryDequeue(out eSerialDataType dataType))
            {
                batchChartOQC.Add(dataType);
            }

            if (batchChartOQC.Count > 0)
            {
                int countOK = batchChartOQC.Count(d => d == eSerialDataType.OK);
                int countNG = batchChartOQC.Count(d => d == eSerialDataType.NG);

                try
                {
                    if (MyParam.autoForm.InvokeRequired)
                    {
                        MyParam.autoForm.Invoke(new Action(() =>
                        {
                            for (int i = 0; i < countOK; i++)
                                MyParam.autoForm.UpdateChartOQC_OK();
                            for (int i = 0; i < countNG; i++)
                                MyParam.autoForm.UpdateChartOQC_NG();
                        }));
                    }
                    else
                    {
                        for (int i = 0; i < countOK; i++)
                            MyParam.autoForm.UpdateChartOQC_OK();
                        for (int i = 0; i < countNG; i++)
                            MyParam.autoForm.UpdateChartOQC_NG();
                    }

                    Console.WriteLine($"[OQC] Chart Updated - OK: {countOK}, NG: {countNG}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[OQC] Update Chart Exception: {ex.Message}");
                }

                batchChartOQC.Clear();
            }
        }
        public static bool CheckMode()
        {
            if (MyParam.runParam.Mode == eMode.None)
            {
                return false;
            }
            return true;
        }
        public static void SetMode(eMode mode)
        {
            MyParam.runParam.Mode = mode;
            //AddLogAuto($"Chế độ hiện tại: {mode}", eIndex.Index_IQC_OQC_Log);
        }
        public static void SetFunc(eFunc func)
        {
            MyParam.runParam.Func = func;
        }



        public static void LoopProcessIQC()
        {

            while (MyParam.commonParam.myComportIQC.GetQueueCount() > 0)
            {
                var dataComIQC = MyParam.commonParam.myComportIQC.GetDataCom();
                if (dataComIQC != null)
                {
                    dataComIQC.Data = dataComIQC.Data.TrimEnd(new char[] { '\r', '\n' });
                    MyParam.autoForm.UpdateLabelSpeedIQC(dataComIQC.Data);
                    switch (MyParam.runParam.Mode)
                    {
                        case eMode.eOnlyTID:

                            var EPCNull = "";
                            var TIDFull = dataComIQC.Data;
                            var TIDFormat = ProcessData(dataComIQC.Data);

                            if (dataComIQC.Type == eSerialDataType.OK)
                            {
                                // Kiểm tra xem dữ liệu đã tồn tại trong danh sách lịch sử chưa
                                if (MyParam.runParam.HistoryIQCData.Contains(TIDFormat))
                                {
                                    AddLogAutoEPCTID(EPCNull, TIDFull, dataComIQC.Timestamp, eSerialDataType.Duplicate, eIndex.Index_IQC_Data);
                                    continue;
                                }
                                MyParam.runParam.HistoryIQCData.Add(TIDFormat);
                            }

                            // Ghi log UI
                            AddLogAutoEPCTID(EPCNull, TIDFull, dataComIQC.Timestamp, dataComIQC.Type, eIndex.Index_IQC_Data);

                            chartIQCUpdateQueue.Enqueue(dataComIQC.Type);
                            if (MyParam.autoForm.swFlushDB.Checked) MyParam.commonParam.mongoDBService.AddToBuffer(EPCNull, TIDFormat, dataComIQC.Timestamp, dataComIQC.Type.ToString(), "IQC");  // Lưu vào MongoDB 
                            break;

                        case eMode.eOnlyEPC:

                            var TIDNull = "";
                            var EPCFull = dataComIQC.Data;
                            var EPCFormat = ProcessData(dataComIQC.Data);

                            if (dataComIQC.Type == eSerialDataType.OK)
                            {
                                // Kiểm tra xem dữ liệu đã tồn tại trong danh sách lịch sử chưa
                                if (MyParam.runParam.HistoryIQCData.Contains(EPCFormat))
                                {
                                    AddLogAutoEPCTID(EPCFull, TIDNull, dataComIQC.Timestamp, eSerialDataType.Duplicate, eIndex.Index_IQC_Data);
                                    continue;
                                }
                                MyParam.runParam.HistoryIQCData.Add(EPCFormat);
                            }
                            // Ghi log UI
                            AddLogAutoEPCTID(EPCFull, TIDNull, dataComIQC.Timestamp, dataComIQC.Type, eIndex.Index_IQC_Data);
                            chartIQCUpdateQueue.Enqueue(dataComIQC.Type);
                            if (MyParam.autoForm.swFlushDB.Checked) MyParam.commonParam.mongoDBService.AddToBuffer(EPCFormat, TIDNull, dataComIQC.Timestamp, dataComIQC.Type.ToString(), "IQC");  // Lưu vào MongoDB 
                            break;
                        case eMode.eEPC_TID: // DATA:Q400052434D443235544C54455A3330375A58D45F,RE2801191200092953FCB038E\r\n

                            var (EPC, TID) = ProcessDataEPCTID(dataComIQC.Data);
                            var dataType = dataComIQC.Type;
                            // Kiểm tra xem dữ liệu đã tồn tại trong danh sách lịch sử chưa
                            if (dataType == eSerialDataType.OK)
                            {
                                // Kiểm tra xem dữ liệu đã tồn tại trong danh sách lịch sử chưa
                                if (MyParam.runParam.HistoryIQCData.Contains(EPC) || MyParam.runParam.HistoryIQCData.Contains(TID))
                                {
                                    dataType = eSerialDataType.Duplicate;
                                    AddLogAutoEPCTID(EPC, TID, dataComIQC.Timestamp, dataType, eIndex.Index_IQC_Data);
                                    continue;
                                }
                                else
                                {
                                    dataType = eSerialDataType.OK;
                                    MyParam.runParam.HistoryIQCData.Add(EPC);
                                    MyParam.runParam.HistoryIQCData.Add(TID);
                                }
                            }
                            AddLogAutoEPCTID(EPC, TID, dataComIQC.Timestamp, dataType, eIndex.Index_IQC_Data);
                            chartIQCUpdateQueue.Enqueue(dataType);
                            if (MyParam.autoForm.swFlushDB.Checked)
                                MyParam.commonParam.mongoDBService.AddToBuffer(EPC, TID, dataComIQC.Timestamp, dataType.ToString(), "IQC");

                            break;
                    }
                }
            }
        }

        private static (string part1, string part2) ProcessDataEPCTID(string rawData)
        {
            if (string.IsNullOrEmpty(rawData))
                return (string.Empty, string.Empty);

            rawData = rawData.TrimEnd('\r', '\n');

            // Tách chuỗi nếu có dấu phẩy
            var parts = rawData.Split(',');

            string part1 = parts.Length > 0 ? ProcessSingle(parts[0]) : string.Empty;
            string part2 = parts.Length > 1 ? ProcessSingle(parts[1]) : string.Empty;

            return (part1, part2);
        }
        private static string ProcessSingle(string rawData)
        {
            var span = rawData.AsSpan();

            if (span.IsEmpty)
                return string.Empty;

            int idx = span.IndexOf(':');
            if (idx >= 0)
                span = span.Slice(0, idx);

            if (span[0] == 'Q' || span[0] == 'U')
            {
                if (span.Length > 9)
                {
                    span = span.Slice(5, span.Length - 9);
                }
            }
            else if (span[0] == 'R')
            {
                if (span.Length > 1)
                {
                    span = span.Slice(1);
                }
            }
            else
            {
                return span.ToString();
            }

            return span.ToString();
        }


        private static string ProcessData(string rawData)
        {
            if (string.IsNullOrEmpty(rawData))
                return rawData;

            rawData = rawData.TrimEnd('\r', '\n');
            var span = rawData.AsSpan();

            if (span.IsEmpty)
                return string.Empty;


            // Cắt tới dấu ':'
            int idx = span.IndexOf(':');
            if (idx >= 0)
                span = span.Slice(0, idx);
            // Xử lý theo kí tự đầu
            if (span[0] == 'Q' || span[0] == 'U')
            {
                if (span.Length > 9)
                {
                    span = span.Slice(5, span.Length - 9);
                }
            }
            else if (span[0] == 'R')
            {
                if (span.Length > 1)
                {
                    span = span.Slice(1);
                }
            }
            else
            {
                // Không phải Q hoặc R thì trả nguyên
                return span.ToString();
            }



            return span.ToString();
        }
        public static void LoopProcessOQC()
        {
            // Lặp và xử lý dữ liệu trong queue OQC cho đến khi queue trống
            while (MyParam.commonParam.myComportOQC.GetQueueCount() > 0)
            {
                var dataComOQC = MyParam.commonParam.myComportOQC.GetDataCom();
                MyParam.autoForm.UpdateLabelSpeedOQC(dataComOQC.Data);
                if (dataComOQC != null)
                {
                    dataComOQC.Data = dataComOQC.Data.TrimEnd(new char[] { '\r', '\n' });

                    switch (MyParam.runParam.Mode)
                    {
                        case eMode.eOnlyTID:

                            var EPCNull = "";
                            var TIDFull = dataComOQC.Data;
                            var TIDFormat = ProcessData(dataComOQC.Data);
                            // Kiểm tra xem dữ liệu đã tồn tại trong danh sách lịch sử chưa
                            if (dataComOQC.Type == eSerialDataType.OK)
                            {
                                if (MyParam.runParam.HistoryOQCData.Contains(TIDFormat)) //check duplicate data
                                {
                                    AddLogAutoEPCTID(EPCNull, TIDFull, dataComOQC.Timestamp, eSerialDataType.Duplicate, eIndex.Index_OQC_Data);

                                    continue;
                                }
                                MyParam.runParam.HistoryOQCData.Add(TIDFormat); //add history data
                            }
                            // Ghi log
                            AddLogAutoEPCTID(EPCNull, TIDFull, dataComOQC.Timestamp, dataComOQC.Type, eIndex.Index_OQC_Data);
                            chartOQCUpdateQueue.Enqueue(dataComOQC.Type);
                            if (MyParam.autoForm.swFlushDB.Checked) MyParam.commonParam.mongoDBService.AddToBuffer(EPCNull, TIDFormat, dataComOQC.Timestamp, dataComOQC.Type.ToString(), "OQC");  // Lưu vào MongoDB 
                            break;

                        case eMode.eOnlyEPC:

                            var TIDNull = "";
                            var EPCFull = dataComOQC.Data;
                            var EPCFormat = ProcessData(dataComOQC.Data);
                            // Kiểm tra xem dữ liệu đã tồn tại trong danh sách lịch sử chưa
                            if (dataComOQC.Type == eSerialDataType.OK)
                            {
                                if (MyParam.runParam.HistoryOQCData.Contains(EPCFormat)) //check duplicate data
                                {
                                    AddLogAutoEPCTID(EPCFull, TIDNull, dataComOQC.Timestamp, eSerialDataType.Duplicate, eIndex.Index_OQC_Data);

                                    continue;
                                }
                                MyParam.runParam.HistoryOQCData.Add(EPCFormat); //add history data
                            }
                            // Ghi log
                            AddLogAutoEPCTID(EPCFull, TIDNull, dataComOQC.Timestamp, dataComOQC.Type, eIndex.Index_OQC_Data);
                            chartOQCUpdateQueue.Enqueue(dataComOQC.Type);
                            if (MyParam.autoForm.swFlushDB.Checked) MyParam.commonParam.mongoDBService.AddToBuffer(EPCFormat, TIDNull, dataComOQC.Timestamp, dataComOQC.Type.ToString(), "OQC");  // Lưu vào MongoDB 
                            break;
                        case eMode.eEPC_TID: // DATA:Q400052434D443235544C54455A3330375A58D45F,RE2801191200092953FCB038E:"count":"speed"\r\n

                            var (EPC, TID) = ProcessDataEPCTID(dataComOQC.Data);
                            var dataType = dataComOQC.Type;

                            if (dataType == eSerialDataType.OK)
                            {
                                // Kiểm tra xem dữ liệu đã tồn tại trong danh sách lịch sử chưa
                                if (MyParam.runParam.HistoryOQCData.Contains(EPC) || MyParam.runParam.HistoryOQCData.Contains(TID))
                                {
                                    dataType = eSerialDataType.Duplicate;
                                    AddLogAutoEPCTID(EPC, TID, dataComOQC.Timestamp, dataType, eIndex.Index_OQC_Data);
                                    continue;
                                }
                                else
                                {
                                    dataType = eSerialDataType.OK;
                                    MyParam.runParam.HistoryOQCData.Add(EPC);
                                    MyParam.runParam.HistoryOQCData.Add(TID);
                                }
                            }
                            AddLogAutoEPCTID(EPC, TID, dataComOQC.Timestamp, dataType, eIndex.Index_OQC_Data);
                            chartOQCUpdateQueue.Enqueue(dataType);
                            if (MyParam.autoForm.swFlushDB.Checked)
                                MyParam.commonParam.mongoDBService.AddToBuffer(EPC, TID, dataComOQC.Timestamp, dataType.ToString(), "OQC");

                            break;
                    }
                }
            }
        }
        public static void AddLogAutoEPCTID(string EPC, string TID, DateTime dateTime, eSerialDataType dataType, eIndex index = eIndex.Index_IQC_Data)
        {
            //if (!MyParam.autoForm.IsHandleCreated) return;
            switch (index)
            {
                case eIndex.Index_IQC_Data:
                    MyLib.ShowLogListviewEPCTID(MyParam.autoForm.lvIQC, dateTime, EPC, TID, dataType);
                    break;

                case eIndex.Index_OQC_Data:
                    MyLib.ShowLogListviewEPCTID(MyParam.autoForm.lvOQC, dateTime, EPC, TID, dataType);
                    break;
                case eIndex.Index_ModeDCM_Data:
                    MyLib.ShowLogListviewEPCTID(MyParam.autoForm.lvDataModeDCM, dateTime, EPC, TID, dataType);
                    break;
                default:
                    break;
            }
            // MyLib.log(message, SvLogger.LogType.SEQUENCE);
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
                    MyParam.mainForm.sttVer.Text = MyDefine.VERSION;
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
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232_Manual].RunLoop(MyParam.commonParam.timeDelay.timeLoopCOM, LoopProcessRS232_Manual).ContinueWith((a) =>
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
