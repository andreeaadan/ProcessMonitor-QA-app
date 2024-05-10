using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace monitor
{
    public class ProcessMonitor
    {
        public static readonly string ClosingMessage = "Process monitor closed.";
        public static readonly string InvalidInputErrorMessage = "Invalid input. Only 'q' is allowed to close the process monitor.";
        public static void Main(string[] args)
        {
            try
            {
                ArgumentParser parser = new ArgumentParser(args);

                Thread inputThread = new Thread(MonitorInput);
                inputThread.Start();

                MonitorProcesses(parser.ProcessName, parser.MaxLifetime, parser.MonitoringFrequency);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void MonitorInput()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.KeyChar == 'q')
                {
                    Console.WriteLine("\n" + ClosingMessage);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\n" + InvalidInputErrorMessage);
                }
                Thread.Sleep(100);
            }
        }

        public static void MonitorProcesses(string processName, int maxLifetime, int monitoringFrequency)
        {
            while (true)
            {
                Process[] processes = Process.GetProcessesByName(processName);
                foreach (Process process in processes)
                {
                    TimeSpan processDuration = DateTime.Now - process.StartTime;
                    if (processDuration.TotalMinutes > maxLifetime)
                    {
                        process.Kill();
                        Console.WriteLine("Process " + processName + " was killed.");
                    }
                }
                Thread.Sleep(monitoringFrequency * 60000);
            }
        }
    }
}