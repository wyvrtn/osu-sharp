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
    if (type == BeatmapType.MostPlayed)
      throw new ArgumentException("Please use GetUserMostPlayedAsync(), as the response type differs.", nameof(type));

    string typeStr = typeof(BeatmapType).GetField(type.ToString())?
      .GetCustomAttribute<DescriptionAttribute>()?.Description ?? throw new InvalidOperationException();
    return (await GetFromJsonAsync<BeatmapSetExtended[]>($"users/{userId}/beatmapsets/{typeStr}", new Dictionary<string, object?>
    {
      { "limit", limit },
      { "offset", offset }
    }))!;
  }

  /// <summary>
  /// Returns the user with the specified ID, optionally in the specified ruleset.<br/>
  /// If no ruleset is specified, the user is returned in their default ruleset.
  /// </summary>
  /// <param name="userId">The user ID.</param>
  /// <param name="ruleset">Optional. The ruleset in which the user is returned.</param>
  /// <returns>The user with the specified ID.</returns>
  public async Task<User?> GetUserAsync(int userId, Ruleset? ruleset = null) => await GetUserInternalAsync(userId.ToString(), ruleset);

  /// <summary>
  /// Returns the user with the specified name, optionally in the specified ruleset.<br/>
  /// If no ruleset is specified, the user is returned in their default ruleset.
  /// </summary>
  /// <param name="username">The user name.</param>
  /// <param name="ruleset">Optional. The ruleset in which the user is returned.</param>
  /// <returns>The user with the specified name.</returns>
  public async Task<User?> GetUserAsync(string username, Ruleset? ruleset = null) => await GetUserInternalAsync($"@{username}", ruleset);

  /// <summary>
  /// Returns the user with the specified identifier, optionally in the specified ruleset.<br/>
  /// If no ruleset is specified, the user is returned in their default ruleset.
  /// </summary>
  /// <param name="userIdentifier">The user identifier (ID or '@'-prefixed username).</param>
  /// <param name="ruleset">Optional. The ruleset in which the user is returned.</param>
  /// <returns>The user with the specified identifier.</returns>
  private async Task<User?> GetUserInternalAsync(string userIdentifier, Ruleset? ruleset)
  {
    string rulesetStr = ruleset is null ? "" : typeof(Ruleset).GetField(ruleset.ToString()!)?
      .GetCustomAttribute<DescriptionAttribute>()?.Description ?? throw new InvalidOperationException();

    return await GetFromJsonAsync<User>($"users/{userIdentifier}/{rulesetStr}");
  }

  /// <summary>
  /// Returns all users with the specified IDs, optionally including the <c>statistics_rulesets.variants</c> attribute.
  /// <br/><br/>
  /// API notes:<br/>
  /// Up to 50 users can be requested at once.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-users"/>
  /// </summary>
  /// <param name="ids">The user IDs.</param>
  /// <param name="include_variant_statistics">Optional. Bool whether the <c>statistics_rulesets.variants</c> attribute is included.</param>
  /// <returns>The users with the specified IDs.</returns>
  public async Task<User[]?> GetUsersAsync(int[] ids, bool include_variant_statistics = false)
  {
    if (ids.Length > 50)
      throw new ArgumentOutOfRangeException("The API only supporst 50 users to be requested at once.", nameof(ids));

    // Build the query parameters with an entry for each specified id. TODO: Actually add statistics_rulesets to the model
    Dictionary<string, object?> parameters = new() { { "include_variant_statistics", include_variant_statistics } };
    foreach (int id in ids)
      parameters.Add($"ids[]", id);

    return (await GetFromJsonAsync<User[]>($"users", parameters, x => x["users"]))!;
  }
}
