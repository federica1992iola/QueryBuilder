using ConsoleApp1.CustomException;
using ConsoleApp1.LogicBusiness;
using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //metodi per controllare, quando l'applicazione chiamando 
            //il batch ha controllato che sulla macchina del cliente
            //è stato installato correttamente l'istanza del server 
            //per salvare i dati del query builder,che la connessione
            //venga inizializzata correttamente
            // Connect connect = new Connect();
            // connect.StartProgram();

            //String fileName = "TaskListBatch.bat";
            //string currentDirectory = Environment.CurrentDirectory;
            //string parentDirectory = Directory.GetParent(Environment.CurrentDirectory).FullName;
            //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\batch";

            //string batDirectory = System.IO.Path.Combine(projectDirectory, fileName);

            Batch.Instance().ExecuteBatchFile();
            
           


        }
    }
}
