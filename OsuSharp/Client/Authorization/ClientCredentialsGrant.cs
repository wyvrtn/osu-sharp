using System.Net.Http.Headers;
using OsuSharp.Client.Core;
using OsuSharp.Models;

namespace OsuSharp.Client.Authorization;

public class ClientCredentialsGrant : AbstractApiAuthorization
{

  public ClientCredentialsGrant(int clientId, string clientSecret) : this(clientId.ToString(), clientSecret) { }

  public ClientCredentialsGrant(string clientId, string clientSecret) : base(new()
    {
      { "client_id", "" },
      { "client_secret", "" },
      { "grant_type", "client_credentials" },
      { "scope", "public" }
    })
  {
    _authorizationBody["client_id"] = clientId;
    _authorizationBody["client_secret"] = clientSecret;
    Status = true;
  }

  internal override async Task AuthorizationFlowAsync(OsuApiClientInternal svc)
  {
    try
    {
      // Request a new access token and parses the JSON in the response into a response object.
      AccessTokenResponse apResponse = await svc.RequestNewToken<AccessTokenResponse>(new FormUrlEncodedContent(_authorizationBody));

      // Validate the parsed JSON object.
      if (apResponse.AccessToken is null || apResponse.ExpiresIn is null) // Error fields are most likely specified
        throw new OsuApiException($"An error occured while requesting a new access token: {apResponse.ErrorDescription} ({apResponse.ErrorCode}).");

      // Set the access token in the Authorization header of the HTTP client and update the expiration date.
      svc.AddBearer(AccessToken);
      ExpirationDate = DateTimeOffset.UtcNow.AddSeconds(apResponse.ExpiresIn.Value - 30 /* Leniency */);
    }
    catch (Exception ex) { throw new OsuApiException("An error occured while requesting a new access token.", ex); }
  }

    internal override async Task RefreshAccessToken(OsuApiClientInternal svc) => await AuthorizationFlowAsync(svc);
}