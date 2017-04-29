using System.Threading.Tasks;
using Plaid.Http;
using Plaid.Inputs;
using Plaid.Outputs;

namespace Plaid
{
    public class PlaidApi : IPlaidApi
    {
        private readonly PlaidApiEnvironment _config;

        public PlaidApi(PlaidApiEnvironment config = PlaidApiEnvironment.BaseApi)
        {
            _config = config;
        }

        public async Task<ExchangeTokenResponse> ExchangeTokenAsync(ExchangeTokenInput input)
        {
            using (var client = new PlaidHttpClient(_config))
            {
                return await client.PostAsync<ExchangeTokenInput, ExchangeTokenResponse>("exchange_token", input);
            }
        }
    }
}
