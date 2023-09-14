using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Repositories.Interfaces
{
    public interface ITweetRepository
    {
        void AddTweet(Tweet tweet);
        public IEnumerable<TweetDto> GetTweetsByUser(User user);
        void DeleteTweet(int id);
    }
}
