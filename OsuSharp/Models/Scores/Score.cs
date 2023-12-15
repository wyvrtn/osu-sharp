using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Scores;

/// <summary>
/// Represents a score, as returned by the osu! API v2.
/// 
/// https://osu.ppy.sh/docs/index.html#score
/// </summary>
public class Score
{
  /// <summary>
  /// The ID of the score.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; internal set; }

  /// <summary>
  /// The ID of the best score the player of this score achieved on the beatmap.
  /// </summary>
  [JsonProperty("best_id")]
  public int BestId { get; internal set; }

  /// <summary>
  /// The ID of the player of this score.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; internal set; }

  /// <summary>
  /// The accuracy of the score.
  /// </summary>
  [JsonProperty("accuracy")]
  public float Accuracy { get; internal set; }

  /// <summary>
  /// The mods used for this score.
  /// </summary>
  [JsonProperty("mods")]
  public string[] Mods { get; internal set; } = default!;

  /// <summary>
  /// The total score points for this score.
  /// </summary>
  [JsonProperty("score")]
  public int TotalScore { get; internal set; }

  /// <summary>
  /// The maximum combo achieved in this score.
  /// </summary>
  [JsonProperty("max_combo")]
  public int MaxCombo { get; internal set; }

  /// <summary>
  /// Bool whether the score has a perfect combo.
  /// </summary>
  [JsonProperty("perfect")]
  public bool IsPerfect { get; internal set; }
}
