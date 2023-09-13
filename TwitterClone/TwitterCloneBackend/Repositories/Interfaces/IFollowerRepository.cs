using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Repositories.Interfaces
{
    public interface IFollowerRepository
    {
        List<Follow> getFollowers(int id);
        List<Follow> getFollowing(int id);
        bool addFollower(Follow follower);
        bool addFollowing(Follow follower);
        bool removeFollower(Follow follower);
        bool removeFollowing(Follow follower);
    }
}
