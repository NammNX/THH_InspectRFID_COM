using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using TanHungHa.Common.Parameter;
using TanHungHa.Common.TaskLoopCustomize;
using TanHungHa.Tabs;
using TanHungHa.Tabs.ManualTab;
using static MaterialSkin.Controls.MaterialForm;

namespace TanHungHa.Common
{
    public enum eTaskLoop
    {
        Task_HEATBEAT,
        Task_RS232_IQC,
        Task_RS232_OQC,
        Task_RS232_Manual
    }


    public enum eMainView
    {
        AUTO_VIEW,
        MANUAL_VIEW,
        TEACHING_VIEW,
        MANAGER_VIEW,
        LOGGING_VIEW,
        INFOR_VIEW,
        EXIT_VIEW
    }
    
    public enum eManagerView
    {
        MANAGER_PARAMTER_VIEW,
        MANAGER_MODEL_VIEW,
        MANAGER_THEME_VIEW
    }
    
    public class StepControl
    {
        public eProcessing Cur_Processing;
        public eProcessing Old_Processing;


        [JsonIgnore]
        public Stopwatch watchTimeprocess;

        public StepControl()
        {
            Cur_Processing = eProcessing.None;
            Old_Processing = eProcessing.None;
            watchTimeprocess = new Stopwatch();
        }

        public void SetStep(eProcessing step)
        {
            if (Cur_Processing == step)
            {
                Console.WriteLine("Dupplicate Step");
                return;
            }
            //Update step
            Old_Processing = Cur_Processing;
            Cur_Processing = step;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Old step = {Old_Processing}");
            Console.WriteLine($"Cur step = {Cur_Processing}");
        }
    }


    public static class MyParam
    {
        static int number_create = 0;
        public static List<TaskLoop> taskLoops = new List<TaskLoop>();
        public static MaterialSkinManager materialSkinManager;
        
        [JsonIgnore]
        public static eMainView curMainView = eMainView.AUTO_VIEW;
        
        [JsonIgnore]
        public static eManagerView curManagerView = eManagerView.MANAGER_PARAMTER_VIEW;

        public static UIParam uIParam = null;
        public static CommonParam commonParam = null;
        public static RunParam runParam = null;


        public static FormAuto autoForm = null;
        public static FormInfo infoForm = null;
        public static FormLog logForm = null;
        public static FormManager managerForm = null;
        public static FormManual manualForm = null;
        public static FormMain mainForm = null;


        //sub tab of Manual TAB
        public static RS232Form tabRS232 = null;
       
        


        //sub tab of Manager TAB
        public static ManParamForm tabManagerParam = null;
        public static ManThemeForm tabManagerTheme = null;



        public static void initial()
        {
            //task
            for (int i = 0; i < MyDefine.NUM_THREAD; i++)
            {
                taskLoops.Add(new TaskLoop());
            }

            //param
            uIParam = UIParam.GetInstance();
            commonParam = CommonParam.GetInstance();
            runParam = RunParam.GetInstance();

            //form
            tabRS232 = RS232Form.GetInstance();
           

            //manual
            tabManagerParam = ManParamForm.GetInstance();
            tabManagerTheme = ManThemeForm.GetInstance();

            autoForm = FormAuto.GetInstance();
            infoForm = FormInfo.GetInstance();
            logForm = FormLog.GetInstance();
            managerForm = FormManager.GetInstance();
            manualForm = FormManual.GetInstance();
            mainForm = FormMain.GetInstance();

        }
        static MyParam()
        {
            Console.WriteLine($"Constructor MyParam = {number_create++}");
            initial();
        }
    }

    public class UIParam
    {
        private static UIParam _instance;
        private static readonly object _lock = new object();
        public static UIParam GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UIParam();
                    }
                }
            }
            return _instance;
        }
        public MaterialSkinManager.Themes themes { get; set; }
        public MaterialForm.FormStyles styles { get; set; }
        public bool swUserColors { get; set; }
        public bool swHighlightWithAccent { get; set; }
        public bool swBackgroundWithAccent { get; set; }
        public bool swDisplayIconWhenHidden { get; set; }
        public bool swAutoShow { get; set; }
        public int colorSchemeIndex { get; set; }

        UIParam()
        {
            themes = MaterialSkinManager.Themes.LIGHT;
            styles = FormStyles.StatusAndActionBar_None;
            swUserColors = true;
            swHighlightWithAccent = true;
            swBackgroundWithAccent = true;
            swDisplayIconWhenHidden = true;
            swAutoShow = true;
            colorSchemeIndex = 2;
        }


    }
}
