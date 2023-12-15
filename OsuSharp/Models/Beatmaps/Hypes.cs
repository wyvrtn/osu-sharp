using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents the hype progress of a beatmapset, as returned by the osu! API v2.
/// 
/// https://osu.ppy.sh/docs/index.html#beatmapsetextended
/// </summary>
public class Hypes
{
    /// <summary>
    /// The amount of hypes this beatmapset currently has.
    /// </summary>
    [JsonProperty("current")]
    public int Current { get; private set; } = default!;

    /// <summary>
    /// The amount of hypes this beatmapset requires to be eligible for ranking.
    /// </summary>
    [JsonProperty("required")]
    public int Required { get; private set; } = default!;
}
