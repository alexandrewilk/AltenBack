using Back.Models.Entities;
using Back.Repositories.IRepositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Repositories.Repositories
{
    public class UserRepo : JsonRepoBase<User>, IUserRepo
    {
        public UserRepo() : base("users.json")
        {
        }

        public User GetUserByEmail(string email)
        {
            return _items.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public bool EmailExists(string email)
        {
            return _items.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public void AddUser(User user)
        {
            _items.Add(user);
            SaveChanges();
        }
    }
}
