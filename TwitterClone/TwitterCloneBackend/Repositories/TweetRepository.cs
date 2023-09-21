using Microsoft.EntityFrameworkCore;
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

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void AddLike(Like like)
        {
            _context.Likes.Add(like);
            _context.SaveChanges();
        }

        public void AddTweet(Tweet tweet)
        {


            _context.Tweets.Add(tweet);
            _context.SaveChanges();
        }

        public void DeleteComment(Comment comment)
        {
            _context.Comments.Remove(comment);
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

        public Comment GetCommentById(int id)
        {
            return (_context.Comments.Where(c => c.Id == id).FirstOrDefault());
        }

        public Tweet GetTweetById(int tweetId)
        {
            return _context.Tweets.Where(x => x.Id == tweetId).FirstOrDefault();
        }

        public IEnumerable<TweetDto> GetTweetsByUser(User user)
        {
            var tweets = _context.Tweets.Where(tweet => tweet.UserId == user.Id).ToList();
            var tweetDtos = tweets.Select(tweet => new TweetDto
            {
                Content = tweet.Content,
                UserName= user.Username,
                Created = tweet.Created,
                Name = user.FirstName+" "+user.LastName,
            });
            return tweetDtos;

        }

        public void RemoveLike(LikeDto like)
        {
            var likeToRemove = _context.Likes.FirstOrDefault(l =>l.TweetId==like.TweetId);
            if(likeToRemove != null)
            {
                _context.Likes.Remove(likeToRemove);
                _context.SaveChanges();
            }
        }

        public void UpdateComment(Comment comment)
        {
            _context.ChangeTracker.Clear();
            _context.Comments.Update(comment);
            _context.SaveChanges();
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

        public void UpdateTweetLikes(Tweet tweet)
        {
            _context.Tweets.Update(tweet);
            _context.SaveChanges();
        }
    }
}
