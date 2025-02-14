using Pessoa.Models;
using Pessoa.Data;

namespace Pessoa.Routers;

public static class PessoaRota
{
    public static void PessoaRotas(this WebApplication app)
    {
        var route = app.MapGroup("pessoa");
        
        route.MapPost("",
            async (PessoaRequest req, PessoaContext context) =>
        {
            var pessoa = new PessoaModel(req.Nome);
            await context.AddAsync(pessoa);
            await context.SaveChangesAsync();
        });
    }
}