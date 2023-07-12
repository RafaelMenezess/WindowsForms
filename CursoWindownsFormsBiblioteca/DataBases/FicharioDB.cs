using System;

namespace CursoWindownsFormsBiblioteca.DataBases
{
    public class FicharioDB
    {
        public string mensagem;
        public bool status;
        public string tabela;
        public LocalDBClass db;

        public FicharioDB(string Tabela)
        {
            status = true;
            try
            {
                db = new LocalDBClass();
                tabela = Tabela;
                mensagem = "Conexão com a tabela criada com sucesso";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão tabela com erro: " + ex.Message;
            }
        }
    }
}
