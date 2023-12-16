using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Beatmaps;

/// <summary>
/// Represents the voters of a discussion on a beatmapset.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-discussion-json.ts"/>
/// </summary>
public class DiscussionVoters
{
  /// <summary>
  /// TODO: What is this? User ids of the users thet voted?
  /// </summary>
  [JsonProperty("down")]
  public int[] Down { get; private set; } = default!;

  /// <summary>
  /// TODO: What is this? User ids of the users thet voted?
  /// </summary>
  [JsonProperty("up")]
  public int[] Up { get; private set; } = default!;
}
