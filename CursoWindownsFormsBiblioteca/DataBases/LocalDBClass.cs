using System.Data.SqlClient;

namespace CursoWindownsFormsBiblioteca.DataBases
{
    public class LocalDBClass
    {
        public string stringConn;
        public SqlConnection connDb;

        public LocalDBClass()
        {
            stringConn = "";
            connDb = new SqlConnection(stringConn);
            connDb.Open();
        }
    }
}
