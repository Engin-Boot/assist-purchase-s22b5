using System.Collections.Generic;

namespace DataAccessLayer.UserManagement
{
    public interface IUserManagement
    {
        bool AddUser(Users user);
        IEnumerable<Users> ShowAllUser();
        bool RemoveUser(Users user);
        bool UpdateUser(Users user);
        Users GetUser(string username);
    }
}