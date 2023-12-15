using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents the nomination progress of a beatmapset, as returned by the osu! API v2.
/// 
/// https://osu.ppy.sh/docs/index.html#beatmapsetextended
/// </summary>
public class NominationsSummary
{
  /// <summary>
  /// The amount of nominations this beatmapset currently has.
  /// </summary>
  [JsonProperty("current")]
  public int Current { get; private set; }

  /// <summary>
  /// The amount nominations the beatmapset requires to be qualified for ranking.
  /// </summary>
  [JsonProperty("required")]
  public int Required { get; private set; }
}
