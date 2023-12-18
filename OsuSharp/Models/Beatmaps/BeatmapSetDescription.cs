using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Contains info about the description of a beatmapset.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapset"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-json.ts"/>
/// </summary>
public class BeatmapSetDescription
{
    /// <summary>
    /// The description of this beatmapset, as a pre-rendered HTML string. This may be null.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; private set; }
}
