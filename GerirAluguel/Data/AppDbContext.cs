using Microsoft.EntityFrameworkCore;
using GerirAluguel.Models;

namespace GerirAluguel.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Inquilino> Inquilino { get; set; }
        public DbSet<Imovel> Imovel { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
        public DbSet<ImovelCaracteristica> ImovelCaracteristicas { get; set; }
        public DbSet<ImovelDespesa> ImovelDespesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Imovel
            modelBuilder.Entity<Imovel>(entity =>
            {
                entity.ToTable("Imovel");
                entity.HasKey(im => im.ImovelId);
                entity.Property(im => im.ImovelId).HasColumnName("id").ValueGeneratedOnAdd();
                entity.Property(im => im.DescricaoImovel).HasColumnName("descricao");
                entity.Property(im => im.Endereco).HasColumnName("endereco");
                entity.Property(im => im.ValorAluguel).HasColumnName("valorAluguel").HasColumnType("decimal(10,2)");
                entity.Property(im => im.Status).HasColumnName("status");
            });

            // Inicio Relacionamentos N:N
            modelBuilder.Entity<ImovelCaracteristica>().HasKey(ic => new { ic.ImovelId, ic.CaracteristicaId });
            modelBuilder.Entity<ImovelCaracteristica>().Property(ic => ic.ImovelId).HasColumnName("idImovel");
            modelBuilder.Entity<ImovelCaracteristica>().Property(ic => ic.CaracteristicaId).HasColumnName("idCaracteristica");

            modelBuilder.Entity<ImovelDespesa>().HasKey(id => new { id.ImovelId, id.DespesaId });
            modelBuilder.Entity<ImovelDespesa>().Property(id => id.ImovelId).HasColumnName("idImovel");
            modelBuilder.Entity<ImovelDespesa>().Property(id => id.DespesaId).HasColumnName("idDespesa");
            // Fim Relacionamento N:N

            modelBuilder.Entity<Inquilino>(entity =>
            {
                entity.ToTable("Inquilino");
                entity.HasKey(iq => iq.InquilinoId);
                entity.Property(iq => iq.InquilinoId).HasColumnName("id").ValueGeneratedOnAdd();
                entity.Property(iq => iq.Nome).HasColumnName("nome");
                entity.Property(iq => iq.Cpf).HasColumnName("cpf");
                entity.Property(iq => iq.Email).HasColumnName("email");
                entity.Property(iq => iq.Telefone).HasColumnName("telefone");
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.ToTable("Contrato");
                entity.HasKey(ct => ct.ContratoId);
                entity.Property(ct => ct.ContratoId).HasColumnName("id").ValueGeneratedOnAdd();
                entity.Property(ct => ct.DataInicio).HasColumnName("dataInicio");
                entity.Property(ct => ct.DataFim).HasColumnName("dataFim");
                entity.Property(ct => ct.ValorMensal).HasColumnName("valorMensal");

                entity.Property(ct => ct.InquilinoId).HasColumnName("idInquilino");
                entity.HasOne(ct => ct.Inquilino)
                      .WithMany(iq => iq.Contratos)
                      .HasForeignKey(ct => ct.InquilinoId);

                entity.Property(ct => ct.ImovelId).HasColumnName("idImovel");
                entity.HasOne(ct => ct.Imovel)
                      .WithMany(im => im.Contratos)
                      .HasForeignKey(ct => ct.ImovelId);

                entity.HasMany(ct => ct.Receitas)
                      .WithOne(r => r.Contrato)
                      .HasForeignKey(r => r.ContratoId);
            });


            modelBuilder.Entity<Receita>(entity =>
            {
                entity.ToTable("Receita");
                entity.HasKey(r => r.ReceitaId);
                entity.Property(r => r.ReceitaId).HasColumnName("id").ValueGeneratedOnAdd();
                entity.Property(r => r.DataPagamento).HasColumnName("dataReferencia");
                entity.Property(r => r.ValorPagamento).HasColumnName("valor");
                entity.Property(r => r.Situacao).HasColumnName("situacao");

                entity.Property(r => r.ContratoId).HasColumnName("idContrato");
                entity.HasOne(r => r.Contrato)
                      .WithMany(ct => ct.Receitas)
                      .HasForeignKey(r => r.ContratoId);
            });
        }
    }
}