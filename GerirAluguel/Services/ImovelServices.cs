using GerirAluguel.Data;
using GerirAluguel.Models;
using GerirAluguel.DTO; 
using Microsoft.EntityFrameworkCore;


namespace GerirAluguel.Services
{
    public class ImovelServices
    {
        private readonly AppDbContext _context;

        public ImovelServices(AppDbContext context)
        {
            _context = context;
        }

      
        public async Task<IEnumerable<ImoveisDto>> GetAll()
        {
            var Imovel = await _context.Imoveis.ToListAsync();
            
            return Imovel.Select(i => new ImoveisDto
            {
                ImovelId = i.ImovelId, 
                DescricaoImovel = i.DescricaoImovel,
                Endereco = i.Endereco,
                ValorAluguel = i.ValorAluguel,
                Status = i.Status
            });
        }

 
        public async Task<ImoveisDto?> GetOneById(int id)
        {
           
            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel == null)
            {
                return null;
            }
            
            return new ImoveisDto
            {
                ImovelId = imovel.ImovelId, 
                DescricaoImovel = imovel.DescricaoImovel,
                Endereco = imovel.Endereco,
                ValorAluguel = imovel.ValorAluguel,
                Status = imovel.Status
            };
        }

        
        public async Task<ImoveisDto> Create(ImoveisDto dto)
        {
           
            var imovel = new Imoveis
            {
               
                DescricaoImovel = dto.DescricaoImovel,
                Endereco = dto.Endereco,
                ValorAluguel = dto.ValorAluguel,
                Status = dto.Status ?? "DISPONÍVEL", 
            };

            _context.Imoveis.Add(imovel);
            await _context.SaveChangesAsync();

            
            return new ImoveisDto
            {
                ImovelId = imovel.ImovelId,
                DescricaoImovel = imovel.DescricaoImovel,
                Endereco = imovel.Endereco,
                ValorAluguel = imovel.ValorAluguel,
                Status = imovel.Status
            };
        }


        public async Task<ImoveisDto?> Update(int id, ImoveisDto dto)
        {
            var imovel = await _context.Imoveis.FindAsync(id);

            if (imovel == null)
            {
                return null; 
            }

           
            imovel.DescricaoImovel = dto.DescricaoImovel;
            imovel.Endereco = dto.Endereco;
            imovel.ValorAluguel = dto.ValorAluguel;
            imovel.Status = dto.Status ?? imovel.Status; 

            await _context.SaveChangesAsync();

            
            return new ImoveisDto
            {
                ImovelId = imovel.ImovelId,
                DescricaoImovel = imovel.DescricaoImovel,
                Endereco = imovel.Endereco,
                ValorAluguel = imovel.ValorAluguel,
                Status = imovel.Status
            };
        }

        
        public async Task<bool> Delete(int id)
        {
            var imovel = await _context.Imoveis.FindAsync(id);

            if (imovel == null)
                return false;

            _context.Imoveis.Remove(imovel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}