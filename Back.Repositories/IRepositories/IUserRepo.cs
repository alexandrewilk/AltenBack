using Back.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Repositories.IRepositories
{
    public interface IUserRepo
    {
        User GetUserByEmail(string email);
        void AddUser(User user);
        bool EmailExists(string email);
        
    }
}
