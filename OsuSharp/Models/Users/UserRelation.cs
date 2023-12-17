using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OsuSharp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Users;

/// <summary>
/// Represents the relation between two osu! users.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-relation-json.ts"/>
/// </summary>
public class UserRelation
{
  /// <summary>
  /// Bool whether this relation is mutual (invoked from both sides).
  /// </summary>
  [JsonProperty("mutual")]
  public bool Mutual { get; private set; }

  /// <summary>
  /// The type of this relation.
  /// </summary>
  [JsonProperty("type")]
  [JsonConverter(typeof(StringEnumConverter))]
  public UserRelationType Type { get; private set; }

  /// <summary>
  /// The ID of the targetted user.
  /// </summary>
  [JsonProperty("target_id")]
  public int TargetId { get; private set; }
}
