using OsuSharp.Models.Comments;
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
  /// Gets the comment with the specified ID and replies up to 2 levels deep. If the comment was not found, null is returned.
  /// <br/><br/>
  /// </summary>
  /// <param name="commentId">The ID of the comment.</param>
  /// <returns>The comment or null, if the comment was not found.</returns>
  public async Task<Comment?> GetCommentAsync(int commentId)
  {
    return await GetFromJsonAsync<Comment>($"comments/{commentId}");
  }
}
