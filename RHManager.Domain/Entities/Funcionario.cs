using System;

namespace RHManager.Domain.Entities
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public Decimal SalarioBruto { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataCadastro { get; set; }
        
        /// <summary>
        /// Regra de negócio para calcular salario líquido
        /// Apenas para exemplificar que Models de Domínios armazenam regras de negócio
        /// </summary>
        /// <returns>Salário calculado</returns>
        public decimal SalarioLiquido()
        {
            decimal salarioLiquido = SalarioBruto;
            decimal baseCalculoIRPF = SalarioBruto;
            decimal descontoINSS = 0;
            // Condições para INSS
            if (SalarioBruto <= 1556.94m)
            {
                descontoINSS = SalarioBruto * 0.08m;
                salarioLiquido = SalarioBruto - descontoINSS;
            }
            else if (SalarioBruto >= 1556.94m && SalarioBruto <= 2594.92m)
            {
                descontoINSS = SalarioBruto * 0.09m;
                salarioLiquido = SalarioBruto - descontoINSS;
            }
            else if (SalarioBruto >= 2594.93m && SalarioBruto <= 5189.82m)
            {
                descontoINSS = SalarioBruto * 0.11m;
                salarioLiquido = SalarioBruto - descontoINSS;
            }
            else
            {
                descontoINSS = 570.88m;
                salarioLiquido = SalarioBruto - descontoINSS;
            }
            // Fim calculo INSS


            // Cálculo IRPF 2016
            baseCalculoIRPF = SalarioBruto - descontoINSS;
            if (baseCalculoIRPF >= 1903.99m && baseCalculoIRPF <= 2826.65m)
            {
                // Calcula o imposto sobre 7,5% e deduz 142.80 do imposto, segundo tabela atual
                salarioLiquido = salarioLiquido - ((baseCalculoIRPF * 0.075m) - 142.80m) ;
            }
            else if (baseCalculoIRPF >= 2826.66m && baseCalculoIRPF <= 3751.05m)
            {
                salarioLiquido = salarioLiquido - ((baseCalculoIRPF * 0.15m) - 354.80m);
            }
            else if (baseCalculoIRPF >= 3751.06m && baseCalculoIRPF <= 4664.68m)
            {
                salarioLiquido = salarioLiquido - ((baseCalculoIRPF * 0.225m) - 636.13m);
            }
            else if (baseCalculoIRPF > 4664.68m)
            {
                salarioLiquido = salarioLiquido - ((baseCalculoIRPF * 0.275m) - 869.36m);
            }


            //return Convert.ToDecimal(salarioLiquido.ToString("#.##"));
            return salarioLiquido;
        }


    }
}
