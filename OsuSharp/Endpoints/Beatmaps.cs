using Newtonsoft.Json;
using OsuSharp.Enums;
using OsuSharp.Models.Beatmaps;
using OsuSharp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#beatmaps

  /// <summary>
  /// Looksup the beatmap with the specified MD5 checksum from the osu! API v2.
  /// If the beatmap is not found, null is returned.
  /// <br/><br/>
  /// API docs: <a href="https://osu.ppy.sh/docs/index.html#lookup-beatmap"/>
  /// </summary>
  /// <param name="checksum">The MD5 checksum of the beatmap.</param>
  /// <returns>The beatmap or null, if no beatmap was found.</returns>
  public async Task<Beatmap?> LookupBeatmapChecksum(string checksum) => await LookupBeatmapInternal($"checksum={HttpUtility.UrlEncode(checksum)}");

  /// <summary>
  /// Looksup the beatmap with the specified filename from the osu! API v2.
  /// If the beatmap is not found, null is returned.
  /// <br/><br/>
  /// API docs: <a href="https://osu.ppy.sh/docs/index.html#lookup-beatmap"/>
  /// </summary>
  /// <param name="checksum">The filename of the beatmap.</param>
  /// <returns>The beatmap or null, if no beatmap was found.</returns>
  public async Task<Beatmap?> LookupBeatmapFilename(string filename) => await LookupBeatmapInternal($"filename={HttpUtility.UrlEncode(filename)}");

  /// <summary>
  /// Looksup the beatmap with the specified ID from the osu! API v2.
  /// If the beatmap is not found, null is returned.
  /// <br/><br/>
  /// API docs: <a href="https://osu.ppy.sh/docs/index.html#lookup-beatmap"/>
  /// </summary>
  /// <param name="beatmapId">The beatmap ID.</param>
  /// <returns>The beatmap or null, if no beatmap was found.</returns>
  public async Task<Beatmap?> LookupBeatmapId(int beatmapId) => await LookupBeatmapInternal($"id={beatmapId}");

  /// <summary>
  /// Looksup the beatmap with the specified query parameter from the osu! API v2.
  /// If the beatmap is not found, null is returned.
  /// <br/><br/>
  /// API docs: <a href="https://osu.ppy.sh/docs/index.html#lookup-beatmap"/>
  /// </summary>
  /// <param name="param">The query parameter.</param>
  /// <returns>The beatmap or null, if no beatmap was found.</returns>
  private async Task<Beatmap?> LookupBeatmapInternal(string param)
  {
    // Send the request and return the beatmap object.
    return await GetFromJsonAsync<Beatmap>($"beatmaps/lookup?{param}");
  }

  /// <summary>
  /// Gets the best user score for the specified mods on the specified beatmap in the specified ruleset from the osu! API v2.
  /// <br/><br/>
  /// NOTE: As per API docs, the mods parameter is not implemented yet.<br/>
  /// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-a-user-beatmap-score"/>
  /// </summary>
  /// <param name="beatmapId">The ID of the beatmap to receive the score of.</param>
  /// <param name="userId">The ID of the user to receive the score of.</param>
  /// <param name="ruleset">Optional. The ruleset in which the score was set.</param>
  /// <param name="mods">Optional. The mods applied to the score.</param>
  /// <returns>The beatmap user score or null, if no score was found.</returns>
  public async Task<BeatmapUserScore?> GetUserBeatmapScore(int beatmapId, int userId, Ruleset? ruleset = null, string? mods = null)
  {
    // Build the query parameters.
    string query = "";
    if (ruleset is not null)
      query += $"&ruleset={ruleset.Value}";
    if (mods is not null)
      query += $"&mods={mods}";

    // Send the request and return the score object.
    return await GetFromJsonAsync<BeatmapUserScore>($"beatmaps/{beatmapId}/scores/users/{userId}?{query}");
  }

  /// <summary>
  /// Gets the beatmap with the specified ID from the osu! API v2.
  /// <br/><br/>
  /// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-beatmap"/>
  /// </summary>
  /// <param name="id">The ID of the beatmap.</param>
  /// <returns>The beatmap or null, if no beatmap was found.</returns>
  public async Task<Beatmap?> GetBeatmap(int id)
  {
    // Send the request and return the beatmap object.
    return await GetFromJsonAsync<Beatmap>($"beatmaps/{id}");
  }
}