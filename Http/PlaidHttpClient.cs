using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plaid.Http.Exceptions;

namespace Plaid.Http
{
    internal class PlaidHttpClient : HttpClient
    {
        public PlaidHttpClient(PlaidApiEnvironment config = PlaidApiEnvironment.BaseApi)
        {
            this.BaseAddress = GetBaseApiUrl(config);
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

        public Uri GetBaseApiUrl(PlaidApiEnvironment config)
        {
            switch (config)
            {
                case PlaidApiEnvironment.BaseApi:
                    return new Uri("https://api.plaid.com");
                case PlaidApiEnvironment.Tartan:
                    return new Uri("https://tartan.plaid.com");
                case PlaidApiEnvironment.Sandbox:
                    return new Uri("https://sandbox.plaid.com");
                case PlaidApiEnvironment.Development:
                    return new Uri("https://development.plaid.com");
                case PlaidApiEnvironment.Production:
                    return new Uri("https://production.plaid.com");
                default:
                    throw new ArgumentOutOfRangeException(nameof(config), config, null);
            }
        }
    }
}