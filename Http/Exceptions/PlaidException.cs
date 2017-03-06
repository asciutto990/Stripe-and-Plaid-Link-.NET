using System;
using Newtonsoft.Json;

namespace Plaid.Http.Exceptions
{
    public class PlaidException : Exception
    {
        public string Code { get; set; }
        public string Resolve { get; set; }

        public PlaidException(PlaidErrorResponse response) : base(response.Message)
        {
            Code = response.Code;
            Resolve = response.Resolve;
        }
    }

    public class PlaidErrorResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("resolve")]
        public string Resolve { get; set; }
    }
}
