using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCL_AutoLogger
{
    class WCL_Handler
    {
        private string wCL_Executable;
        private string log_path;
        public WCL_Handler(string wCL_Executable, string log_path)
        {
            this.wCL_Executable = wCL_Executable;
            this.log_path = log_path;

        }

        public void StartLiveLog()
        {
            if (File.Exists(wCL_Executable))
            { 
                DateTime x = DateTime.Now;
                Process.Start(wCL_Executable, $@"livelog=""{x.ToString("dd/MM/yyyy HH:mm:ss")}""");
            } else
            {
                Console.WriteLine("ERROR: WCL EXECUTABLE DOESN*T EXIST");
            }
        }
        public void StopLiveLog()
        {
            var name = Path.GetFileName(wCL_Executable).Replace(".exe", "");
            var processes = Process.GetProcessesByName(name);
            foreach (var process in processes)
            {
                process.Kill();
            }
        }

        internal void DeleteLog()
        {
            if (File.Exists(log_path))
            {
                File.Delete(log_path);
            } else
            {
                Console.WriteLine("Tried to delete log, but could not find it");
            }
        }
    }
}
