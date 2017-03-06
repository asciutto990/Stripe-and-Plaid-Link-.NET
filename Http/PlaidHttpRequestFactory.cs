using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Plaid.Inputs;
using Plaid.Inputs.Interfaces;

namespace Plaid.Http
{
    internal static class PlaidHttpRequestFactory<T>
    {
        public static StringContent BuildPostRequest(T input)
        {
            SetClientIdAndSecret(input);
            var serializedObject = JsonConvert.SerializeObject(input);
            var content = new StringContent(serializedObject);
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            return content;
        }

        private static void SetClientIdAndSecret(T input)
        {
            if (input is IContainClientId)
                (input as IContainClientId).SetClientId();

            if (input is IContainSecret)
                (input as IContainSecret).SetSecret();
        }
    }
}
