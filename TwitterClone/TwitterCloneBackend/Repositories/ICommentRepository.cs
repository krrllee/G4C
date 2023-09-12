using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Repositories
{
    public interface ICommentRepository
    {
        bool addComment(Comment comment,Tweet tweet);
        List<Comment> getComments(Tweet tweet);
        bool removeComment(Comment comment, Tweet tweet);
        bool updateComment(Comment comment, Tweet tweet);

    }
}
