using Microsoft.EntityFrameworkCore;
using GerirAluguel.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GerirAluguel.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Inquilino> Inquilinos { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
        public DbSet<ImovelCaracteristica> ImovelCaracteristicas { get; set; }
        public DbSet<ImovelDespesa> ImovelDespesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ImovelCaracteristica>()
                .HasKey(ic => new { ic.IdImovel, ic.IdCaracteristica });

            modelBuilder.Entity<ImovelDespesa>()
                .HasKey(id => new { id.IdImovel, id.IdDespesa });
        }
    }
}
