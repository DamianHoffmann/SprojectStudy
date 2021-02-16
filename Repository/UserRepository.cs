using Domain;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : EfRepository, IUserRepository
    {
        public UserRepository(IApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<User> GetUserAsync(User user)
        {

            var result = await Context.Users
      
                .SingleOrDefaultAsync(u => u.Name == user.Name);
            return result;
        }
       public async Task<User> AddUserAsync(User user)
        {
           await Context.Users.AddAsync(user);
           await Context.SaveChangesAsync();
            return user;
        }
     
    }
}
