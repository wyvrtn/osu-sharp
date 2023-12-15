using Newtonsoft.Json;
using OsuSharp.Models.Beatmaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Responses;

public class BeatmapPacksResponse
{
  /// <summary>
  /// The beatmap packs included in the response.
  /// </summary>
  [JsonProperty("beatmap_packs")]
  public BeatmapPack[] Packs { get; private set; } 

  /// <summary>
  /// The cursor string for the next page of beatmap packs.
  /// </summary>
  [JsonProperty("cursor_string")]
  public string Cursor { get; private set; } 


}
