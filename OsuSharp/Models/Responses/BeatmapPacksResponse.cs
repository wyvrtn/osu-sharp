using Newtonsoft.Json;
using OsuSharp.Models.Beatmaps;

namespace OsuSharp.Models.Responses;

/// <summary>
/// The response of a /beatmaps/packs request, containing the actual beatmap packs and a cursor string for the next page.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmap-packs"/>
/// </summary>
public class BeatmapPacksResponse
{
  /// <summary>
  /// The beatmap packs included in the response.
  /// </summary>
  [JsonProperty("beatmap_packs")]
  public BeatmapPack[] Packs { get; private set; } = default!;

  /// <summary>
  /// The cursor string for the next page of beatmap packs.
  /// </summary>
  [JsonProperty("cursor_string")]
  public string Cursor { get; private set; } = default!;


}
