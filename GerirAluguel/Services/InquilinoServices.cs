using GerirAluguel.Data;
using GerirAluguel.Models;
using GerirAluguel.DTO;
using Microsoft.EntityFrameworkCore;

namespace GerirAluguel.Services
{
    public class InquilinoServices
    {
        private readonly AppDbContext _context;

        public InquilinoServices (AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Inquilino>> GetAll()
        {
            return await _context.Inquilinos.ToListAsync();
        }
        public async Task<Inquilino?> GetOneById(int id)
        {
            return await _context.Inquilinos.FindAsync(id);

        }
        public async Task<Inquilino?> Create(InquilinoDto dto)
        {
            var inquilino = new Inquilino
            {
                Nome = dto.Nome,
                Cpf = dto.CPF,
                Email = dto.Email,
                Telefone = dto.Telefone
            };

            _context.Inquilinos.Add(inquilino);
            await _context.SaveChangesAsync();

            return inquilino;
        }

        public async Task<Inquilino?> Update(int id, InquilinoDto dto)
        {
            var inquilino = await _context.Inquilinos.FindAsync(id);

            if (inquilino == null)
                return null;

            inquilino.Nome = dto.Nome;
            inquilino.Cpf = dto.CPF;
            inquilino.Email = dto.Email;
            inquilino.Telefone = dto.Telefone;

            await _context.SaveChangesAsync();
            return inquilino;
        }

        public async Task<bool> Delete(int id)
        {
            var inquilino = await _context.Inquilinos.FindAsync(id);

            if (inquilino == null)
                return false;

            _context.Inquilinos.Remove(inquilino);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
