# Stripe and Plaid Link for .NET

Stripe and Plaid Link integration documentation:
https://plaid.com/docs/link/stripe/

This is a .NET wrapper for the step - <b>Write server-side handler</b>

<h3>Exchange Token Endpoint</h3>
```csharp
var plaidApi = new PlaidApi();
try
{
    var response = await plaidApi.ExchangeTokenAsync(new ExchangeTokenInput
    {
        PublicToken = "the_public_key",
        AccountId = "the_account_id"
    });
    var bankToken = response.StripeBankAccountToken;
    var accountId = response.AccountId;
    var sandbox = response.Sandbox;
    var accessToken = response.AccessToken;
    ...    
}
catch(PlaidException e)
{
    var errorMessage = e.Message;
    var errorCode = e.Code;
    var resolve = e.Resolve;
    ...
}
```

<h3>For Testing against their Tartan API...</h3>
```csharp
var plaidApi = new PlaidApi(developerMode: true);
```

<h3>Optional Configuration</h3>
You may input these in lieu of setting the Client Id and Secret in the ExchangeTokenInput
```xml
<configuration>
  <appSettings>
    <add key="PlaidClientId" value="my_plaid_client_id"/>
    <add key="PlaidSecret" value="my_plaid_secret_key"/>
    ...
```
