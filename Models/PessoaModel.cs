namespace Pessoa.Models
{
    // Classe que representa o modelo de dados para uma pessoa.
    // "Model" aqui é uma parte do padrão MVC (Model-View-Controller), onde Model representa os dados e a lógica de negócio.
    public class PessoaModel
    {
        // Construtor: método executado quando um novo objeto PessoaModel é criado.
        // Recebe um parâmetro "nome" para inicializar a instância.
        public PessoaModel(string nome)
        {
            // Gera um novo GUID (Globally Unique Identifier - Identificador Único Global) para identificar univocamente a pessoa.
            Id = Guid.NewGuid();
            // Atribui o nome recebido ao atributo Nome.
            Nome = nome;
        }

        // Propriedade Id: armazena o identificador único da pessoa.
        // O modificador "init" permite que a propriedade seja setada somente durante a inicialização do objeto.
        public Guid Id { get; init; }

        // Propriedade Nome: armazena o nome da pessoa.
        // Com o modificador "private set", o valor só pode ser alterado dentro da própria classe,
        // garantindo que a modificação externa seja controlada.
        public string Nome { get; private set; }

        // Método TrocarNome: permite alterar o nome da pessoa.
        // Recebe um novo nome e atualiza a propriedade Nome.
        public void TrocarNome(string nome)
        {
            Nome = nome;
        }

        // Método SetInativo: marca a pessoa como inativa.
        // Aqui, a estratégia adotada é alterar o nome da pessoa para a string "desativado".
        // Dependendo dos requisitos da aplicação, isso pode ser substituído por uma propriedade de status.
        public void SetInativo()
        {
            Nome = "desativado";
        }
    }
}