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
            
            //var x = THHInitial.RunHeatbeat();
            //sttVersion.Text = MyDefine.VERSION;
        }


        void InitGUI()
        {
            this.Text = MyDefine.title;
            materialTabControl1.SelectedTab = tabPageAuto;


            MyParam.autoForm.TopLevel = false;
            MyParam.infoForm.TopLevel = false;
            MyParam.logForm.TopLevel = false;
            MyParam.managerForm.TopLevel = false;
            MyParam.manualForm.TopLevel = false;
            
            MyParam.autoForm.FormBorderStyle = FormBorderStyle.None;
            MyParam.infoForm.FormBorderStyle = FormBorderStyle.None;
            MyParam.logForm.FormBorderStyle = FormBorderStyle.None;
            MyParam.managerForm.FormBorderStyle = FormBorderStyle.None;
            MyParam.manualForm.FormBorderStyle = FormBorderStyle.None;
            
            MyParam.autoForm.Dock = DockStyle.Fill;
            MyParam.infoForm.Dock = DockStyle.Fill;
            MyParam.logForm.Dock = DockStyle.Fill;
            MyParam.managerForm.Dock = DockStyle.Fill;
            MyParam.manualForm.Dock = DockStyle.Fill;

            panelAuto.Controls.Add(MyParam.autoForm);
            panelInfo.Controls.Add(MyParam.infoForm);
            panelLog.Controls.Add(MyParam.logForm);
            panelManager.Controls.Add(MyParam.managerForm);
            panelManual.Controls.Add(MyParam.manualForm);
            
            panelAuto.Tag = (MyParam.autoForm);
            panelInfo.Tag = (MyParam.infoForm);
            panelLog.Tag = (MyParam.logForm);
            panelManager.Tag = (MyParam.managerForm);
            panelManual.Tag = (MyParam.manualForm);


            MyParam.autoForm.BringToFront();
            MyParam.infoForm.BringToFront();
            MyParam.logForm.BringToFront();
            MyParam.managerForm.BringToFront();
            MyParam.manualForm.BringToFront();
            
            MyParam.autoForm.Show();
            MyParam.infoForm.Show();
            MyParam.logForm.Show();
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
                    break;
                
                case "tabPageManual":
                    MyParam.curMainView = eMainView.MANUAL_VIEW;
                    break;
                case "tabPageManager":
                    MyParam.curMainView = eMainView.MANAGER_VIEW;
                    break;
                
                case "tabPageLog":
                    MyParam.curMainView = eMainView.LOGGING_VIEW;
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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                return;
            }

            //Close program
            if(MyParam.runParam.ProgramStatus == ePRGSTATUS.Started)
            {
                MyParam.autoForm.StopProgram();
            }

            MyLib.CloseAllDevices();
            MyLib.SaveParamter();
        }

    }
}
