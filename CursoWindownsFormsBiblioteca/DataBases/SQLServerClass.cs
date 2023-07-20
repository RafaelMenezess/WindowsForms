using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace CursoWindownsFormsBiblioteca.DataBases
{
    public class SQLServerClass
    {
        public string stringConn;
        public SqlConnection connDb;

        public SQLServerClass()
        {
            try
            {
                stringConn = "Data Source=DESKTOP-1AMLFGM;Initial Catalog=ByteBank;Persist Security Info=True;User ID=sa;Password=123";
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
