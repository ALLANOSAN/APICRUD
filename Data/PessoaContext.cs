using Microsoft.EntityFrameworkCore;
using Pessoa.Models;
namespace Pessoa.Data;

public class PessoaContext : DbContext
{
    public DbSet<PessoaModel> Pessoas { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Pessoa.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}