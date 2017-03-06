using System.Configuration;

namespace Plaid.Inputs.Interfaces
{
    internal interface IContainSecret
    {
        /// <summary>
        /// If Secret is left empty, it will be populated with your "PlaidSecret" in your AppSettings
        /// </summary>
        string Secret { get; set; }
    }

    internal static class SecretExtensions
    {
        public static IContainSecret SetSecret(this IContainSecret input)
        {
            input.Secret = string.IsNullOrEmpty(input.Secret) ? ConfigurationManager.AppSettings["PlaidSecret"] : input.Secret;
            return input;
        }
    }
}