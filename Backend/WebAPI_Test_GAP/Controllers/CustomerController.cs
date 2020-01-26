using System;
using System.Net;
using System.Web.Http;
using System.Threading.Tasks;
using Domain.Data;

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

        public async Task<IHttpActionResult> Get(string id)
        {
            var selectedUser = await this.CustomerRepository.GetCustomerById(id);

            if (selectedUser == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(selectedUser);
            }
        }

        [Route("api/Customer/GetCustomers")]
        public async Task<IHttpActionResult> GetCustomers()
        {
            var selectedPolicies = await this.CustomerRepository.GetCustomers();

            if (selectedPolicies == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(selectedPolicies);
            }
        }
    }
}
