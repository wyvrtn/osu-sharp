using System.ComponentModel;

namespace OsuSharp.Enums;

/// <summary>
/// Represents the type of actions that result in a <see cref="Models.Users.KudosuHistoryEntry"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#kudosuhistory"/><br/>
/// Source: <a href=""/>
/// </summary>
public enum KudosuAction
{
  [Description("give")]
  Give,

  [Description("vote.give")]
  VoteGive,

  [Description("reset")]
  Reset,

  [Description("vote.reset")]
  VoteReset,

  [Description("revoke")]
  Revoke,

  [Description("vote.revoke")]
  VoteRevoke
}
