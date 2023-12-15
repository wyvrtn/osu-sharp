using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OsuSharp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models;

/// <summary>
/// Represents a beatmap, as returned by the osu! API v2.
/// 
/// https://osu.ppy.sh/docs/index.html#beatmap
/// </summary>
public class Beatmap
{
  /// <summary>
  /// The ID of the beatmapset this beatmap belongs to.
  /// </summary>
  [JsonProperty("beatmapset_id")]
  public int SetId { get; private set; } = default!;

  /// <summary>
  /// The difficulty rating of this beatmap.
  /// </summary>
  [JsonProperty("difficulty_rating")]
  public float DifficultyRating { get; private set; } = default!;

  /// <summary>
  /// The ID of this beatmap.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; } = default!;

  /// <summary>
  /// The ruleset this beatmap was made for.
  /// </summary>
  [JsonProperty("mode")]
  [JsonConverter(typeof(StringEnumConverter))]
  public Ruleset Ruleset { get; private set; } = default!;

  /// <summary>
  /// The ranked status of this beatmap.
  /// </summary>
  [JsonProperty("status")]
  [JsonConverter(typeof(StringEnumConverter))]
  public RankedStatus Status { get; private set; } = default!;

  /// <summary>
  /// The total length of this beatmap.
  /// </summary>
  [JsonProperty("total_length")]
  [JsonConverter(typeof(TimeSpanConverter))]
  public TimeSpan TotalLength { get; private set; } = default!;

  /// <summary>
  /// The user ID of the creator of this beatmap.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; private set; } = default!;

  /// <summary>
  /// The difficulty name of this beatmap.
  /// </summary>
  [JsonProperty("version")]
  public string Version { get; private set; } = default!;

  /// <summary>
  /// The beatmap set this beatmap belongs to. This property is null if the beatmap does not have an associated beatmap set.
  /// </summary>
  public BeatmapSet? Set { get; private set; } = default!;

  /// <summary>
  /// The MD5 checksum of the .osu file representing this beatmap. This may be null.
  /// </summary>
  public string? Checksum { get; private set; }

  /// <summary>
  /// The amount of times players have exited of failed the beatmap at a certain percentage. This may be null.
  /// </summary>
  public Failtimes[]? Failtimes { get; private set; }

  /// <summary>
  /// The maximum achievable combo on this beatmap. This may be null.
  /// </summary>
  [JsonProperty("max_combo")]
  public int? MaxCombo { get; private set; } = default!;
}
