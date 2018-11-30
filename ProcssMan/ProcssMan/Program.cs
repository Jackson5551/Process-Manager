using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;

namespace ProcssMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Process Manager CLI || Copyright © 2018 @Jackson5551";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            int counter = 1;
            string processName;
            Console.WriteLine("Process Manager v1.0.0");
            Console.WriteLine("Copyright (c) 2018 @Jackson5551");
            Console.WriteLine("This is a project by @Jackson5551 on Github licensed under the GNU General Public License v3.0.");
            Console.WriteLine("Visit: https://github.com/Jackson5551/Process-Manager to learn more.");
            Console.WriteLine("Press Enter to start....");
            Console.WriteLine("");
            Console.Read();
            Console.Clear();
            Process[] processlist = Process.GetProcesses();

            while (counter == 1)
            {
                foreach (Process theprocess in processlist)
                {
                    Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
                }
                try
                {
                    Console.WriteLine("\nEnter the name of the process you wold like to kill and then hit enter: ");
                    Console.Read();
                    processName = Console.ReadLine();
                    KillProcess(processName);
                    Console.Clear();
                    Console.WriteLine("Process killed.");
                    Console.Read();
                }catch(Exception x)
                {
                    Console.WriteLine(x.Message);
                }
            }
        }
        public static void KillProcess(string name)
        {
            foreach (var process in Process.GetProcessesByName(name))
            {
                process.Kill();
            }
        }
    }
}
