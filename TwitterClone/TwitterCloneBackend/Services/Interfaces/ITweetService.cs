using TwitterCloneBackend.Dto;

namespace TwitterCloneBackend.Services.Interfaces
{
    public interface ITweetService
    {
        void AddTweet(string username, TweetDto tweet);

    }
}
