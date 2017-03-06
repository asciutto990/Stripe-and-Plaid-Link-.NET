using System.Configuration;

namespace Plaid.Inputs.Interfaces
{
    internal interface IContainClientId
    {
        /// <summary>
        /// If ClientId is left empty, it will be populated with your "PlaidClientId" in your AppSettings
        /// </summary>
        string ClientId { get; set; }
    }

    internal static class ClientIdExtensions
    {
        public static IContainClientId SetClientId(this IContainClientId input)
        {
            input.ClientId = string.IsNullOrEmpty(input.ClientId) ? ConfigurationManager.AppSettings["PlaidClientId"] : input.ClientId;
            return input;
        }
    }
}