using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlTopicRepo : ITopicRepo
    {
        private readonly CommanderContext _context;

        public SqlTopicRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateTopic(Topic topic)
        {
            if(topic == null) 
            {
                throw new ArgumentNullException(nameof(topic));
            }
            _context.Topics.Add(topic);
        }

        public void DeleteTopic(Topic topic)
        {
             if(topic == null) 
            {
                throw new ArgumentNullException(nameof(topic));
            }
            _context.Topics.Remove(topic);
        }

        public IEnumerable<Topic> GetAllTopics()
        {
            return _context.Topics.ToList();
        }

        public Topic GetTopicById(int id)
        {
            return _context.Topics.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public void UpdateTopic(Topic topic)
        {
            //Nothing
        }
    }
}