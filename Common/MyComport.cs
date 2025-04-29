using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Concurrent;
using System.Threading;

namespace TanHungHa.Common
{
    public class MyComport
    {
        public enum eSerialDataType
        {
            OK,
            NG,
            Unknown
        }

        public class SerialData
        {
            public string Data { get; set; }
            public DateTime Timestamp { get; set; }
            public eSerialDataType Type { get; set; }
        }

        public string prefix { get; set; }
        public string suffix { get; set; }
        public string portName { get; set; }
        public int baudRate { get; set; }
        public int readTimeout { get; set; }
        public int writeTimeout { get; set; }
        public Parity parity { get; set; }
        public int dataBits { get; set; }
        public StopBits stopBits { get; set; }
        public Handshake handshake { get; set; }
        public bool isDTR { get; set; }
        public bool isRTS { get; set; }

        [Browsable(false)]
        public string dataComport { get; set; }
        [JsonIgnore]
        public eSerialDataType typeData { get; set; } = eSerialDataType.Unknown;
        public string tempFileName { get; set; } = "com_temp.json";


        [JsonIgnore]
        [Browsable(false)]
        SerialPort serialPort;

        public MyComport()
        {
            dataComport = "";
            prefix = "";
            suffix = "";
            portName = "COM6";
            baudRate = 9600;
            parity = Parity.None;
            dataBits = 8;
            stopBits = StopBits.One;
            handshake = Handshake.None;

            isDTR = false;
            isRTS = false;
            serialPort = null;
            readTimeout = writeTimeout = 5000;
            isReading = false;
        }

        public MyComport Clone()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<MyComport>(json);
        }

        public bool isConnected()
        {
            if (serialPort == null)
            {
                return false;
            }
            else
            {
                return serialPort.IsOpen;
            }
        }
        public bool Connect()
        {
            if (serialPort == null)
            {
                serialPort = new SerialPort();
            }

            try
            {
                if (!serialPort.IsOpen)
                {

                    serialPort.PortName = portName;
                    serialPort.BaudRate = baudRate;
                    serialPort.DataBits = dataBits;
                    serialPort.StopBits = stopBits;
                    serialPort.Parity = parity;
                    serialPort.Handshake = handshake;

                    serialPort.RtsEnable = isRTS;
                    serialPort.DtrEnable = isDTR;

                    serialPort.ReadTimeout = readTimeout;
                    serialPort.WriteTimeout = writeTimeout;

                    //serialPort.ErrorReceived += SerialPort_ErrorReceived;
                    //serialPort.DataReceived += SerialPort_DataReceived;

                    serialPort.Open();
                    // Bắt đầu thread đọc dữ liệu
                    isReading = true;
                    readThread = new Thread(ReadDataThread);
                    readThread.Start();
                }
            }
            catch (Exception ex)
            {

                MyLib.showDlgError(ex.Message);


            }
            return serialPort.IsOpen;
        }
        private void ReadDataThread()
        {
            try
            {
                while (isReading)
                {
                    if (serialPort.IsOpen)
                    {
                        // Kiểm tra xem có dữ liệu trong buffer không
                        if (serialPort.BytesToRead > 0)
                        {
                            try
                            {
                                // Đọc dữ liệu từ cổng COM
                                string dataComport = serialPort.ReadLine();

                                // Nếu có dữ liệu và không rỗng
                                if (!string.IsNullOrEmpty(dataComport))
                                {
                                    eSerialDataType typeData;
                                    // Kiểm tra nếu dữ liệu có lỗi (NG) hay không
                                    if (dataComport.Replace("\r", "").Replace("\n", "").Trim().Length <= MyParam.commonParam.devParam.LengthNG)
                                    {
                                        typeData = eSerialDataType.NG;
                                    }
                                    else
                                    {
                                        typeData = eSerialDataType.OK;
                                    }

                                    // Đóng gói dữ liệu và đưa vào queue
                                    CollectDataCom(dataComport, typeData);
                                }
                            }
                            catch (TimeoutException)
                            {
                                // Xử lý trường hợp timeout
                                Console.WriteLine("Timeout occurred while reading from serial port.");
                            }
                        }

                        // Đảm bảo vòng lặp không chiếm dụng quá nhiều CPU
                        Thread.Sleep(10); 
                    }
                }
            }
            catch (Exception ex)
            {
                MyLib.showDlgError("Error in ReadDataThread: " + ex.Message);
            }
        }



        private void SerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MyLib.showDlgError(e.EventType.ToString());
            Console.WriteLine("SerialPort_ErrorReceived" + e.EventType.ToString());
        }

        //  public Queue<string> queueData = new Queue<string>(MyDefine.MAX_QUEUE_DATA);
        public ConcurrentQueue<SerialData> queueData = new ConcurrentQueue<SerialData>();
        private Thread readThread;  
        private bool isReading;  



        public object lockQueue = new object();
        public void ClearDataRev()
        {
           while (queueData.TryDequeue(out _)) ;
        }
        public void CollectDataCom(string str, eSerialDataType type)
        {
                var item = new SerialData
                {
                    Data = str,
                    Timestamp = DateTime.Now,
                    Type = type
                };
            //if(queueData.Count > MyDefine.MAX_QUEUE_DATA)
            //{
            //    Console.WriteLine("-------------@@@@@@@@@@@@@@@@@@@@------------------" + queueData.Count + "---"+ str);
            //}    

                queueData.Enqueue(item);
                //try
                //{
                //    string json = JsonConvert.SerializeObject(item);
                //    File.AppendAllText(tempFileName, json + Environment.NewLine);
                //}
                //catch (Exception ex)
                //{
                //    MyLib.showDlgError("Error writing to temp file: " + ex.Message);
                //}
        }
        public void RestoreQueueFromFile()
        {
                if (!File.Exists(tempFileName))
                    return;

                try
                {
                    var lines = File.ReadAllLines(tempFileName);
                    foreach (var line in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            var item = JsonConvert.DeserializeObject<SerialData>(line);
                            queueData.Enqueue(item);
                        }
                    }


                    File.Delete(tempFileName);
                }
                catch (Exception ex)
                {
                    MyLib.showDlgError("Error restoring queue: " + ex.Message);
                }
        }


        //public void CollectDataCom(string str)
        //{
        //    lock (lockQueue)
        //    {
        //        queueData.Enqueue(str);

        //    }
        //}
        string data = "";
        public SerialData GetDataCom()
        {
            SerialData temp = new SerialData();
            queueData.TryDequeue(out temp);
            return temp;
        }

        public int GetQueueCount()
        {
            return queueData.Count;
        }


        //public string GetDataCom()
        //{
        //    //string data = "";
        //    lock (lockQueue)
        //    {
        //        if (queueData.Count > 0)
        //        {
        //            data = queueData.Dequeue();
        //        }

        //    }

        //    return data;

        //}
        public void ClearDataCom()
        {
            data = string.Empty;
            // return data;
        }
        private void SerialPort_DataReceived(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {

            try
            {
                dataComport = serialPort.ReadLine();
                //Console.WriteLine(dataComport);

                if (string.IsNullOrEmpty(dataComport))
                    return;
                if (dataComport.Replace("\r", "").Replace("\n", "").Trim().Length <= MyParam.commonParam.devParam.LengthNG)
                {
                    typeData = eSerialDataType.NG;

                }
                else
                {
                    typeData = eSerialDataType.OK;
                }

                CollectDataCom(dataComport, typeData);
            }
            catch (Exception ex)
            {
                MyLib.showDlgError(ex.Message);
                Console.WriteLine("----------" + ex.Message);

            }
        }

        public bool DisConnect()
        {
            if (serialPort == null)
                return false;

            try
            {
                isReading = false;
                if (readThread != null && readThread.IsAlive)
                {
                    readThread.Join();  // Đợi thread kết thúc trước khi tiếp tục
                }
                serialPort.Close();

                //serialPort.DataReceived -= SerialPort_DataReceived;
                //serialPort.ErrorReceived -= SerialPort_ErrorReceived;
            }
            catch (Exception ex)
            {
                MyLib.showDlgError(ex.Message);
            }

            return !serialPort.IsOpen;
        }

        public bool SendData(string data)
        {
            if (serialPort == null || !serialPort.IsOpen)
                return false;
            try
            {
                serialPort.Write(string.Format($"{prefix}{data}{suffix}"));
            }
            catch (Exception e)
            {
                MyLib.showDlgError(e.Message);
            }
            return true;
        }

    }
}
