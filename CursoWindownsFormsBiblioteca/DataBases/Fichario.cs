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
                throw;
            }

        }

    }
}
