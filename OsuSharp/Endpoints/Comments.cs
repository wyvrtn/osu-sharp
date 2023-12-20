using OsuSharp.Enums;
using OsuSharp.Models.Beatmaps;
using OsuSharp.Models.Comments;
using OsuSharp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#comments

  /// <summary>
  /// Gets a comment bundle containing the comment with the specified ID and replies up to 2 levels deep. If the comment was not found, null is returned.
  /// <br/><br/>
  /// </summary>
  /// <param name="commentId">The ID of the comment.</param>
  /// <returns>The comment bundle or null, if the comment was not found.</returns>
  public async Task<CommentBundle?> GetCommentAsync(int commentId)
  {
    return await GetFromJsonAsync<CommentBundle>($"comments/{commentId}");
  }

  public async IAsyncEnumerable<CommentBundle> GetCommentsAsync()
  {
    // Always remember the cursor for the next request.
    Cursor? cursor = null;

    // Keep requesting until there are no more pages, and yield return each beatmap pack to asynchronously enumerate over them.
    do
    {
      // Send the request and validate the response.
      CommentBundle? bundle = await GetFromJsonAsync<CommentBundle>($"comments?cursor[id]={cursor?.Id}&cursor[created_at]={cursor?.CreatedAt.ToString("o")}");
      Console.WriteLine($"comments?cursor[id]={cursor?.Id}&cursor[updated_at]={cursor?.CreatedAt.ToString("o")}");
      if (bundle is null)
        throw new OsuApiException("An error occured while requesting the comment bundle. (bundle is null)");

      // Yield return the bundle.
      yield return bundle;

      // Update the cursor for the next request.
      cursor = bundle.Cursor;
    }
    while (cursor != null);
  }
}
