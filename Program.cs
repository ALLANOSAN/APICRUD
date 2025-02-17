// Importa o namespace Pessoa.Routers que contém as definições das rotas relacionadas a Pessoa
using Pessoa.Routers;
// Importa o namespace Pessoa.Data que contém o contexto do banco de dados
using Pessoa.Data;

// Cria um construtor de aplicação web com os argumentos fornecidos
var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner de injeção de dependência
// Adiciona o serviço de exploração de endpoints da API
// Saiba mais sobre como configurar o Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Adiciona o serviço de geração de documentação Swagger
builder.Services.AddSwaggerGen();
// Adiciona o serviço de contexto de banco de dados PessoaContext com o tempo de vida Scoped
builder.Services.AddScoped<PessoaContext>();

// Constrói a aplicação web
var app = builder.Build();

// Configura o pipeline de requisição HTTP
// Se o ambiente for de desenvolvimento, ativa o Swagger e a interface do Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Adiciona as rotas relacionadas a Pessoa à aplicação
app.PessoaRotas();

// Habilita a redireção de HTTP para HTTPS
app.UseHttpsRedirection();

// Inicia a aplicação web
app.Run();