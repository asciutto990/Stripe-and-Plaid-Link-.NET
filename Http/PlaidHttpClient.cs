using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plaid.Http.Exceptions;

namespace Plaid.Http
{
    internal class PlaidHttpClient : HttpClient
    {
        private readonly Uri _tartanUrl = new Uri("https://tartan.plaid.com");
        private readonly Uri _productionUrl = new Uri("https://api.plaid.com");

        public PlaidHttpClient(bool developerMode = false)
        {
            this.BaseAddress = developerMode ? _tartanUrl : _productionUrl;
        }

        public new Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            var uri = new Uri(BaseAddress + endpoint);
            return base.GetAsync(uri);
        }

        public async Task<TOutput> PostAsync<TInput, TOutput>(string endpoint, TInput input)
        {
            var uri = new Uri(BaseAddress + endpoint);
            var requestContent = PlaidHttpRequestFactory<TInput>.BuildPostRequest(input);
            var response = await base.PostAsync(uri, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<TOutput>(content);
            }
            catch(HttpRequestException)
            {
                var errorResponse = JsonConvert.DeserializeObject<PlaidErrorResponse>(content);
                throw new PlaidException(errorResponse);
            }
        }
    }
}
