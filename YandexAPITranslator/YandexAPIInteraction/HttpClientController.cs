using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace YandexAPITranslator.YandexAPIInteraction
{
    class HttpClientController
    {
        private static readonly HttpClient _httpClient;

        static HttpClientController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<String> GetContentAsync(string uri)
        {
            try
            {
                String content = await _httpClient.GetStringAsync(uri);
                return content;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
