using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Scores;

/// <summary>
/// Represents the statistics (hit judgements) of a score, as returned by the osu! API v2.
/// 
/// https://osu.ppy.sh/docs/index.html#score
/// </summary>
public class ScoreStatistics
{
  /// <summary>
  /// The amount of 300s in this score.
  /// </summary>
  [JsonProperty("count_300")]
  public int Count300 { get; internal set; }

  /// <summary>
  /// The amount of 100s in this score.
  /// </summary>
  [JsonProperty("count_100")]
  public int Count100 { get; internal set; }

  /// <summary>
  /// The amount of 50s in this score.
  /// </summary>
  [JsonProperty("count_50")]
  public int Count50 { get; internal set; }

  /// <summary>
  /// The amount of gekis in this score.
  /// </summary>
  [JsonProperty("count_geki")]
  public int CountGeki { get; internal set; }

  /// <summary>
  /// The amount of katus in this score.
  /// </summary>
  [JsonProperty("count_katu")]
  public int CountKatu { get; internal set; }

  /// <summary>
  /// The amount of misses in this score.
  /// </summary>
  [JsonProperty("count_miss")]
  public int Misses { get; internal set; }
}
