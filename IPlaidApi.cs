using System.Threading.Tasks;
using Plaid.Inputs;
using Plaid.Outputs;

namespace Plaid
{
    public interface IPlaidApi
    {
        Task<ExchangeTokenResponse> ExchangeTokenAsync(ExchangeTokenInput input);
    }
}