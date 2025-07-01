using GerirAluguel.Data;
using GerirAluguel.Services;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; 

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.

// 1. Configuração do DbContext para MySQL usando Pomelo.EntityFrameworkCore.MySql
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString,
                     ServerVersion.AutoDetect(connectionString), // ESSA LINHA É ESPECÍFICA DO POMELO
                     mySqlOptions => mySqlOptions.EnableRetryOnFailure()) // ESTA TAMBÉM
);

// 2. Registro dos seus Services para Injeção de Dependência
builder.Services.AddScoped<InquilinoServices>();
builder.Services.AddScoped<ImovelServices>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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