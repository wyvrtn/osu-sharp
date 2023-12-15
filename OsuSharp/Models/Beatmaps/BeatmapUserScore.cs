using Newtonsoft.Json;
using OsuSharp.Models.Scores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents a user score on a beatmap, including the position of the score on the map leaderboards, as returned by the osu! API v2.
/// 
/// https://osu.ppy.sh/docs/index.html#beatmapuserscore
/// </summary>
public class BeatmapUserScore
{
  /// <summary>
  /// The position of the score on the map leaderboards.
  /// </summary>
  [JsonProperty("position")]
  public int Position { get; private set; }

  /// <summary>
  /// The actual score represented by this <see cref="BeatmapUserScore"/> object.
  /// </summary>
  [JsonProperty("score")]
  public Score Score { get; private set; } = default!;
}
