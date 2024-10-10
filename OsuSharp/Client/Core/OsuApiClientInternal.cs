using System.ComponentModel;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OsuSharp.Converters;
using OsuSharp.Models;

namespace OsuSharp.Client.Core;

internal class OsuApiClientInternal
{
  /// <summary>
  /// The JSON serializer settings used by the API client.
  /// </summary>
  private readonly JsonSerializerSettings _jsonSettings = new()
  {
    // The StringArrayConverter is referenced on specific properties instead as not all string[] are parsed this way.
    Converters = [new EventConverter(),  new GradeConverter(), new StringEnumConverter(), new Converters.TimeSpanConverter()]
  };
  
  /// <summary>
  /// The HTTP client used to make requests to the osu! API v2.
  /// </summary>
  private readonly HttpClient _http = new()
  {
    BaseAddress = new Uri("https://osu.ppy.sh/api/v2/")
  };

  internal void AddBearer(string token)
  {
    _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
  }

  internal async Task<T> RequestNewToken<T>(FormUrlEncodedContent contentBody) where T : AccessTokenResponse
  {
    var response = await _http.PostAsync("https://osu.ppy.sh/oauth/token", contentBody);
    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())
        ?? throw new OsuApiException("An error occured while requesting a new access token. (response is null)");
  }

  internal async Task<T?> GetFromJsonAsync<T>(string url, Dictionary<string, object?>? parameters = null, Func<JObject, JToken?>? jsonSelector = null,
                                             HttpMethod? method = null)
  {
    // Default to an empty dictionary if no parameters are specified.
    parameters ??= [];
    // Send the request and validate the response. If 404 is returned, return null.
    HttpResponseMessage response = await _http.SendAsync(new HttpRequestMessage(method ?? HttpMethod.Get, $"{url}?{BuildQueryString(parameters)}"));
    if (response.StatusCode == HttpStatusCode.NotFound)
      return default;
    string responseString = await response.Content.ReadAsStringAsync();
    // If a json selector is specified, parse the JSON in the response into a JObject and select the specified token.
    if (jsonSelector is not null)
    {
      // Parse the JSON, select the token and check whether the token was found. If not, return null.
      JToken? o = jsonSelector(JObject.Parse(responseString));
      if (o is null) return default;
      // Otherwise, try to parse the token into the specified type and return it.
      return o.ToObject<T>();
    }
    // Parse the JSON in the response into the specified type and return it.
    return JsonConvert.DeserializeObject<T?>(responseString, _jsonSettings);
  }

  /// <summary>
  /// Constructs a query parameter string from the specified parameters, where all parameters with a null value are ignored.
  /// </summary>
  /// <param name="parameters">The parameters.</param>
  /// <returns>The query parameter string.</returns>
  internal static string BuildQueryString(Dictionary<string, object?> parameters)
  {
    string str = "";

    // Build the query string from all no-null parameters.
    foreach (KeyValuePair<string, object?> kvp in parameters.Where(x => x.Value is not null))
    {
      str += $"&{HttpUtility.HtmlEncode(kvp.Key)}=";

      // Handle the value->string parsing based on it's type.
      if (kvp.Value is Enum e)
        // If the enum has a description attribute, use it. Otherwise, use the enum value.
        str += e.GetType().GetField(e.ToString())!.GetCustomAttribute<DescriptionAttribute>()?.Description ?? e.ToString();
      else if (kvp.Value is DateTime dt)
        // Use the ISO 8601 format for dates.
        str += dt.ToString("o");
      else
        str += HttpUtility.HtmlEncode(kvp.Value!.ToString());
    }

    // Remove the first '&' character added by the foreach and return the query string.
    return str.TrimStart('&');
  }
}