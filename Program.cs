using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TanHungHa.Common;
using TanHungHa.Tabs;
using TanHungHa.Tabs.ManualTab;

namespace TanHungHa
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        static Mutex mutex = new Mutex(true, "LogisticsApp");

        [STAThread]
        static void Main()
        {

#if RUNADMIN
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                if (IsRunAsAdmin())
                {
#if KEY
                    try
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(MyParam.mainForm);
                        
                    }
                    catch (Exception ex)
                    {
                        VM.PlatformSDKCS.VmException vmEx = VM.Core.VmSolution.GetVmException(ex);
                        if (null != vmEx)
                        {
                            string codeError = Convert.ToString(vmEx.errorCode, 16).ToUpper();
                            string strMsg = "InitControl failed, check the dongle key (error Code: " + codeError + ")";
                            
                            MyLib.log(strMsg, SvLogger.LogType.ERROR);
                            MessageBox.Show(strMsg);
                        }
                        else
                        {
                            mutex.ReleaseMutex();
                            return;
                        }
                    }
                    mutex.ReleaseMutex();
#else
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(MyParam.mainForm);
                    //Application.Run(new Form1());
#endif
                }
                else
                {
                    RestartAsAdmin();
                }
            }
            else
            {
                MessageBox.Show("Another instance of the application is already running.", "Single Instance App",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
#else
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MyParam.mainForm);
#endif
        }

        private static bool IsRunAsAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private static void RestartAsAdmin()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Application.ExecutablePath;
            startInfo.UseShellExecute = true;
            startInfo.Verb = "runas"; // Set the verb to "runas" to run the process as admin

            try
            {
                Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                // User cancelled the UAC prompt or didn't provide admin credentials
                MessageBox.Show("You need to run the application as an administrator.", "Admin Privileges Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Return without releasing the mutex or exiting the application
            }

            mutex.ReleaseMutex();
            Application.Exit(); // Exit the current instance of the application
        }

    }
}
