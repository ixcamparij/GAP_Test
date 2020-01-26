using Domain_Data.Models;
using System;
using System.Collections.Generic;
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
            return await this.DatBaseConnector.GetUserAuthenticationAsync(user);
        }

        
    }
}
