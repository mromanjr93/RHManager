using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using RHManager.MVC.Utils.Validation;

namespace RHManager.MVC.ViewModels
{
    public class FuncionarioViewModel
    {
        [Key]
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage="Preencha o nome")]
        [MaxLength(150, ErrorMessage="Tamanho máximo para o campo {0}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o sobrenome")]
        [MaxLength(150, ErrorMessage = "Tamanho máximo para o campo {0}")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o e-mail")]
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage="Preencha um e-mail válido")]
        public string Email { get; set; }

        [CPF(ErrorMessage="Informe um CPF Válido")]
        public string CPF { get; set; }
        public string RG { get; set; }
        [DisplayName("Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [DisplayName("Salário Bruto")]        
        public Decimal SalarioBruto { get; set; }
        public bool Ativo { get; set; }

        [DisplayName("Data de Admissão")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataAdmissao { get; set; }

        public decimal SalarioLiquido { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}