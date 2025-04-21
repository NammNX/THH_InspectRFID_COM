using log4net;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace TanHungHa.Common
{
    public class SvLogger
    {
        public static SvLogger Log = new SvLogger();

        log4net.ILog log;
        log4net.Repository.Hierarchy.Hierarchy m_Hierarchy;

        //Program Turned On Date
        DateTime m_Today_Log;
        DateTime m_Today_Image;

        //Setting member variables
        //If possible, change it here instead of changing it in the AddApender method below. When I change from below,

        public const string m_strRoot = "C:\\THH";
        public const string m_strLog = m_strRoot + "\\log";                      // log root
        public const string m_strImage = m_strRoot + "\\Image";                  // image root

        public const string m_strOK = m_strImage + "\\Image";                  // OK Image
        public const string m_strNG = m_strImage + "\\Error";                  // NG Image
        public const string m_strRE = m_strImage + "\\Retry";                  // Retry Image
        public const string m_strTP = m_strImage + "\\Tape";                   // Tape Image

        public bool m_bSaveImageOk = true;
        public bool m_bSaveImageNg = true;
        public bool m_bSaveLog = true;
        public bool m_bSkipAlign = true;
        public bool m_bChangeTapePos = true;
        public bool m_bUseDIO = true;

        public int m_imaxDayImages = 365;                 // Maximum backup date by image
        public int m_imaxDayOkImages = 365;               // Maximum backup date by image OK
        public int m_imaxDayNgImages = 365;               // Maximum backup date by image NG

        public int m_iMaxSizeSizeBackups = 0;             // Log by date Size (file size) Maximum number of backup logs. Create a backup log in the form of "date.number.log".
        // If 0 is specified, the log file is created when the capacity is over.

        public int m_imaxSizeDateBackups = 365;           // Set the log per folder to Date (date) Maximum number of logs

        // There are times when there is a +1 error due to a structural problem and sometimes it is not... Let's ignore it...

        string m_strMaximumFileSize = "30MB";   // Maximum size per log file. Since the capacity unit is automatically parsed, use only "KB", "MB" and "GB". Case sensitive!

        //=====================================> Therefore, the maximum hard drive capacity is. 31 X 30 MB X 6 = 5.58 GB


        // constructor. initialization
        private SvLogger()
        {
            if (!Directory.Exists(m_strOK)) Directory.CreateDirectory(m_strOK);
            if (!Directory.Exists(m_strNG)) Directory.CreateDirectory(m_strNG);
            if (!Directory.Exists(m_strRE)) Directory.CreateDirectory(m_strRE);
            if (!Directory.Exists(m_strTP)) Directory.CreateDirectory(m_strTP);

            log = log4net.LogManager.GetLogger("log");

            // Get the Repository hierarchy containing the logger.
            m_Hierarchy = (log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository();
            m_Hierarchy.Configured = true;  // This option must be turned on to enable dynamic creation

            //logger initialization
            AddApender(log, "%date{yyyy-MM-dd},%date{HH:mm:ss.fff},%message%newline");

            // Organize log and image folders once when creating
            CleanLogFolder();

            // Save the program start date.
            m_Today_Log = DateTime.Now;
            m_Today_Image = DateTime.Now;
        }

        /// <summary>
        /// log initialization. Logging pattern definition.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="strPattern"></param>
        void AddApender(log4net.ILog log, string strPattern)
        {
            log4net.Repository.Hierarchy.Logger logger = (log4net.Repository.Hierarchy.Logger)log.Logger;
            log4net.Appender.RollingFileAppender appender = new log4net.Appender.RollingFileAppender();

            //appender setting
            appender.File = Path.Combine(SvLogger.m_strLog, "Log_.log");        // Name of the main log file to be created in the full path
            appender.PreserveLogFileNameExtension = true;                       // Decide whether to keep the file extension or not. It should be true as the extension created above.
            appender.StaticLogFileName = false;                                 // Whether the file name is fixed or not. If it is fixed (true), the name is not changed to a date.

            appender.Encoding = System.Text.Encoding.Unicode;                   // Use Unicode
            appender.AppendToFile = true;                                       // Option to write to a file. necessary

            appender.LockingModel = new log4net.Appender.FileAppender.MinimalLock();    // How to grab the IO handle when writing to the file above.


            // Define file rolling mode Date + Size
            // What is this part? Currently, Log4Net does not provide automatic deletion by date.
            // Automatic deletion function is provided only when rolling by size
            // ex) When RollingMode = Composite, size = 1KB, MaxSizeRollBackups = 5
            // 1. Create files by date
            // 2. When the size of one log file per date exceeds 1KB, re-create up to 5 files (~~~.5.log) in the form of ~~~.1.log ~~~.2.log
            // 3. When making the 6th Size Rolling Log, delete the number 5 by pushing the numbers of Rolling Logs 1 to 5 created above one by one
            //        
            appender.RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Composite;

            // The part that rolls with the file size.
            appender.MaxSizeRollBackups = m_iMaxSizeSizeBackups; // Number of files to be backed up per day. If the number of logs per date is exceeded, old files are deleted.
            appender.MaximumFileSize = m_strMaximumFileSize;  // Back up the file with only the file size. If it becomes larger than this, a new log file is created.


            // Create a new file after the date has passed. Rolling is not allowed
            appender.DatePattern = "yyyyMMdd"; // construct a name to attach to the old log if the date has passed

            // Pattern to record log.
            appender.Layout = new log4net.Layout.PatternLayout(strPattern);

            //Activate the Appender and attach it to the log
            appender.ActivateOptions();

            logger.AddAppender(appender);
            logger.Hierarchy = m_Hierarchy;
            logger.Level = logger.Hierarchy.LevelMap["ALL"];
        }

        #region Logging function repacking.

        public enum LogType { SEQUENCE, ERROR, DEBUG, DATA, RECIPE }

        public void Sequence(string message)
        {
            if (!m_bSaveLog) return;

            RollOverDate(log);

            log.Debug("SEQUENCE," + message);
        }

        public void Error(string message)
        {
            if (!m_bSaveLog) return;

            RollOverDate(log);

            log.Debug("ERROR," + message);
        }

        public void Debug(string message)
        {
            if (!m_bSaveLog) return;

            RollOverDate(log);

            log.Debug("DEBUG," + message);
        }

        public void Recipe(string message)
        {
            if (!m_bSaveLog) return;

            RollOverDate(log);

            log.Debug("RECIPE," + message);
        }

        public void Data(string message)
        {
            if (!m_bSaveLog) return;

            RollOverDate(log);

            log.Debug("DATA," + message);
        }


        #endregion

        public void RollOverLog()
        {
            RollOverDate(log, true);
        }

        /// <summary>
        /// Delete unconditionally according to the maximum number of log files in the folder
        /// </summary>
        /// <param name="log">Type of log to delete</param>
        void RollOverDate(ILog log)
        {
            RollOverDate(log, false);
        }

        /// <summary>
        /// Delete according to the maximum number of log files in the folder
        /// </summary>
        /// <param name="log">Type of log to delete</param>
        /// <param name="bInitFlag">Init flag. If true, unconditionally clean folders. If false, only clean folders when the date changes</param>
        void RollOverDate(ILog log, bool bInitFlag)
        {
            try
            {

                // Check from date. Return if the date has not changed compared to when the program was turned on.
                // If bInitFlag is true, do not return.
                if ((DateTime.Now.Subtract(m_Today_Log).TotalDays < 1) && !bInitFlag) return;


                // Get the file from the log directory and get the number.
                if (!Directory.Exists(m_strLog)) return; // If the directory does not exist.    

                string[] strLogFiles = Directory.GetFiles(m_strLog);
                int iCountOfFilesInDir = strLogFiles.GetLength(0);


                // Returns when there is no file or only one file in the folder.
                //tuanna: need check
                if (iCountOfFilesInDir <= 1) return;


                // number of files exceeded
                int iOverCount = iCountOfFilesInDir - m_imaxSizeDateBackups;
                if (iOverCount > 0)
                {

                    //Bubble sort (I think the get files are probably sorted by name.... Then it is O(n) complexity.)
                    for (int i = 0; i < iCountOfFilesInDir; i++)
                    {
                        for (int j = iCountOfFilesInDir - 1; j > i; j--)
                        {
                            if (strLogFiles[j - 1].CompareTo(strLogFiles[j]) > 0)
                            {
                                string strTemp = strLogFiles[j - 1];
                                strLogFiles[j - 1] = strLogFiles[j];
                                strLogFiles[j] = strTemp;
                            }
                        }
                    }


                    // Delete repeatedly as much as it exceeds the maximum number.
                    for (int i = 0; i < iOverCount; i++)
                    {
                        // delete the oldest date file
                        if (File.Exists(strLogFiles[i]))
                        {
                            System.IO.File.Delete(strLogFiles[i]);
                        }
                    }
                }

                // When done, update today's date. This part is important.
                if (!bInitFlag) // When not called during initialization
                    m_Today_Log = DateTime.Now;
            }
            catch (Exception deleteEx)
            {
                Console.WriteLine(deleteEx.ToString());
            }
        }

        /// <summary>
        /// Delete other folders/files from the log folder
        /// </summary>
        void CleanLogFolder()
        {

            // If the log folder does not exist, create it
            if (!Directory.Exists(m_strLog)) Directory.CreateDirectory(m_strLog);

            // Search for Sub folder in log folder
            string[] strLogDirs = Directory.GetDirectories(m_strLog);


            //Delete the sub folder in the log folder
            foreach (string strLogDir in strLogDirs)
            {
                Directory.Delete(strLogDir, true);
            }


            //Delete files with an extension other than ".log" (case insensitive) in the log folder
            string[] strLogFiles = Directory.GetFiles(m_strLog);
            foreach (string strLogFile in strLogFiles)
            {
                string strLogFileExtension = Path.GetExtension(strLogFile);
                if (strLogFileExtension.ToLower() != ".log")
                    File.Delete(strLogFile);
            }
        }

        /// <summary>
        /// Delete according to the maximum number of Image folders
        /// </summary>
        public void RollOverImage()
        {
            RollOverImage(m_strOK, true);
            RollOverImage(m_strNG, true);
            RollOverImage(m_strRE, true);
            RollOverImage(m_strTP, true);
        }

        void RollOverImage(string strDir, bool bInitFlag)
        {
            try
            {
                //if ((DateTime.Now.Subtract(m_Today_Image).TotalDays < 1) && !bInitFlag) return;

                //Search the Sub folder in the image folder
                string[] strImageDirs = Directory.GetDirectories(strDir);
                int iCountOfDir = strImageDirs.GetLength(0);


                // Return when there is no Sub or only one Sub in the folder.
                if (iCountOfDir <= 1) return;

                // Exceeded number of directories
                int iOverCount;

                if (strDir != m_strNG)
                    iOverCount = iCountOfDir - m_imaxDayOkImages;
                else
                    iOverCount = iCountOfDir - m_imaxDayNgImages;

                if (iOverCount > 0)
                {

                    //Bubble sort (I think the get files are probably sorted by name.... Then it is O(n) complexity.)
                    for (int i = 0; i < iCountOfDir; i++)
                    {
                        for (int j = iCountOfDir - 1; j > i; j--)
                        {
                            if (strImageDirs[j - 1].CompareTo(strImageDirs[j]) > 0)
                            {
                                string strTemp = strImageDirs[j - 1];
                                strImageDirs[j - 1] = strImageDirs[j];
                                strImageDirs[j] = strTemp;
                            }
                        }
                    }

                    // Delete repeatedly as much as it exceeds the maximum number.
                    for (int i = 0; i < iOverCount; i++)
                    {
                        // delete the oldest date folder
                        if (Directory.Exists(strImageDirs[i]))
                        {
                            Directory.Delete(strImageDirs[i], true);
                        }
                    }
                }

                if (!bInitFlag) // When not called during initialization
                    m_Today_Image = DateTime.Now;
            }
            catch (Exception deleteEx)
            {
                Console.WriteLine(deleteEx.ToString());
            }
        }

        public void SetSaveImageOkEnable(bool Enable)
        {
            m_bSaveImageOk = Enable;
        }

        public void SetSaveImageNgEnable(bool Enable)
        {
            m_bSaveImageNg = Enable;
        }

        public void SetSaveLogEnable(bool Enable)
        {
            m_bSaveLog = Enable;
        }

        public void SetSaveUseDIOEnable(bool Enable)
        {
            m_bUseDIO = Enable;
        }

        public void SetSaveSkipAlignEnable(bool Enable)
        {
            m_bSkipAlign = Enable;
        }

        public void SetChangeTapePosEnable(bool Enable)
        {
            m_bChangeTapePos = Enable;
        }

        public void SetSaveMaxImage(int max)
        {
            m_imaxDayImages = max;
        }

        public void SetSaveMaxImageOk(int max)
        {
            m_imaxDayOkImages = max;
        }

        public void SetSaveMaxImageNg(int max)
        {
            m_imaxDayNgImages = max;
        }

        public void SetSaveMaxLog(int max)
        {
            if (max != m_imaxSizeDateBackups) {
                m_imaxSizeDateBackups = max;
                RollOverLog();
            }
        }

        public void SetSaveImage(int max)
        {
            if (max != m_imaxDayOkImages) {
                SetSaveMaxImage(max);
                SetSaveMaxImageOk(max);
                SetSaveMaxImageNg(max);

                RollOverImage();
            }
        }
    }
}