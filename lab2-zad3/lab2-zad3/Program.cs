using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        // Utwórz liczniki wykorzystania procesora i pamięci
        PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter memCounter = new PerformanceCounter("Memory", "Available MBytes");

        // Utwórz obiekt dziennika zdarzeń
        EventLog eventLog = new EventLog();
        eventLog.Source = "MyMonitoringApp";
        eventLog.Log = "Application";

        // Pętla monitorowania i zapisywania zdarzeń
        while (true)
        {
            // Pobierz aktualne użycie procesora i dostępną pamięć
            float cpuUsage = cpuCounter.NextValue();
            float availableMemory = memCounter.NextValue();

            // Sprawdź czy użycie procesora przekracza 80%
            if (cpuUsage > 80)
            {
                // Zapisz zdarzenie o przekroczeniu użycia procesora do dziennika zdarzeń
                string cpuMessage = $"Użycie procesora przekroczyło 80% ({cpuUsage}%).";
                eventLog.WriteEntry(cpuMessage, EventLogEntryType.Warning);
                Console.WriteLine(cpuMessage);
            }

            // Sprawdź czy dostępna pamięć jest mniejsza niż 1000 MB
            if (availableMemory < 1000)
            {
                // Zapisz zdarzenie o małej dostępnej pamięci do dziennika zdarzeń
                string memMessage = $"Dostępna pamięć spadła poniżej 100 MB ({availableMemory} MB).";
                eventLog.WriteEntry(memMessage, EventLogEntryType.Warning);
                Console.WriteLine(memMessage);
            }

            // Poczekaj 1 sekundę przed kolejnym sprawdzeniem
            Thread.Sleep(1000);
        }
    }
}
