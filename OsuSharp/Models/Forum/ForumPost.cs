using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Forum;

/// <summary>
/// Represents a forum post in a <see cref="ForumTopic"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#forum-post"/>
/// Source: <a href=""/>
/// </summary>
public class ForumPost
{
  /// <summary>
  /// The datetime at which this forum post was created.
  /// </summary>
  [JsonProperty("created_at")]
  public DateTimeOffset CreatedAt { get; private set; }

  /// <summary>
  /// The datetime at which this forum post was deleted. This will be null if the post was not deleted.
  /// </summary>
  [JsonProperty("deleted_at")]
  public DateTimeOffset? DeletedAt { get; private set; }

  /// <summary>
  /// The datetime at which this forum post was last edited. This will be null if the post has not been edited.
  /// </summary>
  [JsonProperty("edited_at")]
  public DateTimeOffset? EditedAt { get; private set; }

  /// <summary>
  /// The ID of the user that edited this forum post. This will be null if the post has not been edited.
  /// </summary>
  [JsonProperty("edited_by_id")]
  public int? EditedById { get; private set; }

  /// <summary>
  /// The ID of the forum this forum post was created in.
  /// </summary>
  [JsonProperty("forum_id")]
  public int ForumId { get; private set; }

  /// <summary>
  /// The ID of this forum post.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The ID of the topic this forum post was created in.
  /// </summary>
  [JsonProperty("topic_id")]
  public int TopicId { get; private set; }

  /// <summary>
  /// The forum topic this forum post was created in.
  /// </summary>
  public ForumTopic Topic { get; internal set; } = null!;

  /// <summary>
  /// The ID of the user that created this forum post.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; private set; }
}

