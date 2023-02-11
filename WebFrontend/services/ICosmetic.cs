using WebFrontend.Models;

namespace WebFrontend.services
{
    public interface ICosmetic : IBaseService
    {

        Task<T> GetAllCosmeticsAsync<T>();
        Task<T> CreateCosmetic<T>(CosmeticDto cosmetic);
        Task<T> UpdateCosmeticAsync<T>(string id, CosmeticDto cosmetic);
        Task<T> SearchCosmeticsByName<T>(string name);
        Task<T> SearchCosmeticsByBrand<T>(string brand);
        Task<T> GetCosmeticById<T>(string id);
        Task<T> DeleteCosmetic<T>(string id);
    }
}
