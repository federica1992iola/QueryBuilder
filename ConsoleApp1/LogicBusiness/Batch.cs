using ConsoleApp1.CustomException;
using ConsoleApp1.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LogicBusiness
{
    internal sealed class Batch
    {
        private SqlServerProcessFinder _SqlServerProcessFinder;
        private string _batchPath;
        private static Batch _instance = null;
        private static readonly object padlock = new object();
        private ProcessStartInfo _processStartInfo;

        public ProcessStartInfo _ProcessStartInfo
        {
            get { return _processStartInfo; }
            private set { _processStartInfo = value; }
        }

        public string BatchPath
        {
            get { return _batchPath; }
            set { _batchPath = value; }
        }

        private Batch()
        {

            _SqlServerProcessFinder = new SqlServerProcessFinder();
            BatchPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\" + Constants.BatchConfiguration.BatchFolder;

        }

        public static Batch Instance()
        {
            // Uses lazy initialization.
            if (_instance == null)
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new Batch();
                    }
                }
            }

            return _instance;
        }

        internal void ExecuteBatchFile()
        {
            String completeBatchPath = @"" + BatchPath + "\\" + Constants.BatchConfiguration.BatchFileName;

            try
            {
                OpenProcessWithStartInfo(completeBatchPath);

                _SqlServerProcessFinder.ReadProcess_listFile();

                if (!_SqlServerProcessFinder.ProcessExist)
                {
                    throw new SqlServerConfigurationException("Non è stato installato o configurato correttemente SqlServer sulla macchina", "ExecuteBatchFile", "Batch");
                }

            }
            catch (Exception exc) when (exc is FileNotFoundException)
            {
                throw new BatchNotFoundException(exc.Message, "ExecuteBatchFile", "Batch");
            }
            catch(Exception exc) when (exc is Win32Exception)
            {
                throw new BatchNotFoundException(exc.Message, "ExecuteBatchFile", "Batch");
            }
        }

        private void OpenProcessWithStartInfo(String completeBatchPath)
        {
            _ProcessStartInfo = new ProcessStartInfo(completeBatchPath);
            //Do not create command propmpt window 
            _ProcessStartInfo.CreateNoWindow = true;
            //Do not use shell execution
            _ProcessStartInfo.UseShellExecute = false;
            //Redirects error and output of the process (command prompt).
            _ProcessStartInfo.RedirectStandardError = true;
            _ProcessStartInfo.RedirectStandardOutput = true;
            _ProcessStartInfo.WorkingDirectory = string.Format("{0}", BatchPath);

            using (Process process = Process.Start(_ProcessStartInfo))
            {
                //wait until process is running
                process.WaitForExit(500);

                //reads output and error of command prompt to string.
                string StandardOutput = process.StandardOutput.ReadToEnd();
                string StandardError = process.StandardError.ReadToEnd();

                if (StandardError != null && !StandardError.Equals(""))
                {
                    throw new CmdStandardErrorException(StandardError, "ExecuteBatchFile", "Batch");
                }
            }         
        }


       
    }
}
