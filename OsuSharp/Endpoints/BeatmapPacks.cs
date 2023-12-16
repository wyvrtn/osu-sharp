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
  /// Fetches all beatmap packs with the specified type from the osu! API v2 and returns an asynchronous enumerable,
  /// allowing to lazily enumerate through all beatmap packs, performing further pagination requests as necessary.
  /// <br/><br/>
  /// NOTE: This endpoint does not provide support for targetting a specific page directly per API design.<br/>
  /// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-beatmap-packs"/>
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
  /// Gets the beatmap pack with the specified tag from the osu! API v2.
  /// <br/><br/>
  /// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-beatmap-pack"/>
  /// </summary>
  /// <returns>The beatmap pack with the specified tag.</returns>
  public async Task<BeatmapPack> GetBeatmapPackAsync(string tag)
  {
    // Ensure a valid access token.
    await EnsureAccessTokenAsync();

    // Send the request and validate the response.
    BeatmapPack? pack = await GetFromJsonAsync<BeatmapPack>($"beatmaps/packs/{tag}");
    if (pack is null)
      throw new OsuApiException("An error occured while requesting the beatmap packs. (response is null)");

    // Return the beatmap pack.
    return pack;
  }
}