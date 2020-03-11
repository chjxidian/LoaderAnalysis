using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoaderAnalysis
{
    static class Program
    {
        private static bool DEBUG = System.Diagnostics.Debugger.IsAttached;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            WindowsPrincipal wp = new WindowsPrincipal(wi);
            if ((!wp.IsInRole(WindowsBuiltInRole.Administrator)) && (!DEBUG))
            {
                runSelfAsAdmin();
                Environment.Exit(0);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Main());
        }


        #region [Run self as Administer]
        public static void runSelfAsAdmin()
        {
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            start.WorkingDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            start.Verb = "runas";
            start.FileName = string.Format("{0}{1}.exe", AppDomain.CurrentDomain.SetupInformation.ApplicationBase, Assembly.GetExecutingAssembly().GetName().Name.ToString());
            System.Diagnostics.Process.Start(start);
        }
        #endregion

    }
}
