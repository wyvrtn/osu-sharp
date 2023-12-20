using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the different titles an owner of a commentable object can have (e.g. Mapper).
/// </summary>
public enum CommentableOwnerTitle
{
  /// <summary>
  /// Indicates that the owner of the commentable object is it's mapper.
  /// </summary>
  [Description("MAPPER")]
  Mapper
}
