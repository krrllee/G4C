using TwitterCloneBackend.Models;
using TwitterCloneBackend.Repositories.Interfaces;

namespace TwitterCloneBackend.Repositories
{
    public class FollowerRepository : IFollowerRepository
    {
        private readonly TwitterDbContext _context;
        public FollowerRepository(TwitterDbContext context)
        {
            _context = context;
        }
        User user = new User();

        public bool addFollower(Follow follower)
        {
            if(follower.Follower != null)
            {
                _context.Follows.Add(follower);
                user.Followers.Add(follower);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool addFollowing(Follow follower)
        {
            if(user.Following != null)
            {
                _context.Follows.Add(follower);
                user.Following.Add(follower);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Follow> getFollowers(int id)
        {
            return user.Followers.ToList();
        }

        public List<Follow> getFollowing(int id)
        {
            return user.Following.ToList();
        }

        public bool removeFollower(Follow follower)
        {
            if(follower == null)
                return false;
            user.Followers.Remove(follower);
            return true;
        }

        public bool removeFollowing(Follow follower)
        {
            if(follower != null)
            {
                user.Following.Remove(follower);
                return true;
            }
            return false;
               
        }
    }
}
