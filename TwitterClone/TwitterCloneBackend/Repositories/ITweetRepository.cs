using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Repositories
{
    public interface ITweetRepository
    {
        Tweet getById(int id);
        List<Tweet> findAll();
        bool addTweet(Tweet tweet);
        bool removeTweet(int id);
        bool updateTweet(Tweet tweet);
    }
}
