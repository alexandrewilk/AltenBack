using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Models.Entities
{
    public class UserList
    {
        public string UserEmail { get; set; } = string.Empty;
        public UserListType Type { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>(); //in real life, not a list of product but a list of IDs that are then fetched by
    }
    public enum UserListType
    {
        Basket,
        WishList
    }
}
