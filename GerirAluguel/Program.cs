using GerirAluguel.Data;
using GerirAluguel.Services;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; 

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner.

// 1. Configura��o do DbContext para MySQL usando Pomelo.EntityFrameworkCore.MySql
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString,
                     ServerVersion.AutoDetect(connectionString), // ESSA LINHA � ESPEC�FICA DO POMELO
                     mySqlOptions => mySqlOptions.EnableRetryOnFailure()) // ESTA TAMB�M
);

// 2. Registro dos seus Services para Inje��o de Depend�ncia
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