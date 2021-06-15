using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data 
{
    public interface ITopicRepo
    {
        bool SaveChanges();
        IEnumerable<Topic> GetAllTopics();
        Topic GetTopicById(int id);
        void CreateTopic(Topic topic);
        void UpdateTopic(Topic topic);
        void DeleteTopic(Topic topic);
    }
}