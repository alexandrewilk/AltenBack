using Back.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Repositories.IRepositories
{
    public interface IUserListRepo
    {
        UserList? AddProductToList(string userEmail, Product product, UserListType type);
        UserList? GetListByUserEmailAndType(string userEmail, UserListType type);
        bool RemoveProductFromList(string userEmail, int productId, UserListType type);
        UserList? ClearList(string userEmail, UserListType type);
    }
}
