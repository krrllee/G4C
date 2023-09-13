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
        public bool addTweet(Tweet tweet)
        {
            try
            {
                _context.Tweets.Add(tweet);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Tweet> findAll()
        {
            return _context.Tweets.ToList();
        }

        public Tweet getById(int id)
        {
            try
            {
                
                var result = _context.Tweets.FirstOrDefault(x => x.Id == id);
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public bool removeTweet(int id)
        {
            var res = _context.Tweets.FirstOrDefault(u=>u.Id==id);
            if(res != null)
            {
                _context.Tweets.Remove(res);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool updateTweet(Tweet tweet)
        {
            try
            {
                var res = _context.Tweets.Update(tweet);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}
