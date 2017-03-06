using System.Threading.Tasks;
using Plaid.Http;
using Plaid.Inputs;
using Plaid.Outputs;

namespace Plaid
{
    public class PlaidApi : IPlaidApi
    {
        private readonly bool _developerMode;

        public PlaidApi(bool developerMode = false)
        {
            _developerMode = developerMode;
        }

        public async Task<ExchangeTokenResponse> ExchangeTokenAsync(ExchangeTokenInput input)
        {
            using (var client = new PlaidHttpClient(_developerMode))
            {
                return await client.PostAsync<ExchangeTokenInput, ExchangeTokenResponse>("exchange_token", input);
            }
        }
    }
}
