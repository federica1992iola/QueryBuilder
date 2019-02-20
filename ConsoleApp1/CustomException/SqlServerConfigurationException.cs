using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.CustomException
{
    public class SqlServerConfigurationException : Exception
    {

        public string errorMessageForLog
        { get; set; }

        public string errorMessageForView
        { get; set; }

        public string redirectToPartialView
        { get; set; }

        public SqlServerConfigurationException() { }

        public SqlServerConfigurationException(string errorMessage,
                                               string methodName,
                                               string className) : base(errorMessage)
        {
            errorMessageForLog = String.Format("Il comando tasklist su prompt non ha trovato il processo sqlservr.exe: {0}---Generato dal metodo {1}---Metodo della classe {2}",
                                                errorMessage,
                                                methodName,
                                                className);

            errorMessageForView = "SqlServer non è stato configurato correttamente sulla macchina.";
            redirectToPartialView = "SqlServerBadConfigurationPartialView";
        }

    }

}
