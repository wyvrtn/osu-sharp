using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Enums;


/// <summary>
/// An enum containing the type of beatmap packs that exist.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmappacktype"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/BeatmapPack.php#L36"/>
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
