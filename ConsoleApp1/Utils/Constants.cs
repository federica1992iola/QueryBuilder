using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Utils
{
    public static class Constants
    {
        public static class BatchConfiguration
        {
            public const string BatchFolder = "Batch";
            public const string BatchFileName = "TaskListBatch.bat";
        }

        public static class SqlServerConfiguration
        {
            public const string ProcessName = "sqlservr.exe";
            public const String TaskListFileName = "Process_list.txt";
        }
       
        
    }
}
