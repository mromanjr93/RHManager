using System.Data.Entity.ModelConfiguration;
using RHManager.Domain.Entities;

namespace RHManager.Infrastructure.Data.EntityConfig
{
    /// <summary>
    /// Classe de configuração da tabela no banco de dados para Migrations, 
    /// Usa Fluent API
    /// </summary>
    public class FuncionarioConfiguration : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfiguration()
        {
            HasKey(f => f.FuncionarioId);

            Property(f => f.Nome)
                    .IsRequired()
                    .HasMaxLength(150);


            Property(f => f.Sobrenome)
                    .IsRequired()
                    .HasMaxLength(150);

            Property(f => f.Email)                    
                    .IsRequired();

            Property(f => f.DataAdmissao)
                    .IsRequired()                    
                    .HasColumnType("date");

            Property(f => f.DataNascimento)
                    .IsRequired()
                    .HasColumnType("date");

            ToTable("Funcionarios");
        }
    }
}
