using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Enums;

/// <summary>
/// Represents the type of beatmap pack to be retrieved.
/// </summary>
public enum BeatmapPackType
{
  /// <summary>
  /// Targets all beatmap packs. ("S")
  /// </summary>
  Standard,

  /// <summary>
  /// Targets all beatmap packs including featured artists. (F")
  /// </summary>
  Featured,

  /// <summary>
  /// Targets all beatmap packs from tournaments. ("P")
  /// </summary>
  Tournament,

  /// <summary>
  /// Targets all beatmap packs containing loved beatmaps. ("L")
  /// </summary>
  Loved,

  /// <summary>
  /// Targets all beatmap packs from the spotlights. ("R")
  /// </summary>
  Chart,

  /// <summary>
  /// Targets all beatmap packs targetting a theme. ("T")
  /// </summary>
  Theme,

  /// <summary>
  /// Targets all beatmap packs targetting an artist. ("A")
  /// </summary>
  Artist
}
