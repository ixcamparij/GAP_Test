using Domain_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Data.Data
{
    public class UserRepository : IUserRepository
    {
        public IDataBaseConnector DatBaseConnector { get; set; }

        public UserRepository(IDataBaseConnector datBaseConnector)
        {
            if (datBaseConnector == null)
            {
                throw new ArgumentNullException("datBaseConnector");
            }

            this.DatBaseConnector = datBaseConnector;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await this.DatBaseConnector.GetUserByIdAsync(id);
        }

        public async Task<bool> GetUserAuthenticationAsync(User user)
        {
            var users = await this.DatBaseConnector.GetUsersAsync();
            var test = users.Where(x => x.UserId.ToLower() == user.UserId.ToLower() && x.Password == user.Password);

            return test != null && test.Count() > 0;
        }
        
    }
}
