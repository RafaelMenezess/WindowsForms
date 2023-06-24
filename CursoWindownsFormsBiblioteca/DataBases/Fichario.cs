using System;
using System.IO;

namespace CursoWindownsFormsBiblioteca.DataBases
{
    public class Fichario
    {
        public string diretorio;
        public string mensagem { get; set; }
        public bool status { get; set; }
        public Fichario(string Diretorio)
        {
            status = true;
            try
            {
                if (!(Directory.Exists(Diretorio)))
                {
                    Directory.CreateDirectory(Diretorio);
                }
                diretorio = Diretorio;
                mensagem = "Conexão com o Fichario criada com sucesso.";

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }

        }

        public void Incluir(string id, string jsonUnit)
        {
            status = true;
            try
            {
                if (File.Exists(diretorio + "\\" + id + ".json"))
                {
                    status = false;
                    mensagem = "Inclusão não permitida porque o identificador já existe: " + id;
                }
                else
                {
                    File.WriteAllText(diretorio + "\\" + id + ".json", jsonUnit);
                    status = true;
                    mensagem = "Inclusão efetuado com sucesso. Identificador: " + id;
                }
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
                if (!(File.Exists(diretorio + "\\" + id + ".json")))
                {
                    status = false;
                    mensagem = "Indentificador não existe: " + id;
                }
                else
                {
                    string conteudo = File.ReadAllText(diretorio + "\\" + id + ".json");
                    status = true;
                    mensagem = "Inclusão efetuado com sucesso. Identificador: " + id;
                    return conteudo;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador erro: " + ex.Message;
            }

            return string.Empty;
        }
    }
}
