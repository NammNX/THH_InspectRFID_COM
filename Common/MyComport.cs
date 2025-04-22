using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanHungHa.Common
{
    public class MyComport
    {
        public class SerialData
        {
            public string Data { get; set; }
            public DateTime Timestamp { get; set; }
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

                    serialPort.Open();
                    serialPort.ErrorReceived += SerialPort_ErrorReceived;
                    serialPort.DataReceived += SerialPort_DataReceived;
                }
            }
            catch (Exception ex)
            {

                MyLib.showDlgError(ex.Message);

            }
            return serialPort.IsOpen;
        }

        private void SerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MyLib.showDlgError(e.EventType.ToString());
        }

      //  public Queue<string> queueData = new Queue<string>(MyDefine.MAX_QUEUE_DATA);
        public Queue<SerialData> queueData = new Queue<SerialData>(MyDefine.MAX_QUEUE_DATA);


        public object lockQueue = new object();
        public void ClearDataRev()
        {
            lock (lockQueue)
            {
                if (queueData.Count > 0)
                {
                    queueData.Clear();
                }

            }
        }
        public void CollectDataCom(string str)
        {
            lock (lockQueue)
            {
                var item = new SerialData
                {
                    Data = str,
                    Timestamp = DateTime.Now
                };

                queueData.Enqueue(item);
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
            lock (lockQueue)
            {
                if (queueData.Count > 0)
                {
                    return queueData.Dequeue();
                }
            }
            return new SerialData(); // Trả về object rỗng nếu không có dữ liệu
        }

        public int GetQueueCount()
        {
            lock (lockQueue)
            {
                return queueData.Count;
            }
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
                if (string.IsNullOrEmpty(dataComport))
                    return;
                if (dataComport.Replace("\r", "").Replace("\n", "").Trim().Length <= MyParam.commonParam.devParam.LengthNG)
                {
                    SendData("NG");  
                }
                if (MyParam.commonParam.queueData.Count >= MyDefine.MAX_QUEUE_DATA)
                {
                    MyLib.showDlgError("Please stop comport and wait a second!");
                }
                else
                {
                    CollectDataCom(dataComport);

                }

            }
            catch (Exception ex)
            {
                MyLib.showDlgError(ex.Message);

            }
        }

        public bool DisConnect()
        {
            if (serialPort == null)
                return false;

            try
            {
                serialPort.DataReceived -= SerialPort_DataReceived;
                serialPort.Close();
                serialPort.ErrorReceived -= SerialPort_ErrorReceived;
            }
            catch (Exception ex)
            {
                MyLib.showDlgError(ex.Message);
            }

            return serialPort.IsOpen;
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
