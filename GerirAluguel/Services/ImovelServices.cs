using GerirAluguel.Data;
using GerirAluguel.Models;
using GerirAluguel.DTO;
using Microsoft.EntityFrameworkCore;

namespace GerirAluguel.Services
{
    public class ImovelServices
    {
        private readonly AppDbContext _context;

        public ImovelServices (AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Imovel>> GetAll()
        {
            return await _context.Imoveis.ToListAsync();
        }
        public async Task<Imovel?> GetOneById(int id)
        {
            return await _context.Imoveis.FindAsync(id);

        }
        public async Task<Imovel?> Create(ImovelDto dto)
        {
            var Imovel = new Imovel
            {
                DescricaoImovel = dto.DescricaoImovel,
                Endereco = dto.Endereco,
                ValorAluguel = dto.ValorAluguel,
                Status = dto.Status,
            };

            _context.Imoveis.Add(Imovel);
            await _context.SaveChangesAsync();

            return Imovel;
        }

        public async Task<Imovel?> Update(int id, ImovelDto dto)
        {
            var Imovel = await _context.Imoveis.FindAsync(id);

            if (Imovel == null)
                return null;

            Imovel.DescricaoImovel = dto.DescricaoImovel;
            Imovel.Endereco = dto.Endereco;
            Imovel.ValorAluguel = dto.ValorAluguel;
            Imovel.Status = dto.Status;

            await _context.SaveChangesAsync();
            return Imovel;
        }

        public async Task<bool> Delete(int id)
        {
            var Imovel = await _context.Imoveis.FindAsync(id);

            if (Imovel == null)
                return false;

            _context.Imoveis.Remove(Imovel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
