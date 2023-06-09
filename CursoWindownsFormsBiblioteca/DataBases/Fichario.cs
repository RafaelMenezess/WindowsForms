﻿using System;
using System.Collections.Generic;
using System.IO;

namespace CursoWindownsFormsBiblioteca.DataBases
{
    public class Fichario
    {
        public string diretorio;
        public string mensagem;
        public bool status;
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
        public List<string> BuscarTodos()
        {
            status = true;
            List<string> list = new List<string>();
            try
            {
                var Arquivos = Directory.GetFiles(diretorio, "*.json");
                for (int i = 0; i <= Arquivos.Length - 1; i++)
                {
                    string conteudo = File.ReadAllText(Arquivos[i]);
                    list.Add(conteudo);
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
                if (!(File.Exists(diretorio + "\\" + id + ".json")))
                {
                    status = false;
                    mensagem = "Indentificador não existe: " + id;
                }
                else
                {
                    File.Delete(diretorio + "\\" + id + ".json");
                    status = true;
                    mensagem = "Exclusão efetuado com sucesso. Identificador: " + id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador erro: " + ex.Message;
            }
        }
        public void Alterar(string id, string jsonUnit)
        {
            status = true;
            try
            {
                if (!(File.Exists(diretorio + "\\" + id + ".json")))
                {
                    status = false;
                    mensagem = "Alteração não permitida porque o identificador não existe: " + id;
                }
                else
                {
                    File.Delete(diretorio + "\\" + id + ".json");
                    File.WriteAllText(diretorio + "\\" + id + ".json", jsonUnit);
                    status = true;
                    mensagem = "Alteração efetuada com sucesso. Identificador: " + id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }
        }
    }
}
