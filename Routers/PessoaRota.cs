namespace Pessoa.Rotas;

public static class PessoaRota
{
    public static void PessoaRotas(this WebApplication app)
    {
        app.MapGet("Pessoa", () => "ola pessoa"); 
    }
}