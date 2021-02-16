using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(User user);
        Task<User> AddUserAsync(User user);
    }
}
