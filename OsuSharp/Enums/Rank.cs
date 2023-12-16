using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the ranks a score can have. (XH, SH, X, S, A, B, C, D)
/// <br/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/rank.ts"/>
/// </summary>
public enum Rank
{
  /// <summary>
  /// 100% accuracy, Hidden and/or Flashlight mod.
  /// </summary>
  XH,

  /// <summary>
  /// 100% accuracy, any mod.
  /// </summary>
  X,

  /// <summary>
  /// S-rank accuracy, Hidden and/or Flashlight mod.
  /// </summary>
  SH,

  /// <summary>
  /// S-rank accuracy, any mod.
  /// </summary>
  S,

  /// <summary>
  /// A-rank accuracy, any mod.
  /// </summary>
  A,

  /// <summary>
  /// B-rank accuracy, any mod.
  /// </summary>
  B,

  /// <summary>
  /// C-rank accuracy, any mod.
  /// </summary>
  C,

  /// <summary>
  /// D-rank accuracy, any mod.
  /// </summary>
  D
}
