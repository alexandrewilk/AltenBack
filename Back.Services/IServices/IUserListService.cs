using Back.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Services.IServices
{
    public interface IUserListService
    {
        UserList? AddProductToList(string userEmail, int productId, UserListType type);
        UserList? GetList(string userEmail, UserListType type);
        bool RemoveProductFromList(string userEmail, int productId, UserListType type);
        UserList? ClearList(string userEmail, UserListType type);
    }
}
