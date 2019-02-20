using ConsoleApp1.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SqlServerProcessFinder
    {
        private string _batchPath;

        public string BatchPath
        {
            get { return _batchPath; }
            private set { _batchPath = value; }
        }

        public bool ProcessExist
        { get; set; }

        public SqlServerProcessFinder()
        {
            _batchPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\" + Constants.BatchConfiguration.BatchFolder;
        }


        internal void ReadProcess_listFile()
        {
            string fileContents = String.Empty;
            string filePath = System.IO.Path.Combine(BatchPath, Constants.SqlServerConfiguration.TaskListFileName);

            using (StreamReader sr = new StreamReader(filePath))
            {
                string content = sr.ReadToEnd();
                var contentSplitted = content.Split('\n');
                FindSqlServerProcess(contentSplitted);

            }

        }


        private void FindSqlServerProcess(String[] contentSplitted)
        {
            String pattern = Constants.SqlServerConfiguration.ProcessName;

            var parser = new Regex(pattern, RegexOptions.Compiled);
            String sqlServerProcess = contentSplitted.Where(x => parser.IsMatch(x)).ToString();

            ProcessExist = (sqlServerProcess != null || sqlServerProcess != "") ? true : false;

        }
    }
}
