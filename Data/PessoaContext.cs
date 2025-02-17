// Importa o namespace do Entity Framework Core, que é um ORM (Object-Relational Mapper) para .NET
using Microsoft.EntityFrameworkCore;

// Importa o namespace que contém o modelo de dados PessoaModel
using Pessoa.Models;

namespace Pessoa.Data
{
    // Define a classe PessoaContext que herda de DbContext, que é a classe base para o contexto do Entity Framework Core
    public class PessoaContext : DbContext
    {
        // Define uma propriedade DbSet para PessoaModel, que representa a coleção de todas as entidades no contexto
        public DbSet<PessoaModel> Pessoas { get; set; }
        
        // Sobrescreve o método OnConfiguring para configurar o contexto do banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configura o contexto para usar um banco de dados SQLite com o arquivo de banco de dados "Pessoa.sqlite"
            optionsBuilder.UseSqlite("Data Source=Pessoa.sqlite");
            // Chama o método base OnConfiguring da classe DbContext
            base.OnConfiguring(optionsBuilder);
        }
    }
}