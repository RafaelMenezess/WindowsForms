using System;
using System.Collections.Generic;
using System.IO;

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

        public string Buscar(string id)
        {
            status = true;
            try
            {
                var sql = "SELECT ID, JSON FROM " + tabela + "WHERE ID = '" + id + "'";
                var dt = db.SQLQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    string conteudo = dt.Rows[0]["JSON"].ToString();
                    status = true;
                    mensagem = "Inclusão efetuado com sucesso. Identificador: " + id;
                    return conteudo;
                }
                else
                {
                    status = false;
                    mensagem = "Indentificador não existe: " + id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador erro: " + ex.Message;
            }

            return string.Empty;
        }

        public List<string> BuscarTodos()
        {
            status = true;
            List<string> list = new List<string>();
            try
            {
                var sql = "SELECT ID, JSON FROM " + tabela;
                var dt = db.SQLQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        string conteudo = dt.Rows[i]["JSON"].ToString();
                        list.Add(conteudo);
                    }
                    return list;
                }
                else
                {
                    status = false;
                    mensagem = "Não existem clientes na base de dados";
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador erro: " + ex.Message;
            }
            return list;
        }

        public void Apagar(string id)
        {
            status = true;
            try
            {
                var sql = "SELECT ID, JSON FROM " + tabela + "WHERE ID = '" + id + "'";
                var dt = db.SQLQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    sql = "DELET FROM " + tabela + "WHERE ID = '" + id + "'";
                    db.SQLCommand(sql);
                    status = true;
                    mensagem = "Exclusão efetuado com sucesso. Identificador: " + id;
                }
                else
                {
                    status = false;
                    mensagem = "Indentificador não existe: " + id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador erro: " + ex.Message;
            }
        }
    }
}
