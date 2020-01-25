using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Http;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Models;

namespace WebAPI_Test_GAP.Controllers
{
    public class PolicyController : ApiController
    {
        public IPolicyRepository PolicyRepository { get; set; }

        public PolicyController(IPolicyRepository policyRepository)
        {
            if (policyRepository == null)
            {
                throw new ArgumentNullException("policyRepository");
            }

            this.PolicyRepository = policyRepository;
        }
        public async Task<IHttpActionResult> Get(string id)
        {
            var selectedPolicy = await this.PolicyRepository.GetPolicyById(id);

            if (selectedPolicy == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(selectedPolicy);
            }
        }

        [Route("api/Policy/GetPolicies")]
        public async Task<IHttpActionResult> GetPolicies()
        {
            var selectedPolicies = await this.PolicyRepository.GetPolicies();

            if (selectedPolicies == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(selectedPolicies);
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] Policy data)
        {
            try
            {
                await this.PolicyRepository.CreatePolicy(data);
                return Request.CreateResponse(statusCode: HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(statusCode: HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody] Policy data)
        {
            try
            {
                await this.PolicyRepository.UpdatePolicy(data);
                return Request.CreateResponse(statusCode: HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(statusCode: HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete([FromBody] string id)
        {
            try
            {
                await this.PolicyRepository.DeletePolicy(id);
                return Request.CreateResponse(statusCode: HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(statusCode: HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
