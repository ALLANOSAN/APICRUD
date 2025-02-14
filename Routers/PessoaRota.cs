using APICRUD.Models;
using APICRUD.Data;

namespace APICRUD.Routers;

public static class PessoaRota
{
    public static void PessoaRotas(this WebApplication app)
    {
        var route = app.MapGroup("pessoa");
        route.MapGet("", (PessoaRequest req, PessoaContext context) =>
        {
            return context.Pessoas.Select(p => new { p.Id, p.Nome });
        });
    }
}