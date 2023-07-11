using System;
using System.Data.SqlClient;

namespace CursoWindownsFormsBiblioteca.DataBases
{
    public class LocalDBClass
    {
        public string stringConn;
        public SqlConnection connDb;

        public LocalDBClass()
        {
            try
            {
                stringConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rafael\\source\\repos\\WindowsForms\\CursoWindownsFormsBiblioteca\\DataBases\\Fichario.mdf;Integrated Security=True";
                connDb = new SqlConnection(stringConn);
                connDb.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string SQLCommand(string sql)
        {
            try
            {
                var myCommand = new SqlCommand(sql, connDb);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();

                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }
    }
}
