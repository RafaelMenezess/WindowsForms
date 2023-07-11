using System;
using System.Data;
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

        public DataTable SQLQuery(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                var myCommand = new SqlCommand(sql, connDb);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();
                dt.Load(myReader);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
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

        public void CloseConn()
        {
            connDb.Close();
        }
    }
}
