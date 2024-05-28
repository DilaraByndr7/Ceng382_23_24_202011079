using System;
using System.Collections.Generic;
using System.Linq;

public static class LogService
{
    public static void DisplayLogsByName(string name)

    {

        Console.WriteLine("Printing logs by name: ");
    

        FileLogger.deserializeLog(); 

        if (FileLogger.logRecords != null)
        {
            foreach (LogRecord logRecord in FileLogger.logRecords)
            {
                if (logRecord.Message.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{logRecord.Timestamp}: {logRecord.Message}");
                }
            }
        }
        

    }


    public static void DisplayLogs(DateTime start, DateTime end)

    {
        
        Console.WriteLine("Displaying logs between the time interval: ");
        

        FileLogger.deserializeLog(); 

        if (FileLogger.logRecords != null)
        {
            foreach (LogRecord logRecord in FileLogger.logRecords)
            {
                if (logRecord.Timestamp >= start && logRecord.Timestamp <= end)
                {
                    Console.WriteLine($"{logRecord.Timestamp}: {logRecord.Message}");
                }
            }
        }
        
    }

}