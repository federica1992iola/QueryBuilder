using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Connect
    {
        public Connect()
        {
        }

        public void StartProgram()
        {
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;

            var conn = System.Configuration.ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString;

          
            sql = "Select * from tabellaProva";
            connection = new SqlConnection(conn);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }



}
