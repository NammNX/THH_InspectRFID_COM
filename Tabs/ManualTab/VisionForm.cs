using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office.SpreadSheetML.Y2023.MsForms;
using MaterialSkin.Controls;
using TanHungHa.Common;
using TanHungHa.Common.VM;
using VM.Core;
using VM.PlatformSDKCS;

namespace TanHungHa.Tabs.ManualTab
{
    public partial class VisionForm : MaterialForm
    {
        private static VisionForm _instance;
        private static readonly object _lock = new object();
        public static VisionForm GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new VisionForm();
                    }
                }
            }
            return _instance;
        }
        VisionForm()
        {
            InitializeComponent();
            InitVM();
        }
        public void InitUI()
        {
            UpdateModelName();
            InitVM();
            if (!pathSol.Contains(".solw"))
                return;
            this.Cursor = Cursors.WaitCursor;
            LoadSolution(pathSol);
            this.Cursor = Cursors.Default;

        }
        private void InitVM()
        {
            if (isInitVM)
                return;

            if (mainViewControl == null)
            {
                mainViewControl = new MainViewControl();
                mainViewControl.Dock = DockStyle.Fill;
            }

            // Ensure only one control is docked at a time
            panelVM.Controls.Clear();

            // Add the main view control
            panelVM.Controls.Add(mainViewControl);
            mainViewControl.BringToFront();
            mainViewControl.Show();

            isInitVM = true;


        }
        private MainViewControl mainViewControl;
        string pathSol = "";
        bool isInitVM = false;
        bool isLoadSol = false;
        public void InitJobPath()
        {
            if (MyParam.runParam.curModel.SolPath.Contains(".solw"))
            {
                pathSol = MyParam.runParam.curModel.SolPath;
            }
        }
        public void UpdateModelName()
        {
            if (MyParam.runParam.curModel != null)
            {
                btnModel.Text = $"Model:{MyParam.runParam.curModel.Name}";
            }
        }
        public void LoadSolution(string solPath)
        {
            if (solPath == null || !MyLib.fileIsExists(solPath))
            {
                MyLib.showDlgWarning($"{solPath} is null or not exits, please check!");
                return;
            }
            try
            {
                VmSolution.Load(solPath);

                mainViewControl.Refresh();
                isLoadSol = true;

                // renderControl.vmRenderControl1.ModuleSource = processList[0];
                // renderControl.Refresh();

            }
            catch (Exception ex)
            {
                //var strMsg = "Load Solution failed. Error Code: " + MyLib.GetSDKError(ex);
                //MyLib.showDlgError(strMsg);
                MyLib.log(ex.Message, SvLogger.LogType.ERROR);
            }
        }

        private void btnLoadJob_Click(object sender, EventArgs e)
        {
            LoadSolution(pathSol);
        }

        private void btnSaveJob_Click(object sender, EventArgs e)
        {
            if (!isLoadSol)
            {
                MyLib.showDlgWarning($"{pathSol} is not load, please check!");
                return;
            }

            if (!MyLib.fileIsExists(pathSol))
            {
                MyLib.showDlgWarning($"{pathSol} is not exits, please check!");
                return;
            }
            try
            {
                VmSolution.Save();
                MyLib.showDlgInfo("Save Solution Done");
            }
            catch (VmException ex)
            {
                var strMsg = "SaveSolution failed. Error Code: " + Convert.ToString(ex.errorCode, 16);
                MyLib.showDlgError(strMsg);
                MyLib.log(strMsg);
            }
            
        }
    }
}
