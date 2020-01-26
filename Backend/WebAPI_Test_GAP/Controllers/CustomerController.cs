using System;
using System.Net;
using System.Web.Http;
using System.Threading.Tasks;
using Domain_Data.Data;
using NHibernate;
using System.Linq;
using System.Collections.Generic;
using Domain_Data.Models;

namespace WebAPI_Test_GAP.Controllers
{
    public class CustomerController : ApiController
    {
        public ICustomerRepository CustomerRepository { get; set; }

        public CustomerController(ICustomerRepository customerRepository)
        {
            if (customerRepository == null)
            {
                throw new ArgumentNullException("customerRepository");
            }

            this.CustomerRepository = customerRepository;
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            Customer selectedCustomer = await this.CustomerRepository.GetCustomerById(id);   
            if (selectedCustomer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(selectedCustomer);
            }
        }

        [Route("api/Customer/GetCustomers")]
        public async Task<IHttpActionResult> GetCustomers()
        {
            var selectedCustomers = await this.CustomerRepository.GetCustomers();
            if (selectedCustomers == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(selectedCustomers);
            }
        }
    }
}
