using Domain_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Data.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        public IDataBaseConnector DataBaseConnector { get; set; }

        public CustomerRepository(IDataBaseConnector dataBaseConnector)
        {
            if (dataBaseConnector == null)
            {
                throw new ArgumentNullException("dataBaseConnector");
            }

            this.DataBaseConnector = dataBaseConnector;
        }

        public async Task<Customer> GetCustomerById(int id) 
        {
            return await this.DataBaseConnector.GetCustomerById(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomers() 
        {
            return await this.DataBaseConnector.GetCustomers();
        }
    }
}
