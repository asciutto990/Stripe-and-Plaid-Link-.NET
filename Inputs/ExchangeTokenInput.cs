using Newtonsoft.Json;
using Plaid.Inputs.Interfaces;

namespace Plaid.Inputs
{
    public class ExchangeTokenInput : IContainClientId, IContainSecret
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("public_token")]
        public string PublicToken { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }
    }
}
