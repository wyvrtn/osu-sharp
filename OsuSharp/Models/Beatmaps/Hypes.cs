using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents the hype progress of a beatmapset.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapsetextended"/><br/>
/// Source: <a href=""/>
/// </summary>
public class Hypes
{
  /// <summary>
  /// The amount of hypes this beatmapset currently has.
  /// </summary>
  [JsonProperty("current")]
  public int Current { get; private set; }

  /// <summary>
  /// The amount of hypes this beatmapset requires to be eligible for ranking.
  /// </summary>
  [JsonProperty("required")]
  public int Required { get; private set; }
}
