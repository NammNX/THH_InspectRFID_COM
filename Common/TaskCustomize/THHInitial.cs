using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanHungHa.Common.TaskCustomize;

namespace TanHungHa.Common.TaskCustomize
{
    public static class THHInitial
    {
        public static async Task<bool> InitDevice()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            var task1 = THHTask.RunTask(eTaskToDo.ConnectCOMIQC);
            var task2 = THHTask.RunTask(eTaskToDo.ConnectCOMOQC);
            var task3 = THHTask.RunTask(eTaskToDo.ConnectMongoDB);
          //  var task4 = THHTask.RunTask(eTaskToDo.HEATBEAT);
            await task1;
            bool bInitConnectCOMIQC = task1.Result;
            MainProcess.AddLogAuto($"Connect COM IQC = {bInitConnectCOMIQC}", eIndex.Index_IQC_OQC_Log);

            await task2;
            bool bInitConnectCOMOQC = task2.Result;
            MainProcess.AddLogAuto($"Connect COM OQC = {bInitConnectCOMOQC}", eIndex.Index_IQC_OQC_Log);
            
            await task3;
            bool bInitConnectMongoDB = task3.Result;
            MainProcess.AddLogAuto($"Connect to MongoDB: {MyParam.runParam.MongoClient} = {bInitConnectMongoDB}", eIndex.Index_MongoDB_Log);

            var timeProcess = watch.Elapsed.TotalMilliseconds.ToString();
            Console.WriteLine($"Time process total = {timeProcess}");


            MyLib.showDlgInfo($"IQC = {bInitConnectCOMIQC}, OQC = {bInitConnectCOMOQC}, DataBase = {bInitConnectMongoDB}");
            return bInitConnectCOMIQC && bInitConnectCOMOQC && bInitConnectMongoDB;
        }

        public static async Task<bool> RunHeatbeat()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            var task1 = THHTask.RunTask(eTaskToDo.HEATBEAT);
            await task1;
            
            var timeProcess = watch.Elapsed.TotalMilliseconds.ToString();
            Console.WriteLine($"Time heatbeat total = {timeProcess}");
            return true;
        }
    }
}
