using Newtonsoft.Json;

namespace Plaid.Outputs
{
    public class ExchangeTokenResponse
    {
        [JsonProperty("sandbox")]
        public bool Sandbox { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("stripe_bank_account_token")]
        public string StripeBankAccountToken { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }
    }
}
