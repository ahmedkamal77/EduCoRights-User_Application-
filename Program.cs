using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LoginPage
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [DllImport("kernel32.dll")]
        static extern bool IsDebuggerPresent();
        static void Main()
        {
            if (IsDebuggerPresent() == true)
            {
                MessageBox.Show("Stopped");
                Environment.Exit(-1);
            }

            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Sign_In());
            }


        }
    }
}