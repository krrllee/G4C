using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Repositories
{
    public interface INotificationRepository
    {
        Notification getbyId(int id);
        bool addNotification(Notification notification);
        bool removeNotification(int id);


    }
}
