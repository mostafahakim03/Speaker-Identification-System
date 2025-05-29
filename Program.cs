using Recorder.MainFuctions;
using System;
using System.Windows.Forms;

namespace Recorder
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //SequenceMatching.train();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
