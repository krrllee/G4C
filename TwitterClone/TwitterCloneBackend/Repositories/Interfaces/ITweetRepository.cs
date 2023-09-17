using System.Runtime.CompilerServices;
using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Repositories.Interfaces
{
    public interface ITweetRepository
    {
        void AddTweet(Tweet tweet);
        public IEnumerable<TweetDto> GetTweetsByUser(User user);
        void DeleteTweet(int id);
        void UpdateTweet(int id, TweetDto tweetDto);
        Tweet GetTweetById(int tweetId);
        void AddLike(Like like);
        void UpdateTweetLikes(Tweet tweet);
        void RemoveLike(LikeDto like);
        void AddComment(Comment comment);
        Comment GetCommentById(int id);
        void DeleteComment(Comment comment);
        void UpdateComment(Comment comment);
    }
}
