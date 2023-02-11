using WebApplication1.Models.DTOs;

namespace WebApplication1.Repositories
{
    public interface CosmeticRepository
    {
        Task<CosmeticDto> GetCosmeticById(string id);
        Task<IEnumerable<CosmeticDto>> GetCosmetics();
        Task<IEnumerable<CosmeticDto>> SearchCosmeticsByName(string name);
        Task<IEnumerable<CosmeticDto>> SearchCosmeticsByBrand(string brand);
        Task<CosmeticDto> CreateCosmetic(CosmeticDto request);
        Task<ResponseDto> DeleteCosmetic(string id);
        Task<CosmeticDto> UpdateCosmetic(CosmeticDto request, string id);
    }
}
