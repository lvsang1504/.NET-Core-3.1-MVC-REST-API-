using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data 
{
    public interface INotificationRepo
    {
        bool SaveChanges();
        IEnumerable<Notification> GetAllNotifications();

        IEnumerable<Notification> GetNotificationByIdStudent(string id);
        Notification GetNotificationById(int id);
        void CreateNotification(Notification notification);
        void UpdateNotification(Notification notification);
        void DeleteNotification(Notification notification);
    }
}