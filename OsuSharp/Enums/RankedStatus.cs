using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the rank statuses a beatmap can have.
/// </summary>
public enum RankedStatus
{
  /// <summary>
  /// The beatmap is in the graveyard.
  /// </summary>
  Graveyard = -2,

  /// <summary>
  /// The beatmap is a work in progress.
  /// </summary>
  WIP = -1,

  /// <summary>
  /// The beatmap is pending a rank status evaluation.
  /// </summary>
  Pending = 0,

  /// <summary>
  /// The beatmap is ranked.
  /// </summary>
  Ranked = 1,

  /// <summary>
  /// The beatmap is approved.
  /// </summary>
  Approved = 2,

  /// <summary>
  /// The beatmap is qualified.
  /// </summary>
  Qualified = 3,

  /// <summary>
  /// The beatmap is loved.
  /// </summary>
  Loved = 4
}
