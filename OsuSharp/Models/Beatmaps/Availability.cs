using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents the availability of a beatmapset, as returned by the osu! API v2.
/// 
/// https://osu.ppy.sh/docs/index.html#beatmapsetextended
/// https://github.com/ppy/osu-web/blob/c617d3455315939c019d5bd3a9a88b18b630a28f/resources/js/interfaces/beatmapset-json.ts#L14
/// </summary>
public class Availability
{
  /// <summary>
  /// Bool whether the beatmapset is available for download or not.
  /// </summary>
  [JsonProperty("download_disabled")]
  public bool IsDownloadDisabled { get; private set; }

  /// <summary>
  /// More information about the availability of the beatmapset. This may be null.
  /// </summary>
  [JsonProperty("more_information")]
  public string? Information { get; private set; }
}
