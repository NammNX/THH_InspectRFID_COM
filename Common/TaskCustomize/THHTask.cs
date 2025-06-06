﻿using System;
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
                    if (!MyParam.commonParam.devParam.ignoreIQC)
                    {
                        MyParam.commonParam.myComportIQC.portName = MyParam.runParam.COM_IQC;
                        MyParam.commonParam.myComportIQC.baudRate = MyParam.runParam.Baudrate;
                        bResult = MyParam.commonParam.myComportIQC.Connect();
                    }
                    else
                    {
                        bResult = true;
                    }
                    break;
                
                case eTaskToDo.ConnectCOMOQC:
                    if (!MyParam.commonParam.devParam.ignoreOQC)
                    {
                        MyParam.commonParam.myComportOQC.portName = MyParam.runParam.COM_OQC;
                        MyParam.commonParam.myComportOQC.baudRate = MyParam.runParam.Baudrate;
                        bResult = MyParam.commonParam.myComportOQC.Connect();
                    }
                    else
                    {
                        bResult = true;
                    }
                    break;
                case eTaskToDo.ConnectMongoDB:
                    if (!MyParam.commonParam.devParam.ignoreDataBase)
                    {
                        if (MyParam.runParam.Func == eFunc.eFunctionNormal)
                        {
                            bResult = MyParam.commonParam.mongoDBService.ConnectMongoDb($"{MyParam.runParam.MongoClient}?connectTimeoutMS={MyParam.runParam.ConnectTimeOut}&socketTimeoutMS=10000&serverSelectionTimeoutMS=5000", $"{MyParam.runParam.DataBaseName}");
                        }
                        else if(MyParam.runParam.Func == eFunc.eFunctionDamCaMau)
                        {
                            bResult = MyParam.commonParam.mongoDBService.ConnectMongoDb($"{MyParam.runParam.MongoClient}?connectTimeoutMS={MyParam.runParam.ConnectTimeOut}&socketTimeoutMS=10000&serverSelectionTimeoutMS=5000", $"{MyParam.runParam.DataBaseNameDamCaMau}");
                        }
                    }
                    else
                    {
                        bResult = true;
                    }    
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
