using System;
using System.Linq;
using System.Data.Entity;
using RHManager.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using RHManager.Infrastructure.Data.EntityConfig;

namespace RHManager.Infrastructure.Data.Context
{
    public class RHManagerContext : DbContext
    {
        public RHManagerContext()
            : base("RHManagerConnection")
        {
            //Inicializa o banco de dados e o cria caso não exista
            Database.SetInitializer<RHManagerContext>(new RHManagerDbInitializer());
        }
        

        
        /// <summary>
        ///    Este método é um override para estabelecer algumas configurações Default para o Migrations
        ///    Configura coisas do tipo: Tamanho do campo na tabela, comportamento quando excluir registros relacionados, estabelece tipo do campo
        ///    no banco de dados padrão quando não especificado, etc.
        /// </summary>
        /// <param name="modelBuilder">
        ///  modelBuilder é um objeto do tipo DbModelBuilder do EntityFramework, no qual está contido todos os métodos para realizar as configurações
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                        .Where(p => p.Name == p.ReflectedType.Name + "Id")
                        .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                        .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                        .Configure(p => p.HasMaxLength(100));
                        
            modelBuilder.Configurations.Add(new FuncionarioConfiguration());            
        }


        /// <summary>
        ///  Este método é um Override do SaveChanges, que neste caso implementei uma regra comum para salvar campos de Data em todos os módulos da aplicação
        ///  em qualquer tabela
        /// </summary>
        /// <returns>Status da operação</returns>
        public override int SaveChanges()
        {  

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    
                }
            }
            return base.SaveChanges();
        }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }

    /// <summary>
    /// Classe para iniciar Banco de Dados, para teste!
    /// </summary>
    public class RHManagerDbInitializer : DropCreateDatabaseIfModelChanges<RHManagerContext>
    {
        protected override void Seed(RHManagerContext context)
        {
              context.Funcionarios.Add(                  
                  new Funcionario { Nome = "Marcelo Roman", Sobrenome = "Roman Junior", CPF = "406.844.998-86", RG = "48.992.313-6", Email = "marcelo.junior107@gmail.com", SalarioBruto = 5000.00m, DataAdmissao = DateTime.Now, Ativo = true, DataNascimento = new DateTime(1993,03,23)}
               );

                context.SaveChanges();
        }  
    }
}
