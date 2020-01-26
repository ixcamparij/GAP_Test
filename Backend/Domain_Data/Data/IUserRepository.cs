using Domain_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Data.Data
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
    }
}
