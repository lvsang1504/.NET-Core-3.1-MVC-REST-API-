using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data 
{
    public interface IUserRepo
    {
        bool SaveChanges();
        IEnumerable<User> GetAllUsers();

        User GetUserById(int id);

        User GetUserByIdFirebase(string idFirebase);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        IEnumerable<User> GetUserByIdRole(int id);
    }
}