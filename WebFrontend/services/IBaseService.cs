using WebFrontend.Models;

namespace WebFrontend.services
{
    public interface IBaseService
    {
         
        public ResponseDto responseModel { get; set; }
        Task<T> SendDataAsync<T>(ApiRequest request, string api);
    }
}
