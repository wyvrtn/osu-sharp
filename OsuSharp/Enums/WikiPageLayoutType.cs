using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the layout types of a wiki page.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/Wiki/Page.php"/>
/// </summary>
public enum WikiPageLayoutType
{
  /// <summary>
  /// The wiki page is in markdown format.
  /// </summary>
  [Description("markdown_page")]
  Markdown,

  /// <summary>
  /// The wiki page is a main page.
  /// </summary>
  [Description("main_page")]
  Main
}
