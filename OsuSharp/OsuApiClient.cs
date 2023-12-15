using Newtonsoft.Json;
using OsuSharp.Models;
using OsuSharp.Models.Responses;
using System.Net;
using System.Net.Http.Headers;

namespace OsuSharp;

/// <summary>
/// The API client used to interact with the osu! API v2.
/// </summary>
public partial class OsuApiClient
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
  /// The HTTP client used to make requests to the osu! API v2.
  /// </summary>
  private readonly HttpClient _http = new HttpClient()
  {
    BaseAddress = new Uri("https://osu.ppy.sh/api/v2/")
  };

  /// <summary>
  /// The expiration date of the current access token stored in the Authorization header of the <see cref="_http"/> client.
  /// </summary>
  private DateTimeOffset _accessTokenExpirationDate = DateTimeOffset.MinValue;

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
  /// This method may be used to improve the performance of the first request, and is
  /// automatically being called by every method that requires an access token.
  /// </summary>
  public async Task EnsureAccessTokenAsync()
  {
    // If the current access token is valid, return.
    if (_accessTokenExpirationDate > DateTimeOffset.UtcNow)
      return;

    try
    {
      // Request a new access token and parses the JSON in the response into a response object.
      var response = await _http.PostAsync("https://osu.ppy.sh/oauth/token", new FormUrlEncodedContent(_authorizationBody));
      string json = await response.Content.ReadAsStringAsync();
      AccessTokenResponse? apResponse = JsonConvert.DeserializeObject<AccessTokenResponse>(json);

      // Validate the parsed JSON object.
      if (apResponse is null)
        throw new OsuApiException("An error occured while requesting a new access token. (response is null)");
      if (apResponse.AccessToken is null || apResponse.ExpiresIn is null) // Error fields are most likely specified
        throw new OsuApiException($"An error occured while requesting a new access token: {apResponse.ErrorDescription} ({apResponse.ErrorCode}).");

      // Set the access token in the Authorization header of the HTTP client and update the expiration date.
      _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apResponse.AccessToken);
      _accessTokenExpirationDate = DateTimeOffset.UtcNow.AddSeconds(apResponse.ExpiresIn.Value - 30 /* Leniency */);
    }
    catch (Exception ex) { throw new OsuApiException("An error occured while requesting a new access token.", ex); }
  }

  /// <summary>
  /// Sends a GET request to the specified URL and parses the JSON in the response into the specified type.
  /// </summary>
  /// <typeparam name="T">The type to parse the JSON in the response into.</typeparam>
  /// <param name="url">The request URL.</param>
  /// <returns></returns>
  private async Task<T?> GetFromJsonAsync<T>(string url)
  {
    try
    {
      // Send the request, and validate the response. If 404 is returned, return null.
      var response = await _http.GetAsync(url);
      if (response.StatusCode == HttpStatusCode.NotFound)
        return default;

      // Parse the JSON in the response into the specified type and return it.
      return JsonConvert.DeserializeObject<T?>(await response.Content.ReadAsStringAsync());
    }
    catch (Exception ex)
    {
      throw new OsuApiException($"An error occured while sending a GET request to {url} and parsing the response to type `{typeof(T).Name}.", ex);
    }
  }
}