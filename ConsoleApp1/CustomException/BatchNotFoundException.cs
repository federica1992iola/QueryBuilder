using ConsoleApp1.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.CustomException
{
    [Serializable]
    public class BatchNotFoundException : Exception
    {
        public string errorMessageForLog
        { get; set; }

        public string errorMessageForView
        { get; set; }

        public string redirectToPartialView
        { get; set; }

        public BatchNotFoundException() { }

        public BatchNotFoundException(string errorMessage,
                                      string methodName,
                                      string className) : base(errorMessage)
        {
            errorMessageForLog = String.Format("Non è stato trovato il file TaskListBatch al percorso: {0}---Generato dal metodo {1}---Metodo della classe {2}",
                                                errorMessage,
                                                methodName,
                                                className);

            errorMessageForView = "Il File .bat per la configurazione di SqlServer non è stato trovato.";
            redirectToPartialView = "FileNotFoundPartialView";
        }
    }
}
