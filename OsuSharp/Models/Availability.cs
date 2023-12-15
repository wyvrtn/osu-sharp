using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models;

/// <summary>
/// Represents the availability of a beatmapset, as returned by the osu! API v2.
/// 
/// https://osu.ppy.sh/docs/index.html#beatmapsetextended
/// </summary>
public class Availability
{
  /// <summary>
  /// Bool whether the beatmapset is available for download or not.
  /// </summary>
  [JsonProperty("download_disabled")]
  public bool IsDownloadDisabled { get; private set; } = default!;

  /// <summary>
  /// More information about the availability of the beatmapset. This may be null.
  /// </summary>
  [JsonProperty("more_information")]
  public string? Information { get; private set; } = default!;
}
