using Newtonsoft.Json;
using OsuSharp.Models;
using System.Net.Http.Headers;

namespace OsuSharp;

/// <summary>
/// The API client used to interact with the osu! API v2.
/// </summary>
public class OsuApiClient
{
  /// <summary>
  /// The authorization body used to authenticate to the osu! API v2.
  /// </summary>
  private readonly Dictionary<string, string> _authorizationBody = new Dictionary<string, string>()
  {
    { "client_id", "" },
    { "client_secret", "" },
    { "grant_type", "client_credentials" },
    { "scope", "public" }
  };

  /// <summary>
  /// The expiration date of the current access token stored in the Authorization header of the <see cref="_http"/> client.
  /// </summary>
  private DateTimeOffset _accessTokenExpirationDate = DateTimeOffset.MinValue;

  /// <summary>
  /// The HTTP client used to make requests to the osu! API v2.
  /// </summary>
  private readonly HttpClient _http = new HttpClient();

  /// <summary>
  /// Creates a new instance of the <see cref="OsuApiClient"/> class with the specified client credentials.
  /// </summary>
  /// <param name="clientId">The client ID.</param>
  /// <param name="clientSecret">The client secret.</param>
  public OsuApiClient(int clientId, string clientSecret) : this(clientId.ToString(), clientSecret) { }

  /// <summary>
  /// Creates a new instance of the <see cref="OsuApiClient"/> class with the specified client credentials.
  /// </summary>
  /// <param name="clientId">The client ID.</param>
  /// <param name="clientSecret">The client secret.</param>
  public OsuApiClient(string clientId, string clientSecret)
  {
    _authorizationBody["client_id"] = clientId;
    _authorizationBody["client_secret"] = clientSecret;
  }

  /// <summary>
  /// Ensures that the current access token is valid, and if not, requests a new one.
  /// This method may also be used to improve the performance of the first request.
  /// </summary>
  public async Task EnsureAccessTokenAsync()
  {
    // If the current access token is valid, return.
    if (_accessTokenExpirationDate > DateTimeOffset.UtcNow)
      return;

    try
    {
      // Request a new access token and parse the response into a JSON object.
      var response = await _http.PostAsync("https://osu.ppy.sh/oauth/token", new FormUrlEncodedContent(_authorizationBody));
      AccessTokenResponse? atResponse = JsonConvert.DeserializeObject< AccessTokenResponse>(await response.Content.ReadAsStringAsync());

      // Validate the parsed JSON object.
      if (atResponse is null)
        throw new OsuApiException("An error occured while requesting a new access token.");
      if (atResponse.AccessToken is null || atResponse.ExpiresIn is null)
        throw new OsuApiException($"An error occured while requesting a new access token: {atResponse.ErrorDescription} ({atResponse.ErrorCode}).");

      // Set the access token in the Authorization header of the HTTP client and update the expiration date.
      _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", atResponse.AccessToken);
      _accessTokenExpirationDate = DateTimeOffset.UtcNow.AddSeconds(atResponse.ExpiresIn.Value - 30 /* Leniency */);
    }
    catch (Exception ex)
    {
      throw new OsuApiException("An error occured while requesting a new access token.", ex);
    }
  }
}