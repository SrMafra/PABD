using Microsoft.EntityFrameworkCore;
using GerirAluguel.Models;


namespace GerirAluguel.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Inquilino> Inquilinos { get; set; }
        public DbSet<Imoveis> Imoveis { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
        public DbSet<ImovelCaracteristica> ImovelCaracteristicas { get; set; }
        public DbSet<ImovelDespesa> ImovelDespesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Imoveis>()
                .HasKey(i => i.ImovelId);

           
            modelBuilder.Entity<Caracteristica>()
                .HasKey(c => c.CaracteristicaId);

            modelBuilder.Entity<Contrato>()
                .HasKey(c => c.ContratoId);

         
            modelBuilder.Entity<Inquilino>()
                .HasKey(i => i.InquilinoId);

            modelBuilder.Entity<Receita>()
                .HasKey(r => r.ReceitaId);

          
            modelBuilder.Entity<Despesa>()
                .HasKey(d => d.DespesaId);


          
            modelBuilder.Entity<ImovelCaracteristica>()
                .HasKey(ic => new { ic.ImovelId, ic.CaracteristicaId });

            modelBuilder.Entity<ImovelDespesa>()
                .HasKey(id => new { id.ImovelId, id.DespesaId });

     
            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Inquilino)
                .WithMany(i => i.Contratos) 
                .HasForeignKey(c => c.InquilinoId);

      
            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Imovel)
                .WithMany(i => i.Contrato) 
                .HasForeignKey(c => c.ImovelId);

           
            modelBuilder.Entity<Receita>()
                .HasOne(r => r.Contrato)
                .WithMany(c => c.Receitas) 
                .HasForeignKey(r => r.ContratoId); 
        }
    }
}