using Back.Models.Entities;
using Back.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Repositories.Repositories
{
    public class UserListRepo: JsonRepoBase<UserList>, IUserListRepo
    {
        public UserListRepo() : base("userlists.json")
        {
        }

        public UserList? AddProductToList(string userEmail, Product product, UserListType type)
        {
            var userList = GetListByUserEmailAndType(userEmail, type);
            if (userList == null)
            {
                userList = new UserList { UserEmail = userEmail, Type = type };
                _items.Add(userList);
            }
            userList.Products.Add(product);
            SaveChanges();
            return userList;
        }
        public UserList? GetListByUserEmailAndType(string userEmail, UserListType type)
        {
            return _items.FirstOrDefault(ul => ul.UserEmail == userEmail && ul.Type == type);
        }
        public bool RemoveProductFromList(string userEmail, int productId, UserListType type)
        {
            var userList = GetListByUserEmailAndType(userEmail, type);
            if (userList == null) return false;

            var productToRemove = userList.Products.FirstOrDefault(p => p.Id == productId);
            if (productToRemove == null) return false;

            userList.Products.Remove(productToRemove);
            SaveChanges();
            return true;
        }
        public UserList? ClearList(string userEmail, UserListType type)
        {
            var userList = GetListByUserEmailAndType(userEmail, type);
            if (userList == null) return null;

            userList.Products.Clear();
            SaveChanges();
            return userList;
        }
    }
}
