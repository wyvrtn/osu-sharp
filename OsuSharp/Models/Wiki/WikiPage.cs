using Newtonsoft.Json;
using OsuSharp.Converters;
using OsuSharp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Models.Wiki;

/// <summary>
/// Represents a wiki page in a specific locale.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#wikipage"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/WikiPageTransformer.php"/>
/// </summary>
public class WikiPage
{
  /// <summary>
  /// The locales this wiki page is available in.
  /// </summary>
  [JsonProperty("available_locales")]
  public string[] AvailableLocales { get; private set; } = default!;

  /// <summary>
  /// The layout type of this wiki page.
  /// </summary>
  [JsonProperty("layout")]
  [JsonConverter(typeof(StringEnumConverter))]
  public WikiPageLayoutType Layout { get; private set; } = default!;

  /// <summary>
  /// The BCP 47 language tag of this wiki page.
  /// </summary>
  [JsonProperty("locale")]
  public string Locale { get; private set; } = default!;

  /// <summary>
  /// The markdown-formatted content of this wiki page.
  /// </summary>
  [JsonProperty("markdown")]
  public string Markdown { get; private set; } = default!;

  /// <summary>
  /// The path of this wiki page.
  /// </summary>
  [JsonProperty("path")]
  public string Path { get; private set; } = default!;

  /// <summary>
  /// The subtitle of this wiki page. This will be null if this wiki page does not have a subtitle.
  /// </summary>
  [JsonProperty("subtitle")]
  public string? SubTitle { get; private set; } = default!;

  /// <summary>
  /// The tags associated with this wiki page.
  /// </summary>
  [JsonProperty("tags")]
  public string[] Tags { get; private set; } = default!;

  /// <summary>
  /// The title of this wiki page.
  /// </summary>
  [JsonProperty("title")]
  public string Title { get; private set; } = default!;
}
