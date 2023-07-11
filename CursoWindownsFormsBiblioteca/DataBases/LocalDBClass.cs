using System.Data.SqlClient;

namespace CursoWindownsFormsBiblioteca.DataBases
{
    public class LocalDBClass
    {
        public string stringConn;
        public SqlConnection connDb;

        public LocalDBClass()
        {
            stringConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rafael\\source\\repos\\WindowsForms\\CursoWindownsFormsBiblioteca\\DataBases\\Fichario.mdf;Integrated Security=True";
            connDb = new SqlConnection(stringConn);
            connDb.Open();
        }
    }
}
