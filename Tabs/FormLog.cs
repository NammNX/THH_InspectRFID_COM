using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TanHungHa.Common;

namespace TanHungHa.Tabs
{
    public partial class FormLog : MaterialForm
    {
        const int MaxShowLogCount = 100;

        Progress pbar = new Progress();

        private static FormLog _instance;
        private static readonly object _lock = new object();
        public static FormLog GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FormLog();
                    }
                }
            }
            return _instance;
        }

        public FormLog()
        {
            InitializeComponent();

            string[] strLoggerType = Enum.GetNames(typeof(SvLogger.LogType));
            for (int i = 0; i < strLoggerType.Length; i++)
            {
                cblSelLog.Items.Add(strLoggerType[i]);
            }

            btn_refresh_Click(this, null);

        }

        public void Adjust_Column()
        {
            //column size
            int total_width = 0;
            for (int id_colum = 0; id_colum < dg_Log.Columns.Count - 1; id_colum++)
            {
                var x = dg_Log.Columns[id_colum];
                total_width += x.Width;
            }
            dg_Log.Columns[dg_Log.Columns.Count - 1].Width = panel_view.Width - total_width;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            pbar.Show();
            dg_Log.DataSource = GetLogList();
            pbar.pBar.Value += 1;
            pbar.Hide();
            Adjust_Column();

        }

        private void dp_Date_ValueChanged(object sender, EventArgs e)
        {
            switch ((sender as DateTimePicker).Name)
            {
                case "dp_startDate":
                    cl_DateSelector.SelectionStart = dp_startDate.Value;
                    break;
                case "dp_endDate":
                    cl_DateSelector.SelectionEnd = dp_endDate.Value;
                    break;
            }
        }

        private void cl_DateSelector_DateChanged(object sender, DateRangeEventArgs e)
        {
            dp_startDate.Value = cl_DateSelector.SelectionStart;
            dp_endDate.Value = cl_DateSelector.SelectionEnd;
        }

        string logDir = SvLogger.m_strLog;

        List<string> GetLogFileList()
        {
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);

            string[] logFiles = Directory.GetFiles(logDir, "*.log", SearchOption.TopDirectoryOnly);

            List<string> selectLogFile = new List<string>();

            for (int i = 0; i < logFiles.Length; i++)
            {
                try
                {
                    long date = long.Parse(Path.GetFileNameWithoutExtension(logFiles[i]).Substring(4));
                    long startDate = long.Parse(dp_startDate.Value.ToString("yyyyMMdd"));
                    long endDate = long.Parse(dp_endDate.Value.ToString("yyyyMMdd"));
                    if (startDate <= date && endDate >= date)
                        selectLogFile.Add(logFiles[i]);
                }
                catch
                {
                    continue;
                }
            }

            return selectLogFile;
        }

        List<LogData> GetLogList()
        {
            List<LogData> logList = LoadLog(GetLogFileList());
            return logList;
        }

        List<LogData> LoadLog(List<string> logFile)
        {
            StringBuilder sbMessage = new StringBuilder();

            StreamReader sr = null;
            List<LogData> list = new List<LogData>();

            pbar.pBar.Maximum = logFile.Count + 1;
            pbar.pBar.Value = 0;

            int count = 0;
            for (int i = 0; i < logFile.Count; i++)
            {
                pbar.pBar.Value = i;
                using (sr = new StreamReader(new FileStream(logFile[i], FileMode.Open, FileAccess.Read, FileShare.Read)))
                {
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            string[] log = sr.ReadLine().Split(',');
                            if (log.Length < 4)
                                throw new Exception("Invalid log format");

                            LogData data = new LogData();
                            data.No = ++count;
                            data.Date = log[0];
                            data.Time = log[1];
                            data.Type = log[2];
                            bool selectFlag = false;
                            for (int k = 0; k < cblSelLog.CheckedItems.Count; k++)
                            {
                                if (cblSelLog.CheckedItems[k] as string == data.Type)
                                {
                                    selectFlag = true; break;
                                }
                            }

                            //tuanna: need check
                            if (selectFlag == false) continue;

                            for (int j = 3; j < log.Length; j++)
                            {
                                sbMessage.Append(log[j]);
                            }
                            data.Message = sbMessage.ToString();
                            sbMessage.Clear();

                            list.Add(data);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
            return list;
        }


        class Progress : Form
        {
            public ProgressBar pBar = new ProgressBar();

            public Progress()
            {
                this.Padding = Padding.Empty;
                this.ClientSize = new System.Drawing.Size(250, 60);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Controls.Add(pBar);
                pBar.Location = new System.Drawing.Point(0, 0);
                pBar.Size = new System.Drawing.Size(325, 60);
                pBar.Margin = Padding.Empty;
            }
        }

    }
}
