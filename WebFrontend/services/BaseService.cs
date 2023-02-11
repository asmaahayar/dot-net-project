using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebFrontend.Models;

namespace WebFrontend.services
{
    public class BaseService : IBaseService
    {
        public ResponseDto response { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public ResponseDto responseModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.response = new ResponseDto();
            this.httpClient = httpClient;
        }



        public async Task<T> SendDataAsync<T>(ApiRequest request, string api)
        {
            try
            {
                var client = httpClient.CreateClient(api);
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(request.url);
                client.DefaultRequestHeaders.Clear();
                if (request.data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(request.data),
                        Encoding.UTF8, "application/json");
                }
                if (!string.IsNullOrEmpty(request.accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.accessToken);
                }
                HttpResponseMessage apiResponse = null;
                switch (request.method)
                {
                    case SD.MethodType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.MethodType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.MethodType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;

            }
            catch (Exception e)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    errorMessages = new List<string> { Convert.ToString(e.Message) },
                    success = false

                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
