using System.Reflection.Metadata.Ecma335;
using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Models;
using TwitterCloneBackend.Repositories;
using TwitterCloneBackend.Repositories.Interfaces;
using TwitterCloneBackend.Services.Interfaces;

namespace TwitterCloneBackend.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly IUserRepository _userRepository;

        public TweetService(ITweetRepository tweetRepository, IUserRepository userRepository,IUserRepository userRepository1)
        {
            _tweetRepository = tweetRepository;
            _userRepository = userRepository1;
        }

        public void AddComment(string username, CommentDto comment)
        {
            User user = _userRepository.getByUsername(username);
            if (user != null)
            {
                var comm = new Comment
                {     
                    TweetId = comment.TweetId,
                    Content = comment.Content,
                    CommentedAt = DateTime.Now,
                    UserId = user.Id,
                };

                _tweetRepository.AddComment(comm);
            }
        }

        public void AddLike(LikeDto dto,string username)
        {
            var tweetId = dto.TweetId;
            if(tweetId != null)
            {
                var user = _userRepository.getByUsername(username);
                var tweet = _tweetRepository.GetTweetById(tweetId);
                

                if (tweet != null)
                {
                    var like = new Like
                    {
                        //Id = id,
                        TweetId = tweetId,
                        UserId = user.Id,
                    };

                    _tweetRepository.AddLike(like);
                    tweet.LikesCount++; // Assuming LikesCount is an integer property
                    _tweetRepository.UpdateTweetLikes(tweet);

                }
            }
           

        }

        public void AddTweet(string username, AddTweetDto tweet)
        {
            User user = _userRepository.getByUsername(username);
            if(user != null )
            {
                var newTweet = new Tweet
                {
                    Content = tweet.Content,
                    UserId = user.Id,
                    UserName = user.Username,
                    Created = DateTime.Now,
                };

                _tweetRepository.AddTweet(newTweet);
            }
            else
            {
                throw new Exception("User not found.");
            }
         }

        public void DeleteComment(int id)
        {
            var comm = _tweetRepository.GetCommentById(id);
            _tweetRepository.DeleteComment(comm);
        }

        public void DeleteTweet(int id)
        {
            _tweetRepository.DeleteTweet(id);

        }

        public IEnumerable<TweetDto> GetTweetsByUser(string username)
        {
            var user = _userRepository.getByUsername(username);
            if(user != null)
            {
                var tweets = _tweetRepository.GetTweetsByUser(user);
                
                return tweets;
            }
            return null;
            
        }

        public void RemoveLike(LikeDto dto)
        {
            _tweetRepository.RemoveLike(dto);
            var tweet = _tweetRepository.GetTweetById(dto.TweetId);
            tweet.LikesCount--; 
            _tweetRepository.UpdateTweetLikes(tweet);

        }

        public void UpdateComment(string username, UpdateCommDto updateCommDto)
        {
            var comment = _tweetRepository.GetCommentById(updateCommDto.Id);
            var user = _userRepository.getByUsername(username);
            

            if(comment.UserId == user.Id)
            {
                var comm = new Comment
                {
                    Id = comment.Id,
                    Content = updateCommDto.Content,
                    UserId = user.Id,
                    TweetId = updateCommDto.TweetId
                };
                _tweetRepository.UpdateComment(comm);
            }
           
        }

        public void UpdateTweet(int id, TweetDto tweetDto)
        {
            _tweetRepository.UpdateTweet(id, tweetDto);
        }
    }
}
