using System;
using System.Diagnostics;
using System.Threading;

namespace MonitCPU
{
    class Program
    {
        static void Main(string[] args)
        {
            // nowy wpis w dzienniku zdarze�
            EventLog eventLog = new EventLog("Application");

            // pr�g u�ycia procesora
            float cpuThreshold = 80;

            while (true)
            {
                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                float cpuUsage = cpuCounter.NextValue();

                if (cpuUsage > cpuThreshold)
                {
                    string message = $"U�ycie procesora przekracza {cpuThreshold}% ({cpuUsage}%).";
                    eventLog.WriteEntry(message, EventLogEntryType.Warning);
                }

                // cz�stotliwo�� sprawdzania
                Thread.Sleep(60000);
            }
        }
    }
}
