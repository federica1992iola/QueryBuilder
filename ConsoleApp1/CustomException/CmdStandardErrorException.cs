using ConsoleApp1.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.CustomException
{
    public class CmdStandardErrorException : Exception
    {
        public string errorMessageForLog
        { get; set; }

        public string errorMessageForView
        { get; set; }

        public string redirectToPartialView
        { get; set; }

        public CmdStandardErrorException() { }

        public CmdStandardErrorException(string errorMessage, 
                                         string methodName, 
                                         string className) : base(errorMessage)
        {
            errorMessageForLog = String.Format("Il file TaskListBatch.bat ha terminato la sua esecuzione lanciando un errore sullo stream STDERR: {0}---Generato dal metodo {1}---Metodo della classe {2}",
                                                errorMessage,
                                                methodName,
                                                className);

            errorMessageForView = "Errore interno dell'applicazione. Se persiste rivolgersi al reparto gestione ticket.";
            redirectToPartialView = "InternalErrorPartialView";
        }
    }
}
