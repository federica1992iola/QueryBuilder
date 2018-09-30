using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DatabaseProcessFinder
    {

        private const String fileName = "process_list.txt";

        public bool? IsProcessActive
        { get; set; }

        public DatabaseProcessFinder() { }

        public void ReadTaskListFile()
        {
            string fileContents = String.Empty;
            //risolvere il problema da desktop alla cartella di visual studio

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullName = System.IO.Path.Combine(desktopPath, fileName);

            using (StreamReader sr = new StreamReader(fullName))
            {
                string content = sr.ReadToEnd();
                var contentSplitted = content.Split('\n');

                FindSqlServerProcess(contentSplitted); 

            }

        }


        private void FindSqlServerProcess(String[] contentSplitted)
        {
            String pattern = "sqlservr.exe";

            var parser = new Regex(pattern, RegexOptions.Compiled);
            String sqlServerProcess = contentSplitted.Where(x => parser.IsMatch(x)).ToString();

            IsProcessActive = (sqlServerProcess != null || sqlServerProcess != "") ? true : false;

        }





    }
}
