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

        public void DeleteTweet(int id)
        {
            var tweet = _context.Tweets.FirstOrDefault(t => t.Id == id);

            if (tweet != null)
            {
                _context.Tweets.Remove(tweet);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Tweet not found"); // Custom exception for not found scenario
            }
        }

        public IEnumerable<TweetDto> GetTweetsByUser(User user)
        {
            var tweets = _context.Tweets.Where(tweet => tweet.UserId == user.Id).ToList();
            var tweetDtos = tweets.Select(tweet => new TweetDto
            {
                Content = tweet.Content,
            });
            return tweetDtos;

        }

        public void UpdateTweet(int id, TweetDto tweetDto)
        {
            var tweet = _context.Tweets.FirstOrDefault(t => t.Id == id);
            if (tweet != null)
            {
                // Update the tweet properties based on the data in tweetUpdateModel
                tweet.Content = tweetDto.Content; // Example property

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Tweet not found"); // Custom exception for not found scenario
            }
        }
    }
}
