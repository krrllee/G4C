using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Models;
using TwitterCloneBackend.Repositories.Interfaces;

namespace TwitterCloneBackend.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly TwitterDbContext _context;
        public TweetRepository(TwitterDbContext context)
        {
            _context = context;
        }

        public void AddTweet(Tweet tweet)
        {
          

            _context.Tweets.Add(tweet);
            _context.SaveChanges();
        }
    }
}
