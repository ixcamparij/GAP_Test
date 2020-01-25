using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class UserRepository : IUserRepository
    {
        public UserRepository() 
        {
        
        }

        public async Task<User> GetUserById(string id) 
        {
            await Task.CompletedTask;

            if (id == "1") 
            {
                return new User() { Id = "1", Name = "David", UserId = "davidix01", Password = "password" };
            }

            return null;
        }
    }
}
