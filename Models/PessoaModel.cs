namespace APICRUD.Models;

public class PessoaModel
{
    public PessoaModel(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
    }
    public Guid Id { get; init; }
    public string Nome { get; private set; }
}