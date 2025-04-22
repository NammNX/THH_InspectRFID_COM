using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TanHungHa.Common.TaskCustomize
{
    public enum eTaskToDo
    {
        ConnectCOMIQC,
        ConnectCOMOQC,
        ConnectMongoDB,
        HEATBEAT
    }
    static class THHTask
    {
        static Func<object, bool> callFunction = (object taskToDo2) =>
        {
            bool bResult = false;
            eTaskToDo taskToDo = (eTaskToDo)taskToDo2; 
            Console.WriteLine($"---------callFunction = {taskToDo}");
            switch (taskToDo)
            {
                case eTaskToDo.ConnectCOMIQC:
                    MyParam.commonParam.myComportIQC.portName = MyParam.runParam.COM_IQC;
                    bResult = MyParam.commonParam.myComportIQC.Connect();
                    break;
                
                case eTaskToDo.ConnectCOMOQC:
                    MyParam.commonParam.myComportOQC.portName = MyParam.runParam.COM_OQC;
                    bResult = MyParam.commonParam.myComportOQC.Connect();
                    break;
                case eTaskToDo.ConnectMongoDB:
                    bResult = MongoDBService.ConnectMongoDb($"{MyParam.runParam.MongoClient}?connectTimeoutMS={MyParam.runParam.ConnectTimeOut}&socketTimeoutMS=10000&serverSelectionTimeoutMS=5000",$"{MyParam.runParam.DataBaseName}");
                    break;

                case eTaskToDo.HEATBEAT:
                    bResult = MainProcess.RunLoopHeartBeat();
                    break;
                default:
                    break;
            }
            Console.WriteLine($"---------callFunction {taskToDo}, result = {bResult}");
            return bResult;
        };

        public static async Task<bool> RunTask(object taskToDo)
        {
            //bool result = await Task.Run(() => callFunction(taskToDo));
            //Console.WriteLine($"Task run --- {taskToDo}: {result}");
            //return result;
            Task<bool> task = new Task<bool>(callFunction, taskToDo);
            task.Start();
            await task;
            Console.WriteLine($"Task run --- {taskToDo}: {task.Result}");
            return task.Result;
        }
    }
}
