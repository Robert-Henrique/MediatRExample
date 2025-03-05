using MediatRExample.Settings;
using MediatRExample.UseCases.CreateProduct;
using MediatRExample.UseCases.GetProductById;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do RavenDB
var ravenDbConfig = builder.Configuration.GetSection("RavenDb").Get<RavenDbSettings>();
var store = new DocumentStore
{
    Urls = ravenDbConfig.Urls,
    Database = ravenDbConfig.Database
};
store.Initialize();

// Registrando IDocumentSession (Scoped)
builder.Services.AddSingleton<IDocumentStore>(_ => store);
builder.Services.AddScoped<IAsyncDocumentSession>(sp =>
    sp.GetRequiredService<IDocumentStore>().OpenAsyncSession());

builder.Services.AddScoped<CreateProductUseCase>();
builder.Services.AddScoped<GetProductByIdUseCase>();

// Registrando o MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProductHandler).Assembly));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Web API")
            .WithTheme(ScalarTheme.BluePlanet)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();