using Domain_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Data.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        public IDataBaseConnector DatBaseConnector { get; set; }

        public CustomerRepository(IDataBaseConnector datBaseConnector)
        {
            if (datBaseConnector == null)
            {
                throw new ArgumentNullException("datBaseConnector");
            }

            this.DatBaseConnector = datBaseConnector;
        }


        public async Task<Customer> GetCustomerByIdAsync(int id) 
        {
            return await this.DatBaseConnector.GetCustomerByIdAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync() 
        {
            return await this.DatBaseConnector.GetCustomersAsync();
        }
    }
}
