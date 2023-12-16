using Newtonsoft.Json;
using OsuSharp.Models.Scores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents a user score on a beatmap, including the position of the score on the map leaderboards.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapuserscore"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/beatmapsets-show/scoreboard/controller.ts"/>
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
