using Newtonsoft.Json;
using OsuSharp.Enums;
using OsuSharp.Models.Forum;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#forum

  /// <summary>
  /// Returns an asynchronous enumerable for all posts of a forum topic with the specified filters, allowing to lazily
  /// enumerate through all posts, performing further pagination requests as necessary.<br/>
  /// If a pagination request failed, an <see cref="OsuApiException"/> is thrown.
  /// <br/><br/>
  /// API notes:<br/>
  /// This endpoint does not provide support for targetting a specific page directly per API design.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-topic-and-posts"/>
  /// </summary>
  /// <param name="topicId">The ID of the forum topic.</param>
  /// <param name="sort">The sorting option for the posts.</param>
  /// <param name="limit">The maximum amount of posts to be returned. Defaults to 20, supports up to 50.</param>
  /// <param name="start">The ID of the first post to return. Only applies if <paramref name="sort"/> is <see cref="PostSort.IDAscending"/>.</param>
  /// <param name="end">The ID of the last post to return. Only applies if <paramref name="sort"/> is <see cref="PostSort.IDDescending"/>.</param>
  /// <returns>An asynchronous enumerable for lazily enumerating over the posts of tthe forum topic.</returns>
  private async IAsyncEnumerable<ForumPost> GetForumPostsAsync(int topicId, PostSort sort = PostSort.IDAscending, int limit = 20,
                                                              int? start = null, int? end = null)
  {
    throw new NotImplementedException("This endpoint is unavailable for client credential flows.");

    // Always remember the cursor for the next request. Also remember the forum topic, as it is identical for all requests.
    string? cursor = null;
    ForumTopic topic = null!;

    // Keep requesting until there are no more pages, and yield return the forum posts to asynchronously enumerate over them.
    do
    {
      // Send the request and parse it into a dynamic object to extract the data and cursor.
      dynamic? obj = await GetFromJsonAsync<dynamic>($"forums/topics/{topicId}", new Dictionary<string, object?>()
      {
      { "sort", sort },
      { "limit", limit },
      { "start", start },
      { "end", end }
      });

      // The topic is the same for all requests, so only parse it if not already done.
      if (topic is null)
        topic = JsonConvert.DeserializeObject<ForumTopic>(obj!.topic.ToString());

      // Update the cursor for the next request and yield return the forum posts.
      cursor = obj!.cursor_string.Value;
      foreach (ForumPost post in JsonConvert.DeserializeObject<ForumPost[]>(obj!.posts.ToString()))
      {
        // Inject the forum topic object containing the posts into the forum post objects,
        // as there is no way to return the object from this method directly (async = no out parameter, ...).
        post.Topic = obj!.topic;

        yield return post;
      }
    }
    while (cursor is not null);
  }
}
