using Newtonsoft.Json;
using OsuSharp.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents an extended beatmapset, as returned by the osu! API v2.
/// This object inherits from <see cref="BeatmapSet"/> and contains additional properties.
/// 
/// https://osu.ppy.sh/docs/index.html#beatmapsetextended
/// </summary>
public class BeatmapSetExtended : BeatmapSet
{
  /// <summary>
  /// Info about the availability of this beatmapset.
  /// </summary>
  [JsonProperty("availability")]
  public Availability Availability { get; private set; } = default!;

  /// <summary>
  /// The beats per minute (BPM) of this beatmapset.
  /// </summary>
  [JsonProperty("bpm")]
  public float BPM { get; private set; }

  /// <summary>
  /// Bool whether this beatmapset can be hyped.
  /// </summary>
  [JsonProperty("can_be_hyped")]
  public bool CanBeHyped { get; private set; }

  /// <summary>
  /// The datetime at which this beatmapset was deleted. This will be null if the beatmapset has not been deleted.
  /// </summary>
  [JsonProperty("deleted_at")]
  public DateTimeOffset? DeletedAt { get; private set; }

  /// <summary>
  /// Bool whether discussion on this beatmapset is locked.
  /// </summary>
  [JsonProperty("discussion_locked")]
  public bool IsDiscussionLocked { get; private set; }

  /// <summary>
  /// To be documented
  /// </summary>
  [JsonProperty("is_scoreable")]
  public bool IsScoreable { get; private set; }

  /// <summary>
  /// The datetime at which this beatmapset was last updated.
  /// </summary>
  [JsonProperty("last_updated")]
  public DateTimeOffset LastUpdated { get; private set; }

  /// <summary>
  /// The URL to the legency thread of this beatmapset.
  /// </summary>
  [JsonProperty("legacy_thread_url")]
  public string? LegacyThreadUrl { get; private set; }

  /// <summary>
  /// Info about the nomination progress of this beatmapset.
  /// </summary>
  [JsonProperty("nominations_summary")]
  public NominationsSummary Nominations { get; private set; } = default!;

  /// <summary>
  /// The datetime at which this beatmapset was ranked, qualified, approved or loved. This will be null if the beatmapset has none of these statuses.
  /// </summary>
  [JsonProperty("ranked_date")]
  public DateTimeOffset? RankedDate { get; private set; }

  /// <summary>
  /// Bool whether this beatmapset has a storyboard.
  /// </summary>
  [JsonProperty("storyboard")]
  public bool HasStoryboard { get; private set; }

  /// <summary>
  /// The datetime at which this beatmapset was submitted to the osu! servers.
  /// </summary>
  [JsonProperty("submitted_date")]
  public DateTimeOffset? SubmittedDate { get; private set; }

  /// <summary>
  /// The tags of this beatmapset, used for searching.
  /// </summary>
  [JsonProperty("tags")]
  [JsonConverter(typeof(StringArrayConverter))]
  public string[] Tags { get; private set; } = default!;

  /// <summary>
  /// The beatmaps belonging to this beatmapset. This may be null.
  /// </summary>
  [JsonProperty("beatmaps")]
  public new BeatmapExtended[]? Beatmaps { get; private set; }
}
