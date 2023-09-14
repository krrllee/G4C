using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Services.Interfaces
{
    public interface ITweetService
    {
        void AddTweet(string username, TweetDto tweet);
        IEnumerable<TweetDto> GetTweetsByUser(string username);
        void DeleteTweet(int id);
        void UpdateTweet(int id, TweetDto tweetDto);

    }
}
