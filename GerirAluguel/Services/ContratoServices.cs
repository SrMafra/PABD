using GerirAluguel.Data;
using GerirAluguel.Models;
using GerirAluguel.Dto;
using Microsoft.EntityFrameworkCore;

namespace GerirAluguel.Services
{
    public class ContratoServices
    {
        private readonly AppDbContext _context;

        public  ContratoServices (AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Contrato>>GetAll()
        {
            return await _context.Contratos.ToListAsync();
        }
        public async Task<Contrato?> GetOneById(int id)
        {
           /*return await _context.Contratos.FindAsync(id);*/
           return await _context.Contratos.Include(c=>c.IdInquilino).Include(c=>c.IdImovel).FirstOrDefaultAsync(c=>c.IdContrato ==id);
        }
        public async Task<Contrato?> Create(ContratoDto dto)
        {
            var Contrato = new Contrato
            {
                IdInquilino = dto.IdInquilino,
                IdImovel = dto.IdImovel,
                DataInicio = dto.DataInicio,
                DataFim = dto.DataFim,
                ValorMensal = dto.ValorMensal,
            };
            _context.Contratos.Add(Contrato);
            await _context.SaveChangesAsync();
            return Contrato;
        }
        public async Task<Contrato?> Update(int id, ContratoDto dto)
        {
            var Contrato = await _context.Contratos.FindAsync(id);

            if (Contrato == null)
                return null;

            Contrato.IdInquilino = dto.IdInquilino;
            Contrato.IdImovel = dto.IdImovel;
            Contrato.DataInicio = dto.DataInicio;
            Contrato.DataFim = dto.DataFim;
            Contrato.ValorMensal = dto.ValorMensal;

            await _context.SaveChangesAsync();
            return Contrato;
        }
        public async Task<bool> Delete(int id)
        {
            var Contrato = await _context.Contratos.FindAsync(id);

            if (Contrato == null)
                return false;

            _context.Contratos.Remove(Contrato);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
