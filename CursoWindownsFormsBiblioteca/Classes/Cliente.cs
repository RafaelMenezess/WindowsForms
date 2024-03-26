using CursoWindownsFormsBiblioteca.DataBases;
using CursoWindowsFormsBiblioteca;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CursoWindownsFormsBiblioteca.Classes
{
    public class Cliente
    {
        public class Unit
        {
            [Required(ErrorMessage = "Código do cliente é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Código do cliente so aceita valores numéricos")]
            [StringLength(6, MinimumLength = 6, ErrorMessage = "Código do cliente deve ter 6 dígitos")]
            public string Id { get; set; }

            [Required(ErrorMessage = "Nome do cliente é obrigatório")]
            [StringLength(50, ErrorMessage = "Nome do cliente deve ter  no máximo 50 caracteres")]
            public string Nome { get; set; }

            [StringLength(50, ErrorMessage = "Nome do pai deve ter  no máximo 50 caracteres")]
            public string NomePai { get; set; }

            [Required(ErrorMessage = "Nome da Mãe é obrigatório")]
            [StringLength(50, ErrorMessage = "Nome da mãe deve ter  no máximo 50 caracteres")]
            public string NomeMae { get; set; }
            public bool NaoTemPai { get; set; }

            [Required(ErrorMessage = "CPF é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "CPF do cliente so aceita valores numéricos")]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 dígitos")]
            public string Cpf { get; set; }

            [Required(ErrorMessage = "Genero é obrigatório")]
            public int Genero { get; set; }

            [Required(ErrorMessage = "CEP é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "CEP do cliente so aceita valores numéricos")]
            [StringLength(8, MinimumLength = 8, ErrorMessage = "CEP deve ter 8 dígitos")]
            public string Cep { get; set; }

            [Required(ErrorMessage = "Logradouro é obrigatório")]
            [StringLength(100, ErrorMessage = "Complemento deve ter  no máximo 100 caracteres")]
            public string Logradouro { get; set; }

            [Required(ErrorMessage = "Complemento é obrigatório")]
            [StringLength(100, ErrorMessage = "Complemento deve ter  no máximo 100 caracteres")]
            public string Complemento { get; set; }

            [Required(ErrorMessage = "Bairro é obrigatório")]
            [StringLength(50, ErrorMessage = "Bairro deve ter  no máximo 50 caracteres")]
            public string Bairro { get; set; }

            [Required(ErrorMessage = "Cidade é obrigatório")]
            [StringLength(50, ErrorMessage = "Cidade deve ter  no máximo 50 caracteres")]
            public string Cidade { get; set; }

            [Required(ErrorMessage = "Estado é obrigatório")]
            [StringLength(50, ErrorMessage = "Estado deve ter  no máximo 50 caracteres")]
            public string Estado { get; set; }

            [Required(ErrorMessage = "Telefone é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Telefone so aceita valores numéricos")]
            public string Telefone { get; set; }
            public string Profissao { get; set; }

            [Required(ErrorMessage = "Renda Familiar é obrigatória")]
            [Range(0, double.MaxValue, ErrorMessage = "Renda familiar deve ser um valor positivo.")]
            public double RendaFamiliar { get; set; }

            public void ValidaClasse()
            {
                ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
                List<ValidationResult> results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(this, context, results, true);

                if (isValid == false)
                {
                    StringBuilder sbrErrors = new StringBuilder();
                    foreach (var validationResult in results)
                    {
                        sbrErrors.AppendLine(validationResult.ErrorMessage);
                    }
                    throw new ValidationException(sbrErrors.ToString());
                }
            }

            public void ValidaComplemento()
            {
                if (this.NomePai == this.NomeMae)
                {
                    throw new Exception("Nome do Pai e da Mãe não podem ser iguais");
                }
                if (this.NaoTemPai == false)
                {
                    if (this.NomePai == string.Empty)
                    {
                        throw new Exception("Nome do Pai não pode estar vazio quuando a propriedade Pai desconhecido não estiver marcada");
                    }
                }

                bool validaCPF = Cls_Uteis.Valida(Cpf);
                if (validaCPF == false)
                {
                    throw new Exception("Cpf Inválido");
                }
            }

            #region "CRUD do Fichario"
            public void IncluirFichario(string conexao)
            {
                string clienteJson = Cliente.SerializedClassUnit(this);
                Fichario f = new Fichario(conexao);
                if (f.status)
                {
                    f.Incluir(this.Id, clienteJson);
                    if (!(f.status))
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }

            }

            public Unit BuscarFichario(string id, string conexao)
            {
                Fichario f = new Fichario(conexao);
                if (f.status)
                {
                    string clienteJson = f.Buscar(id);
                    return Cliente.DesSerializedClassUnit(clienteJson);
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public void AlterarFichario(string conexao)
            {
                string clienteJson = Cliente.SerializedClassUnit(this);
                Fichario f = new Fichario(conexao);
                if (f.status)
                {
                    f.Alterar(this.Id, clienteJson);
                    if (!(f.status))
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public void ApagarFichario(string conexao)
            {
                string clienteJson = Cliente.SerializedClassUnit(this);
                Fichario f = new Fichario(conexao);
                if (f.status)
                {
                    f.Apagar(this.Id);
                    if (!(f.status))
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }

            }

            public List<string> ListaFichario(string conexao)
            {
                Fichario f = new Fichario("C:\\Users\\Rafael\\source\\repos\\WindowsForms\\Fichario");
                if (f.status)
                {
                    List<string> todosJson = f.BuscarTodos();
                    return todosJson;
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }
            #endregion

            #region "CRUD do FicharioDB Local DB"
            public void IncluirFicharioDB(string conexao)
            {
                string clienteJson = Cliente.SerializedClassUnit(this);
                FicharioDB f = new FicharioDB(conexao);
                if (f.status)
                {
                    f.Incluir(this.Id, clienteJson);
                    if (!(f.status))
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public Unit BuscarFicharioDB(string id, string conexao)
            {
                FicharioDB f = new FicharioDB(conexao);
                if (f.status)
                {
                    string clienteJson = f.Buscar(id);
                    return Cliente.DesSerializedClassUnit(clienteJson);
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public void AlterarFicharioDB(string conexao)
            {
                string clienteJson = Cliente.SerializedClassUnit(this);
                FicharioDB f = new FicharioDB(conexao);
                if (f.status)
                {
                    f.Alterar(this.Id, clienteJson);
                    if (!(f.status))
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public void ApagarFicharioDB(string conexao)
            {
                string clienteJson = Cliente.SerializedClassUnit(this);
                FicharioDB f = new FicharioDB(conexao);
                if (f.status)
                {
                    f.Apagar(this.Id);
                    if (!(f.status))
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public List<List<string>> ListaFicharioDB(string conexao)
            {
                FicharioDB f = new FicharioDB(conexao);
                if (f.status)
                {
                    List<string> List = new List<string>();
                    List = f.BuscarTodos();
                    if (f.status)
                    {
                        List<List<string>> ListaBusca = new List<List<string>>();
                        for (int i = 0; i <= List.Count - 1; i++)
                        {
                            Cliente.Unit C = Cliente.DesSerializedClassUnit(List[i]);
                            ListaBusca.Add(new List<string> { C.Id, C.Nome });
                        }
                        return ListaBusca;
                    }
                    else
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }
            #endregion

            #region "CRUD do FicharioDB SQLServer"
            public void IncluirFicharioSQL(string conexao)
            {
                string clienteJson = Cliente.SerializedClassUnit(this);
                FicharioSQLServer f = new FicharioSQLServer(conexao);
                if (f.status)
                {
                    f.Incluir(this.Id, clienteJson);
                    if (!(f.status))
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public Unit BuscarFicharioSQL(string id, string conexao)
            {
                FicharioSQLServer f = new FicharioSQLServer(conexao);
                if (f.status)
                {
                    string clienteJson = f.Buscar(id);
                    return Cliente.DesSerializedClassUnit(clienteJson);
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public void AlterarFicharioSQL(string conexao)
            {
                string clienteJson = Cliente.SerializedClassUnit(this);
                FicharioSQLServer f = new FicharioSQLServer(conexao);
                if (f.status)
                {
                    f.Alterar(this.Id, clienteJson);
                    if (!(f.status))
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public void ApagarFicharioSQL(string conexao)
            {
                string clienteJson = Cliente.SerializedClassUnit(this);
                FicharioSQLServer f = new FicharioSQLServer(conexao);
                if (f.status)
                {
                    f.Apagar(this.Id);
                    if (!(f.status))
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public List<List<string>> ListaFicharioSQL(string conexao)
            {
                FicharioSQLServer f = new FicharioSQLServer(conexao);
                if (f.status)
                {
                    List<string> List = new List<string>();
                    List = f.BuscarTodos();
                    if (f.status)
                    {
                        List<List<string>> ListaBusca = new List<List<string>>();
                        for (int i = 0; i <= List.Count - 1; i++)
                        {
                            Cliente.Unit C = Cliente.DesSerializedClassUnit(List[i]);
                            ListaBusca.Add(new List<string> { C.Id, C.Nome });
                        }
                        return ListaBusca;
                    }
                    else
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }
            #endregion

            #region "CRUD do Fichcario SQLServer Relacional"

            #region "Funções auxiliares"

            public string ToInsert()
            {
                string Sql = $@"INSERT INTO TB_Cliente
                               (Id,
                                Nome,
                                NomePai,
                                NomeMae,
                                NaoTemPai,
                                Cpf,
                                Genero,
                                Cep,
                                Logradouro,
                                Complemento,
                                Bairro,
                                Cidade,
                                Estado,
                                Telefone,
                                Profissao,
                                RendaFamiliar)
                                VALUES
                               ('{Id}',
                                '{Nome}',
                                '{NomePai}',
                                '{NomeMae}',
                                 {NaoTemPai},
                                '{Cpf}',
                                 {Genero},
                                '{Cep}',
                                '{Logradouro}',
                                '{Complemento}',
                                '{Bairro}',
                                '{Cidade}',
                                '{Estado}',
                                '{Telefone}',
                                '{Profissao}',
                                '{RendaFamiliar}')";

                return Sql;
            }

            public string ToUpdate(string id)
            {
                string Sql = $@"UPDATE TB_Cliente
                                SET
                               (Id = '{Id}',
                                Nome = '{Nome}',
                                NomePai = '{NomePai}',
                                NomeMae = '{NomeMae}',
                                NaoTemPai =  {NaoTemPai},
                                Cpf = '{Cpf}',
                                Genero = {Genero},
                                Cep = '{Cep}',
                                Logradouro = '{Logradouro}',
                                Complemento = '{Complemento}',
                                Bairro = '{Bairro}',
                                Cidade = '{Cidade}',
                                Estado = '{Estado}',
                                Telefone = '{Telefone}',
                                Profissao = '{Profissao}',
                                RendaFamiliar = '{RendaFamiliar}')
                                WHERE Id = {id}";

                return Sql;
            }

            #endregion

            #endregion

        }

        public class List
        {
            public List<Unit> ListUnit { get; set; }
        }

        public static Unit DesSerializedClassUnit(string vJson)
        {
            return JsonConvert.DeserializeObject<Unit>(vJson);
        }
        public static string SerializedClassUnit(Unit unit)
        {
            return JsonConvert.SerializeObject(unit);
        }
    }
}
