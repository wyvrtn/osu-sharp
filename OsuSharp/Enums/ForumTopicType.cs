using System.ComponentModel;

namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the type of forum topics that exist.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#forum-topic"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/Forum/Topic.php#L87"/>
/// </summary>
public enum ForumTopicType
{
  /// <summary>
  /// The forum topic is a normal topic.
  /// </summary>
  [Description("normal")]
  Normal,

  /// <summary>
  /// The forum topic is stickied to the top of the forum.
  /// </summary>
  [Description("sticky")]
  Sticky,

  /// <summary>
  /// The forum topic is an announcement.
  /// </summary>
  [Description("announcement")]
  Announcement
}
