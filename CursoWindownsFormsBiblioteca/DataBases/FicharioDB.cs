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

        public void Incluir(string id, string jsonUnit)
        {
            status = true;
            try
            {
                var sql = "INSER INTO " + tabela + " (ID, JSON) VALUES ('" + id + "', '" + jsonUnit + "')";
                db.SQLCommand(sql);
                status = true;
                mensagem = "Inclusão efetuado com sucesso. Identificador: " + id;
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }
        }
    }
}
