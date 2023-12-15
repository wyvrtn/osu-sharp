using Newtonsoft.Json;
using OsuSharp.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents an extended beatmap, as returned by the osu! API v2.
/// This object inherits from <see cref="Beatmap"/> and contains additional properties.
/// 
/// https://osu.ppy.sh/docs/index.html#beatmapextended
/// </summary>
public class BeatmapExtended : Beatmap
{
    /// <summary>
    /// The overall difficulty (OD) of this beatmap.
    /// </summary>
    [JsonProperty("accuracy")]
    public float OverallDifficulty { get; private set; } = default!;

    /// <summary>
    /// The approach rate (AR) of this beatmap.
    /// </summary>
    [JsonProperty("ar")]
    public float ApproachRate { get; private set; } = default!;

    /// <summary>
    /// The beats per minute (BPM) of this beatmap.
    /// </summary>
    [JsonProperty("bpm")]
    public float BPM { get; private set; } = default!;

    /// <summary>
    /// Bool whether this beatmap is converted from a different ruleset or not. This may be null.
    /// </summary>
    [JsonProperty("convert")]
    public bool? Convert { get; private set; } = default!;

    /// <summary>
    /// The amount of circles in this beatmap.
    /// </summary>
    [JsonProperty("count_circles")]
    public int CountCircles { get; private set; } = default!;

    /// <summary>
    /// The amount of sliders in this beatmap.
    /// </summary>
    [JsonProperty("count_sliders")]
    public int CountSliders { get; private set; } = default!;

    /// <summary>
    /// The amount of spinners in this beatmap.
    /// </summary>
    [JsonProperty("count_spinners")]
    public int CountSpinners { get; private set; } = default!;

    /// <summary>
    /// The circle size (CS) of this beatmap.
    /// </summary>
    [JsonProperty("cs")]
    public float CircleSize { get; private set; } = default!;

    /// <summary>
    /// The datetiem at which this beatmap was deleted. This will be null if the beatmap has not been deleted.
    /// </summary>
    public DateTimeOffset? DeletedAt { get; private set; } = default!;

    /// <summary>
    /// The health drain rate (HP) of this beatmap.
    /// </summary>
    [JsonProperty("drain")]
    public float HealthDrain { get; private set; } = default!;

    /// <summary>
    /// The hit length of this beatmap.
    /// </summary>
    [JsonProperty("hit_length")]
    [JsonConverter(typeof(TimeSpanConverter))]
    public TimeSpan HitLength { get; private set; } = default!;

    /// <summary>
    /// To be documented
    /// </summary>
    [JsonProperty("is_scoreable")]
    public bool IsScoreable { get; private set; } = default!;

    /// <summary>
    /// The datetime at which this beatmap was last updated.
    /// </summary>
    [JsonProperty("last_updated")]
    public DateTimeOffset LastUpdated { get; private set; } = default!;

    /// <summary>
    /// The amount of passes this beatmap has.
    /// </summary>
    [JsonProperty("passcount")]
    public int PassCount { get; private set; } = default!;

    /// <summary>
    /// The amount of plays this beatmap has.
    /// </summary>
    [JsonProperty("playcount")]
    public int PlayCount { get; private set; } = default!;

    /// <summary>
    /// The URL to the beatmap page of this beatmap.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; private set; } = default!;

    /// <summary>
    /// The beatmap set this beatmap belongs to. This property is null if the beatmap does not have an associated beatmap set.
    /// </summary>
    public new BeatmapSetExtended? Set { get; private set; } = default!;
}
