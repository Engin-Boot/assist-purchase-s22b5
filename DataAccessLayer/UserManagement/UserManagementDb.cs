using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.UserManagement
{
    class UserManagementDb:IUserManagement
    {
        private static List<Users> _db = new List<Users>();
        public UserManagementDb()
        {
            _db.Add(new Users
            {
                Name = "Shashank",
                Email = "shashank@gmail.com",
                Password = "sha@123"
            });
            _db.Add(new Users
            {
                Name = "Ram",
                Email = "Ram@gmail.com",
                Password = "ram@123"
            });
            _db.Add(new Users
            {
                Name = "test",
                Email = "test@gmail.com",
                Password = "test@123"
            });
        }
        public bool AddUser(Users user)
        {
            try
            {
                _db.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Users> ShowAllUser()
        {
            return _db;
        }

        public bool RemoveUser(Users user)
        {
            foreach (var user1 in _db.Where(user1 => user.Email == user1.Email))
            {
                _db.Remove(user1);
                return true;
            }

            return false;
        }

        public bool UpdateUser(Users user)
        {
            for (var i = 0; i < _db.Count; i++)
            {
                if (user.Email != _db[i].Email) continue;
                _db.RemoveAt(i);
                _db.Insert(i, user);
                return true;
            }

            return false;
        }

        public Users GetUser(string username)
        {
            return _db.FirstOrDefault(user => user.Email == username);
        }
    }
}
