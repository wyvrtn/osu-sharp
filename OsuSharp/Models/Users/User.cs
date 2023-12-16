using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Users;

/// <summary>
/// Represents an osu! user.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#user"/><br/>
/// Sources:<br/>
/// <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-json.ts"/><br/>
/// <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/UserTransformer.php"/>
/// </summary>
public class User
{
  #region Default Attributes

  /// <summary>
  /// The URL for the avatar of this user.
  /// </summary>
  [JsonProperty("avatar_url")]
  public string AvatarUrl { get; private set; } = default!;

  /// <summary>
  /// TODO: what is this?
  /// </summary>
  [JsonProperty("default_group")]
  public string? DefaultGroup { get; private set; }

  /// <summary>
  /// The ID of the user.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// Bool whether the user is active on osu!.
  /// </summary>
  [JsonProperty("is_active")]
  public bool IsActive { get; private set; }

  /// <summary>
  /// Bool whether the user is a bot.
  /// </summary>
  [JsonProperty("is_bot")]
  public bool IsBot { get; private set; }

  /// <summary>
  /// Bool whether the user was deleted.
  /// </summary>
  [JsonProperty("is_deleted")]
  public bool IsDeleted { get; private set; }

  /// <summary>
  /// Bool whether the user is currently online.
  /// </summary>
  [JsonProperty("is_online")]
  public bool IsOnline { get; private set; }

  /// <summary>
  /// Bool whether the user has the osu!supporter status.
  /// </summary>
  [JsonProperty("is_supporter")]
  public bool IsSupporter { get; private set; }

  /// <summary>
  /// The datetime at which the user last visited osu!.
  /// </summary>
  [JsonProperty("last_visit")]
  public DateTimeOffset? LastVisit { get; private set; }

  /// <summary>
  /// Bool whether the user only accepts private messages from friends.
  /// </summary>
  [JsonProperty("pm_friends_only")]
  public bool IsPMFriendsOnly { get; private set; }

  /// <summary>
  /// The hex color of the user's profile. This may be null.
  /// </summary>
  [JsonProperty("profile_colour")]
  public string? ProfileColour { get; private set; }

  /// <summary>
  /// The name of the user.
  /// </summary>
  [JsonProperty("username")]
  public string Username { get; private set; } = default!;

  #endregion

  #region Optional Attributes

  /// <summary>
  /// The account history of this user, containing their restrictions, silences, etc. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("account_history")]
  public AccountHistoryEntry? AccountHistory { get; private set; }

  public ProfileBanner

  /// <summary>
  /// The cover of this user. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("cover")]
  public UserCover? Cover { get; private set; }

  #endregion
}
