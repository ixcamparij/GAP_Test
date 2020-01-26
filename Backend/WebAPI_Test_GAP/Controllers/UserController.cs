using System;
using System.Net;
using System.Web.Http;
using System.Threading.Tasks;
using Domain_Data.Data;
using Domain_Data.Models;
using System.Net.Http;

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
            
        public async Task<IHttpActionResult> Get(int id)
        {
            var selectedUser = await this.UserRepository.GetUserByIdAsync(id);

            if (selectedUser == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(selectedUser);
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] User data)
        {
            try
            {
                var Auth = await this.UserRepository.GetUserAuthenticationAsync(data);
                return Request.CreateResponse(statusCode: HttpStatusCode.OK, Auth);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(statusCode: HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
