using Newtonsoft.Json;
using OsuSharp.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Comments;

/// <summary>
/// Represents a bundle of comments and related data.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#commentbundle"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/comment-json.ts"/>
/// </summary>
public class CommentBundle
{
  /// <summary>
  /// The comments contained in this bundle.
  /// </summary>
  [JsonProperty("comments")]
  public Comment[] Comments { get; private set; } = default!;

  /// <summary>
  /// TODO: what is this? whether the api has more to return?
  /// </summary>
  [JsonProperty("has_more")]
  public bool HasMore { get; private set; }

  /// <summary>
  /// TODO: what is this?
  /// </summary>
  [JsonProperty("has_more_id")]
  public int HasMoreId { get; private set; }

  /// <summary>
  /// TODO: what dis
  /// </summary>
  [JsonProperty("included_comments")]
  public Comment[] IncludedComments { get; private set; } = default!;

  /// <summary>
  /// TODO: what dis? just the pinned comments? from included comments and comments? are they exclusively in here or in both?
  /// </summary>
  [JsonProperty("included_comments")]
  public Comment[] PinnedComments { get; private set; } = default!;

  /// <summary>
  /// The sort order this bundle was fetched with.
  /// </summary>
  [JsonProperty("sort")]
  public string Sort { get; private set; } = default!;

  /// <summary>
  /// TODO: what is this? the amount of top level comments in all of osu?
  /// </summary>
  [JsonProperty("top_level_count")]
  public int TopLevelCount { get; private set; }

  /// <summary>
  /// TODO: what is this? The total amount of comments in all of osu? including replies?
  /// </summary>
  [JsonProperty("total")]
  public int TotalCount { get; private set; }

  /// <summary>
  /// TODO: what is this? is it current user related? if so, why is it returned on client credentials auth?
  /// </summary>
  [JsonProperty("user_follow")]
  public bool UserFollow { get; private set; }

  /// <summary>
  /// TODO: what is this? Seems to be empty when getting a simple instance of this object
  /// </summary>
  [JsonProperty("user_votes")]
  public int[] UserVotes { get; private set; } = default!;

  /// <summary>
  /// The users involved in this bundle.
  /// </summary>
  [JsonProperty("users")]
  public User[] Users { get; private set; } = default!;
}
