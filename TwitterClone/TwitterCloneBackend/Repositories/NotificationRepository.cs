using TwitterCloneBackend.Models;
using TwitterCloneBackend.Repositories.Interfaces;

namespace TwitterCloneBackend.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly TwitterDbContext _context;
        public NotificationRepository(TwitterDbContext context) { 
            _context = context;
        }
        public bool addNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            if(notification != null)
            {
                return true;
            }
            return false;
            
        }

        public Notification getbyId(int id)
        {

            var res = _context.Notifications.FirstOrDefault(n=> n.Id==id);
            _context.SaveChanges();
            return res;

        }

        public bool removeNotification(int id)
        {
                var res = _context.Notifications.FirstOrDefault(x => x.Id == id);
                if(res!=null)
                {
                    _context.Notifications.Remove(res);
                    _context.SaveChanges();
                    return true;
                }
                return false;
        }
    }
}
