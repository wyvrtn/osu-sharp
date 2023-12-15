using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OsuSharp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents a beatmapset, as returned by the osu! API v2.
/// 
/// https://osu.ppy.sh/docs/index.html#beatmapset
/// </summary>
public class BeatmapSet
{
    /// <summary>
    /// The artist of the song this beatmapset is made for.
    /// </summary>
    [JsonProperty("artist")]
    public string Artist { get; private set; } = default!;

    /// <summary>
    /// The unicode representation of the artist of the song this beatmapset is made for.
    /// </summary>
    [JsonProperty("artist_unicode")]
    public string ArtistUnicode { get; private set; } = default!;

    /// <summary>
    /// The URLs for the cover texture assets of this beatmapset.
    /// </summary>
    public Covers Covers { get; private set; } = default!;

    /// <summary>
    /// The name of the creator of this beatmapset.
    /// </summary>
    [JsonProperty("creator")]
    public string Creator { get; private set; } = default!;

    /// <summary>
    /// The amount of favourites this beatmapset has.
    /// </summary>
    [JsonProperty("favorite_count")]
    public int FavouriteCount { get; private set; } = default!;

    /// <summary>
    /// Info about the hype progress of this beatmapset.
    /// </summary>
    [JsonProperty("hype")]
    public Hypes Hypes { get; private set; } = default!;

    /// <summary>
    /// The ID of this beatmapset.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; private set; } = default!;

    /// <summary>
    /// Bool whether the beatmapset contains explicit content.
    /// </summary>
    public bool IsNsfw { get; private set; } = default!;

    /// <summary>
    /// The global milliseconds offset for all the beatmaps in this beatmapset.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; private set; } = default!;

    /// <summary>
    /// The amount of plays this beatmapset has.
    /// </summary>
    [JsonProperty("play_count")]
    public int PlayCount { get; private set; } = default!;

    /// <summary>
    /// The URL for the audio preview of this beatmapset.
    /// </summary>
    [JsonProperty("preview_url")]
    public string PreviewUrl { get; private set; } = default!;

    /// <summary>
    /// The source of the song this beatmapset is made for.
    /// </summary>
    [JsonProperty("source")]
    public string Source { get; private set; } = default!;

    /// <summary>
    /// Bool whether this beatmapset is spotlighted.
    /// </summary>
    [JsonProperty("spotlight")]
    public bool IsSpotlighted { get; private set; } = default!;

    /// <summary>
    /// The ranked status of this beatmapset.
    /// </summary>
    [JsonProperty("status")]
    [JsonConverter(typeof(StringEnumConverter))]
    public RankedStatus Status { get; private set; } = default!;

    /// <summary>
    /// The title of the song this beatmapset is made for.
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; private set; } = default!;

    /// <summary>
    /// The unicode representation of the title of the song this beatmapset is made for.
    /// </summary>
    [JsonProperty("title_unicode")]
    public string TitleUnicode { get; private set; } = default!;

    /// <summary>
    /// The user ID of the creator of this beatmapset.
    /// </summary>
    [JsonProperty("user_id")]
    public int UserId { get; private set; } = default!;

    /// <summary>
    /// Bool whether this beatmapset contains a background video.
    /// </summary>
    [JsonProperty("video")]
    public bool HasVideo { get; private set; } = default!;

    /// <summary>
    /// The beatmaps belonging to this beatmapset. This may be null.
    /// </summary>
    [JsonProperty("beatmaps")]
    public Beatmap[]? Beatmaps { get; private set; }
}
