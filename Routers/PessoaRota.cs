// Importa o namespace Pessoa.Models que contém as definições dos modelos de dados
using Pessoa.Models;
// Importa o namespace Pessoa.Data que contém o contexto do banco de dados
using Pessoa.Data;
// Importa o namespace Microsoft.EntityFrameworkCore que é um ORM (Object-Relational Mapper) para .NET
using Microsoft.EntityFrameworkCore;

// Define o namespace Pessoa.Routers que agrupa as rotas relacionadas a Pessoa
namespace Pessoa.Routers;

// Define uma classe estática chamada PessoaRota
public static class PessoaRota
{
    // Método de extensão que adiciona rotas relacionadas a Pessoa a uma instância de WebApplication
    public static void PessoaRotas(this WebApplication app)
    {
        // Cria um grupo de rotas com o prefixo "pessoa"
        var route = app.MapGroup("pessoa");
        
        // Define uma rota POST para criar uma nova pessoa
        route.MapPost("",
            async (PessoaRequest req, PessoaContext context) =>
        {
            // Cria uma nova instância de PessoaModel com o nome fornecido na requisição
            var pessoa = new PessoaModel(req.Nome);
            // Adiciona a nova pessoa ao contexto do banco de dados de forma assíncrona
            await context.AddAsync(pessoa);
            // Salva as alterações no banco de dados de forma assíncrona
            await context.SaveChangesAsync();
        });

        // Define uma rota GET para obter a lista de todas as pessoas
        route.MapGet("", 
            async (PessoaContext context) =>
        {
            // Obtém a lista de todas as pessoas do banco de dados de forma assíncrona
            var pessoas = await context.Pessoas.ToListAsync();
            // Retorna a lista de pessoas com o status HTTP 200 (OK)
            return Results.Ok(pessoas);
        });

        // Define uma rota PUT para atualizar o nome de uma pessoa existente
        route.MapPut("{id:guid}",
            async (Guid id, PessoaRequest req, PessoaContext context) =>
        {
            // Procura a pessoa no banco de dados pelo ID fornecido de forma assíncrona
            var pessoa = await context.Pessoas.FirstOrDefaultAsync(x => x.Id == id);
            // Se a pessoa não for encontrada, retorna o status HTTP 404 (Not Found)
            if (pessoa == null)
                return Results.NotFound();
                
            // Atualiza o nome da pessoa com o novo nome fornecido na requisição
            pessoa.TrocarNome(req.Nome);
            // Salva as alterações no banco de dados de forma assíncrona
            await context.SaveChangesAsync();
                
            // Retorna a pessoa atualizada com o status HTTP 200 (OK)
            return Results.Ok(pessoa);
        });

        // Define uma rota DELETE para marcar uma pessoa como inativa
        route.MapDelete("{id:guid}", 
            async (Guid id, PessoaContext context) =>
        {
            // Procura a pessoa no banco de dados pelo ID fornecido de forma assíncrona
            var pessoa = await context.Pessoas.FirstOrDefaultAsync(x => x.Id == id);
            // Se a pessoa não for encontrada, retorna o status HTTP 404 (Not Found)
            if (pessoa == null)
                return Results.NotFound();

            // Marca a pessoa como inativa
            pessoa.SetInativo();
            // Salva as alterações no banco de dados de forma assíncrona
            await context.SaveChangesAsync();                
            // Retorna a pessoa marcada como inativa com o status HTTP 200 (OK)
            return Results.Ok(pessoa);
        });
    }
}