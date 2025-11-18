//Jonas da Rosa Oliveira
//18/11/2025
//https://www.linkedin.com/in/jonas-da-rosa-oliveira

using BackendBnpAntlia.Interfaces;
using BackendBnpAntlia.Repositories;
using BackendBnpAntlia.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IMovimentoManualRepository, MovimentoManualRepository>();
builder.Services.AddScoped<IProdutoCosifRepository, ProdutoCosifRepository>();

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IProdutoCosifService, ProdutoCosifService>();
builder.Services.AddScoped<IMovimentoManualService, MovimentoManualService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
