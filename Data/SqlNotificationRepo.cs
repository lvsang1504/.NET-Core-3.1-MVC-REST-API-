using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlNotificationRepo : INotificationRepo
    {
        private readonly CommanderContext _context;

        public SqlNotificationRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateNotification(Notification notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }
            _context.Notifications.Add(notification);
        }

        public void DeleteNotification(Notification notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }
            _context.Notifications.Remove(notification);
        }

        public IEnumerable<Notification> GetAllNotifications()
        {
            return _context.Notifications.ToList();
        }

        public Notification GetNotificationById(int id)
        {
            return _context.Notifications.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Notification> GetNotificationByIdStudent(string id)
        {
            List<Notification> notifications = _context.Notifications.ToList();
            List<Notification> notificationsResult = new List<Notification>();
            foreach (Notification notification in notifications)
            {
                string idStudent = notification.IdStudent.ToLower().Trim();
                if (idStudent.CompareTo(id.ToLower()) == 0)
                {
                    notificationsResult.Add(notification);
                }
            }

            return notificationsResult;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateNotification(Notification notification)
        {
            //Nothing
        }
    }
}