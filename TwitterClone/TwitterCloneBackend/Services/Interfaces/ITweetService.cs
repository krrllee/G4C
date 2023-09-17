using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Services.Interfaces
{
    public interface ITweetService
    {
        void AddTweet(string username, TweetDto tweet);
        IEnumerable<TweetDto> GetTweetsByUser(string username);
        void DeleteTweet(int id);
        void UpdateTweet(int id, TweetDto tweetDto);
        void AddLike(LikeDto dto,string username);
        void RemoveLike(LikeDto likeDto);
        void AddComment(string username,CommentDto comment);
        void DeleteComment(int id);
        void UpdateComment(string username, UpdateCommDto updateCommDto);

    }
}
