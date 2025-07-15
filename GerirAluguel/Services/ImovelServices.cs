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

      
        public async Task<IEnumerable<ImovelDto>> GetAll()
        {
            var Imovel = await _context.Imovel.ToListAsync();
            
            return Imovel.Select(im => new ImovelDto
            {
                ImovelId = im.ImovelId, 
                DescricaoImovel = im.DescricaoImovel,
                Endereco = im.Endereco,
                ValorAluguel = im.ValorAluguel,
                Status = im.Status
            });
        }

 
        public async Task<ImovelDto?> GetOneById(int id)
        {
           
            var imovel = await _context.Imovel.FindAsync(id);
            if (imovel == null)
            {
                return null;
            }
            
            return new ImovelDto
            {
                ImovelId = imovel.ImovelId, 
                DescricaoImovel = imovel.DescricaoImovel,
                Endereco = imovel.Endereco,
                ValorAluguel = imovel.ValorAluguel,
                Status = imovel.Status
            };
        }

        
        public async Task<ImovelDto> Create(ImovelDto dto)
        {
           
            var imovel = new Imovel
            {
               
                DescricaoImovel = dto.DescricaoImovel,
                Endereco = dto.Endereco,
                ValorAluguel = dto.ValorAluguel,
                Status = dto.Status ?? "DISPONÍVEL", 
            };

            _context.Imovel.Add(imovel);
            await _context.SaveChangesAsync();

            
            return new ImovelDto
            {
                ImovelId = imovel.ImovelId,
                DescricaoImovel = imovel.DescricaoImovel,
                Endereco = imovel.Endereco,
                ValorAluguel = imovel.ValorAluguel,
                Status = imovel.Status
            };
        }


        public async Task<ImovelDto?> Update(int id, ImovelDto dto)
        {
            var imovel = await _context.Imovel.FindAsync(id);

            if (imovel == null)
            {
                return null; 
            }

           
            imovel.DescricaoImovel = dto.DescricaoImovel;
            imovel.Endereco = dto.Endereco;
            imovel.ValorAluguel = dto.ValorAluguel;
            imovel.Status = dto.Status ?? imovel.Status; 

            await _context.SaveChangesAsync();

            
            return new ImovelDto
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
            var imovel = await _context.Imovel.FindAsync(id);

            if (imovel == null)
                return false;

            _context.Imovel.Remove(imovel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}