using System;
using System.Net;
using System.Web.Http;
using System.Threading.Tasks;
using Domain.Data;

namespace WebAPI_Test_GAP.Controllers
{
    public class UserController : ApiController
    {
        public IUserRepository UserRepository { get; set; }

        public UserController(IUserRepository userRepository) 
        {
            if (userRepository == null) 
            { 
                throw new ArgumentNullException("userRepository"); 
            }

            this.UserRepository = userRepository;
        }
            
        public async Task<IHttpActionResult> Get(string id)
        {
            var selectedUser = await this.UserRepository.GetUserById(id);

            if (selectedUser == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(selectedUser);
            }
        }
    }
}
