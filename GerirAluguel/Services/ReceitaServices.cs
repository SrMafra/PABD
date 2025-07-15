using GerirAluguel.Data;
using GerirAluguel.DTO;
using GerirAluguel.Models;
using Microsoft.EntityFrameworkCore;

namespace GerirAluguel.Services
{
    public class ReceitaServices
    {
        private readonly AppDbContext _context;

        public ReceitaServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Receita>> GetAll()
        {
            return await _context.Receitas
                .Include(r => r.Contrato) // opcional, se quiser incluir o contrato
                .ToListAsync();
        }

        public async Task<Receita?> GetById(int id)
        {
            return await _context.Receitas
                .Include(r => r.Contrato)
                .FirstOrDefaultAsync(r => r.ReceitaId == id);
        }

        public async Task<Receita> Create(ReceitaDto dto)
        {
            var receita = new Receita
            {
                DataPagamento = dto.DataPagamento,
                ValorPagamento = dto.ValorPagamento,
                Situacao = dto.Situacao,
                ContratoId = dto.ContratoId
            };

            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync();
            return receita;
        }

        public async Task<Receita?> Update(int id, ReceitaDto dto)
        {
            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null) return null;

            receita.DataPagamento = dto.DataPagamento;
            receita.ValorPagamento = dto.ValorPagamento;
            receita.Situacao = dto.Situacao;
            receita.ContratoId = dto.ContratoId;

            await _context.SaveChangesAsync();
            return receita;
        }

        public async Task<bool> Delete(int id)
        {
            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null) return false;

            _context.Receitas.Remove(receita);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
