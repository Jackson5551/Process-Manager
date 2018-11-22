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
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            int counter = 1;
            int procssid;
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
            }
            
            Console.WriteLine("\nEnter the name of the process you wold like to kill: ");
            Console.Read();
            procssid = Convert.ToInt32(Console.ReadLine());
            Process p = Process.GetProcessById(procssid);
            p.Kill();
            Console.Read();
        }
    }
}
