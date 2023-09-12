using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly TwitterDbContext _context;
        public CommentRepository(TwitterDbContext context)
        {
            _context = context;
        }
        public bool addComment(Comment comment, Tweet tweet)
        {
            try
            {
                _context.Comments.Add(comment);
                tweet.Comments.Add(comment);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public List<Comment> getComments(Tweet tweet)
        {
            return tweet.Comments.ToList();
        }

        public bool removeComment(Comment comment, Tweet tweet)
        {
            try
            {
                _context.Comments.Remove(comment);
                tweet.Comments.Remove(comment);
                _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool updateComment(Comment comment, Tweet tweet)
        {
            try
            {
                tweet.Comments.Remove(comment);
                _context.Comments.Update(comment);
                tweet.Comments.Add(comment);
                _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}
