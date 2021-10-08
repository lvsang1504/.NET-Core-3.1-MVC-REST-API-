using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly CommanderContext _context;

        public SqlUserRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if(user == null) 
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
             if(user == null) 
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public User GetUserByIdFirebase(string idFirebase)
        {
            return _context.Users.FirstOrDefault(p => p.KeyFirebase == idFirebase);
        }

        public IEnumerable<User> GetUserByIdRole(int id)
        {
            List<User> users = _context.Users.ToList();
            List<User> usersResult = new List<User>();
            foreach (User user in users)
            {
                int role = user.Role;
                if (role == id)
                {
                    usersResult.Add(user);
                }
            }
            return usersResult;
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(User user)
        {
            //Nothing
        }
    }
}