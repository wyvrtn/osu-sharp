using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents the amount of times players have failed or exited the beatmap at a certain percentage, representing by each element in the 100-element arrays.
/// 
/// https://osu.ppy.sh/docs/index.html#beatmap-failtimes
/// </summary>
public class Failtimes
{
  /// <summary>
  /// The amount of times players have exited the beatmap at a certain percentage. This may be null.
  /// </summary>
  [JsonProperty("exit")]
  public int[]? Exits { get; private set; }

  /// <summary>
  /// The amount of times players have failed the beatmap at a certain percentage. This may be null.
  /// </summary>
  [JsonProperty("fail")]
  public int[]? Fails { get; private set; }
}
