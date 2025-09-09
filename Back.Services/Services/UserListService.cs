using Back.Models.Entities;
using Back.Repositories.IRepositories;
using Back.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Services.Services
{
    public class UserListService : IUserListService
    {
        private readonly IUserListRepo _userListRepo;
        private readonly IProductRepo _productRepo;

        public UserListService(IUserListRepo userListRepo, IProductRepo productRepo)
        {
            _userListRepo = userListRepo;
            _productRepo = productRepo;
        }

        public UserList? AddProductToList(string userEmail, int productId, UserListType type)
        {
            var product = _productRepo.GetProductById(productId);
            if (product == null) return null;
       
            return _userListRepo.AddProductToList(userEmail, product, type);
        }

        public UserList? GetList(string userEmail, UserListType type)
        {
            return _userListRepo.GetListByUserEmailAndType(userEmail, type);
        }

        public bool RemoveProductFromList(string userEmail, int productId, UserListType type)
        {
            return _userListRepo.RemoveProductFromList(userEmail, productId, type);
        }

        public UserList? ClearList(string userEmail, UserListType type)
        {
            return _userListRepo.ClearList(userEmail, type);
        }
    }
}
