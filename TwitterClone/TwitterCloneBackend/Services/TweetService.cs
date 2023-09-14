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
        public void AddTweet(string username, TweetDto tweet)
        {
            User user = _userRepository.getByUsername(username);
            if(user != null )
            {
                var newTweet = new Tweet 
                {
                  Content = tweet.Content,
                  UserId = user.Id,
                  Created = DateTime.Now,
                };

                _tweetRepository.AddTweet(newTweet);
            }
            else
            {
                throw new Exception("User not found.");
            }
         }    
    }
}
