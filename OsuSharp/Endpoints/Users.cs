using OsuSharp.Enums;
using OsuSharp.Models.Beatmaps;
using OsuSharp.Models.Users;
using System.ComponentModel;
using System.Reflection;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#users

  /// <summary>
  /// Returns the kudosu history of the user with the specified ID.
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="limit">The amount of history entries to return.</param>
  /// <param name="offset">The offset in the history to return at.</param>
  /// <returns></returns>
  public async Task<KudosuHistoryEntry[]> GetKudosuHistoryAsync(int userId, int? limit = null, int? offset = null)
  {
    return (await GetFromJsonAsync<KudosuHistoryEntry[]>($"users/{userId}/kudosu", new Dictionary<string, object?>
    {
      { "limit", limit },
      { "offset", offset }
    }))!;
  }

  /// <summary>
  /// Returns the most played beatmaps of the specified user.
  /// <br/><br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-beatmaps"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="limit">The amount of beatmaps to limit to.</param>
  /// <param name="offset">The offset for the beatmaps returned.</param>
  /// <returns>The most played beatmaps of the user.</returns>
  public async Task<BeatmapPlaycount[]> GetUserMostPlayedAsync(int userId, int? limit = null, int? offset = null)
  {
    DescriptionAttribute attr = typeof(BeatmapType).GetField(nameof(BeatmapType.MostPlayed))!
      .GetCustomAttribute<DescriptionAttribute>() ?? throw new InvalidOperationException();
    return (await GetFromJsonAsync<BeatmapPlaycount[]>($"users/{userId}/beatmapsets/{attr.Description}", new Dictionary<string, object?>
    {
      { "limit", limit },
      { "offset", offset }
    }))!;
  }

  /// <summary>
  /// Returns all beatmaps of the specified user with the specified type.
  /// <br/><br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-beatmaps"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="limit">The amount of beatmaps to limit to.</param>
  /// <param name="offset">The offset for the beatmaps returned.</param>
  /// <returns>The most played beatmaps of the user.</returns>
  public async Task<BeatmapSetExtended[]> GetUserBeatmapsAsync(int userId, BeatmapType type, int? limit = null, int? offset = null)
  {
    if(type == BeatmapType.MostPlayed)
      throw new ArgumentException("Please use GetUserMostPlayedAsync(), as the response type differs.", nameof(type));

    DescriptionAttribute attr = typeof(BeatmapType).GetField(type.ToString())!
      .GetCustomAttribute<DescriptionAttribute>() ?? throw new InvalidOperationException();
    return (await GetFromJsonAsync<BeatmapSetExtended[]>($"users/{userId}/beatmapsets/{attr.Description}", new Dictionary<string, object?>
    {
      { "limit", limit },
      { "offset", offset }
    }))!;
  }
}
