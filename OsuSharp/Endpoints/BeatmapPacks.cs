using Newtonsoft.Json;
using OsuSharp.Enums;
using OsuSharp.Models;
using OsuSharp.Models.Beatmaps;
using OsuSharp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#beatmap-packs

  /// <summary>
  /// Fetches all beatmap packs with the specified type and returns an asynchronous enumerable,
  /// allowing to lazily enumerate through all beatmap packs, performing further pagination requests as necessary.<br/>
  /// If a pagination request failed, an <see cref="OsuApiException"/> is thrown.
  /// <br/><br/>
  /// API notes:<br/>
  /// This endpoint does not provide support for targetting a specific page directly per API design.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmap-packs"/>
  /// </summary>
  /// <returns>An asynchronous enumerable for lazily enumerating over the beatmap packs.</returns>
  public async IAsyncEnumerable<BeatmapPack> GetBeatmapPacksAsync(BeatmapPackType type = BeatmapPackType.Standard)
  {
    // Always remember the cursor for the next request.
    string? cursor = null;

    // Keep requesting until there are no more pages, and yield return each beatmap pack to asynchronously enumerate over them.
    do
    {
      // Send the request and validate the response.
      BeatmapPacksResponse? bpResponse = await GetFromJsonAsync<BeatmapPacksResponse>($"beatmaps/packs?type={type.ToString().ToLower()}&cursor_string={cursor}");
      if (bpResponse is null)
        throw new OsuApiException("An error occured while requesting the beatmap packs. (response is null)");

      // Yield return each beatmap pack.
      foreach (var pack in bpResponse.Packs)
        yield return pack;

      // Update the cursor for the next request.
      cursor = bpResponse.Cursor;
    }
    while (cursor != null);
  }

  /// <summary>
  /// Gets the beatmap pack with the specified tag. If the beatmap pack was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmap-pack"/>
  /// </summary>
  /// <returns>The beatmap pack with the specified tag or null, if the beatmap pack was not found.</returns>
  public async Task<BeatmapPack?> GetBeatmapPackAsync(string tag)
  {
    // Send the request and return the beatmap pack object.
    return await GetFromJsonAsync<BeatmapPack>($"beatmaps/packs/{tag}");
  }
}