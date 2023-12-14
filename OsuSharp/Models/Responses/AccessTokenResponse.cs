using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Responses;

/// <summary>
/// Represents the response of an access token request on the osu! API v2.
/// </summary>
internal class AccessTokenResponse
{
    /// <summary>
    /// The successfully requested access token.
    /// </summary>
    [JsonProperty("access_token")]
    public string? AccessToken { get; private set; }

    /// <summary>
    /// Amount of seconds until the access token expires.
    /// </summary>
    [JsonProperty("expires_in")]
    public int? ExpiresIn { get; private set; }

    /// <summary>
    /// The error code, if any.
    /// </summary>
    [JsonProperty("error")]
    public string? ErrorCode { get; private set; }

    /// <summary>
    /// The error description, if any.
    /// </summary>
    [JsonProperty("error_description")]
    public string? ErrorDescription { get; private set; }
}
