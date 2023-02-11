using AutoMapper;
using WebApplication1.DBContext;
using WebApplication1.Models.DTOs;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repositories
{
    public class CosmeticsRepoImpl : CosmeticRepository
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;

        public CosmeticsRepoImpl(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CosmeticDto> CreateCosmetic(CosmeticDto request)
        {
            if (request != null)
            {
                Guid UUID = Guid.NewGuid();
                Cosmetic Cosmetic = _mapper.Map<Cosmetic>(request);
                Cosmetic.id = UUID.ToString().Replace("-", "");
                _db.cosmetics.Add(Cosmetic);
                await _db.SaveChangesAsync();
                Cosmetic response = await _db.cosmetics.Where(p => p.id == Cosmetic.id).FirstAsync();
                return _mapper.Map<CosmeticDto>(response);
            }
            return null;
        }

        public Task<ResponseDto> DeleteCosmetic(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<CosmeticDto> GetCosmeticById(string id)
        {
            Cosmetic response = await _db.cosmetics.Where(p => p.id == id).FirstOrDefaultAsync();
            return _mapper.Map<CosmeticDto>(response); ;
        }

        public async Task<IEnumerable<CosmeticDto>> GetCosmetics()
        {
            List<Cosmetic> list = await _db.cosmetics.ToListAsync();
            return _mapper.Map<List<CosmeticDto>>(list);
        }

        public async Task<IEnumerable<CosmeticDto>> SearchCosmeticsByBrand(string brand)
        {
            List<Cosmetic> list = await _db.cosmetics.Where(c => c.brand == brand).ToListAsync();
            return _mapper.Map<List<CosmeticDto>>(list);
        }

        public async Task<IEnumerable<CosmeticDto>> SearchCosmeticsByName(string name)
        {
            List<Cosmetic> list = await _db.cosmetics.Where(c => c.name == name).ToListAsync();
            return _mapper.Map<List<CosmeticDto>>(list);
        }

        public async Task<CosmeticDto> UpdateCosmetic(CosmeticDto request, string id)
        {
            if (request != null)
            {
                Cosmetic cosmetic = _mapper.Map<Cosmetic>(request);
                cosmetic.id = id;
                _db.cosmetics.Update(cosmetic);
                await _db.SaveChangesAsync();
                Cosmetic response = await _db.cosmetics.Where(p => p.id == cosmetic.id).FirstAsync();
                return _mapper.Map<CosmeticDto>(response);
            }
            return null;
        }



    }
}
