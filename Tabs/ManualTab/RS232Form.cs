using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperSimpleTcp;
using TanHungHa.Common;

namespace TanHungHa.Tabs.ManualTab
{
    public partial class RS232Form : MaterialForm
    {
        private static RS232Form _instance;
        private static readonly object _lock = new object();
        public static RS232Form GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new RS232Form();
                    }
                }
            }
            return _instance;
        }
        public RS232Form()
        {
            InitializeComponent();
            initSerialPort();
        }
        void initSerialPort()
        {
            try
            {
                cbbParity.DataSource = Enum.GetValues(typeof(Parity));
                cbbParity.SelectedItem = MyParam.commonParam.myComport.parity;

                cbbHandshake.DataSource = Enum.GetValues(typeof(Handshake));
                cbbHandshake.SelectedItem = MyParam.commonParam.myComport.handshake;

                cbbBaud.DataSource = MyDefine.baudrates;
                cbbBaud.SelectedItem = MyParam.commonParam.myComport.baudRate;

                cbbDataSize.DataSource = MyDefine.dataSize;
                cbbDataSize.SelectedItem = MyParam.commonParam.myComport.dataBits;

                cbbStopbit.DataSource = Enum.GetValues(typeof(StopBits));
                cbbStopbit.SelectedItem = MyParam.commonParam.myComport.stopBits;

                cbbComPort.DataSource = SerialPort.GetPortNames();
                cbbComPort.SelectedItem = MyParam.commonParam.myComport.portName;
            }
            catch (Exception ex)
            {
                MyLib.showDlgError(ex.Message);
            }

        }

        public void setText(string data)
        {
            txtDataReceiver.BeginInvoke(new Action(() =>
            {
                txtDataReceiver.Text += data;
            }));
        }

        private void btnSerialClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var btnSerialName = ((MaterialButton)sender).Name;
            switch (btnSerialName)
            {
                case "btnScanCom":
                    try
                    {
                        cbbComPort.DataSource = null;
                        cbbComPort.Items.Clear(); // Clear existing items

                        string[] portNames = SerialPort.GetPortNames(); // Get all COM port names
                        if (portNames.Length == 0)
                        {
                            MessageBox.Show("No COM ports found.");
                        }
                        else
                        {
                            cbbComPort.DataSource = portNames;
                            cbbComPort.SelectedIndex = 0; // Select the first port by default
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while updating COM ports: " + ex.Message);
                    }
                    break;
                case "btnClearData":
                    txtDataReceiver.Text = "";
                    break;

                case "btnSendDataCom":
                    if (MyParam.commonParam.myComport.isConnected())
                    {
                        MyParam.commonParam.myComport.SendData(txtDataSend.Text + "\r\n");
                        MyLib.log($"Write data = {txtDataSend.Text}");
                    }
                    else
                    {
                        MyLib.showDlgInfo($"Please connect {MyParam.commonParam.myComport.portName} first!");
                    }
                    break;


                case "btnConnectComport":
                    //connect
                    if (MyParam.commonParam.myComport.isConnected())
                    {
                        //disconnect
                        MyParam.commonParam.myComport.DisConnect();
                        MyLib.log($"Disconnect {MyParam.commonParam.myComport.portName}");
                        btnConnectComport.Text = "Connect";
                        MainProcess.StopLoopRS232_Manual();
                    }
                    else
                    {
                        //connect
                        try
                        {
                            MyParam.commonParam.myComport.portName = cbbComPort.Text;
                            MyParam.commonParam.myComport.baudRate = (int)cbbBaud.SelectedItem; //int.Parse(cbbBaud.Text);
                            MyParam.commonParam.myComport.parity = (Parity)cbbParity.SelectedIndex;
                            MyParam.commonParam.myComport.dataBits = (int)cbbDataSize.SelectedItem;
                            MyParam.commonParam.myComport.handshake = (Handshake)cbbHandshake.SelectedItem;
                            MyParam.commonParam.myComport.stopBits = (StopBits)cbbStopbit.SelectedItem;


                            if (MyParam.commonParam.myComport.Connect())
                            {
                                btnConnectComport.Text = "Connected";


                                MainProcess.RunLoopRS232_Manual();
                                MyLib.log($"Connected {MyParam.commonParam.myComport.portName}");
                            }
                        }
                        catch (Exception ex)
                        {
                            MyLib.showDlgError(ex.Message);
                            //MyLib.ShowInfo(ex.Message, "Exception");
                            // MyLib.log(ex.Message, SvLogger.LogType.ERROR);
                        }

                    }
                    break;


            }

            this.Cursor = Cursors.Default;
        }
        public void closeComManual()
        {
            if (MyParam.commonParam.myComport.isConnected())
            {
                MyParam.commonParam.myComport.DisConnect();
                this.Invoke(new Action(() =>
                {
                    btnConnectComport.Text = MyParam.commonParam.myComport.isConnected() ? "Connected" : "Connect";
                }));
            }

        }
    }
}
