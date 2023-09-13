using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        Notification getbyId(int id);
        bool addNotification(Notification notification);
        bool removeNotification(int id);


    }
}
