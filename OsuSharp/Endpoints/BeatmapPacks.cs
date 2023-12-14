using Newtonsoft.Json;
using OsuSharp.Enums;
using OsuSharp.Models;
using OsuSharp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp;

// https://osu.ppy.sh/docs/index.html#beatmap-packs

public partial class OsuApiClient
{
  /// <summary>
  /// Fetches all beatmap packs with the specified type from the osu! API v2 and returns an asynchronous enumerable,
  /// allowing to lazily enumerate through all beatmap packs, performing further pagination requests as necessary.
  /// 
  /// NOTE: This endpoint does not provide support for targetting a specific page directly per API design.
  /// </summary>
  /// <returns>An asynchronous enumerable for lazily enumerating over the beatmap packs.</returns>
  public async IAsyncEnumerable<BeatmapPack> GetBeatmapPacksAsync(BeatmapPackType type = BeatmapPackType.Standard)
  {
    // Always remember the cursor for the next request.
    string? cursor = null;

    // Keep requesting until there are no more pages, and yield return each beatmap pack to asynchronously enumerate over them.
    do
    {
      // Ensure a valid access token.
      await EnsureAccessTokenAsync();

      // Send the request and validate the response.
      BeatmapPacksResponse? bpResponse = await GetFromJsonAsync<BeatmapPacksResponse>($"beatmaps/packs?type={type.ToString().ToLower()}&cursor_string={cursor}");
      if (bpResponse is null)
        throw new OsuApiException("An error occured while requesting the beatmap packs. (response is null).");

      // Yield return each beatmap pack.
      foreach (var pack in bpResponse.Packs)
        yield return pack;

      // Update the cursor for the next request.
      cursor = bpResponse.Cursor;
    }
    while (cursor != null);
  }
}