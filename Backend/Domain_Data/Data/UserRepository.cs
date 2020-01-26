using Domain_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Data.Data
{
    public class UserRepository : IUserRepository
    {
        public IDataBaseConnector DataBaseConnector { get; set; }

        public UserRepository(IDataBaseConnector dataBaseConnector) 
        {
            if (dataBaseConnector == null) 
            {
                throw new ArgumentNullException("dataBaseConnector");
            }

            this.DataBaseConnector = dataBaseConnector;
        }

        public async Task<User> GetUserById(int id) 
        {
            var user = await this.DataBaseConnector.GetUserById(id);
            return user;
        }
    }
}
