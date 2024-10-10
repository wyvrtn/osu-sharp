using Newtonsoft.Json.Linq;
using OsuSharp.Client.Authorization;
using OsuSharp.Client.Core;
using OsuSharp.Models;
using System.Net.Http.Headers;

namespace OsuSharp;

/// <summary>
/// The API client used to interact with the osu! API v2.
/// </summary>
public partial class OsuApiClient
{
  private readonly OsuApiClientInternal _svc = new();
  private readonly AbstractApiAuthorization _auth;

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
    _auth = new ClientCredentialsGrant(clientId, clientSecret);
  }

  /// <summary>
  /// Ensures that the current access token is valid, and if not, requests a new one.
  /// This method may be used to improve the performance of the first request, and is
  /// automatically being called by every method that requires an access token.
  /// </summary>
  public async Task EnsureAccessTokenAsync()
  {
    // If the current access token is valid, return.
    if (_auth.ExpirationDate > DateTimeOffset.UtcNow)
      return;
    if (_auth.Status is not true) {
      await _auth.AuthorizationFlowAsync(_svc);
    } else {
      await _auth.RefreshAccessToken(_svc);
    }
  }

  /// <summary>
  /// Sends a GET request to the specified URL and parses the JSON in the response into the specified type.<br/>
  /// If the requested resource could not be found, null is returned. If the request fails otherwise, an <see cref="OsuApiException"/> is thrown.<br/>
  /// </summary>
  /// <typeparam name="T">The type to parse the JSON in the response into.</typeparam>
  /// <param name="url">The request URL.</param>
  /// <param name="parameters">Optional. The query parameters of the URL. All parameters with a null value are ignored.</param>
  /// <param name="jsonSelector">Optional. A selector for the base JSON, allowing to parse a sub-property of the JSON object.</param>
  /// <param name="method">Optional. The HTTP Method used. This defaults to GET, and only exists for niche API inconsistencies.</param>
  /// <returns>The parsed response or null, if the requested resource could not be found.</returns>
  private async Task<T?> GetFromJsonAsync<T>(string url, Dictionary<string, object?>? parameters = null, Func<JObject, JToken?>? jsonSelector = null,
                                             HttpMethod? method = null)
  {
    // Ensure a valid access token.
    await EnsureAccessTokenAsync();
    try
    {
      return await _svc.GetFromJsonAsync<T>(url, parameters, jsonSelector, method);
    }
    catch (Exception ex)
    {
      throw new OsuApiException($"An error occured while sending a GET request to {url} and parsing the response as `{typeof(T).Name}`.", ex);
    }
  }

  /// <summary>
  /// Constructs a query parameter string from the specified parameters, where all parameters with a null value are ignored.
  /// </summary>
  /// <param name="parameters">The parameters.</param>
  /// <returns>The query parameter string.</returns>
  private static string BuildQueryString(Dictionary<string, object?> parameters)
  {
    return OsuApiClientInternal.BuildQueryString(parameters);
  }
}