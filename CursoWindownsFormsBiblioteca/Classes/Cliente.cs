﻿using CursoWindowsFormsBiblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
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
        }

        public class List
        {
            public List<Unit> ListUnit { get; set; }
        }
    }
}
