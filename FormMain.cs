using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TanHungHa.Common;
using TanHungHa.Common.TaskCustomize;

namespace TanHungHa
{
    public partial class FormMain : MaterialForm
    {
        private static FormMain _instance;
        private static readonly object _lock = new object();
        public static FormMain GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {

                    if (_instance == null)
                    {
                        _instance = new FormMain();
                    }
                }
            }
            return _instance;
        }

        void InitSkin()
        {
            // Initialize MaterialSkinManager
            MyParam.materialSkinManager = MaterialSkinManager.Instance;

            // Set this to false to disable backcolor enforcing on non-materialSkin components
            // This HAS to be set before the AddFormToManage()
            MyParam.materialSkinManager.EnforceBackcolorOnAllComponents = true;

            // MaterialSkinManager properties
            MyParam.materialSkinManager.AddFormToManage(this);
            MyParam.materialSkinManager.Theme = MyParam.uIParam.themes;
            DrawerAutoShow = MyParam.uIParam.swAutoShow;
            DrawerUseColors = MyParam.uIParam.swUserColors;
            DrawerHighlightWithAccent = MyParam.uIParam.swHighlightWithAccent;
            DrawerBackgroundWithAccent = MyParam.uIParam.swBackgroundWithAccent;
            DrawerShowIconsWhenHidden = MyParam.uIParam.swDisplayIconWhenHidden;
            MyLib.updateColor();
            Invalidate();


        }

        void InitVariables()
        {
            //this.DoubleBuffered = true;
            //Load parameter
            MyLib.LoadParameter();
            var x = THHInitial.RunHeatbeat();
            //sttVersion.Text = MyDefine.VERSION;
        }


        void InitGUI()
        {
            this.Text = MyDefine.title;
            if (MyParam.runParam.DataBaseName != String.Empty)
            {
                MyParam.autoForm.btnRollName.Visible = true;
                MyParam.autoForm.btnRollName.Text = "Name: " + MyParam.runParam.DataBaseName;
            }
            else
            {
                MyParam.autoForm.btnRollName.Visible = false;
            }
            if(MyParam.runParam.Mode != eMode.Noon)
            {
                MyParam.autoForm.UpdateModeUI();
            }
         //   MyParam.autoForm.UpdateModeUI();

            materialTabControl1.SelectedTab = tabPageAuto;


            MyParam.autoForm.TopLevel = false;
            MyParam.infoForm.TopLevel = false;
            MyParam.logFormDB.TopLevel = false;
            MyParam.managerForm.TopLevel = false;
            MyParam.manualForm.TopLevel = false;
            
            MyParam.autoForm.FormBorderStyle = FormBorderStyle.None;
            MyParam.infoForm.FormBorderStyle = FormBorderStyle.None;
            MyParam.logFormDB.FormBorderStyle = FormBorderStyle.None;
            MyParam.managerForm.FormBorderStyle = FormBorderStyle.None;
            MyParam.manualForm.FormBorderStyle = FormBorderStyle.None;
            
            MyParam.autoForm.Dock = DockStyle.Fill;
            MyParam.infoForm.Dock = DockStyle.Fill;
            MyParam.logFormDB.Dock = DockStyle.Fill;
            MyParam.managerForm.Dock = DockStyle.Fill;
            MyParam.manualForm.Dock = DockStyle.Fill;

            panelAuto.Controls.Add(MyParam.autoForm);
            panelInfo.Controls.Add(MyParam.infoForm);
            panelLog.Controls.Add(MyParam.logFormDB);
            panelManager.Controls.Add(MyParam.managerForm);
            panelManual.Controls.Add(MyParam.manualForm);
            
            panelAuto.Tag = (MyParam.autoForm);
            panelInfo.Tag = (MyParam.infoForm);
            panelLog.Tag = (MyParam.logFormDB);
            panelManager.Tag = (MyParam.managerForm);
            panelManual.Tag = (MyParam.manualForm);


            MyParam.autoForm.BringToFront();
            MyParam.infoForm.BringToFront();
            MyParam.logFormDB.BringToFront();
            MyParam.managerForm.BringToFront();
            MyParam.manualForm.BringToFront();
            
            MyParam.autoForm.Show();
            MyParam.infoForm.Show();
            MyParam.logFormDB.Show();
            MyParam.managerForm.Show();
            MyParam.manualForm.Show();

        }

        public FormMain()
        {
            InitializeComponent();
            InitVariables();
            InitSkin();
            InitGUI();
            
        }


        private void materialTabControl1_Selected(object sender, TabControlEventArgs e)
        {
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "TabPage", e.TabPage);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action);
            messageBoxCS.AppendLine();
            Console.WriteLine(messageBoxCS.ToString());

            switch(e.TabPage.Name)
            {
                case "tabPageAuto":
                    MyParam.curMainView = eMainView.AUTO_VIEW;
                    if (MyParam.runParam.DataBaseName != String.Empty)
                    {
                        MyParam.autoForm.btnRollName.Visible = true;
                        MyParam.autoForm.btnRollName.Text = "Name: " + MyParam.runParam.DataBaseName;
                    }
                    else
                    {
                        MyParam.autoForm.btnRollName.Visible = false;
                    }
                    break;
                
                case "tabPageManual":
                    MyParam.curMainView = eMainView.MANUAL_VIEW;
                    break;
                case "tabPageManager":
                    MyParam.curMainView = eMainView.MANAGER_VIEW;
                    break;
                
                case "tabPageLog":
                    MyParam.curMainView = eMainView.LOGGING_VIEW;
                    MyParam.commonParam.mongoDBService.ConnectMongoDb($"{MyParam.runParam.MongoClient}?connectTimeoutMS={MyParam.runParam.ConnectTimeOut}&socketTimeoutMS=10000&serverSelectionTimeoutMS=5000");
                    MyParam.logFormDB.mtDatePicker1.Date = DateTime.Now;
                    //MyParam.logFormDB.mtDatePicker2.Date = DateTime.Now;
                    break;
                
                case "tabPageInfo":
                    MyParam.curMainView = eMainView.INFOR_VIEW;
                    break;
                
                case "tabPageExit":
                    MyParam.curMainView = eMainView.EXIT_VIEW;
                    closeApp();
                    break;
            }
        }
        void closeApp()
        {
            MaterialDialog materialDialog = new MaterialDialog(this, "Exit?", "Are you sure want to exit?", "OK", true, "Cancel");
            DialogResult result = materialDialog.ShowDialog(this);

            //MaterialSnackBar SnackBarMessage = new MaterialSnackBar(result.ToString(), 750);
            //SnackBarMessage.Show(this);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }
         //if (e.CloseReason == CloseReason.UserClosing)
         //   {
         //       if ((MyParam.commonParam.myComportIQC.GetQueueCount() > 0) || (MyParam.commonParam.myComportOQC.GetQueueCount() > 0)
         //           || (MongoDBService.GetIqcBufferCount() > 0) || (MongoDBService.GetOqcBufferCount() > 0))
         //       {
         //           MyLib.showDlgInfo("Quá trình ghi dữ liệu vào data base chưa hoàn tất, vui lòng đợi trong giây lát");
         //           e.Cancel = true; // Hủy sự kiện đóng
         //           return;
         //       }
         //   }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                if ((MyParam.commonParam.myComportIQC.GetQueueCount() > 0) || (MyParam.commonParam.myComportOQC.GetQueueCount() > 0)
                || (MyParam.commonParam.mongoDBService.GetIqcBufferCount() > 0) || (MyParam.commonParam.mongoDBService.GetOqcBufferCount() > 0))
                {
                    MaterialDialog materialDialog1 = new MaterialDialog(this, "Exit?", "Quá trình ghi dữ liệu vào data base chưa hoàn tất, tiếp tục đóng ?", "OK", true, "Cancel");
                    DialogResult result1 = materialDialog1.ShowDialog(this);
                    if (result1 == DialogResult.Cancel)
                    {
                        e.Cancel = true; // Hủy sự kiện đóng
                        return;
                    }
                }
                //Show dialog confirm exit
                MaterialDialog materialDialog = new MaterialDialog(this, "Exit?", "Bạn có chắc chắn muốn đóng chương trình?", "OK", true, "Cancel");
                DialogResult result = materialDialog.ShowDialog(this);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; // Hủy sự kiện đóng
                    return;
                }
            }
           
            //Close program
            if ((MyParam.runParam.ProgramStatus == ePRGSTATUS.Started) || (MyParam.runParam.ProgramStatus == ePRGSTATUS.Initial))
            {
                MyParam.autoForm.StopProgram();
            }

            MyLib.CloseAllDevices();
            MyLib.SaveParamter();
        }

        private void materialTabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (MyParam.runParam.ProgramStatus == ePRGSTATUS.Started)
            {
                e.Cancel = true;
                MyLib.showDlgWarning("Chương trình đang chạy, Bấm Stop trước khi chuyển Tab ");
                return;
            }
        }
    }
}
