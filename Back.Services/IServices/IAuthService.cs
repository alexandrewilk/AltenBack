using Back.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Services.IServices
{
    public interface IAuthService
    {
        string? Authenticate(string email, string password);
        bool Register(User user, out string error);
    }
}
