using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Connect c = new Connect();
            c.button1_Click();
            DatabaseProcessFinder d = new DatabaseProcessFinder();

            String fileName = "batch.bat";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullName = System.IO.Path.Combine(desktopPath, fileName);

            try
            {
                string batDir = desktopPath;
                Process proc = new Process();
                proc.StartInfo.WorkingDirectory = batDir;
                proc.StartInfo.FileName = fileName;
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();

            }
            catch (Exception exc)
            {

            }

            d.ReadTaskListFile();

            bool? result = d.IsProcessActive;


        }
    }
}
