using WebFrontend.Models;

namespace WebFrontend.services
{
    public class CosmeticService : BaseService, ICosmetic
    {
        private readonly IHttpClientFactory _clientFactory;
        public CosmeticService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async
            Task<T> CreateCosmetic<T>(CosmeticDto cosmetic)
        {
            return await this.SendDataAsync<T>(new ApiRequest()
            {
                method = SD.MethodType.POST,
                data = cosmetic,
                url = SD.cosmetics + "/api/cosmetics/create"
            }, API.cosmetics);
        }

        public Task<T> DeleteCosmetic<T>(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAllCosmeticsAsync<T>()
        {
            return await this.SendDataAsync<T>(new ApiRequest()
            {
                method = SD.MethodType.GET,
                url = SD.cosmetics + "/api/cosmetics/list"
                //accessToken = accessToken
            }, API.cosmetics);
        }

        public async Task<T> GetCosmeticById<T>(string id)
        {
            return await this.SendDataAsync<T>(new ApiRequest()
            {
                method = SD.MethodType.GET,
                url = SD.cosmetics + "/api/cosmetics/" + id
                //accessToken = accessToken
            }, API.cosmetics);
        }

        public async Task<T> SearchCosmeticsByBrand<T>(string brand)
        {
            return await this.SendDataAsync<T>(new ApiRequest()
            {
                method = SD.MethodType.GET,
                url = SD.cosmetics + "/api/cosmetics/list/brand/" + brand
                //accessToken = accessToken
            }, API.cosmetics);
        }

        public async Task<T> SearchCosmeticsByName<T>(string name)
        {
            return await this.SendDataAsync<T>(new ApiRequest()
            {
                method = SD.MethodType.GET,
                url = SD.cosmetics + "/api/cosmetics/list/name/" + name
                //accessToken = accessToken
            }, API.cosmetics);
        }

        public async Task<T> UpdateCosmeticAsync<T>(string id, CosmeticDto cosmetic)
        {
            return await this.SendDataAsync<T>(new ApiRequest()
            {
                method = SD.MethodType.GET,
                url = SD.cosmetics + "/api/cosmetics/list"
                //accessToken = accessToken
            }, API.cosmetics);
        }
    }
}
