using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WCL_AutoLogger
{
    class Program
    {
        internal static string WCL_Executable;
        internal static string log_path;
        static void Main(string[] args)
        {
            if (args.Count() == 2)
            {
                log_path = args[1];
                WCL_Executable = args[0];
                processWatcher();
                Console.WriteLine("Watcher is running...click enter to stop it");
                Console.ReadLine();
            } else
            {
                Console.WriteLine("You need to pass exe path to WCL and the log location");
            }
        }
        static void processWatcher()
        {
            ManagementEventWatcher processStartEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");
            ManagementEventWatcher processStopEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStopTrace");
            processStartEvent.EventArrived += new EventArrivedEventHandler(processStartEvent_EventArrived);
            processStopEvent.EventArrived += new EventArrivedEventHandler(processStopEvent_EventArrived);
            processStopEvent.Start();
            processStartEvent.Start();
        }
        static void processStartEvent_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            string processID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value).ToString();
            Console.WriteLine("Process started. Name: " + processName + " | ID: " + processID);

            if (processName.ToLower().Replace(".exe", "") == "wow")
            {
                var wcl = new WCL_Handler(WCL_Executable, log_path);
                wcl.StartLiveLog();
            }
        }

        static void processStopEvent_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            string processID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value).ToString();
            Console.WriteLine("Process stopped. Name: " + processName + " | ID: " + processID);

            if (processName.ToLower().Replace(".exe","") == "wow")
            {
                var wcl = new WCL_Handler(WCL_Executable, log_path);
                wcl.StopLiveLog();
                wcl.DeleteLog();
            }
        }

    }
}
