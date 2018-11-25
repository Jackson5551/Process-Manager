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
            Console.Title = "Running Processess";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            int counter = 1;
            int procssid;
            string processName;
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
