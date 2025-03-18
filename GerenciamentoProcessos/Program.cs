using GerenciamentoProcessos.Models;
using GerenciamentoProcessos.Repositories;
using GerenciamentoProcessos.Services.AppServices;
using GerenciamentoProcessos.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona AutoMapper ao container de serviços
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Conexão DataBase
builder.Services.AddDbContext<GerenciamentoProcessosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Services
builder.Services.AddScoped<IClienteAppService, ClienteAppService>();
builder.Services.AddScoped<IDistribuicaoProcessoAppService, DistribuicaoProcessoAppService>();
builder.Services.AddScoped<IDocumentoAppService, DocumentoAppService>();
builder.Services.AddScoped<IPrazoAppService, PrazoAppService>();
builder.Services.AddScoped<IProcessosAppService, ProcessosAppService>();
builder.Services.AddScoped<IProcuradorAppService, ProcuradorAppService>();


// Repositories
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IDistribuicaoProcessoRepository, DistribuicaoProcessoRepository>();
builder.Services.AddScoped<IDocumentoRepository, DocumentoRepository>();
builder.Services.AddScoped<IPrazoRepository, PrazoRepository>();
builder.Services.AddScoped<IProcessosRepository, ProcessosRepository>();
builder.Services.AddScoped<IProcuradorRepository, ProcuradorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
